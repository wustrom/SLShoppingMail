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
    public partial class Producer_Invoice_ViewOper : SingleTon<Producer_Invoice_ViewOper>
    {
        /// <summary>
        /// 筛选全部数据
        /// </summary>
        /// <param name="model">模型</param>
        /// <param name="connection">连接</param>
        /// <param name="transaction">事务</param>
        /// <returns>对象列表</returns>
        public List<Producer_Invoice_View> SelectAll(Producer_Invoice_View model = null, string SelectFiled = null, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var query = new LambdaQuery<Producer_Invoice_View>();
            if (model != null)
            {
                if (!model.Id.IsNullOrEmpty())
                {
                    query.Where(p => p.Id == model.Id);
                }
                if (!model.ProducerId.IsNullOrEmpty())
                {
                    query.Where(p => p.ProducerId == model.ProducerId);
                }
                if (!model.InvoiceNumber.IsNullOrEmpty())
                {
                    query.Where(p => p.InvoiceNumber == model.InvoiceNumber);
                }
                if (!model.InvoiceTime.IsNullOrEmpty())
                {
                    query.Where(p => p.InvoiceTime == model.InvoiceTime);
                }
                if (!model.InvoiceMoney.IsNullOrEmpty())
                {
                    query.Where(p => p.InvoiceMoney == model.InvoiceMoney);
                }
                if (!model.InvoiceContext.IsNullOrEmpty())
                {
                    query.Where(p => p.InvoiceContext == model.InvoiceContext);
                }
                if (!model.CompanyName.IsNullOrEmpty())
                {
                    query.Where(p => p.CompanyName == model.CompanyName);
                }
                if (!model.InvoiceIdentify.IsNullOrEmpty())
                {
                    query.Where(p => p.InvoiceIdentify == model.InvoiceIdentify);
                }
                if (!model.InvoicePhone.IsNullOrEmpty())
                {
                    query.Where(p => p.InvoicePhone == model.InvoicePhone);
                }
                if (!model.InvoiceAddress.IsNullOrEmpty())
                {
                    query.Where(p => p.InvoiceAddress == model.InvoiceAddress);
                }
                if (!model.InvoiceBank.IsNullOrEmpty())
                {
                    query.Where(p => p.InvoiceBank == model.InvoiceBank);
                }
                if (!model.Name.IsNullOrEmpty())
                {
                    query.Where(p => p.Name == model.Name);
                }
                if (!model.identify.IsNullOrEmpty())
                {
                    query.Where(p => p.identify == model.identify);
                }
                if (!model.Address.IsNullOrEmpty())
                {
                    query.Where(p => p.Address == model.Address);
                }
                if (!model.AccountPeriod.IsNullOrEmpty())
                {
                    query.Where(p => p.AccountPeriod == model.AccountPeriod);
                }
                if (!model.Bank.IsNullOrEmpty())
                {
                    query.Where(p => p.Bank == model.Bank);
                }
                if (!model.IsDelete.IsNullOrEmpty())
                {
                    query.Where(p => p.IsDelete == model.IsDelete);
                }
            }
            if (SelectFiled != null)
            {
                SelectFiled = SelectFiled.ToLowerInvariant();
                if (SelectFiled.Contains("id,"))
                {
                    query.Select(p => new { p.Id });
                }
                if (SelectFiled.Contains("producerid,"))
                {
                    query.Select(p => new { p.ProducerId });
                }
                if (SelectFiled.Contains("invoicenumber,"))
                {
                    query.Select(p => new { p.InvoiceNumber });
                }
                if (SelectFiled.Contains("invoicetime,"))
                {
                    query.Select(p => new { p.InvoiceTime });
                }
                if (SelectFiled.Contains("invoicemoney,"))
                {
                    query.Select(p => new { p.InvoiceMoney });
                }
                if (SelectFiled.Contains("invoicecontext,"))
                {
                    query.Select(p => new { p.InvoiceContext });
                }
                if (SelectFiled.Contains("companyname,"))
                {
                    query.Select(p => new { p.CompanyName });
                }
                if (SelectFiled.Contains("invoiceidentify,"))
                {
                    query.Select(p => new { p.InvoiceIdentify });
                }
                if (SelectFiled.Contains("invoicephone,"))
                {
                    query.Select(p => new { p.InvoicePhone });
                }
                if (SelectFiled.Contains("invoiceaddress,"))
                {
                    query.Select(p => new { p.InvoiceAddress });
                }
                if (SelectFiled.Contains("invoicebank,"))
                {
                    query.Select(p => new { p.InvoiceBank });
                }
                if (SelectFiled.Contains("name,"))
                {
                    query.Select(p => new { p.Name });
                }
                if (SelectFiled.Contains("identify,"))
                {
                    query.Select(p => new { p.identify });
                }
                if (SelectFiled.Contains("address,"))
                {
                    query.Select(p => new { p.Address });
                }
                if (SelectFiled.Contains("accountperiod,"))
                {
                    query.Select(p => new { p.AccountPeriod });
                }
                if (SelectFiled.Contains("bank,"))
                {
                    query.Select(p => new { p.Bank });
                }
                if (SelectFiled.Contains("isdelete,"))
                {
                    query.Select(p => new { p.IsDelete });
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
        public int SelectCount(Producer_Invoice_View model = null, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var query = new LambdaQuery<Producer_Invoice_View>();
            if (model != null)
            {
                if (!model.Id.IsNullOrEmpty())
                {
                    query.Where(p => p.Id == model.Id);
                }
                if (!model.ProducerId.IsNullOrEmpty())
                {
                    query.Where(p => p.ProducerId == model.ProducerId);
                }
                if (!model.InvoiceNumber.IsNullOrEmpty())
                {
                    query.Where(p => p.InvoiceNumber == model.InvoiceNumber);
                }
                if (!model.InvoiceTime.IsNullOrEmpty())
                {
                    query.Where(p => p.InvoiceTime == model.InvoiceTime);
                }
                if (!model.InvoiceMoney.IsNullOrEmpty())
                {
                    query.Where(p => p.InvoiceMoney == model.InvoiceMoney);
                }
                if (!model.InvoiceContext.IsNullOrEmpty())
                {
                    query.Where(p => p.InvoiceContext == model.InvoiceContext);
                }
                if (!model.CompanyName.IsNullOrEmpty())
                {
                    query.Where(p => p.CompanyName == model.CompanyName);
                }
                if (!model.InvoiceIdentify.IsNullOrEmpty())
                {
                    query.Where(p => p.InvoiceIdentify == model.InvoiceIdentify);
                }
                if (!model.InvoicePhone.IsNullOrEmpty())
                {
                    query.Where(p => p.InvoicePhone == model.InvoicePhone);
                }
                if (!model.InvoiceAddress.IsNullOrEmpty())
                {
                    query.Where(p => p.InvoiceAddress == model.InvoiceAddress);
                }
                if (!model.InvoiceBank.IsNullOrEmpty())
                {
                    query.Where(p => p.InvoiceBank == model.InvoiceBank);
                }
                if (!model.Name.IsNullOrEmpty())
                {
                    query.Where(p => p.Name == model.Name);
                }
                if (!model.identify.IsNullOrEmpty())
                {
                    query.Where(p => p.identify == model.identify);
                }
                if (!model.Address.IsNullOrEmpty())
                {
                    query.Where(p => p.Address == model.Address);
                }
                if (!model.AccountPeriod.IsNullOrEmpty())
                {
                    query.Where(p => p.AccountPeriod == model.AccountPeriod);
                }
                if (!model.Bank.IsNullOrEmpty())
                {
                    query.Where(p => p.Bank == model.Bank);
                }
                if (!model.IsDelete.IsNullOrEmpty())
                {
                    query.Where(p => p.IsDelete == model.IsDelete);
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
        public Producer_Invoice_View SelectById(int KeyId, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var query = new LambdaQuery<Producer_Invoice_View>();
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
        public List<Producer_Invoice_View> SelectByKeys(string Key,List<string> KeyIds, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var query = new LambdaQuery<Producer_Invoice_View>();
            if("id" == Key.ToLowerInvariant())
            {
                query.Where(p => p.Id.In(KeyIds));
            }
            if("producerid" == Key.ToLowerInvariant())
            {
                query.Where(p => p.ProducerId.In(KeyIds));
            }
            if("invoicenumber" == Key.ToLowerInvariant())
            {
                query.Where(p => p.InvoiceNumber.In(KeyIds));
            }
            if("invoicetime" == Key.ToLowerInvariant())
            {
                query.Where(p => p.InvoiceTime.In(KeyIds));
            }
            if("invoicemoney" == Key.ToLowerInvariant())
            {
                query.Where(p => p.InvoiceMoney.In(KeyIds));
            }
            if("invoicecontext" == Key.ToLowerInvariant())
            {
                query.Where(p => p.InvoiceContext.In(KeyIds));
            }
            if("companyname" == Key.ToLowerInvariant())
            {
                query.Where(p => p.CompanyName.In(KeyIds));
            }
            if("invoiceidentify" == Key.ToLowerInvariant())
            {
                query.Where(p => p.InvoiceIdentify.In(KeyIds));
            }
            if("invoicephone" == Key.ToLowerInvariant())
            {
                query.Where(p => p.InvoicePhone.In(KeyIds));
            }
            if("invoiceaddress" == Key.ToLowerInvariant())
            {
                query.Where(p => p.InvoiceAddress.In(KeyIds));
            }
            if("invoicebank" == Key.ToLowerInvariant())
            {
                query.Where(p => p.InvoiceBank.In(KeyIds));
            }
            if("name" == Key.ToLowerInvariant())
            {
                query.Where(p => p.Name.In(KeyIds));
            }
            if("identify" == Key.ToLowerInvariant())
            {
                query.Where(p => p.identify.In(KeyIds));
            }
            if("address" == Key.ToLowerInvariant())
            {
                query.Where(p => p.Address.In(KeyIds));
            }
            if("accountperiod" == Key.ToLowerInvariant())
            {
                query.Where(p => p.AccountPeriod.In(KeyIds));
            }
            if("bank" == Key.ToLowerInvariant())
            {
                query.Where(p => p.Bank.In(KeyIds));
            }
            if("isdelete" == Key.ToLowerInvariant())
            {
                query.Where(p => p.IsDelete.In(KeyIds));
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
        public List<Producer_Invoice_View> SelectByPage(string Key, int start, int PageSize, bool desc = true,Producer_Invoice_View model = null, string SelectFiled = null, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var query = new LambdaQuery<Producer_Invoice_View>();
            if (model != null)
            {
                if (!model.Id.IsNullOrEmpty())
                {
                    query.Where(p => p.Id == model.Id);
                }
                if (!model.ProducerId.IsNullOrEmpty())
                {
                    query.Where(p => p.ProducerId == model.ProducerId);
                }
                if (!model.InvoiceNumber.IsNullOrEmpty())
                {
                    query.Where(p => p.InvoiceNumber == model.InvoiceNumber);
                }
                if (!model.InvoiceTime.IsNullOrEmpty())
                {
                    query.Where(p => p.InvoiceTime == model.InvoiceTime);
                }
                if (!model.InvoiceMoney.IsNullOrEmpty())
                {
                    query.Where(p => p.InvoiceMoney == model.InvoiceMoney);
                }
                if (!model.InvoiceContext.IsNullOrEmpty())
                {
                    query.Where(p => p.InvoiceContext == model.InvoiceContext);
                }
                if (!model.CompanyName.IsNullOrEmpty())
                {
                    query.Where(p => p.CompanyName == model.CompanyName);
                }
                if (!model.InvoiceIdentify.IsNullOrEmpty())
                {
                    query.Where(p => p.InvoiceIdentify == model.InvoiceIdentify);
                }
                if (!model.InvoicePhone.IsNullOrEmpty())
                {
                    query.Where(p => p.InvoicePhone == model.InvoicePhone);
                }
                if (!model.InvoiceAddress.IsNullOrEmpty())
                {
                    query.Where(p => p.InvoiceAddress == model.InvoiceAddress);
                }
                if (!model.InvoiceBank.IsNullOrEmpty())
                {
                    query.Where(p => p.InvoiceBank == model.InvoiceBank);
                }
                if (!model.Name.IsNullOrEmpty())
                {
                    query.Where(p => p.Name == model.Name);
                }
                if (!model.identify.IsNullOrEmpty())
                {
                    query.Where(p => p.identify == model.identify);
                }
                if (!model.Address.IsNullOrEmpty())
                {
                    query.Where(p => p.Address == model.Address);
                }
                if (!model.AccountPeriod.IsNullOrEmpty())
                {
                    query.Where(p => p.AccountPeriod == model.AccountPeriod);
                }
                if (!model.Bank.IsNullOrEmpty())
                {
                    query.Where(p => p.Bank == model.Bank);
                }
                if (!model.IsDelete.IsNullOrEmpty())
                {
                    query.Where(p => p.IsDelete == model.IsDelete);
                }
            }
            if (SelectFiled != null)
            {
                SelectFiled = SelectFiled.ToLowerInvariant();
                if (SelectFiled.Contains("id,"))
                {
                    query.Select(p => new { p.Id });
                }
                if (SelectFiled.Contains("producerid,"))
                {
                    query.Select(p => new { p.ProducerId });
                }
                if (SelectFiled.Contains("invoicenumber,"))
                {
                    query.Select(p => new { p.InvoiceNumber });
                }
                if (SelectFiled.Contains("invoicetime,"))
                {
                    query.Select(p => new { p.InvoiceTime });
                }
                if (SelectFiled.Contains("invoicemoney,"))
                {
                    query.Select(p => new { p.InvoiceMoney });
                }
                if (SelectFiled.Contains("invoicecontext,"))
                {
                    query.Select(p => new { p.InvoiceContext });
                }
                if (SelectFiled.Contains("companyname,"))
                {
                    query.Select(p => new { p.CompanyName });
                }
                if (SelectFiled.Contains("invoiceidentify,"))
                {
                    query.Select(p => new { p.InvoiceIdentify });
                }
                if (SelectFiled.Contains("invoicephone,"))
                {
                    query.Select(p => new { p.InvoicePhone });
                }
                if (SelectFiled.Contains("invoiceaddress,"))
                {
                    query.Select(p => new { p.InvoiceAddress });
                }
                if (SelectFiled.Contains("invoicebank,"))
                {
                    query.Select(p => new { p.InvoiceBank });
                }
                if (SelectFiled.Contains("name,"))
                {
                    query.Select(p => new { p.Name });
                }
                if (SelectFiled.Contains("identify,"))
                {
                    query.Select(p => new { p.identify });
                }
                if (SelectFiled.Contains("address,"))
                {
                    query.Select(p => new { p.Address });
                }
                if (SelectFiled.Contains("accountperiod,"))
                {
                    query.Select(p => new { p.AccountPeriod });
                }
                if (SelectFiled.Contains("bank,"))
                {
                    query.Select(p => new { p.Bank });
                }
                if (SelectFiled.Contains("isdelete,"))
                {
                    query.Select(p => new { p.IsDelete });
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
