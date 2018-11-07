
using Common.Helper;
using DbOpertion.Function;
using SLSM.ErpWeb.App_Start;
using SLSM.ErpWeb.Common.BaseController;
using SLSM.ErpWeb.Model.Request.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SLSM.ErpWeb.Controllers.PageController
{
    public class LoginController : BaseMvcMasterController
    {
        // GET: Login 

        public ActionResult Login()
        {
            return View();
        }
        public ActionResult LoginIn(LoginRequest request)
        {
            var LoginUser = ErploginuerFunc.Instance.SelectByModel(new DbOpertion.Models.Erploginuer { erpLoginName = request.UserName }).FirstOrDefault();
            if (LoginUser != null)
            {
                var userGuid = CookieOper.Instance.GetUserGuid();
                MemCacheHelper2.Instance.Cache.Set("ErpUserGuID_" + userGuid, LoginUser, 24 * 60);
                if (request.UserPass == LoginUser.erpLoginPwd)
                {
                    return RedirectToAction("Index", "Home", null);
                }
                else
                {
                    ViewBag.LoginPwdError = true;
                }
            }
            else
            {
                ViewBag.LoginUserError = true;
            }
            return View("Login");
        }
    }
}