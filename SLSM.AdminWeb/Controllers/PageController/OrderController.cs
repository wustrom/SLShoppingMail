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
        #region 订单详情
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
        /// 订单详情
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
        #endregion

        #region 后台下单
        /// <summary>
        /// 后台下单
        /// </summary>
        /// <returns></returns>
        public ActionResult BackstageOrder()
        {
            return View();
        }

        /// <summary>
        /// 后台下单详情
        /// </summary>
        /// <returns></returns>
        public ActionResult BackstageOrderDetail(IdRequest request)
        {
            var colorList = ColorinfoFunc.Instance.GetAllColorListBase();
            ViewBag.colorList = colorList;
            if (request.Id != 0)
            {
                var comm = CommodityFunc.Instance.SelectById(request.Id);
                if (comm != null)
                {
                    var Mater = Raw_MaterialsFunc.Instance.SelectById(comm.MaterialId.Value);
                    ViewBag.Raw_Material = Mater;
                }
                ViewBag.Commodity = comm;
            }
            return View();
        }

        /// <summary>
        /// 后台下单列表
        /// </summary>
        /// <returns></returns>
        public ActionResult BackstageOrderList()
        {
            ViewBag.OrderStatus = StatusFunc.Instance.GetAllStatusInfo();
            return View();
        }

        /// <summary>
        /// 上传Logo
        /// </summary>
        /// <returns></returns>
        public ActionResult UpLoadLogo(IdRequest request)
        {
            ViewBag.OrderInfo = Order_InfoFunc.Instance.SelectById(request.Id);
            return View();
        }

        /// <summary>
        /// 确定设计师
        /// </summary>
        /// <returns></returns>
        public ActionResult SureDesign(IdRequest request)
        {
            var OrderInfo = Order_InfoFunc.Instance.SelectById(request.Id);
            var OrderDetailInfo = Order_DetailFunc.Instance.SelectByModel(new Order_Detail { OrderId = request.Id }).FirstOrDefault();
            var Comm = CommodityFunc.Instance.SelectById(OrderDetailInfo.CommodityId.Value);
            var materials_colorinfo = Materials_ColorinfoFunc.Instance.SelectByModel(new Materials_Colorinfo { MaterialsId = Comm.MaterialId, ColorId = OrderDetailInfo.Color }).FirstOrDefault();
            ViewBag.OrderInfo = OrderInfo;
            ViewBag.OrderDetailInfo = OrderDetailInfo;
            ViewBag.Commodity = Comm;
            ViewBag.materials = Raw_MaterialsFunc.Instance.SelectById(Comm.MaterialId.Value);
            ViewBag.materials_colorinfo = materials_colorinfo;
            ViewBag.ColorInfo = ColorinfoFunc.Instance.SelectById(materials_colorinfo.ColorId.Value);
            ViewBag.production = ProductionFunc.Instance.SelectByModel(new Production { order_detailId = OrderDetailInfo.Id }).FirstOrDefault();
            return View();
        }
        #endregion
    }
}