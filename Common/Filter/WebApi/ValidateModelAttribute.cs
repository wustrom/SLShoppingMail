using Common.Result;
using Newtonsoft.Json.Linq;
using System.Net.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using Common.Enum_My;

namespace Common.Filter.WebApi
{
    /// <summary>
    /// 模型验证过滤器
    /// </summary>
    public class WebApiModelValidateAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            if (!actionContext.ModelState.IsValid)
            {
                ResultJson resultJson = new ResultJson();
                resultJson.HttpCode = 400;
                JObject json = new JObject();
                string ErrorMsg = "";
                bool flagFirst = true;
                bool flagToken = true;
                foreach (var item in actionContext.ModelState.Values)
                {
                    foreach (var error in item.Errors)
                    {
                        if (error.ErrorMessage.Trim() == Enum_Message.TokenInvalidMessage.Enum_GetString())
                        {
                            resultJson.HttpCode = 700;
                            resultJson.Message = error.ErrorMessage;
                            flagToken = false;
                            break;
                        }
                        if (flagFirst)
                        {
                            flagFirst = false;
                        }
                        else
                        {
                            ErrorMsg += ",";
                        }
                        ErrorMsg += error.ErrorMessage;
                    }
                }
                if (flagToken)
                {
                    resultJson.Message = ErrorMsg;
                }
                actionContext.Response = actionContext.Request.CreateResponse(System.Net.HttpStatusCode.OK, resultJson);
            }
        }
    }
}
