using Common.Helper;
using DbOpertion.Function;
using DbOpertion.Models;
using SLSM.AdminWeb.Common.BaseController;
using SLSM.AdminWeb.Model.Request.Commdity;
using SLSM.DBOpertion.Function;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SLSM.AdminWeb.Controllers.PageController
{
    public class OrderController : BaseMvcMasterController
    {
        /// <summary>
        /// 网站订单
        /// </summary>
        /// <returns></returns>
        public ActionResult WebOrder()
        {
            ViewBag.OrderStatus = StatusFunc.Instance.GetAllStatusInfo();
            return View();
        }

        /// <summary>
        /// 微信订单
        /// </summary>
        /// <returns></returns>
        public ActionResult WechatOrder()
        {
            ViewBag.OrderStatus = StatusFunc.Instance.GetAllStatusInfo();
            return View();
        }

        /// <summary>
        /// 微信订单
        /// </summary>
        /// <returns></returns>
        public ActionResult OrderDetail(IdRequest request)
        {
            if (request.Id != 0)
            {
                var OrderInfo = OrderFunc.Instance.GetOrderInfo(request.Id);
                var viewList = new List<Order_Detail_View>();
                foreach (var item in OrderInfo.Item2)
                {
                    var result = FileHelper.Instance.SelectImageFile($"/current/images/ShopCart/{ item.ShopCartId}/");
                    item.Image = result;
                    viewList.Add(item);
                }
                ViewBag.OrderInfo = new Tuple<Order_Allinfo, List<Order_Detail_View>>(item1: OrderInfo.Item1, item2: viewList);
                ViewBag.ColorInfo = ColorinfoFunc.Instance.GetAllColorListBase();
                ViewBag.Status = StatusFunc.Instance.GetStatusName(OrderInfo.Item1.Status);
                ViewBag.PayType = PayTypeFunc.Instance.GetPayTypeName(OrderInfo.Item1.PayType);
            }

            return View();
        }
        
        /// <summary>
        /// 确定发货
        /// </summary>
        /// <param name="request">请求</param>
        /// <returns></returns>
        public ActionResult SendThing(IdRequest request)
        {
            if (request.Id != 0)
            {
                ViewBag.OrderInfo = OrderFunc.Instance.GetOrderById(request.Id);
                ViewBag.OrderID = request.Id;
            }
            return View();
        }
    }
}