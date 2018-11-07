using Common.Filter.WebApi;
using Common.Result;
using DbOpertion.Function;
using SLSM.ErpWeb.Model.Request.wantBuyerInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SLSM.ErpWeb.Controllers.AjaxController
{
    /// <summary>
    /// 发货管理
    /// </summary>
    public class ConsignmentController : BaseApiController
    {
        /// <summary>
        /// 发货
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ResultJson ExpressInfo(ConsignmentRequest request)
        {
            if (ProductionFunc.Instance.Update(new DbOpertion.Models.Production
            {
                Id = request.Id,
                ExpressCompany = request.ExpressCompany,
                ExpressNo = request.ExpressNo,
                ExpressContext = request.ExpressContext,
                ExpressWeight = request.ExpressWeight,
                OrderStatus = "成品已发货"
            }))
            {
                var production = Production_Orderdetail_ViewFunc.Instance.SelectByModel(new DbOpertion.Models.Production_Orderdetail_View { Id = request.Id }).FirstOrDefault();
                OrderFunc.Instance.SendThing(production.OrderId.Value);
                return new ResultJson { HttpCode = 200, Message = "成功!" };

            }
            else
            {
                return new ResultJson { HttpCode = 300, Message = "操作失败!请重试!" };
            }
        }
    }
}
