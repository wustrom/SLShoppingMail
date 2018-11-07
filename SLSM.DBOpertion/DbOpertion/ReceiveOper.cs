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
    public partial class ReceiveOper : SingleTon<ReceiveOper>
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
            var delete = new LambdaDelete<Receive>();
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
        public bool DeleteModel(Receive model = null, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var delete = new LambdaDelete<Receive>();
            if (model != null)
            {
                if (!model.Id.IsNullOrEmpty())
                {
                    delete.Where(p => p.Id == model.Id);
                }
                if (!model.ProductionId.IsNullOrEmpty())
                {
                    delete.Where(p => p.ProductionId == model.ProductionId);
                }
                if (!model.receiveStatus.IsNullOrEmpty())
                {
                    delete.Where(p => p.receiveStatus == model.receiveStatus);
                }
                if (!model.receiveOutTime.IsNullOrEmpty())
                {
                    delete.Where(p => p.receiveOutTime == model.receiveOutTime);
                }
                if (!model.receiveTime.IsNullOrEmpty())
                {
                    delete.Where(p => p.receiveTime == model.receiveTime);
                }
                if (!model.receiveContext.IsNullOrEmpty())
                {
                    delete.Where(p => p.receiveContext == model.receiveContext);
                }
                if (!model.receiveSinglePerson.IsNullOrEmpty())
                {
                    delete.Where(p => p.receiveSinglePerson == model.receiveSinglePerson);
                }
                if (!model.receiveSingleTime.IsNullOrEmpty())
                {
                    delete.Where(p => p.receiveSingleTime == model.receiveSingleTime);
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
        public bool Update(Receive model, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var update = new LambdaUpdate<Receive>();
            if (!model.Id.IsNullOrEmpty())
            {
                update.Where(p => p.Id == model.Id);
            }
            if (!model.ProductionId.IsNullOrEmpty())
            {
                update.Set(p => p.ProductionId == model.ProductionId);
            }
            if (!model.receiveStatus.IsNullOrEmpty())
            {
                update.Set(p => p.receiveStatus == model.receiveStatus);
            }
            if (!model.receiveOutTime.IsNullOrEmpty())
            {
                update.Set(p => p.receiveOutTime == model.receiveOutTime);
            }
            if (!model.receiveTime.IsNullOrEmpty())
            {
                update.Set(p => p.receiveTime == model.receiveTime);
            }
            if (!model.receiveContext.IsNullOrEmpty())
            {
                update.Set(p => p.receiveContext == model.receiveContext);
            }
            if (!model.receiveSinglePerson.IsNullOrEmpty())
            {
                update.Set(p => p.receiveSinglePerson == model.receiveSinglePerson);
            }
            if (!model.receiveSingleTime.IsNullOrEmpty())
            {
                update.Set(p => p.receiveSingleTime == model.receiveSingleTime);
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
        public bool Insert(Receive model, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var insert = new LambdaInsert<Receive>();
            if (!model.ProductionId.IsNullOrEmpty())
            {
                insert.Insert(p => p.ProductionId == model.ProductionId);
            }
            if (!model.receiveStatus.IsNullOrEmpty())
            {
                insert.Insert(p => p.receiveStatus == model.receiveStatus);
            }
            if (!model.receiveOutTime.IsNullOrEmpty())
            {
                insert.Insert(p => p.receiveOutTime == model.receiveOutTime);
            }
            if (!model.receiveTime.IsNullOrEmpty())
            {
                insert.Insert(p => p.receiveTime == model.receiveTime);
            }
            if (!model.receiveContext.IsNullOrEmpty())
            {
                insert.Insert(p => p.receiveContext == model.receiveContext);
            }
            if (!model.receiveSinglePerson.IsNullOrEmpty())
            {
                insert.Insert(p => p.receiveSinglePerson == model.receiveSinglePerson);
            }
            if (!model.receiveSingleTime.IsNullOrEmpty())
            {
                insert.Insert(p => p.receiveSingleTime == model.receiveSingleTime);
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
        public int InsertReturnKey(Receive model, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var insert = new LambdaInsert<Receive>();
            if (!model.ProductionId.IsNullOrEmpty())
            {
                insert.Insert(p => p.ProductionId == model.ProductionId);
            }
            if (!model.receiveStatus.IsNullOrEmpty())
            {
                insert.Insert(p => p.receiveStatus == model.receiveStatus);
            }
            if (!model.receiveOutTime.IsNullOrEmpty())
            {
                insert.Insert(p => p.receiveOutTime == model.receiveOutTime);
            }
            if (!model.receiveTime.IsNullOrEmpty())
            {
                insert.Insert(p => p.receiveTime == model.receiveTime);
            }
            if (!model.receiveContext.IsNullOrEmpty())
            {
                insert.Insert(p => p.receiveContext == model.receiveContext);
            }
            if (!model.receiveSinglePerson.IsNullOrEmpty())
            {
                insert.Insert(p => p.receiveSinglePerson == model.receiveSinglePerson);
            }
            if (!model.receiveSingleTime.IsNullOrEmpty())
            {
                insert.Insert(p => p.receiveSingleTime == model.receiveSingleTime);
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
        public List<Receive> SelectAll(Receive model = null, string SelectFiled = null, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var query = new LambdaQuery<Receive>();
            if (model != null)
            {
                if (!model.Id.IsNullOrEmpty())
                {
                    query.Where(p => p.Id == model.Id);
                }
                if (!model.ProductionId.IsNullOrEmpty())
                {
                    query.Where(p => p.ProductionId == model.ProductionId);
                }
                if (!model.receiveStatus.IsNullOrEmpty())
                {
                    query.Where(p => p.receiveStatus == model.receiveStatus);
                }
                if (!model.receiveOutTime.IsNullOrEmpty())
                {
                    query.Where(p => p.receiveOutTime == model.receiveOutTime);
                }
                if (!model.receiveTime.IsNullOrEmpty())
                {
                    query.Where(p => p.receiveTime == model.receiveTime);
                }
                if (!model.receiveContext.IsNullOrEmpty())
                {
                    query.Where(p => p.receiveContext == model.receiveContext);
                }
                if (!model.receiveSinglePerson.IsNullOrEmpty())
                {
                    query.Where(p => p.receiveSinglePerson == model.receiveSinglePerson);
                }
                if (!model.receiveSingleTime.IsNullOrEmpty())
                {
                    query.Where(p => p.receiveSingleTime == model.receiveSingleTime);
                }
            }
            if (SelectFiled != null)
            {
                SelectFiled = SelectFiled.ToLowerInvariant();
                if (SelectFiled.Contains("id,"))
                {
                    query.Select(p => new { p.Id });
                }
                if (SelectFiled.Contains("productionid,"))
                {
                    query.Select(p => new { p.ProductionId });
                }
                if (SelectFiled.Contains("receivestatus,"))
                {
                    query.Select(p => new { p.receiveStatus });
                }
                if (SelectFiled.Contains("receiveouttime,"))
                {
                    query.Select(p => new { p.receiveOutTime });
                }
                if (SelectFiled.Contains("receivetime,"))
                {
                    query.Select(p => new { p.receiveTime });
                }
                if (SelectFiled.Contains("receivecontext,"))
                {
                    query.Select(p => new { p.receiveContext });
                }
                if (SelectFiled.Contains("receivesingleperson,"))
                {
                    query.Select(p => new { p.receiveSinglePerson });
                }
                if (SelectFiled.Contains("receivesingletime,"))
                {
                    query.Select(p => new { p.receiveSingleTime });
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
        public int SelectCount(Receive model = null, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var query = new LambdaQuery<Receive>();
            if (model != null)
            {
                if (!model.Id.IsNullOrEmpty())
                {
                    query.Where(p => p.Id == model.Id);
                }
                if (!model.ProductionId.IsNullOrEmpty())
                {
                    query.Where(p => p.ProductionId == model.ProductionId);
                }
                if (!model.receiveStatus.IsNullOrEmpty())
                {
                    query.Where(p => p.receiveStatus == model.receiveStatus);
                }
                if (!model.receiveOutTime.IsNullOrEmpty())
                {
                    query.Where(p => p.receiveOutTime == model.receiveOutTime);
                }
                if (!model.receiveTime.IsNullOrEmpty())
                {
                    query.Where(p => p.receiveTime == model.receiveTime);
                }
                if (!model.receiveContext.IsNullOrEmpty())
                {
                    query.Where(p => p.receiveContext == model.receiveContext);
                }
                if (!model.receiveSinglePerson.IsNullOrEmpty())
                {
                    query.Where(p => p.receiveSinglePerson == model.receiveSinglePerson);
                }
                if (!model.receiveSingleTime.IsNullOrEmpty())
                {
                    query.Where(p => p.receiveSingleTime == model.receiveSingleTime);
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
        public Receive SelectById(int KeyId, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var query = new LambdaQuery<Receive>();
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
        public List<Receive> SelectByKeys(string Key,List<string> KeyIds, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var query = new LambdaQuery<Receive>();
            if("id" == Key.ToLowerInvariant())
            {
                query.Where(p => p.Id.In(KeyIds));
            }
            if("productionid" == Key.ToLowerInvariant())
            {
                query.Where(p => p.ProductionId.In(KeyIds));
            }
            if("receivestatus" == Key.ToLowerInvariant())
            {
                query.Where(p => p.receiveStatus.In(KeyIds));
            }
            if("receiveouttime" == Key.ToLowerInvariant())
            {
                query.Where(p => p.receiveOutTime.In(KeyIds));
            }
            if("receivetime" == Key.ToLowerInvariant())
            {
                query.Where(p => p.receiveTime.In(KeyIds));
            }
            if("receivecontext" == Key.ToLowerInvariant())
            {
                query.Where(p => p.receiveContext.In(KeyIds));
            }
            if("receivesingleperson" == Key.ToLowerInvariant())
            {
                query.Where(p => p.receiveSinglePerson.In(KeyIds));
            }
            if("receivesingletime" == Key.ToLowerInvariant())
            {
                query.Where(p => p.receiveSingleTime.In(KeyIds));
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
        public List<Receive> SelectByPage(string Key, int start, int PageSize, bool desc = true,Receive model = null, string SelectFiled = null, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var query = new LambdaQuery<Receive>();
            if (model != null)
            {
                if (!model.Id.IsNullOrEmpty())
                {
                    query.Where(p => p.Id == model.Id);
                }
                if (!model.ProductionId.IsNullOrEmpty())
                {
                    query.Where(p => p.ProductionId == model.ProductionId);
                }
                if (!model.receiveStatus.IsNullOrEmpty())
                {
                    query.Where(p => p.receiveStatus == model.receiveStatus);
                }
                if (!model.receiveOutTime.IsNullOrEmpty())
                {
                    query.Where(p => p.receiveOutTime == model.receiveOutTime);
                }
                if (!model.receiveTime.IsNullOrEmpty())
                {
                    query.Where(p => p.receiveTime == model.receiveTime);
                }
                if (!model.receiveContext.IsNullOrEmpty())
                {
                    query.Where(p => p.receiveContext == model.receiveContext);
                }
                if (!model.receiveSinglePerson.IsNullOrEmpty())
                {
                    query.Where(p => p.receiveSinglePerson == model.receiveSinglePerson);
                }
                if (!model.receiveSingleTime.IsNullOrEmpty())
                {
                    query.Where(p => p.receiveSingleTime == model.receiveSingleTime);
                }
            }
            if (SelectFiled != null)
            {
                SelectFiled = SelectFiled.ToLowerInvariant();
                if (SelectFiled.Contains("id,"))
                {
                    query.Select(p => new { p.Id });
                }
                if (SelectFiled.Contains("productionid,"))
                {
                    query.Select(p => new { p.ProductionId });
                }
                if (SelectFiled.Contains("receivestatus,"))
                {
                    query.Select(p => new { p.receiveStatus });
                }
                if (SelectFiled.Contains("receiveouttime,"))
                {
                    query.Select(p => new { p.receiveOutTime });
                }
                if (SelectFiled.Contains("receivetime,"))
                {
                    query.Select(p => new { p.receiveTime });
                }
                if (SelectFiled.Contains("receivecontext,"))
                {
                    query.Select(p => new { p.receiveContext });
                }
                if (SelectFiled.Contains("receivesingleperson,"))
                {
                    query.Select(p => new { p.receiveSinglePerson });
                }
                if (SelectFiled.Contains("receivesingletime,"))
                {
                    query.Select(p => new { p.receiveSingleTime });
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
