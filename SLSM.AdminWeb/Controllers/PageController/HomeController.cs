using Common.Helper;
using Common.ThirdParty.AliPay;
using DbOpertion.Function;
using SLSM.AdminWeb.Common.BaseController;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace SLSM.AdminWeb.Controllers
{
    public class HomeController : BaseMvcMasterController
    {
        // GET: Home
        public ActionResult Index(AliPagePayRequest request)
        {
            var userGuid = CookieOper.Instance.GetUserGuid();
            var user = MemCacheHelper2.Instance.Cache.GetModel<DbOpertion.Models.Erploginuer>("AdminUserGuID_" + userGuid);
            if (user == null)
            {
                return RedirectToAction("Login", "Login");
            }
            return View();
        }

        public ActionResult Grade()
        {
            return View();
        }
    }
}