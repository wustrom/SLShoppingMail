using Common.Extend;
using Common.Helper;
using DbOpertion.Function;
using DbOpertion.Models;
using SLSM.DBOpertion.Function;
using SLSM.MoblieWeb.Common.BaseController;
using SLSM.Web.Models.Response.Address;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SLSM.Web.Controllers.PageController
{
    /// <summary>
    /// 购物车控制器
    /// </summary>
    public class ShopCartController : BaseMvcMasterController
    {
        /// <summary>
        /// 购物车首页
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {

            return View();
        }

        /// <summary>
        /// 购物车首页
        /// </summary>
        /// <returns></returns>
        public ActionResult DesignInfo()
        {
            #region 购物车详情
            var ShopCartId = Request.QueryString["ShopCartId"].ParseInt();
            if (ShopCartId != null)
            {
                var Hisdesigninfo = HisdesignFunc.Instance.GetModleHisdesign(new Hisdesigninfo_View { Id = ShopCartId.Value, OrderId = 0 }).FirstOrDefault();
                if (Hisdesigninfo.BackView != null && Hisdesigninfo.ForntView != null)
                {
                    ViewBag.ForntView = Hisdesigninfo.ForntView;
                    ViewBag.BackView = Hisdesigninfo.BackView;
                }
                else
                {
                    var commodity = CommodityFunc.Instance.SelectCommInfo(new Commodity { Id = Hisdesigninfo.CommodityId.Value }).FirstOrDefault();
                    ViewBag.BackView = Hisdesigninfo.BackView == null ? commodity.BackView : Hisdesigninfo.BackView;
                    ViewBag.ForntView = Hisdesigninfo.ForntView == null ? commodity.FrontView : Hisdesigninfo.ForntView;
                }
            }
            #endregion

            #region 订单详情
            var OrderDetailId = Request.QueryString["OrderDetailId"].ParseInt();
            if (OrderDetailId != null)
            {
                var OrderDetail = OrderListFunc.Instance.SelectOrderDetailById(OrderDetailId.Value);
                //if (OrderDetail.BackImage != null && OrderDetail.FrontImage != null)
                //{
                //    ViewBag.ForntView = OrderDetail.FrontImage;
                //    ViewBag.BackView = OrderDetail.BackImage;
                //}
                //else
                //{
                //    var commodity = CommodityFunc.Instance.SelectCommInfo(new Commodity { Id = OrderDetail.CommodityId.Value }).FirstOrDefault();
                //    ViewBag.ForntView = OrderDetail.FrontImage == null ? commodity.FrontView : OrderDetail.FrontImage;
                //    ViewBag.BackView = OrderDetail.BackImage == null ? commodity.BackView : OrderDetail.BackImage;
                //}
            }
            #endregion
            return View();
        }
    }
}