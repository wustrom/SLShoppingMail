using Common.Extend;
using SLSM.ErpWeb.App_Start;
using SLSM.ErpWeb.Common.BaseController;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SLSM.ErpWeb.Controllers.PageController
{
    public class ServiceController : BaseMvcMasterController
    {
        #region 订单管理
        // GET: Service
        /// <summary>
        /// 订单
        /// </summary>
        /// <returns></returns>
        [UserAuthorize]
        public ActionResult OrderInfo()
        {
            var ReturnText = HttpContext.Request.QueryString["ReturnText"].ParseInt();
            if(ReturnText!=null)
            {
                ViewBag.ReturnText = ReturnText;
            }
            return View();
        }
        #endregion
    }
}