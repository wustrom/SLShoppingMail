using Common.Extend;
using Common.Helper;
using Common.ThirdParty;
using DbOpertion.Function;
using DbOpertion.Models;
using SLSM.DBOpertion.Function;
using SLSM.MoblieWeb.Common.BaseController;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WxPayAPI;

namespace SLSM.Web.Controllers.PageController
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
            var user = MemCacheHelper2.Instance.Cache.GetModel<DbOpertion.Models.User>("UserGuID_" + userGuid);

            if (user != null)
            {
                ViewBag.addressList = AddressFunc.Instance.SelectAll(new Address { UserId = user.Id })
                                                 .OrderByDescending(p => p.DefaultTime).ToList();
                ViewBag.InvoiceList = InvoiceFunc.Instance.SelectModel(new Invoice { UserId = user.Id })
                                                 .OrderByDescending(p => p.InvoiceTime).ToList();
            }
            else
            {
                var NoLogin = Request.QueryString["NoLogin"];
                if (NoLogin != "true")
                {
                    return View("NoLogin");
                }
            }

            if (ShopCartId == null)
            {
                return RedirectToAction("NoMoreThing", "Diy");
            }
            else
            {
                var Count = HisdesignFunc.Instance.GetHisdesignInfoCount(new Hisdesigninfo_View { UserGuId = userGuid, OrderId = 0, IsMobile = false }, ShopCartId.Split(',').Where(p => !p.IsNullOrEmpty()).ToList());
                if (Count == 0)
                {
                    return RedirectToAction("NoMoreThing", "Diy");
                }
            }

            return View();
        }

        /// <summary>
        /// 首页
        /// </summary>
        /// <returns></returns>
        public ActionResult NoLogin()
        {
            return View();
        }

        /// <summary>
        /// 首页
        /// </summary>
        /// <returns></returns>
        public ActionResult OrderPayPage()
        {
            var OrderInfoId = Request.QueryString["OrderInfoId"].ParseInt();
            if (OrderInfoId != null)
            {
                #region 订单信息
                var OrderInfo = Order_InfoFunc.Instance.SelectById(OrderInfoId.Value);
                ViewBag.OrderInfo = OrderInfo;
                if (OrderInfo.Status != 1)
                {
                    return RedirectToAction("MyOrderList", "UserInfo");
                }
                var OrderDetailInfo = Order_Detail_ViewFunc.Instance.SelectByModel(new Order_Detail_View { OrderId = OrderInfoId.Value });
                ViewBag.OrderDetailInfo = OrderDetailInfo;
                #endregion
                #region 支付信息
                var WechatOrder = NativePay.Instance.GetPayUrl(OrderInfo.OrderNo, OrderInfo.TotalPrice.Value);
                ViewBag.WechatOrder = WechatOrder;
                var aliOrder = AlipayHelper.Instance.CreateAlipayPageOrder(OrderInfo.TotalPrice.Value.ToString("0.00"), OrderInfo.OrderNo, "http://www.syloon.cn/UserInfo/AliPayOrder", "", "赛龙商城");
                aliOrder = aliOrder.Replace("name='alipaysubmit'", " name='alipaysubmit' target='_blank' ");
                aliOrder = aliOrder.Replace("<script>document.forms['alipaysubmit'].submit();</script>", "");
                ViewBag.aliOrder = aliOrder;
                #endregion
                ViewBag.OrderNo = OrderInfo.OrderNo;
                ViewBag.OrderInfoId = OrderInfoId;
            }
            return View();
        }
    }
}