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
    public partial class Materials_ProducerOper : SingleTon<Materials_ProducerOper>
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
            var delete = new LambdaDelete<Materials_Producer>();
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
        public bool DeleteModel(Materials_Producer model = null, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var delete = new LambdaDelete<Materials_Producer>();
            if (model != null)
            {
                if (!model.Id.IsNullOrEmpty())
                {
                    delete.Where(p => p.Id == model.Id);
                }
                if (!model.ProducerId.IsNullOrEmpty())
                {
                    delete.Where(p => p.ProducerId == model.ProducerId);
                }
                if (!model.MaterialsId.IsNullOrEmpty())
                {
                    delete.Where(p => p.MaterialsId == model.MaterialsId);
                }
                if (!model.FactoryNumber.IsNullOrEmpty())
                {
                    delete.Where(p => p.FactoryNumber == model.FactoryNumber);
                }
                if (!model.PurchasePrice.IsNullOrEmpty())
                {
                    delete.Where(p => p.PurchasePrice == model.PurchasePrice);
                }
                if (!model.QuotationDate.IsNullOrEmpty())
                {
                    delete.Where(p => p.QuotationDate == model.QuotationDate);
                }
                if (!model.ProCycle.IsNullOrEmpty())
                {
                    delete.Where(p => p.ProCycle == model.ProCycle);
                }
                if (!model.MinQuantity.IsNullOrEmpty())
                {
                    delete.Where(p => p.MinQuantity == model.MinQuantity);
                }
                if (!model.PriceTag.IsNullOrEmpty())
                {
                    delete.Where(p => p.PriceTag == model.PriceTag);
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
        public bool Update(Materials_Producer model, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var update = new LambdaUpdate<Materials_Producer>();
            if (!model.Id.IsNullOrEmpty())
            {
                update.Where(p => p.Id == model.Id);
            }
            if (!model.ProducerId.IsNullOrEmpty())
            {
                update.Set(p => p.ProducerId == model.ProducerId);
            }
            if (!model.MaterialsId.IsNullOrEmpty())
            {
                update.Set(p => p.MaterialsId == model.MaterialsId);
            }
            if (!model.FactoryNumber.IsNullOrEmpty())
            {
                update.Set(p => p.FactoryNumber == model.FactoryNumber);
            }
            if (!model.PurchasePrice.IsNullOrEmpty())
            {
                update.Set(p => p.PurchasePrice == model.PurchasePrice);
            }
            if (!model.QuotationDate.IsNullOrEmpty())
            {
                update.Set(p => p.QuotationDate == model.QuotationDate);
            }
            if (!model.ProCycle.IsNullOrEmpty())
            {
                update.Set(p => p.ProCycle == model.ProCycle);
            }
            if (!model.MinQuantity.IsNullOrEmpty())
            {
                update.Set(p => p.MinQuantity == model.MinQuantity);
            }
            if (!model.PriceTag.IsNullOrEmpty())
            {
                update.Set(p => p.PriceTag == model.PriceTag);
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
        public bool Insert(Materials_Producer model, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var insert = new LambdaInsert<Materials_Producer>();
            if (!model.ProducerId.IsNullOrEmpty())
            {
                insert.Insert(p => p.ProducerId == model.ProducerId);
            }
            if (!model.MaterialsId.IsNullOrEmpty())
            {
                insert.Insert(p => p.MaterialsId == model.MaterialsId);
            }
            if (!model.FactoryNumber.IsNullOrEmpty())
            {
                insert.Insert(p => p.FactoryNumber == model.FactoryNumber);
            }
            if (!model.PurchasePrice.IsNullOrEmpty())
            {
                insert.Insert(p => p.PurchasePrice == model.PurchasePrice);
            }
            if (!model.QuotationDate.IsNullOrEmpty())
            {
                insert.Insert(p => p.QuotationDate == model.QuotationDate);
            }
            if (!model.ProCycle.IsNullOrEmpty())
            {
                insert.Insert(p => p.ProCycle == model.ProCycle);
            }
            if (!model.MinQuantity.IsNullOrEmpty())
            {
                insert.Insert(p => p.MinQuantity == model.MinQuantity);
            }
            if (!model.PriceTag.IsNullOrEmpty())
            {
                insert.Insert(p => p.PriceTag == model.PriceTag);
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
        public int InsertReturnKey(Materials_Producer model, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var insert = new LambdaInsert<Materials_Producer>();
            if (!model.ProducerId.IsNullOrEmpty())
            {
                insert.Insert(p => p.ProducerId == model.ProducerId);
            }
            if (!model.MaterialsId.IsNullOrEmpty())
            {
                insert.Insert(p => p.MaterialsId == model.MaterialsId);
            }
            if (!model.FactoryNumber.IsNullOrEmpty())
            {
                insert.Insert(p => p.FactoryNumber == model.FactoryNumber);
            }
            if (!model.PurchasePrice.IsNullOrEmpty())
            {
                insert.Insert(p => p.PurchasePrice == model.PurchasePrice);
            }
            if (!model.QuotationDate.IsNullOrEmpty())
            {
                insert.Insert(p => p.QuotationDate == model.QuotationDate);
            }
            if (!model.ProCycle.IsNullOrEmpty())
            {
                insert.Insert(p => p.ProCycle == model.ProCycle);
            }
            if (!model.MinQuantity.IsNullOrEmpty())
            {
                insert.Insert(p => p.MinQuantity == model.MinQuantity);
            }
            if (!model.PriceTag.IsNullOrEmpty())
            {
                insert.Insert(p => p.PriceTag == model.PriceTag);
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
        public List<Materials_Producer> SelectAll(Materials_Producer model = null, string SelectFiled = null, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var query = new LambdaQuery<Materials_Producer>();
            if (model != null)
            {
                if (!model.Id.IsNullOrEmpty())
                {
                    query.Where(p => p.Id == model.Id);
                }
                if (!model.ProducerId.IsNullOrEmpty())
                {
                    query.Where(p => p.ProducerId == model.ProducerId);
                }
                if (!model.MaterialsId.IsNullOrEmpty())
                {
                    query.Where(p => p.MaterialsId == model.MaterialsId);
                }
                if (!model.FactoryNumber.IsNullOrEmpty())
                {
                    query.Where(p => p.FactoryNumber == model.FactoryNumber);
                }
                if (!model.PurchasePrice.IsNullOrEmpty())
                {
                    query.Where(p => p.PurchasePrice == model.PurchasePrice);
                }
                if (!model.QuotationDate.IsNullOrEmpty())
                {
                    query.Where(p => p.QuotationDate == model.QuotationDate);
                }
                if (!model.ProCycle.IsNullOrEmpty())
                {
                    query.Where(p => p.ProCycle == model.ProCycle);
                }
                if (!model.MinQuantity.IsNullOrEmpty())
                {
                    query.Where(p => p.MinQuantity == model.MinQuantity);
                }
                if (!model.PriceTag.IsNullOrEmpty())
                {
                    query.Where(p => p.PriceTag == model.PriceTag);
                }
            }
            if (SelectFiled != null)
            {
                SelectFiled = SelectFiled.ToLowerInvariant();
                if (SelectFiled.Contains("id,"))
                {
                    query.Select(p => new { p.Id });
                }
                if (SelectFiled.Contains("producerid,"))
                {
                    query.Select(p => new { p.ProducerId });
                }
                if (SelectFiled.Contains("materialsid,"))
                {
                    query.Select(p => new { p.MaterialsId });
                }
                if (SelectFiled.Contains("factorynumber,"))
                {
                    query.Select(p => new { p.FactoryNumber });
                }
                if (SelectFiled.Contains("purchaseprice,"))
                {
                    query.Select(p => new { p.PurchasePrice });
                }
                if (SelectFiled.Contains("quotationdate,"))
                {
                    query.Select(p => new { p.QuotationDate });
                }
                if (SelectFiled.Contains("procycle,"))
                {
                    query.Select(p => new { p.ProCycle });
                }
                if (SelectFiled.Contains("minquantity,"))
                {
                    query.Select(p => new { p.MinQuantity });
                }
                if (SelectFiled.Contains("pricetag,"))
                {
                    query.Select(p => new { p.PriceTag });
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
        public int SelectCount(Materials_Producer model = null, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var query = new LambdaQuery<Materials_Producer>();
            if (model != null)
            {
                if (!model.Id.IsNullOrEmpty())
                {
                    query.Where(p => p.Id == model.Id);
                }
                if (!model.ProducerId.IsNullOrEmpty())
                {
                    query.Where(p => p.ProducerId == model.ProducerId);
                }
                if (!model.MaterialsId.IsNullOrEmpty())
                {
                    query.Where(p => p.MaterialsId == model.MaterialsId);
                }
                if (!model.FactoryNumber.IsNullOrEmpty())
                {
                    query.Where(p => p.FactoryNumber == model.FactoryNumber);
                }
                if (!model.PurchasePrice.IsNullOrEmpty())
                {
                    query.Where(p => p.PurchasePrice == model.PurchasePrice);
                }
                if (!model.QuotationDate.IsNullOrEmpty())
                {
                    query.Where(p => p.QuotationDate == model.QuotationDate);
                }
                if (!model.ProCycle.IsNullOrEmpty())
                {
                    query.Where(p => p.ProCycle == model.ProCycle);
                }
                if (!model.MinQuantity.IsNullOrEmpty())
                {
                    query.Where(p => p.MinQuantity == model.MinQuantity);
                }
                if (!model.PriceTag.IsNullOrEmpty())
                {
                    query.Where(p => p.PriceTag == model.PriceTag);
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
        public Materials_Producer SelectById(int KeyId, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var query = new LambdaQuery<Materials_Producer>();
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
        public List<Materials_Producer> SelectByKeys(string Key,List<string> KeyIds, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var query = new LambdaQuery<Materials_Producer>();
            if("id" == Key.ToLowerInvariant())
            {
                query.Where(p => p.Id.In(KeyIds));
            }
            if("producerid" == Key.ToLowerInvariant())
            {
                query.Where(p => p.ProducerId.In(KeyIds));
            }
            if("materialsid" == Key.ToLowerInvariant())
            {
                query.Where(p => p.MaterialsId.In(KeyIds));
            }
            if("factorynumber" == Key.ToLowerInvariant())
            {
                query.Where(p => p.FactoryNumber.In(KeyIds));
            }
            if("purchaseprice" == Key.ToLowerInvariant())
            {
                query.Where(p => p.PurchasePrice.In(KeyIds));
            }
            if("quotationdate" == Key.ToLowerInvariant())
            {
                query.Where(p => p.QuotationDate.In(KeyIds));
            }
            if("procycle" == Key.ToLowerInvariant())
            {
                query.Where(p => p.ProCycle.In(KeyIds));
            }
            if("minquantity" == Key.ToLowerInvariant())
            {
                query.Where(p => p.MinQuantity.In(KeyIds));
            }
            if("pricetag" == Key.ToLowerInvariant())
            {
                query.Where(p => p.PriceTag.In(KeyIds));
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
        public List<Materials_Producer> SelectByPage(string Key, int start, int PageSize, bool desc = true,Materials_Producer model = null, string SelectFiled = null, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var query = new LambdaQuery<Materials_Producer>();
            if (model != null)
            {
                if (!model.Id.IsNullOrEmpty())
                {
                    query.Where(p => p.Id == model.Id);
                }
                if (!model.ProducerId.IsNullOrEmpty())
                {
                    query.Where(p => p.ProducerId == model.ProducerId);
                }
                if (!model.MaterialsId.IsNullOrEmpty())
                {
                    query.Where(p => p.MaterialsId == model.MaterialsId);
                }
                if (!model.FactoryNumber.IsNullOrEmpty())
                {
                    query.Where(p => p.FactoryNumber == model.FactoryNumber);
                }
                if (!model.PurchasePrice.IsNullOrEmpty())
                {
                    query.Where(p => p.PurchasePrice == model.PurchasePrice);
                }
                if (!model.QuotationDate.IsNullOrEmpty())
                {
                    query.Where(p => p.QuotationDate == model.QuotationDate);
                }
                if (!model.ProCycle.IsNullOrEmpty())
                {
                    query.Where(p => p.ProCycle == model.ProCycle);
                }
                if (!model.MinQuantity.IsNullOrEmpty())
                {
                    query.Where(p => p.MinQuantity == model.MinQuantity);
                }
                if (!model.PriceTag.IsNullOrEmpty())
                {
                    query.Where(p => p.PriceTag == model.PriceTag);
                }
            }
            if (SelectFiled != null)
            {
                SelectFiled = SelectFiled.ToLowerInvariant();
                if (SelectFiled.Contains("id,"))
                {
                    query.Select(p => new { p.Id });
                }
                if (SelectFiled.Contains("producerid,"))
                {
                    query.Select(p => new { p.ProducerId });
                }
                if (SelectFiled.Contains("materialsid,"))
                {
                    query.Select(p => new { p.MaterialsId });
                }
                if (SelectFiled.Contains("factorynumber,"))
                {
                    query.Select(p => new { p.FactoryNumber });
                }
                if (SelectFiled.Contains("purchaseprice,"))
                {
                    query.Select(p => new { p.PurchasePrice });
                }
                if (SelectFiled.Contains("quotationdate,"))
                {
                    query.Select(p => new { p.QuotationDate });
                }
                if (SelectFiled.Contains("procycle,"))
                {
                    query.Select(p => new { p.ProCycle });
                }
                if (SelectFiled.Contains("minquantity,"))
                {
                    query.Select(p => new { p.MinQuantity });
                }
                if (SelectFiled.Contains("pricetag,"))
                {
                    query.Select(p => new { p.PriceTag });
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
