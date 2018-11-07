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
    public partial class DistributionOper : SingleTon<DistributionOper>
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
            var delete = new LambdaDelete<Distribution>();
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
        public bool DeleteModel(Distribution model = null, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var delete = new LambdaDelete<Distribution>();
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
                if (!model.procedures.IsNullOrEmpty())
                {
                    delete.Where(p => p.procedures == model.procedures);
                }
                if (!model.productionTime.IsNullOrEmpty())
                {
                    delete.Where(p => p.productionTime == model.productionTime);
                }
                if (!model.productionMan.IsNullOrEmpty())
                {
                    delete.Where(p => p.productionMan == model.productionMan);
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
        public bool Update(Distribution model, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var update = new LambdaUpdate<Distribution>();
            if (!model.Id.IsNullOrEmpty())
            {
                update.Where(p => p.Id == model.Id);
            }
            if (!model.ProductionId.IsNullOrEmpty())
            {
                update.Set(p => p.ProductionId == model.ProductionId);
            }
            if (!model.procedures.IsNullOrEmpty())
            {
                update.Set(p => p.procedures == model.procedures);
            }
            if (!model.productionTime.IsNullOrEmpty())
            {
                update.Set(p => p.productionTime == model.productionTime);
            }
            if (!model.productionMan.IsNullOrEmpty())
            {
                update.Set(p => p.productionMan == model.productionMan);
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
        public bool Insert(Distribution model, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var insert = new LambdaInsert<Distribution>();
            if (!model.ProductionId.IsNullOrEmpty())
            {
                insert.Insert(p => p.ProductionId == model.ProductionId);
            }
            if (!model.procedures.IsNullOrEmpty())
            {
                insert.Insert(p => p.procedures == model.procedures);
            }
            if (!model.productionTime.IsNullOrEmpty())
            {
                insert.Insert(p => p.productionTime == model.productionTime);
            }
            if (!model.productionMan.IsNullOrEmpty())
            {
                insert.Insert(p => p.productionMan == model.productionMan);
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
        public int InsertReturnKey(Distribution model, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var insert = new LambdaInsert<Distribution>();
            if (!model.ProductionId.IsNullOrEmpty())
            {
                insert.Insert(p => p.ProductionId == model.ProductionId);
            }
            if (!model.procedures.IsNullOrEmpty())
            {
                insert.Insert(p => p.procedures == model.procedures);
            }
            if (!model.productionTime.IsNullOrEmpty())
            {
                insert.Insert(p => p.productionTime == model.productionTime);
            }
            if (!model.productionMan.IsNullOrEmpty())
            {
                insert.Insert(p => p.productionMan == model.productionMan);
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
        public List<Distribution> SelectAll(Distribution model = null, string SelectFiled = null, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var query = new LambdaQuery<Distribution>();
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
                if (!model.procedures.IsNullOrEmpty())
                {
                    query.Where(p => p.procedures == model.procedures);
                }
                if (!model.productionTime.IsNullOrEmpty())
                {
                    query.Where(p => p.productionTime == model.productionTime);
                }
                if (!model.productionMan.IsNullOrEmpty())
                {
                    query.Where(p => p.productionMan == model.productionMan);
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
                if (SelectFiled.Contains("procedures,"))
                {
                    query.Select(p => new { p.procedures });
                }
                if (SelectFiled.Contains("productiontime,"))
                {
                    query.Select(p => new { p.productionTime });
                }
                if (SelectFiled.Contains("productionman,"))
                {
                    query.Select(p => new { p.productionMan });
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
        public int SelectCount(Distribution model = null, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var query = new LambdaQuery<Distribution>();
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
                if (!model.procedures.IsNullOrEmpty())
                {
                    query.Where(p => p.procedures == model.procedures);
                }
                if (!model.productionTime.IsNullOrEmpty())
                {
                    query.Where(p => p.productionTime == model.productionTime);
                }
                if (!model.productionMan.IsNullOrEmpty())
                {
                    query.Where(p => p.productionMan == model.productionMan);
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
        public Distribution SelectById(int KeyId, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var query = new LambdaQuery<Distribution>();
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
        public List<Distribution> SelectByKeys(string Key,List<string> KeyIds, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var query = new LambdaQuery<Distribution>();
            if("id" == Key.ToLowerInvariant())
            {
                query.Where(p => p.Id.In(KeyIds));
            }
            if("productionid" == Key.ToLowerInvariant())
            {
                query.Where(p => p.ProductionId.In(KeyIds));
            }
            if("procedures" == Key.ToLowerInvariant())
            {
                query.Where(p => p.procedures.In(KeyIds));
            }
            if("productiontime" == Key.ToLowerInvariant())
            {
                query.Where(p => p.productionTime.In(KeyIds));
            }
            if("productionman" == Key.ToLowerInvariant())
            {
                query.Where(p => p.productionMan.In(KeyIds));
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
        public List<Distribution> SelectByPage(string Key, int start, int PageSize, bool desc = true,Distribution model = null, string SelectFiled = null, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var query = new LambdaQuery<Distribution>();
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
                if (!model.procedures.IsNullOrEmpty())
                {
                    query.Where(p => p.procedures == model.procedures);
                }
                if (!model.productionTime.IsNullOrEmpty())
                {
                    query.Where(p => p.productionTime == model.productionTime);
                }
                if (!model.productionMan.IsNullOrEmpty())
                {
                    query.Where(p => p.productionMan == model.productionMan);
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
                if (SelectFiled.Contains("procedures,"))
                {
                    query.Select(p => new { p.procedures });
                }
                if (SelectFiled.Contains("productiontime,"))
                {
                    query.Select(p => new { p.productionTime });
                }
                if (SelectFiled.Contains("productionman,"))
                {
                    query.Select(p => new { p.productionMan });
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
