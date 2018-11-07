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
    public partial class ProductionOper : SingleTon<ProductionOper>
    {
        /// <summary>
        /// 根据主键删除数据
        /// </summary>
        /// <param name="KeyId">主键Id</param>
        /// <param name="connection">连接</param>
        /// <param name="transaction">事务</param>
        /// <returns>是否成功</returns>
        public bool DeleteById(int KeyId, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var delete = new LambdaDelete<Production>();
            delete.Where(p => p.Id == KeyId);
            return delete.GetDeleteResult(connection, transaction);
        }

        /// <summary>
        /// 根据模型删除数据
        /// </summary>
        /// <param name="model">模型</param>
        /// <param name="connection">连接</param>
        /// <param name="transaction">事务</param>
        /// <returns>是否成功</returns>
        public bool DeleteModel(Production model = null, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var delete = new LambdaDelete<Production>();
            if (model != null)
            {
                if (!model.Id.IsNullOrEmpty())
                {
                    delete.Where(p => p.Id == model.Id);
                }
                if (!model.ProductionNo.IsNullOrEmpty())
                {
                    delete.Where(p => p.ProductionNo == model.ProductionNo);
                }
                if (!model.order_detailId.IsNullOrEmpty())
                {
                    delete.Where(p => p.order_detailId == model.order_detailId);
                }
                if (!model.DesignerStatus.IsNullOrEmpty())
                {
                    delete.Where(p => p.DesignerStatus == model.DesignerStatus);
                }
                if (!model.DesignerZip.IsNullOrEmpty())
                {
                    delete.Where(p => p.DesignerZip == model.DesignerZip);
                }
                if (!model.ProductionStatus.IsNullOrEmpty())
                {
                    delete.Where(p => p.ProductionStatus == model.ProductionStatus);
                }
                if (!model.ProductionZip.IsNullOrEmpty())
                {
                    delete.Where(p => p.ProductionZip == model.ProductionZip);
                }
                if (!model.OrderStatus.IsNullOrEmpty())
                {
                    delete.Where(p => p.OrderStatus == model.OrderStatus);
                }
                if (!model.OrderType.IsNullOrEmpty())
                {
                    delete.Where(p => p.OrderType == model.OrderType);
                }
                if (!model.deliveryTime.IsNullOrEmpty())
                {
                    delete.Where(p => p.deliveryTime == model.deliveryTime);
                }
                if (!model.InspectionStatus.IsNullOrEmpty())
                {
                    delete.Where(p => p.InspectionStatus == model.InspectionStatus);
                }
                if (!model.ReturnCount.IsNullOrEmpty())
                {
                    delete.Where(p => p.ReturnCount == model.ReturnCount);
                }
                if (!model.ReturnContext.IsNullOrEmpty())
                {
                    delete.Where(p => p.ReturnContext == model.ReturnContext);
                }
                if (!model.InspectionContext.IsNullOrEmpty())
                {
                    delete.Where(p => p.InspectionContext == model.InspectionContext);
                }
                if (!model.ServiceContext.IsNullOrEmpty())
                {
                    delete.Where(p => p.ServiceContext == model.ServiceContext);
                }
                if (!model.AddresseeName.IsNullOrEmpty())
                {
                    delete.Where(p => p.AddresseeName == model.AddresseeName);
                }
                if (!model.AddresseePhone.IsNullOrEmpty())
                {
                    delete.Where(p => p.AddresseePhone == model.AddresseePhone);
                }
                if (!model.ExpressCompany.IsNullOrEmpty())
                {
                    delete.Where(p => p.ExpressCompany == model.ExpressCompany);
                }
                if (!model.ExpressNo.IsNullOrEmpty())
                {
                    delete.Where(p => p.ExpressNo == model.ExpressNo);
                }
                if (!model.ExpressWeight.IsNullOrEmpty())
                {
                    delete.Where(p => p.ExpressWeight == model.ExpressWeight);
                }
                if (!model.ExpressContext.IsNullOrEmpty())
                {
                    delete.Where(p => p.ExpressContext == model.ExpressContext);
                }
                if (!model.ProductionPerson.IsNullOrEmpty())
                {
                    delete.Where(p => p.ProductionPerson == model.ProductionPerson);
                }
                if (!model.ProductionTime.IsNullOrEmpty())
                {
                    delete.Where(p => p.ProductionTime == model.ProductionTime);
                }
                if (!model.DesigerPerson.IsNullOrEmpty())
                {
                    delete.Where(p => p.DesigerPerson == model.DesigerPerson);
                }
                if (!model.KefuPerson.IsNullOrEmpty())
                {
                    delete.Where(p => p.KefuPerson == model.KefuPerson);
                }
                if (!model.SalePerson.IsNullOrEmpty())
                {
                    delete.Where(p => p.SalePerson == model.SalePerson);
                }
                if (!model.PrintInfo.IsNullOrEmpty())
                {
                    delete.Where(p => p.PrintInfo == model.PrintInfo);
                }
                if (!model.PrintParm.IsNullOrEmpty())
                {
                    delete.Where(p => p.PrintParm == model.PrintParm);
                }
                if (!model.Inspector.IsNullOrEmpty())
                {
                    delete.Where(p => p.Inspector == model.Inspector);
                }
                if (!model.BadInfo.IsNullOrEmpty())
                {
                    delete.Where(p => p.BadInfo == model.BadInfo);
                }
                if (!model.TestResults.IsNullOrEmpty())
                {
                    delete.Where(p => p.TestResults == model.TestResults);
                }
                if (!model.ProductImageInfo.IsNullOrEmpty())
                {
                    delete.Where(p => p.ProductImageInfo == model.ProductImageInfo);
                }
                if (!model.INSPECTIONDATE.IsNullOrEmpty())
                {
                    delete.Where(p => p.INSPECTIONDATE == model.INSPECTIONDATE);
                }
                if (!model.QCINSPECTOR.IsNullOrEmpty())
                {
                    delete.Where(p => p.QCINSPECTOR == model.QCINSPECTOR);
                }
            }
            return delete.GetDeleteResult(connection, transaction);
        }

        /// <summary>
        /// 根据模型更新
        /// </summary>
        /// <param name="model">模型</param>
        /// <param name="connection">连接</param>
        /// <param name="transaction">事务</param>
        /// <returns>是否成功</returns>
        public bool Update(Production model, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var update = new LambdaUpdate<Production>();
            if (!model.Id.IsNullOrEmpty())
            {
                update.Where(p => p.Id == model.Id);
            }
            if (!model.ProductionNo.IsNullOrEmpty())
            {
                update.Set(p => p.ProductionNo == model.ProductionNo);
            }
            if (!model.order_detailId.IsNullOrEmpty())
            {
                update.Set(p => p.order_detailId == model.order_detailId);
            }
            if (!model.DesignerStatus.IsNullOrEmpty())
            {
                update.Set(p => p.DesignerStatus == model.DesignerStatus);
            }
            if (!model.DesignerZip.IsNullOrEmpty())
            {
                update.Set(p => p.DesignerZip == model.DesignerZip);
            }
            if (!model.ProductionStatus.IsNullOrEmpty())
            {
                update.Set(p => p.ProductionStatus == model.ProductionStatus);
            }
            if (!model.ProductionZip.IsNullOrEmpty())
            {
                update.Set(p => p.ProductionZip == model.ProductionZip);
            }
            if (!model.OrderStatus.IsNullOrEmpty())
            {
                update.Set(p => p.OrderStatus == model.OrderStatus);
            }
            if (!model.OrderType.IsNullOrEmpty())
            {
                update.Set(p => p.OrderType == model.OrderType);
            }
            if (!model.deliveryTime.IsNullOrEmpty())
            {
                update.Set(p => p.deliveryTime == model.deliveryTime);
            }
            if (!model.InspectionStatus.IsNullOrEmpty())
            {
                update.Set(p => p.InspectionStatus == model.InspectionStatus);
            }
            if (!model.ReturnCount.IsNullOrEmpty())
            {
                update.Set(p => p.ReturnCount == model.ReturnCount);
            }
            if (!model.ReturnContext.IsNullOrEmpty())
            {
                update.Set(p => p.ReturnContext == model.ReturnContext);
            }
            if (!model.InspectionContext.IsNullOrEmpty())
            {
                update.Set(p => p.InspectionContext == model.InspectionContext);
            }
            if (!model.ServiceContext.IsNullOrEmpty())
            {
                update.Set(p => p.ServiceContext == model.ServiceContext);
            }
            if (!model.AddresseeName.IsNullOrEmpty())
            {
                update.Set(p => p.AddresseeName == model.AddresseeName);
            }
            if (!model.AddresseePhone.IsNullOrEmpty())
            {
                update.Set(p => p.AddresseePhone == model.AddresseePhone);
            }
            if (!model.ExpressCompany.IsNullOrEmpty())
            {
                update.Set(p => p.ExpressCompany == model.ExpressCompany);
            }
            if (!model.ExpressNo.IsNullOrEmpty())
            {
                update.Set(p => p.ExpressNo == model.ExpressNo);
            }
            if (!model.ExpressWeight.IsNullOrEmpty())
            {
                update.Set(p => p.ExpressWeight == model.ExpressWeight);
            }
            if (!model.ExpressContext.IsNullOrEmpty())
            {
                update.Set(p => p.ExpressContext == model.ExpressContext);
            }
            if (!model.ProductionPerson.IsNullOrEmpty())
            {
                update.Set(p => p.ProductionPerson == model.ProductionPerson);
            }
            if (!model.ProductionTime.IsNullOrEmpty())
            {
                update.Set(p => p.ProductionTime == model.ProductionTime);
            }
            if (!model.DesigerPerson.IsNullOrEmpty())
            {
                update.Set(p => p.DesigerPerson == model.DesigerPerson);
            }
            if (!model.KefuPerson.IsNullOrEmpty())
            {
                update.Set(p => p.KefuPerson == model.KefuPerson);
            }
            if (!model.SalePerson.IsNullOrEmpty())
            {
                update.Set(p => p.SalePerson == model.SalePerson);
            }
            if (!model.PrintInfo.IsNullOrEmpty())
            {
                update.Set(p => p.PrintInfo == model.PrintInfo);
            }
            if (!model.PrintParm.IsNullOrEmpty())
            {
                update.Set(p => p.PrintParm == model.PrintParm);
            }
            if (!model.Inspector.IsNullOrEmpty())
            {
                update.Set(p => p.Inspector == model.Inspector);
            }
            if (!model.BadInfo.IsNullOrEmpty())
            {
                update.Set(p => p.BadInfo == model.BadInfo);
            }
            if (!model.TestResults.IsNullOrEmpty())
            {
                update.Set(p => p.TestResults == model.TestResults);
            }
            if (!model.ProductImageInfo.IsNullOrEmpty())
            {
                update.Set(p => p.ProductImageInfo == model.ProductImageInfo);
            }
            if (!model.INSPECTIONDATE.IsNullOrEmpty())
            {
                update.Set(p => p.INSPECTIONDATE == model.INSPECTIONDATE);
            }
            if (!model.QCINSPECTOR.IsNullOrEmpty())
            {
                update.Set(p => p.QCINSPECTOR == model.QCINSPECTOR);
            }
            return update.GetUpdateResult(connection, transaction);
        }

        /// <summary>
        /// 根据模型插入
        /// </summary>
        /// <param name="model">模型</param>
        /// <param name="connection">连接</param>
        /// <param name="transaction">事务</param>
        /// <returns>是否成功</returns>
        public bool Insert(Production model, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var insert = new LambdaInsert<Production>();
            if (!model.ProductionNo.IsNullOrEmpty())
            {
                insert.Insert(p => p.ProductionNo == model.ProductionNo);
            }
            if (!model.order_detailId.IsNullOrEmpty())
            {
                insert.Insert(p => p.order_detailId == model.order_detailId);
            }
            if (!model.DesignerStatus.IsNullOrEmpty())
            {
                insert.Insert(p => p.DesignerStatus == model.DesignerStatus);
            }
            if (!model.DesignerZip.IsNullOrEmpty())
            {
                insert.Insert(p => p.DesignerZip == model.DesignerZip);
            }
            if (!model.ProductionStatus.IsNullOrEmpty())
            {
                insert.Insert(p => p.ProductionStatus == model.ProductionStatus);
            }
            if (!model.ProductionZip.IsNullOrEmpty())
            {
                insert.Insert(p => p.ProductionZip == model.ProductionZip);
            }
            if (!model.OrderStatus.IsNullOrEmpty())
            {
                insert.Insert(p => p.OrderStatus == model.OrderStatus);
            }
            if (!model.OrderType.IsNullOrEmpty())
            {
                insert.Insert(p => p.OrderType == model.OrderType);
            }
            if (!model.deliveryTime.IsNullOrEmpty())
            {
                insert.Insert(p => p.deliveryTime == model.deliveryTime);
            }
            if (!model.InspectionStatus.IsNullOrEmpty())
            {
                insert.Insert(p => p.InspectionStatus == model.InspectionStatus);
            }
            if (!model.ReturnCount.IsNullOrEmpty())
            {
                insert.Insert(p => p.ReturnCount == model.ReturnCount);
            }
            if (!model.ReturnContext.IsNullOrEmpty())
            {
                insert.Insert(p => p.ReturnContext == model.ReturnContext);
            }
            if (!model.InspectionContext.IsNullOrEmpty())
            {
                insert.Insert(p => p.InspectionContext == model.InspectionContext);
            }
            if (!model.ServiceContext.IsNullOrEmpty())
            {
                insert.Insert(p => p.ServiceContext == model.ServiceContext);
            }
            if (!model.AddresseeName.IsNullOrEmpty())
            {
                insert.Insert(p => p.AddresseeName == model.AddresseeName);
            }
            if (!model.AddresseePhone.IsNullOrEmpty())
            {
                insert.Insert(p => p.AddresseePhone == model.AddresseePhone);
            }
            if (!model.ExpressCompany.IsNullOrEmpty())
            {
                insert.Insert(p => p.ExpressCompany == model.ExpressCompany);
            }
            if (!model.ExpressNo.IsNullOrEmpty())
            {
                insert.Insert(p => p.ExpressNo == model.ExpressNo);
            }
            if (!model.ExpressWeight.IsNullOrEmpty())
            {
                insert.Insert(p => p.ExpressWeight == model.ExpressWeight);
            }
            if (!model.ExpressContext.IsNullOrEmpty())
            {
                insert.Insert(p => p.ExpressContext == model.ExpressContext);
            }
            if (!model.ProductionPerson.IsNullOrEmpty())
            {
                insert.Insert(p => p.ProductionPerson == model.ProductionPerson);
            }
            if (!model.ProductionTime.IsNullOrEmpty())
            {
                insert.Insert(p => p.ProductionTime == model.ProductionTime);
            }
            if (!model.DesigerPerson.IsNullOrEmpty())
            {
                insert.Insert(p => p.DesigerPerson == model.DesigerPerson);
            }
            if (!model.KefuPerson.IsNullOrEmpty())
            {
                insert.Insert(p => p.KefuPerson == model.KefuPerson);
            }
            if (!model.SalePerson.IsNullOrEmpty())
            {
                insert.Insert(p => p.SalePerson == model.SalePerson);
            }
            if (!model.PrintInfo.IsNullOrEmpty())
            {
                insert.Insert(p => p.PrintInfo == model.PrintInfo);
            }
            if (!model.PrintParm.IsNullOrEmpty())
            {
                insert.Insert(p => p.PrintParm == model.PrintParm);
            }
            if (!model.Inspector.IsNullOrEmpty())
            {
                insert.Insert(p => p.Inspector == model.Inspector);
            }
            if (!model.BadInfo.IsNullOrEmpty())
            {
                insert.Insert(p => p.BadInfo == model.BadInfo);
            }
            if (!model.TestResults.IsNullOrEmpty())
            {
                insert.Insert(p => p.TestResults == model.TestResults);
            }
            if (!model.ProductImageInfo.IsNullOrEmpty())
            {
                insert.Insert(p => p.ProductImageInfo == model.ProductImageInfo);
            }
            if (!model.INSPECTIONDATE.IsNullOrEmpty())
            {
                insert.Insert(p => p.INSPECTIONDATE == model.INSPECTIONDATE);
            }
            if (!model.QCINSPECTOR.IsNullOrEmpty())
            {
                insert.Insert(p => p.QCINSPECTOR == model.QCINSPECTOR);
            }
            return insert.GetInsertResult(connection, transaction) >= 0;
        }

        /// <summary>
        /// 根据模型插入
        /// </summary>
        /// <param name="model">模型</param>
        /// <param name="connection">连接</param>
        /// <param name="transaction">事务</param>
        /// <returns>是否成功</returns>
        public int InsertReturnKey(Production model, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var insert = new LambdaInsert<Production>();
            if (!model.ProductionNo.IsNullOrEmpty())
            {
                insert.Insert(p => p.ProductionNo == model.ProductionNo);
            }
            if (!model.order_detailId.IsNullOrEmpty())
            {
                insert.Insert(p => p.order_detailId == model.order_detailId);
            }
            if (!model.DesignerStatus.IsNullOrEmpty())
            {
                insert.Insert(p => p.DesignerStatus == model.DesignerStatus);
            }
            if (!model.DesignerZip.IsNullOrEmpty())
            {
                insert.Insert(p => p.DesignerZip == model.DesignerZip);
            }
            if (!model.ProductionStatus.IsNullOrEmpty())
            {
                insert.Insert(p => p.ProductionStatus == model.ProductionStatus);
            }
            if (!model.ProductionZip.IsNullOrEmpty())
            {
                insert.Insert(p => p.ProductionZip == model.ProductionZip);
            }
            if (!model.OrderStatus.IsNullOrEmpty())
            {
                insert.Insert(p => p.OrderStatus == model.OrderStatus);
            }
            if (!model.OrderType.IsNullOrEmpty())
            {
                insert.Insert(p => p.OrderType == model.OrderType);
            }
            if (!model.deliveryTime.IsNullOrEmpty())
            {
                insert.Insert(p => p.deliveryTime == model.deliveryTime);
            }
            if (!model.InspectionStatus.IsNullOrEmpty())
            {
                insert.Insert(p => p.InspectionStatus == model.InspectionStatus);
            }
            if (!model.ReturnCount.IsNullOrEmpty())
            {
                insert.Insert(p => p.ReturnCount == model.ReturnCount);
            }
            if (!model.ReturnContext.IsNullOrEmpty())
            {
                insert.Insert(p => p.ReturnContext == model.ReturnContext);
            }
            if (!model.InspectionContext.IsNullOrEmpty())
            {
                insert.Insert(p => p.InspectionContext == model.InspectionContext);
            }
            if (!model.ServiceContext.IsNullOrEmpty())
            {
                insert.Insert(p => p.ServiceContext == model.ServiceContext);
            }
            if (!model.AddresseeName.IsNullOrEmpty())
            {
                insert.Insert(p => p.AddresseeName == model.AddresseeName);
            }
            if (!model.AddresseePhone.IsNullOrEmpty())
            {
                insert.Insert(p => p.AddresseePhone == model.AddresseePhone);
            }
            if (!model.ExpressCompany.IsNullOrEmpty())
            {
                insert.Insert(p => p.ExpressCompany == model.ExpressCompany);
            }
            if (!model.ExpressNo.IsNullOrEmpty())
            {
                insert.Insert(p => p.ExpressNo == model.ExpressNo);
            }
            if (!model.ExpressWeight.IsNullOrEmpty())
            {
                insert.Insert(p => p.ExpressWeight == model.ExpressWeight);
            }
            if (!model.ExpressContext.IsNullOrEmpty())
            {
                insert.Insert(p => p.ExpressContext == model.ExpressContext);
            }
            if (!model.ProductionPerson.IsNullOrEmpty())
            {
                insert.Insert(p => p.ProductionPerson == model.ProductionPerson);
            }
            if (!model.ProductionTime.IsNullOrEmpty())
            {
                insert.Insert(p => p.ProductionTime == model.ProductionTime);
            }
            if (!model.DesigerPerson.IsNullOrEmpty())
            {
                insert.Insert(p => p.DesigerPerson == model.DesigerPerson);
            }
            if (!model.KefuPerson.IsNullOrEmpty())
            {
                insert.Insert(p => p.KefuPerson == model.KefuPerson);
            }
            if (!model.SalePerson.IsNullOrEmpty())
            {
                insert.Insert(p => p.SalePerson == model.SalePerson);
            }
            if (!model.PrintInfo.IsNullOrEmpty())
            {
                insert.Insert(p => p.PrintInfo == model.PrintInfo);
            }
            if (!model.PrintParm.IsNullOrEmpty())
            {
                insert.Insert(p => p.PrintParm == model.PrintParm);
            }
            if (!model.Inspector.IsNullOrEmpty())
            {
                insert.Insert(p => p.Inspector == model.Inspector);
            }
            if (!model.BadInfo.IsNullOrEmpty())
            {
                insert.Insert(p => p.BadInfo == model.BadInfo);
            }
            if (!model.TestResults.IsNullOrEmpty())
            {
                insert.Insert(p => p.TestResults == model.TestResults);
            }
            if (!model.ProductImageInfo.IsNullOrEmpty())
            {
                insert.Insert(p => p.ProductImageInfo == model.ProductImageInfo);
            }
            if (!model.INSPECTIONDATE.IsNullOrEmpty())
            {
                insert.Insert(p => p.INSPECTIONDATE == model.INSPECTIONDATE);
            }
            if (!model.QCINSPECTOR.IsNullOrEmpty())
            {
                insert.Insert(p => p.QCINSPECTOR == model.QCINSPECTOR);
            }
            return insert.GetInsertResult(connection, transaction);
        }

        /// <summary>
        /// 筛选全部数据
        /// </summary>
        /// <param name="model">模型</param>
        /// <param name="connection">连接</param>
        /// <param name="transaction">事务</param>
        /// <returns>对象列表</returns>
        public List<Production> SelectAll(Production model = null, string SelectFiled = null, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var query = new LambdaQuery<Production>();
            if (model != null)
            {
                if (!model.Id.IsNullOrEmpty())
                {
                    query.Where(p => p.Id == model.Id);
                }
                if (!model.ProductionNo.IsNullOrEmpty())
                {
                    query.Where(p => p.ProductionNo == model.ProductionNo);
                }
                if (!model.order_detailId.IsNullOrEmpty())
                {
                    query.Where(p => p.order_detailId == model.order_detailId);
                }
                if (!model.DesignerStatus.IsNullOrEmpty())
                {
                    query.Where(p => p.DesignerStatus == model.DesignerStatus);
                }
                if (!model.DesignerZip.IsNullOrEmpty())
                {
                    query.Where(p => p.DesignerZip == model.DesignerZip);
                }
                if (!model.ProductionStatus.IsNullOrEmpty())
                {
                    query.Where(p => p.ProductionStatus == model.ProductionStatus);
                }
                if (!model.ProductionZip.IsNullOrEmpty())
                {
                    query.Where(p => p.ProductionZip == model.ProductionZip);
                }
                if (!model.OrderStatus.IsNullOrEmpty())
                {
                    query.Where(p => p.OrderStatus == model.OrderStatus);
                }
                if (!model.OrderType.IsNullOrEmpty())
                {
                    query.Where(p => p.OrderType == model.OrderType);
                }
                if (!model.deliveryTime.IsNullOrEmpty())
                {
                    query.Where(p => p.deliveryTime == model.deliveryTime);
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
                if (!model.InspectionContext.IsNullOrEmpty())
                {
                    query.Where(p => p.InspectionContext == model.InspectionContext);
                }
                if (!model.ServiceContext.IsNullOrEmpty())
                {
                    query.Where(p => p.ServiceContext == model.ServiceContext);
                }
                if (!model.AddresseeName.IsNullOrEmpty())
                {
                    query.Where(p => p.AddresseeName == model.AddresseeName);
                }
                if (!model.AddresseePhone.IsNullOrEmpty())
                {
                    query.Where(p => p.AddresseePhone == model.AddresseePhone);
                }
                if (!model.ExpressCompany.IsNullOrEmpty())
                {
                    query.Where(p => p.ExpressCompany == model.ExpressCompany);
                }
                if (!model.ExpressNo.IsNullOrEmpty())
                {
                    query.Where(p => p.ExpressNo == model.ExpressNo);
                }
                if (!model.ExpressWeight.IsNullOrEmpty())
                {
                    query.Where(p => p.ExpressWeight == model.ExpressWeight);
                }
                if (!model.ExpressContext.IsNullOrEmpty())
                {
                    query.Where(p => p.ExpressContext == model.ExpressContext);
                }
                if (!model.ProductionPerson.IsNullOrEmpty())
                {
                    query.Where(p => p.ProductionPerson == model.ProductionPerson);
                }
                if (!model.ProductionTime.IsNullOrEmpty())
                {
                    query.Where(p => p.ProductionTime == model.ProductionTime);
                }
                if (!model.DesigerPerson.IsNullOrEmpty())
                {
                    query.Where(p => p.DesigerPerson == model.DesigerPerson);
                }
                if (!model.KefuPerson.IsNullOrEmpty())
                {
                    query.Where(p => p.KefuPerson == model.KefuPerson);
                }
                if (!model.SalePerson.IsNullOrEmpty())
                {
                    query.Where(p => p.SalePerson == model.SalePerson);
                }
                if (!model.PrintInfo.IsNullOrEmpty())
                {
                    query.Where(p => p.PrintInfo == model.PrintInfo);
                }
                if (!model.PrintParm.IsNullOrEmpty())
                {
                    query.Where(p => p.PrintParm == model.PrintParm);
                }
                if (!model.Inspector.IsNullOrEmpty())
                {
                    query.Where(p => p.Inspector == model.Inspector);
                }
                if (!model.BadInfo.IsNullOrEmpty())
                {
                    query.Where(p => p.BadInfo == model.BadInfo);
                }
                if (!model.TestResults.IsNullOrEmpty())
                {
                    query.Where(p => p.TestResults == model.TestResults);
                }
                if (!model.ProductImageInfo.IsNullOrEmpty())
                {
                    query.Where(p => p.ProductImageInfo == model.ProductImageInfo);
                }
                if (!model.INSPECTIONDATE.IsNullOrEmpty())
                {
                    query.Where(p => p.INSPECTIONDATE == model.INSPECTIONDATE);
                }
                if (!model.QCINSPECTOR.IsNullOrEmpty())
                {
                    query.Where(p => p.QCINSPECTOR == model.QCINSPECTOR);
                }
            }
            if (SelectFiled != null)
            {
                SelectFiled = SelectFiled.ToLowerInvariant();
                if (SelectFiled.Contains("id,"))
                {
                    query.Select(p => new { p.Id });
                }
                if (SelectFiled.Contains("productionno,"))
                {
                    query.Select(p => new { p.ProductionNo });
                }
                if (SelectFiled.Contains("order_detailid,"))
                {
                    query.Select(p => new { p.order_detailId });
                }
                if (SelectFiled.Contains("designerstatus,"))
                {
                    query.Select(p => new { p.DesignerStatus });
                }
                if (SelectFiled.Contains("designerzip,"))
                {
                    query.Select(p => new { p.DesignerZip });
                }
                if (SelectFiled.Contains("productionstatus,"))
                {
                    query.Select(p => new { p.ProductionStatus });
                }
                if (SelectFiled.Contains("productionzip,"))
                {
                    query.Select(p => new { p.ProductionZip });
                }
                if (SelectFiled.Contains("orderstatus,"))
                {
                    query.Select(p => new { p.OrderStatus });
                }
                if (SelectFiled.Contains("ordertype,"))
                {
                    query.Select(p => new { p.OrderType });
                }
                if (SelectFiled.Contains("deliverytime,"))
                {
                    query.Select(p => new { p.deliveryTime });
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
                if (SelectFiled.Contains("inspectioncontext,"))
                {
                    query.Select(p => new { p.InspectionContext });
                }
                if (SelectFiled.Contains("servicecontext,"))
                {
                    query.Select(p => new { p.ServiceContext });
                }
                if (SelectFiled.Contains("addresseename,"))
                {
                    query.Select(p => new { p.AddresseeName });
                }
                if (SelectFiled.Contains("addresseephone,"))
                {
                    query.Select(p => new { p.AddresseePhone });
                }
                if (SelectFiled.Contains("expresscompany,"))
                {
                    query.Select(p => new { p.ExpressCompany });
                }
                if (SelectFiled.Contains("expressno,"))
                {
                    query.Select(p => new { p.ExpressNo });
                }
                if (SelectFiled.Contains("expressweight,"))
                {
                    query.Select(p => new { p.ExpressWeight });
                }
                if (SelectFiled.Contains("expresscontext,"))
                {
                    query.Select(p => new { p.ExpressContext });
                }
                if (SelectFiled.Contains("productionperson,"))
                {
                    query.Select(p => new { p.ProductionPerson });
                }
                if (SelectFiled.Contains("productiontime,"))
                {
                    query.Select(p => new { p.ProductionTime });
                }
                if (SelectFiled.Contains("desigerperson,"))
                {
                    query.Select(p => new { p.DesigerPerson });
                }
                if (SelectFiled.Contains("kefuperson,"))
                {
                    query.Select(p => new { p.KefuPerson });
                }
                if (SelectFiled.Contains("saleperson,"))
                {
                    query.Select(p => new { p.SalePerson });
                }
                if (SelectFiled.Contains("printinfo,"))
                {
                    query.Select(p => new { p.PrintInfo });
                }
                if (SelectFiled.Contains("printparm,"))
                {
                    query.Select(p => new { p.PrintParm });
                }
                if (SelectFiled.Contains("inspector,"))
                {
                    query.Select(p => new { p.Inspector });
                }
                if (SelectFiled.Contains("badinfo,"))
                {
                    query.Select(p => new { p.BadInfo });
                }
                if (SelectFiled.Contains("testresults,"))
                {
                    query.Select(p => new { p.TestResults });
                }
                if (SelectFiled.Contains("productimageinfo,"))
                {
                    query.Select(p => new { p.ProductImageInfo });
                }
                if (SelectFiled.Contains("inspectiondate,"))
                {
                    query.Select(p => new { p.INSPECTIONDATE });
                }
                if (SelectFiled.Contains("qcinspector,"))
                {
                    query.Select(p => new { p.QCINSPECTOR });
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
        public int SelectCount(Production model = null, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var query = new LambdaQuery<Production>();
            if (model != null)
            {
                if (!model.Id.IsNullOrEmpty())
                {
                    query.Where(p => p.Id == model.Id);
                }
                if (!model.ProductionNo.IsNullOrEmpty())
                {
                    query.Where(p => p.ProductionNo == model.ProductionNo);
                }
                if (!model.order_detailId.IsNullOrEmpty())
                {
                    query.Where(p => p.order_detailId == model.order_detailId);
                }
                if (!model.DesignerStatus.IsNullOrEmpty())
                {
                    query.Where(p => p.DesignerStatus == model.DesignerStatus);
                }
                if (!model.DesignerZip.IsNullOrEmpty())
                {
                    query.Where(p => p.DesignerZip == model.DesignerZip);
                }
                if (!model.ProductionStatus.IsNullOrEmpty())
                {
                    query.Where(p => p.ProductionStatus == model.ProductionStatus);
                }
                if (!model.ProductionZip.IsNullOrEmpty())
                {
                    query.Where(p => p.ProductionZip == model.ProductionZip);
                }
                if (!model.OrderStatus.IsNullOrEmpty())
                {
                    query.Where(p => p.OrderStatus == model.OrderStatus);
                }
                if (!model.OrderType.IsNullOrEmpty())
                {
                    query.Where(p => p.OrderType == model.OrderType);
                }
                if (!model.deliveryTime.IsNullOrEmpty())
                {
                    query.Where(p => p.deliveryTime == model.deliveryTime);
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
                if (!model.InspectionContext.IsNullOrEmpty())
                {
                    query.Where(p => p.InspectionContext == model.InspectionContext);
                }
                if (!model.ServiceContext.IsNullOrEmpty())
                {
                    query.Where(p => p.ServiceContext == model.ServiceContext);
                }
                if (!model.AddresseeName.IsNullOrEmpty())
                {
                    query.Where(p => p.AddresseeName == model.AddresseeName);
                }
                if (!model.AddresseePhone.IsNullOrEmpty())
                {
                    query.Where(p => p.AddresseePhone == model.AddresseePhone);
                }
                if (!model.ExpressCompany.IsNullOrEmpty())
                {
                    query.Where(p => p.ExpressCompany == model.ExpressCompany);
                }
                if (!model.ExpressNo.IsNullOrEmpty())
                {
                    query.Where(p => p.ExpressNo == model.ExpressNo);
                }
                if (!model.ExpressWeight.IsNullOrEmpty())
                {
                    query.Where(p => p.ExpressWeight == model.ExpressWeight);
                }
                if (!model.ExpressContext.IsNullOrEmpty())
                {
                    query.Where(p => p.ExpressContext == model.ExpressContext);
                }
                if (!model.ProductionPerson.IsNullOrEmpty())
                {
                    query.Where(p => p.ProductionPerson == model.ProductionPerson);
                }
                if (!model.ProductionTime.IsNullOrEmpty())
                {
                    query.Where(p => p.ProductionTime == model.ProductionTime);
                }
                if (!model.DesigerPerson.IsNullOrEmpty())
                {
                    query.Where(p => p.DesigerPerson == model.DesigerPerson);
                }
                if (!model.KefuPerson.IsNullOrEmpty())
                {
                    query.Where(p => p.KefuPerson == model.KefuPerson);
                }
                if (!model.SalePerson.IsNullOrEmpty())
                {
                    query.Where(p => p.SalePerson == model.SalePerson);
                }
                if (!model.PrintInfo.IsNullOrEmpty())
                {
                    query.Where(p => p.PrintInfo == model.PrintInfo);
                }
                if (!model.PrintParm.IsNullOrEmpty())
                {
                    query.Where(p => p.PrintParm == model.PrintParm);
                }
                if (!model.Inspector.IsNullOrEmpty())
                {
                    query.Where(p => p.Inspector == model.Inspector);
                }
                if (!model.BadInfo.IsNullOrEmpty())
                {
                    query.Where(p => p.BadInfo == model.BadInfo);
                }
                if (!model.TestResults.IsNullOrEmpty())
                {
                    query.Where(p => p.TestResults == model.TestResults);
                }
                if (!model.ProductImageInfo.IsNullOrEmpty())
                {
                    query.Where(p => p.ProductImageInfo == model.ProductImageInfo);
                }
                if (!model.INSPECTIONDATE.IsNullOrEmpty())
                {
                    query.Where(p => p.INSPECTIONDATE == model.INSPECTIONDATE);
                }
                if (!model.QCINSPECTOR.IsNullOrEmpty())
                {
                    query.Where(p => p.QCINSPECTOR == model.QCINSPECTOR);
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
        public Production SelectById(int KeyId, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var query = new LambdaQuery<Production>();
            query.Where(p => p.Id == KeyId);
            return query.GetQueryList(connection, transaction).FirstOrDefault();
        }


        /// <summary>
        /// 根据主键筛选数据
        /// </summary>
        /// <param name="KeyId">主键Id</param>
        /// <param name="connection">连接</param>
        /// <param name="transaction">事务</param>
        /// <returns>是否成功</returns>
        public List<Production> SelectByKeys(string Key,List<string> KeyIds, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var query = new LambdaQuery<Production>();
            if("id" == Key.ToLowerInvariant())
            {
                query.Where(p => p.Id.In(KeyIds));
            }
            if("productionno" == Key.ToLowerInvariant())
            {
                query.Where(p => p.ProductionNo.In(KeyIds));
            }
            if("order_detailid" == Key.ToLowerInvariant())
            {
                query.Where(p => p.order_detailId.In(KeyIds));
            }
            if("designerstatus" == Key.ToLowerInvariant())
            {
                query.Where(p => p.DesignerStatus.In(KeyIds));
            }
            if("designerzip" == Key.ToLowerInvariant())
            {
                query.Where(p => p.DesignerZip.In(KeyIds));
            }
            if("productionstatus" == Key.ToLowerInvariant())
            {
                query.Where(p => p.ProductionStatus.In(KeyIds));
            }
            if("productionzip" == Key.ToLowerInvariant())
            {
                query.Where(p => p.ProductionZip.In(KeyIds));
            }
            if("orderstatus" == Key.ToLowerInvariant())
            {
                query.Where(p => p.OrderStatus.In(KeyIds));
            }
            if("ordertype" == Key.ToLowerInvariant())
            {
                query.Where(p => p.OrderType.In(KeyIds));
            }
            if("deliverytime" == Key.ToLowerInvariant())
            {
                query.Where(p => p.deliveryTime.In(KeyIds));
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
            if("inspectioncontext" == Key.ToLowerInvariant())
            {
                query.Where(p => p.InspectionContext.In(KeyIds));
            }
            if("servicecontext" == Key.ToLowerInvariant())
            {
                query.Where(p => p.ServiceContext.In(KeyIds));
            }
            if("addresseename" == Key.ToLowerInvariant())
            {
                query.Where(p => p.AddresseeName.In(KeyIds));
            }
            if("addresseephone" == Key.ToLowerInvariant())
            {
                query.Where(p => p.AddresseePhone.In(KeyIds));
            }
            if("expresscompany" == Key.ToLowerInvariant())
            {
                query.Where(p => p.ExpressCompany.In(KeyIds));
            }
            if("expressno" == Key.ToLowerInvariant())
            {
                query.Where(p => p.ExpressNo.In(KeyIds));
            }
            if("expressweight" == Key.ToLowerInvariant())
            {
                query.Where(p => p.ExpressWeight.In(KeyIds));
            }
            if("expresscontext" == Key.ToLowerInvariant())
            {
                query.Where(p => p.ExpressContext.In(KeyIds));
            }
            if("productionperson" == Key.ToLowerInvariant())
            {
                query.Where(p => p.ProductionPerson.In(KeyIds));
            }
            if("productiontime" == Key.ToLowerInvariant())
            {
                query.Where(p => p.ProductionTime.In(KeyIds));
            }
            if("desigerperson" == Key.ToLowerInvariant())
            {
                query.Where(p => p.DesigerPerson.In(KeyIds));
            }
            if("kefuperson" == Key.ToLowerInvariant())
            {
                query.Where(p => p.KefuPerson.In(KeyIds));
            }
            if("saleperson" == Key.ToLowerInvariant())
            {
                query.Where(p => p.SalePerson.In(KeyIds));
            }
            if("printinfo" == Key.ToLowerInvariant())
            {
                query.Where(p => p.PrintInfo.In(KeyIds));
            }
            if("printparm" == Key.ToLowerInvariant())
            {
                query.Where(p => p.PrintParm.In(KeyIds));
            }
            if("inspector" == Key.ToLowerInvariant())
            {
                query.Where(p => p.Inspector.In(KeyIds));
            }
            if("badinfo" == Key.ToLowerInvariant())
            {
                query.Where(p => p.BadInfo.In(KeyIds));
            }
            if("testresults" == Key.ToLowerInvariant())
            {
                query.Where(p => p.TestResults.In(KeyIds));
            }
            if("productimageinfo" == Key.ToLowerInvariant())
            {
                query.Where(p => p.ProductImageInfo.In(KeyIds));
            }
            if("inspectiondate" == Key.ToLowerInvariant())
            {
                query.Where(p => p.INSPECTIONDATE.In(KeyIds));
            }
            if("qcinspector" == Key.ToLowerInvariant())
            {
                query.Where(p => p.QCINSPECTOR.In(KeyIds));
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
        public List<Production> SelectByPage(string Key, int start, int PageSize, bool desc = true,Production model = null, string SelectFiled = null, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var query = new LambdaQuery<Production>();
            if (model != null)
            {
                if (!model.Id.IsNullOrEmpty())
                {
                    query.Where(p => p.Id == model.Id);
                }
                if (!model.ProductionNo.IsNullOrEmpty())
                {
                    query.Where(p => p.ProductionNo == model.ProductionNo);
                }
                if (!model.order_detailId.IsNullOrEmpty())
                {
                    query.Where(p => p.order_detailId == model.order_detailId);
                }
                if (!model.DesignerStatus.IsNullOrEmpty())
                {
                    query.Where(p => p.DesignerStatus == model.DesignerStatus);
                }
                if (!model.DesignerZip.IsNullOrEmpty())
                {
                    query.Where(p => p.DesignerZip == model.DesignerZip);
                }
                if (!model.ProductionStatus.IsNullOrEmpty())
                {
                    query.Where(p => p.ProductionStatus == model.ProductionStatus);
                }
                if (!model.ProductionZip.IsNullOrEmpty())
                {
                    query.Where(p => p.ProductionZip == model.ProductionZip);
                }
                if (!model.OrderStatus.IsNullOrEmpty())
                {
                    query.Where(p => p.OrderStatus == model.OrderStatus);
                }
                if (!model.OrderType.IsNullOrEmpty())
                {
                    query.Where(p => p.OrderType == model.OrderType);
                }
                if (!model.deliveryTime.IsNullOrEmpty())
                {
                    query.Where(p => p.deliveryTime == model.deliveryTime);
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
                if (!model.InspectionContext.IsNullOrEmpty())
                {
                    query.Where(p => p.InspectionContext == model.InspectionContext);
                }
                if (!model.ServiceContext.IsNullOrEmpty())
                {
                    query.Where(p => p.ServiceContext == model.ServiceContext);
                }
                if (!model.AddresseeName.IsNullOrEmpty())
                {
                    query.Where(p => p.AddresseeName == model.AddresseeName);
                }
                if (!model.AddresseePhone.IsNullOrEmpty())
                {
                    query.Where(p => p.AddresseePhone == model.AddresseePhone);
                }
                if (!model.ExpressCompany.IsNullOrEmpty())
                {
                    query.Where(p => p.ExpressCompany == model.ExpressCompany);
                }
                if (!model.ExpressNo.IsNullOrEmpty())
                {
                    query.Where(p => p.ExpressNo == model.ExpressNo);
                }
                if (!model.ExpressWeight.IsNullOrEmpty())
                {
                    query.Where(p => p.ExpressWeight == model.ExpressWeight);
                }
                if (!model.ExpressContext.IsNullOrEmpty())
                {
                    query.Where(p => p.ExpressContext == model.ExpressContext);
                }
                if (!model.ProductionPerson.IsNullOrEmpty())
                {
                    query.Where(p => p.ProductionPerson == model.ProductionPerson);
                }
                if (!model.ProductionTime.IsNullOrEmpty())
                {
                    query.Where(p => p.ProductionTime == model.ProductionTime);
                }
                if (!model.DesigerPerson.IsNullOrEmpty())
                {
                    query.Where(p => p.DesigerPerson == model.DesigerPerson);
                }
                if (!model.KefuPerson.IsNullOrEmpty())
                {
                    query.Where(p => p.KefuPerson == model.KefuPerson);
                }
                if (!model.SalePerson.IsNullOrEmpty())
                {
                    query.Where(p => p.SalePerson == model.SalePerson);
                }
                if (!model.PrintInfo.IsNullOrEmpty())
                {
                    query.Where(p => p.PrintInfo == model.PrintInfo);
                }
                if (!model.PrintParm.IsNullOrEmpty())
                {
                    query.Where(p => p.PrintParm == model.PrintParm);
                }
                if (!model.Inspector.IsNullOrEmpty())
                {
                    query.Where(p => p.Inspector == model.Inspector);
                }
                if (!model.BadInfo.IsNullOrEmpty())
                {
                    query.Where(p => p.BadInfo == model.BadInfo);
                }
                if (!model.TestResults.IsNullOrEmpty())
                {
                    query.Where(p => p.TestResults == model.TestResults);
                }
                if (!model.ProductImageInfo.IsNullOrEmpty())
                {
                    query.Where(p => p.ProductImageInfo == model.ProductImageInfo);
                }
                if (!model.INSPECTIONDATE.IsNullOrEmpty())
                {
                    query.Where(p => p.INSPECTIONDATE == model.INSPECTIONDATE);
                }
                if (!model.QCINSPECTOR.IsNullOrEmpty())
                {
                    query.Where(p => p.QCINSPECTOR == model.QCINSPECTOR);
                }
            }
            if (SelectFiled != null)
            {
                SelectFiled = SelectFiled.ToLowerInvariant();
                if (SelectFiled.Contains("id,"))
                {
                    query.Select(p => new { p.Id });
                }
                if (SelectFiled.Contains("productionno,"))
                {
                    query.Select(p => new { p.ProductionNo });
                }
                if (SelectFiled.Contains("order_detailid,"))
                {
                    query.Select(p => new { p.order_detailId });
                }
                if (SelectFiled.Contains("designerstatus,"))
                {
                    query.Select(p => new { p.DesignerStatus });
                }
                if (SelectFiled.Contains("designerzip,"))
                {
                    query.Select(p => new { p.DesignerZip });
                }
                if (SelectFiled.Contains("productionstatus,"))
                {
                    query.Select(p => new { p.ProductionStatus });
                }
                if (SelectFiled.Contains("productionzip,"))
                {
                    query.Select(p => new { p.ProductionZip });
                }
                if (SelectFiled.Contains("orderstatus,"))
                {
                    query.Select(p => new { p.OrderStatus });
                }
                if (SelectFiled.Contains("ordertype,"))
                {
                    query.Select(p => new { p.OrderType });
                }
                if (SelectFiled.Contains("deliverytime,"))
                {
                    query.Select(p => new { p.deliveryTime });
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
                if (SelectFiled.Contains("inspectioncontext,"))
                {
                    query.Select(p => new { p.InspectionContext });
                }
                if (SelectFiled.Contains("servicecontext,"))
                {
                    query.Select(p => new { p.ServiceContext });
                }
                if (SelectFiled.Contains("addresseename,"))
                {
                    query.Select(p => new { p.AddresseeName });
                }
                if (SelectFiled.Contains("addresseephone,"))
                {
                    query.Select(p => new { p.AddresseePhone });
                }
                if (SelectFiled.Contains("expresscompany,"))
                {
                    query.Select(p => new { p.ExpressCompany });
                }
                if (SelectFiled.Contains("expressno,"))
                {
                    query.Select(p => new { p.ExpressNo });
                }
                if (SelectFiled.Contains("expressweight,"))
                {
                    query.Select(p => new { p.ExpressWeight });
                }
                if (SelectFiled.Contains("expresscontext,"))
                {
                    query.Select(p => new { p.ExpressContext });
                }
                if (SelectFiled.Contains("productionperson,"))
                {
                    query.Select(p => new { p.ProductionPerson });
                }
                if (SelectFiled.Contains("productiontime,"))
                {
                    query.Select(p => new { p.ProductionTime });
                }
                if (SelectFiled.Contains("desigerperson,"))
                {
                    query.Select(p => new { p.DesigerPerson });
                }
                if (SelectFiled.Contains("kefuperson,"))
                {
                    query.Select(p => new { p.KefuPerson });
                }
                if (SelectFiled.Contains("saleperson,"))
                {
                    query.Select(p => new { p.SalePerson });
                }
                if (SelectFiled.Contains("printinfo,"))
                {
                    query.Select(p => new { p.PrintInfo });
                }
                if (SelectFiled.Contains("printparm,"))
                {
                    query.Select(p => new { p.PrintParm });
                }
                if (SelectFiled.Contains("inspector,"))
                {
                    query.Select(p => new { p.Inspector });
                }
                if (SelectFiled.Contains("badinfo,"))
                {
                    query.Select(p => new { p.BadInfo });
                }
                if (SelectFiled.Contains("testresults,"))
                {
                    query.Select(p => new { p.TestResults });
                }
                if (SelectFiled.Contains("productimageinfo,"))
                {
                    query.Select(p => new { p.ProductImageInfo });
                }
                if (SelectFiled.Contains("inspectiondate,"))
                {
                    query.Select(p => new { p.INSPECTIONDATE });
                }
                if (SelectFiled.Contains("qcinspector,"))
                {
                    query.Select(p => new { p.QCINSPECTOR });
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
