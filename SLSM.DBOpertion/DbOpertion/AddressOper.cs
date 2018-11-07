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
    public partial class AddressOper : SingleTon<AddressOper>
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
            var delete = new LambdaDelete<Address>();
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
        public bool DeleteModel(Address model = null, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var delete = new LambdaDelete<Address>();
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
                if (!model.ContactName.IsNullOrEmpty())
                {
                    delete.Where(p => p.ContactName == model.ContactName);
                }
                if (!model.ContactPhone.IsNullOrEmpty())
                {
                    delete.Where(p => p.ContactPhone == model.ContactPhone);
                }
                if (!model.AddrArea.IsNullOrEmpty())
                {
                    delete.Where(p => p.AddrArea == model.AddrArea);
                }
                if (!model.AddrDetail.IsNullOrEmpty())
                {
                    delete.Where(p => p.AddrDetail == model.AddrDetail);
                }
                if (!model.DefaultTime.IsNullOrEmpty())
                {
                    delete.Where(p => p.DefaultTime == model.DefaultTime);
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
        public bool Update(Address model, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var update = new LambdaUpdate<Address>();
            if (!model.Id.IsNullOrEmpty())
            {
                update.Where(p => p.Id == model.Id);
            }
            if (!model.UserId.IsNullOrEmpty())
            {
                update.Set(p => p.UserId == model.UserId);
            }
            if (!model.ContactName.IsNullOrEmpty())
            {
                update.Set(p => p.ContactName == model.ContactName);
            }
            if (!model.ContactPhone.IsNullOrEmpty())
            {
                update.Set(p => p.ContactPhone == model.ContactPhone);
            }
            if (!model.AddrArea.IsNullOrEmpty())
            {
                update.Set(p => p.AddrArea == model.AddrArea);
            }
            if (!model.AddrDetail.IsNullOrEmpty())
            {
                update.Set(p => p.AddrDetail == model.AddrDetail);
            }
            if (!model.DefaultTime.IsNullOrEmpty())
            {
                update.Set(p => p.DefaultTime == model.DefaultTime);
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
        public bool Insert(Address model, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var insert = new LambdaInsert<Address>();
            if (!model.UserId.IsNullOrEmpty())
            {
                insert.Insert(p => p.UserId == model.UserId);
            }
            if (!model.ContactName.IsNullOrEmpty())
            {
                insert.Insert(p => p.ContactName == model.ContactName);
            }
            if (!model.ContactPhone.IsNullOrEmpty())
            {
                insert.Insert(p => p.ContactPhone == model.ContactPhone);
            }
            if (!model.AddrArea.IsNullOrEmpty())
            {
                insert.Insert(p => p.AddrArea == model.AddrArea);
            }
            if (!model.AddrDetail.IsNullOrEmpty())
            {
                insert.Insert(p => p.AddrDetail == model.AddrDetail);
            }
            if (!model.DefaultTime.IsNullOrEmpty())
            {
                insert.Insert(p => p.DefaultTime == model.DefaultTime);
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
        public int InsertReturnKey(Address model, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var insert = new LambdaInsert<Address>();
            if (!model.UserId.IsNullOrEmpty())
            {
                insert.Insert(p => p.UserId == model.UserId);
            }
            if (!model.ContactName.IsNullOrEmpty())
            {
                insert.Insert(p => p.ContactName == model.ContactName);
            }
            if (!model.ContactPhone.IsNullOrEmpty())
            {
                insert.Insert(p => p.ContactPhone == model.ContactPhone);
            }
            if (!model.AddrArea.IsNullOrEmpty())
            {
                insert.Insert(p => p.AddrArea == model.AddrArea);
            }
            if (!model.AddrDetail.IsNullOrEmpty())
            {
                insert.Insert(p => p.AddrDetail == model.AddrDetail);
            }
            if (!model.DefaultTime.IsNullOrEmpty())
            {
                insert.Insert(p => p.DefaultTime == model.DefaultTime);
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
        public List<Address> SelectAll(Address model = null, string SelectFiled = null, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var query = new LambdaQuery<Address>();
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
                if (!model.ContactName.IsNullOrEmpty())
                {
                    query.Where(p => p.ContactName == model.ContactName);
                }
                if (!model.ContactPhone.IsNullOrEmpty())
                {
                    query.Where(p => p.ContactPhone == model.ContactPhone);
                }
                if (!model.AddrArea.IsNullOrEmpty())
                {
                    query.Where(p => p.AddrArea == model.AddrArea);
                }
                if (!model.AddrDetail.IsNullOrEmpty())
                {
                    query.Where(p => p.AddrDetail == model.AddrDetail);
                }
                if (!model.DefaultTime.IsNullOrEmpty())
                {
                    query.Where(p => p.DefaultTime == model.DefaultTime);
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
                if (SelectFiled.Contains("contactname,"))
                {
                    query.Select(p => new { p.ContactName });
                }
                if (SelectFiled.Contains("contactphone,"))
                {
                    query.Select(p => new { p.ContactPhone });
                }
                if (SelectFiled.Contains("addrarea,"))
                {
                    query.Select(p => new { p.AddrArea });
                }
                if (SelectFiled.Contains("addrdetail,"))
                {
                    query.Select(p => new { p.AddrDetail });
                }
                if (SelectFiled.Contains("defaulttime,"))
                {
                    query.Select(p => new { p.DefaultTime });
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
        public int SelectCount(Address model = null, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var query = new LambdaQuery<Address>();
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
                if (!model.ContactName.IsNullOrEmpty())
                {
                    query.Where(p => p.ContactName == model.ContactName);
                }
                if (!model.ContactPhone.IsNullOrEmpty())
                {
                    query.Where(p => p.ContactPhone == model.ContactPhone);
                }
                if (!model.AddrArea.IsNullOrEmpty())
                {
                    query.Where(p => p.AddrArea == model.AddrArea);
                }
                if (!model.AddrDetail.IsNullOrEmpty())
                {
                    query.Where(p => p.AddrDetail == model.AddrDetail);
                }
                if (!model.DefaultTime.IsNullOrEmpty())
                {
                    query.Where(p => p.DefaultTime == model.DefaultTime);
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
        public Address SelectById(int KeyId, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var query = new LambdaQuery<Address>();
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
        public List<Address> SelectByKeys(string Key,List<string> KeyIds, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var query = new LambdaQuery<Address>();
            if("id" == Key.ToLowerInvariant())
            {
                query.Where(p => p.Id.In(KeyIds));
            }
            if("userid" == Key.ToLowerInvariant())
            {
                query.Where(p => p.UserId.In(KeyIds));
            }
            if("contactname" == Key.ToLowerInvariant())
            {
                query.Where(p => p.ContactName.In(KeyIds));
            }
            if("contactphone" == Key.ToLowerInvariant())
            {
                query.Where(p => p.ContactPhone.In(KeyIds));
            }
            if("addrarea" == Key.ToLowerInvariant())
            {
                query.Where(p => p.AddrArea.In(KeyIds));
            }
            if("addrdetail" == Key.ToLowerInvariant())
            {
                query.Where(p => p.AddrDetail.In(KeyIds));
            }
            if("defaulttime" == Key.ToLowerInvariant())
            {
                query.Where(p => p.DefaultTime.In(KeyIds));
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
        public List<Address> SelectByPage(string Key, int start, int PageSize, bool desc = true,Address model = null, string SelectFiled = null, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var query = new LambdaQuery<Address>();
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
                if (!model.ContactName.IsNullOrEmpty())
                {
                    query.Where(p => p.ContactName == model.ContactName);
                }
                if (!model.ContactPhone.IsNullOrEmpty())
                {
                    query.Where(p => p.ContactPhone == model.ContactPhone);
                }
                if (!model.AddrArea.IsNullOrEmpty())
                {
                    query.Where(p => p.AddrArea == model.AddrArea);
                }
                if (!model.AddrDetail.IsNullOrEmpty())
                {
                    query.Where(p => p.AddrDetail == model.AddrDetail);
                }
                if (!model.DefaultTime.IsNullOrEmpty())
                {
                    query.Where(p => p.DefaultTime == model.DefaultTime);
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
                if (SelectFiled.Contains("contactname,"))
                {
                    query.Select(p => new { p.ContactName });
                }
                if (SelectFiled.Contains("contactphone,"))
                {
                    query.Select(p => new { p.ContactPhone });
                }
                if (SelectFiled.Contains("addrarea,"))
                {
                    query.Select(p => new { p.AddrArea });
                }
                if (SelectFiled.Contains("addrdetail,"))
                {
                    query.Select(p => new { p.AddrDetail });
                }
                if (SelectFiled.Contains("defaulttime,"))
                {
                    query.Select(p => new { p.DefaultTime });
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
