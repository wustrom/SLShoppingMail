using Common.Filter.WebApi;
using Common.Result;
using DbOpertion.Function;
using SLSM.DBOpertion.Function;
using SLSM.DBOpertion.Model.Extend.Request.CommodityList;
using SLSM.DBOpertion.Model.Extend.Response.CommodityRes;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace SLSM.MoblieWeb.Controllers.AjaxController
{
    /// <summary>
    /// 商品控制器
    /// </summary>
    public class CommodityController : BaseApiController
    {
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
                else
                    c2 = CommodityFunc.Instance.GetCommListRes(index, size, gradeId, sales, order);
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
                else
                    c2 = CommodityFunc.Instance.GetSearchList(index, size, text, sales, order);
            }
            else
                c2 = CommodityFunc.Instance.GetSearchList(index, size, text, sales, order);

            r2.Add(c2);
            r.ListData = r2;
            r.HttpCode = 200;
            return r;
        }
    }
}
