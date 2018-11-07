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
    public partial class StorageOper : SingleTon<StorageOper>
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
            var delete = new LambdaDelete<Storage>();
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
        public bool DeleteModel(Storage model = null, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var delete = new LambdaDelete<Storage>();
            if (model != null)
            {
                if (!model.Id.IsNullOrEmpty())
                {
                    delete.Where(p => p.Id == model.Id);
                }
                if (!model.WarehouseId.IsNullOrEmpty())
                {
                    delete.Where(p => p.WarehouseId == model.WarehouseId);
                }
                if (!model.ProducerId.IsNullOrEmpty())
                {
                    delete.Where(p => p.ProducerId == model.ProducerId);
                }
                if (!model.Raw_materialsId.IsNullOrEmpty())
                {
                    delete.Where(p => p.Raw_materialsId == model.Raw_materialsId);
                }
                if (!model.stock.IsNullOrEmpty())
                {
                    delete.Where(p => p.stock == model.stock);
                }
                if (!model.freeze_stock.IsNullOrEmpty())
                {
                    delete.Where(p => p.freeze_stock == model.freeze_stock);
                }
                if (!model.Color.IsNullOrEmpty())
                {
                    delete.Where(p => p.Color == model.Color);
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
        public bool Update(Storage model, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var update = new LambdaUpdate<Storage>();
            if (!model.Id.IsNullOrEmpty())
            {
                update.Where(p => p.Id == model.Id);
            }
            if (!model.WarehouseId.IsNullOrEmpty())
            {
                update.Set(p => p.WarehouseId == model.WarehouseId);
            }
            if (!model.ProducerId.IsNullOrEmpty())
            {
                update.Set(p => p.ProducerId == model.ProducerId);
            }
            if (!model.Raw_materialsId.IsNullOrEmpty())
            {
                update.Set(p => p.Raw_materialsId == model.Raw_materialsId);
            }
            if (!model.stock.IsNullOrEmpty())
            {
                update.Set(p => p.stock == model.stock);
            }
            if (!model.freeze_stock.IsNullOrEmpty())
            {
                update.Set(p => p.freeze_stock == model.freeze_stock);
            }
            if (!model.Color.IsNullOrEmpty())
            {
                update.Set(p => p.Color == model.Color);
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
        public bool Insert(Storage model, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var insert = new LambdaInsert<Storage>();
            if (!model.WarehouseId.IsNullOrEmpty())
            {
                insert.Insert(p => p.WarehouseId == model.WarehouseId);
            }
            if (!model.ProducerId.IsNullOrEmpty())
            {
                insert.Insert(p => p.ProducerId == model.ProducerId);
            }
            if (!model.Raw_materialsId.IsNullOrEmpty())
            {
                insert.Insert(p => p.Raw_materialsId == model.Raw_materialsId);
            }
            if (!model.stock.IsNullOrEmpty())
            {
                insert.Insert(p => p.stock == model.stock);
            }
            if (!model.freeze_stock.IsNullOrEmpty())
            {
                insert.Insert(p => p.freeze_stock == model.freeze_stock);
            }
            if (!model.Color.IsNullOrEmpty())
            {
                insert.Insert(p => p.Color == model.Color);
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
        public int InsertReturnKey(Storage model, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var insert = new LambdaInsert<Storage>();
            if (!model.WarehouseId.IsNullOrEmpty())
            {
                insert.Insert(p => p.WarehouseId == model.WarehouseId);
            }
            if (!model.ProducerId.IsNullOrEmpty())
            {
                insert.Insert(p => p.ProducerId == model.ProducerId);
            }
            if (!model.Raw_materialsId.IsNullOrEmpty())
            {
                insert.Insert(p => p.Raw_materialsId == model.Raw_materialsId);
            }
            if (!model.stock.IsNullOrEmpty())
            {
                insert.Insert(p => p.stock == model.stock);
            }
            if (!model.freeze_stock.IsNullOrEmpty())
            {
                insert.Insert(p => p.freeze_stock == model.freeze_stock);
            }
            if (!model.Color.IsNullOrEmpty())
            {
                insert.Insert(p => p.Color == model.Color);
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
        public List<Storage> SelectAll(Storage model = null, string SelectFiled = null, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var query = new LambdaQuery<Storage>();
            if (model != null)
            {
                if (!model.Id.IsNullOrEmpty())
                {
                    query.Where(p => p.Id == model.Id);
                }
                if (!model.WarehouseId.IsNullOrEmpty())
                {
                    query.Where(p => p.WarehouseId == model.WarehouseId);
                }
                if (!model.ProducerId.IsNullOrEmpty())
                {
                    query.Where(p => p.ProducerId == model.ProducerId);
                }
                if (!model.Raw_materialsId.IsNullOrEmpty())
                {
                    query.Where(p => p.Raw_materialsId == model.Raw_materialsId);
                }
                if (!model.stock.IsNullOrEmpty())
                {
                    query.Where(p => p.stock == model.stock);
                }
                if (!model.freeze_stock.IsNullOrEmpty())
                {
                    query.Where(p => p.freeze_stock == model.freeze_stock);
                }
                if (!model.Color.IsNullOrEmpty())
                {
                    query.Where(p => p.Color == model.Color);
                }
            }
            if (SelectFiled != null)
            {
                SelectFiled = SelectFiled.ToLowerInvariant();
                if (SelectFiled.Contains("id,"))
                {
                    query.Select(p => new { p.Id });
                }
                if (SelectFiled.Contains("warehouseid,"))
                {
                    query.Select(p => new { p.WarehouseId });
                }
                if (SelectFiled.Contains("producerid,"))
                {
                    query.Select(p => new { p.ProducerId });
                }
                if (SelectFiled.Contains("raw_materialsid,"))
                {
                    query.Select(p => new { p.Raw_materialsId });
                }
                if (SelectFiled.Contains("stock,"))
                {
                    query.Select(p => new { p.stock });
                }
                if (SelectFiled.Contains("freeze_stock,"))
                {
                    query.Select(p => new { p.freeze_stock });
                }
                if (SelectFiled.Contains("color,"))
                {
                    query.Select(p => new { p.Color });
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
        public int SelectCount(Storage model = null, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var query = new LambdaQuery<Storage>();
            if (model != null)
            {
                if (!model.Id.IsNullOrEmpty())
                {
                    query.Where(p => p.Id == model.Id);
                }
                if (!model.WarehouseId.IsNullOrEmpty())
                {
                    query.Where(p => p.WarehouseId == model.WarehouseId);
                }
                if (!model.ProducerId.IsNullOrEmpty())
                {
                    query.Where(p => p.ProducerId == model.ProducerId);
                }
                if (!model.Raw_materialsId.IsNullOrEmpty())
                {
                    query.Where(p => p.Raw_materialsId == model.Raw_materialsId);
                }
                if (!model.stock.IsNullOrEmpty())
                {
                    query.Where(p => p.stock == model.stock);
                }
                if (!model.freeze_stock.IsNullOrEmpty())
                {
                    query.Where(p => p.freeze_stock == model.freeze_stock);
                }
                if (!model.Color.IsNullOrEmpty())
                {
                    query.Where(p => p.Color == model.Color);
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
        public Storage SelectById(int KeyId, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var query = new LambdaQuery<Storage>();
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
        public List<Storage> SelectByKeys(string Key,List<string> KeyIds, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var query = new LambdaQuery<Storage>();
            if("id" == Key.ToLowerInvariant())
            {
                query.Where(p => p.Id.In(KeyIds));
            }
            if("warehouseid" == Key.ToLowerInvariant())
            {
                query.Where(p => p.WarehouseId.In(KeyIds));
            }
            if("producerid" == Key.ToLowerInvariant())
            {
                query.Where(p => p.ProducerId.In(KeyIds));
            }
            if("raw_materialsid" == Key.ToLowerInvariant())
            {
                query.Where(p => p.Raw_materialsId.In(KeyIds));
            }
            if("stock" == Key.ToLowerInvariant())
            {
                query.Where(p => p.stock.In(KeyIds));
            }
            if("freeze_stock" == Key.ToLowerInvariant())
            {
                query.Where(p => p.freeze_stock.In(KeyIds));
            }
            if("color" == Key.ToLowerInvariant())
            {
                query.Where(p => p.Color.In(KeyIds));
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
        public List<Storage> SelectByPage(string Key, int start, int PageSize, bool desc = true,Storage model = null, string SelectFiled = null, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var query = new LambdaQuery<Storage>();
            if (model != null)
            {
                if (!model.Id.IsNullOrEmpty())
                {
                    query.Where(p => p.Id == model.Id);
                }
                if (!model.WarehouseId.IsNullOrEmpty())
                {
                    query.Where(p => p.WarehouseId == model.WarehouseId);
                }
                if (!model.ProducerId.IsNullOrEmpty())
                {
                    query.Where(p => p.ProducerId == model.ProducerId);
                }
                if (!model.Raw_materialsId.IsNullOrEmpty())
                {
                    query.Where(p => p.Raw_materialsId == model.Raw_materialsId);
                }
                if (!model.stock.IsNullOrEmpty())
                {
                    query.Where(p => p.stock == model.stock);
                }
                if (!model.freeze_stock.IsNullOrEmpty())
                {
                    query.Where(p => p.freeze_stock == model.freeze_stock);
                }
                if (!model.Color.IsNullOrEmpty())
                {
                    query.Where(p => p.Color == model.Color);
                }
            }
            if (SelectFiled != null)
            {
                SelectFiled = SelectFiled.ToLowerInvariant();
                if (SelectFiled.Contains("id,"))
                {
                    query.Select(p => new { p.Id });
                }
                if (SelectFiled.Contains("warehouseid,"))
                {
                    query.Select(p => new { p.WarehouseId });
                }
                if (SelectFiled.Contains("producerid,"))
                {
                    query.Select(p => new { p.ProducerId });
                }
                if (SelectFiled.Contains("raw_materialsid,"))
                {
                    query.Select(p => new { p.Raw_materialsId });
                }
                if (SelectFiled.Contains("stock,"))
                {
                    query.Select(p => new { p.stock });
                }
                if (SelectFiled.Contains("freeze_stock,"))
                {
                    query.Select(p => new { p.freeze_stock });
                }
                if (SelectFiled.Contains("color,"))
                {
                    query.Select(p => new { p.Color });
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
