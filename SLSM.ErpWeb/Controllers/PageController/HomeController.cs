using Common.Helper;
using DbOpertion.Function;
using DbOpertion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SLSM.ErpWeb.Controllers.PageController
{
    public class HomeController : Controller
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            var userGuid = CookieOper.Instance.GetUserGuid();
            var user = MemCacheHelper2.Instance.Cache.GetModel<Erploginuer>("ErpUserGuID_" + userGuid);
            if (user == null)
            {
                return RedirectToAction("Login", "Login");
            }
            ViewBag.UserName = user.erpLoginName;
            var Id = ErploginuerFunc.Instance.SelectByModel(new Erploginuer { erpLoginName = user.erpLoginName.ToString() }).FirstOrDefault().ErproleId;
            var ERProlePower = ErpuserFunc.Instance.SelectById(Id.Value).ERProlePower;
            ViewBag.ERProlePower = ERProlePower;

            return View();
        }
    }
}