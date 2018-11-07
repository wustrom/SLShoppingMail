using Common.Helper;
using Common.Result;
using DbOpertion.Function;
using SLSM.DBOpertion.Function;
using SLSM.MoblieWeb.Models.Resquest.Home;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SLSM.MoblieWeb.Controllers.AjaxController
{
    /// <summary>
    /// 登入控制器
    /// </summary>
    public class LoginController : ApiController
    {
        /// <summary>
        /// 发送手机验证码
        /// </summary>
        /// <param name="request">请求</param>
        [HttpPost]
        public ResultJson SendPhoneCode(LoginByPhoneRequest request)
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

        /// <summary>
        /// 手机号登入
        /// </summary>
        /// <param name="request">请求</param>
        [HttpPost]
        public ResultJson LoginByPhone(LoginByPhoneRequest request)
        {
            var userGuid = CookieOper.Instance.GetUserGuid();
            var LoginResult = UserFunc.Instance.LoginUser(request.UserPhone, request.PhoneCode, request.Password);
            if (LoginResult.Item1 == null)
            {
                return new ResultJson { HttpCode = 300, Message = LoginResult.Item2 };
            }
            else
            {
                //由于Session重启应用是就会取消，所以暂时存在Cookie里面;;
                MemCacheHelper2.Instance.Cache.Set("UserGuID_" + userGuid, LoginResult.Item1, DateTime.Now.AddDays(29));
                return new ResultJson { HttpCode = 200, Message = "登入成功！" };
            }
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
    }
}