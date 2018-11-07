using log4net;
using SLSM.MoblieWeb.Models.Response;
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

    public class HomeController : BaseMvcMasterController
    {
        JsApiPay jsApiPay = new JsApiPay();
        //创建日志记录组件实例
        ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }



        /// <summary>
        /// 获取code
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult getCode()
        {
            object objResult = "";
            if (Session["url"] != null)
            {
                objResult = Session["url"].ToString();
            }
            else
            {
                objResult = "url为空。";
            }
            return Json(objResult);
        }

        /// <summary>
        /// 通过code换取网页授权access_token和openid的返回数据
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult getWxInfo()
        {
            object objResult = "";
            string strCode = Request.Form["code"];
            log.Error($"code:{strCode}");
            if (Session["access_token"] == null || Session["openid"] == null)
            {
                jsApiPay.GetOpenidAndAccessTokenFromCode(strCode);
            }
            string strAccess_Token = Session["access_token"].ToString();
            string strOpenid = Session["openid"].ToString();
            objResult = new { openid = strOpenid, access_token = strAccess_Token };
            return Json(objResult);
        }


        /// <summary>
        /// 生成订单信息
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult MeterRecharge()
        {
            object objResult = "";
            string strTotal_fee = Request.Form["totalfee"];
            string strOut_trade_no = Request.Form["out_trade_no"];
            string strFee = (double.Parse(strTotal_fee) * 100).ToString();
            //若传递了相关参数，则调统一下单接口，获得后续相关接口的入口参数
            jsApiPay.openid = Session["openid"].ToString();
            jsApiPay.total_fee = int.Parse(strFee);
            log.Error($"out_trade_no:{strOut_trade_no}");
            //JSAPI支付预处理
            try
            {
                string strBody = "赛龙商城微信支付";//商品描述
                WxPayData unifiedOrderResult = jsApiPay.GetUnifiedOrderResult(strBody, strOut_trade_no);
                WxPayData wxJsApiParam = jsApiPay.GetJsApiParameters();//获取H5调起JS API参数，注意，这里引用了官方的demo的方法，由于原方法是返回string的，所以，要对原方法改为下面的代码，代码在下一段
                ModelForOrder aOrder = new ModelForOrder()
                {
                    appId = wxJsApiParam.GetValue("appId").ToString(),
                    nonceStr = wxJsApiParam.GetValue("nonceStr").ToString(),
                    packageValue = wxJsApiParam.GetValue("package").ToString(),
                    paySign = wxJsApiParam.GetValue("paySign").ToString(),
                    timeStamp = wxJsApiParam.GetValue("timeStamp").ToString(),
                    msg = "成功下单,正在接入微信支付."
                };
                objResult = aOrder;
            }
            catch (Exception ex)
            {
                log.Error(ex);
                ModelForOrder aOrder = new ModelForOrder()
                {
                    appId = "",
                    nonceStr = "",
                    packageValue = "",
                    paySign = "",
                    timeStamp = "",
                    msg = "下单失败，请重试,多次失败,请联系管理员."
                };
                objResult = aOrder;
            }
            return Json(objResult);
        }
    }
}