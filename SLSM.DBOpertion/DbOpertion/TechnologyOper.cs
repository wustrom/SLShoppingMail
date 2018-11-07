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
    public partial class TechnologyOper : SingleTon<TechnologyOper>
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
            var delete = new LambdaDelete<Technology>();
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
        public bool DeleteModel(Technology model = null, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var delete = new LambdaDelete<Technology>();
            if (model != null)
            {
                if (!model.Id.IsNullOrEmpty())
                {
                    delete.Where(p => p.Id == model.Id);
                }
                if (!model.Name.IsNullOrEmpty())
                {
                    delete.Where(p => p.Name == model.Name);
                }
                if (!model.IsDelete.IsNullOrEmpty())
                {
                    delete.Where(p => p.IsDelete == model.IsDelete);
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
        public bool Update(Technology model, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var update = new LambdaUpdate<Technology>();
            if (!model.Id.IsNullOrEmpty())
            {
                update.Where(p => p.Id == model.Id);
            }
            if (!model.Name.IsNullOrEmpty())
            {
                update.Set(p => p.Name == model.Name);
            }
            if (!model.IsDelete.IsNullOrEmpty())
            {
                update.Set(p => p.IsDelete == model.IsDelete);
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
        public bool Insert(Technology model, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var insert = new LambdaInsert<Technology>();
            if (!model.Name.IsNullOrEmpty())
            {
                insert.Insert(p => p.Name == model.Name);
            }
            if (!model.IsDelete.IsNullOrEmpty())
            {
                insert.Insert(p => p.IsDelete == model.IsDelete);
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
        public int InsertReturnKey(Technology model, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var insert = new LambdaInsert<Technology>();
            if (!model.Name.IsNullOrEmpty())
            {
                insert.Insert(p => p.Name == model.Name);
            }
            if (!model.IsDelete.IsNullOrEmpty())
            {
                insert.Insert(p => p.IsDelete == model.IsDelete);
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
        public List<Technology> SelectAll(Technology model = null, string SelectFiled = null, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var query = new LambdaQuery<Technology>();
            if (model != null)
            {
                if (!model.Id.IsNullOrEmpty())
                {
                    query.Where(p => p.Id == model.Id);
                }
                if (!model.Name.IsNullOrEmpty())
                {
                    query.Where(p => p.Name == model.Name);
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
                if (SelectFiled.Contains("name,"))
                {
                    query.Select(p => new { p.Name });
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
        public int SelectCount(Technology model = null, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var query = new LambdaQuery<Technology>();
            if (model != null)
            {
                if (!model.Id.IsNullOrEmpty())
                {
                    query.Where(p => p.Id == model.Id);
                }
                if (!model.Name.IsNullOrEmpty())
                {
                    query.Where(p => p.Name == model.Name);
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
        public Technology SelectById(int KeyId, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var query = new LambdaQuery<Technology>();
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
        public List<Technology> SelectByKeys(string Key,List<string> KeyIds, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var query = new LambdaQuery<Technology>();
            if("id" == Key.ToLowerInvariant())
            {
                query.Where(p => p.Id.In(KeyIds));
            }
            if("name" == Key.ToLowerInvariant())
            {
                query.Where(p => p.Name.In(KeyIds));
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
        public List<Technology> SelectByPage(string Key, int start, int PageSize, bool desc = true,Technology model = null, string SelectFiled = null, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var query = new LambdaQuery<Technology>();
            if (model != null)
            {
                if (!model.Id.IsNullOrEmpty())
                {
                    query.Where(p => p.Id == model.Id);
                }
                if (!model.Name.IsNullOrEmpty())
                {
                    query.Where(p => p.Name == model.Name);
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
                if (SelectFiled.Contains("name,"))
                {
                    query.Select(p => new { p.Name });
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
