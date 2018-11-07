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
    public partial class ProducerinvoiceOper : SingleTon<ProducerinvoiceOper>
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
            var delete = new LambdaDelete<Producerinvoice>();
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
        public bool DeleteModel(Producerinvoice model = null, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var delete = new LambdaDelete<Producerinvoice>();
            if (model != null)
            {
                if (!model.Id.IsNullOrEmpty())
                {
                    delete.Where(p => p.Id == model.Id);
                }
                if (!model.ProducerId.IsNullOrEmpty())
                {
                    delete.Where(p => p.ProducerId == model.ProducerId);
                }
                if (!model.CompanyName.IsNullOrEmpty())
                {
                    delete.Where(p => p.CompanyName == model.CompanyName);
                }
                if (!model.InvoiceNumber.IsNullOrEmpty())
                {
                    delete.Where(p => p.InvoiceNumber == model.InvoiceNumber);
                }
                if (!model.InvoiceTime.IsNullOrEmpty())
                {
                    delete.Where(p => p.InvoiceTime == model.InvoiceTime);
                }
                if (!model.InvoiceMoney.IsNullOrEmpty())
                {
                    delete.Where(p => p.InvoiceMoney == model.InvoiceMoney);
                }
                if (!model.InvoiceIdentify.IsNullOrEmpty())
                {
                    delete.Where(p => p.InvoiceIdentify == model.InvoiceIdentify);
                }
                if (!model.InvoicePhone.IsNullOrEmpty())
                {
                    delete.Where(p => p.InvoicePhone == model.InvoicePhone);
                }
                if (!model.InvoiceAddress.IsNullOrEmpty())
                {
                    delete.Where(p => p.InvoiceAddress == model.InvoiceAddress);
                }
                if (!model.InvoiceBank.IsNullOrEmpty())
                {
                    delete.Where(p => p.InvoiceBank == model.InvoiceBank);
                }
                if (!model.InvoiceContext.IsNullOrEmpty())
                {
                    delete.Where(p => p.InvoiceContext == model.InvoiceContext);
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
        public bool Update(Producerinvoice model, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var update = new LambdaUpdate<Producerinvoice>();
            if (!model.Id.IsNullOrEmpty())
            {
                update.Where(p => p.Id == model.Id);
            }
            if (!model.ProducerId.IsNullOrEmpty())
            {
                update.Set(p => p.ProducerId == model.ProducerId);
            }
            if (!model.CompanyName.IsNullOrEmpty())
            {
                update.Set(p => p.CompanyName == model.CompanyName);
            }
            if (!model.InvoiceNumber.IsNullOrEmpty())
            {
                update.Set(p => p.InvoiceNumber == model.InvoiceNumber);
            }
            if (!model.InvoiceTime.IsNullOrEmpty())
            {
                update.Set(p => p.InvoiceTime == model.InvoiceTime);
            }
            if (!model.InvoiceMoney.IsNullOrEmpty())
            {
                update.Set(p => p.InvoiceMoney == model.InvoiceMoney);
            }
            if (!model.InvoiceIdentify.IsNullOrEmpty())
            {
                update.Set(p => p.InvoiceIdentify == model.InvoiceIdentify);
            }
            if (!model.InvoicePhone.IsNullOrEmpty())
            {
                update.Set(p => p.InvoicePhone == model.InvoicePhone);
            }
            if (!model.InvoiceAddress.IsNullOrEmpty())
            {
                update.Set(p => p.InvoiceAddress == model.InvoiceAddress);
            }
            if (!model.InvoiceBank.IsNullOrEmpty())
            {
                update.Set(p => p.InvoiceBank == model.InvoiceBank);
            }
            if (!model.InvoiceContext.IsNullOrEmpty())
            {
                update.Set(p => p.InvoiceContext == model.InvoiceContext);
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
        public bool Insert(Producerinvoice model, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var insert = new LambdaInsert<Producerinvoice>();
            if (!model.ProducerId.IsNullOrEmpty())
            {
                insert.Insert(p => p.ProducerId == model.ProducerId);
            }
            if (!model.CompanyName.IsNullOrEmpty())
            {
                insert.Insert(p => p.CompanyName == model.CompanyName);
            }
            if (!model.InvoiceNumber.IsNullOrEmpty())
            {
                insert.Insert(p => p.InvoiceNumber == model.InvoiceNumber);
            }
            if (!model.InvoiceTime.IsNullOrEmpty())
            {
                insert.Insert(p => p.InvoiceTime == model.InvoiceTime);
            }
            if (!model.InvoiceMoney.IsNullOrEmpty())
            {
                insert.Insert(p => p.InvoiceMoney == model.InvoiceMoney);
            }
            if (!model.InvoiceIdentify.IsNullOrEmpty())
            {
                insert.Insert(p => p.InvoiceIdentify == model.InvoiceIdentify);
            }
            if (!model.InvoicePhone.IsNullOrEmpty())
            {
                insert.Insert(p => p.InvoicePhone == model.InvoicePhone);
            }
            if (!model.InvoiceAddress.IsNullOrEmpty())
            {
                insert.Insert(p => p.InvoiceAddress == model.InvoiceAddress);
            }
            if (!model.InvoiceBank.IsNullOrEmpty())
            {
                insert.Insert(p => p.InvoiceBank == model.InvoiceBank);
            }
            if (!model.InvoiceContext.IsNullOrEmpty())
            {
                insert.Insert(p => p.InvoiceContext == model.InvoiceContext);
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
        public int InsertReturnKey(Producerinvoice model, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var insert = new LambdaInsert<Producerinvoice>();
            if (!model.ProducerId.IsNullOrEmpty())
            {
                insert.Insert(p => p.ProducerId == model.ProducerId);
            }
            if (!model.CompanyName.IsNullOrEmpty())
            {
                insert.Insert(p => p.CompanyName == model.CompanyName);
            }
            if (!model.InvoiceNumber.IsNullOrEmpty())
            {
                insert.Insert(p => p.InvoiceNumber == model.InvoiceNumber);
            }
            if (!model.InvoiceTime.IsNullOrEmpty())
            {
                insert.Insert(p => p.InvoiceTime == model.InvoiceTime);
            }
            if (!model.InvoiceMoney.IsNullOrEmpty())
            {
                insert.Insert(p => p.InvoiceMoney == model.InvoiceMoney);
            }
            if (!model.InvoiceIdentify.IsNullOrEmpty())
            {
                insert.Insert(p => p.InvoiceIdentify == model.InvoiceIdentify);
            }
            if (!model.InvoicePhone.IsNullOrEmpty())
            {
                insert.Insert(p => p.InvoicePhone == model.InvoicePhone);
            }
            if (!model.InvoiceAddress.IsNullOrEmpty())
            {
                insert.Insert(p => p.InvoiceAddress == model.InvoiceAddress);
            }
            if (!model.InvoiceBank.IsNullOrEmpty())
            {
                insert.Insert(p => p.InvoiceBank == model.InvoiceBank);
            }
            if (!model.InvoiceContext.IsNullOrEmpty())
            {
                insert.Insert(p => p.InvoiceContext == model.InvoiceContext);
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
        public List<Producerinvoice> SelectAll(Producerinvoice model = null, string SelectFiled = null, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var query = new LambdaQuery<Producerinvoice>();
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
                if (!model.CompanyName.IsNullOrEmpty())
                {
                    query.Where(p => p.CompanyName == model.CompanyName);
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
                if (!model.InvoiceContext.IsNullOrEmpty())
                {
                    query.Where(p => p.InvoiceContext == model.InvoiceContext);
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
                if (SelectFiled.Contains("companyname,"))
                {
                    query.Select(p => new { p.CompanyName });
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
                if (SelectFiled.Contains("invoicecontext,"))
                {
                    query.Select(p => new { p.InvoiceContext });
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
        public int SelectCount(Producerinvoice model = null, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var query = new LambdaQuery<Producerinvoice>();
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
                if (!model.CompanyName.IsNullOrEmpty())
                {
                    query.Where(p => p.CompanyName == model.CompanyName);
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
                if (!model.InvoiceContext.IsNullOrEmpty())
                {
                    query.Where(p => p.InvoiceContext == model.InvoiceContext);
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
        public Producerinvoice SelectById(int KeyId, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var query = new LambdaQuery<Producerinvoice>();
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
        public List<Producerinvoice> SelectByKeys(string Key,List<string> KeyIds, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var query = new LambdaQuery<Producerinvoice>();
            if("id" == Key.ToLowerInvariant())
            {
                query.Where(p => p.Id.In(KeyIds));
            }
            if("producerid" == Key.ToLowerInvariant())
            {
                query.Where(p => p.ProducerId.In(KeyIds));
            }
            if("companyname" == Key.ToLowerInvariant())
            {
                query.Where(p => p.CompanyName.In(KeyIds));
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
            if("invoicecontext" == Key.ToLowerInvariant())
            {
                query.Where(p => p.InvoiceContext.In(KeyIds));
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
        public List<Producerinvoice> SelectByPage(string Key, int start, int PageSize, bool desc = true,Producerinvoice model = null, string SelectFiled = null, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var query = new LambdaQuery<Producerinvoice>();
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
                if (!model.CompanyName.IsNullOrEmpty())
                {
                    query.Where(p => p.CompanyName == model.CompanyName);
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
                if (!model.InvoiceContext.IsNullOrEmpty())
                {
                    query.Where(p => p.InvoiceContext == model.InvoiceContext);
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
                if (SelectFiled.Contains("companyname,"))
                {
                    query.Select(p => new { p.CompanyName });
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
                if (SelectFiled.Contains("invoicecontext,"))
                {
                    query.Select(p => new { p.InvoiceContext });
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
