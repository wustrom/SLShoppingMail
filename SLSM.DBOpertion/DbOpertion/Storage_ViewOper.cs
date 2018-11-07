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
    public partial class Storage_ViewOper : SingleTon<Storage_ViewOper>
    {
        /// <summary>
        /// 筛选全部数据
        /// </summary>
        /// <param name="model">模型</param>
        /// <param name="connection">连接</param>
        /// <param name="transaction">事务</param>
        /// <returns>对象列表</returns>
        public List<Storage_View> SelectAll(Storage_View model = null, string SelectFiled = null, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var query = new LambdaQuery<Storage_View>();
            if (model != null)
            {
                if (!model.Id.IsNullOrEmpty())
                {
                    query.Where(p => p.Id == model.Id);
                }
                if (!model.ProductNo.IsNullOrEmpty())
                {
                    query.Where(p => p.ProductNo == model.ProductNo);
                }
                if (!model.Raw_materialsId.IsNullOrEmpty())
                {
                    query.Where(p => p.Raw_materialsId == model.Raw_materialsId);
                }
                if (!model.ChinaProductName.IsNullOrEmpty())
                {
                    query.Where(p => p.ChinaProductName == model.ChinaProductName);
                }
                if (!model.ChinaUnit.IsNullOrEmpty())
                {
                    query.Where(p => p.ChinaUnit == model.ChinaUnit);
                }
                if (!model.Specification.IsNullOrEmpty())
                {
                    query.Where(p => p.Specification == model.Specification);
                }
                if (!model.MatAndPro.IsNullOrEmpty())
                {
                    query.Where(p => p.MatAndPro == model.MatAndPro);
                }
                if (!model.Attributes.IsNullOrEmpty())
                {
                    query.Where(p => p.Attributes == model.Attributes);
                }
                if (!model.HSCODE.IsNullOrEmpty())
                {
                    query.Where(p => p.HSCODE == model.HSCODE);
                }
                if (!model.IsDelete.IsNullOrEmpty())
                {
                    query.Where(p => p.IsDelete == model.IsDelete);
                }
                if (!model.WarehouseId.IsNullOrEmpty())
                {
                    query.Where(p => p.WarehouseId == model.WarehouseId);
                }
                if (!model.WarehouseName.IsNullOrEmpty())
                {
                    query.Where(p => p.WarehouseName == model.WarehouseName);
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
                if (!model.NetWeight.IsNullOrEmpty())
                {
                    query.Where(p => p.NetWeight == model.NetWeight);
                }
                if (!model.Material.IsNullOrEmpty())
                {
                    query.Where(p => p.Material == model.Material);
                }
                if (!model.Remark.IsNullOrEmpty())
                {
                    query.Where(p => p.Remark == model.Remark);
                }
                if (!model.Weight.IsNullOrEmpty())
                {
                    query.Where(p => p.Weight == model.Weight);
                }
                if (!model.matercolorId.IsNullOrEmpty())
                {
                    query.Where(p => p.matercolorId == model.matercolorId);
                }
            }
            if (SelectFiled != null)
            {
                SelectFiled = SelectFiled.ToLowerInvariant();
                if (SelectFiled.Contains("id,"))
                {
                    query.Select(p => new { p.Id });
                }
                if (SelectFiled.Contains("productno,"))
                {
                    query.Select(p => new { p.ProductNo });
                }
                if (SelectFiled.Contains("raw_materialsid,"))
                {
                    query.Select(p => new { p.Raw_materialsId });
                }
                if (SelectFiled.Contains("chinaproductname,"))
                {
                    query.Select(p => new { p.ChinaProductName });
                }
                if (SelectFiled.Contains("chinaunit,"))
                {
                    query.Select(p => new { p.ChinaUnit });
                }
                if (SelectFiled.Contains("specification,"))
                {
                    query.Select(p => new { p.Specification });
                }
                if (SelectFiled.Contains("matandpro,"))
                {
                    query.Select(p => new { p.MatAndPro });
                }
                if (SelectFiled.Contains("attributes,"))
                {
                    query.Select(p => new { p.Attributes });
                }
                if (SelectFiled.Contains("hscode,"))
                {
                    query.Select(p => new { p.HSCODE });
                }
                if (SelectFiled.Contains("isdelete,"))
                {
                    query.Select(p => new { p.IsDelete });
                }
                if (SelectFiled.Contains("warehouseid,"))
                {
                    query.Select(p => new { p.WarehouseId });
                }
                if (SelectFiled.Contains("warehousename,"))
                {
                    query.Select(p => new { p.WarehouseName });
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
                if (SelectFiled.Contains("netweight,"))
                {
                    query.Select(p => new { p.NetWeight });
                }
                if (SelectFiled.Contains("material,"))
                {
                    query.Select(p => new { p.Material });
                }
                if (SelectFiled.Contains("remark,"))
                {
                    query.Select(p => new { p.Remark });
                }
                if (SelectFiled.Contains("weight,"))
                {
                    query.Select(p => new { p.Weight });
                }
                if (SelectFiled.Contains("matercolorid,"))
                {
                    query.Select(p => new { p.matercolorId });
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
        public int SelectCount(Storage_View model = null, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var query = new LambdaQuery<Storage_View>();
            if (model != null)
            {
                if (!model.Id.IsNullOrEmpty())
                {
                    query.Where(p => p.Id == model.Id);
                }
                if (!model.ProductNo.IsNullOrEmpty())
                {
                    query.Where(p => p.ProductNo == model.ProductNo);
                }
                if (!model.Raw_materialsId.IsNullOrEmpty())
                {
                    query.Where(p => p.Raw_materialsId == model.Raw_materialsId);
                }
                if (!model.ChinaProductName.IsNullOrEmpty())
                {
                    query.Where(p => p.ChinaProductName == model.ChinaProductName);
                }
                if (!model.ChinaUnit.IsNullOrEmpty())
                {
                    query.Where(p => p.ChinaUnit == model.ChinaUnit);
                }
                if (!model.Specification.IsNullOrEmpty())
                {
                    query.Where(p => p.Specification == model.Specification);
                }
                if (!model.MatAndPro.IsNullOrEmpty())
                {
                    query.Where(p => p.MatAndPro == model.MatAndPro);
                }
                if (!model.Attributes.IsNullOrEmpty())
                {
                    query.Where(p => p.Attributes == model.Attributes);
                }
                if (!model.HSCODE.IsNullOrEmpty())
                {
                    query.Where(p => p.HSCODE == model.HSCODE);
                }
                if (!model.IsDelete.IsNullOrEmpty())
                {
                    query.Where(p => p.IsDelete == model.IsDelete);
                }
                if (!model.WarehouseId.IsNullOrEmpty())
                {
                    query.Where(p => p.WarehouseId == model.WarehouseId);
                }
                if (!model.WarehouseName.IsNullOrEmpty())
                {
                    query.Where(p => p.WarehouseName == model.WarehouseName);
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
                if (!model.NetWeight.IsNullOrEmpty())
                {
                    query.Where(p => p.NetWeight == model.NetWeight);
                }
                if (!model.Material.IsNullOrEmpty())
                {
                    query.Where(p => p.Material == model.Material);
                }
                if (!model.Remark.IsNullOrEmpty())
                {
                    query.Where(p => p.Remark == model.Remark);
                }
                if (!model.Weight.IsNullOrEmpty())
                {
                    query.Where(p => p.Weight == model.Weight);
                }
                if (!model.matercolorId.IsNullOrEmpty())
                {
                    query.Where(p => p.matercolorId == model.matercolorId);
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
        public Storage_View SelectById(int KeyId, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var query = new LambdaQuery<Storage_View>();
            return query.GetQueryList(connection, transaction).FirstOrDefault();
        }


        /// <summary>
        /// 根据主键筛选数据
        /// </summary>
        /// <param name="KeyId">主键Id</param>
        /// <param name="connection">连接</param>
        /// <param name="transaction">事务</param>
        /// <returns>是否成功</returns>
        public List<Storage_View> SelectByKeys(string Key,List<string> KeyIds, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var query = new LambdaQuery<Storage_View>();
            if("id" == Key.ToLowerInvariant())
            {
                query.Where(p => p.Id.In(KeyIds));
            }
            if("productno" == Key.ToLowerInvariant())
            {
                query.Where(p => p.ProductNo.In(KeyIds));
            }
            if("raw_materialsid" == Key.ToLowerInvariant())
            {
                query.Where(p => p.Raw_materialsId.In(KeyIds));
            }
            if("chinaproductname" == Key.ToLowerInvariant())
            {
                query.Where(p => p.ChinaProductName.In(KeyIds));
            }
            if("chinaunit" == Key.ToLowerInvariant())
            {
                query.Where(p => p.ChinaUnit.In(KeyIds));
            }
            if("specification" == Key.ToLowerInvariant())
            {
                query.Where(p => p.Specification.In(KeyIds));
            }
            if("matandpro" == Key.ToLowerInvariant())
            {
                query.Where(p => p.MatAndPro.In(KeyIds));
            }
            if("attributes" == Key.ToLowerInvariant())
            {
                query.Where(p => p.Attributes.In(KeyIds));
            }
            if("hscode" == Key.ToLowerInvariant())
            {
                query.Where(p => p.HSCODE.In(KeyIds));
            }
            if("isdelete" == Key.ToLowerInvariant())
            {
                query.Where(p => p.IsDelete.In(KeyIds));
            }
            if("warehouseid" == Key.ToLowerInvariant())
            {
                query.Where(p => p.WarehouseId.In(KeyIds));
            }
            if("warehousename" == Key.ToLowerInvariant())
            {
                query.Where(p => p.WarehouseName.In(KeyIds));
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
            if("netweight" == Key.ToLowerInvariant())
            {
                query.Where(p => p.NetWeight.In(KeyIds));
            }
            if("material" == Key.ToLowerInvariant())
            {
                query.Where(p => p.Material.In(KeyIds));
            }
            if("remark" == Key.ToLowerInvariant())
            {
                query.Where(p => p.Remark.In(KeyIds));
            }
            if("weight" == Key.ToLowerInvariant())
            {
                query.Where(p => p.Weight.In(KeyIds));
            }
            if("matercolorid" == Key.ToLowerInvariant())
            {
                query.Where(p => p.matercolorId.In(KeyIds));
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
        public List<Storage_View> SelectByPage(string Key, int start, int PageSize, bool desc = true,Storage_View model = null, string SelectFiled = null, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var query = new LambdaQuery<Storage_View>();
            if (model != null)
            {
                if (!model.Id.IsNullOrEmpty())
                {
                    query.Where(p => p.Id == model.Id);
                }
                if (!model.ProductNo.IsNullOrEmpty())
                {
                    query.Where(p => p.ProductNo == model.ProductNo);
                }
                if (!model.Raw_materialsId.IsNullOrEmpty())
                {
                    query.Where(p => p.Raw_materialsId == model.Raw_materialsId);
                }
                if (!model.ChinaProductName.IsNullOrEmpty())
                {
                    query.Where(p => p.ChinaProductName == model.ChinaProductName);
                }
                if (!model.ChinaUnit.IsNullOrEmpty())
                {
                    query.Where(p => p.ChinaUnit == model.ChinaUnit);
                }
                if (!model.Specification.IsNullOrEmpty())
                {
                    query.Where(p => p.Specification == model.Specification);
                }
                if (!model.MatAndPro.IsNullOrEmpty())
                {
                    query.Where(p => p.MatAndPro == model.MatAndPro);
                }
                if (!model.Attributes.IsNullOrEmpty())
                {
                    query.Where(p => p.Attributes == model.Attributes);
                }
                if (!model.HSCODE.IsNullOrEmpty())
                {
                    query.Where(p => p.HSCODE == model.HSCODE);
                }
                if (!model.IsDelete.IsNullOrEmpty())
                {
                    query.Where(p => p.IsDelete == model.IsDelete);
                }
                if (!model.WarehouseId.IsNullOrEmpty())
                {
                    query.Where(p => p.WarehouseId == model.WarehouseId);
                }
                if (!model.WarehouseName.IsNullOrEmpty())
                {
                    query.Where(p => p.WarehouseName == model.WarehouseName);
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
                if (!model.NetWeight.IsNullOrEmpty())
                {
                    query.Where(p => p.NetWeight == model.NetWeight);
                }
                if (!model.Material.IsNullOrEmpty())
                {
                    query.Where(p => p.Material == model.Material);
                }
                if (!model.Remark.IsNullOrEmpty())
                {
                    query.Where(p => p.Remark == model.Remark);
                }
                if (!model.Weight.IsNullOrEmpty())
                {
                    query.Where(p => p.Weight == model.Weight);
                }
                if (!model.matercolorId.IsNullOrEmpty())
                {
                    query.Where(p => p.matercolorId == model.matercolorId);
                }
            }
            if (SelectFiled != null)
            {
                SelectFiled = SelectFiled.ToLowerInvariant();
                if (SelectFiled.Contains("id,"))
                {
                    query.Select(p => new { p.Id });
                }
                if (SelectFiled.Contains("productno,"))
                {
                    query.Select(p => new { p.ProductNo });
                }
                if (SelectFiled.Contains("raw_materialsid,"))
                {
                    query.Select(p => new { p.Raw_materialsId });
                }
                if (SelectFiled.Contains("chinaproductname,"))
                {
                    query.Select(p => new { p.ChinaProductName });
                }
                if (SelectFiled.Contains("chinaunit,"))
                {
                    query.Select(p => new { p.ChinaUnit });
                }
                if (SelectFiled.Contains("specification,"))
                {
                    query.Select(p => new { p.Specification });
                }
                if (SelectFiled.Contains("matandpro,"))
                {
                    query.Select(p => new { p.MatAndPro });
                }
                if (SelectFiled.Contains("attributes,"))
                {
                    query.Select(p => new { p.Attributes });
                }
                if (SelectFiled.Contains("hscode,"))
                {
                    query.Select(p => new { p.HSCODE });
                }
                if (SelectFiled.Contains("isdelete,"))
                {
                    query.Select(p => new { p.IsDelete });
                }
                if (SelectFiled.Contains("warehouseid,"))
                {
                    query.Select(p => new { p.WarehouseId });
                }
                if (SelectFiled.Contains("warehousename,"))
                {
                    query.Select(p => new { p.WarehouseName });
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
                if (SelectFiled.Contains("netweight,"))
                {
                    query.Select(p => new { p.NetWeight });
                }
                if (SelectFiled.Contains("material,"))
                {
                    query.Select(p => new { p.Material });
                }
                if (SelectFiled.Contains("remark,"))
                {
                    query.Select(p => new { p.Remark });
                }
                if (SelectFiled.Contains("weight,"))
                {
                    query.Select(p => new { p.Weight });
                }
                if (SelectFiled.Contains("matercolorid,"))
                {
                    query.Select(p => new { p.matercolorId });
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
