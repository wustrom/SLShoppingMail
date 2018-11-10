using Common.Extend;
using Common.Filter.WebApi;
using Common.Helper;
using Common.Result;
using DbOpertion.Function;
using DbOpertion.Models;
using SLSM.AdminWeb.Common.BaseController;
using SLSM.AdminWeb.Model.Request.Commdity;
using SLSM.AdminWeb.Model.Request.Order;
using SLSM.DBOpertion.Function;
using SLSM.Web.Models.Resquest.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SLSM.AdminWeb.Controllers.AjaxController
{
    /// <summary>
    /// 订单控制器
    /// </summary>
    public class OrderController : BaseApiController
    {
        /// <summary>
        /// 确认订单支付
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ResultJson SurePay(OrderChangeRequest request)
        {
            if (OrderFunc.Instance.SurePay(request.Id))
            {
                return new ResultJson { HttpCode = 200, Message = "支付成功！" };
            }
            else
            {
                return new ResultJson { HttpCode = 300, Message = "支付失败！" };
            }
        }
        /// <summary>
        /// 发货成功
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ResultJson SendThing(OrderChangeRequest request)
        {
            var result = OrderFunc.Instance.SendThing2(request.Id);
            if (result.ToLower() == "true")
            {
                return new ResultJson { HttpCode = 200, Message = "发货成功！" };
            }
            else
            {
                return new ResultJson { HttpCode = 300, Message = result };
            }
        }

        /// <summary>
        /// 更新快递
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ResultJson UpdateExpress(OrderChangeRequest request)
        {
            if (OrderFunc.Instance.UpdateModel(new DbOpertion.Models.Order_Info { Id = request.Id, ExpressCompany = request.ExpressCompany, ExpressNo = request.ExpressNo }))
            {
                return new ResultJson { HttpCode = 200, Message = "更新快递信息成功！" };
            }
            else
            {
                return new ResultJson { HttpCode = 300, Message = "更新快递信息失败！" };
            }
        }

        /// <summary>
        /// 确认收货
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ResultJson EnterThing(OrderChangeRequest request)
        {
            if (OrderFunc.Instance.EnterThing(request.Id))
            {
                return new ResultJson { HttpCode = 200, Message = "收货成功！" };
            }
            else
            {
                return new ResultJson { HttpCode = 300, Message = "收货失败！" };
            }
        }

        /// <summary>
        /// 退货成功
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ResultJson ReturnSuccess(OrderChangeRequest request)
        {
            if (OrderFunc.Instance.ReturnSuccess(request.Id))
            {
                return new ResultJson { HttpCode = 200, Message = "退货成功！" };
            }
            else
            {
                return new ResultJson { HttpCode = 300 };
            }
        }

        /// <summary>
        /// 退货失败
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ResultJson ReturnFail(OrderChangeRequest request)
        {
            if (OrderFunc.Instance.ReturnFail(request.Id))
            {
                return new ResultJson { HttpCode = 200, Message = "退货失败！" };
            }
            else
            {
                return new ResultJson { HttpCode = 300 };
            }
        }

        /// <summary>
        /// 退货失败
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ResultJson ConvertErp(OrderChangeRequest request)
        {
            if (OrderFunc.Instance.ConvertToErp(request.Id))
            {
                return new ResultJson { HttpCode = 200, Message = "成功转至Erp！" };
            }
            else
            {
                return new ResultJson { HttpCode = 300, Message = "转到Erp失败，请查看是否已转入！" };
            }
        }

        /// <summary>
        /// 修改价格
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ResultJson ChangePrice(OrderChangePriceRequest request)
        {
            var ChangePrice = request.ChangePrice.ParseDecimal();
            if (ChangePrice == null)
            {
                return new ResultJson { HttpCode = 300, Message = "请输入正确的订单价格！" };
            }
            var OrderInfo = Order_InfoFunc.Instance.SelectById(request.Id);
            if (OrderInfo == null)
            {
                return new ResultJson { HttpCode = 300, Message = "该订单不存在！" };
            }
            else if (OrderInfo.Status != 1)
            {
                return new ResultJson { HttpCode = 300, Message = "订单已支付，不能修改！" };
            }
            else if ((OrderInfo.TotalPrice + (OrderInfo.DiscountPrice == null ? 0 : OrderInfo.DiscountPrice.Value)) <= ChangePrice)
            {
                return new ResultJson { HttpCode = 300, Message = "请输入一个小于订单金额的价格！" };
            }
            if (OrderInfo.DiscountPrice != null)
            {
                OrderInfo.TotalPrice = OrderInfo.TotalPrice + OrderInfo.DiscountPrice - ChangePrice;
                OrderInfo.DiscountPrice = ChangePrice;
                OrderInfo.DisCountResult = request.ChangePriceResult;
            }
            else
            {
                OrderInfo.TotalPrice = OrderInfo.TotalPrice - ChangePrice;
                OrderInfo.DiscountPrice = ChangePrice;
                OrderInfo.DisCountResult = request.ChangePriceResult;
            }
            if (Order_InfoFunc.Instance.Update(OrderInfo))
            {
                return new ResultJson { HttpCode = 200, Message = "价格修改成功！" };
            }
            else
            {
                return new ResultJson { HttpCode = 300, Message = "价格修改失败！" };
            }
        }

        /// <summary>
        /// 取消订单
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public void CancelOrder()
        {
            OrderFunc.Instance.CancelTodayOrder();
        }

        #region 后台下单
        /// <summary>
        /// 后台下单
        /// </summary>
        /// <returns></returns>
        public ResultJson AdminBackOrder(AdminBackOrderRequest request)
        {
            var userGuid = CookieOper.Instance.GetUserGuid();
            var user = MemCacheHelper2.Instance.Cache.GetModel<DbOpertion.Models.Erploginuer>("AdminUserGuID_" + userGuid);
            if (OrderFunc.Instance.CreateAdminOrder(request.OrderType, $"{request.CommArea} {request.CommDetailArea}", request.CommName, request.CommPhone, (request.InvoiceInfo == 2 ? $"{request.InvoicesRaised},{request.EnterpriseTaxNumber}" : null), request.CommID, request.CommPrint, request.CommNum, request.CommColor, user.erpLoginName))
            {
                return new ResultJson { HttpCode = 200, Message = "下单成功" };
            }
            else
            {
                return new ResultJson { HttpCode = 300, Message = "下单失败" };
            }

        }

        /// <summary>
        /// 用户确认
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public ResultJson SureOrdersubmit(IdRequest request)
        {
            var detail = Order_DetailFunc.Instance.SelectByModel(new Order_Detail { OrderId = request.Id }).FirstOrDefault();
            if (detail != null)
            {
                var production = ProductionFunc.Instance.SelectByModel(new DbOpertion.Models.Production { order_detailId = detail.Id }).FirstOrDefault();
                if (production == null)
                {
                    return new ResultJson { HttpCode = 300, Message = "并无对应订单" };
                }
                if (Order_DetailFunc.Instance.Update(detail))
                {
                    detail.UserSure = true;
                    production.ProductionStatus = "待生产确认";
                    production.DesignerStatus = "设计已完成";
                    if (ProductionFunc.Instance.Update(production))
                    {
                        return new ResultJson { HttpCode = 200, Message = "提交成功" };
                    }
                    else
                    {
                        detail.UserSure = false;
                        Order_DetailFunc.Instance.Update(detail);
                        return new ResultJson { HttpCode = 300, Message = "更新订单失败，请再次尝试" };
                    }
                }
                else
                {
                    return new ResultJson { HttpCode = 300, Message = "更新订单失败，请再次尝试" };
                }
            }
            else
            {
                return new ResultJson { HttpCode = 200, Message = "订单明细不存在成功" };
            }
        }


        /// <summary>
        /// 确定上传订单详情
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ResultJson SureUploadOrder(OrderDesignRequest request)
        {
            if (Order_InfoFunc.Instance.Update(new Order_Info { Id = request.OrderId, UserDesign = request.DesignImage }))
            {
                return new ResultJson { HttpCode = 200, Message = "订单更新成功！" };
            }
            else
            {
                return new ResultJson { HttpCode = 300, Message = "订单更新失败！" };
            }
        }
        #endregion

    }
}