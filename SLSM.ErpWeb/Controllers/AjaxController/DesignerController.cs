using Common.Extend;
using Common.Filter.WebApi;
using Common.Helper;
using Common.Result;
using DbOpertion.Function;
using DbOpertion.Models;
using SLSM.DBOpertion.Function;
using SLSM.ErpWeb.Model.Request.Designer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace SLSM.ErpWeb.Controllers.AjaxController
{
    /// <summary>
    /// 设计师管理,生产管理,订单管理
    /// </summary>
    public class DesignerController : BaseApiController
    {
        #region 退回操作
        /// <summary>
        /// 退回设计,退回客服
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ResultJson ReturnService(DesignerRequest request)
        {
            var result = false;
            var Productions = ProductionFunc.Instance.SelectViewById(request.Id);
            //生产状态
            var ProductionStatus = Productions.ProductionStatus;
            //设计师状态
            var DesignerStatus = Productions.DesignerStatus;
            //订单状态
            var OrderStatus = Productions.OrderStatus;
            //退回次数
            var ReturnCount = Productions.ReturnCount;

            #region 生产管理,待生产退回,(生产退回客服)
            if (ProductionStatus == "待生产")
            {
                result = ProductionFunc.Instance.Update(new DbOpertion.Models.Production { Id = request.Id, ReturnContext = request.Context, ProductionStatus = "待处理", ReturnCount = 2, OrderStatus = "生产退回待处理" });
            }
            #endregion 

            #region 生产管理,待生产确认,二次修改待确认,(退回设计)
            else if (ProductionStatus == "待生产确认")
            {
                result = ProductionFunc.Instance.Update(new DbOpertion.Models.Production { Id = request.Id, ReturnContext = request.Context, ProductionStatus = "待处理", DesignerStatus = "生产退回待处理", ReturnCount = 1, deliveryTime = null });
            }
            #endregion

            #region 生产管理,待生产确认,二次修改待确认,(退回客服)
            else if (ProductionStatus == "待生产确认" && ReturnCount == 1)
            {
                result = ProductionFunc.Instance.Update(new DbOpertion.Models.Production { Id = request.Id, ReturnContext = request.Context, ProductionStatus = "待处理", OrderStatus = "生产退回待处理", ReturnCount = 2 });
            }
            #endregion

            #region 设计师管理,设计未处理,(设计退回客服)
            else if (DesignerStatus == "设计未处理")
            {
                result = ProductionFunc.Instance.Update(new DbOpertion.Models.Production { Id = request.Id, ReturnContext = request.Context, OrderStatus = "设计退回待处理", DesignerStatus = "待处理" });
            }
            #endregion  

            #region 设计师管理,生产退回待处理,(退回客服)
            else if (DesignerStatus == "生产退回待处理" && ReturnCount == 1)
            {
                result = ProductionFunc.Instance.Update(new DbOpertion.Models.Production { Id = request.Id, ReturnContext = request.Context, OrderStatus = "设计退回待处理", ReturnCount = 2 });
            }
            #endregion

            #region 订单管理,生产退回待处理 (取消订单)
            else if (OrderStatus == "生产退回待处理" && ReturnCount == 2)
            {
                result = ProductionFunc.Instance.Update(new DbOpertion.Models.Production { Id = request.Id, OrderStatus = "已取消订单" });
            }
            #endregion 

            if (result)
            {
                return new ResultJson { HttpCode = 200, Message = "成功!" };
            }
            else
            {
                return new ResultJson { HttpCode = 300, Message = "操作失败!请重试!" };
            }
        }
        #endregion

        #region 提交生产操作
        /// <summary>
        /// 生产操作
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public ResultJson StartProduction(DesignerRequest request)
        {
            #region 用户信息
            var userGuid = CookieOper.Instance.GetUserGuid();
            var user = MemCacheHelper2.Instance.Cache.GetModel<Erploginuer>("ErpUserGuID_" + userGuid);
            #endregion

            var result = false;
            var Productions = ProductionFunc.Instance.SelectViewById(request.Id);
            //生产状态
            var ProductionStatus = Productions.ProductionStatus;
            //设计师状态
            var DesignerStatus = Productions.DesignerStatus;
            //订单状态
            var OrderStatus = Productions.OrderStatus;
            //退回次数
            var ReturnCount = Productions.ReturnCount;

            #region 生产管理,待生产确认(待生产)
            if (ProductionStatus == "待生产确认")
            {
                result = ProductionFunc.Instance.Update(new DbOpertion.Models.Production { Id = request.Id, ProductionStatus = "待生产", PrintParm = request.PrintParm, PrintInfo = request.printTech });
            }
            #endregion

            #region 订单管理,设计退回待处理
            else if (OrderStatus == "设计退回待处理")
            {
                result = ProductionFunc.Instance.Update(new Production { Id = request.Id, OrderStatus = "待处理", ProductionStatus = "待处理", DesignerStatus = "设计未处理", ServiceContext = request.Context, KefuPerson = user.erpLoginName });
            }
            #endregion   

            #region 生产退回待处理
            else if (DesignerStatus == "生产退回待处理")
            {
                result = ProductionFunc.Instance.Update(new DbOpertion.Models.Production { Id = request.Id, OrderStatus = "设计已处理", ProductionStatus = "待生产确认", DesignerStatus = "待处理", ServiceContext = request.Context });
            }
            #endregion

            #region 生产管理,待生产(提交生产)
            else if (ProductionStatus == "待生产")
            {
                if (DistributionFunc.Instance.SelectCount(new DbOpertion.Models.Distribution { ProductionId = request.Id }) == 0 || ReceiveFunc.Instance.SelectCount(new DbOpertion.Models.Receive { ProductionId = request.Id, receiveStatus = "已出库" }) == 0)
                {
                    return new ResultJson { HttpCode = 300, Message = "请先填写生产计划和分配表或者领料单未出库!" };
                }
                else
                {
                    result = ProductionFunc.Instance.Update(new DbOpertion.Models.Production { Id = request.Id, ProductionStatus = "生产中" });
                }
            }
            #endregion

            #region 生产管理,生产中(生产完成)
            else if (ProductionStatus == "生产中")
            {
                result = ProductionFunc.Instance.Update(new DbOpertion.Models.Production { Id = request.Id, ProductionStatus = "生产已完成", OrderStatus = "生产完成待品检", InspectionStatus = "生产完成待品检" });
            }
            #endregion 

            #region 设计师管理,设计未处理(设计已处理)
            else if (DesignerStatus == "设计未处理" || (OrderStatus == "设计退回待处理" && ReturnCount == 1))
            {
                if (Productions.DesignerZip.IsNullOrEmpty())
                {
                    return new ResultJson { HttpCode = 300, Message = "请先上传设计师文件！" };
                }
                result = ProductionFunc.Instance.Update(new Production { Id = request.Id, DesignerStatus = "待客户确认", ProductionStatus = "待处理", OrderStatus = "待处理", InspectionContext = request.InspectionContext, DesigerPerson = user.erpLoginName });
                Order_DetailFunc.Instance.Update(new Order_Detail { Id = Productions.order_detailId.Value, DesignCommit = true });
            }
            #endregion 

            #region 订单管理,生产退回待处理(再次提交生产)(交货时间)
            else if (OrderStatus == "生产退回待处理")
            {
                result = ProductionFunc.Instance.Update(new Production { Id = request.Id, OrderStatus = "设计已处理", ProductionStatus = "待生产确认", ServiceContext = request.Context, KefuPerson = user.erpLoginName });
            }

            #endregion

            if (result)
            {
                return new ResultJson { HttpCode = 200, Message = "成功!" };
            }
            else
            {
                return new ResultJson { HttpCode = 300, Message = "操作失败!请重试!" };
            }
        }
        #endregion

        #region 保存操作
        /// <summary>
        /// 设计师管理,生产退回待处理,订单管理,生产退回待处理(保存)
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public ResultJson KeepProduction(DesignerRequest request)
        {
            if (ProductionFunc.Instance.Update(new DbOpertion.Models.Production { Id = request.Id, InspectionContext = request.InspectionContext }))
            {
                return new ResultJson { HttpCode = 200, Message = "成功!" };
            }
            else
            {
                return new ResultJson { HttpCode = 300, Message = "操作失败!请重试!" };
            }
        }
        #endregion

        #region 生成领料单
        /// <summary>
        /// 生成领料单
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public ResultJson GetProduction(DesignerRequest request)
        {
            if (ProductionFunc.Instance.Update(new DbOpertion.Models.Production { Id = request.Id }))
            {
                return new ResultJson { HttpCode = 200, Message = "成功!" };
            }
            else
            {
                return new ResultJson { HttpCode = 300, Message = "请重试!" };
            }
        }
        #endregion

        #region 生产计划和分配表保存
        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public ResultJson GetDistribution(DistributionRequest request)
        {
            if (DistributionFunc.Instance.AddDistribution(request.ProductionId, request.ProductionPerson, request.ProInfo))
            {
                return new ResultJson { HttpCode = 200, Message = "成功" };
            }
            else
            {
                return new ResultJson { HttpCode = 300, Message = "失败,请重试!" };
            }
        }
        #endregion

        #region 设计师上传文件

        /// <summary>
        /// 管理员路径
        /// </summary>
        string AdminUrl = System.Configuration.ConfigurationManager.AppSettings["AdminUrl"];
        /// <summary>
        /// 后台路径
        /// </summary>
        string FileUrl = System.Configuration.ConfigurationManager.AppSettings["FileUrl"];
        [HttpPost]
        public ResultJson DesignUpLoadFile(DesignerUpLoadRequest request)
        {
            #region 文件基础处理和转移
            if ((request.PositionName1 != null && request.Position1 == null) || (request.PositionName2 != null && request.Position2 == null) || (request.PositionName3 != null && request.Position3 == null))
            {
                return new ResultJson { HttpCode = 300, Message = "所有展示位都需要对应的图片" };
            }
            if (request.UpFileAddr == null || request.UpFileAddr == "")
            {
                return new ResultJson { HttpCode = 300, Message = "请上传设计文件" };
            }
            var ImageList = "";
            var positionList = request.Position1 == null ? new List<string>() : request.Position1.Split('|').Where(p => !string.IsNullOrEmpty(p)).ToList();
            foreach (var item in positionList)
            {
                var arrayItem = item.Split(',').Where(p => !string.IsNullOrEmpty(p)).ToList(); ;
                if (arrayItem.Count == 2)
                {
                    if (arrayItem[1].Contains("temp"))
                    {
                        FileHelper.Instance.Move(FileUrl + arrayItem[1], FileUrl + $"/current/Image/Desingn/" + arrayItem[1].Split('/').Last(), FileUrl + $"/current/Image/Desingn/");
                        ImageList = ImageList + $"{arrayItem[0]},/current/Image/Desingn/{arrayItem[1].Split('/').Last()}|";
                    }
                    else
                    {
                        ImageList = ImageList + $"{item}|";
                    }
                }

            }
            #region 注释代码
            //if (request.Position1 != null && request.Position1.Contains("temp"))
            //{
            //    FileHelper.Instance.Move(FileUrl + request.Position1, FileUrl + $"/current/Image/Desingn/" + request.Position1.Split('/').Last(), FileUrl + $"/current/Image/Desingn/");
            //    request.Position1 = $"/current/Image/Desingn/{request.Position1.Split('/').Last()}";
            //}
            //if (request.PositionName1 != null && request.Position1 != null)
            //{
            //    ImageList = $"{ImageList}{request.PositionName1},{request.Position1}|";
            //}
            //if (request.Position2 != null && request.Position2.Contains("temp"))
            //{
            //    FileHelper.Instance.Move(FileUrl + request.Position2, FileUrl + $"/current/Image/Desingn/" + request.Position2.Split('/').Last(), FileUrl + $"/current/Image/Desingn/");
            //    request.Position2 = $"/current/Image/Desingn/{request.Position2.Split('/').Last()}";
            //}
            //if (request.PositionName2 != null && request.Position2 != null)
            //{
            //    ImageList = $"{ImageList}{request.PositionName2},{request.Position2}|";
            //}
            //if (request.Position3 != null && request.Position3.Contains("temp"))
            //{
            //    FileHelper.Instance.Move(FileUrl + request.Position3, FileUrl + $"/current/Image/Desingn/" + request.Position3.Split('/').Last(), FileUrl + $"/current/Image/Desingn/");
            //    request.Position3 = $"/current/Image/Desingn/{request.Position3.Split('/').Last()}";
            //}
            //if (request.PositionName3 != null && request.Position3 != null)
            //{
            //    ImageList = $"{ImageList}{request.PositionName3},{request.Position3};";
            //} 
            #endregion

            if (request.UpFileAddr.Contains("temp"))
            {
                var UpFileAddrList = request.UpFileAddr.Split('|').Where(p => !string.IsNullOrEmpty(p)).ToList();
                var UpFileAddr = "";
                foreach (var item in UpFileAddrList)
                {
                    if (item.Contains("temp"))
                    {
                        FileHelper.Instance.Move(FileUrl + item, FileUrl + $"/current/UpLoad/Desingn/" + item.Split('/').Last(), FileUrl + $"/current/UpLoad/Desingn/");
                        UpFileAddr = UpFileAddr + $"/current/UpLoad/Desingn/{item.Split('/').Last()}|";
                    }
                    else
                    {
                        UpFileAddr = UpFileAddr + $"{item}|";
                    }

                }
                request.UpFileAddr = UpFileAddr;
            }
            #endregion

            #region 更新操作
            var prodution = Production_Orderdetail_ViewFunc.Instance.SelectByModel(new DbOpertion.Models.Production_Orderdetail_View { Id = request.ProductionId }).FirstOrDefault();
            if (ProductionFunc.Instance.Update(new DbOpertion.Models.Production { Id = request.ProductionId, DesignerZip = request.UpFileAddr }))
            {
                if (Order_DetailFunc.Instance.Update(new DbOpertion.Models.Order_Detail { Id = prodution.order_detailId.Value, DesignerImage = ImageList }))
                {
                    return new ResultJson { HttpCode = 200, Message = "修改成功" };
                }
                else
                {
                    return new ResultJson { HttpCode = 200, Message = "订单详情修改失败" };
                }
            }
            else
            {
                return new ResultJson { HttpCode = 300, Message = "生成管理修改失败" };
            }
            #endregion
        }
        #endregion
    }
}

