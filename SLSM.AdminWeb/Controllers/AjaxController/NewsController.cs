using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SLSM.AdminWeb.Model.Request.Commdity;
using DbOpertion.Models;
using Common.Helper;
using SLSM.DBOpertion.Function;
using Common.Result;
using Common.Filter.WebApi;
using SLSM.AdminWeb.Model.Request.Message;
using DbOpertion.Function;

namespace SLSM.AdminWeb.Controllers.AjaxController
{
    /// <summary>
    /// 消息控制器
    /// </summary>
    public class NewsController : ApiController
    {
        /// <summary>
        /// 更新消息
        /// </summary>
        /// <param name="request">请求</param>
        /// <returns></returns>
        [HttpPost]
        [WebApiModelValidate]
        [WebApiException]
        public ResultJson UpdateNews(MessageRequest request)
        {
            News news = new News
            {
                Content = request.Content,
                Id = request.Id,
                MainTitle = request.MainTitle,
                Title = request.MainTitle,
                ValidityTime = request.Time
            };
            if (NewsFunc.Instance.InsertByModel(news))
            {
                return new ResultJson { HttpCode = 200, Message = "操作成功！" };
            }
            else
            {
                return new ResultJson { HttpCode = 400, Message = "操作失败，请再次尝试！" };
            }
        }

        /// <summary>
        /// 删除消息
        /// </summary>
        /// <param name="request">请求</param>
        /// <returns></returns>
        [HttpPost]
        [WebApiModelValidate]
        [WebApiException]
        public ResultJson DeleteNews(IdRequest request)
        {
            if (NewsFunc.Instance.DeleteById(request.Id))
            {
                return new ResultJson { HttpCode = 200, Message = "操作成功！" };
            }
            else
            {
                return new ResultJson { HttpCode = 400, Message = "操作失败，请再次尝试！" };
            }
        }
    }
}