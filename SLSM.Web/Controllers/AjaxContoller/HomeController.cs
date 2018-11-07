//using Aliyun.Acs.Dysmsapi.Model.V20170525;
//using AliyunHelper.SendMail;
using Common.Extend;
using Common.Filter.WebApi;
using Common.Helper;
using Common.Result;
using Common.ThirdParty.WeChatLogin;
using DbOpertion.Function;
using DbOpertion.Models;
using DbOpertion.Operation;
using log4net;
using SLSM.DBOpertion.Function;
using SLSM.Web.Models.Resquest.Home;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Text;
using System.Web;
using System.Web.Http;
using System.Web.SessionState;
using ThoughtWorks.QRCode.Codec;

namespace SLSM.Web.Controllers.AjaxContoller
{
    /// <summary>
    /// 主页API控制器
    /// </summary>
    public class HomeController : BaseApiController
    {
        ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        #region 登入信息
        /// <summary>
        /// 发送手机验证码
        /// </summary>
        /// <param name="request">请求</param>
        [HttpPost]
        public ResultJson SendPhoneCode(LoginByPhoneRequest request)
        {
            ResultJson result = new ResultJson();
            #region 第三方登入直接发送验证码
            if (request.IsThild == true)
            {
                var resultCode = UserFunc.Instance.SetUserPhoneCodeCached(request.UserPhone);
                if (resultCode == "手机验证码发送成功！")
                {
                    result.HttpCode = 200;
                    result.Message = "发送信息成功！";
                }
                else
                {
                    result.HttpCode = 500;
                    result.Message = resultCode;
                }
                return result;
            }
            #endregion

            #region 筛选图片验证码并判断是否为空
            var userGuid = CookieOper.Instance.GetUserGuid();
            var yzmcode = MemCacheHelper2.Instance.Cache.GetModel<string>("yzmCode_" + userGuid);
            if (yzmcode.IsNullOrEmpty() || request.ImageCode.IsNullOrEmpty())
            {
                result.HttpCode = 300;
                result.Message = "请输入图片验证码！";
                return result;
            }
            #endregion

            if (yzmcode.ToString().ToLower() == request.ImageCode.ToLower())
            {
                #region 发送验证码
                var resultCode = UserFunc.Instance.SetUserPhoneCodeCached(request.UserPhone);
                if (resultCode == "手机验证码发送成功！")
                {
                    result.HttpCode = 200;
                    result.Message = "发送信息成功！";
                }
                else
                {
                    result.HttpCode = 500;
                    result.Message = resultCode;
                }
                #endregion
            }
            else
            {
                result.HttpCode = 300;
                result.Message = "输入的验证码不正确！";
            }

            return result;
        }

        /// <summary>
        /// 手机号登入
        /// </summary>
        /// <param name="request">请求</param>
        [HttpPost]
        public ResultJson LoginByPhone(LoginByPhoneRequest request)
        {
            //由于Session重启应用是就会取消，所以暂时存在Cookie里面;
            var userGuid = CookieOper.Instance.GetUserGuid();

            #region 不是第三方登入需要验证码验证
            if (request.IsThild != true)
            {
                var yzmcode = MemCacheHelper2.Instance.Cache.Get("yzmCode_" + userGuid);
                if (yzmcode != null && request.ImageCode == null)
                {
                    return new ResultJson { HttpCode = 300, Message = "请输入图片验证码！" };
                }
                if (yzmcode.ToString().ToLower() != request.ImageCode.ToLower())
                {
                    return new ResultJson { HttpCode = 300, Message = "验证码错误，请输入正确的图片验证码！" };
                }
            }
            #endregion

            #region 用户登录
            var LoginResult = UserFunc.Instance.LoginUser(request.UserPhone, request.PhoneCode, request.Password);
            if (LoginResult.Item1 == null)
            {
                return new ResultJson { HttpCode = 300, Message = LoginResult.Item2 };
            }
            else
            {
                #region 如果微信登入Id不为空（微信注册）
                if (!request.openWechatid.IsNullOrEmpty())
                {
                    if (!LoginResult.Item1.WeChat.IsNullOrEmpty())
                    {
                        return new ResultJson { HttpCode = 300, Message = "该账户已绑定一个微信号！" };
                    }

                    #region 修改用户的微信登入Id
                    string result;
                    if (LoginResult.Item3 == true)
                    {
                        var loginResult = WeChatLoginHelper.Instance.GetUserInfo(request.accessToken, request.openWechatid);
                        if (loginResult.errcode.IsNullOrEmpty())
                        {
                            result = UserFunc.Instance.UpdateModel(new User
                            {
                                WeChat = request.openWechatid,
                                IsDelete = false,
                                Id = LoginResult.Item1.Id,
                                Name = loginResult.nickname,
                                Sex = loginResult.sex == "1" ? true : false,
                                Phone = LoginResult.Item1.Phone
                            });
                        }
                        else
                        {
                            return new ResultJson { HttpCode = 300, Message = loginResult.errmsg };
                        }

                    }
                    else
                    {
                        result = UserFunc.Instance.UpdateModel(new User { WeChat = request.openWechatid, IsDelete = false, Id = LoginResult.Item1.Id, Phone = LoginResult.Item1.Phone });
                    }
                    #endregion

                    if (result == "成功！")
                    {
                        MemCacheHelper2.Instance.Cache.Set("UserGuID_" + userGuid, LoginResult.Item1, DateTime.Now.AddDays(29));
                        return new ResultJson { HttpCode = 200, Message = "登入成功！" };
                    }
                    else
                    {
                        return new ResultJson { HttpCode = 300, Message = result };
                    }
                }
                #endregion

                #region 密码登入
                else
                {
                    MemCacheHelper2.Instance.Cache.Set("UserGuID_" + userGuid, LoginResult.Item1, 24 * 60);
                    return new ResultJson { HttpCode = 200, Message = "登入成功！" };
                }
                #endregion
            }
            #endregion
        }

        /// <summary>
        /// 手机号登入
        /// </summary>
        /// <param name="request">请求</param>
        [HttpPost]
        public ResultJson GetUserAccount(LoginByPhoneRequest request)
        {
            var Result = UserFunc.Instance.SelectByModel(new User { Phone = request.UserPhone });
            if (Result.Count == 0)
            {
                return new ResultJson { HttpCode = 200, Message = "没有此用户请验证码登入！" };
            }
            else
            {
                return new ResultJson { HttpCode = 200, Message = "登入成功！" };
            }
        }

        /// <summary>
        /// 获得用户是否登入
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ResultJsonModel<string> GetUserLogin()
        {
            ResultJsonModel<string> result = new ResultJsonModel<string>();
            var userGuid = CookieOper.Instance.GetUserGuid();
            var user = MemCacheHelper2.Instance.Cache.GetModel<User>("UserGuID_" + userGuid);
            if (user != null)
            {
                result.HttpCode = 200;
                result.Message = "用户已登入";
                result.Model1 = user.Name;
            }
            else
            {
                result.HttpCode = 200;
                result.Message = "用户未登入";
            }
            return result;
        }

        /// <summary>
        /// 退出登入
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ResultJsonModel ExitUserLogin()
        {
            ResultJsonModel result = new ResultJsonModel();
            var userGuid = CookieOper.Instance.GetUserGuid();
            var flag = MemCacheHelper2.Instance.Cache.Delete("UserGuID_" + userGuid);
            if (flag)
            {
                result.HttpCode = 200;
                result.Message = "退出登入成功";
            }
            else
            {
                result.HttpCode = 300;
                result.Message = "退出登入失败";
            }
            return result;
        }

        /// <summary>
        /// 微信登入
        /// </summary>
        /// <param name="Code"></param>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage WeChatLoginIn(string Code)
        {
            var result = WeChatLoginHelper.Instance.GetAccessToken(Code);
            log.Error(result.errcode);
            if (result.errcode.IsNullOrEmpty())
            {
                var user = UserFunc.Instance.SelectByModel(new User { IsDelete = false, WeChat = result.openid }).FirstOrDefault();
                #region 用户成功登入
                if (user != null)
                {
                    var userGuid = CookieOper.Instance.GetUserGuid();
                    MemCacheHelper2.Instance.Cache.Set("UserGuID_" + userGuid, user, 24 * 60);
                    #region 刷新父页面
                    var httpResponseMessage = new HttpResponseMessage();
                    httpResponseMessage.Content = new StringContent(@"<script>var parentWin = window;
                                                            while (parentWin != parentWin.parent)
                                                            {
                                                                parentWin = parentWin.parent;
                                                            }
                                                            parentWin.location.reload();
                                                            </script>", Encoding.UTF8);
                    httpResponseMessage.Content.Headers.ContentType = new MediaTypeHeaderValue("text/html");
                    return httpResponseMessage;
                    #endregion
                }
                #endregion
                #region 用户登入失败
                else
                {
                    var userInfo = WeChatLoginHelper.Instance.GetUserInfo(result.access_token, result.openid);
                    #region 刷新父页面
                    var httpResponseMessage = new HttpResponseMessage();
                    httpResponseMessage.Content = new StringContent(@"<script>var parentWin = window;
                                                            while (parentWin != parentWin.parent)
                                                            {
                                                                parentWin = parentWin.parent;
                                                            }
                                                            parentWin.document.getElementById('openWechatid').value='" + result.openid + @"';
                                                            parentWin.document.getElementById('accessToken').value='" + result.access_token + @"';
                                                            parentWin.document.getElementById('Login_Form').style.display='none';
                                                            parentWin.document.getElementById('login_container').style.display='none';
                                                            parentWin.document.getElementById('Register').style.display='block';
                                                            </script>", Encoding.UTF8);
                    httpResponseMessage.Content.Headers.ContentType = new MediaTypeHeaderValue("text/html");
                    return httpResponseMessage;
                    #endregion
                }
                #endregion
            }
            else
            {
                #region 如果通行证获取失败,刷新当前页面
                var httpResponseMessage = new HttpResponseMessage();
                httpResponseMessage.Content = new StringContent(@"<script>alert('result.errcode');</script>", Encoding.UTF8);
                httpResponseMessage.Content.Headers.ContentType = new MediaTypeHeaderValue("text/html");
                return httpResponseMessage;
                #endregion
            }
        }

        #endregion

        /// <summary>  
        /// 获得验证码图片  
        /// </summary>  
        public HttpResponseMessage GetYZMImage()
        {
            YZMHelper yzmhelper = new YZMHelper();
            var userGuid = CookieOper.Instance.GetUserGuid();
            MemCacheHelper2.Instance.Cache.Set("yzmCode_" + userGuid, yzmhelper.Text, DateTime.Now.AddMinutes(30));
            var resp = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new ByteArrayContent(yzmhelper.GetVaildateBytes())
            };
            resp.Content.Headers.ContentType = new MediaTypeHeaderValue("image/jpg");
            return resp;
        }

        /// <summary>  
        /// 获得祝福二维码
        /// </summary>  
        public HttpResponseMessage GetQrCode(string data, string OrderNo)
        {
            if (!string.IsNullOrEmpty(data) && !string.IsNullOrEmpty(data))
            {
                string str = data;
                //初始化二维码生成工具
                QRCodeEncoder qrCodeEncoder = new QRCodeEncoder();
                qrCodeEncoder.QRCodeEncodeMode = QRCodeEncoder.ENCODE_MODE.BYTE;
                qrCodeEncoder.QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.M;
                qrCodeEncoder.QRCodeVersion = 0;
                qrCodeEncoder.QRCodeScale = 4;

                //将字符串生成二维码图片
                Bitmap image = qrCodeEncoder.Encode(str, Encoding.Default);

                //保存为PNG到内存流  
                MemoryStream ms = new MemoryStream();
                image.Save(ms, ImageFormat.Png);
                var order = Order_InfoFunc.Instance.SelectByModel(new Order_Info { OrderNo = OrderNo }).FirstOrDefault();
                if (order != null)
                {
                    Order_InfoFunc.Instance.Update(new Order_Info { Id = order.Id, OrderNo = OrderNo, LastCodeTime = DateTime.Now, WechatFaild = false });
                }
                //输出二维码图片
                var resp = new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new ByteArrayContent(ms.GetBuffer())
                };
                resp.Content.Headers.ContentType = new MediaTypeHeaderValue("image/png");
                return resp;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 获得省份的信息
        /// </summary>
        [HttpPost]
        public string GetProvinceInfo(ProvinceRequest request)
        {
            if (request.Level.ToLower() == "province")
            {
                var result = ProvinceHelper.Instance.GetProvince();
                return result;
            }
            else if (request.Level.ToLower() == "city")
            {
                if (!request.AreaName.IsNullOrEmpty())
                {
                    var result = ProvinceHelper.Instance.GetCity(request.AreaName);
                    return result;
                }
            }
            else if (request.Level.ToLower() == "area")
            {
                if (!request.AreaName.IsNullOrEmpty())
                {
                    var result = ProvinceHelper.Instance.GetArea(request.AreaName);
                    return result;
                }
            }
            return "[]";
        }



        /// <summary>
        /// 发送手机验证码
        /// </summary>
        /// <param name="request">请求</param>
        [HttpPost]
        public ResultJson SendReSetPhone(LoginByPhoneRequest request)
        {
            ResultJson result = new ResultJson();
            var userGuid = CookieOper.Instance.GetUserGuid();
            var resultCode = UserFunc.Instance.SetUserPhoneCodeCached(request.UserPhone);
            if (resultCode == "手机验证码发送成功！")
            {
                result.HttpCode = 200;
                result.Message = "发送信息成功！";
            }
            else
            {
                result.HttpCode = 500;
                result.Message = resultCode;
            }
            return result;
        }
    }
}