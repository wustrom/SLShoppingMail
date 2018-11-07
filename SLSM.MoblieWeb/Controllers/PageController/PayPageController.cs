using Common.Extend;
using Common.Helper;
using Common.ThirdParty;
using DbOpertion.Function;
using DbOpertion.Models;
using SLSM.DBOpertion.Function;
using SLSM.Web.Common.BaseController;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WxPayAPI;

namespace SLSM.MoblieWeb.Controllers.PageController
{
    /// <summary>
    /// 支付页面控制器
    /// </summary>
    public class PayPageController : BaseMvcMasterController
    {
        /// <summary>
        /// 首页
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            var ShopCartId = Request.QueryString["ShopCartId"];
            ViewBag.ShopCartId = ShopCartId;
            var userGuid = CookieOper.Instance.GetUserGuid();
            ViewBag.ShopCartId = ShopCartId;
            var user = MemCacheHelper2.Instance.Cache.GetModel<DbOpertion.Models.User>("UserGuID_" + userGuid);
            var NoLogin = Request.QueryString["NoLogin"].ParseBool();
            if (user != null)
            {
                ViewBag.addressList = AddressFunc.Instance.SelectAll(new DbOpertion.Models.Address { UserId = user.Id })
                                                 .OrderByDescending(p => p.DefaultTime).ToList();
            }
            else if (NoLogin == true)
            {
                return View();
            }
            else
            {
                return View("NoLoginPage");
            }
            return View();
        }

        /// <summary>
        /// 订单支付页面
        /// </summary>
        /// <returns></returns>
        public ActionResult OrderPayPage()
        {
            var OrderId = Request.QueryString["OrderId"].ParseInt();
            if (OrderId != null)
            {
                #region 订单信息
                var OrderInfo = Order_InfoFunc.Instance.SelectById(OrderId.Value);
                ViewBag.OrderInfo = OrderInfo;
                if (OrderInfo.Status != 1)
                {
                    return RedirectToAction("MyOrderList", "UserInfo");
                }
                var OrderDetailInfo = Order_Detail_ViewFunc.Instance.SelectByModel(new Order_Detail_View { OrderId = OrderId.Value });
                ViewBag.OrderDetailInfo = OrderDetailInfo;
                #endregion
                #region 支付信息
                //var WechatOrder = NativePay.Instance.GetPayUrl(OrderInfo.OrderNo, OrderInfo.TotalPrice.Value);
                //ViewBag.WechatOrder = WechatOrder;
                var aliOrder = AlipayHelper.Instance.CreateAlipayWapOrder(OrderInfo.TotalPrice.Value.ToString("0.00"), OrderInfo.OrderNo, "http://mobile.syloon.cn/UserInfo/AliPayOrder", "", "赛龙商城");
                aliOrder = aliOrder.Replace("<script>document.forms['alipaysubmit'].submit();</script>", "");
                ViewBag.aliOrder = aliOrder;
                #endregion
                ViewBag.OrderNo = OrderInfo.OrderNo;
                ViewBag.OrderInfoId = OrderId;
            }
            return View();
        }

        
    }
}