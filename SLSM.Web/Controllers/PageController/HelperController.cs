using SLSM.MoblieWeb.Common.BaseController;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SLSM.Web.Controllers.PageController
{
    public class HelperController : BaseMvcMasterController
    {

        /// <summary>
        /// 隐秘政策
        /// </summary>
        /// <returns></returns>
        public ActionResult PrivacyPolicy()
        {
            return View();
        }

        /// <summary>
        /// 使用条款
        /// </summary>
        /// <returns></returns>
        public ActionResult TermOfUser()
        {
            return View();
        }

        /// <summary>
        /// 网站地图
        /// </summary>
        /// <returns></returns>
        public ActionResult WebMap()
        {
            return View();
        }

        /// <summary>
        /// 购买指南
        /// </summary>
        /// <returns></returns>
        public ActionResult PurchaseGuide()
        {
            var tabname = Request.QueryString["tabname"];
            ViewBag.tabname = string.IsNullOrEmpty(tabname) ? "" : tabname.ToLower();
            return View();
        }

        /// <summary>
        /// 关于我们
        /// </summary>
        /// <returns></returns>
        public ActionResult AboutUs()
        {
            var tabname = Request.QueryString["tabname"];
            ViewBag.tabname = string.IsNullOrEmpty(tabname) ? "" : tabname.ToLower();
            return View();
        }
    }
}