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
    public partial class Receive_MaterialsOper : SingleTon<Receive_MaterialsOper>
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
            var delete = new LambdaDelete<Receive_Materials>();
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
        public bool DeleteModel(Receive_Materials model = null, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var delete = new LambdaDelete<Receive_Materials>();
            if (model != null)
            {
                if (!model.Id.IsNullOrEmpty())
                {
                    delete.Where(p => p.Id == model.Id);
                }
                if (!model.receiveId.IsNullOrEmpty())
                {
                    delete.Where(p => p.receiveId == model.receiveId);
                }
                if (!model.raw_materialsId.IsNullOrEmpty())
                {
                    delete.Where(p => p.raw_materialsId == model.raw_materialsId);
                }
                if (!model.BaseCount.IsNullOrEmpty())
                {
                    delete.Where(p => p.BaseCount == model.BaseCount);
                }
                if (!model.additionalCount.IsNullOrEmpty())
                {
                    delete.Where(p => p.additionalCount == model.additionalCount);
                }
                if (!model.SKU.IsNullOrEmpty())
                {
                    delete.Where(p => p.SKU == model.SKU);
                }
                if (!model.Isadditional.IsNullOrEmpty())
                {
                    delete.Where(p => p.Isadditional == model.Isadditional);
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
        public bool Update(Receive_Materials model, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var update = new LambdaUpdate<Receive_Materials>();
            if (!model.Id.IsNullOrEmpty())
            {
                update.Where(p => p.Id == model.Id);
            }
            if (!model.receiveId.IsNullOrEmpty())
            {
                update.Set(p => p.receiveId == model.receiveId);
            }
            if (!model.raw_materialsId.IsNullOrEmpty())
            {
                update.Set(p => p.raw_materialsId == model.raw_materialsId);
            }
            if (!model.BaseCount.IsNullOrEmpty())
            {
                update.Set(p => p.BaseCount == model.BaseCount);
            }
            if (!model.additionalCount.IsNullOrEmpty())
            {
                update.Set(p => p.additionalCount == model.additionalCount);
            }
            if (!model.SKU.IsNullOrEmpty())
            {
                update.Set(p => p.SKU == model.SKU);
            }
            if (!model.Isadditional.IsNullOrEmpty())
            {
                update.Set(p => p.Isadditional == model.Isadditional);
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
        public bool Insert(Receive_Materials model, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var insert = new LambdaInsert<Receive_Materials>();
            if (!model.receiveId.IsNullOrEmpty())
            {
                insert.Insert(p => p.receiveId == model.receiveId);
            }
            if (!model.raw_materialsId.IsNullOrEmpty())
            {
                insert.Insert(p => p.raw_materialsId == model.raw_materialsId);
            }
            if (!model.BaseCount.IsNullOrEmpty())
            {
                insert.Insert(p => p.BaseCount == model.BaseCount);
            }
            if (!model.additionalCount.IsNullOrEmpty())
            {
                insert.Insert(p => p.additionalCount == model.additionalCount);
            }
            if (!model.SKU.IsNullOrEmpty())
            {
                insert.Insert(p => p.SKU == model.SKU);
            }
            if (!model.Isadditional.IsNullOrEmpty())
            {
                insert.Insert(p => p.Isadditional == model.Isadditional);
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
        public int InsertReturnKey(Receive_Materials model, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var insert = new LambdaInsert<Receive_Materials>();
            if (!model.receiveId.IsNullOrEmpty())
            {
                insert.Insert(p => p.receiveId == model.receiveId);
            }
            if (!model.raw_materialsId.IsNullOrEmpty())
            {
                insert.Insert(p => p.raw_materialsId == model.raw_materialsId);
            }
            if (!model.BaseCount.IsNullOrEmpty())
            {
                insert.Insert(p => p.BaseCount == model.BaseCount);
            }
            if (!model.additionalCount.IsNullOrEmpty())
            {
                insert.Insert(p => p.additionalCount == model.additionalCount);
            }
            if (!model.SKU.IsNullOrEmpty())
            {
                insert.Insert(p => p.SKU == model.SKU);
            }
            if (!model.Isadditional.IsNullOrEmpty())
            {
                insert.Insert(p => p.Isadditional == model.Isadditional);
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
        public List<Receive_Materials> SelectAll(Receive_Materials model = null, string SelectFiled = null, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var query = new LambdaQuery<Receive_Materials>();
            if (model != null)
            {
                if (!model.Id.IsNullOrEmpty())
                {
                    query.Where(p => p.Id == model.Id);
                }
                if (!model.receiveId.IsNullOrEmpty())
                {
                    query.Where(p => p.receiveId == model.receiveId);
                }
                if (!model.raw_materialsId.IsNullOrEmpty())
                {
                    query.Where(p => p.raw_materialsId == model.raw_materialsId);
                }
                if (!model.BaseCount.IsNullOrEmpty())
                {
                    query.Where(p => p.BaseCount == model.BaseCount);
                }
                if (!model.additionalCount.IsNullOrEmpty())
                {
                    query.Where(p => p.additionalCount == model.additionalCount);
                }
                if (!model.SKU.IsNullOrEmpty())
                {
                    query.Where(p => p.SKU == model.SKU);
                }
                if (!model.Isadditional.IsNullOrEmpty())
                {
                    query.Where(p => p.Isadditional == model.Isadditional);
                }
            }
            if (SelectFiled != null)
            {
                SelectFiled = SelectFiled.ToLowerInvariant();
                if (SelectFiled.Contains("id,"))
                {
                    query.Select(p => new { p.Id });
                }
                if (SelectFiled.Contains("receiveid,"))
                {
                    query.Select(p => new { p.receiveId });
                }
                if (SelectFiled.Contains("raw_materialsid,"))
                {
                    query.Select(p => new { p.raw_materialsId });
                }
                if (SelectFiled.Contains("basecount,"))
                {
                    query.Select(p => new { p.BaseCount });
                }
                if (SelectFiled.Contains("additionalcount,"))
                {
                    query.Select(p => new { p.additionalCount });
                }
                if (SelectFiled.Contains("sku,"))
                {
                    query.Select(p => new { p.SKU });
                }
                if (SelectFiled.Contains("isadditional,"))
                {
                    query.Select(p => new { p.Isadditional });
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
        public int SelectCount(Receive_Materials model = null, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var query = new LambdaQuery<Receive_Materials>();
            if (model != null)
            {
                if (!model.Id.IsNullOrEmpty())
                {
                    query.Where(p => p.Id == model.Id);
                }
                if (!model.receiveId.IsNullOrEmpty())
                {
                    query.Where(p => p.receiveId == model.receiveId);
                }
                if (!model.raw_materialsId.IsNullOrEmpty())
                {
                    query.Where(p => p.raw_materialsId == model.raw_materialsId);
                }
                if (!model.BaseCount.IsNullOrEmpty())
                {
                    query.Where(p => p.BaseCount == model.BaseCount);
                }
                if (!model.additionalCount.IsNullOrEmpty())
                {
                    query.Where(p => p.additionalCount == model.additionalCount);
                }
                if (!model.SKU.IsNullOrEmpty())
                {
                    query.Where(p => p.SKU == model.SKU);
                }
                if (!model.Isadditional.IsNullOrEmpty())
                {
                    query.Where(p => p.Isadditional == model.Isadditional);
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
        public Receive_Materials SelectById(int KeyId, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var query = new LambdaQuery<Receive_Materials>();
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
        public List<Receive_Materials> SelectByKeys(string Key,List<string> KeyIds, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var query = new LambdaQuery<Receive_Materials>();
            if("id" == Key.ToLowerInvariant())
            {
                query.Where(p => p.Id.In(KeyIds));
            }
            if("receiveid" == Key.ToLowerInvariant())
            {
                query.Where(p => p.receiveId.In(KeyIds));
            }
            if("raw_materialsid" == Key.ToLowerInvariant())
            {
                query.Where(p => p.raw_materialsId.In(KeyIds));
            }
            if("basecount" == Key.ToLowerInvariant())
            {
                query.Where(p => p.BaseCount.In(KeyIds));
            }
            if("additionalcount" == Key.ToLowerInvariant())
            {
                query.Where(p => p.additionalCount.In(KeyIds));
            }
            if("sku" == Key.ToLowerInvariant())
            {
                query.Where(p => p.SKU.In(KeyIds));
            }
            if("isadditional" == Key.ToLowerInvariant())
            {
                query.Where(p => p.Isadditional.In(KeyIds));
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
        public List<Receive_Materials> SelectByPage(string Key, int start, int PageSize, bool desc = true,Receive_Materials model = null, string SelectFiled = null, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var query = new LambdaQuery<Receive_Materials>();
            if (model != null)
            {
                if (!model.Id.IsNullOrEmpty())
                {
                    query.Where(p => p.Id == model.Id);
                }
                if (!model.receiveId.IsNullOrEmpty())
                {
                    query.Where(p => p.receiveId == model.receiveId);
                }
                if (!model.raw_materialsId.IsNullOrEmpty())
                {
                    query.Where(p => p.raw_materialsId == model.raw_materialsId);
                }
                if (!model.BaseCount.IsNullOrEmpty())
                {
                    query.Where(p => p.BaseCount == model.BaseCount);
                }
                if (!model.additionalCount.IsNullOrEmpty())
                {
                    query.Where(p => p.additionalCount == model.additionalCount);
                }
                if (!model.SKU.IsNullOrEmpty())
                {
                    query.Where(p => p.SKU == model.SKU);
                }
                if (!model.Isadditional.IsNullOrEmpty())
                {
                    query.Where(p => p.Isadditional == model.Isadditional);
                }
            }
            if (SelectFiled != null)
            {
                SelectFiled = SelectFiled.ToLowerInvariant();
                if (SelectFiled.Contains("id,"))
                {
                    query.Select(p => new { p.Id });
                }
                if (SelectFiled.Contains("receiveid,"))
                {
                    query.Select(p => new { p.receiveId });
                }
                if (SelectFiled.Contains("raw_materialsid,"))
                {
                    query.Select(p => new { p.raw_materialsId });
                }
                if (SelectFiled.Contains("basecount,"))
                {
                    query.Select(p => new { p.BaseCount });
                }
                if (SelectFiled.Contains("additionalcount,"))
                {
                    query.Select(p => new { p.additionalCount });
                }
                if (SelectFiled.Contains("sku,"))
                {
                    query.Select(p => new { p.SKU });
                }
                if (SelectFiled.Contains("isadditional,"))
                {
                    query.Select(p => new { p.Isadditional });
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
