using DbOpertion.Function;
using DbOpertion.Models;
using log4net;
using SLSM.DBOpertion.Function;
using SLSM.DBOpertion.Model.Extend.Response.GradeRes;
using SLSM.Web.Common.BaseController;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using WxPayAPI;

namespace SLSM.MoblieWeb.Controllers.PageController
{

    /// <summary>
    /// 主页控制器
    /// </summary>
    public class MainController : BaseMvcMasterController
    {
        JsApiPay jsApiPay = new JsApiPay();
        //创建日志记录组件实例
        ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        /// <summary>
        /// 首页
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            if (Session["openid"] == null)
            {
                try
                {
                    //调用【网页授权获取用户信息】接口获取用户的openid和access_token
                    GetOpenidAndAccessToken();

                }
                catch (Exception ex)
                {
                    //Response.Write(ex.ToString());
                    //throw;
                }
            }
            var hotGrade = GradeFunc.Instance.GetHotGrade(4);
            ViewBag.hotGrade = hotGrade ?? new List<GradeId_Name_Img>();
            ViewBag.Commrecommend = CommrecommendFunc.Instance.SelectByModel(null);
            ViewBag.commodity = CommodityPriceFunc.Instance.SelectByRecommendTime(0, 8);
            ViewBag.Images = Carousel_ImageFunc.Instance.SelectTopMobileImages(0, 6);
            return View();
        }

        /// <summary>
        /// 网页授权获取用户基本信息的全部过程
        /// 详情请参看网页授权获取用户基本信息：http://mp.weixin.qq.com/wiki/17/c0f37d5704f0b64713d5d2c37b468d75.html
        /// 第一步：利用url跳转获取code
        /// 第二步：利用code去获取openid和access_token
        /// </summary>

        public void GetOpenidAndAccessToken()
        {
            if (Session["code"] != null)
            {
                //获取code码，以获取openid和access_token
                string code = Session["code"].ToString();
                Log.Debug(this.GetType().ToString(), "Get code : " + code);
                jsApiPay.GetOpenidAndAccessTokenFromCode(code);
            }
            else
            {
                //构造网页授权获取code的URL
                string host = Request.Url.Host;
                string path = Request.Path;
                string redirect_uri = HttpUtility.UrlEncode("http://" + host + path);
                //string redirect_uri = HttpUtility.UrlEncode("http://gzh.lmx.ren");
                WxPayData data = new WxPayData();
                data.SetValue("appid", WxPayConfig.APPID);
                data.SetValue("redirect_uri", redirect_uri);
                data.SetValue("response_type", "code");
                data.SetValue("scope", "snsapi_base");
                data.SetValue("state", "STATE" + "#wechat_redirect");
                string url = "https://open.weixin.qq.com/connect/oauth2/authorize?" + data.ToUrl();
                Log.Debug(this.GetType().ToString(), "Will Redirect to URL : " + url);
                Session["url"] = url;
            }
        }
    }
}