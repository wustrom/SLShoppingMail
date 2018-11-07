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
    public partial class TipsOper : SingleTon<TipsOper>
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
            var delete = new LambdaDelete<Tips>();
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
        public bool DeleteModel(Tips model = null, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var delete = new LambdaDelete<Tips>();
            if (model != null)
            {
                if (!model.Id.IsNullOrEmpty())
                {
                    delete.Where(p => p.Id == model.Id);
                }
                if (!model.Title.IsNullOrEmpty())
                {
                    delete.Where(p => p.Title == model.Title);
                }
                if (!model.Content.IsNullOrEmpty())
                {
                    delete.Where(p => p.Content == model.Content);
                }
                if (!model.CreateTime.IsNullOrEmpty())
                {
                    delete.Where(p => p.CreateTime == model.CreateTime);
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
        public bool Update(Tips model, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var update = new LambdaUpdate<Tips>();
            if (!model.Id.IsNullOrEmpty())
            {
                update.Where(p => p.Id == model.Id);
            }
            if (!model.Title.IsNullOrEmpty())
            {
                update.Set(p => p.Title == model.Title);
            }
            if (!model.Content.IsNullOrEmpty())
            {
                update.Set(p => p.Content == model.Content);
            }
            if (!model.CreateTime.IsNullOrEmpty())
            {
                update.Set(p => p.CreateTime == model.CreateTime);
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
        public bool Insert(Tips model, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var insert = new LambdaInsert<Tips>();
            if (!model.Title.IsNullOrEmpty())
            {
                insert.Insert(p => p.Title == model.Title);
            }
            if (!model.Content.IsNullOrEmpty())
            {
                insert.Insert(p => p.Content == model.Content);
            }
            if (!model.CreateTime.IsNullOrEmpty())
            {
                insert.Insert(p => p.CreateTime == model.CreateTime);
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
        public int InsertReturnKey(Tips model, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var insert = new LambdaInsert<Tips>();
            if (!model.Title.IsNullOrEmpty())
            {
                insert.Insert(p => p.Title == model.Title);
            }
            if (!model.Content.IsNullOrEmpty())
            {
                insert.Insert(p => p.Content == model.Content);
            }
            if (!model.CreateTime.IsNullOrEmpty())
            {
                insert.Insert(p => p.CreateTime == model.CreateTime);
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
        public List<Tips> SelectAll(Tips model = null, string SelectFiled = null, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var query = new LambdaQuery<Tips>();
            if (model != null)
            {
                if (!model.Id.IsNullOrEmpty())
                {
                    query.Where(p => p.Id == model.Id);
                }
                if (!model.Title.IsNullOrEmpty())
                {
                    query.Where(p => p.Title == model.Title);
                }
                if (!model.Content.IsNullOrEmpty())
                {
                    query.Where(p => p.Content == model.Content);
                }
                if (!model.CreateTime.IsNullOrEmpty())
                {
                    query.Where(p => p.CreateTime == model.CreateTime);
                }
            }
            if (SelectFiled != null)
            {
                SelectFiled = SelectFiled.ToLowerInvariant();
                if (SelectFiled.Contains("id,"))
                {
                    query.Select(p => new { p.Id });
                }
                if (SelectFiled.Contains("title,"))
                {
                    query.Select(p => new { p.Title });
                }
                if (SelectFiled.Contains("content,"))
                {
                    query.Select(p => new { p.Content });
                }
                if (SelectFiled.Contains("createtime,"))
                {
                    query.Select(p => new { p.CreateTime });
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
        public int SelectCount(Tips model = null, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var query = new LambdaQuery<Tips>();
            if (model != null)
            {
                if (!model.Id.IsNullOrEmpty())
                {
                    query.Where(p => p.Id == model.Id);
                }
                if (!model.Title.IsNullOrEmpty())
                {
                    query.Where(p => p.Title == model.Title);
                }
                if (!model.Content.IsNullOrEmpty())
                {
                    query.Where(p => p.Content == model.Content);
                }
                if (!model.CreateTime.IsNullOrEmpty())
                {
                    query.Where(p => p.CreateTime == model.CreateTime);
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
        public Tips SelectById(int KeyId, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var query = new LambdaQuery<Tips>();
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
        public List<Tips> SelectByKeys(string Key,List<string> KeyIds, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var query = new LambdaQuery<Tips>();
            if("id" == Key.ToLowerInvariant())
            {
                query.Where(p => p.Id.In(KeyIds));
            }
            if("title" == Key.ToLowerInvariant())
            {
                query.Where(p => p.Title.In(KeyIds));
            }
            if("content" == Key.ToLowerInvariant())
            {
                query.Where(p => p.Content.In(KeyIds));
            }
            if("createtime" == Key.ToLowerInvariant())
            {
                query.Where(p => p.CreateTime.In(KeyIds));
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
        public List<Tips> SelectByPage(string Key, int start, int PageSize, bool desc = true,Tips model = null, string SelectFiled = null, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var query = new LambdaQuery<Tips>();
            if (model != null)
            {
                if (!model.Id.IsNullOrEmpty())
                {
                    query.Where(p => p.Id == model.Id);
                }
                if (!model.Title.IsNullOrEmpty())
                {
                    query.Where(p => p.Title == model.Title);
                }
                if (!model.Content.IsNullOrEmpty())
                {
                    query.Where(p => p.Content == model.Content);
                }
                if (!model.CreateTime.IsNullOrEmpty())
                {
                    query.Where(p => p.CreateTime == model.CreateTime);
                }
            }
            if (SelectFiled != null)
            {
                SelectFiled = SelectFiled.ToLowerInvariant();
                if (SelectFiled.Contains("id,"))
                {
                    query.Select(p => new { p.Id });
                }
                if (SelectFiled.Contains("title,"))
                {
                    query.Select(p => new { p.Title });
                }
                if (SelectFiled.Contains("content,"))
                {
                    query.Select(p => new { p.Content });
                }
                if (SelectFiled.Contains("createtime,"))
                {
                    query.Select(p => new { p.CreateTime });
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
