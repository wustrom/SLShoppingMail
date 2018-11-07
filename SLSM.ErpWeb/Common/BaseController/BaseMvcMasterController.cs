using Common.Extend;
using Common.Helper;
using Common.Helper.JsonHelper;
using Common.Result;
using DbOpertion.Models;
using log4net;
using SLSM.ErpWeb.App_Start;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http.Results;
using System.Web.Mvc;

namespace SLSM.ErpWeb.Common.BaseController
{
    /// <summary>
    /// MVC母版控制器
    /// </summary>    
    public class BaseMvcMasterController : Controller
    {
        /// <summary>
        /// Mvc母版控制器构造函数
        /// </summary>
        public BaseMvcMasterController()
        {
           
        }

        /// <summary>
        /// 发生错误之后
        /// </summary>
        /// <param name="filterContext">条件内容</param>
        protected override void OnException(ExceptionContext filterContext)
        {
            JsonResult jsonResult = new JsonResult();
            ResultJson result = new ResultJson();
            result.HttpCode = 400;
            result.Message = filterContext.Exception.Message;
            jsonResult.Data = JsonHelper.Instance.SerializeObject(result);
            //创建日志记录组件实例
            ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
            //记录错误日志
            log.Error("error", filterContext.Exception);
            filterContext.Result = jsonResult;
        }

        /// <summary>
        /// Model验证
        /// </summary>
        /// <param name="actionContext"></param>
        protected override void OnActionExecuting(ActionExecutingContext actionContext)
        {
            var Controller = actionContext.Controller;
            ModelStateDictionary ModelState = (ModelStateDictionary)ReflexHelper.Instance.GetPropertyValue(Controller, "ModelState");
            bool? IsValid = null;
            if (ModelState != null)
            {
                IsValid = ModelState.IsValid;
            }
            if (IsValid == false)
            {
                ResultJson result = new ResultJson();
                result.HttpCode = 300;
                foreach (var item in ModelState.Values)
                {
                    foreach (var error in item.Errors)
                    {
                        if (!error.ErrorMessage.IsNullOrEmpty())
                        {
                            result.Message += error.ErrorMessage + ",";
                        }
                    }
                }
                result.Message = result.Message.Remove(result.Message.Count() - 1, 1);
                var JsonString = JsonHelper.Instance.SerializeObject(result);
                JsonResult jsonResult = new JsonResult();
                jsonResult.Data = JsonHelper.Instance.SerializeObject(result);
                jsonResult.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
                actionContext.Result = jsonResult;
            }
        }

        /// <summary>
        /// 重新设置用户的过期时间
        /// </summary>
        /// <param name="filterContext"></param>
        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            var userGuid = CookieOper.Instance.GetUserGuid();
            var user = MemCacheHelper2.Instance.Cache.GetModel<Erploginuer>("ErpUserGuID_" + userGuid);
            if (user != null)
            {
                ViewBag.UserInfo = user;
                MemCacheHelper2.Instance.Cache.Set("ErpUserGuID_" + userGuid, user, 24 * 60);
                ViewBag.UserName = user.erpLoginName;
            }
            ViewBag.AdminUrl = System.Configuration.ConfigurationManager.AppSettings["AdminUrl"];
        }

    }
}