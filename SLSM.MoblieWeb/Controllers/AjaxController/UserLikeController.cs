using Common.Filter.WebApi;
using Common.Result;
using DbOpertion.Function;
using SLSM.DBOpertion.Function;
using SLSM.MoblieWeb.Models.Resquest.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SLSM.MoblieWeb.Controllers.AjaxController
{
    /// <summary>
    /// 个人收藏
    /// </summary>
    public class UserLikeController : BaseApiController
    {
        /// <summary>
        /// 取消收藏
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public ResultJson DeleteLike(DelUserLikeRequest request)
        {
            ResultJson result = new ResultJson();
            var Likeresult = UserLikeFunc.Instance.DeleteLike(request.Id);
            if (Likeresult)
            {
                result.HttpCode = 200;
                result.Message = "取消收藏成功！";
            }
            else
            {
                result.HttpCode = 300;
                result.Message = "取消收藏失败！";
            }
            return result;
        }
    }
}
