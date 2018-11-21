using AliyunHelper.SendMail;
using Common.Extend;
using Common.Helper;
using Common.ThirdParty;
using Common.ThirdParty.AliPay;
using Common.ThirdParty.KdGold;
using DbOpertion.Function;
using DbOpertion.Models;
using SLSM.DBOpertion.Function;
using SLSM.MoblieWeb.Common.BaseController;
using SLSM.Web.Models.Response.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace SLSM.Web.Controllers.PageController
{
    /// <summary>
    /// 
    /// </summary>
    public class UserInfoController : BaseMvcMasterController
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            var userGuid = CookieOper.Instance.GetUserGuid();
            var user = MemCacheHelper2.Instance.Cache.GetModel<User>("UserGuID_" + userGuid);
            if (user != null)
            {
                var OrderList = OrderListFunc.Instance.SelectOrder(0, 3, user.Id);
                var OrderDetailList = OrderListFunc.Instance.SelectOrderCommodity(OrderList.Select(p => p.Id).ToList().ConvertToString());
                List<OrderInfoResponse> infos = new List<OrderInfoResponse>();
                var ListStatus = StatusFunc.Instance.GetAllStatusInfo();
                var ListColor = ColorinfoFunc.Instance.GetAllColorListBase();
                ViewBag.AllImage = Carousel_ImageFunc.Instance.SelectAllImages().Item1;
                foreach (var item in OrderList)
                {
                    var response = new OrderInfoResponse(item, ListStatus);
                    #region 颜色
                    response.ListDetail = new List<OrderDetailResponse>();
                    var detailList = OrderDetailList.Where(p => p.OrderId == item.Id).ToList();
                    foreach (var detail in detailList)
                    {

                        var detailResponse = new OrderDetailResponse(detail, ListColor);
                        response.ListDetail.Add(detailResponse);
                    }
                    infos.Add(response);
                    #endregion
                }
                ViewBag.Order = infos;
            }
            else
            {
                return RedirectToAction("Index", "Main");
            }
            return View();
        }
        /// <summary>
        /// 用户信息
        /// </summary>
        /// <returns></returns>
        public ActionResult Info()
        {
            #region MemCache获取用户信息
            var userGuid = CookieOper.Instance.GetUserGuid();
            var user = MemCacheHelper2.Instance.Cache.GetModel<User>("UserGuID_" + userGuid);
            #endregion
            if (user == null)
            {
                return RedirectToAction("Index", "Main");
            }
            ViewBag.ListComm = CommpanyTypeFunc.Instance.GetAllCompanyType();
            ViewBag.UserFullInfo = UserFunc.Instance.SelectById(user.Id);
            return View();
        }
        /// <summary>
        /// 消息
        /// </summary>
        /// <returns></returns>
        public ActionResult Message()
        {
            var userGuid = CookieOper.Instance.GetUserGuid();
            var user = MemCacheHelper2.Instance.Cache.GetModel<User>("UserGuID_" + userGuid);
            if (user != null)
            {
                ViewBag.Message = MessageFunc.Instance.SelectMessage(0, 7, user.Id);

                #region 数据条数
                //全部信息
                var num = 5;
                var count = MessageFunc.Instance.SelectMessageCount(user.Id);
                ViewBag.MessageCount = count % num == 0 ? ((int)(count / num)) : ((int)(count / num) + 1);
                //未读
                var Nocount = MessageFunc.Instance.SelectMessageCount(user.Id, false);
                ViewBag.NoReadMessageAllCount = Nocount;
                ViewBag.NoReadMessageCount = Nocount % num == 0 ? ((int)(Nocount / num)) : ((int)(Nocount / num) + 1);
                //已读
                var Readecount = MessageFunc.Instance.SelectMessageCount(user.Id, true);
                ViewBag.ReadMessageCount = Readecount % num == 0 ? ((int)(Readecount / num)) : ((int)(Readecount / num) + 1);
                #endregion
            }
            else
            {
                return RedirectToAction("Index", "Main");
            }
            return View();
        }
        /// <summary>
        /// 地址
        /// </summary>
        /// <returns></returns>
        public ActionResult Address()
        {
            var userGuid = CookieOper.Instance.GetUserGuid();
            var user = MemCacheHelper2.Instance.Cache.GetModel<User>("UserGuID_" + userGuid);
            if (user != null)
            {
                ViewBag.Address = AddressFunc.Instance.SelectAll(new Address { UserId = user.Id }).OrderByDescending(p => p.DefaultTime).ToList();
            }
            else
            {
                return RedirectToAction("Index", "Main");
            }
            return View();
        }

        /// <summary>
        /// 地址
        /// </summary>
        /// <returns></returns>
        public ActionResult InvoiceInfo()
        {
            var userGuid = CookieOper.Instance.GetUserGuid();
            var user = MemCacheHelper2.Instance.Cache.GetModel<User>("UserGuID_" + userGuid);
            if (user != null)
            {
                ViewBag.InvoiceList = InvoiceFunc.Instance.SelectModel(new Invoice { UserId = user.Id }).OrderByDescending(p => p.InvoiceTime).ToList();
            }
            else
            {
                return RedirectToAction("Index", "Main");
            }
            return View();
        }
        /// <summary>
        /// 我的订单
        /// </summary>
        /// <returns></returns>
        public ActionResult MyOrderList()
        {
            var userGuid = CookieOper.Instance.GetUserGuid();
            var user = MemCacheHelper2.Instance.Cache.GetModel<User>("UserGuID_" + userGuid);
            if (user == null)
            {
                return RedirectToAction("Index", "Main");
            }
            #region  状态
            var OrderList = OrderListFunc.Instance.SelectOrder(user.Id);
            var OrderDetailList = OrderListFunc.Instance.SelectOrderCommodity(OrderList.Select(p => p.Id).ToList().ConvertToString());
            var CommodityList = CommodityFunc.Instance.SelectByKeys("Id", OrderDetailList.Select(p => p.CommodityId.ToString()).ToList());
            var MaterialsList = Raw_MaterialsFunc.Instance.SelectByKeys("Id", CommodityList.Select(p => p.MaterialId.ToString()).ToList());
            List<OrderInfoResponse> infos = new List<OrderInfoResponse>();
            var ListStatus = StatusFunc.Instance.GetAllStatusInfo();
            var ListColor = ColorinfoFunc.Instance.GetAllColorListBase();
            ViewBag.AllImage = Carousel_ImageFunc.Instance.SelectAllImages().Item1;
            foreach (var item in OrderList)
            {
                var response = new OrderInfoResponse(item, ListStatus);
                #region 颜色
                response.ListDetail = new List<OrderDetailResponse>();
                var detailList = OrderDetailList.Where(p => p.OrderId == item.Id).ToList();
                foreach (var detail in detailList)
                {
                    var commodity = CommodityList.Where(p => p.Id == detail.CommodityId).FirstOrDefault();
                    if (commodity == null)
                    {
                        continue;
                    }
                    var Materials = MaterialsList.Where(p => p.Id == commodity.MaterialId).FirstOrDefault();
                    if (Materials == null)
                    {
                        continue;
                    }
                    var detailResponse = new OrderDetailResponse(detail, ListColor, Materials.PrintFuncInfo);
                    response.ListDetail.Add(detailResponse);
                }
                infos.Add(response);
                #endregion
            }
            #endregion

            ViewBag.Order = infos;
            #region 获得数据
            var num = 50;
            var OrderCount = OrderListFunc.Instance.SelectOrderCount(user.Id);
            ViewBag.OrderCount = OrderCount % num == 0 ? ((int)(OrderCount / num)) : ((int)(OrderCount / num) + 1);
            //待付款
            var PendingOrderCount = OrderListFunc.Instance.SelectOrderCount(user.Id, 1);
            ViewBag.PendingOrderCount = PendingOrderCount % num == 0 ? ((int)(PendingOrderCount / num)) : ((int)(PendingOrderCount / num) + 1);
            //待发货
            var deliveryOrderCount = OrderListFunc.Instance.SelectOrderCount(user.Id, 3);
            ViewBag.DeliveryOrderCount = deliveryOrderCount % num == 0 ? ((int)(deliveryOrderCount / num)) : ((int)(deliveryOrderCount / num) + 1);
            //待收货
            var ReceivedOrderCount = OrderListFunc.Instance.SelectOrderCount(user.Id, 4);
            ViewBag.ReceivedOrderCount = ReceivedOrderCount % num == 0 ? ((int)(ReceivedOrderCount / num)) : ((int)(ReceivedOrderCount / num) + 1);
            //待评价
            var EvaluatedOrderCount = OrderListFunc.Instance.SelectOrderCount(user.Id, 5);
            ViewBag.EvaluatedOrderCount = EvaluatedOrderCount % num == 0 ? ((int)(EvaluatedOrderCount / num)) : ((int)(EvaluatedOrderCount / num) + 1);
            //已完成
            var CompletedOrderCount = OrderListFunc.Instance.SelectOrderCount(user.Id, 6);
            ViewBag.CompletedOrderCount = CompletedOrderCount % num == 0 ? ((int)(CompletedOrderCount / num)) : ((int)(CompletedOrderCount / num) + 1);
            //退货中
            var RefundOrderCount = OrderListFunc.Instance.SelectOrderCount(user.Id, 7);
            ViewBag.RefundOrderCount = RefundOrderCount % num == 0 ? ((int)(RefundOrderCount / num)) : ((int)(RefundOrderCount / num) + 1);
            #endregion

            return View();
        }
        /// <summary>
        /// 订单详情
        /// </summary>
        /// <returns></returns>
        public ActionResult OrderDetail()
        {

            var OrderId = HttpContext.Request.QueryString["OrderId"].ParseInt();
            if (OrderId != null)
            {
                #region 订单信息
                var OrderList = OrderListFunc.Instance.SelectOrderInfo(OrderId.Value);
                var ListStatus = StatusFunc.Instance.GetAllStatusInfo();
                var ListColor = ColorinfoFunc.Instance.GetAllColorListBase();
                var response = new OrderInfoResponse(OrderList, ListStatus);
                ViewBag.Order = response;
                response.ListDetail = new List<OrderDetailResponse>();
                var DetailList = OrderListFunc.Instance.SelectDetail(0, 99, OrderList.Id);
                foreach (var detail in DetailList)
                {
                    var detailResponse = new OrderDetailResponse(detail, ListColor);
                    response.ListDetail.Add(detailResponse);
                }
                ViewBag.OrderDetail = response;
                #endregion

                #region  地址
                if (OrderList.Address != null)
                {
                    ViewBag.AddressFull = OrderList.Address;
                }
                else
                {
                    int AddressId = OrderList.AddressId.Value;
                    ViewBag.Address = AddressFunc.Instance.SelectAddrById(AddressId);
                }
                #endregion

                #region 快递信息
                if (OrderList.ExpressNo != null && OrderList.ExpressCompany != null)
                {
                    var result = MemCacheHelper2.Instance.Cache.GetModel<KdApiResult>(OrderList.ExpressNo + ":" + OrderList.ExpressCompany);
                    if (result == null)
                    {
                        result = KdApiSearchDemo.Instance.getOrderTracesByJson(OrderList.ExpressCompany, OrderList.ExpressNo);
                        MemCacheHelper2.Instance.Cache.Set(OrderList.ExpressNo + ":" + OrderList.ExpressCompany, result, DateTime.Now.AddHours(6));
                    }
                    ViewBag.Express = result;
                }
                #endregion

            }
            return View();
        }
        /// <summary>
        /// 评论
        /// </summary>
        /// <returns></returns>
        public ActionResult Evaluate()
        {
            //订单信息
            var OrderId = HttpContext.Request.QueryString["OrderId"].ParseInt();
            if (OrderId != null)
            {
                var OrderList = OrderListFunc.Instance.SelectOrderInfo(OrderId.Value);
                var ListStatus = StatusFunc.Instance.GetAllStatusInfo();
                var ListColor = ColorinfoFunc.Instance.GetAllColorListBase();
                var response = new OrderInfoResponse(OrderList, ListStatus);
                ViewBag.Order = response;

                #region 订单详细信息
                response.ListDetail = new List<OrderDetailResponse>();
                var DetailList = OrderListFunc.Instance.SelectDetail(0, 99, OrderList.Id);
                foreach (var detail in DetailList)
                {
                    var detailResponse = new OrderDetailResponse(detail, ListColor);
                    response.ListDetail.Add(detailResponse);
                }
                ViewBag.OrderDetail = response;
                #endregion

                #region 地址
                int AddressId = OrderList.AddressId.Value;
                ViewBag.Address = AddressFunc.Instance.SelectAddrById(AddressId);
                #endregion
            }
            return View();

        }
        /// <summary>
        /// 收藏
        /// </summary>
        /// <returns></returns>
        public ActionResult UserLike()
        {
            var userGuid = CookieOper.Instance.GetUserGuid();
            var user = MemCacheHelper2.Instance.Cache.GetModel<User>("UserGuID_" + userGuid);
            var LikeList = UserLikeFunc.Instance.SelectLikePage(0, 5, user.Id);

            #region 颜色
            List<LikeCommodityResponse> infos = new List<LikeCommodityResponse>();
            var ListColor = ColorFunc.Instance.GetAllColorInfo();
            foreach (var item in LikeList)
            {
                var commResponse = new LikeCommodityResponse(item, ListColor);
                infos.Add(commResponse);
            }
            ViewBag.LikeList = infos;
            #endregion

            var num = 5;
            var count = UserLikeFunc.Instance.SelectLikeCount(user.Id);
            ViewBag.PageCount = count % num == 0 ? ((int)(count / num)) : ((int)(count / num) + 1);
            return View();
        }

        /// <summary>
        /// 阿里支付回掉
        /// </summary>
        /// <returns></returns>
        public ActionResult AliPayOrder(AliPagePayRequest request)
        {
            if (request.app_id == AlipayHelper.Instance.app_id)
            {
                var orderInfo = Order_InfoFunc.Instance.SelectByModel(new Order_Info { OrderNo = request.out_trade_no }).FirstOrDefault();

                if (orderInfo.Status != 1)
                {
                    return RedirectToAction("MyOrderList");
                }
                orderInfo.Status = 3;
                orderInfo.PayType = 2;
                if (Order_InfoFunc.Instance.Update(orderInfo))
                {
                    SendMail.Instance.SendEmail(orderInfo.Phone, "{\"code\":\"" + orderInfo.OrderNo + "\",\"code2\":\"" + orderInfo.TotalPrice + "\"}", Enum_SendEmailCode.NoticeOfPaymentCode);
                    this.TempData["OrderId"] = orderInfo.Id;
                    return RedirectToAction("OrderPaySuccessPage", "PayPage");
                }
            }
            return RedirectToAction("MyOrderList");
        }

        /// <summary>
        /// 微信支付回掉
        /// </summary>
        /// <returns></returns>
        public ActionResult WeChatOrder()
        {
            return RedirectToAction("MyOrderList");
        }
        /// <summary>
        /// 客服
        /// </summary>
        /// <returns></returns>
        public ActionResult CustomerService()
        {
            var userGuid = CookieOper.Instance.GetUserGuid();
            var user = MemCacheHelper2.Instance.Cache.GetModel<User>("UserGuID_" + userGuid);

            #region 登录
            if (user != null)
            {
                ViewBag.UserInfo = user;
            }
            ViewBag.UserInfo = null;
            #endregion

            #region 产生随机客服编号
            var Services = ServiceFun.Instance.SelectService(0, 9999, false);
            if (Services.Count != 0)
            {
                //产生随机数
                Random Rdm = new Random();
                int iRdm = Rdm.Next(0, Services.Count - 1);
                ViewBag.Service = Services[iRdm];
            }
            else
            {
                ViewBag.Service = null;
            }
            #endregion

            #region 未登录,得到guid注册
            var guidArry = userGuid.Split('-').ToList();
            var guid = "";
            foreach (var item in guidArry)
            {
                guid = guid + item;
            }
            ViewBag.userGuid = guid;
            #endregion

            return View();
        }


        /// <summary>
        /// 修改密码
        /// </summary>
        /// <returns></returns>
        public ActionResult Password()
        {
            var userGuid = CookieOper.Instance.GetUserGuid();
            var user = MemCacheHelper2.Instance.Cache.GetModel<User>("UserGuID_" + userGuid);
            if (user != null)
            {

            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
    }
}