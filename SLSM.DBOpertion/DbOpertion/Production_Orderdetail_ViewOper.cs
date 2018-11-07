using Common;
using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common.LambdaOpertion;
using Common.Extend;
using System.Data;
using Common.Extend.LambdaFunction;
using DbOpertion.Models;

namespace DbOpertion.Operation
{
    public partial class Production_Orderdetail_ViewOper : SingleTon<Production_Orderdetail_ViewOper>
    {
        /// <summary>
        /// 筛选全部数据
        /// </summary>
        /// <param name="model">模型</param>
        /// <param name="connection">连接</param>
        /// <param name="transaction">事务</param>
        /// <returns>对象列表</returns>
        public List<Production_Orderdetail_View> SelectAll(Production_Orderdetail_View model = null, string SelectFiled = null, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var query = new LambdaQuery<Production_Orderdetail_View>();
            if (model != null)
            {
                if (!model.Id.IsNullOrEmpty())
                {
                    query.Where(p => p.Id == model.Id);
                }
                if (!model.OrderNo.IsNullOrEmpty())
                {
                    query.Where(p => p.OrderNo == model.OrderNo);
                }
                if (!model.OrderTime.IsNullOrEmpty())
                {
                    query.Where(p => p.OrderTime == model.OrderTime);
                }
                if (!model.DesignerStatus.IsNullOrEmpty())
                {
                    query.Where(p => p.DesignerStatus == model.DesignerStatus);
                }
                if (!model.ProductionStatus.IsNullOrEmpty())
                {
                    query.Where(p => p.ProductionStatus == model.ProductionStatus);
                }
                if (!model.OrderStatus.IsNullOrEmpty())
                {
                    query.Where(p => p.OrderStatus == model.OrderStatus);
                }
                if (!model.OrderType.IsNullOrEmpty())
                {
                    query.Where(p => p.OrderType == model.OrderType);
                }
                if (!model.InspectionStatus.IsNullOrEmpty())
                {
                    query.Where(p => p.InspectionStatus == model.InspectionStatus);
                }
                if (!model.ReturnCount.IsNullOrEmpty())
                {
                    query.Where(p => p.ReturnCount == model.ReturnCount);
                }
                if (!model.ReturnContext.IsNullOrEmpty())
                {
                    query.Where(p => p.ReturnContext == model.ReturnContext);
                }
                if (!model.ServiceContext.IsNullOrEmpty())
                {
                    query.Where(p => p.ServiceContext == model.ServiceContext);
                }
                if (!model.DesignerZip.IsNullOrEmpty())
                {
                    query.Where(p => p.DesignerZip == model.DesignerZip);
                }
                if (!model.ProductionZip.IsNullOrEmpty())
                {
                    query.Where(p => p.ProductionZip == model.ProductionZip);
                }
                if (!model.order_detailId.IsNullOrEmpty())
                {
                    query.Where(p => p.order_detailId == model.order_detailId);
                }
                if (!model.ExpressCompany.IsNullOrEmpty())
                {
                    query.Where(p => p.ExpressCompany == model.ExpressCompany);
                }
                if (!model.ExpressWeight.IsNullOrEmpty())
                {
                    query.Where(p => p.ExpressWeight == model.ExpressWeight);
                }
                if (!model.ExpressContext.IsNullOrEmpty())
                {
                    query.Where(p => p.ExpressContext == model.ExpressContext);
                }
                if (!model.ExpressNo.IsNullOrEmpty())
                {
                    query.Where(p => p.ExpressNo == model.ExpressNo);
                }
                if (!model.QCINSPECTOR.IsNullOrEmpty())
                {
                    query.Where(p => p.QCINSPECTOR == model.QCINSPECTOR);
                }
                if (!model.INSPECTIONDATE.IsNullOrEmpty())
                {
                    query.Where(p => p.INSPECTIONDATE == model.INSPECTIONDATE);
                }
                if (!model.BadInfo.IsNullOrEmpty())
                {
                    query.Where(p => p.BadInfo == model.BadInfo);
                }
                if (!model.ProductImageInfo.IsNullOrEmpty())
                {
                    query.Where(p => p.ProductImageInfo == model.ProductImageInfo);
                }
                if (!model.TestResults.IsNullOrEmpty())
                {
                    query.Where(p => p.TestResults == model.TestResults);
                }
                if (!model.userName.IsNullOrEmpty())
                {
                    query.Where(p => p.userName == model.userName);
                }
                if (!model.Phone.IsNullOrEmpty())
                {
                    query.Where(p => p.Phone == model.Phone);
                }
                if (!model.CompanyAddr.IsNullOrEmpty())
                {
                    query.Where(p => p.CompanyAddr == model.CompanyAddr);
                }
                if (!model.CompanyName.IsNullOrEmpty())
                {
                    query.Where(p => p.CompanyName == model.CompanyName);
                }
                if (!model.MaterialId.IsNullOrEmpty())
                {
                    query.Where(p => p.MaterialId == model.MaterialId);
                }
                if (!model.commodityName.IsNullOrEmpty())
                {
                    query.Where(p => p.commodityName == model.commodityName);
                }
                if (!model.commodityId.IsNullOrEmpty())
                {
                    query.Where(p => p.commodityId == model.commodityId);
                }
                if (!model.ImageInfoList.IsNullOrEmpty())
                {
                    query.Where(p => p.ImageInfoList == model.ImageInfoList);
                }
                if (!model.Amount.IsNullOrEmpty())
                {
                    query.Where(p => p.Amount == model.Amount);
                }
                if (!model.PayMoney.IsNullOrEmpty())
                {
                    query.Where(p => p.PayMoney == model.PayMoney);
                }
                if (!model.ImageList.IsNullOrEmpty())
                {
                    query.Where(p => p.ImageList == model.ImageList);
                }
                if (!model.WordOpertion.IsNullOrEmpty())
                {
                    query.Where(p => p.WordOpertion == model.WordOpertion);
                }
                if (!model.OnLineImageOpertion.IsNullOrEmpty())
                {
                    query.Where(p => p.OnLineImageOpertion == model.OnLineImageOpertion);
                }
                if (!model.CustomImageOpertion.IsNullOrEmpty())
                {
                    query.Where(p => p.CustomImageOpertion == model.CustomImageOpertion);
                }
                if (!model.DesignerImage.IsNullOrEmpty())
                {
                    query.Where(p => p.DesignerImage == model.DesignerImage);
                }
                if (!model.OrderId.IsNullOrEmpty())
                {
                    query.Where(p => p.OrderId == model.OrderId);
                }
                if (!model.Color.IsNullOrEmpty())
                {
                    query.Where(p => p.Color == model.Color);
                }
                if (!model.ColorId.IsNullOrEmpty())
                {
                    query.Where(p => p.ColorId == model.ColorId);
                }
                if (!model.deliveryTime.IsNullOrEmpty())
                {
                    query.Where(p => p.deliveryTime == model.deliveryTime);
                }
                if (!model.InspectionContext.IsNullOrEmpty())
                {
                    query.Where(p => p.InspectionContext == model.InspectionContext);
                }
                if (!model.ProductNo.IsNullOrEmpty())
                {
                    query.Where(p => p.ProductNo == model.ProductNo);
                }
                if (!model.ChinaProductName.IsNullOrEmpty())
                {
                    query.Where(p => p.ChinaProductName == model.ChinaProductName);
                }
                if (!model.ChinaUnit.IsNullOrEmpty())
                {
                    query.Where(p => p.ChinaUnit == model.ChinaUnit);
                }
                if (!model.Specification.IsNullOrEmpty())
                {
                    query.Where(p => p.Specification == model.Specification);
                }
                if (!model.PositionInfo.IsNullOrEmpty())
                {
                    query.Where(p => p.PositionInfo == model.PositionInfo);
                }
                if (!model.SKU.IsNullOrEmpty())
                {
                    query.Where(p => p.SKU == model.SKU);
                }
                if (!model.BuyName.IsNullOrEmpty())
                {
                    query.Where(p => p.BuyName == model.BuyName);
                }
                if (!model.Address.IsNullOrEmpty())
                {
                    query.Where(p => p.Address == model.Address);
                }
                if (!model.userphone.IsNullOrEmpty())
                {
                    query.Where(p => p.userphone == model.userphone);
                }
                if (!model.PrintFuncInfo.IsNullOrEmpty())
                {
                    query.Where(p => p.PrintFuncInfo == model.PrintFuncInfo);
                }
                if (!model.PrintingMethod.IsNullOrEmpty())
                {
                    query.Where(p => p.PrintingMethod == model.PrintingMethod);
                }
                if (!model.DesigerPerson.IsNullOrEmpty())
                {
                    query.Where(p => p.DesigerPerson == model.DesigerPerson);
                }
                if (!model.SalePerson.IsNullOrEmpty())
                {
                    query.Where(p => p.SalePerson == model.SalePerson);
                }
                if (!model.KefuPerson.IsNullOrEmpty())
                {
                    query.Where(p => p.KefuPerson == model.KefuPerson);
                }
                if (!model.PrintInfo.IsNullOrEmpty())
                {
                    query.Where(p => p.PrintInfo == model.PrintInfo);
                }
                if (!model.PrintParm.IsNullOrEmpty())
                {
                    query.Where(p => p.PrintParm == model.PrintParm);
                }
                if (!model.Printingdetail.IsNullOrEmpty())
                {
                    query.Where(p => p.Printingdetail == model.Printingdetail);
                }
            }
            if (SelectFiled != null)
            {
                SelectFiled = SelectFiled.ToLowerInvariant();
                if (SelectFiled.Contains("id,"))
                {
                    query.Select(p => new { p.Id });
                }
                if (SelectFiled.Contains("orderno,"))
                {
                    query.Select(p => new { p.OrderNo });
                }
                if (SelectFiled.Contains("ordertime,"))
                {
                    query.Select(p => new { p.OrderTime });
                }
                if (SelectFiled.Contains("designerstatus,"))
                {
                    query.Select(p => new { p.DesignerStatus });
                }
                if (SelectFiled.Contains("productionstatus,"))
                {
                    query.Select(p => new { p.ProductionStatus });
                }
                if (SelectFiled.Contains("orderstatus,"))
                {
                    query.Select(p => new { p.OrderStatus });
                }
                if (SelectFiled.Contains("ordertype,"))
                {
                    query.Select(p => new { p.OrderType });
                }
                if (SelectFiled.Contains("inspectionstatus,"))
                {
                    query.Select(p => new { p.InspectionStatus });
                }
                if (SelectFiled.Contains("returncount,"))
                {
                    query.Select(p => new { p.ReturnCount });
                }
                if (SelectFiled.Contains("returncontext,"))
                {
                    query.Select(p => new { p.ReturnContext });
                }
                if (SelectFiled.Contains("servicecontext,"))
                {
                    query.Select(p => new { p.ServiceContext });
                }
                if (SelectFiled.Contains("designerzip,"))
                {
                    query.Select(p => new { p.DesignerZip });
                }
                if (SelectFiled.Contains("productionzip,"))
                {
                    query.Select(p => new { p.ProductionZip });
                }
                if (SelectFiled.Contains("order_detailid,"))
                {
                    query.Select(p => new { p.order_detailId });
                }
                if (SelectFiled.Contains("expresscompany,"))
                {
                    query.Select(p => new { p.ExpressCompany });
                }
                if (SelectFiled.Contains("expressweight,"))
                {
                    query.Select(p => new { p.ExpressWeight });
                }
                if (SelectFiled.Contains("expresscontext,"))
                {
                    query.Select(p => new { p.ExpressContext });
                }
                if (SelectFiled.Contains("expressno,"))
                {
                    query.Select(p => new { p.ExpressNo });
                }
                if (SelectFiled.Contains("qcinspector,"))
                {
                    query.Select(p => new { p.QCINSPECTOR });
                }
                if (SelectFiled.Contains("inspectiondate,"))
                {
                    query.Select(p => new { p.INSPECTIONDATE });
                }
                if (SelectFiled.Contains("badinfo,"))
                {
                    query.Select(p => new { p.BadInfo });
                }
                if (SelectFiled.Contains("productimageinfo,"))
                {
                    query.Select(p => new { p.ProductImageInfo });
                }
                if (SelectFiled.Contains("testresults,"))
                {
                    query.Select(p => new { p.TestResults });
                }
                if (SelectFiled.Contains("username,"))
                {
                    query.Select(p => new { p.userName });
                }
                if (SelectFiled.Contains("phone,"))
                {
                    query.Select(p => new { p.Phone });
                }
                if (SelectFiled.Contains("companyaddr,"))
                {
                    query.Select(p => new { p.CompanyAddr });
                }
                if (SelectFiled.Contains("companyname,"))
                {
                    query.Select(p => new { p.CompanyName });
                }
                if (SelectFiled.Contains("materialid,"))
                {
                    query.Select(p => new { p.MaterialId });
                }
                if (SelectFiled.Contains("commodityname,"))
                {
                    query.Select(p => new { p.commodityName });
                }
                if (SelectFiled.Contains("commodityid,"))
                {
                    query.Select(p => new { p.commodityId });
                }
                if (SelectFiled.Contains("imageinfolist,"))
                {
                    query.Select(p => new { p.ImageInfoList });
                }
                if (SelectFiled.Contains("amount,"))
                {
                    query.Select(p => new { p.Amount });
                }
                if (SelectFiled.Contains("paymoney,"))
                {
                    query.Select(p => new { p.PayMoney });
                }
                if (SelectFiled.Contains("imagelist,"))
                {
                    query.Select(p => new { p.ImageList });
                }
                if (SelectFiled.Contains("wordopertion,"))
                {
                    query.Select(p => new { p.WordOpertion });
                }
                if (SelectFiled.Contains("onlineimageopertion,"))
                {
                    query.Select(p => new { p.OnLineImageOpertion });
                }
                if (SelectFiled.Contains("customimageopertion,"))
                {
                    query.Select(p => new { p.CustomImageOpertion });
                }
                if (SelectFiled.Contains("designerimage,"))
                {
                    query.Select(p => new { p.DesignerImage });
                }
                if (SelectFiled.Contains("orderid,"))
                {
                    query.Select(p => new { p.OrderId });
                }
                if (SelectFiled.Contains("color,"))
                {
                    query.Select(p => new { p.Color });
                }
                if (SelectFiled.Contains("colorid,"))
                {
                    query.Select(p => new { p.ColorId });
                }
                if (SelectFiled.Contains("deliverytime,"))
                {
                    query.Select(p => new { p.deliveryTime });
                }
                if (SelectFiled.Contains("inspectioncontext,"))
                {
                    query.Select(p => new { p.InspectionContext });
                }
                if (SelectFiled.Contains("productno,"))
                {
                    query.Select(p => new { p.ProductNo });
                }
                if (SelectFiled.Contains("chinaproductname,"))
                {
                    query.Select(p => new { p.ChinaProductName });
                }
                if (SelectFiled.Contains("chinaunit,"))
                {
                    query.Select(p => new { p.ChinaUnit });
                }
                if (SelectFiled.Contains("specification,"))
                {
                    query.Select(p => new { p.Specification });
                }
                if (SelectFiled.Contains("positioninfo,"))
                {
                    query.Select(p => new { p.PositionInfo });
                }
                if (SelectFiled.Contains("sku,"))
                {
                    query.Select(p => new { p.SKU });
                }
                if (SelectFiled.Contains("buyname,"))
                {
                    query.Select(p => new { p.BuyName });
                }
                if (SelectFiled.Contains("address,"))
                {
                    query.Select(p => new { p.Address });
                }
                if (SelectFiled.Contains("userphone,"))
                {
                    query.Select(p => new { p.userphone });
                }
                if (SelectFiled.Contains("printfuncinfo,"))
                {
                    query.Select(p => new { p.PrintFuncInfo });
                }
                if (SelectFiled.Contains("printingmethod,"))
                {
                    query.Select(p => new { p.PrintingMethod });
                }
                if (SelectFiled.Contains("desigerperson,"))
                {
                    query.Select(p => new { p.DesigerPerson });
                }
                if (SelectFiled.Contains("saleperson,"))
                {
                    query.Select(p => new { p.SalePerson });
                }
                if (SelectFiled.Contains("kefuperson,"))
                {
                    query.Select(p => new { p.KefuPerson });
                }
                if (SelectFiled.Contains("printinfo,"))
                {
                    query.Select(p => new { p.PrintInfo });
                }
                if (SelectFiled.Contains("printparm,"))
                {
                    query.Select(p => new { p.PrintParm });
                }
                if (SelectFiled.Contains("printingdetail,"))
                {
                    query.Select(p => new { p.Printingdetail });
                }
            }
            return query.GetQueryList(connection, transaction);
        }

        /// <summary>
        /// 数据条数
        /// </summary>
        /// <param name="model">模型</param>
        /// <param name="connection">连接</param>
        /// <param name="transaction">事务</param>
        /// <returns>对象列表</returns>
        public int SelectCount(Production_Orderdetail_View model = null, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var query = new LambdaQuery<Production_Orderdetail_View>();
            if (model != null)
            {
                if (!model.Id.IsNullOrEmpty())
                {
                    query.Where(p => p.Id == model.Id);
                }
                if (!model.OrderNo.IsNullOrEmpty())
                {
                    query.Where(p => p.OrderNo == model.OrderNo);
                }
                if (!model.OrderTime.IsNullOrEmpty())
                {
                    query.Where(p => p.OrderTime == model.OrderTime);
                }
                if (!model.DesignerStatus.IsNullOrEmpty())
                {
                    query.Where(p => p.DesignerStatus == model.DesignerStatus);
                }
                if (!model.ProductionStatus.IsNullOrEmpty())
                {
                    query.Where(p => p.ProductionStatus == model.ProductionStatus);
                }
                if (!model.OrderStatus.IsNullOrEmpty())
                {
                    query.Where(p => p.OrderStatus == model.OrderStatus);
                }
                if (!model.OrderType.IsNullOrEmpty())
                {
                    query.Where(p => p.OrderType == model.OrderType);
                }
                if (!model.InspectionStatus.IsNullOrEmpty())
                {
                    query.Where(p => p.InspectionStatus == model.InspectionStatus);
                }
                if (!model.ReturnCount.IsNullOrEmpty())
                {
                    query.Where(p => p.ReturnCount == model.ReturnCount);
                }
                if (!model.ReturnContext.IsNullOrEmpty())
                {
                    query.Where(p => p.ReturnContext == model.ReturnContext);
                }
                if (!model.ServiceContext.IsNullOrEmpty())
                {
                    query.Where(p => p.ServiceContext == model.ServiceContext);
                }
                if (!model.DesignerZip.IsNullOrEmpty())
                {
                    query.Where(p => p.DesignerZip == model.DesignerZip);
                }
                if (!model.ProductionZip.IsNullOrEmpty())
                {
                    query.Where(p => p.ProductionZip == model.ProductionZip);
                }
                if (!model.order_detailId.IsNullOrEmpty())
                {
                    query.Where(p => p.order_detailId == model.order_detailId);
                }
                if (!model.ExpressCompany.IsNullOrEmpty())
                {
                    query.Where(p => p.ExpressCompany == model.ExpressCompany);
                }
                if (!model.ExpressWeight.IsNullOrEmpty())
                {
                    query.Where(p => p.ExpressWeight == model.ExpressWeight);
                }
                if (!model.ExpressContext.IsNullOrEmpty())
                {
                    query.Where(p => p.ExpressContext == model.ExpressContext);
                }
                if (!model.ExpressNo.IsNullOrEmpty())
                {
                    query.Where(p => p.ExpressNo == model.ExpressNo);
                }
                if (!model.QCINSPECTOR.IsNullOrEmpty())
                {
                    query.Where(p => p.QCINSPECTOR == model.QCINSPECTOR);
                }
                if (!model.INSPECTIONDATE.IsNullOrEmpty())
                {
                    query.Where(p => p.INSPECTIONDATE == model.INSPECTIONDATE);
                }
                if (!model.BadInfo.IsNullOrEmpty())
                {
                    query.Where(p => p.BadInfo == model.BadInfo);
                }
                if (!model.ProductImageInfo.IsNullOrEmpty())
                {
                    query.Where(p => p.ProductImageInfo == model.ProductImageInfo);
                }
                if (!model.TestResults.IsNullOrEmpty())
                {
                    query.Where(p => p.TestResults == model.TestResults);
                }
                if (!model.userName.IsNullOrEmpty())
                {
                    query.Where(p => p.userName == model.userName);
                }
                if (!model.Phone.IsNullOrEmpty())
                {
                    query.Where(p => p.Phone == model.Phone);
                }
                if (!model.CompanyAddr.IsNullOrEmpty())
                {
                    query.Where(p => p.CompanyAddr == model.CompanyAddr);
                }
                if (!model.CompanyName.IsNullOrEmpty())
                {
                    query.Where(p => p.CompanyName == model.CompanyName);
                }
                if (!model.MaterialId.IsNullOrEmpty())
                {
                    query.Where(p => p.MaterialId == model.MaterialId);
                }
                if (!model.commodityName.IsNullOrEmpty())
                {
                    query.Where(p => p.commodityName == model.commodityName);
                }
                if (!model.commodityId.IsNullOrEmpty())
                {
                    query.Where(p => p.commodityId == model.commodityId);
                }
                if (!model.ImageInfoList.IsNullOrEmpty())
                {
                    query.Where(p => p.ImageInfoList == model.ImageInfoList);
                }
                if (!model.Amount.IsNullOrEmpty())
                {
                    query.Where(p => p.Amount == model.Amount);
                }
                if (!model.PayMoney.IsNullOrEmpty())
                {
                    query.Where(p => p.PayMoney == model.PayMoney);
                }
                if (!model.ImageList.IsNullOrEmpty())
                {
                    query.Where(p => p.ImageList == model.ImageList);
                }
                if (!model.WordOpertion.IsNullOrEmpty())
                {
                    query.Where(p => p.WordOpertion == model.WordOpertion);
                }
                if (!model.OnLineImageOpertion.IsNullOrEmpty())
                {
                    query.Where(p => p.OnLineImageOpertion == model.OnLineImageOpertion);
                }
                if (!model.CustomImageOpertion.IsNullOrEmpty())
                {
                    query.Where(p => p.CustomImageOpertion == model.CustomImageOpertion);
                }
                if (!model.DesignerImage.IsNullOrEmpty())
                {
                    query.Where(p => p.DesignerImage == model.DesignerImage);
                }
                if (!model.OrderId.IsNullOrEmpty())
                {
                    query.Where(p => p.OrderId == model.OrderId);
                }
                if (!model.Color.IsNullOrEmpty())
                {
                    query.Where(p => p.Color == model.Color);
                }
                if (!model.ColorId.IsNullOrEmpty())
                {
                    query.Where(p => p.ColorId == model.ColorId);
                }
                if (!model.deliveryTime.IsNullOrEmpty())
                {
                    query.Where(p => p.deliveryTime == model.deliveryTime);
                }
                if (!model.InspectionContext.IsNullOrEmpty())
                {
                    query.Where(p => p.InspectionContext == model.InspectionContext);
                }
                if (!model.ProductNo.IsNullOrEmpty())
                {
                    query.Where(p => p.ProductNo == model.ProductNo);
                }
                if (!model.ChinaProductName.IsNullOrEmpty())
                {
                    query.Where(p => p.ChinaProductName == model.ChinaProductName);
                }
                if (!model.ChinaUnit.IsNullOrEmpty())
                {
                    query.Where(p => p.ChinaUnit == model.ChinaUnit);
                }
                if (!model.Specification.IsNullOrEmpty())
                {
                    query.Where(p => p.Specification == model.Specification);
                }
                if (!model.PositionInfo.IsNullOrEmpty())
                {
                    query.Where(p => p.PositionInfo == model.PositionInfo);
                }
                if (!model.SKU.IsNullOrEmpty())
                {
                    query.Where(p => p.SKU == model.SKU);
                }
                if (!model.BuyName.IsNullOrEmpty())
                {
                    query.Where(p => p.BuyName == model.BuyName);
                }
                if (!model.Address.IsNullOrEmpty())
                {
                    query.Where(p => p.Address == model.Address);
                }
                if (!model.userphone.IsNullOrEmpty())
                {
                    query.Where(p => p.userphone == model.userphone);
                }
                if (!model.PrintFuncInfo.IsNullOrEmpty())
                {
                    query.Where(p => p.PrintFuncInfo == model.PrintFuncInfo);
                }
                if (!model.PrintingMethod.IsNullOrEmpty())
                {
                    query.Where(p => p.PrintingMethod == model.PrintingMethod);
                }
                if (!model.DesigerPerson.IsNullOrEmpty())
                {
                    query.Where(p => p.DesigerPerson == model.DesigerPerson);
                }
                if (!model.SalePerson.IsNullOrEmpty())
                {
                    query.Where(p => p.SalePerson == model.SalePerson);
                }
                if (!model.KefuPerson.IsNullOrEmpty())
                {
                    query.Where(p => p.KefuPerson == model.KefuPerson);
                }
                if (!model.PrintInfo.IsNullOrEmpty())
                {
                    query.Where(p => p.PrintInfo == model.PrintInfo);
                }
                if (!model.PrintParm.IsNullOrEmpty())
                {
                    query.Where(p => p.PrintParm == model.PrintParm);
                }
                if (!model.Printingdetail.IsNullOrEmpty())
                {
                    query.Where(p => p.Printingdetail == model.Printingdetail);
                }
            }
            return query.GetQueryCount(connection, transaction);
        }

        /// <summary>
        /// 根据主键筛选数据
        /// </summary>
        /// <param name="KeyId">主键Id</param>
        /// <param name="connection">连接</param>
        /// <param name="transaction">事务</param>
        /// <returns>是否成功</returns>
        public Production_Orderdetail_View SelectById(int KeyId, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var query = new LambdaQuery<Production_Orderdetail_View>();
            return query.GetQueryList(connection, transaction).FirstOrDefault();
        }


        /// <summary>
        /// 根据主键筛选数据
        /// </summary>
        /// <param name="KeyId">主键Id</param>
        /// <param name="connection">连接</param>
        /// <param name="transaction">事务</param>
        /// <returns>是否成功</returns>
        public List<Production_Orderdetail_View> SelectByKeys(string Key,List<string> KeyIds, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var query = new LambdaQuery<Production_Orderdetail_View>();
            if("id" == Key.ToLowerInvariant())
            {
                query.Where(p => p.Id.In(KeyIds));
            }
            if("orderno" == Key.ToLowerInvariant())
            {
                query.Where(p => p.OrderNo.In(KeyIds));
            }
            if("ordertime" == Key.ToLowerInvariant())
            {
                query.Where(p => p.OrderTime.In(KeyIds));
            }
            if("designerstatus" == Key.ToLowerInvariant())
            {
                query.Where(p => p.DesignerStatus.In(KeyIds));
            }
            if("productionstatus" == Key.ToLowerInvariant())
            {
                query.Where(p => p.ProductionStatus.In(KeyIds));
            }
            if("orderstatus" == Key.ToLowerInvariant())
            {
                query.Where(p => p.OrderStatus.In(KeyIds));
            }
            if("ordertype" == Key.ToLowerInvariant())
            {
                query.Where(p => p.OrderType.In(KeyIds));
            }
            if("inspectionstatus" == Key.ToLowerInvariant())
            {
                query.Where(p => p.InspectionStatus.In(KeyIds));
            }
            if("returncount" == Key.ToLowerInvariant())
            {
                query.Where(p => p.ReturnCount.In(KeyIds));
            }
            if("returncontext" == Key.ToLowerInvariant())
            {
                query.Where(p => p.ReturnContext.In(KeyIds));
            }
            if("servicecontext" == Key.ToLowerInvariant())
            {
                query.Where(p => p.ServiceContext.In(KeyIds));
            }
            if("designerzip" == Key.ToLowerInvariant())
            {
                query.Where(p => p.DesignerZip.In(KeyIds));
            }
            if("productionzip" == Key.ToLowerInvariant())
            {
                query.Where(p => p.ProductionZip.In(KeyIds));
            }
            if("order_detailid" == Key.ToLowerInvariant())
            {
                query.Where(p => p.order_detailId.In(KeyIds));
            }
            if("expresscompany" == Key.ToLowerInvariant())
            {
                query.Where(p => p.ExpressCompany.In(KeyIds));
            }
            if("expressweight" == Key.ToLowerInvariant())
            {
                query.Where(p => p.ExpressWeight.In(KeyIds));
            }
            if("expresscontext" == Key.ToLowerInvariant())
            {
                query.Where(p => p.ExpressContext.In(KeyIds));
            }
            if("expressno" == Key.ToLowerInvariant())
            {
                query.Where(p => p.ExpressNo.In(KeyIds));
            }
            if("qcinspector" == Key.ToLowerInvariant())
            {
                query.Where(p => p.QCINSPECTOR.In(KeyIds));
            }
            if("inspectiondate" == Key.ToLowerInvariant())
            {
                query.Where(p => p.INSPECTIONDATE.In(KeyIds));
            }
            if("badinfo" == Key.ToLowerInvariant())
            {
                query.Where(p => p.BadInfo.In(KeyIds));
            }
            if("productimageinfo" == Key.ToLowerInvariant())
            {
                query.Where(p => p.ProductImageInfo.In(KeyIds));
            }
            if("testresults" == Key.ToLowerInvariant())
            {
                query.Where(p => p.TestResults.In(KeyIds));
            }
            if("username" == Key.ToLowerInvariant())
            {
                query.Where(p => p.userName.In(KeyIds));
            }
            if("phone" == Key.ToLowerInvariant())
            {
                query.Where(p => p.Phone.In(KeyIds));
            }
            if("companyaddr" == Key.ToLowerInvariant())
            {
                query.Where(p => p.CompanyAddr.In(KeyIds));
            }
            if("companyname" == Key.ToLowerInvariant())
            {
                query.Where(p => p.CompanyName.In(KeyIds));
            }
            if("materialid" == Key.ToLowerInvariant())
            {
                query.Where(p => p.MaterialId.In(KeyIds));
            }
            if("commodityname" == Key.ToLowerInvariant())
            {
                query.Where(p => p.commodityName.In(KeyIds));
            }
            if("commodityid" == Key.ToLowerInvariant())
            {
                query.Where(p => p.commodityId.In(KeyIds));
            }
            if("imageinfolist" == Key.ToLowerInvariant())
            {
                query.Where(p => p.ImageInfoList.In(KeyIds));
            }
            if("amount" == Key.ToLowerInvariant())
            {
                query.Where(p => p.Amount.In(KeyIds));
            }
            if("paymoney" == Key.ToLowerInvariant())
            {
                query.Where(p => p.PayMoney.In(KeyIds));
            }
            if("imagelist" == Key.ToLowerInvariant())
            {
                query.Where(p => p.ImageList.In(KeyIds));
            }
            if("wordopertion" == Key.ToLowerInvariant())
            {
                query.Where(p => p.WordOpertion.In(KeyIds));
            }
            if("onlineimageopertion" == Key.ToLowerInvariant())
            {
                query.Where(p => p.OnLineImageOpertion.In(KeyIds));
            }
            if("customimageopertion" == Key.ToLowerInvariant())
            {
                query.Where(p => p.CustomImageOpertion.In(KeyIds));
            }
            if("designerimage" == Key.ToLowerInvariant())
            {
                query.Where(p => p.DesignerImage.In(KeyIds));
            }
            if("orderid" == Key.ToLowerInvariant())
            {
                query.Where(p => p.OrderId.In(KeyIds));
            }
            if("color" == Key.ToLowerInvariant())
            {
                query.Where(p => p.Color.In(KeyIds));
            }
            if("colorid" == Key.ToLowerInvariant())
            {
                query.Where(p => p.ColorId.In(KeyIds));
            }
            if("deliverytime" == Key.ToLowerInvariant())
            {
                query.Where(p => p.deliveryTime.In(KeyIds));
            }
            if("inspectioncontext" == Key.ToLowerInvariant())
            {
                query.Where(p => p.InspectionContext.In(KeyIds));
            }
            if("productno" == Key.ToLowerInvariant())
            {
                query.Where(p => p.ProductNo.In(KeyIds));
            }
            if("chinaproductname" == Key.ToLowerInvariant())
            {
                query.Where(p => p.ChinaProductName.In(KeyIds));
            }
            if("chinaunit" == Key.ToLowerInvariant())
            {
                query.Where(p => p.ChinaUnit.In(KeyIds));
            }
            if("specification" == Key.ToLowerInvariant())
            {
                query.Where(p => p.Specification.In(KeyIds));
            }
            if("positioninfo" == Key.ToLowerInvariant())
            {
                query.Where(p => p.PositionInfo.In(KeyIds));
            }
            if("sku" == Key.ToLowerInvariant())
            {
                query.Where(p => p.SKU.In(KeyIds));
            }
            if("buyname" == Key.ToLowerInvariant())
            {
                query.Where(p => p.BuyName.In(KeyIds));
            }
            if("address" == Key.ToLowerInvariant())
            {
                query.Where(p => p.Address.In(KeyIds));
            }
            if("userphone" == Key.ToLowerInvariant())
            {
                query.Where(p => p.userphone.In(KeyIds));
            }
            if("printfuncinfo" == Key.ToLowerInvariant())
            {
                query.Where(p => p.PrintFuncInfo.In(KeyIds));
            }
            if("printingmethod" == Key.ToLowerInvariant())
            {
                query.Where(p => p.PrintingMethod.In(KeyIds));
            }
            if("desigerperson" == Key.ToLowerInvariant())
            {
                query.Where(p => p.DesigerPerson.In(KeyIds));
            }
            if("saleperson" == Key.ToLowerInvariant())
            {
                query.Where(p => p.SalePerson.In(KeyIds));
            }
            if("kefuperson" == Key.ToLowerInvariant())
            {
                query.Where(p => p.KefuPerson.In(KeyIds));
            }
            if("printinfo" == Key.ToLowerInvariant())
            {
                query.Where(p => p.PrintInfo.In(KeyIds));
            }
            if("printparm" == Key.ToLowerInvariant())
            {
                query.Where(p => p.PrintParm.In(KeyIds));
            }
            if("printingdetail" == Key.ToLowerInvariant())
            {
                query.Where(p => p.Printingdetail.In(KeyIds));
            }
            return query.GetQueryList(connection, transaction);
        }

        /// <summary>
        /// 根据分页筛选数据
        /// </summary>
        /// <param name="Key">主键</param>
        /// <param name="start">开始数据</param>
        /// <param name="PageSize">页面长度</param>
        /// <param name="desc">排序</param>
        /// <param name="model">对象</param>
        /// <param name="connection">连接</param>
        /// <param name="transaction">事务</param>
        /// <returns>对象列表</returns>
        public List<Production_Orderdetail_View> SelectByPage(string Key, int start, int PageSize, bool desc = true,Production_Orderdetail_View model = null, string SelectFiled = null, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var query = new LambdaQuery<Production_Orderdetail_View>();
            if (model != null)
            {
                if (!model.Id.IsNullOrEmpty())
                {
                    query.Where(p => p.Id == model.Id);
                }
                if (!model.OrderNo.IsNullOrEmpty())
                {
                    query.Where(p => p.OrderNo == model.OrderNo);
                }
                if (!model.OrderTime.IsNullOrEmpty())
                {
                    query.Where(p => p.OrderTime == model.OrderTime);
                }
                if (!model.DesignerStatus.IsNullOrEmpty())
                {
                    query.Where(p => p.DesignerStatus == model.DesignerStatus);
                }
                if (!model.ProductionStatus.IsNullOrEmpty())
                {
                    query.Where(p => p.ProductionStatus == model.ProductionStatus);
                }
                if (!model.OrderStatus.IsNullOrEmpty())
                {
                    query.Where(p => p.OrderStatus == model.OrderStatus);
                }
                if (!model.OrderType.IsNullOrEmpty())
                {
                    query.Where(p => p.OrderType == model.OrderType);
                }
                if (!model.InspectionStatus.IsNullOrEmpty())
                {
                    query.Where(p => p.InspectionStatus == model.InspectionStatus);
                }
                if (!model.ReturnCount.IsNullOrEmpty())
                {
                    query.Where(p => p.ReturnCount == model.ReturnCount);
                }
                if (!model.ReturnContext.IsNullOrEmpty())
                {
                    query.Where(p => p.ReturnContext == model.ReturnContext);
                }
                if (!model.ServiceContext.IsNullOrEmpty())
                {
                    query.Where(p => p.ServiceContext == model.ServiceContext);
                }
                if (!model.DesignerZip.IsNullOrEmpty())
                {
                    query.Where(p => p.DesignerZip == model.DesignerZip);
                }
                if (!model.ProductionZip.IsNullOrEmpty())
                {
                    query.Where(p => p.ProductionZip == model.ProductionZip);
                }
                if (!model.order_detailId.IsNullOrEmpty())
                {
                    query.Where(p => p.order_detailId == model.order_detailId);
                }
                if (!model.ExpressCompany.IsNullOrEmpty())
                {
                    query.Where(p => p.ExpressCompany == model.ExpressCompany);
                }
                if (!model.ExpressWeight.IsNullOrEmpty())
                {
                    query.Where(p => p.ExpressWeight == model.ExpressWeight);
                }
                if (!model.ExpressContext.IsNullOrEmpty())
                {
                    query.Where(p => p.ExpressContext == model.ExpressContext);
                }
                if (!model.ExpressNo.IsNullOrEmpty())
                {
                    query.Where(p => p.ExpressNo == model.ExpressNo);
                }
                if (!model.QCINSPECTOR.IsNullOrEmpty())
                {
                    query.Where(p => p.QCINSPECTOR == model.QCINSPECTOR);
                }
                if (!model.INSPECTIONDATE.IsNullOrEmpty())
                {
                    query.Where(p => p.INSPECTIONDATE == model.INSPECTIONDATE);
                }
                if (!model.BadInfo.IsNullOrEmpty())
                {
                    query.Where(p => p.BadInfo == model.BadInfo);
                }
                if (!model.ProductImageInfo.IsNullOrEmpty())
                {
                    query.Where(p => p.ProductImageInfo == model.ProductImageInfo);
                }
                if (!model.TestResults.IsNullOrEmpty())
                {
                    query.Where(p => p.TestResults == model.TestResults);
                }
                if (!model.userName.IsNullOrEmpty())
                {
                    query.Where(p => p.userName == model.userName);
                }
                if (!model.Phone.IsNullOrEmpty())
                {
                    query.Where(p => p.Phone == model.Phone);
                }
                if (!model.CompanyAddr.IsNullOrEmpty())
                {
                    query.Where(p => p.CompanyAddr == model.CompanyAddr);
                }
                if (!model.CompanyName.IsNullOrEmpty())
                {
                    query.Where(p => p.CompanyName == model.CompanyName);
                }
                if (!model.MaterialId.IsNullOrEmpty())
                {
                    query.Where(p => p.MaterialId == model.MaterialId);
                }
                if (!model.commodityName.IsNullOrEmpty())
                {
                    query.Where(p => p.commodityName == model.commodityName);
                }
                if (!model.commodityId.IsNullOrEmpty())
                {
                    query.Where(p => p.commodityId == model.commodityId);
                }
                if (!model.ImageInfoList.IsNullOrEmpty())
                {
                    query.Where(p => p.ImageInfoList == model.ImageInfoList);
                }
                if (!model.Amount.IsNullOrEmpty())
                {
                    query.Where(p => p.Amount == model.Amount);
                }
                if (!model.PayMoney.IsNullOrEmpty())
                {
                    query.Where(p => p.PayMoney == model.PayMoney);
                }
                if (!model.ImageList.IsNullOrEmpty())
                {
                    query.Where(p => p.ImageList == model.ImageList);
                }
                if (!model.WordOpertion.IsNullOrEmpty())
                {
                    query.Where(p => p.WordOpertion == model.WordOpertion);
                }
                if (!model.OnLineImageOpertion.IsNullOrEmpty())
                {
                    query.Where(p => p.OnLineImageOpertion == model.OnLineImageOpertion);
                }
                if (!model.CustomImageOpertion.IsNullOrEmpty())
                {
                    query.Where(p => p.CustomImageOpertion == model.CustomImageOpertion);
                }
                if (!model.DesignerImage.IsNullOrEmpty())
                {
                    query.Where(p => p.DesignerImage == model.DesignerImage);
                }
                if (!model.OrderId.IsNullOrEmpty())
                {
                    query.Where(p => p.OrderId == model.OrderId);
                }
                if (!model.Color.IsNullOrEmpty())
                {
                    query.Where(p => p.Color == model.Color);
                }
                if (!model.ColorId.IsNullOrEmpty())
                {
                    query.Where(p => p.ColorId == model.ColorId);
                }
                if (!model.deliveryTime.IsNullOrEmpty())
                {
                    query.Where(p => p.deliveryTime == model.deliveryTime);
                }
                if (!model.InspectionContext.IsNullOrEmpty())
                {
                    query.Where(p => p.InspectionContext == model.InspectionContext);
                }
                if (!model.ProductNo.IsNullOrEmpty())
                {
                    query.Where(p => p.ProductNo == model.ProductNo);
                }
                if (!model.ChinaProductName.IsNullOrEmpty())
                {
                    query.Where(p => p.ChinaProductName == model.ChinaProductName);
                }
                if (!model.ChinaUnit.IsNullOrEmpty())
                {
                    query.Where(p => p.ChinaUnit == model.ChinaUnit);
                }
                if (!model.Specification.IsNullOrEmpty())
                {
                    query.Where(p => p.Specification == model.Specification);
                }
                if (!model.PositionInfo.IsNullOrEmpty())
                {
                    query.Where(p => p.PositionInfo == model.PositionInfo);
                }
                if (!model.SKU.IsNullOrEmpty())
                {
                    query.Where(p => p.SKU == model.SKU);
                }
                if (!model.BuyName.IsNullOrEmpty())
                {
                    query.Where(p => p.BuyName == model.BuyName);
                }
                if (!model.Address.IsNullOrEmpty())
                {
                    query.Where(p => p.Address == model.Address);
                }
                if (!model.userphone.IsNullOrEmpty())
                {
                    query.Where(p => p.userphone == model.userphone);
                }
                if (!model.PrintFuncInfo.IsNullOrEmpty())
                {
                    query.Where(p => p.PrintFuncInfo == model.PrintFuncInfo);
                }
                if (!model.PrintingMethod.IsNullOrEmpty())
                {
                    query.Where(p => p.PrintingMethod == model.PrintingMethod);
                }
                if (!model.DesigerPerson.IsNullOrEmpty())
                {
                    query.Where(p => p.DesigerPerson == model.DesigerPerson);
                }
                if (!model.SalePerson.IsNullOrEmpty())
                {
                    query.Where(p => p.SalePerson == model.SalePerson);
                }
                if (!model.KefuPerson.IsNullOrEmpty())
                {
                    query.Where(p => p.KefuPerson == model.KefuPerson);
                }
                if (!model.PrintInfo.IsNullOrEmpty())
                {
                    query.Where(p => p.PrintInfo == model.PrintInfo);
                }
                if (!model.PrintParm.IsNullOrEmpty())
                {
                    query.Where(p => p.PrintParm == model.PrintParm);
                }
                if (!model.Printingdetail.IsNullOrEmpty())
                {
                    query.Where(p => p.Printingdetail == model.Printingdetail);
                }
            }
            if (SelectFiled != null)
            {
                SelectFiled = SelectFiled.ToLowerInvariant();
                if (SelectFiled.Contains("id,"))
                {
                    query.Select(p => new { p.Id });
                }
                if (SelectFiled.Contains("orderno,"))
                {
                    query.Select(p => new { p.OrderNo });
                }
                if (SelectFiled.Contains("ordertime,"))
                {
                    query.Select(p => new { p.OrderTime });
                }
                if (SelectFiled.Contains("designerstatus,"))
                {
                    query.Select(p => new { p.DesignerStatus });
                }
                if (SelectFiled.Contains("productionstatus,"))
                {
                    query.Select(p => new { p.ProductionStatus });
                }
                if (SelectFiled.Contains("orderstatus,"))
                {
                    query.Select(p => new { p.OrderStatus });
                }
                if (SelectFiled.Contains("ordertype,"))
                {
                    query.Select(p => new { p.OrderType });
                }
                if (SelectFiled.Contains("inspectionstatus,"))
                {
                    query.Select(p => new { p.InspectionStatus });
                }
                if (SelectFiled.Contains("returncount,"))
                {
                    query.Select(p => new { p.ReturnCount });
                }
                if (SelectFiled.Contains("returncontext,"))
                {
                    query.Select(p => new { p.ReturnContext });
                }
                if (SelectFiled.Contains("servicecontext,"))
                {
                    query.Select(p => new { p.ServiceContext });
                }
                if (SelectFiled.Contains("designerzip,"))
                {
                    query.Select(p => new { p.DesignerZip });
                }
                if (SelectFiled.Contains("productionzip,"))
                {
                    query.Select(p => new { p.ProductionZip });
                }
                if (SelectFiled.Contains("order_detailid,"))
                {
                    query.Select(p => new { p.order_detailId });
                }
                if (SelectFiled.Contains("expresscompany,"))
                {
                    query.Select(p => new { p.ExpressCompany });
                }
                if (SelectFiled.Contains("expressweight,"))
                {
                    query.Select(p => new { p.ExpressWeight });
                }
                if (SelectFiled.Contains("expresscontext,"))
                {
                    query.Select(p => new { p.ExpressContext });
                }
                if (SelectFiled.Contains("expressno,"))
                {
                    query.Select(p => new { p.ExpressNo });
                }
                if (SelectFiled.Contains("qcinspector,"))
                {
                    query.Select(p => new { p.QCINSPECTOR });
                }
                if (SelectFiled.Contains("inspectiondate,"))
                {
                    query.Select(p => new { p.INSPECTIONDATE });
                }
                if (SelectFiled.Contains("badinfo,"))
                {
                    query.Select(p => new { p.BadInfo });
                }
                if (SelectFiled.Contains("productimageinfo,"))
                {
                    query.Select(p => new { p.ProductImageInfo });
                }
                if (SelectFiled.Contains("testresults,"))
                {
                    query.Select(p => new { p.TestResults });
                }
                if (SelectFiled.Contains("username,"))
                {
                    query.Select(p => new { p.userName });
                }
                if (SelectFiled.Contains("phone,"))
                {
                    query.Select(p => new { p.Phone });
                }
                if (SelectFiled.Contains("companyaddr,"))
                {
                    query.Select(p => new { p.CompanyAddr });
                }
                if (SelectFiled.Contains("companyname,"))
                {
                    query.Select(p => new { p.CompanyName });
                }
                if (SelectFiled.Contains("materialid,"))
                {
                    query.Select(p => new { p.MaterialId });
                }
                if (SelectFiled.Contains("commodityname,"))
                {
                    query.Select(p => new { p.commodityName });
                }
                if (SelectFiled.Contains("commodityid,"))
                {
                    query.Select(p => new { p.commodityId });
                }
                if (SelectFiled.Contains("imageinfolist,"))
                {
                    query.Select(p => new { p.ImageInfoList });
                }
                if (SelectFiled.Contains("amount,"))
                {
                    query.Select(p => new { p.Amount });
                }
                if (SelectFiled.Contains("paymoney,"))
                {
                    query.Select(p => new { p.PayMoney });
                }
                if (SelectFiled.Contains("imagelist,"))
                {
                    query.Select(p => new { p.ImageList });
                }
                if (SelectFiled.Contains("wordopertion,"))
                {
                    query.Select(p => new { p.WordOpertion });
                }
                if (SelectFiled.Contains("onlineimageopertion,"))
                {
                    query.Select(p => new { p.OnLineImageOpertion });
                }
                if (SelectFiled.Contains("customimageopertion,"))
                {
                    query.Select(p => new { p.CustomImageOpertion });
                }
                if (SelectFiled.Contains("designerimage,"))
                {
                    query.Select(p => new { p.DesignerImage });
                }
                if (SelectFiled.Contains("orderid,"))
                {
                    query.Select(p => new { p.OrderId });
                }
                if (SelectFiled.Contains("color,"))
                {
                    query.Select(p => new { p.Color });
                }
                if (SelectFiled.Contains("colorid,"))
                {
                    query.Select(p => new { p.ColorId });
                }
                if (SelectFiled.Contains("deliverytime,"))
                {
                    query.Select(p => new { p.deliveryTime });
                }
                if (SelectFiled.Contains("inspectioncontext,"))
                {
                    query.Select(p => new { p.InspectionContext });
                }
                if (SelectFiled.Contains("productno,"))
                {
                    query.Select(p => new { p.ProductNo });
                }
                if (SelectFiled.Contains("chinaproductname,"))
                {
                    query.Select(p => new { p.ChinaProductName });
                }
                if (SelectFiled.Contains("chinaunit,"))
                {
                    query.Select(p => new { p.ChinaUnit });
                }
                if (SelectFiled.Contains("specification,"))
                {
                    query.Select(p => new { p.Specification });
                }
                if (SelectFiled.Contains("positioninfo,"))
                {
                    query.Select(p => new { p.PositionInfo });
                }
                if (SelectFiled.Contains("sku,"))
                {
                    query.Select(p => new { p.SKU });
                }
                if (SelectFiled.Contains("buyname,"))
                {
                    query.Select(p => new { p.BuyName });
                }
                if (SelectFiled.Contains("address,"))
                {
                    query.Select(p => new { p.Address });
                }
                if (SelectFiled.Contains("userphone,"))
                {
                    query.Select(p => new { p.userphone });
                }
                if (SelectFiled.Contains("printfuncinfo,"))
                {
                    query.Select(p => new { p.PrintFuncInfo });
                }
                if (SelectFiled.Contains("printingmethod,"))
                {
                    query.Select(p => new { p.PrintingMethod });
                }
                if (SelectFiled.Contains("desigerperson,"))
                {
                    query.Select(p => new { p.DesigerPerson });
                }
                if (SelectFiled.Contains("saleperson,"))
                {
                    query.Select(p => new { p.SalePerson });
                }
                if (SelectFiled.Contains("kefuperson,"))
                {
                    query.Select(p => new { p.KefuPerson });
                }
                if (SelectFiled.Contains("printinfo,"))
                {
                    query.Select(p => new { p.PrintInfo });
                }
                if (SelectFiled.Contains("printparm,"))
                {
                    query.Select(p => new { p.PrintParm });
                }
                if (SelectFiled.Contains("printingdetail,"))
                {
                    query.Select(p => new { p.Printingdetail });
                }
            }
            if (Key != null)
            {
                query.OrderByKey(Key, desc);
            }
            return query.GetQueryPageList(start, PageSize, connection, transaction);
        }
    }
}
