using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Common.Extend;
using Common.Helper;
using DbOpertion.Models;
using SLSM.DBOpertion.Function;
using SLSM.Web.Common.BaseController;
using SLSM.MoblieWeb.Models.Response.Order;
using Common.ThirdParty.KdGold;
using Common.ThirdParty.AliPay;
using Common.ThirdParty;
using DbOpertion.Function;
using SLSM.MoblieWeb.Controllers.AjaxController;
using AliyunHelper.SendMail;

namespace SLSM.Web.Controllers.PageController
{
    /// <summary>
    /// 
    /// </summary>
    public class UserInfoController : BaseMvcMasterController
    {
        // GET: UserInfo
        /// <summary>
        /// 首页1
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            //未读个数
            var userGuid = CookieOper.Instance.GetUserGuid();
            var user = MemCacheHelper2.Instance.Cache.GetModel<User>("UserGuID_" + userGuid);
            if (user != null)
            {
                var Nocount = MessageFunc.Instance.SelectMessageCount(user.Id, false);
                ViewBag.NoReadMessageAllCount = Nocount;
                ViewBag.NoReadMessageCount = Nocount % 5 == 0 ? ((int)(Nocount / 5)) : ((int)(Nocount / 5) + 1);
            }
            if (user == null)
            {
                return RedirectToAction("Index", "Login");
            }
            return View();
        }
        /// <summary>
        /// 用户信息1
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
                return RedirectToAction("Index", "Login");
            }
            ViewBag.UserFullInfo = UserFunc.Instance.SelectById(user.Id);
            return View();
        }
        /// <summary>
        /// 消息1
        /// </summary>
        /// <returns></returns>
        public ActionResult Message()
        {
            var userGuid = CookieOper.Instance.GetUserGuid();
            var user = MemCacheHelper2.Instance.Cache.GetModel<User>("UserGuID_" + userGuid);
            if (user != null)
            {
                ViewBag.Message = MessageFunc.Instance.SelectMessage(0, 999, user.Id);
            }
            if (user == null)
            {
                return RedirectToAction("Index", "Login");
            }
            ViewBag.MessageCount = MessageFunc.Instance.SelectMessageCount(user.Id);
            return View();
        }
        /// <summary>
        /// 地址1
        /// </summary>
        /// <returns></returns>
        public ActionResult Address()
        {
            var userGuid = CookieOper.Instance.GetUserGuid();
            var user = MemCacheHelper2.Instance.Cache.GetModel<User>("UserGuID_" + userGuid);
            if (user != null)
            {
                ViewBag.Address = UserFunc.Instance.SelectAddress(0, 999, user.Id);
                ViewBag.AddressCount = UserFunc.Instance.SelectAddressCount(user.Id);
            }
            if (user == null)
            {
                return RedirectToAction("Index", "Login");
            }
            return View();
        }
        /// <summary>
        /// 新增和修改地址1
        /// </summary>
        /// <returns></returns>
        public ActionResult AddressAdd()
        {
            var Id = HttpContext.Request.QueryString["id"].ParseInt();
            if (Id != null)
            {
                var Address = AddressFunc.Instance.SelectAddrById(Id.Value);
                ViewBag.Address = Address;
                if (Address.AddrArea != null)
                {
                    var array = Address.AddrArea.Split(',');
                    if (array.Count() == 3)
                    {
                        ViewBag.provinceList = ProvinceHelper.Instance.GetProvinceList();
                        ViewBag.CityList = ProvinceHelper.Instance.GetCityList(array[0]);
                        ViewBag.AreaList = ProvinceHelper.Instance.GetAreaList(array[1]);
                    }
                    else
                    {
                        ViewBag.provinceList = new List<string>();
                        ViewBag.CityList = new List<string>();
                        ViewBag.AreaList = new List<string>();
                    }
                }
                else
                {
                    ViewBag.provinceList = new List<string>();
                    ViewBag.CityList = new List<string>();
                    ViewBag.AreaList = new List<string>();
                }
            }
            else
            {
                ViewBag.provinceList = new List<string>();
                ViewBag.CityList = new List<string>();
                ViewBag.AreaList = new List<string>();
                return View();
            }
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
                var OrderInfo = Order_InfoFunc.Instance.SelectByModel(new Order_Info { OrderNo = request.out_trade_no }).FirstOrDefault();
                if (OrderInfo.Status != 1)
                {
                    return RedirectToAction("MyOrderList");
                }
                SendMail.Instance.SendEmail(OrderInfo.Phone, "{\"code\":\"" + OrderInfo.OrderNo + "\",\"code2\":\"" + OrderInfo.TotalPrice + "\"}", Enum_SendEmailCode.NoticeOfPaymentCode);
                if (OrderFunc.Instance.OrderSurePay(request.out_trade_no))
                {
                    this.TempData["OrderId"] = OrderInfo.Id;
                    return RedirectToAction("OrderPaySuccessPage", "PayPage");
                }
            }
            return RedirectToAction("MyOrderList");
        }
        /// <summary>
        /// 我的订单1
        /// </summary>
        /// <returns></returns>
        public ActionResult MyOrderList()
        {
            var userGuid = CookieOper.Instance.GetUserGuid();
            var user = MemCacheHelper2.Instance.Cache.GetModel<User>("UserGuID_" + userGuid);
            if (user == null)
            {
                return RedirectToAction("Index", "Login");
            }
            #region 状态
            var OrderList = OrderListFunc.Instance.SelectOrder(user.Id);
            var OrderDetailList = OrderListFunc.Instance.SelectOrderCommodity(OrderList.Select(p => p.Id).ToList().ConvertToString());
            List<OrderInfoResponse> infos = new List<OrderInfoResponse>();
            var ListStatus = StatusFunc.Instance.GetAllStatusInfo();
            var ListColor = ColorinfoFunc.Instance.GetAllColorListBase();
            foreach (var item in OrderList)
            {

                var response = new OrderInfoResponse(item, ListStatus);
                response.ListDetail = new List<OrderDetailResponse>();
                #region 颜色
                var detailList = OrderDetailList.Where(p => p.OrderId == item.Id).ToList();
                foreach (var detail in detailList)
                {
                    var detailResponse = new OrderDetailResponse(detail, ListColor);
                    response.ListDetail.Add(detailResponse);
                }
                infos.Add(response);
                #endregion
            }
            #endregion
            ViewBag.Order = infos;
            //ViewBag.OrderCount = OrderListFunc.Instance.SelectOrderCount(user.Id);
            ////待付款
            //ViewBag.PendingOrderCount = OrderListFunc.Instance.SelectOrderCount(user.Id, 1);
            ////待收货
            //ViewBag.ReceivedOrderCount = OrderListFunc.Instance.SelectOrderCount(user.Id, 4);
            ////待评价
            //ViewBag.EvaluatedOrderCount = OrderListFunc.Instance.SelectOrderCount(user.Id, 5);
            ////退货中
            //ViewBag.RefundOrderCount = OrderListFunc.Instance.SelectOrderCount(user.Id, 6);
            return View();
        }
        /// <summary>
        /// 退货申请1
        /// </summary>
        /// <returns></returns>
        public ActionResult ReturnGood()
        {
            var OrderId = HttpContext.Request.QueryString["OrderId"].ParseInt();
            if (OrderId != null)
            {
                var OrderList = OrderListFunc.Instance.SelectOrderInfo(OrderId.Value);
                var ListStatus = StatusFunc.Instance.GetAllStatusInfo();
                var ListColor = ColorinfoFunc.Instance.GetAllColorListBase();
                //状态
                var response = new OrderInfoResponse(OrderList, ListStatus);
                ViewBag.Order = response;
                response.ListDetail = new List<OrderDetailResponse>();
                #region 颜色
                var DetailList = OrderListFunc.Instance.SelectDetail(0, 99, OrderList.Id);
                foreach (var detail in DetailList)
                {
                    var detailResponse = new OrderDetailResponse(detail, ListColor);
                    response.ListDetail.Add(detailResponse);
                }
                #endregion
                ViewBag.OrderDetail = response;
            }
            return View();
        }
        /// <summary>
        /// 订单详情1
        /// </summary>
        /// <returns></returns>
        public ActionResult OrderDetail()
        {
            var OrderId = HttpContext.Request.QueryString["OrderId"].ParseInt();
            if (OrderId != null)
            {
                var OrderList = OrderListFunc.Instance.SelectOrderInfo(OrderId.Value);
                //状态
                var ListStatus = StatusFunc.Instance.GetAllStatusInfo();
                var ListColor = ColorinfoFunc.Instance.GetAllColorListBase();
                var response = new OrderInfoResponse(OrderList, ListStatus);
                ViewBag.Order = response;
                response.ListDetail = new List<OrderDetailResponse>();

                #region 颜色
                var DetailList = OrderListFunc.Instance.SelectDetail(0, 99, OrderList.Id);
                foreach (var detail in DetailList)
                {
                    var detailResponse = new OrderDetailResponse(detail, ListColor);
                    response.ListDetail.Add(detailResponse);
                }
                #endregion 

                ViewBag.OrderDetail = response;

                #region 地址
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

                #region 快递
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
        /// 评论1
        /// </summary>
        /// <returns></returns>
        public ActionResult Evaluate()
        {
            var OrderId = HttpContext.Request.QueryString["OrderId"].ParseInt();
            if (OrderId != null)
            {
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
            }
            return View();

        }

        /// <summary>
        /// 收藏1
        /// </summary>
        /// <returns></returns>
        public ActionResult UserLike()
        {
            var userGuid = CookieOper.Instance.GetUserGuid();
            var user = MemCacheHelper2.Instance.Cache.GetModel<User>("UserGuID_" + userGuid);
            //颜色
            if (user == null)
            {
                return RedirectToAction("Index", "Login");
            }
            var LikeList = UserLikeFunc.Instance.SelectLikePage(0, 999, user.Id);
            List<LikeCommodityResponse> infos = new List<LikeCommodityResponse>();
            var ListColor = ColorFunc.Instance.GetAllColorInfo();
            foreach (var item in LikeList)
            {
                var commResponse = new LikeCommodityResponse(item, ListColor);
                infos.Add(commResponse);
            }

            ViewBag.LikeList = infos;
            ViewBag.PageCount = UserLikeFunc.Instance.SelectLikeCount(user.Id);
            return View();
        }
        /// <summary>
        /// 客服1
        /// </summary>
        /// <returns></returns>
        public ActionResult CustomerService()
        {
            var userGuid = CookieOper.Instance.GetUserGuid();
            var user = MemCacheHelper2.Instance.Cache.GetModel<User>("UserGuID_" + userGuid);
            if (user != null)
            {
                ViewBag.UserInfo = user;
            }
            ViewBag.UserInfo = null;

            #region 得到随机客服编号
            var Services = ServiceFun.Instance.SelectService(0, 999, true);
            if (Services.Count != 0)
            {
                Random Rdm = new Random();
                //产生随机数
                int iRdm = Rdm.Next(0, Services.Count - 1);
                ViewBag.Service = Services[iRdm];
            }
            else
            {
                ViewBag.Service = null;
            }
            #endregion

            #region 用户没登录时
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
    }
}