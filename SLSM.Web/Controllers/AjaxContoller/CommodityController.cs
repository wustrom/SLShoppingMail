using Common.Filter.WebApi;
using Common.Helper;
using Common.Result;
using DbOpertion.Function;
using DbOpertion.Models;
using SLSM.DBOpertion.Function;
using SLSM.DBOpertion.Model.Extend.Request.CommodityList;
using SLSM.DBOpertion.Model.Extend.Response.CommodityRes;
using SLSM.Web.Models.Resquest.CommodityList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace SLSM.Web.Controllers.AjaxContoller
{
    /// <summary>
    /// 
    /// </summary>
    public class CommodityController : BaseApiController
    {
        /// <summary>
        /// 获取价格和商品区间
        /// </summary>
        /// <returns></returns>
        [WebApiException]
        [WebApiModelValidate]
        [HttpPost]
        public ResultJson<CommPrice_Amount_CommIds> GetPriceAmount()
        {
            ResultJson<CommPrice_Amount_CommIds> r = new ResultJson<CommPrice_Amount_CommIds>();
            return r;
        }

        /// <summary>
        /// 获取商品列表
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        [WebApiException]
        [WebApiModelValidate]
        [HttpPost]
        public ResultJson<CommodityRes> GetList(CommListSearchReq req)
        {
            ResultJson<CommodityRes> r = new ResultJson<CommodityRes>();
            var gradeId = req.gradeId;
            var sales = req.sales;
            var order = req.order;
            var commIdTemp = req.commIds;
            var isSearch = req.isSearch;
            var size = req.size;
            var index = req.index;

            var list = new List<CommodityListRes>();
            var r2 = new List<CommodityRes>();

            var c2 = new CommodityRes();
            c2.pages = 1;
            c2.ListData = new List<CommodityListRes>();
            if (isSearch)
            {
                if (commIdTemp != null)
                {
                    var listCommIds = new List<int>(commIdTemp).Distinct().ToList();
                    c2 = CommodityFunc.Instance.GetCommList(index, size, listCommIds, sales, order);
                }
            }
            else
                c2 = CommodityFunc.Instance.GetCommListRes(index, size, gradeId, sales, order);

            r2.Add(c2);
            r.ListData = r2;
            r.HttpCode = 200;
            return r;
        }

        /// <summary>
        /// 关键词搜索商品列表
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        [WebApiException]
        [WebApiModelValidate]
        [HttpPost]
        public ResultJson<CommodityRes> GetListBySearch(CommListSearchReq req)
        {
            ResultJson<CommodityRes> r = new ResultJson<CommodityRes>();
            var text = req.text;
            var sales = req.sales;
            var order = req.order;
            var commIdTemp = req.commIds;
            var isSearch = req.isSearch;
            var size = req.size;
            var index = req.index;

            var list = new List<CommodityListRes>();
            var r2 = new List<CommodityRes>();

            var c2 = new CommodityRes();
            c2.pages = 1;
            c2.ListData = new List<CommodityListRes>();
            if (isSearch)
            {
                if (commIdTemp != null)
                {
                    var listCommIds = new List<int>(commIdTemp).Distinct().ToList();
                    c2 = CommodityFunc.Instance.GetCommList(index, size, listCommIds, sales, order);
                }
            }
            else
                c2 = CommodityFunc.Instance.GetSearchList(index, size, text, sales, order);

            r2.Add(c2);
            r.ListData = r2;
            r.HttpCode = 200;
            return r;
        }

        /// <summary>
        /// 添加购物车信息
        /// </summary>
        /// <param name="request">请求</param>
        /// <returns></returns>
        [HttpPost]
        public ResultJson AddCartInfo(AddCartRequest request)
        {
            var userGuid = CookieOper.Instance.GetUserGuid();
            var user = MemCacheHelper2.Instance.Cache.GetModel<DbOpertion.Models.User>("UserGuID_" + userGuid);
            Hisdesign hisdesign;
            if (user == null)
            {
                hisdesign = HisdesignFunc.Instance.GetHisdesignInfo(null, request.commodityId, userGuid);
            }
            else
            {
                hisdesign = HisdesignFunc.Instance.GetHisdesignInfo(user.Id, request.commodityId, userGuid);
            }
            hisdesign.LastLookTime = DateTime.Now;
            hisdesign.IsCart = true;
            if (HisdesignFunc.Instance.UpdateHisdesign(hisdesign))
            {
                return new ResultJson { HttpCode = 200, Message = "加入购物车成功！" };
            }
            else
            {
                return new ResultJson { HttpCode=300,Message="更新失败！"};
            }
        }
    }
}
