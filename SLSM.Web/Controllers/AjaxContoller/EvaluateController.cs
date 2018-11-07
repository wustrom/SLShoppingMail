using Common.Filter.WebApi;
using Common.Helper;
using Common.Result;
using DbOpertion.Function;
using DbOpertion.Models;
using DbOpertion.Operation;
using SLSM.DBOpertion.Function;
using SLSM.DBOpertion.Model.Extend.Response.CommodityRes;
using SLSM.DBOpertion.Model.Extend.Response.GradeRes;
using SLSM.Web.Models.Response.Evaluate;
using SLSM.Web.Models.Resquest.CommodityList;
using SLSM.Web.Models.Resquest.Evaluate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SLSM.Web.Controllers.AjaxContoller
{
    /// <summary>
    /// 获得评价列表
    /// </summary>
    public class EvaluateController : BaseApiController
    {
        /// <summary>
        /// 分页获得评价页面
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ResultJson<EvaluateByPageResponse> EvaluateByPage(EvaluateByPageRequest request)
        {
            ResultJson<EvaluateByPageResponse> result = new ResultJson<EvaluateByPageResponse>();
            var listEvalinfo = EvaluateFunc.Instance.SelectByCommodityId(request.OrderBy, request.Desc, request.CommodityId, (request.PageNo - 1) * request.PageSize, request.PageSize);
            foreach (var item in listEvalinfo)
            {
                EvaluateByPageResponse response = new EvaluateByPageResponse(item);
                result.ListData.Add(response);
            }
            result.HttpCode = 200;
            result.Message = "查询数据成功！";
            return result;
        }
        /// <summary>
        /// 提交评价
        /// </summary>
        /// <param name="eva"></param>
        /// <returns></returns>
        [HttpPost]
        public ResultJson SubmitEvaluate(SubmitEvaluateResquest eva)
        {
            ResultJson result = new ResultJson();
            var userGuid = CookieOper.Instance.GetUserGuid();
            var user = MemCacheHelper2.Instance.Cache.GetModel<User>("UserGuID_" + userGuid);
            var evaluateresult = EvaluateFunc.Instance.SubmitEvaluate(new Evaluate { UserId = user.Id,CommodityId=eva.CommodityId,ImageList=eva.ImageList,CreateTime = DateTime.Now, Start=eva.Start,Content=eva.Content});
            var OrderInfo = OrderListFunc.Instance.UpdateOrderStatus(new Order_Info { Id = eva.OrderId, Status = eva.Status });
            if (evaluateresult&& OrderInfo)
            {
                result.HttpCode = 200;
                result.Message = "提交成功！";
            }
            else
            {
                result.HttpCode = 300;
                result.Message = "提交失败！";
            }
            return result;
        }
    }
}
