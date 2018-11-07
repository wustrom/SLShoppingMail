using Common.Result;
using DbOpertion.Function;
using DbOpertion.Models;
using SLSM.AdminWeb.Model.Request.Table;
using SLSM.AdminWeb.Model.Response.Table;
using SLSM.DBOpertion.Function;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace SLSM.AdminWeb.Controllers.AjaxController
{
    /// <summary>
    /// 表格控制器
    /// </summary>
    public class TableController : ApiController
    {
        #region 用户管理表格
        /// <summary>
        /// 获得用户信息列表
        /// </summary>
        /// <param name="request">请求</param>
        /// <returns></returns>
        [HttpPost]
        public LayUITableResponse<List<UserInfo>> GetUserInfo(LayUITableRequest request)
        {
            var List_User = UserFunc.Instance.SelectUserByPage(request.pageIndex, request.pageSize);
            LayUITableResponse<List<UserInfo>> response = new LayUITableResponse<List<UserInfo>>();
            foreach (var item in List_User)
            {
                response.list.Add(new UserInfo(item));
            }
            response.count = UserFunc.Instance.SelectAllUserCount();
            response.rel = true;
            response.msg = "成功";
            if (response.count == 0)
            {
                response.rel = false;
                response.msg = "暂无数据";
            }
            return response;
        }
        #endregion

        #region 商品管理表格
        /// <summary>
        /// 获得分类列表
        /// </summary>
        /// <param name="request">请求</param>
        /// <returns></returns>
        [HttpPost]
        public LayUITableResponse<List<GradeInfo>> GetGradeInfo(LayUITableRequest request)
        {
            var List_Grade = GradeFunc.Instance.SelectGradeByPage(request.pageIndex, request.pageSize);
            LayUITableResponse<List<GradeInfo>> response = new LayUITableResponse<List<GradeInfo>>();
            foreach (var item in List_Grade)
            {
                response.list.Add(new GradeInfo(item));
            }
            response.count = GradeFunc.Instance.SelectAllGradeCount();
            response.rel = true;
            response.msg = "成功";
            if (response.count == 0)
            {
                response.rel = false;
                response.msg = "暂无数据";
            }
            return response;
        }

        /// <summary>
        /// 获得商品列表
        /// </summary>
        /// <param name="request">请求</param>
        /// <returns></returns>
        [HttpPost]
        public LayUITableResponse<List<CommodityInfo>> GetCommodityList(LayUITableRequest request)
        {
            var CommodityList = CommodityFunc.Instance.SelectCommodityListByPage(request.sort, (request.pageIndex - 1) * request.pageSize, request.pageSize, request.order, request.name);
            LayUITableResponse<List<CommodityInfo>> response = new LayUITableResponse<List<CommodityInfo>>();
            foreach (var item in CommodityList)
            {
                response.list.Add(new CommodityInfo(item));
            }
            response.count = CommodityFunc.Instance.SelectCommodityListCount((request.pageIndex - 1) * request.pageSize, request.pageSize, request.name);
            response.rel = true;
            response.msg = "成功";
            if (response.count == 0)
            {
                response.rel = false;
                response.msg = "暂无数据";
            }
            return response;
        }
        #endregion

        #region 商城展示管理表格
        /// <summary>
        /// 获得分类列表推荐
        /// </summary>
        /// <param name="request">请求</param>
        /// <returns></returns>
        [HttpPost]
        public LayUITableResponse<List<SLSM.AdminWeb.Model.Response.Table.GradeInfo>> GetGradeListSetting(LayUITableRequest request)
        {
            var List_Grade = GradeFunc.Instance.SelectGradeByPageByTime(request.pageIndex, request.pageSize);
            LayUITableResponse<List<SLSM.AdminWeb.Model.Response.Table.GradeInfo>> response = new LayUITableResponse<List<SLSM.AdminWeb.Model.Response.Table.GradeInfo>>();
            foreach (var item in List_Grade)
            {
                response.list.Add(new SLSM.AdminWeb.Model.Response.Table.GradeInfo(item));
            }
            response.count = GradeFunc.Instance.SelectAllGradeCount();
            response.rel = true;
            response.msg = "成功";
            if (response.count == 0)
            {
                response.rel = false;
                response.msg = "暂无数据";
            }
            return response;
        }

        /// <summary>
        /// 获得商品列表推荐
        /// </summary>
        /// <param name="request">请求</param>
        /// <returns></returns>
        [HttpPost]
        public LayUITableResponse<List<CommodityInfo>> GetCommodityListSetting(LayUITableRequest request)
        {
            var List_Grade = CommodityFunc.Instance.GetCommodityListByPage((request.pageIndex - 1) * request.pageSize, request.pageSize);
            LayUITableResponse<List<SLSM.AdminWeb.Model.Response.Table.CommodityInfo>> response = new LayUITableResponse<List<SLSM.AdminWeb.Model.Response.Table.CommodityInfo>>();
            foreach (var item in List_Grade)
            {
                response.list.Add(new SLSM.AdminWeb.Model.Response.Table.CommodityInfo(item));
            }
            response.count = CommodityFunc.Instance.GetCommodityListCount();
            response.rel = true;
            response.msg = "成功";
            if (response.count == 0)
            {
                response.rel = false;
                response.msg = "暂无数据";
            }
            return response;
        }

        /// <summary>
        /// 获得在线图库列表
        /// </summary>
        /// <param name="request">请求</param>
        /// <returns></returns>
        [HttpPost]
        public LayUITableResponse<List<CarouselImage>> GetOnlineGallery(LayUITableRequest request)
        {
            var List_Grade = Carousel_ImageFunc.Instance.SelectAllImages();
            LayUITableResponse<List<CarouselImage>> response = new LayUITableResponse<List<CarouselImage>>();
            foreach (var item in List_Grade.Item1)
            {
                response.list.Add(new CarouselImage(item));
            }
            response.count = List_Grade.Item2;
            response.rel = true;
            response.msg = "成功";
            if (response.count == 0)
            {
                response.rel = false;
                response.msg = "暂无数据";
            }
            return response;
        }
        #endregion

        #region 订单管理表格
        /// <summary>
        /// 获得网页订单列表
        /// </summary>
        /// <param name="request">请求</param>
        /// <returns></returns>
        [HttpPost]
        public LayUITableResponse<List<OrderInfoResponse>> GetWebOrderList(LayTableOrderRequest request)
        {
            int? StatusType = null;
            if (request.StatusType != 0)
            {
                StatusType = request.StatusType;
            }
            var List_Order = OrderListFunc.Instance.GetOrderList((request.pageIndex - 1) * request.pageSize, request.pageSize, request.sort, request.order, 1, request.name, StatusType);
            var List_OrderDetail = Order_DetailFunc.Instance.SelectByKeys("OrderId", List_Order.Select(p => p.Id.ToString()).ToList());
            var List_Commodity = CommodityFunc.Instance.SelectByKeys("Id", List_OrderDetail.Select(p => p.CommodityId.ToString()).ToList());
            var List_Materials = Raw_MaterialsFunc.Instance.SelectByKeys("Id", List_Commodity.Select(p => p.MaterialId.ToString()).ToList());
            LayUITableResponse<List<OrderInfoResponse>> response = new LayUITableResponse<List<OrderInfoResponse>>();
            var payList = PayTypeFunc.Instance.GetAllPayTypeInfo();
            var orderList = StatusFunc.Instance.GetAllStatusInfo();
            foreach (var item in List_Order)
            {
                var order = new OrderInfoResponse(item, payList, orderList);
                var this_OrderDetail = List_OrderDetail.Where(p => p.OrderId == item.Id).ToList();
                order.ProductNum = "";
                order.MaterName = "";
                foreach (var orderdetailitem in this_OrderDetail)
                {
                    var commodity = List_Commodity.Where(p => p.Id == orderdetailitem.CommodityId).FirstOrDefault();
                    if (commodity == null)
                    {
                        continue;
                    }
                    var Material = List_Materials.Where(p => p.Id == commodity.MaterialId).FirstOrDefault();
                    if (Material == null)
                    {
                        continue;
                    }
                    if (orderdetailitem != this_OrderDetail[0])
                    {
                        order.ProductNum = $"{order.ProductNum},";
                        order.MaterName = $"{order.MaterName},";
                    }
                    order.ProductNum = $"{order.ProductNum}{orderdetailitem.Amount}";
                    order.MaterName = $"{order.MaterName}{Material.ProductNo}";
                }
                response.list.Add(order);
            }
            response.count = OrderListFunc.Instance.GetOrderCount(1, request.name, StatusType);
            response.rel = true;
            response.msg = "成功";
            if (response.count == 0)
            {
                response.rel = false;
                response.msg = "暂无数据";
            }
            return response;
        }

        /// <summary>
        /// 获得微信订单列表
        /// </summary>
        /// <param name="request">请求</param>
        /// <returns></returns>
        [HttpPost]
        public LayUITableResponse<List<OrderInfoResponse>> GetWeChatOrderList(LayTableOrderRequest request)
        {
            int? StatusType = null;
            if (request.StatusType != 0)
            {
                StatusType = request.StatusType;
            }
            var List_Order = OrderListFunc.Instance.GetOrderList((request.pageIndex - 1) * request.pageSize, request.pageSize, request.sort, request.order, 2, request.name, StatusType);
            var List_OrderDetail = Order_DetailFunc.Instance.SelectByKeys("OrderId", List_Order.Select(p => p.Id.ToString()).ToList());
            var List_Commodity = CommodityFunc.Instance.SelectByKeys("Id", List_OrderDetail.Select(p => p.CommodityId.ToString()).ToList());
            var List_Materials = Raw_MaterialsFunc.Instance.SelectByKeys("Id", List_Commodity.Select(p => p.MaterialId.ToString()).ToList());
            LayUITableResponse<List<OrderInfoResponse>> response = new LayUITableResponse<List<OrderInfoResponse>>();
            var payList = PayTypeFunc.Instance.GetAllPayTypeInfo();
            var orderList = StatusFunc.Instance.GetAllStatusInfo();
            foreach (var item in List_Order)
            {
                var order = new OrderInfoResponse(item, payList, orderList);
                var this_OrderDetail = List_OrderDetail.Where(p => p.OrderId == item.Id).ToList();
                order.ProductNum = "";
                order.MaterName = "";
                foreach (var orderdetailitem in this_OrderDetail)
                {
                    var commodity = List_Commodity.Where(p => p.Id == orderdetailitem.CommodityId).FirstOrDefault();
                    if (commodity == null)
                    {
                        continue;
                    }
                    var Material = List_Materials.Where(p => p.Id == commodity.MaterialId).FirstOrDefault();
                    if (Material == null)
                    {
                        continue;
                    }
                    if (orderdetailitem != this_OrderDetail[0])
                    {
                        order.ProductNum = $"{order.ProductNum},";
                        order.MaterName = $"{order.MaterName},";
                    }
                    order.ProductNum = $"{order.ProductNum}{orderdetailitem.Amount}";
                    order.MaterName = $"{order.MaterName}{Material.ProductNo}";
                }
                response.list.Add(order);
            }
            response.count = OrderListFunc.Instance.GetOrderCount(2, request.name, StatusType);
            response.rel = true;
            response.msg = "成功";
            if (response.count == 0)
            {
                response.rel = false;
                response.msg = "暂无数据";
            }
            return response;
        }
        #endregion

        #region 回复评价表格
        /// <summary>
        /// 获得用户信息列表
        /// </summary>
        /// <param name="request">请求</param>
        /// <returns></returns>
        [HttpPost]
        public LayUITableResponse<List<EvaluateResponse>> GetEvaluateList(LayUITableRequest request)
        {
            var List_Evaluate = EvaluateFunc.Instance.SelectByPage(request.sort, request.order, (request.pageIndex - 1) * request.pageSize, request.pageSize);
            LayUITableResponse<List<EvaluateResponse>> response = new LayUITableResponse<List<EvaluateResponse>>();
            foreach (var item in List_Evaluate)
            {
                response.list.Add(new EvaluateResponse(item));
            }
            response.count = EvaluateFunc.Instance.SelectAllCount();
            response.rel = true;
            response.msg = "成功";
            return response;
        }
        #endregion

        #region 消息管理表格
        /// <summary>
        /// 获得用户信息列表
        /// </summary>
        /// <param name="request">请求</param>
        /// <returns></returns>
        [HttpPost]
        public LayUITableResponse<List<MessageResponse>> GetMessageList(LayUITableRequest request)
        {
            var List_Evaluate = MessageFunc.Instance.SelectMessageByPage(request.sort, request.order, (request.pageIndex - 1) * request.pageSize, request.pageSize);
            LayUITableResponse<List<MessageResponse>> response = new LayUITableResponse<List<MessageResponse>>();
            foreach (var item in List_Evaluate)
            {
                response.list.Add(new MessageResponse(item));
            }
            response.count = MessageFunc.Instance.SelectAllMessageCount();
            response.rel = true;
            response.msg = "成功";
            if (response.count == 0)
            {
                response.rel = false;
                response.msg = "暂无数据";
            }
            return response;
        }

        /// <summary>
        /// 获得用户信息列表
        /// </summary>
        /// <param name="request">请求</param>
        /// <returns></returns>
        [HttpPost]
        public LayUITableResponse<List<MessageResponse>> GetNewsList(LayUITableRequest request)
        {
            var List_Evaluate = NewsFunc.Instance.SelectNewsPage(request.sort, request.order, (request.pageIndex - 1) * request.pageSize, request.pageSize);
            LayUITableResponse<List<MessageResponse>> response = new LayUITableResponse<List<MessageResponse>>();
            foreach (var item in List_Evaluate)
            {
                response.list.Add(new MessageResponse(item));
            }
            response.count = NewsFunc.Instance.SelectNewsPageCount();
            response.rel = true;
            response.msg = "成功";
            if (response.count == 0)
            {
                response.rel = false;
                response.msg = "暂无数据";
            }
            return response;
        }
        #endregion

        #region 客服管理表格
        /// <summary>
        /// 获得客服信息列表
        /// </summary>
        /// <param name="request">请求</param>
        /// <returns></returns>
        [HttpPost]
        public LayUITableResponse<List<CustomerserviceInfo>> GetService(LayUITableRequest request)
        {
            var List_Service = CustomerserviceFunc.Instance.SelectUserByPage(request.pageIndex, request.pageSize);
            LayUITableResponse<List<CustomerserviceInfo>> response = new LayUITableResponse<List<CustomerserviceInfo>>();
            foreach (var item in List_Service)
            {
                response.list.Add(new CustomerserviceInfo(item));
            }
            response.count = CustomerserviceFunc.Instance.SelectAllUserCount();
            response.rel = true;
            response.msg = "成功";
            return response;
        }
        #endregion
    }
}