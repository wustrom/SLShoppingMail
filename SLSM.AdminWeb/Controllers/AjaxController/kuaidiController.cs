using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Common.ThirdParty.KdGold;

namespace SLSM.AdminWeb.Controllers.AjaxController
{
    public class kuaidiController : ApiController
    {
        [HttpGet]
        public KdApiResult aaa()
        {
            return KdApiSearchDemo.Instance.getOrderTracesByJson("韵达速递", "3852861307512");
        }
    }
}