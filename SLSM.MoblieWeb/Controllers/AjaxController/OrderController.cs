using AliyunHelper.SendMail;
using Common.Extend;
using Common.Filter.WebApi;
using Common.Helper;
using Common.Result;
using Common.ThirdParty;
using DbOpertion.Function;
using DbOpertion.Models;
using log4net;
using SLSM.DBOpertion.Function;
using SLSM.MoblieWeb.Models.Response.Order;
using SLSM.MoblieWeb.Models.Resquest.Order;
using SLSM.MoblieWeb.Models.Resquest.OrderList;
using SLSM.MoblieWeb.Models.Resquest.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Web.Http;
using WxPayAPI;

namespace SLSM.MoblieWeb.Controllers.AjaxController
{
    /// <summary>
    /// 我的订单
    /// </summary>
    public class OrderController : BaseApiController
    {
        /// <summary>
        /// 分页获得订单页面
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public ResultJsonModel<List<OrderInfoResponse>, int> OrderCountByPage(OrderTypeRequest request)
        {
            ResultJsonModel<List<OrderInfoResponse>, int> result = new ResultJsonModel<List<OrderInfoResponse>, int>();
            var userGuid = CookieOper.Instance.GetUserGuid();
            var user = MemCacheHelper2.Instance.Cache.GetModel<User>("UserGuID_" + userGuid);
            #region 列表数据
            //状态
            var status = StatusFunc.Instance.GetTypeStatus(request.Name);
            //订单列表
            var listOrder = OrderListFunc.Instance.SelectOrder((request.PageNo - 1) * request.PageSize, request.PageSize, user.Id, status);
            //订单明细列表
            var listOrderDetail = OrderListFunc.Instance.SelectOrderCommodity(listOrder.Select(p => p.Id).ToList().ConvertToString());
            //颜色列表
            var ListColor = ColorinfoFunc.Instance.GetAllColorListBase();
            //状态列表
            var tuples = StatusFunc.Instance.GetAllStatusInfo();
            var flag = true;
            result.Model1 = new List<OrderInfoResponse>();
            foreach (var item in listOrder)
            {
                //订单应答
                OrderInfoResponse response = new OrderInfoResponse(item, tuples);
                if (flag && request.PageNo == 1)
                {
                    flag = false;
                }
                response.ListDetail = new List<OrderDetailResponse>();

                var detailList = listOrderDetail.Where(p => p.OrderId == item.Id).ToList();
                foreach (var detail in detailList)
                {
                    var detailResponse = new OrderDetailResponse(detail, ListColor);
                    response.ListDetail.Add(detailResponse);
                }
                result.Model1.Add(response);
            }
            #endregion
            result.HttpCode = 200;
            result.Message = "查询数据成功！";
            return result;
        }
        /// <summary>
        /// 退货信息提交
        /// </summary>
        /// <param name="res"></param>
        /// <returns></returns>
        [HttpPost]
        public ResultJson ReturnInfo(ReturnInfoRequest res)
        {
            ResultJson result = new ResultJson();
            var Returnresult = OrderListFunc.Instance.ReturnInfo(new DbOpertion.Models.Sales_Return { DetailId = res.DetailId, ReturnText = res.ReturnText });
            var OrderInfo = OrderListFunc.Instance.UpdateOrderStatus(new Order_Info { Id = res.OrderId, Status = res.Status });
            if (Returnresult == "true")
            {
                result.HttpCode = 200;
                result.Message = "退货信息提交成功！";
            }
            else
            {
                result.HttpCode = 300;
                result.Message = Returnresult;
            }
            return result;
        }

        /// <summary>
        /// 添加订单
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public ResultJsonModel<OrderInfoResponse> AddOrder(AddOrderRequest request)
        {
            var userGuid = CookieOper.Instance.GetUserGuid();
            var user = MemCacheHelper2.Instance.Cache.GetModel<User>("UserGuID_" + userGuid);
            if (user == null)
            {
                user = UserFunc.Instance.CreateByPhone(request.Phone, request.Name);
            }
            if (request.payType.Trim() == "线下支付")
            {
                var order = OrderFunc.Instance.CreateOnline(2, request.Address, user.Id, request.ShopCartIds, (decimal)user.Discount, request.Name, request.Phone, request.Invoice);
                if (order.Item1 != null)
                {
                    MemCacheHelper2.Instance.Cache.Set("UserGuID_" + userGuid, user, 24 * 60);
                    return new ResultJsonModel<OrderInfoResponse> { HttpCode = 200, Message = "支付成功", Model1 = new OrderInfoResponse(order.Item1, new List<Tuple<string, string>>()) };
                }
                else
                {
                    return new ResultJsonModel<OrderInfoResponse> { HttpCode = 300, Message = order.Item2 };
                }
            }
            else if (request.payType.Trim() == "支付宝")
            {
                var order = OrderFunc.Instance.CreateAlipay(2, request.Address, user.Id, request.ShopCartIds, (decimal)user.Discount, request.Name, request.Phone, request.Invoice);
                if (order != null)
                {
                    var result = AlipayHelper.Instance.CreateAlipayWapOrder(order.Item1.TotalPrice.Value.ToString("0.00"), order.Item1.OrderNo, "http://mobile.syloon.cn/UserInfo/AliPayOrder", "", "赛龙商城");
                    MemCacheHelper2.Instance.Cache.Set("UserGuID_" + userGuid, user, 24 * 60);
                    return new ResultJsonModel<OrderInfoResponse> { HttpCode = 200, Message = result, Model1 = new OrderInfoResponse(order.Item1, new List<Tuple<string, string>>()) };
                }
                else
                {
                    return new ResultJsonModel<OrderInfoResponse> { HttpCode = 300, Message = order.Item2 };
                }
            }
            else if (request.payType.Trim() == "微信")
            {
                var order = OrderFunc.Instance.CreateWechat(2, request.Address, user.Id, request.ShopCartIds, (decimal)user.Discount, request.Name, request.Phone, request.Invoice);
                if (order != null)
                {
                    //状态列表
                    var tuples = StatusFunc.Instance.GetAllStatusInfo();
                    OrderInfoResponse response = new OrderInfoResponse(order.Item1, tuples);
                    MemCacheHelper2.Instance.Cache.Set("UserGuID_" + userGuid, user, 24 * 60);
                    return new ResultJsonModel<OrderInfoResponse> { HttpCode = 200, Message = "支付成功", Model1 = response };
                }
                else
                {
                    return new ResultJsonModel<OrderInfoResponse> { HttpCode = 300, Message = order.Item2 };
                }
            }
            else
            {
                return new ResultJsonModel<OrderInfoResponse> { HttpCode = 300, Message = "暂无此支付类型" };
            }
        }


        /// <summary>
        /// 更改订单类型
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public ResultJsonModel<OrderInfoResponse> ChangeOrderPayType(ChangePayTypeRequest request)
        {
            ResultJsonModel<OrderInfoResponse> result = new ResultJsonModel<OrderInfoResponse>();
            if (OrderFunc.Instance.UpdateModel(new Order_Info { Id = request.Id, PayType = request.PayType }))
            {
                var order_Info = OrderFunc.Instance.GetOrderById(request.Id);
                var aliOrder = AlipayHelper.Instance.CreateAlipayWapOrder(order_Info.TotalPrice.Value.ToString("0.00"), order_Info.OrderNo, "http://mobile.syloon.cn/UserInfo/AliPayOrder", "", "赛龙商城");
                result.HttpCode = 200;
                result.Message = aliOrder;
                //状态列表
                var tuples = StatusFunc.Instance.GetAllStatusInfo();
                result.Model1 = new OrderInfoResponse(order_Info, tuples);
            }
            else
            {
                result.HttpCode = 300;
                result.Message = "支付类型更改失败";
            }
            return result;
        }

        /// <summary>
        /// 确认收货
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ResultJson EnterThing(ChangePayTypeRequest request)
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
        /// 微信订单确认
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ResultJson WeiChatOrder(PayOrderRequest request)
        {
            var result = OrderQuery.Instance.Run(null, request.OrderNo);
            var trade_state_desc = result.GetValue("trade_state_desc") == null ? null : result.GetValue("trade_state_desc").ToString();
            var order = Order_InfoFunc.Instance.SelectByModel(new Order_Info { OrderNo = request.OrderNo }).FirstOrDefault();
            if (order.Status != 1)
            {
                return new ResultJson { HttpCode = 300, Message = "此订单并非微信订单！" };
            }
            if (trade_state_desc == "支付成功")
            {
                SendMail.Instance.SendEmail(order.Phone, "{\"code\":\"" + order.OrderNo + "\",\"code2\":\"" + order.TotalPrice + "\"}", Enum_SendEmailCode.NoticeOfPaymentCode);
                if (OrderFunc.Instance.UpdateModel(new Order_Info { Id = order.Id, Status = 3, PayType = 3 }))
                {
                    return new ResultJson { HttpCode = 200, Message = "该订单支付成功！" };
                }
                else
                {
                    return new ResultJson { HttpCode = 300, Message = "该订单修改失败！" };
                }
            }
            else
            {
                if (order.LastCodeTime == null || order.LastCodeTime.Value.AddMinutes(30) < DateTime.Now)
                {
                    OrderFunc.Instance.UpdateModel(new Order_Info { Id = order.Id, WechatFaild = true });
                }
                return new ResultJson { HttpCode = 300, Message = "此订单并未成功支付！" };
            }
        }

        /// <summary>
        /// 微信订单确认
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ResultJson SureWeiChatOrder(PayOrderRequest request)
        {
            var order = Order_InfoFunc.Instance.SelectByModel(new Order_Info { OrderNo = request.OrderNo }).FirstOrDefault();
            if (OrderFunc.Instance.UpdateModel(new Order_Info { Id = order.Id, Status = 3, PayType = 3 }))
            {
                return new ResultJson { HttpCode = 200, Message = "该订单支付成功！" };
            }
            else
            {
                return new ResultJson { HttpCode = 300, Message = "该订单修改失败！" };
            }

        }


        /// <summary>
        /// 取消订单
        /// </summary>
        /// <param name="request">请求</param>
        /// <returns></returns>
        [HttpPost]
        public ResultJson CancelOrder(ChangePayTypeRequest request)
        {
            var orderInfo = Order_InfoFunc.Instance.SelectById(request.Id);
            if (orderInfo == null)
            {
                return new ResultJson { HttpCode = 300, Message = "并无对应订单!" };
            }
            else if (orderInfo.Status != 1)
            {
                return new ResultJson { HttpCode = 300, Message = "已支付订单不能取消!" };
            }
            else
            {
                if (!Order_InfoFunc.Instance.Update(new Order_Info { IsDelete = true, Id = request.Id }))
                {
                    return new ResultJson { HttpCode = 300, Message = "订单取消失败,请重新尝试!" };
                }
                if (!Order_DetailFunc.Instance.DeleteModel(new Order_Detail { OrderId = request.Id }))
                {
                    return new ResultJson { HttpCode = 300, Message = "订单取消失败,请重新尝试!" };
                }
                return new ResultJson { HttpCode = 200, Message = "订单取消成功！" };
            }
        }

    }
}
