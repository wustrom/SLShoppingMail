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
    public partial class Buyer_Producer_ViewOper : SingleTon<Buyer_Producer_ViewOper>
    {
        /// <summary>
        /// 筛选全部数据
        /// </summary>
        /// <param name="model">模型</param>
        /// <param name="connection">连接</param>
        /// <param name="transaction">事务</param>
        /// <returns>对象列表</returns>
        public List<Buyer_Producer_View> SelectAll(Buyer_Producer_View model = null, string SelectFiled = null, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var query = new LambdaQuery<Buyer_Producer_View>();
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
                if (!model.Name.IsNullOrEmpty())
                {
                    query.Where(p => p.Name == model.Name);
                }
                if (!model.AccountNumber.IsNullOrEmpty())
                {
                    query.Where(p => p.AccountNumber == model.AccountNumber);
                }
                if (!model.AccountPeriod.IsNullOrEmpty())
                {
                    query.Where(p => p.AccountPeriod == model.AccountPeriod);
                }
                if (!model.Address.IsNullOrEmpty())
                {
                    query.Where(p => p.Address == model.Address);
                }
                if (!model.Bank.IsNullOrEmpty())
                {
                    query.Where(p => p.Bank == model.Bank);
                }
                if (!model.identify.IsNullOrEmpty())
                {
                    query.Where(p => p.identify == model.identify);
                }
                if (!model.SupplyProducts.IsNullOrEmpty())
                {
                    query.Where(p => p.SupplyProducts == model.SupplyProducts);
                }
                if (!model.FaxNumber.IsNullOrEmpty())
                {
                    query.Where(p => p.FaxNumber == model.FaxNumber);
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
                if (SelectFiled.Contains("name,"))
                {
                    query.Select(p => new { p.Name });
                }
                if (SelectFiled.Contains("accountnumber,"))
                {
                    query.Select(p => new { p.AccountNumber });
                }
                if (SelectFiled.Contains("accountperiod,"))
                {
                    query.Select(p => new { p.AccountPeriod });
                }
                if (SelectFiled.Contains("address,"))
                {
                    query.Select(p => new { p.Address });
                }
                if (SelectFiled.Contains("bank,"))
                {
                    query.Select(p => new { p.Bank });
                }
                if (SelectFiled.Contains("identify,"))
                {
                    query.Select(p => new { p.identify });
                }
                if (SelectFiled.Contains("supplyproducts,"))
                {
                    query.Select(p => new { p.SupplyProducts });
                }
                if (SelectFiled.Contains("faxnumber,"))
                {
                    query.Select(p => new { p.FaxNumber });
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
        public int SelectCount(Buyer_Producer_View model = null, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var query = new LambdaQuery<Buyer_Producer_View>();
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
                if (!model.Name.IsNullOrEmpty())
                {
                    query.Where(p => p.Name == model.Name);
                }
                if (!model.AccountNumber.IsNullOrEmpty())
                {
                    query.Where(p => p.AccountNumber == model.AccountNumber);
                }
                if (!model.AccountPeriod.IsNullOrEmpty())
                {
                    query.Where(p => p.AccountPeriod == model.AccountPeriod);
                }
                if (!model.Address.IsNullOrEmpty())
                {
                    query.Where(p => p.Address == model.Address);
                }
                if (!model.Bank.IsNullOrEmpty())
                {
                    query.Where(p => p.Bank == model.Bank);
                }
                if (!model.identify.IsNullOrEmpty())
                {
                    query.Where(p => p.identify == model.identify);
                }
                if (!model.SupplyProducts.IsNullOrEmpty())
                {
                    query.Where(p => p.SupplyProducts == model.SupplyProducts);
                }
                if (!model.FaxNumber.IsNullOrEmpty())
                {
                    query.Where(p => p.FaxNumber == model.FaxNumber);
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
        public Buyer_Producer_View SelectById(int KeyId, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var query = new LambdaQuery<Buyer_Producer_View>();
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
        public List<Buyer_Producer_View> SelectByKeys(string Key,List<string> KeyIds, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var query = new LambdaQuery<Buyer_Producer_View>();
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
            if("name" == Key.ToLowerInvariant())
            {
                query.Where(p => p.Name.In(KeyIds));
            }
            if("accountnumber" == Key.ToLowerInvariant())
            {
                query.Where(p => p.AccountNumber.In(KeyIds));
            }
            if("accountperiod" == Key.ToLowerInvariant())
            {
                query.Where(p => p.AccountPeriod.In(KeyIds));
            }
            if("address" == Key.ToLowerInvariant())
            {
                query.Where(p => p.Address.In(KeyIds));
            }
            if("bank" == Key.ToLowerInvariant())
            {
                query.Where(p => p.Bank.In(KeyIds));
            }
            if("identify" == Key.ToLowerInvariant())
            {
                query.Where(p => p.identify.In(KeyIds));
            }
            if("supplyproducts" == Key.ToLowerInvariant())
            {
                query.Where(p => p.SupplyProducts.In(KeyIds));
            }
            if("faxnumber" == Key.ToLowerInvariant())
            {
                query.Where(p => p.FaxNumber.In(KeyIds));
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
        public List<Buyer_Producer_View> SelectByPage(string Key, int start, int PageSize, bool desc = true,Buyer_Producer_View model = null, string SelectFiled = null, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var query = new LambdaQuery<Buyer_Producer_View>();
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
                if (!model.Name.IsNullOrEmpty())
                {
                    query.Where(p => p.Name == model.Name);
                }
                if (!model.AccountNumber.IsNullOrEmpty())
                {
                    query.Where(p => p.AccountNumber == model.AccountNumber);
                }
                if (!model.AccountPeriod.IsNullOrEmpty())
                {
                    query.Where(p => p.AccountPeriod == model.AccountPeriod);
                }
                if (!model.Address.IsNullOrEmpty())
                {
                    query.Where(p => p.Address == model.Address);
                }
                if (!model.Bank.IsNullOrEmpty())
                {
                    query.Where(p => p.Bank == model.Bank);
                }
                if (!model.identify.IsNullOrEmpty())
                {
                    query.Where(p => p.identify == model.identify);
                }
                if (!model.SupplyProducts.IsNullOrEmpty())
                {
                    query.Where(p => p.SupplyProducts == model.SupplyProducts);
                }
                if (!model.FaxNumber.IsNullOrEmpty())
                {
                    query.Where(p => p.FaxNumber == model.FaxNumber);
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
                if (SelectFiled.Contains("name,"))
                {
                    query.Select(p => new { p.Name });
                }
                if (SelectFiled.Contains("accountnumber,"))
                {
                    query.Select(p => new { p.AccountNumber });
                }
                if (SelectFiled.Contains("accountperiod,"))
                {
                    query.Select(p => new { p.AccountPeriod });
                }
                if (SelectFiled.Contains("address,"))
                {
                    query.Select(p => new { p.Address });
                }
                if (SelectFiled.Contains("bank,"))
                {
                    query.Select(p => new { p.Bank });
                }
                if (SelectFiled.Contains("identify,"))
                {
                    query.Select(p => new { p.identify });
                }
                if (SelectFiled.Contains("supplyproducts,"))
                {
                    query.Select(p => new { p.SupplyProducts });
                }
                if (SelectFiled.Contains("faxnumber,"))
                {
                    query.Select(p => new { p.FaxNumber });
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
