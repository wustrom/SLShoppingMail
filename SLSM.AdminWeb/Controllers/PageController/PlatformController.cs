using DbOpertion.Function;
using SLSM.AdminWeb.Common.BaseController;
using SLSM.DBOpertion.Function;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SLSM.AdminWeb.Controllers.PageController
{
    /// <summary>
    /// 平台概览统计
    /// </summary>
    public class PlatformController : BaseMvcMasterController
    {
        /// <summary>
        /// 今日成交量
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            ViewBag.TodayOrder =TodaysuccessorderFunc.Instance.SelectByModel(null).FirstOrDefault();
            return View();
        }

        /// <summary>
        /// 平台链接
        /// </summary>
        /// <returns></returns>
        public ActionResult PlatLink()
        {
            ViewBag.TodayOrder = TodaysuccessorderFunc.Instance.SelectByModel(null).FirstOrDefault();
            return View();
        }

        /// <summary>
        /// 管理平台帐号权限
        /// </summary>
        /// <returns></returns>
        public ActionResult ManagePlat()
        {
            return View();
        }
    }
}