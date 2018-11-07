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
    public partial class Commodity_Stage_PriceOper : SingleTon<Commodity_Stage_PriceOper>
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
            var delete = new LambdaDelete<Commodity_Stage_Price>();
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
        public bool DeleteModel(Commodity_Stage_Price model = null, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var delete = new LambdaDelete<Commodity_Stage_Price>();
            if (model != null)
            {
                if (!model.Id.IsNullOrEmpty())
                {
                    delete.Where(p => p.Id == model.Id);
                }
                if (!model.CommodityId.IsNullOrEmpty())
                {
                    delete.Where(p => p.CommodityId == model.CommodityId);
                }
                if (!model.StageAmount.IsNullOrEmpty())
                {
                    delete.Where(p => p.StageAmount == model.StageAmount);
                }
                if (!model.StagePrice.IsNullOrEmpty())
                {
                    delete.Where(p => p.StagePrice == model.StagePrice);
                }
                if (!model.DiscountRate.IsNullOrEmpty())
                {
                    delete.Where(p => p.DiscountRate == model.DiscountRate);
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
        public bool Update(Commodity_Stage_Price model, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var update = new LambdaUpdate<Commodity_Stage_Price>();
            if (!model.Id.IsNullOrEmpty())
            {
                update.Where(p => p.Id == model.Id);
            }
            if (!model.CommodityId.IsNullOrEmpty())
            {
                update.Set(p => p.CommodityId == model.CommodityId);
            }
            if (!model.StageAmount.IsNullOrEmpty())
            {
                update.Set(p => p.StageAmount == model.StageAmount);
            }
            if (!model.StagePrice.IsNullOrEmpty())
            {
                update.Set(p => p.StagePrice == model.StagePrice);
            }
            if (!model.DiscountRate.IsNullOrEmpty())
            {
                update.Set(p => p.DiscountRate == model.DiscountRate);
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
        public bool Insert(Commodity_Stage_Price model, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var insert = new LambdaInsert<Commodity_Stage_Price>();
            if (!model.CommodityId.IsNullOrEmpty())
            {
                insert.Insert(p => p.CommodityId == model.CommodityId);
            }
            if (!model.StageAmount.IsNullOrEmpty())
            {
                insert.Insert(p => p.StageAmount == model.StageAmount);
            }
            if (!model.StagePrice.IsNullOrEmpty())
            {
                insert.Insert(p => p.StagePrice == model.StagePrice);
            }
            if (!model.DiscountRate.IsNullOrEmpty())
            {
                insert.Insert(p => p.DiscountRate == model.DiscountRate);
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
        public int InsertReturnKey(Commodity_Stage_Price model, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var insert = new LambdaInsert<Commodity_Stage_Price>();
            if (!model.CommodityId.IsNullOrEmpty())
            {
                insert.Insert(p => p.CommodityId == model.CommodityId);
            }
            if (!model.StageAmount.IsNullOrEmpty())
            {
                insert.Insert(p => p.StageAmount == model.StageAmount);
            }
            if (!model.StagePrice.IsNullOrEmpty())
            {
                insert.Insert(p => p.StagePrice == model.StagePrice);
            }
            if (!model.DiscountRate.IsNullOrEmpty())
            {
                insert.Insert(p => p.DiscountRate == model.DiscountRate);
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
        public List<Commodity_Stage_Price> SelectAll(Commodity_Stage_Price model = null, string SelectFiled = null, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var query = new LambdaQuery<Commodity_Stage_Price>();
            if (model != null)
            {
                if (!model.Id.IsNullOrEmpty())
                {
                    query.Where(p => p.Id == model.Id);
                }
                if (!model.CommodityId.IsNullOrEmpty())
                {
                    query.Where(p => p.CommodityId == model.CommodityId);
                }
                if (!model.StageAmount.IsNullOrEmpty())
                {
                    query.Where(p => p.StageAmount == model.StageAmount);
                }
                if (!model.StagePrice.IsNullOrEmpty())
                {
                    query.Where(p => p.StagePrice == model.StagePrice);
                }
                if (!model.DiscountRate.IsNullOrEmpty())
                {
                    query.Where(p => p.DiscountRate == model.DiscountRate);
                }
            }
            if (SelectFiled != null)
            {
                SelectFiled = SelectFiled.ToLowerInvariant();
                if (SelectFiled.Contains("id,"))
                {
                    query.Select(p => new { p.Id });
                }
                if (SelectFiled.Contains("commodityid,"))
                {
                    query.Select(p => new { p.CommodityId });
                }
                if (SelectFiled.Contains("stageamount,"))
                {
                    query.Select(p => new { p.StageAmount });
                }
                if (SelectFiled.Contains("stageprice,"))
                {
                    query.Select(p => new { p.StagePrice });
                }
                if (SelectFiled.Contains("discountrate,"))
                {
                    query.Select(p => new { p.DiscountRate });
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
        public int SelectCount(Commodity_Stage_Price model = null, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var query = new LambdaQuery<Commodity_Stage_Price>();
            if (model != null)
            {
                if (!model.Id.IsNullOrEmpty())
                {
                    query.Where(p => p.Id == model.Id);
                }
                if (!model.CommodityId.IsNullOrEmpty())
                {
                    query.Where(p => p.CommodityId == model.CommodityId);
                }
                if (!model.StageAmount.IsNullOrEmpty())
                {
                    query.Where(p => p.StageAmount == model.StageAmount);
                }
                if (!model.StagePrice.IsNullOrEmpty())
                {
                    query.Where(p => p.StagePrice == model.StagePrice);
                }
                if (!model.DiscountRate.IsNullOrEmpty())
                {
                    query.Where(p => p.DiscountRate == model.DiscountRate);
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
        public Commodity_Stage_Price SelectById(int KeyId, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var query = new LambdaQuery<Commodity_Stage_Price>();
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
        public List<Commodity_Stage_Price> SelectByKeys(string Key,List<string> KeyIds, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var query = new LambdaQuery<Commodity_Stage_Price>();
            if("id" == Key.ToLowerInvariant())
            {
                query.Where(p => p.Id.In(KeyIds));
            }
            if("commodityid" == Key.ToLowerInvariant())
            {
                query.Where(p => p.CommodityId.In(KeyIds));
            }
            if("stageamount" == Key.ToLowerInvariant())
            {
                query.Where(p => p.StageAmount.In(KeyIds));
            }
            if("stageprice" == Key.ToLowerInvariant())
            {
                query.Where(p => p.StagePrice.In(KeyIds));
            }
            if("discountrate" == Key.ToLowerInvariant())
            {
                query.Where(p => p.DiscountRate.In(KeyIds));
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
        public List<Commodity_Stage_Price> SelectByPage(string Key, int start, int PageSize, bool desc = true,Commodity_Stage_Price model = null, string SelectFiled = null, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var query = new LambdaQuery<Commodity_Stage_Price>();
            if (model != null)
            {
                if (!model.Id.IsNullOrEmpty())
                {
                    query.Where(p => p.Id == model.Id);
                }
                if (!model.CommodityId.IsNullOrEmpty())
                {
                    query.Where(p => p.CommodityId == model.CommodityId);
                }
                if (!model.StageAmount.IsNullOrEmpty())
                {
                    query.Where(p => p.StageAmount == model.StageAmount);
                }
                if (!model.StagePrice.IsNullOrEmpty())
                {
                    query.Where(p => p.StagePrice == model.StagePrice);
                }
                if (!model.DiscountRate.IsNullOrEmpty())
                {
                    query.Where(p => p.DiscountRate == model.DiscountRate);
                }
            }
            if (SelectFiled != null)
            {
                SelectFiled = SelectFiled.ToLowerInvariant();
                if (SelectFiled.Contains("id,"))
                {
                    query.Select(p => new { p.Id });
                }
                if (SelectFiled.Contains("commodityid,"))
                {
                    query.Select(p => new { p.CommodityId });
                }
                if (SelectFiled.Contains("stageamount,"))
                {
                    query.Select(p => new { p.StageAmount });
                }
                if (SelectFiled.Contains("stageprice,"))
                {
                    query.Select(p => new { p.StagePrice });
                }
                if (SelectFiled.Contains("discountrate,"))
                {
                    query.Select(p => new { p.DiscountRate });
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
