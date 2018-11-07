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
    public partial class Materials_Stock_ViewOper : SingleTon<Materials_Stock_ViewOper>
    {
        /// <summary>
        /// 筛选全部数据
        /// </summary>
        /// <param name="model">模型</param>
        /// <param name="connection">连接</param>
        /// <param name="transaction">事务</param>
        /// <returns>对象列表</returns>
        public List<Materials_Stock_View> SelectAll(Materials_Stock_View model = null, string SelectFiled = null, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var query = new LambdaQuery<Materials_Stock_View>();
            if (model != null)
            {
                if (!model.Stock.IsNullOrEmpty())
                {
                    query.Where(p => p.Stock == model.Stock);
                }
                if (!model.freeze_stock.IsNullOrEmpty())
                {
                    query.Where(p => p.freeze_stock == model.freeze_stock);
                }
                if (!model.available_stock.IsNullOrEmpty())
                {
                    query.Where(p => p.available_stock == model.available_stock);
                }
                if (!model.ColorId.IsNullOrEmpty())
                {
                    query.Where(p => p.ColorId == model.ColorId);
                }
                if (!model.ColorName.IsNullOrEmpty())
                {
                    query.Where(p => p.ColorName == model.ColorName);
                }
                if (!model.MinStockNum.IsNullOrEmpty())
                {
                    query.Where(p => p.MinStockNum == model.MinStockNum);
                }
                if (!model.SKU.IsNullOrEmpty())
                {
                    query.Where(p => p.SKU == model.SKU);
                }
                if (!model.Raw_materialsId.IsNullOrEmpty())
                {
                    query.Where(p => p.Raw_materialsId == model.Raw_materialsId);
                }
                if (!model.Genera.IsNullOrEmpty())
                {
                    query.Where(p => p.Genera == model.Genera);
                }
                if (!model.ChinaProductName.IsNullOrEmpty())
                {
                    query.Where(p => p.ChinaProductName == model.ChinaProductName);
                }
                if (!model.ChinaUnit.IsNullOrEmpty())
                {
                    query.Where(p => p.ChinaUnit == model.ChinaUnit);
                }
                if (!model.MatAndPro.IsNullOrEmpty())
                {
                    query.Where(p => p.MatAndPro == model.MatAndPro);
                }
                if (!model.ProductNo.IsNullOrEmpty())
                {
                    query.Where(p => p.ProductNo == model.ProductNo);
                }
                if (!model.MaterialId.IsNullOrEmpty())
                {
                    query.Where(p => p.MaterialId == model.MaterialId);
                }
                if (!model.Id.IsNullOrEmpty())
                {
                    query.Where(p => p.Id == model.Id);
                }
            }
            if (SelectFiled != null)
            {
                SelectFiled = SelectFiled.ToLowerInvariant();
                if (SelectFiled.Contains("stock,"))
                {
                    query.Select(p => new { p.Stock });
                }
                if (SelectFiled.Contains("freeze_stock,"))
                {
                    query.Select(p => new { p.freeze_stock });
                }
                if (SelectFiled.Contains("available_stock,"))
                {
                    query.Select(p => new { p.available_stock });
                }
                if (SelectFiled.Contains("colorid,"))
                {
                    query.Select(p => new { p.ColorId });
                }
                if (SelectFiled.Contains("colorname,"))
                {
                    query.Select(p => new { p.ColorName });
                }
                if (SelectFiled.Contains("minstocknum,"))
                {
                    query.Select(p => new { p.MinStockNum });
                }
                if (SelectFiled.Contains("sku,"))
                {
                    query.Select(p => new { p.SKU });
                }
                if (SelectFiled.Contains("raw_materialsid,"))
                {
                    query.Select(p => new { p.Raw_materialsId });
                }
                if (SelectFiled.Contains("genera,"))
                {
                    query.Select(p => new { p.Genera });
                }
                if (SelectFiled.Contains("chinaproductname,"))
                {
                    query.Select(p => new { p.ChinaProductName });
                }
                if (SelectFiled.Contains("chinaunit,"))
                {
                    query.Select(p => new { p.ChinaUnit });
                }
                if (SelectFiled.Contains("matandpro,"))
                {
                    query.Select(p => new { p.MatAndPro });
                }
                if (SelectFiled.Contains("productno,"))
                {
                    query.Select(p => new { p.ProductNo });
                }
                if (SelectFiled.Contains("materialid,"))
                {
                    query.Select(p => new { p.MaterialId });
                }
                if (SelectFiled.Contains("id,"))
                {
                    query.Select(p => new { p.Id });
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
        public int SelectCount(Materials_Stock_View model = null, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var query = new LambdaQuery<Materials_Stock_View>();
            if (model != null)
            {
                if (!model.Stock.IsNullOrEmpty())
                {
                    query.Where(p => p.Stock == model.Stock);
                }
                if (!model.freeze_stock.IsNullOrEmpty())
                {
                    query.Where(p => p.freeze_stock == model.freeze_stock);
                }
                if (!model.available_stock.IsNullOrEmpty())
                {
                    query.Where(p => p.available_stock == model.available_stock);
                }
                if (!model.ColorId.IsNullOrEmpty())
                {
                    query.Where(p => p.ColorId == model.ColorId);
                }
                if (!model.ColorName.IsNullOrEmpty())
                {
                    query.Where(p => p.ColorName == model.ColorName);
                }
                if (!model.MinStockNum.IsNullOrEmpty())
                {
                    query.Where(p => p.MinStockNum == model.MinStockNum);
                }
                if (!model.SKU.IsNullOrEmpty())
                {
                    query.Where(p => p.SKU == model.SKU);
                }
                if (!model.Raw_materialsId.IsNullOrEmpty())
                {
                    query.Where(p => p.Raw_materialsId == model.Raw_materialsId);
                }
                if (!model.Genera.IsNullOrEmpty())
                {
                    query.Where(p => p.Genera == model.Genera);
                }
                if (!model.ChinaProductName.IsNullOrEmpty())
                {
                    query.Where(p => p.ChinaProductName == model.ChinaProductName);
                }
                if (!model.ChinaUnit.IsNullOrEmpty())
                {
                    query.Where(p => p.ChinaUnit == model.ChinaUnit);
                }
                if (!model.MatAndPro.IsNullOrEmpty())
                {
                    query.Where(p => p.MatAndPro == model.MatAndPro);
                }
                if (!model.ProductNo.IsNullOrEmpty())
                {
                    query.Where(p => p.ProductNo == model.ProductNo);
                }
                if (!model.MaterialId.IsNullOrEmpty())
                {
                    query.Where(p => p.MaterialId == model.MaterialId);
                }
                if (!model.Id.IsNullOrEmpty())
                {
                    query.Where(p => p.Id == model.Id);
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
        public Materials_Stock_View SelectById(int KeyId, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var query = new LambdaQuery<Materials_Stock_View>();
            return query.GetQueryList(connection, transaction).FirstOrDefault();
        }


        /// <summary>
        /// 根据主键筛选数据
        /// </summary>
        /// <param name="KeyId">主键Id</param>
        /// <param name="connection">连接</param>
        /// <param name="transaction">事务</param>
        /// <returns>是否成功</returns>
        public List<Materials_Stock_View> SelectByKeys(string Key,List<string> KeyIds, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var query = new LambdaQuery<Materials_Stock_View>();
            if("stock" == Key.ToLowerInvariant())
            {
                query.Where(p => p.Stock.In(KeyIds));
            }
            if("freeze_stock" == Key.ToLowerInvariant())
            {
                query.Where(p => p.freeze_stock.In(KeyIds));
            }
            if("available_stock" == Key.ToLowerInvariant())
            {
                query.Where(p => p.available_stock.In(KeyIds));
            }
            if("colorid" == Key.ToLowerInvariant())
            {
                query.Where(p => p.ColorId.In(KeyIds));
            }
            if("colorname" == Key.ToLowerInvariant())
            {
                query.Where(p => p.ColorName.In(KeyIds));
            }
            if("minstocknum" == Key.ToLowerInvariant())
            {
                query.Where(p => p.MinStockNum.In(KeyIds));
            }
            if("sku" == Key.ToLowerInvariant())
            {
                query.Where(p => p.SKU.In(KeyIds));
            }
            if("raw_materialsid" == Key.ToLowerInvariant())
            {
                query.Where(p => p.Raw_materialsId.In(KeyIds));
            }
            if("genera" == Key.ToLowerInvariant())
            {
                query.Where(p => p.Genera.In(KeyIds));
            }
            if("chinaproductname" == Key.ToLowerInvariant())
            {
                query.Where(p => p.ChinaProductName.In(KeyIds));
            }
            if("chinaunit" == Key.ToLowerInvariant())
            {
                query.Where(p => p.ChinaUnit.In(KeyIds));
            }
            if("matandpro" == Key.ToLowerInvariant())
            {
                query.Where(p => p.MatAndPro.In(KeyIds));
            }
            if("productno" == Key.ToLowerInvariant())
            {
                query.Where(p => p.ProductNo.In(KeyIds));
            }
            if("materialid" == Key.ToLowerInvariant())
            {
                query.Where(p => p.MaterialId.In(KeyIds));
            }
            if("id" == Key.ToLowerInvariant())
            {
                query.Where(p => p.Id.In(KeyIds));
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
        public List<Materials_Stock_View> SelectByPage(string Key, int start, int PageSize, bool desc = true,Materials_Stock_View model = null, string SelectFiled = null, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var query = new LambdaQuery<Materials_Stock_View>();
            if (model != null)
            {
                if (!model.Stock.IsNullOrEmpty())
                {
                    query.Where(p => p.Stock == model.Stock);
                }
                if (!model.freeze_stock.IsNullOrEmpty())
                {
                    query.Where(p => p.freeze_stock == model.freeze_stock);
                }
                if (!model.available_stock.IsNullOrEmpty())
                {
                    query.Where(p => p.available_stock == model.available_stock);
                }
                if (!model.ColorId.IsNullOrEmpty())
                {
                    query.Where(p => p.ColorId == model.ColorId);
                }
                if (!model.ColorName.IsNullOrEmpty())
                {
                    query.Where(p => p.ColorName == model.ColorName);
                }
                if (!model.MinStockNum.IsNullOrEmpty())
                {
                    query.Where(p => p.MinStockNum == model.MinStockNum);
                }
                if (!model.SKU.IsNullOrEmpty())
                {
                    query.Where(p => p.SKU == model.SKU);
                }
                if (!model.Raw_materialsId.IsNullOrEmpty())
                {
                    query.Where(p => p.Raw_materialsId == model.Raw_materialsId);
                }
                if (!model.Genera.IsNullOrEmpty())
                {
                    query.Where(p => p.Genera == model.Genera);
                }
                if (!model.ChinaProductName.IsNullOrEmpty())
                {
                    query.Where(p => p.ChinaProductName == model.ChinaProductName);
                }
                if (!model.ChinaUnit.IsNullOrEmpty())
                {
                    query.Where(p => p.ChinaUnit == model.ChinaUnit);
                }
                if (!model.MatAndPro.IsNullOrEmpty())
                {
                    query.Where(p => p.MatAndPro == model.MatAndPro);
                }
                if (!model.ProductNo.IsNullOrEmpty())
                {
                    query.Where(p => p.ProductNo == model.ProductNo);
                }
                if (!model.MaterialId.IsNullOrEmpty())
                {
                    query.Where(p => p.MaterialId == model.MaterialId);
                }
                if (!model.Id.IsNullOrEmpty())
                {
                    query.Where(p => p.Id == model.Id);
                }
            }
            if (SelectFiled != null)
            {
                SelectFiled = SelectFiled.ToLowerInvariant();
                if (SelectFiled.Contains("stock,"))
                {
                    query.Select(p => new { p.Stock });
                }
                if (SelectFiled.Contains("freeze_stock,"))
                {
                    query.Select(p => new { p.freeze_stock });
                }
                if (SelectFiled.Contains("available_stock,"))
                {
                    query.Select(p => new { p.available_stock });
                }
                if (SelectFiled.Contains("colorid,"))
                {
                    query.Select(p => new { p.ColorId });
                }
                if (SelectFiled.Contains("colorname,"))
                {
                    query.Select(p => new { p.ColorName });
                }
                if (SelectFiled.Contains("minstocknum,"))
                {
                    query.Select(p => new { p.MinStockNum });
                }
                if (SelectFiled.Contains("sku,"))
                {
                    query.Select(p => new { p.SKU });
                }
                if (SelectFiled.Contains("raw_materialsid,"))
                {
                    query.Select(p => new { p.Raw_materialsId });
                }
                if (SelectFiled.Contains("genera,"))
                {
                    query.Select(p => new { p.Genera });
                }
                if (SelectFiled.Contains("chinaproductname,"))
                {
                    query.Select(p => new { p.ChinaProductName });
                }
                if (SelectFiled.Contains("chinaunit,"))
                {
                    query.Select(p => new { p.ChinaUnit });
                }
                if (SelectFiled.Contains("matandpro,"))
                {
                    query.Select(p => new { p.MatAndPro });
                }
                if (SelectFiled.Contains("productno,"))
                {
                    query.Select(p => new { p.ProductNo });
                }
                if (SelectFiled.Contains("materialid,"))
                {
                    query.Select(p => new { p.MaterialId });
                }
                if (SelectFiled.Contains("id,"))
                {
                    query.Select(p => new { p.Id });
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
