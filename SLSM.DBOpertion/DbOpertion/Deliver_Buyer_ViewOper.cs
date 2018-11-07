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
    public partial class Deliver_Buyer_ViewOper : SingleTon<Deliver_Buyer_ViewOper>
    {
        /// <summary>
        /// 筛选全部数据
        /// </summary>
        /// <param name="model">模型</param>
        /// <param name="connection">连接</param>
        /// <param name="transaction">事务</param>
        /// <returns>对象列表</returns>
        public List<Deliver_Buyer_View> SelectAll(Deliver_Buyer_View model = null, string SelectFiled = null, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var query = new LambdaQuery<Deliver_Buyer_View>();
            if (model != null)
            {
                if (!model.Id.IsNullOrEmpty())
                {
                    query.Where(p => p.Id == model.Id);
                }
                if (!model.buyerId.IsNullOrEmpty())
                {
                    query.Where(p => p.buyerId == model.buyerId);
                }
                if (!model.buyerTime.IsNullOrEmpty())
                {
                    query.Where(p => p.buyerTime == model.buyerTime);
                }
                if (!model.raw_materialsId.IsNullOrEmpty())
                {
                    query.Where(p => p.raw_materialsId == model.raw_materialsId);
                }
                if (!model.ChinaProductName.IsNullOrEmpty())
                {
                    query.Where(p => p.ChinaProductName == model.ChinaProductName);
                }
                if (!model.Specification.IsNullOrEmpty())
                {
                    query.Where(p => p.Specification == model.Specification);
                }
                if (!model.ChinaUnit.IsNullOrEmpty())
                {
                    query.Where(p => p.ChinaUnit == model.ChinaUnit);
                }
                if (!model.IsStatus.IsNullOrEmpty())
                {
                    query.Where(p => p.IsStatus == model.IsStatus);
                }
                if (!model.DeliverMoney.IsNullOrEmpty())
                {
                    query.Where(p => p.DeliverMoney == model.DeliverMoney);
                }
                if (!model.buyerPrice.IsNullOrEmpty())
                {
                    query.Where(p => p.buyerPrice == model.buyerPrice);
                }
                if (!model.Color.IsNullOrEmpty())
                {
                    query.Where(p => p.Color == model.Color);
                }
                if (!model.DeliverCountext.IsNullOrEmpty())
                {
                    query.Where(p => p.DeliverCountext == model.DeliverCountext);
                }
                if (!model.AlreadyQuantity.IsNullOrEmpty())
                {
                    query.Where(p => p.AlreadyQuantity == model.AlreadyQuantity);
                }
                if (!model.wantmoney.IsNullOrEmpty())
                {
                    query.Where(p => p.wantmoney == model.wantmoney);
                }
                if (!model.wantTime.IsNullOrEmpty())
                {
                    query.Where(p => p.wantTime == model.wantTime);
                }
                if (!model.buyerMoney.IsNullOrEmpty())
                {
                    query.Where(p => p.buyerMoney == model.buyerMoney);
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
                if (!model.SLSMEmail.IsNullOrEmpty())
                {
                    query.Where(p => p.SLSMEmail == model.SLSMEmail);
                }
                if (!model.SLSMFaxNumber.IsNullOrEmpty())
                {
                    query.Where(p => p.SLSMFaxNumber == model.SLSMFaxNumber);
                }
                if (!model.SLSMPhone.IsNullOrEmpty())
                {
                    query.Where(p => p.SLSMPhone == model.SLSMPhone);
                }
                if (!model.ContractContext.IsNullOrEmpty())
                {
                    query.Where(p => p.ContractContext == model.ContractContext);
                }
                if (!model.buyerCount.IsNullOrEmpty())
                {
                    query.Where(p => p.buyerCount == model.buyerCount);
                }
                if (!model.buyerContext.IsNullOrEmpty())
                {
                    query.Where(p => p.buyerContext == model.buyerContext);
                }
                if (!model.producerId.IsNullOrEmpty())
                {
                    query.Where(p => p.producerId == model.producerId);
                }
                if (!model.FactoryNumber.IsNullOrEmpty())
                {
                    query.Where(p => p.FactoryNumber == model.FactoryNumber);
                }
                if (!model.PriceTag.IsNullOrEmpty())
                {
                    query.Where(p => p.PriceTag == model.PriceTag);
                }
                if (!model.producerIdName.IsNullOrEmpty())
                {
                    query.Where(p => p.producerIdName == model.producerIdName);
                }
                if (!model.producerName.IsNullOrEmpty())
                {
                    query.Where(p => p.producerName == model.producerName);
                }
                if (!model.buyerStatus.IsNullOrEmpty())
                {
                    query.Where(p => p.buyerStatus == model.buyerStatus);
                }
                if (!model.checkStatus.IsNullOrEmpty())
                {
                    query.Where(p => p.checkStatus == model.checkStatus);
                }
                if (!model.ProductNo.IsNullOrEmpty())
                {
                    query.Where(p => p.ProductNo == model.ProductNo);
                }
                if (!model.NetWeight.IsNullOrEmpty())
                {
                    query.Where(p => p.NetWeight == model.NetWeight);
                }
                if (!model.NumOuterBoxes.IsNullOrEmpty())
                {
                    query.Where(p => p.NumOuterBoxes == model.NumOuterBoxes);
                }
                if (!model.NumMiddleBoxes.IsNullOrEmpty())
                {
                    query.Where(p => p.NumMiddleBoxes == model.NumMiddleBoxes);
                }
                if (!model.OuterBoxesHeight.IsNullOrEmpty())
                {
                    query.Where(p => p.OuterBoxesHeight == model.OuterBoxesHeight);
                }
                if (!model.OuterBoxesLength.IsNullOrEmpty())
                {
                    query.Where(p => p.OuterBoxesLength == model.OuterBoxesLength);
                }
                if (!model.OuterBoxesWidth.IsNullOrEmpty())
                {
                    query.Where(p => p.OuterBoxesWidth == model.OuterBoxesWidth);
                }
                if (!model.ProductDesibe.IsNullOrEmpty())
                {
                    query.Where(p => p.ProductDesibe == model.ProductDesibe);
                }
                if (!model.ChinaDescribe.IsNullOrEmpty())
                {
                    query.Where(p => p.ChinaDescribe == model.ChinaDescribe);
                }
                if (!model.ParentCount.IsNullOrEmpty())
                {
                    query.Where(p => p.ParentCount == model.ParentCount);
                }
            }
            if (SelectFiled != null)
            {
                SelectFiled = SelectFiled.ToLowerInvariant();
                if (SelectFiled.Contains("id,"))
                {
                    query.Select(p => new { p.Id });
                }
                if (SelectFiled.Contains("buyerid,"))
                {
                    query.Select(p => new { p.buyerId });
                }
                if (SelectFiled.Contains("buyertime,"))
                {
                    query.Select(p => new { p.buyerTime });
                }
                if (SelectFiled.Contains("raw_materialsid,"))
                {
                    query.Select(p => new { p.raw_materialsId });
                }
                if (SelectFiled.Contains("chinaproductname,"))
                {
                    query.Select(p => new { p.ChinaProductName });
                }
                if (SelectFiled.Contains("specification,"))
                {
                    query.Select(p => new { p.Specification });
                }
                if (SelectFiled.Contains("chinaunit,"))
                {
                    query.Select(p => new { p.ChinaUnit });
                }
                if (SelectFiled.Contains("isstatus,"))
                {
                    query.Select(p => new { p.IsStatus });
                }
                if (SelectFiled.Contains("delivermoney,"))
                {
                    query.Select(p => new { p.DeliverMoney });
                }
                if (SelectFiled.Contains("buyerprice,"))
                {
                    query.Select(p => new { p.buyerPrice });
                }
                if (SelectFiled.Contains("color,"))
                {
                    query.Select(p => new { p.Color });
                }
                if (SelectFiled.Contains("delivercountext,"))
                {
                    query.Select(p => new { p.DeliverCountext });
                }
                if (SelectFiled.Contains("alreadyquantity,"))
                {
                    query.Select(p => new { p.AlreadyQuantity });
                }
                if (SelectFiled.Contains("wantmoney,"))
                {
                    query.Select(p => new { p.wantmoney });
                }
                if (SelectFiled.Contains("wanttime,"))
                {
                    query.Select(p => new { p.wantTime });
                }
                if (SelectFiled.Contains("buyermoney,"))
                {
                    query.Select(p => new { p.buyerMoney });
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
                if (SelectFiled.Contains("slsmemail,"))
                {
                    query.Select(p => new { p.SLSMEmail });
                }
                if (SelectFiled.Contains("slsmfaxnumber,"))
                {
                    query.Select(p => new { p.SLSMFaxNumber });
                }
                if (SelectFiled.Contains("slsmphone,"))
                {
                    query.Select(p => new { p.SLSMPhone });
                }
                if (SelectFiled.Contains("contractcontext,"))
                {
                    query.Select(p => new { p.ContractContext });
                }
                if (SelectFiled.Contains("buyercount,"))
                {
                    query.Select(p => new { p.buyerCount });
                }
                if (SelectFiled.Contains("buyercontext,"))
                {
                    query.Select(p => new { p.buyerContext });
                }
                if (SelectFiled.Contains("producerid,"))
                {
                    query.Select(p => new { p.producerId });
                }
                if (SelectFiled.Contains("factorynumber,"))
                {
                    query.Select(p => new { p.FactoryNumber });
                }
                if (SelectFiled.Contains("pricetag,"))
                {
                    query.Select(p => new { p.PriceTag });
                }
                if (SelectFiled.Contains("produceridname,"))
                {
                    query.Select(p => new { p.producerIdName });
                }
                if (SelectFiled.Contains("producername,"))
                {
                    query.Select(p => new { p.producerName });
                }
                if (SelectFiled.Contains("buyerstatus,"))
                {
                    query.Select(p => new { p.buyerStatus });
                }
                if (SelectFiled.Contains("checkstatus,"))
                {
                    query.Select(p => new { p.checkStatus });
                }
                if (SelectFiled.Contains("productno,"))
                {
                    query.Select(p => new { p.ProductNo });
                }
                if (SelectFiled.Contains("netweight,"))
                {
                    query.Select(p => new { p.NetWeight });
                }
                if (SelectFiled.Contains("numouterboxes,"))
                {
                    query.Select(p => new { p.NumOuterBoxes });
                }
                if (SelectFiled.Contains("nummiddleboxes,"))
                {
                    query.Select(p => new { p.NumMiddleBoxes });
                }
                if (SelectFiled.Contains("outerboxesheight,"))
                {
                    query.Select(p => new { p.OuterBoxesHeight });
                }
                if (SelectFiled.Contains("outerboxeslength,"))
                {
                    query.Select(p => new { p.OuterBoxesLength });
                }
                if (SelectFiled.Contains("outerboxeswidth,"))
                {
                    query.Select(p => new { p.OuterBoxesWidth });
                }
                if (SelectFiled.Contains("productdesibe,"))
                {
                    query.Select(p => new { p.ProductDesibe });
                }
                if (SelectFiled.Contains("chinadescribe,"))
                {
                    query.Select(p => new { p.ChinaDescribe });
                }
                if (SelectFiled.Contains("parentcount,"))
                {
                    query.Select(p => new { p.ParentCount });
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
        public int SelectCount(Deliver_Buyer_View model = null, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var query = new LambdaQuery<Deliver_Buyer_View>();
            if (model != null)
            {
                if (!model.Id.IsNullOrEmpty())
                {
                    query.Where(p => p.Id == model.Id);
                }
                if (!model.buyerId.IsNullOrEmpty())
                {
                    query.Where(p => p.buyerId == model.buyerId);
                }
                if (!model.buyerTime.IsNullOrEmpty())
                {
                    query.Where(p => p.buyerTime == model.buyerTime);
                }
                if (!model.raw_materialsId.IsNullOrEmpty())
                {
                    query.Where(p => p.raw_materialsId == model.raw_materialsId);
                }
                if (!model.ChinaProductName.IsNullOrEmpty())
                {
                    query.Where(p => p.ChinaProductName == model.ChinaProductName);
                }
                if (!model.Specification.IsNullOrEmpty())
                {
                    query.Where(p => p.Specification == model.Specification);
                }
                if (!model.ChinaUnit.IsNullOrEmpty())
                {
                    query.Where(p => p.ChinaUnit == model.ChinaUnit);
                }
                if (!model.IsStatus.IsNullOrEmpty())
                {
                    query.Where(p => p.IsStatus == model.IsStatus);
                }
                if (!model.DeliverMoney.IsNullOrEmpty())
                {
                    query.Where(p => p.DeliverMoney == model.DeliverMoney);
                }
                if (!model.buyerPrice.IsNullOrEmpty())
                {
                    query.Where(p => p.buyerPrice == model.buyerPrice);
                }
                if (!model.Color.IsNullOrEmpty())
                {
                    query.Where(p => p.Color == model.Color);
                }
                if (!model.DeliverCountext.IsNullOrEmpty())
                {
                    query.Where(p => p.DeliverCountext == model.DeliverCountext);
                }
                if (!model.AlreadyQuantity.IsNullOrEmpty())
                {
                    query.Where(p => p.AlreadyQuantity == model.AlreadyQuantity);
                }
                if (!model.wantmoney.IsNullOrEmpty())
                {
                    query.Where(p => p.wantmoney == model.wantmoney);
                }
                if (!model.wantTime.IsNullOrEmpty())
                {
                    query.Where(p => p.wantTime == model.wantTime);
                }
                if (!model.buyerMoney.IsNullOrEmpty())
                {
                    query.Where(p => p.buyerMoney == model.buyerMoney);
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
                if (!model.SLSMEmail.IsNullOrEmpty())
                {
                    query.Where(p => p.SLSMEmail == model.SLSMEmail);
                }
                if (!model.SLSMFaxNumber.IsNullOrEmpty())
                {
                    query.Where(p => p.SLSMFaxNumber == model.SLSMFaxNumber);
                }
                if (!model.SLSMPhone.IsNullOrEmpty())
                {
                    query.Where(p => p.SLSMPhone == model.SLSMPhone);
                }
                if (!model.ContractContext.IsNullOrEmpty())
                {
                    query.Where(p => p.ContractContext == model.ContractContext);
                }
                if (!model.buyerCount.IsNullOrEmpty())
                {
                    query.Where(p => p.buyerCount == model.buyerCount);
                }
                if (!model.buyerContext.IsNullOrEmpty())
                {
                    query.Where(p => p.buyerContext == model.buyerContext);
                }
                if (!model.producerId.IsNullOrEmpty())
                {
                    query.Where(p => p.producerId == model.producerId);
                }
                if (!model.FactoryNumber.IsNullOrEmpty())
                {
                    query.Where(p => p.FactoryNumber == model.FactoryNumber);
                }
                if (!model.PriceTag.IsNullOrEmpty())
                {
                    query.Where(p => p.PriceTag == model.PriceTag);
                }
                if (!model.producerIdName.IsNullOrEmpty())
                {
                    query.Where(p => p.producerIdName == model.producerIdName);
                }
                if (!model.producerName.IsNullOrEmpty())
                {
                    query.Where(p => p.producerName == model.producerName);
                }
                if (!model.buyerStatus.IsNullOrEmpty())
                {
                    query.Where(p => p.buyerStatus == model.buyerStatus);
                }
                if (!model.checkStatus.IsNullOrEmpty())
                {
                    query.Where(p => p.checkStatus == model.checkStatus);
                }
                if (!model.ProductNo.IsNullOrEmpty())
                {
                    query.Where(p => p.ProductNo == model.ProductNo);
                }
                if (!model.NetWeight.IsNullOrEmpty())
                {
                    query.Where(p => p.NetWeight == model.NetWeight);
                }
                if (!model.NumOuterBoxes.IsNullOrEmpty())
                {
                    query.Where(p => p.NumOuterBoxes == model.NumOuterBoxes);
                }
                if (!model.NumMiddleBoxes.IsNullOrEmpty())
                {
                    query.Where(p => p.NumMiddleBoxes == model.NumMiddleBoxes);
                }
                if (!model.OuterBoxesHeight.IsNullOrEmpty())
                {
                    query.Where(p => p.OuterBoxesHeight == model.OuterBoxesHeight);
                }
                if (!model.OuterBoxesLength.IsNullOrEmpty())
                {
                    query.Where(p => p.OuterBoxesLength == model.OuterBoxesLength);
                }
                if (!model.OuterBoxesWidth.IsNullOrEmpty())
                {
                    query.Where(p => p.OuterBoxesWidth == model.OuterBoxesWidth);
                }
                if (!model.ProductDesibe.IsNullOrEmpty())
                {
                    query.Where(p => p.ProductDesibe == model.ProductDesibe);
                }
                if (!model.ChinaDescribe.IsNullOrEmpty())
                {
                    query.Where(p => p.ChinaDescribe == model.ChinaDescribe);
                }
                if (!model.ParentCount.IsNullOrEmpty())
                {
                    query.Where(p => p.ParentCount == model.ParentCount);
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
        public Deliver_Buyer_View SelectById(int KeyId, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var query = new LambdaQuery<Deliver_Buyer_View>();
            return query.GetQueryList(connection, transaction).FirstOrDefault();
        }


        /// <summary>
        /// 根据主键筛选数据
        /// </summary>
        /// <param name="KeyId">主键Id</param>
        /// <param name="connection">连接</param>
        /// <param name="transaction">事务</param>
        /// <returns>是否成功</returns>
        public List<Deliver_Buyer_View> SelectByKeys(string Key,List<string> KeyIds, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var query = new LambdaQuery<Deliver_Buyer_View>();
            if("id" == Key.ToLowerInvariant())
            {
                query.Where(p => p.Id.In(KeyIds));
            }
            if("buyerid" == Key.ToLowerInvariant())
            {
                query.Where(p => p.buyerId.In(KeyIds));
            }
            if("buyertime" == Key.ToLowerInvariant())
            {
                query.Where(p => p.buyerTime.In(KeyIds));
            }
            if("raw_materialsid" == Key.ToLowerInvariant())
            {
                query.Where(p => p.raw_materialsId.In(KeyIds));
            }
            if("chinaproductname" == Key.ToLowerInvariant())
            {
                query.Where(p => p.ChinaProductName.In(KeyIds));
            }
            if("specification" == Key.ToLowerInvariant())
            {
                query.Where(p => p.Specification.In(KeyIds));
            }
            if("chinaunit" == Key.ToLowerInvariant())
            {
                query.Where(p => p.ChinaUnit.In(KeyIds));
            }
            if("isstatus" == Key.ToLowerInvariant())
            {
                query.Where(p => p.IsStatus.In(KeyIds));
            }
            if("delivermoney" == Key.ToLowerInvariant())
            {
                query.Where(p => p.DeliverMoney.In(KeyIds));
            }
            if("buyerprice" == Key.ToLowerInvariant())
            {
                query.Where(p => p.buyerPrice.In(KeyIds));
            }
            if("color" == Key.ToLowerInvariant())
            {
                query.Where(p => p.Color.In(KeyIds));
            }
            if("delivercountext" == Key.ToLowerInvariant())
            {
                query.Where(p => p.DeliverCountext.In(KeyIds));
            }
            if("alreadyquantity" == Key.ToLowerInvariant())
            {
                query.Where(p => p.AlreadyQuantity.In(KeyIds));
            }
            if("wantmoney" == Key.ToLowerInvariant())
            {
                query.Where(p => p.wantmoney.In(KeyIds));
            }
            if("wanttime" == Key.ToLowerInvariant())
            {
                query.Where(p => p.wantTime.In(KeyIds));
            }
            if("buyermoney" == Key.ToLowerInvariant())
            {
                query.Where(p => p.buyerMoney.In(KeyIds));
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
            if("slsmemail" == Key.ToLowerInvariant())
            {
                query.Where(p => p.SLSMEmail.In(KeyIds));
            }
            if("slsmfaxnumber" == Key.ToLowerInvariant())
            {
                query.Where(p => p.SLSMFaxNumber.In(KeyIds));
            }
            if("slsmphone" == Key.ToLowerInvariant())
            {
                query.Where(p => p.SLSMPhone.In(KeyIds));
            }
            if("contractcontext" == Key.ToLowerInvariant())
            {
                query.Where(p => p.ContractContext.In(KeyIds));
            }
            if("buyercount" == Key.ToLowerInvariant())
            {
                query.Where(p => p.buyerCount.In(KeyIds));
            }
            if("buyercontext" == Key.ToLowerInvariant())
            {
                query.Where(p => p.buyerContext.In(KeyIds));
            }
            if("producerid" == Key.ToLowerInvariant())
            {
                query.Where(p => p.producerId.In(KeyIds));
            }
            if("factorynumber" == Key.ToLowerInvariant())
            {
                query.Where(p => p.FactoryNumber.In(KeyIds));
            }
            if("pricetag" == Key.ToLowerInvariant())
            {
                query.Where(p => p.PriceTag.In(KeyIds));
            }
            if("produceridname" == Key.ToLowerInvariant())
            {
                query.Where(p => p.producerIdName.In(KeyIds));
            }
            if("producername" == Key.ToLowerInvariant())
            {
                query.Where(p => p.producerName.In(KeyIds));
            }
            if("buyerstatus" == Key.ToLowerInvariant())
            {
                query.Where(p => p.buyerStatus.In(KeyIds));
            }
            if("checkstatus" == Key.ToLowerInvariant())
            {
                query.Where(p => p.checkStatus.In(KeyIds));
            }
            if("productno" == Key.ToLowerInvariant())
            {
                query.Where(p => p.ProductNo.In(KeyIds));
            }
            if("netweight" == Key.ToLowerInvariant())
            {
                query.Where(p => p.NetWeight.In(KeyIds));
            }
            if("numouterboxes" == Key.ToLowerInvariant())
            {
                query.Where(p => p.NumOuterBoxes.In(KeyIds));
            }
            if("nummiddleboxes" == Key.ToLowerInvariant())
            {
                query.Where(p => p.NumMiddleBoxes.In(KeyIds));
            }
            if("outerboxesheight" == Key.ToLowerInvariant())
            {
                query.Where(p => p.OuterBoxesHeight.In(KeyIds));
            }
            if("outerboxeslength" == Key.ToLowerInvariant())
            {
                query.Where(p => p.OuterBoxesLength.In(KeyIds));
            }
            if("outerboxeswidth" == Key.ToLowerInvariant())
            {
                query.Where(p => p.OuterBoxesWidth.In(KeyIds));
            }
            if("productdesibe" == Key.ToLowerInvariant())
            {
                query.Where(p => p.ProductDesibe.In(KeyIds));
            }
            if("chinadescribe" == Key.ToLowerInvariant())
            {
                query.Where(p => p.ChinaDescribe.In(KeyIds));
            }
            if("parentcount" == Key.ToLowerInvariant())
            {
                query.Where(p => p.ParentCount.In(KeyIds));
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
        public List<Deliver_Buyer_View> SelectByPage(string Key, int start, int PageSize, bool desc = true,Deliver_Buyer_View model = null, string SelectFiled = null, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var query = new LambdaQuery<Deliver_Buyer_View>();
            if (model != null)
            {
                if (!model.Id.IsNullOrEmpty())
                {
                    query.Where(p => p.Id == model.Id);
                }
                if (!model.buyerId.IsNullOrEmpty())
                {
                    query.Where(p => p.buyerId == model.buyerId);
                }
                if (!model.buyerTime.IsNullOrEmpty())
                {
                    query.Where(p => p.buyerTime == model.buyerTime);
                }
                if (!model.raw_materialsId.IsNullOrEmpty())
                {
                    query.Where(p => p.raw_materialsId == model.raw_materialsId);
                }
                if (!model.ChinaProductName.IsNullOrEmpty())
                {
                    query.Where(p => p.ChinaProductName == model.ChinaProductName);
                }
                if (!model.Specification.IsNullOrEmpty())
                {
                    query.Where(p => p.Specification == model.Specification);
                }
                if (!model.ChinaUnit.IsNullOrEmpty())
                {
                    query.Where(p => p.ChinaUnit == model.ChinaUnit);
                }
                if (!model.IsStatus.IsNullOrEmpty())
                {
                    query.Where(p => p.IsStatus == model.IsStatus);
                }
                if (!model.DeliverMoney.IsNullOrEmpty())
                {
                    query.Where(p => p.DeliverMoney == model.DeliverMoney);
                }
                if (!model.buyerPrice.IsNullOrEmpty())
                {
                    query.Where(p => p.buyerPrice == model.buyerPrice);
                }
                if (!model.Color.IsNullOrEmpty())
                {
                    query.Where(p => p.Color == model.Color);
                }
                if (!model.DeliverCountext.IsNullOrEmpty())
                {
                    query.Where(p => p.DeliverCountext == model.DeliverCountext);
                }
                if (!model.AlreadyQuantity.IsNullOrEmpty())
                {
                    query.Where(p => p.AlreadyQuantity == model.AlreadyQuantity);
                }
                if (!model.wantmoney.IsNullOrEmpty())
                {
                    query.Where(p => p.wantmoney == model.wantmoney);
                }
                if (!model.wantTime.IsNullOrEmpty())
                {
                    query.Where(p => p.wantTime == model.wantTime);
                }
                if (!model.buyerMoney.IsNullOrEmpty())
                {
                    query.Where(p => p.buyerMoney == model.buyerMoney);
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
                if (!model.SLSMEmail.IsNullOrEmpty())
                {
                    query.Where(p => p.SLSMEmail == model.SLSMEmail);
                }
                if (!model.SLSMFaxNumber.IsNullOrEmpty())
                {
                    query.Where(p => p.SLSMFaxNumber == model.SLSMFaxNumber);
                }
                if (!model.SLSMPhone.IsNullOrEmpty())
                {
                    query.Where(p => p.SLSMPhone == model.SLSMPhone);
                }
                if (!model.ContractContext.IsNullOrEmpty())
                {
                    query.Where(p => p.ContractContext == model.ContractContext);
                }
                if (!model.buyerCount.IsNullOrEmpty())
                {
                    query.Where(p => p.buyerCount == model.buyerCount);
                }
                if (!model.buyerContext.IsNullOrEmpty())
                {
                    query.Where(p => p.buyerContext == model.buyerContext);
                }
                if (!model.producerId.IsNullOrEmpty())
                {
                    query.Where(p => p.producerId == model.producerId);
                }
                if (!model.FactoryNumber.IsNullOrEmpty())
                {
                    query.Where(p => p.FactoryNumber == model.FactoryNumber);
                }
                if (!model.PriceTag.IsNullOrEmpty())
                {
                    query.Where(p => p.PriceTag == model.PriceTag);
                }
                if (!model.producerIdName.IsNullOrEmpty())
                {
                    query.Where(p => p.producerIdName == model.producerIdName);
                }
                if (!model.producerName.IsNullOrEmpty())
                {
                    query.Where(p => p.producerName == model.producerName);
                }
                if (!model.buyerStatus.IsNullOrEmpty())
                {
                    query.Where(p => p.buyerStatus == model.buyerStatus);
                }
                if (!model.checkStatus.IsNullOrEmpty())
                {
                    query.Where(p => p.checkStatus == model.checkStatus);
                }
                if (!model.ProductNo.IsNullOrEmpty())
                {
                    query.Where(p => p.ProductNo == model.ProductNo);
                }
                if (!model.NetWeight.IsNullOrEmpty())
                {
                    query.Where(p => p.NetWeight == model.NetWeight);
                }
                if (!model.NumOuterBoxes.IsNullOrEmpty())
                {
                    query.Where(p => p.NumOuterBoxes == model.NumOuterBoxes);
                }
                if (!model.NumMiddleBoxes.IsNullOrEmpty())
                {
                    query.Where(p => p.NumMiddleBoxes == model.NumMiddleBoxes);
                }
                if (!model.OuterBoxesHeight.IsNullOrEmpty())
                {
                    query.Where(p => p.OuterBoxesHeight == model.OuterBoxesHeight);
                }
                if (!model.OuterBoxesLength.IsNullOrEmpty())
                {
                    query.Where(p => p.OuterBoxesLength == model.OuterBoxesLength);
                }
                if (!model.OuterBoxesWidth.IsNullOrEmpty())
                {
                    query.Where(p => p.OuterBoxesWidth == model.OuterBoxesWidth);
                }
                if (!model.ProductDesibe.IsNullOrEmpty())
                {
                    query.Where(p => p.ProductDesibe == model.ProductDesibe);
                }
                if (!model.ChinaDescribe.IsNullOrEmpty())
                {
                    query.Where(p => p.ChinaDescribe == model.ChinaDescribe);
                }
                if (!model.ParentCount.IsNullOrEmpty())
                {
                    query.Where(p => p.ParentCount == model.ParentCount);
                }
            }
            if (SelectFiled != null)
            {
                SelectFiled = SelectFiled.ToLowerInvariant();
                if (SelectFiled.Contains("id,"))
                {
                    query.Select(p => new { p.Id });
                }
                if (SelectFiled.Contains("buyerid,"))
                {
                    query.Select(p => new { p.buyerId });
                }
                if (SelectFiled.Contains("buyertime,"))
                {
                    query.Select(p => new { p.buyerTime });
                }
                if (SelectFiled.Contains("raw_materialsid,"))
                {
                    query.Select(p => new { p.raw_materialsId });
                }
                if (SelectFiled.Contains("chinaproductname,"))
                {
                    query.Select(p => new { p.ChinaProductName });
                }
                if (SelectFiled.Contains("specification,"))
                {
                    query.Select(p => new { p.Specification });
                }
                if (SelectFiled.Contains("chinaunit,"))
                {
                    query.Select(p => new { p.ChinaUnit });
                }
                if (SelectFiled.Contains("isstatus,"))
                {
                    query.Select(p => new { p.IsStatus });
                }
                if (SelectFiled.Contains("delivermoney,"))
                {
                    query.Select(p => new { p.DeliverMoney });
                }
                if (SelectFiled.Contains("buyerprice,"))
                {
                    query.Select(p => new { p.buyerPrice });
                }
                if (SelectFiled.Contains("color,"))
                {
                    query.Select(p => new { p.Color });
                }
                if (SelectFiled.Contains("delivercountext,"))
                {
                    query.Select(p => new { p.DeliverCountext });
                }
                if (SelectFiled.Contains("alreadyquantity,"))
                {
                    query.Select(p => new { p.AlreadyQuantity });
                }
                if (SelectFiled.Contains("wantmoney,"))
                {
                    query.Select(p => new { p.wantmoney });
                }
                if (SelectFiled.Contains("wanttime,"))
                {
                    query.Select(p => new { p.wantTime });
                }
                if (SelectFiled.Contains("buyermoney,"))
                {
                    query.Select(p => new { p.buyerMoney });
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
                if (SelectFiled.Contains("slsmemail,"))
                {
                    query.Select(p => new { p.SLSMEmail });
                }
                if (SelectFiled.Contains("slsmfaxnumber,"))
                {
                    query.Select(p => new { p.SLSMFaxNumber });
                }
                if (SelectFiled.Contains("slsmphone,"))
                {
                    query.Select(p => new { p.SLSMPhone });
                }
                if (SelectFiled.Contains("contractcontext,"))
                {
                    query.Select(p => new { p.ContractContext });
                }
                if (SelectFiled.Contains("buyercount,"))
                {
                    query.Select(p => new { p.buyerCount });
                }
                if (SelectFiled.Contains("buyercontext,"))
                {
                    query.Select(p => new { p.buyerContext });
                }
                if (SelectFiled.Contains("producerid,"))
                {
                    query.Select(p => new { p.producerId });
                }
                if (SelectFiled.Contains("factorynumber,"))
                {
                    query.Select(p => new { p.FactoryNumber });
                }
                if (SelectFiled.Contains("pricetag,"))
                {
                    query.Select(p => new { p.PriceTag });
                }
                if (SelectFiled.Contains("produceridname,"))
                {
                    query.Select(p => new { p.producerIdName });
                }
                if (SelectFiled.Contains("producername,"))
                {
                    query.Select(p => new { p.producerName });
                }
                if (SelectFiled.Contains("buyerstatus,"))
                {
                    query.Select(p => new { p.buyerStatus });
                }
                if (SelectFiled.Contains("checkstatus,"))
                {
                    query.Select(p => new { p.checkStatus });
                }
                if (SelectFiled.Contains("productno,"))
                {
                    query.Select(p => new { p.ProductNo });
                }
                if (SelectFiled.Contains("netweight,"))
                {
                    query.Select(p => new { p.NetWeight });
                }
                if (SelectFiled.Contains("numouterboxes,"))
                {
                    query.Select(p => new { p.NumOuterBoxes });
                }
                if (SelectFiled.Contains("nummiddleboxes,"))
                {
                    query.Select(p => new { p.NumMiddleBoxes });
                }
                if (SelectFiled.Contains("outerboxesheight,"))
                {
                    query.Select(p => new { p.OuterBoxesHeight });
                }
                if (SelectFiled.Contains("outerboxeslength,"))
                {
                    query.Select(p => new { p.OuterBoxesLength });
                }
                if (SelectFiled.Contains("outerboxeswidth,"))
                {
                    query.Select(p => new { p.OuterBoxesWidth });
                }
                if (SelectFiled.Contains("productdesibe,"))
                {
                    query.Select(p => new { p.ProductDesibe });
                }
                if (SelectFiled.Contains("chinadescribe,"))
                {
                    query.Select(p => new { p.ChinaDescribe });
                }
                if (SelectFiled.Contains("parentcount,"))
                {
                    query.Select(p => new { p.ParentCount });
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
