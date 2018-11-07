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
    public partial class InvoiceOper : SingleTon<InvoiceOper>
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
            var delete = new LambdaDelete<Invoice>();
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
        public bool DeleteModel(Invoice model = null, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var delete = new LambdaDelete<Invoice>();
            if (model != null)
            {
                if (!model.Id.IsNullOrEmpty())
                {
                    delete.Where(p => p.Id == model.Id);
                }
                if (!model.UserId.IsNullOrEmpty())
                {
                    delete.Where(p => p.UserId == model.UserId);
                }
                if (!model.OrderId.IsNullOrEmpty())
                {
                    delete.Where(p => p.OrderId == model.OrderId);
                }
                if (!model.Title.IsNullOrEmpty())
                {
                    delete.Where(p => p.Title == model.Title);
                }
                if (!model.DutyParagraph.IsNullOrEmpty())
                {
                    delete.Where(p => p.DutyParagraph == model.DutyParagraph);
                }
                if (!model.TypeInvoice.IsNullOrEmpty())
                {
                    delete.Where(p => p.TypeInvoice == model.TypeInvoice);
                }
                if (!model.InvoiceTime.IsNullOrEmpty())
                {
                    delete.Where(p => p.InvoiceTime == model.InvoiceTime);
                }
                if (!model.MobliePhone.IsNullOrEmpty())
                {
                    delete.Where(p => p.MobliePhone == model.MobliePhone);
                }
                if (!model.OpeningBank.IsNullOrEmpty())
                {
                    delete.Where(p => p.OpeningBank == model.OpeningBank);
                }
                if (!model.BankAccount.IsNullOrEmpty())
                {
                    delete.Where(p => p.BankAccount == model.BankAccount);
                }
                if (!model.Address.IsNullOrEmpty())
                {
                    delete.Where(p => p.Address == model.Address);
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
        public bool Update(Invoice model, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var update = new LambdaUpdate<Invoice>();
            if (!model.Id.IsNullOrEmpty())
            {
                update.Where(p => p.Id == model.Id);
            }
            if (!model.UserId.IsNullOrEmpty())
            {
                update.Set(p => p.UserId == model.UserId);
            }
            if (!model.OrderId.IsNullOrEmpty())
            {
                update.Set(p => p.OrderId == model.OrderId);
            }
            if (!model.Title.IsNullOrEmpty())
            {
                update.Set(p => p.Title == model.Title);
            }
            if (!model.DutyParagraph.IsNullOrEmpty())
            {
                update.Set(p => p.DutyParagraph == model.DutyParagraph);
            }
            if (!model.TypeInvoice.IsNullOrEmpty())
            {
                update.Set(p => p.TypeInvoice == model.TypeInvoice);
            }
            if (!model.InvoiceTime.IsNullOrEmpty())
            {
                update.Set(p => p.InvoiceTime == model.InvoiceTime);
            }
            if (!model.MobliePhone.IsNullOrEmpty())
            {
                update.Set(p => p.MobliePhone == model.MobliePhone);
            }
            if (!model.OpeningBank.IsNullOrEmpty())
            {
                update.Set(p => p.OpeningBank == model.OpeningBank);
            }
            if (!model.BankAccount.IsNullOrEmpty())
            {
                update.Set(p => p.BankAccount == model.BankAccount);
            }
            if (!model.Address.IsNullOrEmpty())
            {
                update.Set(p => p.Address == model.Address);
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
        public bool Insert(Invoice model, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var insert = new LambdaInsert<Invoice>();
            if (!model.UserId.IsNullOrEmpty())
            {
                insert.Insert(p => p.UserId == model.UserId);
            }
            if (!model.OrderId.IsNullOrEmpty())
            {
                insert.Insert(p => p.OrderId == model.OrderId);
            }
            if (!model.Title.IsNullOrEmpty())
            {
                insert.Insert(p => p.Title == model.Title);
            }
            if (!model.DutyParagraph.IsNullOrEmpty())
            {
                insert.Insert(p => p.DutyParagraph == model.DutyParagraph);
            }
            if (!model.TypeInvoice.IsNullOrEmpty())
            {
                insert.Insert(p => p.TypeInvoice == model.TypeInvoice);
            }
            if (!model.InvoiceTime.IsNullOrEmpty())
            {
                insert.Insert(p => p.InvoiceTime == model.InvoiceTime);
            }
            if (!model.MobliePhone.IsNullOrEmpty())
            {
                insert.Insert(p => p.MobliePhone == model.MobliePhone);
            }
            if (!model.OpeningBank.IsNullOrEmpty())
            {
                insert.Insert(p => p.OpeningBank == model.OpeningBank);
            }
            if (!model.BankAccount.IsNullOrEmpty())
            {
                insert.Insert(p => p.BankAccount == model.BankAccount);
            }
            if (!model.Address.IsNullOrEmpty())
            {
                insert.Insert(p => p.Address == model.Address);
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
        public int InsertReturnKey(Invoice model, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var insert = new LambdaInsert<Invoice>();
            if (!model.UserId.IsNullOrEmpty())
            {
                insert.Insert(p => p.UserId == model.UserId);
            }
            if (!model.OrderId.IsNullOrEmpty())
            {
                insert.Insert(p => p.OrderId == model.OrderId);
            }
            if (!model.Title.IsNullOrEmpty())
            {
                insert.Insert(p => p.Title == model.Title);
            }
            if (!model.DutyParagraph.IsNullOrEmpty())
            {
                insert.Insert(p => p.DutyParagraph == model.DutyParagraph);
            }
            if (!model.TypeInvoice.IsNullOrEmpty())
            {
                insert.Insert(p => p.TypeInvoice == model.TypeInvoice);
            }
            if (!model.InvoiceTime.IsNullOrEmpty())
            {
                insert.Insert(p => p.InvoiceTime == model.InvoiceTime);
            }
            if (!model.MobliePhone.IsNullOrEmpty())
            {
                insert.Insert(p => p.MobliePhone == model.MobliePhone);
            }
            if (!model.OpeningBank.IsNullOrEmpty())
            {
                insert.Insert(p => p.OpeningBank == model.OpeningBank);
            }
            if (!model.BankAccount.IsNullOrEmpty())
            {
                insert.Insert(p => p.BankAccount == model.BankAccount);
            }
            if (!model.Address.IsNullOrEmpty())
            {
                insert.Insert(p => p.Address == model.Address);
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
        public List<Invoice> SelectAll(Invoice model = null, string SelectFiled = null, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var query = new LambdaQuery<Invoice>();
            if (model != null)
            {
                if (!model.Id.IsNullOrEmpty())
                {
                    query.Where(p => p.Id == model.Id);
                }
                if (!model.UserId.IsNullOrEmpty())
                {
                    query.Where(p => p.UserId == model.UserId);
                }
                if (!model.OrderId.IsNullOrEmpty())
                {
                    query.Where(p => p.OrderId == model.OrderId);
                }
                if (!model.Title.IsNullOrEmpty())
                {
                    query.Where(p => p.Title == model.Title);
                }
                if (!model.DutyParagraph.IsNullOrEmpty())
                {
                    query.Where(p => p.DutyParagraph == model.DutyParagraph);
                }
                if (!model.TypeInvoice.IsNullOrEmpty())
                {
                    query.Where(p => p.TypeInvoice == model.TypeInvoice);
                }
                if (!model.InvoiceTime.IsNullOrEmpty())
                {
                    query.Where(p => p.InvoiceTime == model.InvoiceTime);
                }
                if (!model.MobliePhone.IsNullOrEmpty())
                {
                    query.Where(p => p.MobliePhone == model.MobliePhone);
                }
                if (!model.OpeningBank.IsNullOrEmpty())
                {
                    query.Where(p => p.OpeningBank == model.OpeningBank);
                }
                if (!model.BankAccount.IsNullOrEmpty())
                {
                    query.Where(p => p.BankAccount == model.BankAccount);
                }
                if (!model.Address.IsNullOrEmpty())
                {
                    query.Where(p => p.Address == model.Address);
                }
            }
            if (SelectFiled != null)
            {
                SelectFiled = SelectFiled.ToLowerInvariant();
                if (SelectFiled.Contains("id,"))
                {
                    query.Select(p => new { p.Id });
                }
                if (SelectFiled.Contains("userid,"))
                {
                    query.Select(p => new { p.UserId });
                }
                if (SelectFiled.Contains("orderid,"))
                {
                    query.Select(p => new { p.OrderId });
                }
                if (SelectFiled.Contains("title,"))
                {
                    query.Select(p => new { p.Title });
                }
                if (SelectFiled.Contains("dutyparagraph,"))
                {
                    query.Select(p => new { p.DutyParagraph });
                }
                if (SelectFiled.Contains("typeinvoice,"))
                {
                    query.Select(p => new { p.TypeInvoice });
                }
                if (SelectFiled.Contains("invoicetime,"))
                {
                    query.Select(p => new { p.InvoiceTime });
                }
                if (SelectFiled.Contains("mobliephone,"))
                {
                    query.Select(p => new { p.MobliePhone });
                }
                if (SelectFiled.Contains("openingbank,"))
                {
                    query.Select(p => new { p.OpeningBank });
                }
                if (SelectFiled.Contains("bankaccount,"))
                {
                    query.Select(p => new { p.BankAccount });
                }
                if (SelectFiled.Contains("address,"))
                {
                    query.Select(p => new { p.Address });
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
        public int SelectCount(Invoice model = null, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var query = new LambdaQuery<Invoice>();
            if (model != null)
            {
                if (!model.Id.IsNullOrEmpty())
                {
                    query.Where(p => p.Id == model.Id);
                }
                if (!model.UserId.IsNullOrEmpty())
                {
                    query.Where(p => p.UserId == model.UserId);
                }
                if (!model.OrderId.IsNullOrEmpty())
                {
                    query.Where(p => p.OrderId == model.OrderId);
                }
                if (!model.Title.IsNullOrEmpty())
                {
                    query.Where(p => p.Title == model.Title);
                }
                if (!model.DutyParagraph.IsNullOrEmpty())
                {
                    query.Where(p => p.DutyParagraph == model.DutyParagraph);
                }
                if (!model.TypeInvoice.IsNullOrEmpty())
                {
                    query.Where(p => p.TypeInvoice == model.TypeInvoice);
                }
                if (!model.InvoiceTime.IsNullOrEmpty())
                {
                    query.Where(p => p.InvoiceTime == model.InvoiceTime);
                }
                if (!model.MobliePhone.IsNullOrEmpty())
                {
                    query.Where(p => p.MobliePhone == model.MobliePhone);
                }
                if (!model.OpeningBank.IsNullOrEmpty())
                {
                    query.Where(p => p.OpeningBank == model.OpeningBank);
                }
                if (!model.BankAccount.IsNullOrEmpty())
                {
                    query.Where(p => p.BankAccount == model.BankAccount);
                }
                if (!model.Address.IsNullOrEmpty())
                {
                    query.Where(p => p.Address == model.Address);
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
        public Invoice SelectById(int KeyId, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var query = new LambdaQuery<Invoice>();
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
        public List<Invoice> SelectByKeys(string Key,List<string> KeyIds, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var query = new LambdaQuery<Invoice>();
            if("id" == Key.ToLowerInvariant())
            {
                query.Where(p => p.Id.In(KeyIds));
            }
            if("userid" == Key.ToLowerInvariant())
            {
                query.Where(p => p.UserId.In(KeyIds));
            }
            if("orderid" == Key.ToLowerInvariant())
            {
                query.Where(p => p.OrderId.In(KeyIds));
            }
            if("title" == Key.ToLowerInvariant())
            {
                query.Where(p => p.Title.In(KeyIds));
            }
            if("dutyparagraph" == Key.ToLowerInvariant())
            {
                query.Where(p => p.DutyParagraph.In(KeyIds));
            }
            if("typeinvoice" == Key.ToLowerInvariant())
            {
                query.Where(p => p.TypeInvoice.In(KeyIds));
            }
            if("invoicetime" == Key.ToLowerInvariant())
            {
                query.Where(p => p.InvoiceTime.In(KeyIds));
            }
            if("mobliephone" == Key.ToLowerInvariant())
            {
                query.Where(p => p.MobliePhone.In(KeyIds));
            }
            if("openingbank" == Key.ToLowerInvariant())
            {
                query.Where(p => p.OpeningBank.In(KeyIds));
            }
            if("bankaccount" == Key.ToLowerInvariant())
            {
                query.Where(p => p.BankAccount.In(KeyIds));
            }
            if("address" == Key.ToLowerInvariant())
            {
                query.Where(p => p.Address.In(KeyIds));
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
        public List<Invoice> SelectByPage(string Key, int start, int PageSize, bool desc = true,Invoice model = null, string SelectFiled = null, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var query = new LambdaQuery<Invoice>();
            if (model != null)
            {
                if (!model.Id.IsNullOrEmpty())
                {
                    query.Where(p => p.Id == model.Id);
                }
                if (!model.UserId.IsNullOrEmpty())
                {
                    query.Where(p => p.UserId == model.UserId);
                }
                if (!model.OrderId.IsNullOrEmpty())
                {
                    query.Where(p => p.OrderId == model.OrderId);
                }
                if (!model.Title.IsNullOrEmpty())
                {
                    query.Where(p => p.Title == model.Title);
                }
                if (!model.DutyParagraph.IsNullOrEmpty())
                {
                    query.Where(p => p.DutyParagraph == model.DutyParagraph);
                }
                if (!model.TypeInvoice.IsNullOrEmpty())
                {
                    query.Where(p => p.TypeInvoice == model.TypeInvoice);
                }
                if (!model.InvoiceTime.IsNullOrEmpty())
                {
                    query.Where(p => p.InvoiceTime == model.InvoiceTime);
                }
                if (!model.MobliePhone.IsNullOrEmpty())
                {
                    query.Where(p => p.MobliePhone == model.MobliePhone);
                }
                if (!model.OpeningBank.IsNullOrEmpty())
                {
                    query.Where(p => p.OpeningBank == model.OpeningBank);
                }
                if (!model.BankAccount.IsNullOrEmpty())
                {
                    query.Where(p => p.BankAccount == model.BankAccount);
                }
                if (!model.Address.IsNullOrEmpty())
                {
                    query.Where(p => p.Address == model.Address);
                }
            }
            if (SelectFiled != null)
            {
                SelectFiled = SelectFiled.ToLowerInvariant();
                if (SelectFiled.Contains("id,"))
                {
                    query.Select(p => new { p.Id });
                }
                if (SelectFiled.Contains("userid,"))
                {
                    query.Select(p => new { p.UserId });
                }
                if (SelectFiled.Contains("orderid,"))
                {
                    query.Select(p => new { p.OrderId });
                }
                if (SelectFiled.Contains("title,"))
                {
                    query.Select(p => new { p.Title });
                }
                if (SelectFiled.Contains("dutyparagraph,"))
                {
                    query.Select(p => new { p.DutyParagraph });
                }
                if (SelectFiled.Contains("typeinvoice,"))
                {
                    query.Select(p => new { p.TypeInvoice });
                }
                if (SelectFiled.Contains("invoicetime,"))
                {
                    query.Select(p => new { p.InvoiceTime });
                }
                if (SelectFiled.Contains("mobliephone,"))
                {
                    query.Select(p => new { p.MobliePhone });
                }
                if (SelectFiled.Contains("openingbank,"))
                {
                    query.Select(p => new { p.OpeningBank });
                }
                if (SelectFiled.Contains("bankaccount,"))
                {
                    query.Select(p => new { p.BankAccount });
                }
                if (SelectFiled.Contains("address,"))
                {
                    query.Select(p => new { p.Address });
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
