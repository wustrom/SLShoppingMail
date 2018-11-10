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
using SLSM.Web.Models.Response.Address;
using SLSM.Web.Models.Response.Order;
using SLSM.Web.Models.Resquest;
using SLSM.Web.Models.Resquest.Order;
using SLSM.Web.Models.Resquest.OrderList;
using SLSM.Web.Models.Resquest.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Web;
using System.Web.Http;
using WxPayAPI;

namespace SLSM.Web.Controllers.AjaxContoller
{
    /// <summary>
    /// 地址控制器
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
            var status = StatusFunc.Instance.GetTypeStatus(request.Name);
            var listOrder = OrderListFunc.Instance.SelectOrder(user.Id, status);
            var listOrderDetail = OrderListFunc.Instance.SelectOrderCommodity(listOrder.Select(p => p.Id).ToList().ConvertToString());
            var ListColor = ColorinfoFunc.Instance.GetAllColorListBase();
            var tuples = StatusFunc.Instance.GetAllStatusInfo();
            var flag = true;
            result.Model1 = new List<OrderInfoResponse>();
            foreach (var item in listOrder)
            {
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
        public ResultJsonModel<string> AddOrder(AddOrderRequest request)
        {
            var userGuid = CookieOper.Instance.GetUserGuid();
            var user = MemCacheHelper2.Instance.Cache.GetModel<User>("UserGuID_" + userGuid);
            if (user == null)
            {
                HomeController controller = new HomeController();
                var result = controller.LoginByPhone(new Models.Resquest.Home.LoginByPhoneRequest { UserPhone = request.UserPhone, PhoneCode = request.UserPhoneCode, IsThild = true });
                if (result.HttpCode != 200)
                {
                    return new ResultJsonModel<string> { HttpCode = result.HttpCode, Message = result.Message };
                }
                else
                {
                    user = MemCacheHelper2.Instance.Cache.GetModel<User>("UserGuID_" + userGuid);
                }
            }
            var order = OrderFunc.Instance.CreateOnline(1, request.Address, user.Id, request.ShopCartIds, (decimal)user.Discount, request.Name, request.Phone, request.Invoice);
            if (order.Item1 != null)
            {
                MemCacheHelper2.Instance.Cache.Set("UserGuID_" + userGuid, user, 24 * 60);
                return new ResultJsonModel<string> { HttpCode = 200, Message = order.Item1.Id.ToString() };
            }
            else
            {
                return new ResultJsonModel<string> { HttpCode = 300, Message = order.Item2 };
            }
        }

        /// <summary>
        /// 微信订单确认
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ResultJson WeiChatOrder(string OrderNo)
        {
            var result = OrderQuery.Instance.Run(null, OrderNo);
            var trade_state_desc = result.GetValue("trade_state_desc") == null ? null : result.GetValue("trade_state_desc").ToString();
            var order = Order_InfoFunc.Instance.SelectByModel(new Order_Info { OrderNo = OrderNo }).FirstOrDefault();
            if (order == null)
            {
                return new ResultJson { HttpCode = 300, Message = "此订单并非微信订单！" };
            }
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
                    return new ResultJson { HttpCode = 200, Message = "该订单修改失败！" };
                }
            }
            else
            {
                if (order.LastCodeTime != null && order.LastCodeTime.Value.AddMinutes(30) < DateTime.Now)
                {
                    OrderFunc.Instance.UpdateModel(new Order_Info { Id = order.Id, WechatFaild = true });
                }
                return new ResultJson { HttpCode = 200, Message = "此订单并未成功支付！" };
            }
        }

        /// <summary>
        /// 添加订单
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public ResultJsonModel<string> ChangeOrderPayType(ChangePayTypeRequest request)
        {
            ResultJsonModel<string> result = new ResultJsonModel<string>();
            if (OrderFunc.Instance.UpdateModel(new Order_Info { Id = request.Id, PayType = request.PayType }))
            {
                result.HttpCode = 200;
                var order_Info = OrderFunc.Instance.GetOrderById(request.Id);

                if (request.PayType == 2)
                {
                    var aliOrder = AlipayHelper.Instance.CreateAlipayPageOrder(order_Info.TotalPrice.Value.ToString("0.00"), order_Info.OrderNo, "http://www.syloon.cn/UserInfo/AliPayOrder", "", "赛龙商城");
                    result.Message = aliOrder;
                }
                else if (request.PayType == 3)
                {
                    var WechatOrder = NativePay.Instance.GetPayUrl(order_Info.OrderNo, order_Info.TotalPrice.Value);
                    result.Message = WechatOrder;
                    result.Model1 = order_Info.OrderNo;
                }

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
        /// 确定上传订单详情
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ResultJson SureUploadOrder(OrderDesignRequest request)
        {
            if (Order_InfoFunc.Instance.Update(new Order_Info { Id = request.OrderId, UserDesign = request.DesignImage }))
            {
                return new ResultJson { HttpCode = 200, Message = "订单更新成功！" };
            }
            else
            {
                return new ResultJson { HttpCode = 300, Message = "订单更新失败！" };
            }
        }

        /// <summary>
        /// 确定上传订单详情
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ResultJson OrderDesignInfo(OrderDesignRequest request)
        {
            var orderinfo = Order_InfoFunc.Instance.SelectById(request.OrderId);
            if (orderinfo != null)
            {
                return new ResultJson { HttpCode = 200, Message = orderinfo.UserDesign };
            }
            else
            {
                return new ResultJson { HttpCode = 300, Message = "订单更新失败！" };
            }
        }

        /// <summary>
        /// 根据详情Id筛选设计
        /// </summary>
        /// <param name="request">详情Id</param>
        /// <returns></returns>

        public ResultJson<OrderDetailDesignResponse> DetailDesign(IdRequest request)
        {
            var detail = OrderListFunc.Instance.SelectOrderDetailById(request.Id);
            if (detail != null)
            {
                var OrderInfo = Order_InfoFunc.Instance.SelectById(detail.OrderId.Value);
                if (OrderInfo == null)
                {
                    return new ResultJson<OrderDetailDesignResponse> { HttpCode = 300, Message = "并无对应订单！" };
                }
                if (OrderInfo.ToErp == true)
                {
                    return new ResultJson<OrderDetailDesignResponse> { HttpCode = 300, Message = "该订单设计师已开始设计！" };
                }
                var comm = CommodityFunc.Instance.SelectCommodityById(detail.CommodityId.Value);
                var OrderDetailDesignList = OrderDetailDesignFunc.Instance.SelectByModel(new Orderdetaildesign { OrderDetailId = detail.Id });
                var ListDesign = new List<OrderDetailDesignResponse>();
                #region 正式
                var position = new List<string>();
                var positionList = comm.PringtingPosition.Split(')').Where(p => !string.IsNullOrEmpty(p)).ToList();
                foreach (var item in positionList)
                {
                    var positionItemList = item.Split('(').Where(p => !string.IsNullOrEmpty(p)).ToList(); ;
                    if (positionItemList[0] == detail.Color.Value.ToString())
                    {
                        var positonInfoList = positionItemList[1].Split('|').Where(p => !string.IsNullOrEmpty(p)).ToList();
                        foreach (var positonInfo in positonInfoList)
                        {
                            var arry = positonInfo.Split(',').ToList();
                            position.Add(arry[0] + "," + arry[1] + "," + arry[2]);
                        }
                    }
                }
                #endregion

                #region 临时

                #endregion

                foreach (var item in position)
                {
                    var arry = item.Split(',');
                    var design = OrderDetailDesignList.Where(p => p.PrintingPosition == arry[1]).FirstOrDefault();
                    OrderDetailDesignResponse response;
                    if (design != null)
                    {
                        response = new OrderDetailDesignResponse(design, arry[0]);
                    }
                    else
                    {
                        response = new OrderDetailDesignResponse();

                    }
                    response.MainImage = arry[2];
                    response.PrintingPosition = arry[1];
                    response.Printing = arry[0];
                    ListDesign.Add(response);
                }
                return new ResultJson<OrderDetailDesignResponse> { HttpCode = 200, Message = "查询成功！", ListData = ListDesign };
            }
            return new ResultJson<OrderDetailDesignResponse> { HttpCode = 300, Message = "并未存在此订单！" };
        }

        /// <summary>
        /// 根据详情Id筛选设计
        /// </summary>
        /// <param name="detaildInfoId">详情Id</param>
        /// <returns></returns>
        public ResultJson<OrderDetailDesignResponse> DesignImageInfo(IdRequest request)
        {
            var detail = OrderListFunc.Instance.SelectOrderDetailById(request.Id);
            if (detail != null)
            {
                var OrderInfo = Order_InfoFunc.Instance.SelectById(detail.OrderId.Value);
                if (OrderInfo == null)
                {
                    return new ResultJson<OrderDetailDesignResponse> { HttpCode = 300, Message = "并无对应订单！" };
                }
                var comm = CommodityFunc.Instance.SelectCommodityById(detail.CommodityId.Value);
                var ListDesign = new List<OrderDetailDesignResponse>();
                #region 注释代码
                //var position = new List<string>();
                //var positionList = comm.PringtingPosition.Split(')').Where(p => !string.IsNullOrEmpty(p)).ToList();
                //foreach (var item in positionList)
                //{
                //    var positionItemList = item.Split('(').Where(p => !string.IsNullOrEmpty(p)).ToList(); ;
                //    if (positionItemList[0] == detail.Color.Value.ToString())
                //    {
                //        var positonInfoList = positionItemList[1].Split('|').Where(p => !string.IsNullOrEmpty(p)).ToList();
                //        foreach (var positonInfo in positonInfoList)
                //        {
                //            var arry = positonInfo.Split(',').ToList();
                //            position.Add(arry[0] + "," + arry[1] + "," + arry[2]);
                //        }
                //    }
                //}
                //detail.ImageList = detail.ImageList == null ? "" : detail.ImageList;
                //var ImageList = detail.ImageList.Split('|').Where(p => !string.IsNullOrEmpty(p)).ToList();
                //var ImageDetail = new List<Tuple<string, string, string>>();
                //foreach (var imageitem in ImageList)
                //{
                //    ImageDetail.Add(new Tuple<string, string, string>(item1: imageitem.Split(',')[0], item2: imageitem.Split(',')[1], item3: imageitem.Split(',')[2]));
                //}

                //foreach (var item in position)
                //{
                //    var arry = item.Split(',');
                //    var UserImage = ImageDetail.Where(p => p.Item2 == arry[1]).FirstOrDefault();
                //    var DesignImage = DesignerImageDetail.Where(p => p.Item1 == arry[1]).FirstOrDefault();
                //    OrderDetailDesignResponse response;
                //    if (UserImage != null)
                //    {
                //        response = new OrderDetailDesignResponse
                //        {
                //            OrderDetailId = detail.Id,
                //            MainImage = UserImage.Item3,
                //            Printing = UserImage.Item1,
                //            PrintingPosition = UserImage.Item2
                //        };

                //    }
                //    else
                //    {
                //        response = new OrderDetailDesignResponse();
                //        response.MainImage = arry[2];
                //        response.PrintingPosition = arry[1];
                //        response.Printing = arry[0];
                //    }
                //    if (DesignImage != null)
                //    {
                //        response.DesignImage = DesignImage.Item2;
                //    }
                //    ListDesign.Add(response);
                //}
                #endregion

                #region 设计师上传图片列表
                detail.DesignerImage = detail.DesignerImage == null ? "" : detail.DesignerImage;
                var DesignerImageList = detail.DesignerImage.Split('|').Where(p => !string.IsNullOrEmpty(p)).ToList();
                var DesignerImageDetail = new List<Tuple<string, string>>();
                foreach (var imageitem in DesignerImageList)
                {
                    DesignerImageDetail.Add(new Tuple<string, string>(item1: imageitem.Split(',')[0], item2: imageitem.Split(',')[1]));
                }
                #endregion
                #region MyRegion
                foreach (var item in DesignerImageDetail)
                {
                    OrderDetailDesignResponse response;
                    response = new OrderDetailDesignResponse
                    {
                        OrderDetailId = detail.Id,
                        PrintingPosition = item.Item1,
                        DesignImage = item.Item2
                    };
                    ListDesign.Add(response);
                }
                #endregion
                return new ResultJson<OrderDetailDesignResponse> { HttpCode = 200, Message = "查询成功！", ListData = ListDesign };
            }
            return new ResultJson<OrderDetailDesignResponse> { HttpCode = 300, Message = "并未存在此订单！" };
        }

        /// <summary>
        /// 设计师提交信息
        /// </summary>
        /// <param name="detaildInfoId">详情Id</param>
        /// <returns></returns>
        public ResultJsonModel<OrderDesignResponse> DesignCommitInfo(IdRequest request)
        {
            var detail = OrderListFunc.Instance.SelectOrderDetailById(request.Id);
            if (detail != null)
            {
                detail.PrintingMethod = detail.PrintingMethod == null ? "PrintFunc1" : detail.PrintingMethod;
                var OrderInfo = Order_InfoFunc.Instance.SelectById(detail.OrderId.Value);
                if (OrderInfo == null)
                {
                    return new ResultJsonModel<OrderDesignResponse> { HttpCode = 300, Message = "并无对应订单！" };
                }
                var comm = CommodityFunc.Instance.SelectCommodityById(detail.CommodityId.Value);
                var producer = ProductionFunc.Instance.SelectByModel(new Production { order_detailId = request.Id }).FirstOrDefault();
                var rawmaterials = Raw_MaterialsFunc.Instance.SelectById(comm.MaterialId.Value);
                var materialscolor = Materials_ColorinfoFunc.Instance.SelectByModel(new Materials_Colorinfo { MaterialsId = comm.MaterialId.Value, ColorId = detail.Color }).FirstOrDefault();
                var colorName = ColorinfoFunc.Instance.GetColorListBase().Where(p => p.Id == materialscolor.ColorId).FirstOrDefault();

                #region 印刷方式
                string PrintingFunc = "";
                if (rawmaterials.PrintFuncInfo != null)
                {
                    var printFuncList = rawmaterials.PrintFuncInfo.Split('|').Where(p => !string.IsNullOrEmpty(p)).ToList();
                    foreach (var item in printFuncList)
                    {
                        var arry = item.Split(':').ToList();
                        if (arry.Count == 2)
                        {
                            if (arry[0].ToLower() == detail.PrintingMethod.ToLower())
                            {
                                PrintingFunc = arry[1];
                            }
                            else if (arry[0].ToLower() == detail.PrintingMethod.ToLower())
                            {
                                PrintingFunc = arry[1];
                            }
                            else if (arry[0].ToLower() == detail.PrintingMethod.ToLower())
                            {
                                PrintingFunc = arry[1];
                            }

                        }
                    }
                }
                #endregion

                #region 设计图片
                string SKUImage = "";
                if (detail.DesignerImage != null)
                {
                    var designerImage = detail.DesignerImage.Split('|').Where(p => !string.IsNullOrEmpty(p)).ToList().FirstOrDefault();
                    if (designerImage != null)
                    {
                        var arry = designerImage.Split(',').Where(p => !string.IsNullOrEmpty(p)).ToList();
                        if (arry.Count == 2)
                        {
                            SKUImage = arry[1];
                        }
                    }
                }
                #endregion

                OrderDesignResponse response = new OrderDesignResponse { OrderDetailId = request.Id, OrderDetailNo = OrderInfo.OrderNo, CommodityName = comm.Name, proposal = producer.InspectionContext, ColorName = colorName.ChinaDescribe, PrintingFunc = PrintingFunc, SKU = materialscolor.SKU, SKUImage = SKUImage };
                return new ResultJsonModel<OrderDesignResponse> { HttpCode = 200, Message = "查询成功！", Model1 = response };
            }
            return new ResultJsonModel<OrderDesignResponse> { HttpCode = 300, Message = "并未存在此订单！" };
        }

        public ResultJson UpdateDesignInfo(UpdateDesignInfoRequest request)
        {
            var AdminUrl = System.Configuration.ConfigurationManager.AppSettings["AdminUrl"];
            #region 对文字进行处理
            var WordOpertion = "";
            var WordPositionArray = request.WordList.Select(p => p.Position).Distinct().ToList();
            foreach (var item in WordPositionArray)
            {
                var thisWordPositionList = request.WordList.Where(p => p.Position == item).ToList();
                if (thisWordPositionList.Count != 0)
                {
                    WordOpertion = WordOpertion + item + "(";
                }
                foreach (var thisWordPosition in thisWordPositionList)
                {
                    WordOpertion = $"{WordOpertion}{thisWordPosition.Text},{thisWordPosition.fontFamily},{thisWordPosition.fontsize},{thisWordPosition.color},{thisWordPosition.rotate},{thisWordPosition.Count_Index}|";
                }
                if (thisWordPositionList.Count != 0)
                {
                    WordOpertion = WordOpertion + ")";
                }
            }
            #endregion

            #region 对客户图片进行处理
            var CustomImageOpertion = "";
            var CustomImagePositionArray = request.CustomerImageList.Select(p => p.Position).Distinct().ToList();
            foreach (var item in CustomImagePositionArray)
            {
                var thisCustomImagePositionList = request.CustomerImageList.Where(p => p.Position == item).ToList();
                if (thisCustomImagePositionList.Count != 0)
                {
                    CustomImageOpertion = CustomImageOpertion + item + "(";
                }
                foreach (var thisCustomImage in thisCustomImagePositionList)
                {
                    CustomImageOpertion = $"{CustomImageOpertion}{thisCustomImage.ImageUrl.Replace(AdminUrl, "")},0,{thisCustomImage.rotate},{thisCustomImage.Count_Index}|";
                }
                if (thisCustomImagePositionList.Count != 0)
                {
                    CustomImageOpertion = CustomImageOpertion + ")";
                }
            }
            #endregion

            #region 对在线图片进行处理
            var OnlineImageOpertion = "";
            var OnlineImagePositionArray = request.OnLineImageList.Select(p => p.Position).Distinct().ToList();
            foreach (var item in OnlineImagePositionArray)
            {
                var thisOnlineImagePositionList = request.OnLineImageList.Where(p => p.Position == item).ToList();
                if (thisOnlineImagePositionList.Count != 0)
                {
                    OnlineImageOpertion = OnlineImageOpertion + item + "(";
                }
                foreach (var thisOnlineImage in thisOnlineImagePositionList)
                {
                    OnlineImageOpertion = $"{OnlineImageOpertion}{thisOnlineImage.ImageUrl.Replace(AdminUrl, "")},0,{thisOnlineImage.rotate},{thisOnlineImage.Count_Index}|";
                }
                if (thisOnlineImagePositionList.Count != 0)
                {
                    OnlineImageOpertion = OnlineImageOpertion + ")";
                }
            }
            #endregion

            if (Order_DetailFunc.Instance.Update(new Order_Detail
            {
                Id = request.DetailID,
                WordOpertion = string.IsNullOrEmpty(WordOpertion) ? "" : WordOpertion,
                CustomImageOpertion = string.IsNullOrEmpty(CustomImageOpertion) ? "" : CustomImageOpertion,
                OnLineImageOpertion = string.IsNullOrEmpty(OnlineImageOpertion) ? "" : OnlineImageOpertion,
            }))
            {
                return new ResultJson { HttpCode = 200, Message = "修改成功！" };
            }
            else
            {
                return new ResultJson { HttpCode = 300, Message = "修改失败！" };

            }
        }

        /// <summary>
        /// 设计详情修改
        /// </summary>
        /// <param name="detaildInfoId">详情Id</param>
        /// <returns></returns>
        public ResultJson DetailPositionDesign(PositionDesignRequest request)
        {
            var orderDetail = Order_DetailFunc.Instance.SelectById(request.OrderDetailId);
            if (request.DesignId == 0)
            {
                #region 插入图片
                var key = OrderDetailDesignFunc.Instance.InsertReturnKey(new Orderdetaildesign { PrintingPosition = request.PrintingPosition.Trim(), Content = HtmlCodeHelper.HtmlToString(request.Content), OrderDetailId = request.OrderDetailId });
                if (key > 0)
                {
                    var url = SaveImg(request.Image, $"/current/images/OrderDetail/{key}/");
                    if (orderDetail.ImageList == null)
                    {
                        orderDetail.ImageList = "";
                    }
                    if (orderDetail.ImageList.Contains("," + request.PrintingPosition + ","))
                    {
                        var ImageList = orderDetail.ImageList.Split('|').Where(p => !string.IsNullOrEmpty(p) && !p.Contains("," + request.PrintingPosition + ",")).ToList();
                        orderDetail.ImageList = "";
                        foreach (var item in ImageList)
                        {
                            orderDetail.ImageList = $"{orderDetail.ImageList}|{ImageList}";
                        }
                        orderDetail.ImageList = $"{request.Printing},{request.PrintingPosition},{url}|";
                    }
                    else
                    {
                        orderDetail.ImageList = orderDetail.ImageList + $"{request.Printing},{request.PrintingPosition},{url}|";
                    }
                    if (!Order_DetailFunc.Instance.Update(orderDetail))
                    {
                        return new ResultJson { HttpCode = 300, Message = "订单修改失败！" };
                    }
                    if (url != null)
                    {
                        if (OrderDetailDesignFunc.Instance.Update(new Orderdetaildesign { Id = key, Image = url }))
                        {
                            return new ResultJson { HttpCode = 200, Message = key.ToString() };
                        }
                    }
                    OrderDetailDesignFunc.Instance.DeleteById(key);
                }
                #endregion
                return new ResultJson { HttpCode = 300, Message = "新增失败！" };
            }
            else
            {
                if (OrderDetailDesignFunc.Instance.Update(new Orderdetaildesign { Id = request.DesignId, PrintingPosition = request.PrintingPosition.Trim(), Content = HtmlCodeHelper.HtmlToString(request.Content), OrderDetailId = request.OrderDetailId }))
                {
                    var url = SaveImg(request.Image, $"/current/images/OrderDetail/{request.DesignId}/");
                    if (orderDetail.ImageList == null)
                    {
                        orderDetail.ImageList = "";
                    }
                    if (orderDetail.ImageList.Contains("," + request.PrintingPosition + ","))
                    {
                        var ImageList = orderDetail.ImageList.Split('|').Where(p => !string.IsNullOrEmpty(p) && !p.Contains("," + request.PrintingPosition + ",")).ToList();
                        orderDetail.ImageList = "";
                        foreach (var item in ImageList)
                        {
                            orderDetail.ImageList = $"{orderDetail.ImageList}|{ImageList}";
                        }
                        orderDetail.ImageList = $"{request.Printing},{request.PrintingPosition},{url}|";
                    }
                    else
                    {
                        orderDetail.ImageList = orderDetail.ImageList + $"{request.Printing},{request.PrintingPosition},{url}|";
                    }
                    if (!Order_DetailFunc.Instance.Update(orderDetail))
                    {
                        return new ResultJson { HttpCode = 300, Message = "订单修改失败！" };
                    }
                    if (url != null)
                    {
                        if (OrderDetailDesignFunc.Instance.Update(new Orderdetaildesign { Id = request.DesignId, Image = url }))
                        {
                            return new ResultJson { HttpCode = 200, Message = request.DesignId.ToString() };
                        }
                    }
                    return new ResultJson { HttpCode = 300, Message = "修改失败！" };
                }
                else
                {
                    return new ResultJson { HttpCode = 300, Message = "修改失败！" };
                }
            }

        }

        /// <summary>
        /// 取消订单
        /// </summary>
        /// <param name="request">请求</param>
        /// <returns></returns>
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
                if (!OrderFunc.Instance.CancelOrder(orderInfo.Id))
                {
                    return new ResultJson { HttpCode = 300, Message = "订单取消失败,请重新尝试!" };
                }
                return new ResultJson { HttpCode = 200, Message = "订单取消成功！" };
            }
        }

        public ResultJson SureOrdersubmit(IdRequest request)
        {
            var detail = Order_DetailFunc.Instance.SelectById(request.Id);
            if (detail != null)
            {
                var production = ProductionFunc.Instance.SelectByModel(new Production { order_detailId = detail.Id }).FirstOrDefault();
                if (production == null)
                {
                    return new ResultJson { HttpCode = 300, Message = "并无对应订单" };
                }
                detail.UserSure = true;
                if (Order_DetailFunc.Instance.Update(detail))
                {
                    production.ProductionStatus = "待生产确认";
                    production.DesignerStatus = "设计已完成";
                    if (ProductionFunc.Instance.Update(production))
                    {
                        return new ResultJson { HttpCode = 200, Message = "提交成功" };
                    }
                    else
                    {
                        detail.UserSure = false;
                        Order_DetailFunc.Instance.Update(detail);
                        return new ResultJson { HttpCode = 300, Message = "更新订单失败，请再次尝试" };
                    }
                }
                else
                {
                    return new ResultJson { HttpCode = 300, Message = "更新订单失败，请再次尝试" };
                }
            }
            else
            {
                return new ResultJson { HttpCode = 200, Message = "订单明细不存在成功" };
            }
        }

        #region 保存图片
        /// <summary>
        /// 文件路径
        /// </summary>
        string FileUrl = System.Configuration.ConfigurationManager.AppSettings["FileUrl"];
        /// <summary>
        /// 根据base64编码保存图片
        /// </summary>
        /// <param name="Pic">base64编码图片</param>
        /// <param name="DicUrl">文件目录</param>
        /// <returns></returns>
        private string SaveImg(string Pic, string DicUrl)
        {
            try
            {
                if (Pic == null)
                {
                    return null;
                }
                var arrayImg = Pic.Split(',');
                string extension = null;
                extension = arrayImg[0].Split(':')[1].Split('/')[1].Split(';')[0];
                if (extension != null)
                {
                    string DicFullUrl = FileUrl + DicUrl;
                    if (FileHelper.Instance.checkDir(DicFullUrl))
                    {
                        string AllUrl = DicUrl + "/" + RandHelper.Instance.Str(6) + DateTime.Now.ToString("yyyyMMddHHmmss") + "." + extension;
                        string AllFullUrl = FileUrl + AllUrl;
                        ImageUploadHelper.Instance.SaveImg(arrayImg[1], AllFullUrl);
                        return AllUrl;
                    }
                }
            }
            catch (Exception)
            {
                return null;
            }
            return null;
        }
        #endregion
    }
}

