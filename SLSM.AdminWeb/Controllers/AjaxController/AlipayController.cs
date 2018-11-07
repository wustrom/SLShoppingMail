using Common.ThirdParty;
using Common.ThirdParty.Qisuso;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WxPayAPI;

namespace SLSM.AdminWeb.Controllers.AjaxController
{
    public class AlipayController : ApiController
    {
        [HttpGet]
        public string OrderCreateInfo()
        {
            //var aaa = JsApiPay.Instance.GetJsApiParameters();

            var result = AlipayHelper.Instance.CreateAlipayPageOrder("0.01", "000adasdas", "http://www.syloon.cn/UserInfo/AliPayOrder", "", "赛龙商城");
            return result;
        }
        [HttpPost]
        public void OrderSuccessInfo()
        {

        }
    }
}