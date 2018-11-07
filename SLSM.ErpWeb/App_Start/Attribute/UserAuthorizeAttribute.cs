using Common.Helper;
using DbOpertion.Function;
using DbOpertion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SLSM.ErpWeb.App_Start
{
    public class UserAuthorizeAttribute : AuthorizeAttribute
    {
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            var userGuid = CookieOper.Instance.GetUserGuid();
            var user = MemCacheHelper2.Instance.Cache.GetModel<Erploginuer>("ErpUserGuID_" + userGuid);
            var controller = filterContext.RouteData.Values["controller"].ToString();
            var action = filterContext.RouteData.Values["action"].ToString();
            if (user == null)
            {
                filterContext.RequestContext.HttpContext.Response.Write("用户请登入");
                filterContext.RequestContext.HttpContext.Response.End();
            }
            else if (!isAllowed(user.erpLoginName, action))
            {
                filterContext.RequestContext.HttpContext.Response.Write("无权访问");
                filterContext.RequestContext.HttpContext.Response.End();
            }
        }

        private bool isAllowed(string user, string action)
        {
            //查找用户
            var erpLogin = ErploginuerFunc.Instance.SelectByModel(new Erploginuer { erpLoginName = user.ToString() }).FirstOrDefault();
            //查找角色的访问页面
            var erpRole = ErpuserFunc.Instance.SelectById(erpLogin.ErproleId.Value).ERProlePower;
            //ERProlePower
            var List_erpRole = erpRole.Split(',').Distinct().ToList();
            foreach (var item in List_erpRole)
            {
                if (item == action || action == "LoginIn")
                {
                    return true;
                }
            }
            return false;

        }
    }
}