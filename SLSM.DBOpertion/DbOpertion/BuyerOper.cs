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
    public partial class BuyerOper : SingleTon<BuyerOper>
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
            var delete = new LambdaDelete<Buyer>();
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
        public bool DeleteModel(Buyer model = null, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var delete = new LambdaDelete<Buyer>();
            if (model != null)
            {
                if (!model.Id.IsNullOrEmpty())
                {
                    delete.Where(p => p.Id == model.Id);
                }
                if (!model.BuyerNo.IsNullOrEmpty())
                {
                    delete.Where(p => p.BuyerNo == model.BuyerNo);
                }
                if (!model.producerId.IsNullOrEmpty())
                {
                    delete.Where(p => p.producerId == model.producerId);
                }
                if (!model.buyerMoney.IsNullOrEmpty())
                {
                    delete.Where(p => p.buyerMoney == model.buyerMoney);
                }
                if (!model.buyerTime.IsNullOrEmpty())
                {
                    delete.Where(p => p.buyerTime == model.buyerTime);
                }
                if (!model.wantTime.IsNullOrEmpty())
                {
                    delete.Where(p => p.wantTime == model.wantTime);
                }
                if (!model.paidTime.IsNullOrEmpty())
                {
                    delete.Where(p => p.paidTime == model.paidTime);
                }
                if (!model.CreateTime.IsNullOrEmpty())
                {
                    delete.Where(p => p.CreateTime == model.CreateTime);
                }
                if (!model.wantmoney.IsNullOrEmpty())
                {
                    delete.Where(p => p.wantmoney == model.wantmoney);
                }
                if (!model.buyerStatus.IsNullOrEmpty())
                {
                    delete.Where(p => p.buyerStatus == model.buyerStatus);
                }
                if (!model.checkStatus.IsNullOrEmpty())
                {
                    delete.Where(p => p.checkStatus == model.checkStatus);
                }
                if (!model.buyerContext.IsNullOrEmpty())
                {
                    delete.Where(p => p.buyerContext == model.buyerContext);
                }
                if (!model.ContractNumber.IsNullOrEmpty())
                {
                    delete.Where(p => p.ContractNumber == model.ContractNumber);
                }
                if (!model.SignedTime.IsNullOrEmpty())
                {
                    delete.Where(p => p.SignedTime == model.SignedTime);
                }
                if (!model.SLSMContacts.IsNullOrEmpty())
                {
                    delete.Where(p => p.SLSMContacts == model.SLSMContacts);
                }
                if (!model.SLSMPhone.IsNullOrEmpty())
                {
                    delete.Where(p => p.SLSMPhone == model.SLSMPhone);
                }
                if (!model.SLSMFaxNumber.IsNullOrEmpty())
                {
                    delete.Where(p => p.SLSMFaxNumber == model.SLSMFaxNumber);
                }
                if (!model.SLSMEmail.IsNullOrEmpty())
                {
                    delete.Where(p => p.SLSMEmail == model.SLSMEmail);
                }
                if (!model.ContractContext.IsNullOrEmpty())
                {
                    delete.Where(p => p.ContractContext == model.ContractContext);
                }
                if (!model.DeliverCompany.IsNullOrEmpty())
                {
                    delete.Where(p => p.DeliverCompany == model.DeliverCompany);
                }
                if (!model.DeeliverExpressNo.IsNullOrEmpty())
                {
                    delete.Where(p => p.DeeliverExpressNo == model.DeeliverExpressNo);
                }
                if (!model.DeliverMan.IsNullOrEmpty())
                {
                    delete.Where(p => p.DeliverMan == model.DeliverMan);
                }
                if (!model.DeliverConsignee.IsNullOrEmpty())
                {
                    delete.Where(p => p.DeliverConsignee == model.DeliverConsignee);
                }
                if (!model.SinglePerson.IsNullOrEmpty())
                {
                    delete.Where(p => p.SinglePerson == model.SinglePerson);
                }
                if (!model.SingleTime.IsNullOrEmpty())
                {
                    delete.Where(p => p.SingleTime == model.SingleTime);
                }
                if (!model.DeliverSinglePerson.IsNullOrEmpty())
                {
                    delete.Where(p => p.DeliverSinglePerson == model.DeliverSinglePerson);
                }
                if (!model.DeliverSingleTime.IsNullOrEmpty())
                {
                    delete.Where(p => p.DeliverSingleTime == model.DeliverSingleTime);
                }
                if (!model.ParentId.IsNullOrEmpty())
                {
                    delete.Where(p => p.ParentId == model.ParentId);
                }
                if (!model.AmountOfWare.IsNullOrEmpty())
                {
                    delete.Where(p => p.AmountOfWare == model.AmountOfWare);
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
                if (!model.QCINSPECTOR.IsNullOrEmpty())
                {
                    delete.Where(p => p.QCINSPECTOR == model.QCINSPECTOR);
                }
                if (!model.INSPECTIONDATE.IsNullOrEmpty())
                {
                    delete.Where(p => p.INSPECTIONDATE == model.INSPECTIONDATE);
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
        public bool Update(Buyer model, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var update = new LambdaUpdate<Buyer>();
            if (!model.Id.IsNullOrEmpty())
            {
                update.Where(p => p.Id == model.Id);
            }
            if (!model.BuyerNo.IsNullOrEmpty())
            {
                update.Set(p => p.BuyerNo == model.BuyerNo);
            }
            if (!model.producerId.IsNullOrEmpty())
            {
                update.Set(p => p.producerId == model.producerId);
            }
            if (!model.buyerMoney.IsNullOrEmpty())
            {
                update.Set(p => p.buyerMoney == model.buyerMoney);
            }
            if (!model.buyerTime.IsNullOrEmpty())
            {
                update.Set(p => p.buyerTime == model.buyerTime);
            }
            if (!model.wantTime.IsNullOrEmpty())
            {
                update.Set(p => p.wantTime == model.wantTime);
            }
            if (!model.paidTime.IsNullOrEmpty())
            {
                update.Set(p => p.paidTime == model.paidTime);
            }
            if (!model.CreateTime.IsNullOrEmpty())
            {
                update.Set(p => p.CreateTime == model.CreateTime);
            }
            if (!model.wantmoney.IsNullOrEmpty())
            {
                update.Set(p => p.wantmoney == model.wantmoney);
            }
            if (!model.buyerStatus.IsNullOrEmpty())
            {
                update.Set(p => p.buyerStatus == model.buyerStatus);
            }
            if (!model.checkStatus.IsNullOrEmpty())
            {
                update.Set(p => p.checkStatus == model.checkStatus);
            }
            if (!model.buyerContext.IsNullOrEmpty())
            {
                update.Set(p => p.buyerContext == model.buyerContext);
            }
            if (!model.ContractNumber.IsNullOrEmpty())
            {
                update.Set(p => p.ContractNumber == model.ContractNumber);
            }
            if (!model.SignedTime.IsNullOrEmpty())
            {
                update.Set(p => p.SignedTime == model.SignedTime);
            }
            if (!model.SLSMContacts.IsNullOrEmpty())
            {
                update.Set(p => p.SLSMContacts == model.SLSMContacts);
            }
            if (!model.SLSMPhone.IsNullOrEmpty())
            {
                update.Set(p => p.SLSMPhone == model.SLSMPhone);
            }
            if (!model.SLSMFaxNumber.IsNullOrEmpty())
            {
                update.Set(p => p.SLSMFaxNumber == model.SLSMFaxNumber);
            }
            if (!model.SLSMEmail.IsNullOrEmpty())
            {
                update.Set(p => p.SLSMEmail == model.SLSMEmail);
            }
            if (!model.ContractContext.IsNullOrEmpty())
            {
                update.Set(p => p.ContractContext == model.ContractContext);
            }
            if (!model.DeliverCompany.IsNullOrEmpty())
            {
                update.Set(p => p.DeliverCompany == model.DeliverCompany);
            }
            if (!model.DeeliverExpressNo.IsNullOrEmpty())
            {
                update.Set(p => p.DeeliverExpressNo == model.DeeliverExpressNo);
            }
            if (!model.DeliverMan.IsNullOrEmpty())
            {
                update.Set(p => p.DeliverMan == model.DeliverMan);
            }
            if (!model.DeliverConsignee.IsNullOrEmpty())
            {
                update.Set(p => p.DeliverConsignee == model.DeliverConsignee);
            }
            if (!model.SinglePerson.IsNullOrEmpty())
            {
                update.Set(p => p.SinglePerson == model.SinglePerson);
            }
            if (!model.SingleTime.IsNullOrEmpty())
            {
                update.Set(p => p.SingleTime == model.SingleTime);
            }
            if (!model.DeliverSinglePerson.IsNullOrEmpty())
            {
                update.Set(p => p.DeliverSinglePerson == model.DeliverSinglePerson);
            }
            if (!model.DeliverSingleTime.IsNullOrEmpty())
            {
                update.Set(p => p.DeliverSingleTime == model.DeliverSingleTime);
            }
            if (!model.ParentId.IsNullOrEmpty())
            {
                update.Set(p => p.ParentId == model.ParentId);
            }
            if (!model.AmountOfWare.IsNullOrEmpty())
            {
                update.Set(p => p.AmountOfWare == model.AmountOfWare);
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
            if (!model.QCINSPECTOR.IsNullOrEmpty())
            {
                update.Set(p => p.QCINSPECTOR == model.QCINSPECTOR);
            }
            if (!model.INSPECTIONDATE.IsNullOrEmpty())
            {
                update.Set(p => p.INSPECTIONDATE == model.INSPECTIONDATE);
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
        public bool Insert(Buyer model, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var insert = new LambdaInsert<Buyer>();
            if (!model.BuyerNo.IsNullOrEmpty())
            {
                insert.Insert(p => p.BuyerNo == model.BuyerNo);
            }
            if (!model.producerId.IsNullOrEmpty())
            {
                insert.Insert(p => p.producerId == model.producerId);
            }
            if (!model.buyerMoney.IsNullOrEmpty())
            {
                insert.Insert(p => p.buyerMoney == model.buyerMoney);
            }
            if (!model.buyerTime.IsNullOrEmpty())
            {
                insert.Insert(p => p.buyerTime == model.buyerTime);
            }
            if (!model.wantTime.IsNullOrEmpty())
            {
                insert.Insert(p => p.wantTime == model.wantTime);
            }
            if (!model.paidTime.IsNullOrEmpty())
            {
                insert.Insert(p => p.paidTime == model.paidTime);
            }
            if (!model.CreateTime.IsNullOrEmpty())
            {
                insert.Insert(p => p.CreateTime == model.CreateTime);
            }
            if (!model.wantmoney.IsNullOrEmpty())
            {
                insert.Insert(p => p.wantmoney == model.wantmoney);
            }
            if (!model.buyerStatus.IsNullOrEmpty())
            {
                insert.Insert(p => p.buyerStatus == model.buyerStatus);
            }
            if (!model.checkStatus.IsNullOrEmpty())
            {
                insert.Insert(p => p.checkStatus == model.checkStatus);
            }
            if (!model.buyerContext.IsNullOrEmpty())
            {
                insert.Insert(p => p.buyerContext == model.buyerContext);
            }
            if (!model.ContractNumber.IsNullOrEmpty())
            {
                insert.Insert(p => p.ContractNumber == model.ContractNumber);
            }
            if (!model.SignedTime.IsNullOrEmpty())
            {
                insert.Insert(p => p.SignedTime == model.SignedTime);
            }
            if (!model.SLSMContacts.IsNullOrEmpty())
            {
                insert.Insert(p => p.SLSMContacts == model.SLSMContacts);
            }
            if (!model.SLSMPhone.IsNullOrEmpty())
            {
                insert.Insert(p => p.SLSMPhone == model.SLSMPhone);
            }
            if (!model.SLSMFaxNumber.IsNullOrEmpty())
            {
                insert.Insert(p => p.SLSMFaxNumber == model.SLSMFaxNumber);
            }
            if (!model.SLSMEmail.IsNullOrEmpty())
            {
                insert.Insert(p => p.SLSMEmail == model.SLSMEmail);
            }
            if (!model.ContractContext.IsNullOrEmpty())
            {
                insert.Insert(p => p.ContractContext == model.ContractContext);
            }
            if (!model.DeliverCompany.IsNullOrEmpty())
            {
                insert.Insert(p => p.DeliverCompany == model.DeliverCompany);
            }
            if (!model.DeeliverExpressNo.IsNullOrEmpty())
            {
                insert.Insert(p => p.DeeliverExpressNo == model.DeeliverExpressNo);
            }
            if (!model.DeliverMan.IsNullOrEmpty())
            {
                insert.Insert(p => p.DeliverMan == model.DeliverMan);
            }
            if (!model.DeliverConsignee.IsNullOrEmpty())
            {
                insert.Insert(p => p.DeliverConsignee == model.DeliverConsignee);
            }
            if (!model.SinglePerson.IsNullOrEmpty())
            {
                insert.Insert(p => p.SinglePerson == model.SinglePerson);
            }
            if (!model.SingleTime.IsNullOrEmpty())
            {
                insert.Insert(p => p.SingleTime == model.SingleTime);
            }
            if (!model.DeliverSinglePerson.IsNullOrEmpty())
            {
                insert.Insert(p => p.DeliverSinglePerson == model.DeliverSinglePerson);
            }
            if (!model.DeliverSingleTime.IsNullOrEmpty())
            {
                insert.Insert(p => p.DeliverSingleTime == model.DeliverSingleTime);
            }
            if (!model.ParentId.IsNullOrEmpty())
            {
                insert.Insert(p => p.ParentId == model.ParentId);
            }
            if (!model.AmountOfWare.IsNullOrEmpty())
            {
                insert.Insert(p => p.AmountOfWare == model.AmountOfWare);
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
            if (!model.QCINSPECTOR.IsNullOrEmpty())
            {
                insert.Insert(p => p.QCINSPECTOR == model.QCINSPECTOR);
            }
            if (!model.INSPECTIONDATE.IsNullOrEmpty())
            {
                insert.Insert(p => p.INSPECTIONDATE == model.INSPECTIONDATE);
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
        public int InsertReturnKey(Buyer model, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var insert = new LambdaInsert<Buyer>();
            if (!model.BuyerNo.IsNullOrEmpty())
            {
                insert.Insert(p => p.BuyerNo == model.BuyerNo);
            }
            if (!model.producerId.IsNullOrEmpty())
            {
                insert.Insert(p => p.producerId == model.producerId);
            }
            if (!model.buyerMoney.IsNullOrEmpty())
            {
                insert.Insert(p => p.buyerMoney == model.buyerMoney);
            }
            if (!model.buyerTime.IsNullOrEmpty())
            {
                insert.Insert(p => p.buyerTime == model.buyerTime);
            }
            if (!model.wantTime.IsNullOrEmpty())
            {
                insert.Insert(p => p.wantTime == model.wantTime);
            }
            if (!model.paidTime.IsNullOrEmpty())
            {
                insert.Insert(p => p.paidTime == model.paidTime);
            }
            if (!model.CreateTime.IsNullOrEmpty())
            {
                insert.Insert(p => p.CreateTime == model.CreateTime);
            }
            if (!model.wantmoney.IsNullOrEmpty())
            {
                insert.Insert(p => p.wantmoney == model.wantmoney);
            }
            if (!model.buyerStatus.IsNullOrEmpty())
            {
                insert.Insert(p => p.buyerStatus == model.buyerStatus);
            }
            if (!model.checkStatus.IsNullOrEmpty())
            {
                insert.Insert(p => p.checkStatus == model.checkStatus);
            }
            if (!model.buyerContext.IsNullOrEmpty())
            {
                insert.Insert(p => p.buyerContext == model.buyerContext);
            }
            if (!model.ContractNumber.IsNullOrEmpty())
            {
                insert.Insert(p => p.ContractNumber == model.ContractNumber);
            }
            if (!model.SignedTime.IsNullOrEmpty())
            {
                insert.Insert(p => p.SignedTime == model.SignedTime);
            }
            if (!model.SLSMContacts.IsNullOrEmpty())
            {
                insert.Insert(p => p.SLSMContacts == model.SLSMContacts);
            }
            if (!model.SLSMPhone.IsNullOrEmpty())
            {
                insert.Insert(p => p.SLSMPhone == model.SLSMPhone);
            }
            if (!model.SLSMFaxNumber.IsNullOrEmpty())
            {
                insert.Insert(p => p.SLSMFaxNumber == model.SLSMFaxNumber);
            }
            if (!model.SLSMEmail.IsNullOrEmpty())
            {
                insert.Insert(p => p.SLSMEmail == model.SLSMEmail);
            }
            if (!model.ContractContext.IsNullOrEmpty())
            {
                insert.Insert(p => p.ContractContext == model.ContractContext);
            }
            if (!model.DeliverCompany.IsNullOrEmpty())
            {
                insert.Insert(p => p.DeliverCompany == model.DeliverCompany);
            }
            if (!model.DeeliverExpressNo.IsNullOrEmpty())
            {
                insert.Insert(p => p.DeeliverExpressNo == model.DeeliverExpressNo);
            }
            if (!model.DeliverMan.IsNullOrEmpty())
            {
                insert.Insert(p => p.DeliverMan == model.DeliverMan);
            }
            if (!model.DeliverConsignee.IsNullOrEmpty())
            {
                insert.Insert(p => p.DeliverConsignee == model.DeliverConsignee);
            }
            if (!model.SinglePerson.IsNullOrEmpty())
            {
                insert.Insert(p => p.SinglePerson == model.SinglePerson);
            }
            if (!model.SingleTime.IsNullOrEmpty())
            {
                insert.Insert(p => p.SingleTime == model.SingleTime);
            }
            if (!model.DeliverSinglePerson.IsNullOrEmpty())
            {
                insert.Insert(p => p.DeliverSinglePerson == model.DeliverSinglePerson);
            }
            if (!model.DeliverSingleTime.IsNullOrEmpty())
            {
                insert.Insert(p => p.DeliverSingleTime == model.DeliverSingleTime);
            }
            if (!model.ParentId.IsNullOrEmpty())
            {
                insert.Insert(p => p.ParentId == model.ParentId);
            }
            if (!model.AmountOfWare.IsNullOrEmpty())
            {
                insert.Insert(p => p.AmountOfWare == model.AmountOfWare);
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
            if (!model.QCINSPECTOR.IsNullOrEmpty())
            {
                insert.Insert(p => p.QCINSPECTOR == model.QCINSPECTOR);
            }
            if (!model.INSPECTIONDATE.IsNullOrEmpty())
            {
                insert.Insert(p => p.INSPECTIONDATE == model.INSPECTIONDATE);
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
        public List<Buyer> SelectAll(Buyer model = null, string SelectFiled = null, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var query = new LambdaQuery<Buyer>();
            if (model != null)
            {
                if (!model.Id.IsNullOrEmpty())
                {
                    query.Where(p => p.Id == model.Id);
                }
                if (!model.BuyerNo.IsNullOrEmpty())
                {
                    query.Where(p => p.BuyerNo == model.BuyerNo);
                }
                if (!model.producerId.IsNullOrEmpty())
                {
                    query.Where(p => p.producerId == model.producerId);
                }
                if (!model.buyerMoney.IsNullOrEmpty())
                {
                    query.Where(p => p.buyerMoney == model.buyerMoney);
                }
                if (!model.buyerTime.IsNullOrEmpty())
                {
                    query.Where(p => p.buyerTime == model.buyerTime);
                }
                if (!model.wantTime.IsNullOrEmpty())
                {
                    query.Where(p => p.wantTime == model.wantTime);
                }
                if (!model.paidTime.IsNullOrEmpty())
                {
                    query.Where(p => p.paidTime == model.paidTime);
                }
                if (!model.CreateTime.IsNullOrEmpty())
                {
                    query.Where(p => p.CreateTime == model.CreateTime);
                }
                if (!model.wantmoney.IsNullOrEmpty())
                {
                    query.Where(p => p.wantmoney == model.wantmoney);
                }
                if (!model.buyerStatus.IsNullOrEmpty())
                {
                    query.Where(p => p.buyerStatus == model.buyerStatus);
                }
                if (!model.checkStatus.IsNullOrEmpty())
                {
                    query.Where(p => p.checkStatus == model.checkStatus);
                }
                if (!model.buyerContext.IsNullOrEmpty())
                {
                    query.Where(p => p.buyerContext == model.buyerContext);
                }
                if (!model.ContractNumber.IsNullOrEmpty())
                {
                    query.Where(p => p.ContractNumber == model.ContractNumber);
                }
                if (!model.SignedTime.IsNullOrEmpty())
                {
                    query.Where(p => p.SignedTime == model.SignedTime);
                }
                if (!model.SLSMContacts.IsNullOrEmpty())
                {
                    query.Where(p => p.SLSMContacts == model.SLSMContacts);
                }
                if (!model.SLSMPhone.IsNullOrEmpty())
                {
                    query.Where(p => p.SLSMPhone == model.SLSMPhone);
                }
                if (!model.SLSMFaxNumber.IsNullOrEmpty())
                {
                    query.Where(p => p.SLSMFaxNumber == model.SLSMFaxNumber);
                }
                if (!model.SLSMEmail.IsNullOrEmpty())
                {
                    query.Where(p => p.SLSMEmail == model.SLSMEmail);
                }
                if (!model.ContractContext.IsNullOrEmpty())
                {
                    query.Where(p => p.ContractContext == model.ContractContext);
                }
                if (!model.DeliverCompany.IsNullOrEmpty())
                {
                    query.Where(p => p.DeliverCompany == model.DeliverCompany);
                }
                if (!model.DeeliverExpressNo.IsNullOrEmpty())
                {
                    query.Where(p => p.DeeliverExpressNo == model.DeeliverExpressNo);
                }
                if (!model.DeliverMan.IsNullOrEmpty())
                {
                    query.Where(p => p.DeliverMan == model.DeliverMan);
                }
                if (!model.DeliverConsignee.IsNullOrEmpty())
                {
                    query.Where(p => p.DeliverConsignee == model.DeliverConsignee);
                }
                if (!model.SinglePerson.IsNullOrEmpty())
                {
                    query.Where(p => p.SinglePerson == model.SinglePerson);
                }
                if (!model.SingleTime.IsNullOrEmpty())
                {
                    query.Where(p => p.SingleTime == model.SingleTime);
                }
                if (!model.DeliverSinglePerson.IsNullOrEmpty())
                {
                    query.Where(p => p.DeliverSinglePerson == model.DeliverSinglePerson);
                }
                if (!model.DeliverSingleTime.IsNullOrEmpty())
                {
                    query.Where(p => p.DeliverSingleTime == model.DeliverSingleTime);
                }
                if (!model.ParentId.IsNullOrEmpty())
                {
                    query.Where(p => p.ParentId == model.ParentId);
                }
                if (!model.AmountOfWare.IsNullOrEmpty())
                {
                    query.Where(p => p.AmountOfWare == model.AmountOfWare);
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
                if (!model.QCINSPECTOR.IsNullOrEmpty())
                {
                    query.Where(p => p.QCINSPECTOR == model.QCINSPECTOR);
                }
                if (!model.INSPECTIONDATE.IsNullOrEmpty())
                {
                    query.Where(p => p.INSPECTIONDATE == model.INSPECTIONDATE);
                }
            }
            if (SelectFiled != null)
            {
                SelectFiled = SelectFiled.ToLowerInvariant();
                if (SelectFiled.Contains("id,"))
                {
                    query.Select(p => new { p.Id });
                }
                if (SelectFiled.Contains("buyerno,"))
                {
                    query.Select(p => new { p.BuyerNo });
                }
                if (SelectFiled.Contains("producerid,"))
                {
                    query.Select(p => new { p.producerId });
                }
                if (SelectFiled.Contains("buyermoney,"))
                {
                    query.Select(p => new { p.buyerMoney });
                }
                if (SelectFiled.Contains("buyertime,"))
                {
                    query.Select(p => new { p.buyerTime });
                }
                if (SelectFiled.Contains("wanttime,"))
                {
                    query.Select(p => new { p.wantTime });
                }
                if (SelectFiled.Contains("paidtime,"))
                {
                    query.Select(p => new { p.paidTime });
                }
                if (SelectFiled.Contains("createtime,"))
                {
                    query.Select(p => new { p.CreateTime });
                }
                if (SelectFiled.Contains("wantmoney,"))
                {
                    query.Select(p => new { p.wantmoney });
                }
                if (SelectFiled.Contains("buyerstatus,"))
                {
                    query.Select(p => new { p.buyerStatus });
                }
                if (SelectFiled.Contains("checkstatus,"))
                {
                    query.Select(p => new { p.checkStatus });
                }
                if (SelectFiled.Contains("buyercontext,"))
                {
                    query.Select(p => new { p.buyerContext });
                }
                if (SelectFiled.Contains("contractnumber,"))
                {
                    query.Select(p => new { p.ContractNumber });
                }
                if (SelectFiled.Contains("signedtime,"))
                {
                    query.Select(p => new { p.SignedTime });
                }
                if (SelectFiled.Contains("slsmcontacts,"))
                {
                    query.Select(p => new { p.SLSMContacts });
                }
                if (SelectFiled.Contains("slsmphone,"))
                {
                    query.Select(p => new { p.SLSMPhone });
                }
                if (SelectFiled.Contains("slsmfaxnumber,"))
                {
                    query.Select(p => new { p.SLSMFaxNumber });
                }
                if (SelectFiled.Contains("slsmemail,"))
                {
                    query.Select(p => new { p.SLSMEmail });
                }
                if (SelectFiled.Contains("contractcontext,"))
                {
                    query.Select(p => new { p.ContractContext });
                }
                if (SelectFiled.Contains("delivercompany,"))
                {
                    query.Select(p => new { p.DeliverCompany });
                }
                if (SelectFiled.Contains("deeliverexpressno,"))
                {
                    query.Select(p => new { p.DeeliverExpressNo });
                }
                if (SelectFiled.Contains("deliverman,"))
                {
                    query.Select(p => new { p.DeliverMan });
                }
                if (SelectFiled.Contains("deliverconsignee,"))
                {
                    query.Select(p => new { p.DeliverConsignee });
                }
                if (SelectFiled.Contains("singleperson,"))
                {
                    query.Select(p => new { p.SinglePerson });
                }
                if (SelectFiled.Contains("singletime,"))
                {
                    query.Select(p => new { p.SingleTime });
                }
                if (SelectFiled.Contains("deliversingleperson,"))
                {
                    query.Select(p => new { p.DeliverSinglePerson });
                }
                if (SelectFiled.Contains("deliversingletime,"))
                {
                    query.Select(p => new { p.DeliverSingleTime });
                }
                if (SelectFiled.Contains("parentid,"))
                {
                    query.Select(p => new { p.ParentId });
                }
                if (SelectFiled.Contains("amountofware,"))
                {
                    query.Select(p => new { p.AmountOfWare });
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
                if (SelectFiled.Contains("qcinspector,"))
                {
                    query.Select(p => new { p.QCINSPECTOR });
                }
                if (SelectFiled.Contains("inspectiondate,"))
                {
                    query.Select(p => new { p.INSPECTIONDATE });
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
        public int SelectCount(Buyer model = null, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var query = new LambdaQuery<Buyer>();
            if (model != null)
            {
                if (!model.Id.IsNullOrEmpty())
                {
                    query.Where(p => p.Id == model.Id);
                }
                if (!model.BuyerNo.IsNullOrEmpty())
                {
                    query.Where(p => p.BuyerNo == model.BuyerNo);
                }
                if (!model.producerId.IsNullOrEmpty())
                {
                    query.Where(p => p.producerId == model.producerId);
                }
                if (!model.buyerMoney.IsNullOrEmpty())
                {
                    query.Where(p => p.buyerMoney == model.buyerMoney);
                }
                if (!model.buyerTime.IsNullOrEmpty())
                {
                    query.Where(p => p.buyerTime == model.buyerTime);
                }
                if (!model.wantTime.IsNullOrEmpty())
                {
                    query.Where(p => p.wantTime == model.wantTime);
                }
                if (!model.paidTime.IsNullOrEmpty())
                {
                    query.Where(p => p.paidTime == model.paidTime);
                }
                if (!model.CreateTime.IsNullOrEmpty())
                {
                    query.Where(p => p.CreateTime == model.CreateTime);
                }
                if (!model.wantmoney.IsNullOrEmpty())
                {
                    query.Where(p => p.wantmoney == model.wantmoney);
                }
                if (!model.buyerStatus.IsNullOrEmpty())
                {
                    query.Where(p => p.buyerStatus == model.buyerStatus);
                }
                if (!model.checkStatus.IsNullOrEmpty())
                {
                    query.Where(p => p.checkStatus == model.checkStatus);
                }
                if (!model.buyerContext.IsNullOrEmpty())
                {
                    query.Where(p => p.buyerContext == model.buyerContext);
                }
                if (!model.ContractNumber.IsNullOrEmpty())
                {
                    query.Where(p => p.ContractNumber == model.ContractNumber);
                }
                if (!model.SignedTime.IsNullOrEmpty())
                {
                    query.Where(p => p.SignedTime == model.SignedTime);
                }
                if (!model.SLSMContacts.IsNullOrEmpty())
                {
                    query.Where(p => p.SLSMContacts == model.SLSMContacts);
                }
                if (!model.SLSMPhone.IsNullOrEmpty())
                {
                    query.Where(p => p.SLSMPhone == model.SLSMPhone);
                }
                if (!model.SLSMFaxNumber.IsNullOrEmpty())
                {
                    query.Where(p => p.SLSMFaxNumber == model.SLSMFaxNumber);
                }
                if (!model.SLSMEmail.IsNullOrEmpty())
                {
                    query.Where(p => p.SLSMEmail == model.SLSMEmail);
                }
                if (!model.ContractContext.IsNullOrEmpty())
                {
                    query.Where(p => p.ContractContext == model.ContractContext);
                }
                if (!model.DeliverCompany.IsNullOrEmpty())
                {
                    query.Where(p => p.DeliverCompany == model.DeliverCompany);
                }
                if (!model.DeeliverExpressNo.IsNullOrEmpty())
                {
                    query.Where(p => p.DeeliverExpressNo == model.DeeliverExpressNo);
                }
                if (!model.DeliverMan.IsNullOrEmpty())
                {
                    query.Where(p => p.DeliverMan == model.DeliverMan);
                }
                if (!model.DeliverConsignee.IsNullOrEmpty())
                {
                    query.Where(p => p.DeliverConsignee == model.DeliverConsignee);
                }
                if (!model.SinglePerson.IsNullOrEmpty())
                {
                    query.Where(p => p.SinglePerson == model.SinglePerson);
                }
                if (!model.SingleTime.IsNullOrEmpty())
                {
                    query.Where(p => p.SingleTime == model.SingleTime);
                }
                if (!model.DeliverSinglePerson.IsNullOrEmpty())
                {
                    query.Where(p => p.DeliverSinglePerson == model.DeliverSinglePerson);
                }
                if (!model.DeliverSingleTime.IsNullOrEmpty())
                {
                    query.Where(p => p.DeliverSingleTime == model.DeliverSingleTime);
                }
                if (!model.ParentId.IsNullOrEmpty())
                {
                    query.Where(p => p.ParentId == model.ParentId);
                }
                if (!model.AmountOfWare.IsNullOrEmpty())
                {
                    query.Where(p => p.AmountOfWare == model.AmountOfWare);
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
                if (!model.QCINSPECTOR.IsNullOrEmpty())
                {
                    query.Where(p => p.QCINSPECTOR == model.QCINSPECTOR);
                }
                if (!model.INSPECTIONDATE.IsNullOrEmpty())
                {
                    query.Where(p => p.INSPECTIONDATE == model.INSPECTIONDATE);
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
        public Buyer SelectById(int KeyId, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var query = new LambdaQuery<Buyer>();
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
        public List<Buyer> SelectByKeys(string Key,List<string> KeyIds, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var query = new LambdaQuery<Buyer>();
            if("id" == Key.ToLowerInvariant())
            {
                query.Where(p => p.Id.In(KeyIds));
            }
            if("buyerno" == Key.ToLowerInvariant())
            {
                query.Where(p => p.BuyerNo.In(KeyIds));
            }
            if("producerid" == Key.ToLowerInvariant())
            {
                query.Where(p => p.producerId.In(KeyIds));
            }
            if("buyermoney" == Key.ToLowerInvariant())
            {
                query.Where(p => p.buyerMoney.In(KeyIds));
            }
            if("buyertime" == Key.ToLowerInvariant())
            {
                query.Where(p => p.buyerTime.In(KeyIds));
            }
            if("wanttime" == Key.ToLowerInvariant())
            {
                query.Where(p => p.wantTime.In(KeyIds));
            }
            if("paidtime" == Key.ToLowerInvariant())
            {
                query.Where(p => p.paidTime.In(KeyIds));
            }
            if("createtime" == Key.ToLowerInvariant())
            {
                query.Where(p => p.CreateTime.In(KeyIds));
            }
            if("wantmoney" == Key.ToLowerInvariant())
            {
                query.Where(p => p.wantmoney.In(KeyIds));
            }
            if("buyerstatus" == Key.ToLowerInvariant())
            {
                query.Where(p => p.buyerStatus.In(KeyIds));
            }
            if("checkstatus" == Key.ToLowerInvariant())
            {
                query.Where(p => p.checkStatus.In(KeyIds));
            }
            if("buyercontext" == Key.ToLowerInvariant())
            {
                query.Where(p => p.buyerContext.In(KeyIds));
            }
            if("contractnumber" == Key.ToLowerInvariant())
            {
                query.Where(p => p.ContractNumber.In(KeyIds));
            }
            if("signedtime" == Key.ToLowerInvariant())
            {
                query.Where(p => p.SignedTime.In(KeyIds));
            }
            if("slsmcontacts" == Key.ToLowerInvariant())
            {
                query.Where(p => p.SLSMContacts.In(KeyIds));
            }
            if("slsmphone" == Key.ToLowerInvariant())
            {
                query.Where(p => p.SLSMPhone.In(KeyIds));
            }
            if("slsmfaxnumber" == Key.ToLowerInvariant())
            {
                query.Where(p => p.SLSMFaxNumber.In(KeyIds));
            }
            if("slsmemail" == Key.ToLowerInvariant())
            {
                query.Where(p => p.SLSMEmail.In(KeyIds));
            }
            if("contractcontext" == Key.ToLowerInvariant())
            {
                query.Where(p => p.ContractContext.In(KeyIds));
            }
            if("delivercompany" == Key.ToLowerInvariant())
            {
                query.Where(p => p.DeliverCompany.In(KeyIds));
            }
            if("deeliverexpressno" == Key.ToLowerInvariant())
            {
                query.Where(p => p.DeeliverExpressNo.In(KeyIds));
            }
            if("deliverman" == Key.ToLowerInvariant())
            {
                query.Where(p => p.DeliverMan.In(KeyIds));
            }
            if("deliverconsignee" == Key.ToLowerInvariant())
            {
                query.Where(p => p.DeliverConsignee.In(KeyIds));
            }
            if("singleperson" == Key.ToLowerInvariant())
            {
                query.Where(p => p.SinglePerson.In(KeyIds));
            }
            if("singletime" == Key.ToLowerInvariant())
            {
                query.Where(p => p.SingleTime.In(KeyIds));
            }
            if("deliversingleperson" == Key.ToLowerInvariant())
            {
                query.Where(p => p.DeliverSinglePerson.In(KeyIds));
            }
            if("deliversingletime" == Key.ToLowerInvariant())
            {
                query.Where(p => p.DeliverSingleTime.In(KeyIds));
            }
            if("parentid" == Key.ToLowerInvariant())
            {
                query.Where(p => p.ParentId.In(KeyIds));
            }
            if("amountofware" == Key.ToLowerInvariant())
            {
                query.Where(p => p.AmountOfWare.In(KeyIds));
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
            if("qcinspector" == Key.ToLowerInvariant())
            {
                query.Where(p => p.QCINSPECTOR.In(KeyIds));
            }
            if("inspectiondate" == Key.ToLowerInvariant())
            {
                query.Where(p => p.INSPECTIONDATE.In(KeyIds));
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
        public List<Buyer> SelectByPage(string Key, int start, int PageSize, bool desc = true,Buyer model = null, string SelectFiled = null, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var query = new LambdaQuery<Buyer>();
            if (model != null)
            {
                if (!model.Id.IsNullOrEmpty())
                {
                    query.Where(p => p.Id == model.Id);
                }
                if (!model.BuyerNo.IsNullOrEmpty())
                {
                    query.Where(p => p.BuyerNo == model.BuyerNo);
                }
                if (!model.producerId.IsNullOrEmpty())
                {
                    query.Where(p => p.producerId == model.producerId);
                }
                if (!model.buyerMoney.IsNullOrEmpty())
                {
                    query.Where(p => p.buyerMoney == model.buyerMoney);
                }
                if (!model.buyerTime.IsNullOrEmpty())
                {
                    query.Where(p => p.buyerTime == model.buyerTime);
                }
                if (!model.wantTime.IsNullOrEmpty())
                {
                    query.Where(p => p.wantTime == model.wantTime);
                }
                if (!model.paidTime.IsNullOrEmpty())
                {
                    query.Where(p => p.paidTime == model.paidTime);
                }
                if (!model.CreateTime.IsNullOrEmpty())
                {
                    query.Where(p => p.CreateTime == model.CreateTime);
                }
                if (!model.wantmoney.IsNullOrEmpty())
                {
                    query.Where(p => p.wantmoney == model.wantmoney);
                }
                if (!model.buyerStatus.IsNullOrEmpty())
                {
                    query.Where(p => p.buyerStatus == model.buyerStatus);
                }
                if (!model.checkStatus.IsNullOrEmpty())
                {
                    query.Where(p => p.checkStatus == model.checkStatus);
                }
                if (!model.buyerContext.IsNullOrEmpty())
                {
                    query.Where(p => p.buyerContext == model.buyerContext);
                }
                if (!model.ContractNumber.IsNullOrEmpty())
                {
                    query.Where(p => p.ContractNumber == model.ContractNumber);
                }
                if (!model.SignedTime.IsNullOrEmpty())
                {
                    query.Where(p => p.SignedTime == model.SignedTime);
                }
                if (!model.SLSMContacts.IsNullOrEmpty())
                {
                    query.Where(p => p.SLSMContacts == model.SLSMContacts);
                }
                if (!model.SLSMPhone.IsNullOrEmpty())
                {
                    query.Where(p => p.SLSMPhone == model.SLSMPhone);
                }
                if (!model.SLSMFaxNumber.IsNullOrEmpty())
                {
                    query.Where(p => p.SLSMFaxNumber == model.SLSMFaxNumber);
                }
                if (!model.SLSMEmail.IsNullOrEmpty())
                {
                    query.Where(p => p.SLSMEmail == model.SLSMEmail);
                }
                if (!model.ContractContext.IsNullOrEmpty())
                {
                    query.Where(p => p.ContractContext == model.ContractContext);
                }
                if (!model.DeliverCompany.IsNullOrEmpty())
                {
                    query.Where(p => p.DeliverCompany == model.DeliverCompany);
                }
                if (!model.DeeliverExpressNo.IsNullOrEmpty())
                {
                    query.Where(p => p.DeeliverExpressNo == model.DeeliverExpressNo);
                }
                if (!model.DeliverMan.IsNullOrEmpty())
                {
                    query.Where(p => p.DeliverMan == model.DeliverMan);
                }
                if (!model.DeliverConsignee.IsNullOrEmpty())
                {
                    query.Where(p => p.DeliverConsignee == model.DeliverConsignee);
                }
                if (!model.SinglePerson.IsNullOrEmpty())
                {
                    query.Where(p => p.SinglePerson == model.SinglePerson);
                }
                if (!model.SingleTime.IsNullOrEmpty())
                {
                    query.Where(p => p.SingleTime == model.SingleTime);
                }
                if (!model.DeliverSinglePerson.IsNullOrEmpty())
                {
                    query.Where(p => p.DeliverSinglePerson == model.DeliverSinglePerson);
                }
                if (!model.DeliverSingleTime.IsNullOrEmpty())
                {
                    query.Where(p => p.DeliverSingleTime == model.DeliverSingleTime);
                }
                if (!model.ParentId.IsNullOrEmpty())
                {
                    query.Where(p => p.ParentId == model.ParentId);
                }
                if (!model.AmountOfWare.IsNullOrEmpty())
                {
                    query.Where(p => p.AmountOfWare == model.AmountOfWare);
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
                if (!model.QCINSPECTOR.IsNullOrEmpty())
                {
                    query.Where(p => p.QCINSPECTOR == model.QCINSPECTOR);
                }
                if (!model.INSPECTIONDATE.IsNullOrEmpty())
                {
                    query.Where(p => p.INSPECTIONDATE == model.INSPECTIONDATE);
                }
            }
            if (SelectFiled != null)
            {
                SelectFiled = SelectFiled.ToLowerInvariant();
                if (SelectFiled.Contains("id,"))
                {
                    query.Select(p => new { p.Id });
                }
                if (SelectFiled.Contains("buyerno,"))
                {
                    query.Select(p => new { p.BuyerNo });
                }
                if (SelectFiled.Contains("producerid,"))
                {
                    query.Select(p => new { p.producerId });
                }
                if (SelectFiled.Contains("buyermoney,"))
                {
                    query.Select(p => new { p.buyerMoney });
                }
                if (SelectFiled.Contains("buyertime,"))
                {
                    query.Select(p => new { p.buyerTime });
                }
                if (SelectFiled.Contains("wanttime,"))
                {
                    query.Select(p => new { p.wantTime });
                }
                if (SelectFiled.Contains("paidtime,"))
                {
                    query.Select(p => new { p.paidTime });
                }
                if (SelectFiled.Contains("createtime,"))
                {
                    query.Select(p => new { p.CreateTime });
                }
                if (SelectFiled.Contains("wantmoney,"))
                {
                    query.Select(p => new { p.wantmoney });
                }
                if (SelectFiled.Contains("buyerstatus,"))
                {
                    query.Select(p => new { p.buyerStatus });
                }
                if (SelectFiled.Contains("checkstatus,"))
                {
                    query.Select(p => new { p.checkStatus });
                }
                if (SelectFiled.Contains("buyercontext,"))
                {
                    query.Select(p => new { p.buyerContext });
                }
                if (SelectFiled.Contains("contractnumber,"))
                {
                    query.Select(p => new { p.ContractNumber });
                }
                if (SelectFiled.Contains("signedtime,"))
                {
                    query.Select(p => new { p.SignedTime });
                }
                if (SelectFiled.Contains("slsmcontacts,"))
                {
                    query.Select(p => new { p.SLSMContacts });
                }
                if (SelectFiled.Contains("slsmphone,"))
                {
                    query.Select(p => new { p.SLSMPhone });
                }
                if (SelectFiled.Contains("slsmfaxnumber,"))
                {
                    query.Select(p => new { p.SLSMFaxNumber });
                }
                if (SelectFiled.Contains("slsmemail,"))
                {
                    query.Select(p => new { p.SLSMEmail });
                }
                if (SelectFiled.Contains("contractcontext,"))
                {
                    query.Select(p => new { p.ContractContext });
                }
                if (SelectFiled.Contains("delivercompany,"))
                {
                    query.Select(p => new { p.DeliverCompany });
                }
                if (SelectFiled.Contains("deeliverexpressno,"))
                {
                    query.Select(p => new { p.DeeliverExpressNo });
                }
                if (SelectFiled.Contains("deliverman,"))
                {
                    query.Select(p => new { p.DeliverMan });
                }
                if (SelectFiled.Contains("deliverconsignee,"))
                {
                    query.Select(p => new { p.DeliverConsignee });
                }
                if (SelectFiled.Contains("singleperson,"))
                {
                    query.Select(p => new { p.SinglePerson });
                }
                if (SelectFiled.Contains("singletime,"))
                {
                    query.Select(p => new { p.SingleTime });
                }
                if (SelectFiled.Contains("deliversingleperson,"))
                {
                    query.Select(p => new { p.DeliverSinglePerson });
                }
                if (SelectFiled.Contains("deliversingletime,"))
                {
                    query.Select(p => new { p.DeliverSingleTime });
                }
                if (SelectFiled.Contains("parentid,"))
                {
                    query.Select(p => new { p.ParentId });
                }
                if (SelectFiled.Contains("amountofware,"))
                {
                    query.Select(p => new { p.AmountOfWare });
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
                if (SelectFiled.Contains("qcinspector,"))
                {
                    query.Select(p => new { p.QCINSPECTOR });
                }
                if (SelectFiled.Contains("inspectiondate,"))
                {
                    query.Select(p => new { p.INSPECTIONDATE });
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
