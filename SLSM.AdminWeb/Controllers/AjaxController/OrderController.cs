using Common.Extend;
using Common.Filter.WebApi;
using Common.Result;
using DbOpertion.Function;
using SLSM.AdminWeb.Common.BaseController;
using SLSM.AdminWeb.Model.Request.Order;
using SLSM.DBOpertion.Function;
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

    }
}