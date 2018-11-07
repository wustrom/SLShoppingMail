using SLSM.AdminWeb.Common.BaseController;
using SLSM.AdminWeb.Model.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DbOpertion.Models;
using DbOpertion.Function;
using Common.Helper;

namespace SLSM.AdminWeb.Controllers.PageController
{
    /// <summary>
    /// 登入页面
    /// </summary>
    public class LoginController : BaseMvcMasterController
    {
        /// <summary>
        /// 登入
        /// </summary>
        /// <returns></returns>
        public ActionResult Login()
        {
            return View();
        }

        /// <summary>
        /// 登入
        /// </summary>
        /// <returns></returns>
        public ActionResult LoginIn(LoginRequest request)
        {
            var userGuid = CookieOper.Instance.GetUserGuid();
            var erpLogin = ErploginuerFunc.Instance.SelectByModel(new Erploginuer { erpLoginName = request.UserName }).FirstOrDefault();
            if (erpLogin == null)
            {
                ViewBag.LoginError = true;
                return View("Login");
            }
            if ((erpLogin.erpLoginPwd.ToLower() == request.UserPass.ToLower()) && (erpLogin.ErproleId == 11))
            {
                MemCacheHelper2.Instance.Cache.Set("AdminUserGuID_" + userGuid, erpLogin, 24 * 60);
                return RedirectToAction("Index", "Home", null);
            }
            else
            {
                ViewBag.LoginError = true;
                return View("Login");
            }
        }
    }
}