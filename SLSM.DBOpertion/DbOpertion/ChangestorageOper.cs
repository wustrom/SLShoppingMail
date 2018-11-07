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
    public partial class ChangestorageOper : SingleTon<ChangestorageOper>
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
            var delete = new LambdaDelete<Changestorage>();
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
        public bool DeleteModel(Changestorage model = null, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var delete = new LambdaDelete<Changestorage>();
            if (model != null)
            {
                if (!model.Id.IsNullOrEmpty())
                {
                    delete.Where(p => p.Id == model.Id);
                }
                if (!model.storageId.IsNullOrEmpty())
                {
                    delete.Where(p => p.storageId == model.storageId);
                }
                if (!model.ChangeTime.IsNullOrEmpty())
                {
                    delete.Where(p => p.ChangeTime == model.ChangeTime);
                }
                if (!model.ChangeType.IsNullOrEmpty())
                {
                    delete.Where(p => p.ChangeType == model.ChangeType);
                }
                if (!model.ChangeCount.IsNullOrEmpty())
                {
                    delete.Where(p => p.ChangeCount == model.ChangeCount);
                }
                if (!model.ChangeAfterCount.IsNullOrEmpty())
                {
                    delete.Where(p => p.ChangeAfterCount == model.ChangeAfterCount);
                }
                if (!model.ChangeContext.IsNullOrEmpty())
                {
                    delete.Where(p => p.ChangeContext == model.ChangeContext);
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
        public bool Update(Changestorage model, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var update = new LambdaUpdate<Changestorage>();
            if (!model.Id.IsNullOrEmpty())
            {
                update.Where(p => p.Id == model.Id);
            }
            if (!model.storageId.IsNullOrEmpty())
            {
                update.Set(p => p.storageId == model.storageId);
            }
            if (!model.ChangeTime.IsNullOrEmpty())
            {
                update.Set(p => p.ChangeTime == model.ChangeTime);
            }
            if (!model.ChangeType.IsNullOrEmpty())
            {
                update.Set(p => p.ChangeType == model.ChangeType);
            }
            if (!model.ChangeCount.IsNullOrEmpty())
            {
                update.Set(p => p.ChangeCount == model.ChangeCount);
            }
            if (!model.ChangeAfterCount.IsNullOrEmpty())
            {
                update.Set(p => p.ChangeAfterCount == model.ChangeAfterCount);
            }
            if (!model.ChangeContext.IsNullOrEmpty())
            {
                update.Set(p => p.ChangeContext == model.ChangeContext);
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
        public bool Insert(Changestorage model, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var insert = new LambdaInsert<Changestorage>();
            if (!model.storageId.IsNullOrEmpty())
            {
                insert.Insert(p => p.storageId == model.storageId);
            }
            if (!model.ChangeTime.IsNullOrEmpty())
            {
                insert.Insert(p => p.ChangeTime == model.ChangeTime);
            }
            if (!model.ChangeType.IsNullOrEmpty())
            {
                insert.Insert(p => p.ChangeType == model.ChangeType);
            }
            if (!model.ChangeCount.IsNullOrEmpty())
            {
                insert.Insert(p => p.ChangeCount == model.ChangeCount);
            }
            if (!model.ChangeAfterCount.IsNullOrEmpty())
            {
                insert.Insert(p => p.ChangeAfterCount == model.ChangeAfterCount);
            }
            if (!model.ChangeContext.IsNullOrEmpty())
            {
                insert.Insert(p => p.ChangeContext == model.ChangeContext);
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
        public int InsertReturnKey(Changestorage model, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var insert = new LambdaInsert<Changestorage>();
            if (!model.storageId.IsNullOrEmpty())
            {
                insert.Insert(p => p.storageId == model.storageId);
            }
            if (!model.ChangeTime.IsNullOrEmpty())
            {
                insert.Insert(p => p.ChangeTime == model.ChangeTime);
            }
            if (!model.ChangeType.IsNullOrEmpty())
            {
                insert.Insert(p => p.ChangeType == model.ChangeType);
            }
            if (!model.ChangeCount.IsNullOrEmpty())
            {
                insert.Insert(p => p.ChangeCount == model.ChangeCount);
            }
            if (!model.ChangeAfterCount.IsNullOrEmpty())
            {
                insert.Insert(p => p.ChangeAfterCount == model.ChangeAfterCount);
            }
            if (!model.ChangeContext.IsNullOrEmpty())
            {
                insert.Insert(p => p.ChangeContext == model.ChangeContext);
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
        public List<Changestorage> SelectAll(Changestorage model = null, string SelectFiled = null, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var query = new LambdaQuery<Changestorage>();
            if (model != null)
            {
                if (!model.Id.IsNullOrEmpty())
                {
                    query.Where(p => p.Id == model.Id);
                }
                if (!model.storageId.IsNullOrEmpty())
                {
                    query.Where(p => p.storageId == model.storageId);
                }
                if (!model.ChangeTime.IsNullOrEmpty())
                {
                    query.Where(p => p.ChangeTime == model.ChangeTime);
                }
                if (!model.ChangeType.IsNullOrEmpty())
                {
                    query.Where(p => p.ChangeType == model.ChangeType);
                }
                if (!model.ChangeCount.IsNullOrEmpty())
                {
                    query.Where(p => p.ChangeCount == model.ChangeCount);
                }
                if (!model.ChangeAfterCount.IsNullOrEmpty())
                {
                    query.Where(p => p.ChangeAfterCount == model.ChangeAfterCount);
                }
                if (!model.ChangeContext.IsNullOrEmpty())
                {
                    query.Where(p => p.ChangeContext == model.ChangeContext);
                }
            }
            if (SelectFiled != null)
            {
                SelectFiled = SelectFiled.ToLowerInvariant();
                if (SelectFiled.Contains("id,"))
                {
                    query.Select(p => new { p.Id });
                }
                if (SelectFiled.Contains("storageid,"))
                {
                    query.Select(p => new { p.storageId });
                }
                if (SelectFiled.Contains("changetime,"))
                {
                    query.Select(p => new { p.ChangeTime });
                }
                if (SelectFiled.Contains("changetype,"))
                {
                    query.Select(p => new { p.ChangeType });
                }
                if (SelectFiled.Contains("changecount,"))
                {
                    query.Select(p => new { p.ChangeCount });
                }
                if (SelectFiled.Contains("changeaftercount,"))
                {
                    query.Select(p => new { p.ChangeAfterCount });
                }
                if (SelectFiled.Contains("changecontext,"))
                {
                    query.Select(p => new { p.ChangeContext });
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
        public int SelectCount(Changestorage model = null, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var query = new LambdaQuery<Changestorage>();
            if (model != null)
            {
                if (!model.Id.IsNullOrEmpty())
                {
                    query.Where(p => p.Id == model.Id);
                }
                if (!model.storageId.IsNullOrEmpty())
                {
                    query.Where(p => p.storageId == model.storageId);
                }
                if (!model.ChangeTime.IsNullOrEmpty())
                {
                    query.Where(p => p.ChangeTime == model.ChangeTime);
                }
                if (!model.ChangeType.IsNullOrEmpty())
                {
                    query.Where(p => p.ChangeType == model.ChangeType);
                }
                if (!model.ChangeCount.IsNullOrEmpty())
                {
                    query.Where(p => p.ChangeCount == model.ChangeCount);
                }
                if (!model.ChangeAfterCount.IsNullOrEmpty())
                {
                    query.Where(p => p.ChangeAfterCount == model.ChangeAfterCount);
                }
                if (!model.ChangeContext.IsNullOrEmpty())
                {
                    query.Where(p => p.ChangeContext == model.ChangeContext);
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
        public Changestorage SelectById(int KeyId, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var query = new LambdaQuery<Changestorage>();
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
        public List<Changestorage> SelectByKeys(string Key,List<string> KeyIds, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var query = new LambdaQuery<Changestorage>();
            if("id" == Key.ToLowerInvariant())
            {
                query.Where(p => p.Id.In(KeyIds));
            }
            if("storageid" == Key.ToLowerInvariant())
            {
                query.Where(p => p.storageId.In(KeyIds));
            }
            if("changetime" == Key.ToLowerInvariant())
            {
                query.Where(p => p.ChangeTime.In(KeyIds));
            }
            if("changetype" == Key.ToLowerInvariant())
            {
                query.Where(p => p.ChangeType.In(KeyIds));
            }
            if("changecount" == Key.ToLowerInvariant())
            {
                query.Where(p => p.ChangeCount.In(KeyIds));
            }
            if("changeaftercount" == Key.ToLowerInvariant())
            {
                query.Where(p => p.ChangeAfterCount.In(KeyIds));
            }
            if("changecontext" == Key.ToLowerInvariant())
            {
                query.Where(p => p.ChangeContext.In(KeyIds));
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
        public List<Changestorage> SelectByPage(string Key, int start, int PageSize, bool desc = true,Changestorage model = null, string SelectFiled = null, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var query = new LambdaQuery<Changestorage>();
            if (model != null)
            {
                if (!model.Id.IsNullOrEmpty())
                {
                    query.Where(p => p.Id == model.Id);
                }
                if (!model.storageId.IsNullOrEmpty())
                {
                    query.Where(p => p.storageId == model.storageId);
                }
                if (!model.ChangeTime.IsNullOrEmpty())
                {
                    query.Where(p => p.ChangeTime == model.ChangeTime);
                }
                if (!model.ChangeType.IsNullOrEmpty())
                {
                    query.Where(p => p.ChangeType == model.ChangeType);
                }
                if (!model.ChangeCount.IsNullOrEmpty())
                {
                    query.Where(p => p.ChangeCount == model.ChangeCount);
                }
                if (!model.ChangeAfterCount.IsNullOrEmpty())
                {
                    query.Where(p => p.ChangeAfterCount == model.ChangeAfterCount);
                }
                if (!model.ChangeContext.IsNullOrEmpty())
                {
                    query.Where(p => p.ChangeContext == model.ChangeContext);
                }
            }
            if (SelectFiled != null)
            {
                SelectFiled = SelectFiled.ToLowerInvariant();
                if (SelectFiled.Contains("id,"))
                {
                    query.Select(p => new { p.Id });
                }
                if (SelectFiled.Contains("storageid,"))
                {
                    query.Select(p => new { p.storageId });
                }
                if (SelectFiled.Contains("changetime,"))
                {
                    query.Select(p => new { p.ChangeTime });
                }
                if (SelectFiled.Contains("changetype,"))
                {
                    query.Select(p => new { p.ChangeType });
                }
                if (SelectFiled.Contains("changecount,"))
                {
                    query.Select(p => new { p.ChangeCount });
                }
                if (SelectFiled.Contains("changeaftercount,"))
                {
                    query.Select(p => new { p.ChangeAfterCount });
                }
                if (SelectFiled.Contains("changecontext,"))
                {
                    query.Select(p => new { p.ChangeContext });
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
