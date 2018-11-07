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
    public partial class Materials_ColorinfoOper : SingleTon<Materials_ColorinfoOper>
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
            var delete = new LambdaDelete<Materials_Colorinfo>();
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
        public bool DeleteModel(Materials_Colorinfo model = null, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var delete = new LambdaDelete<Materials_Colorinfo>();
            if (model != null)
            {
                if (!model.Id.IsNullOrEmpty())
                {
                    delete.Where(p => p.Id == model.Id);
                }
                if (!model.MaterialsId.IsNullOrEmpty())
                {
                    delete.Where(p => p.MaterialsId == model.MaterialsId);
                }
                if (!model.SKU.IsNullOrEmpty())
                {
                    delete.Where(p => p.SKU == model.SKU);
                }
                if (!model.ColorId.IsNullOrEmpty())
                {
                    delete.Where(p => p.ColorId == model.ColorId);
                }
                if (!model.MinStockNum.IsNullOrEmpty())
                {
                    delete.Where(p => p.MinStockNum == model.MinStockNum);
                }
                if (!model.SKUImage.IsNullOrEmpty())
                {
                    delete.Where(p => p.SKUImage == model.SKUImage);
                }
                if (!model.PositionInfo.IsNullOrEmpty())
                {
                    delete.Where(p => p.PositionInfo == model.PositionInfo);
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
        public bool Update(Materials_Colorinfo model, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var update = new LambdaUpdate<Materials_Colorinfo>();
            if (!model.Id.IsNullOrEmpty())
            {
                update.Where(p => p.Id == model.Id);
            }
            if (!model.MaterialsId.IsNullOrEmpty())
            {
                update.Set(p => p.MaterialsId == model.MaterialsId);
            }
            if (!model.SKU.IsNullOrEmpty())
            {
                update.Set(p => p.SKU == model.SKU);
            }
            if (!model.ColorId.IsNullOrEmpty())
            {
                update.Set(p => p.ColorId == model.ColorId);
            }
            if (!model.MinStockNum.IsNullOrEmpty())
            {
                update.Set(p => p.MinStockNum == model.MinStockNum);
            }
            if (!model.SKUImage.IsNullOrEmpty())
            {
                update.Set(p => p.SKUImage == model.SKUImage);
            }
            if (!model.PositionInfo.IsNullOrEmpty())
            {
                update.Set(p => p.PositionInfo == model.PositionInfo);
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
        public bool Insert(Materials_Colorinfo model, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var insert = new LambdaInsert<Materials_Colorinfo>();
            if (!model.MaterialsId.IsNullOrEmpty())
            {
                insert.Insert(p => p.MaterialsId == model.MaterialsId);
            }
            if (!model.SKU.IsNullOrEmpty())
            {
                insert.Insert(p => p.SKU == model.SKU);
            }
            if (!model.ColorId.IsNullOrEmpty())
            {
                insert.Insert(p => p.ColorId == model.ColorId);
            }
            if (!model.MinStockNum.IsNullOrEmpty())
            {
                insert.Insert(p => p.MinStockNum == model.MinStockNum);
            }
            if (!model.SKUImage.IsNullOrEmpty())
            {
                insert.Insert(p => p.SKUImage == model.SKUImage);
            }
            if (!model.PositionInfo.IsNullOrEmpty())
            {
                insert.Insert(p => p.PositionInfo == model.PositionInfo);
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
        public int InsertReturnKey(Materials_Colorinfo model, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var insert = new LambdaInsert<Materials_Colorinfo>();
            if (!model.MaterialsId.IsNullOrEmpty())
            {
                insert.Insert(p => p.MaterialsId == model.MaterialsId);
            }
            if (!model.SKU.IsNullOrEmpty())
            {
                insert.Insert(p => p.SKU == model.SKU);
            }
            if (!model.ColorId.IsNullOrEmpty())
            {
                insert.Insert(p => p.ColorId == model.ColorId);
            }
            if (!model.MinStockNum.IsNullOrEmpty())
            {
                insert.Insert(p => p.MinStockNum == model.MinStockNum);
            }
            if (!model.SKUImage.IsNullOrEmpty())
            {
                insert.Insert(p => p.SKUImage == model.SKUImage);
            }
            if (!model.PositionInfo.IsNullOrEmpty())
            {
                insert.Insert(p => p.PositionInfo == model.PositionInfo);
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
        public List<Materials_Colorinfo> SelectAll(Materials_Colorinfo model = null, string SelectFiled = null, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var query = new LambdaQuery<Materials_Colorinfo>();
            if (model != null)
            {
                if (!model.Id.IsNullOrEmpty())
                {
                    query.Where(p => p.Id == model.Id);
                }
                if (!model.MaterialsId.IsNullOrEmpty())
                {
                    query.Where(p => p.MaterialsId == model.MaterialsId);
                }
                if (!model.SKU.IsNullOrEmpty())
                {
                    query.Where(p => p.SKU == model.SKU);
                }
                if (!model.ColorId.IsNullOrEmpty())
                {
                    query.Where(p => p.ColorId == model.ColorId);
                }
                if (!model.MinStockNum.IsNullOrEmpty())
                {
                    query.Where(p => p.MinStockNum == model.MinStockNum);
                }
                if (!model.SKUImage.IsNullOrEmpty())
                {
                    query.Where(p => p.SKUImage == model.SKUImage);
                }
                if (!model.PositionInfo.IsNullOrEmpty())
                {
                    query.Where(p => p.PositionInfo == model.PositionInfo);
                }
            }
            if (SelectFiled != null)
            {
                SelectFiled = SelectFiled.ToLowerInvariant();
                if (SelectFiled.Contains("id,"))
                {
                    query.Select(p => new { p.Id });
                }
                if (SelectFiled.Contains("materialsid,"))
                {
                    query.Select(p => new { p.MaterialsId });
                }
                if (SelectFiled.Contains("sku,"))
                {
                    query.Select(p => new { p.SKU });
                }
                if (SelectFiled.Contains("colorid,"))
                {
                    query.Select(p => new { p.ColorId });
                }
                if (SelectFiled.Contains("minstocknum,"))
                {
                    query.Select(p => new { p.MinStockNum });
                }
                if (SelectFiled.Contains("skuimage,"))
                {
                    query.Select(p => new { p.SKUImage });
                }
                if (SelectFiled.Contains("positioninfo,"))
                {
                    query.Select(p => new { p.PositionInfo });
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
        public int SelectCount(Materials_Colorinfo model = null, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var query = new LambdaQuery<Materials_Colorinfo>();
            if (model != null)
            {
                if (!model.Id.IsNullOrEmpty())
                {
                    query.Where(p => p.Id == model.Id);
                }
                if (!model.MaterialsId.IsNullOrEmpty())
                {
                    query.Where(p => p.MaterialsId == model.MaterialsId);
                }
                if (!model.SKU.IsNullOrEmpty())
                {
                    query.Where(p => p.SKU == model.SKU);
                }
                if (!model.ColorId.IsNullOrEmpty())
                {
                    query.Where(p => p.ColorId == model.ColorId);
                }
                if (!model.MinStockNum.IsNullOrEmpty())
                {
                    query.Where(p => p.MinStockNum == model.MinStockNum);
                }
                if (!model.SKUImage.IsNullOrEmpty())
                {
                    query.Where(p => p.SKUImage == model.SKUImage);
                }
                if (!model.PositionInfo.IsNullOrEmpty())
                {
                    query.Where(p => p.PositionInfo == model.PositionInfo);
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
        public Materials_Colorinfo SelectById(int KeyId, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var query = new LambdaQuery<Materials_Colorinfo>();
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
        public List<Materials_Colorinfo> SelectByKeys(string Key,List<string> KeyIds, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var query = new LambdaQuery<Materials_Colorinfo>();
            if("id" == Key.ToLowerInvariant())
            {
                query.Where(p => p.Id.In(KeyIds));
            }
            if("materialsid" == Key.ToLowerInvariant())
            {
                query.Where(p => p.MaterialsId.In(KeyIds));
            }
            if("sku" == Key.ToLowerInvariant())
            {
                query.Where(p => p.SKU.In(KeyIds));
            }
            if("colorid" == Key.ToLowerInvariant())
            {
                query.Where(p => p.ColorId.In(KeyIds));
            }
            if("minstocknum" == Key.ToLowerInvariant())
            {
                query.Where(p => p.MinStockNum.In(KeyIds));
            }
            if("skuimage" == Key.ToLowerInvariant())
            {
                query.Where(p => p.SKUImage.In(KeyIds));
            }
            if("positioninfo" == Key.ToLowerInvariant())
            {
                query.Where(p => p.PositionInfo.In(KeyIds));
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
        public List<Materials_Colorinfo> SelectByPage(string Key, int start, int PageSize, bool desc = true,Materials_Colorinfo model = null, string SelectFiled = null, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var query = new LambdaQuery<Materials_Colorinfo>();
            if (model != null)
            {
                if (!model.Id.IsNullOrEmpty())
                {
                    query.Where(p => p.Id == model.Id);
                }
                if (!model.MaterialsId.IsNullOrEmpty())
                {
                    query.Where(p => p.MaterialsId == model.MaterialsId);
                }
                if (!model.SKU.IsNullOrEmpty())
                {
                    query.Where(p => p.SKU == model.SKU);
                }
                if (!model.ColorId.IsNullOrEmpty())
                {
                    query.Where(p => p.ColorId == model.ColorId);
                }
                if (!model.MinStockNum.IsNullOrEmpty())
                {
                    query.Where(p => p.MinStockNum == model.MinStockNum);
                }
                if (!model.SKUImage.IsNullOrEmpty())
                {
                    query.Where(p => p.SKUImage == model.SKUImage);
                }
                if (!model.PositionInfo.IsNullOrEmpty())
                {
                    query.Where(p => p.PositionInfo == model.PositionInfo);
                }
            }
            if (SelectFiled != null)
            {
                SelectFiled = SelectFiled.ToLowerInvariant();
                if (SelectFiled.Contains("id,"))
                {
                    query.Select(p => new { p.Id });
                }
                if (SelectFiled.Contains("materialsid,"))
                {
                    query.Select(p => new { p.MaterialsId });
                }
                if (SelectFiled.Contains("sku,"))
                {
                    query.Select(p => new { p.SKU });
                }
                if (SelectFiled.Contains("colorid,"))
                {
                    query.Select(p => new { p.ColorId });
                }
                if (SelectFiled.Contains("minstocknum,"))
                {
                    query.Select(p => new { p.MinStockNum });
                }
                if (SelectFiled.Contains("skuimage,"))
                {
                    query.Select(p => new { p.SKUImage });
                }
                if (SelectFiled.Contains("positioninfo,"))
                {
                    query.Select(p => new { p.PositionInfo });
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
