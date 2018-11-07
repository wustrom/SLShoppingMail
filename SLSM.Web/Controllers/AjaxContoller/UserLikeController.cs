using Common.Filter.WebApi;
using Common.Helper;
using Common.Result;
using DbOpertion.Function;
using DbOpertion.Models;
using SLSM.DBOpertion.Function;
using SLSM.Web.Models.Response.Order;
using SLSM.Web.Models.Resquest;
using SLSM.Web.Models.Resquest.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SLSM.Web.Controllers.AjaxContoller
{
    /// <summary>
    /// 收藏
    /// </summary>
    public class UserLikeController : BaseApiController
    {
        /// <summary>
        /// 分页获得地址页面
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ResultJsonModel<List<LikeCommodityResponse>, int> UserLikeByPage(PageRequest request)
        {
            ResultJsonModel<List<LikeCommodityResponse>, int> result = new ResultJsonModel<List<LikeCommodityResponse>, int>();
            var userGuid = CookieOper.Instance.GetUserGuid();
            var user = MemCacheHelper2.Instance.Cache.GetModel<User>("UserGuID_" + userGuid);
            var listUserLike = UserLikeFunc.Instance.SelectLikePage((request.PageNo - 1) * request.PageSize, request.PageSize, user.Id);
            var ListColor = ColorFunc.Instance.GetAllColorInfo();
            var flag = true;
            result.Model1 = new List<LikeCommodityResponse>();
            foreach (var item in listUserLike)
            {
                LikeCommodityResponse response = new LikeCommodityResponse(item, ListColor);
                if (flag && request.PageNo == 1)
                {
                    flag = false;
                }
                result.Model1.Add(response);
            }
            result.HttpCode = 200;
            result.Message = "查询数据成功！";
            return result;
        }
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
