using Common.Result;
using System.Net.Http;
using System.Web.Mvc;
using System;
using System.Threading;
using System.Threading.Tasks;
using Common.Helper.JsonHelper;
using System.Reflection;
using log4net;

namespace Common.Filter.MvcAjax
{
    /// <summary>
    /// WebApi异常过滤器
    /// </summary>
    public class MvcAjaxExceptionAttribute : FilterAttribute, IExceptionFilter
    {
        /// <summary>
        /// 发生错误之后
        /// </summary>
        /// <param name="filterContext">条件内容</param>
        public void OnException(ExceptionContext filterContext)
        {
            JsonResult jsonResult = new JsonResult();
            ResultJson result = new ResultJson();
            result.HttpCode = 400;
            result.Message = filterContext.Exception.Message;
            jsonResult.Data = JsonHelper.Instance.SerializeObject(result);
            jsonResult.ContentType = "application/json";
            jsonResult.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            //创建日志记录组件实例
            ILog log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
            //记录错误日志
            log.Error("error", filterContext.Exception);
            filterContext.Result = jsonResult;
        }

    }
}
