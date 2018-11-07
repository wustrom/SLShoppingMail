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
    public partial class Message_GrantOper : SingleTon<Message_GrantOper>
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
            var delete = new LambdaDelete<Message_Grant>();
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
        public bool DeleteModel(Message_Grant model = null, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var delete = new LambdaDelete<Message_Grant>();
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
                if (!model.MessageId.IsNullOrEmpty())
                {
                    delete.Where(p => p.MessageId == model.MessageId);
                }
                if (!model.IsWatch.IsNullOrEmpty())
                {
                    delete.Where(p => p.IsWatch == model.IsWatch);
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
        public bool Update(Message_Grant model, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var update = new LambdaUpdate<Message_Grant>();
            if (!model.Id.IsNullOrEmpty())
            {
                update.Where(p => p.Id == model.Id);
            }
            if (!model.UserId.IsNullOrEmpty())
            {
                update.Set(p => p.UserId == model.UserId);
            }
            if (!model.MessageId.IsNullOrEmpty())
            {
                update.Set(p => p.MessageId == model.MessageId);
            }
            if (!model.IsWatch.IsNullOrEmpty())
            {
                update.Set(p => p.IsWatch == model.IsWatch);
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
        public bool Insert(Message_Grant model, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var insert = new LambdaInsert<Message_Grant>();
            if (!model.UserId.IsNullOrEmpty())
            {
                insert.Insert(p => p.UserId == model.UserId);
            }
            if (!model.MessageId.IsNullOrEmpty())
            {
                insert.Insert(p => p.MessageId == model.MessageId);
            }
            if (!model.IsWatch.IsNullOrEmpty())
            {
                insert.Insert(p => p.IsWatch == model.IsWatch);
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
        public int InsertReturnKey(Message_Grant model, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var insert = new LambdaInsert<Message_Grant>();
            if (!model.UserId.IsNullOrEmpty())
            {
                insert.Insert(p => p.UserId == model.UserId);
            }
            if (!model.MessageId.IsNullOrEmpty())
            {
                insert.Insert(p => p.MessageId == model.MessageId);
            }
            if (!model.IsWatch.IsNullOrEmpty())
            {
                insert.Insert(p => p.IsWatch == model.IsWatch);
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
        public List<Message_Grant> SelectAll(Message_Grant model = null, string SelectFiled = null, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var query = new LambdaQuery<Message_Grant>();
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
                if (!model.MessageId.IsNullOrEmpty())
                {
                    query.Where(p => p.MessageId == model.MessageId);
                }
                if (!model.IsWatch.IsNullOrEmpty())
                {
                    query.Where(p => p.IsWatch == model.IsWatch);
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
                if (SelectFiled.Contains("messageid,"))
                {
                    query.Select(p => new { p.MessageId });
                }
                if (SelectFiled.Contains("iswatch,"))
                {
                    query.Select(p => new { p.IsWatch });
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
        public int SelectCount(Message_Grant model = null, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var query = new LambdaQuery<Message_Grant>();
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
                if (!model.MessageId.IsNullOrEmpty())
                {
                    query.Where(p => p.MessageId == model.MessageId);
                }
                if (!model.IsWatch.IsNullOrEmpty())
                {
                    query.Where(p => p.IsWatch == model.IsWatch);
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
        public Message_Grant SelectById(int KeyId, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var query = new LambdaQuery<Message_Grant>();
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
        public List<Message_Grant> SelectByKeys(string Key,List<string> KeyIds, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var query = new LambdaQuery<Message_Grant>();
            if("id" == Key.ToLowerInvariant())
            {
                query.Where(p => p.Id.In(KeyIds));
            }
            if("userid" == Key.ToLowerInvariant())
            {
                query.Where(p => p.UserId.In(KeyIds));
            }
            if("messageid" == Key.ToLowerInvariant())
            {
                query.Where(p => p.MessageId.In(KeyIds));
            }
            if("iswatch" == Key.ToLowerInvariant())
            {
                query.Where(p => p.IsWatch.In(KeyIds));
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
        public List<Message_Grant> SelectByPage(string Key, int start, int PageSize, bool desc = true,Message_Grant model = null, string SelectFiled = null, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var query = new LambdaQuery<Message_Grant>();
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
                if (!model.MessageId.IsNullOrEmpty())
                {
                    query.Where(p => p.MessageId == model.MessageId);
                }
                if (!model.IsWatch.IsNullOrEmpty())
                {
                    query.Where(p => p.IsWatch == model.IsWatch);
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
                if (SelectFiled.Contains("messageid,"))
                {
                    query.Select(p => new { p.MessageId });
                }
                if (SelectFiled.Contains("iswatch,"))
                {
                    query.Select(p => new { p.IsWatch });
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
