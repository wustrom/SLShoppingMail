using System.Web.Http;
using System.Web.Http.Controllers;

namespace Common.Filter.WebApi
{
    /// <summary>
    /// Api基础控制器
    /// </summary>
    [WebApiModelValidate]
    [WebApiException]
    public class BaseApiController : ApiController
    {

    }
}
