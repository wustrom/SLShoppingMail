using Common.Extend;
using DbOpertion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SLSM.ErpWeb.Model.Response.Table
{
    public class Storages
    {
        /// <summary>
        /// 库存信息构造函数
        /// </summary>
        /// <param name="ware"></param>
        public Storages(Storage_View storage)
        {
            //库存Id
            this.Id = storage.Id == null ? 0 : storage.Id;
            //名称
            this.ChinaProductName = storage.ChinaProductName;
            //单位
            this.ChinaUnit = storage.ChinaUnit;
            //型号
            this.Specification = storage.Specification;
            //仓库名称
            this.WarehouseName = storage.WarehouseName == null ? "暂无仓库" : storage.WarehouseName;
            //库存
            this.stock = storage.stock == null ? 0 : storage.stock;
            //冻结库存
            this.freeze_stock = storage.freeze_stock == null ? 0 : storage.freeze_stock;
            //颜色
            this.Color = storage.Color;
            //原材料Id
            this.Raw_materialsId = storage.Raw_materialsId == null ? 0 : storage.Raw_materialsId.Value;
            //原材料颜色Id
            this.matercolorId = storage.matercolorId.ToString();
        }

        /// <summary>
        /// 库存信息构造函数
        /// </summary>
        /// <param name="ware"></param>
        public Storages(Materials_Stock_View stockview)
        {
            //库存Id
            this.Id = stockview.Id;
            //名称
            this.ChinaProductName = stockview.ChinaProductName;
            //单位
            this.ChinaUnit = stockview.ChinaUnit;
            //产品货号
            this.ProductNo = stockview.ProductNo;
            //库存
            this.stock = stockview.Stock == null ? 0 : stockview.Stock.Value.ParseInt();
            //冻结库存
            this.freeze_stock = stockview.freeze_stock == null ? 0 : stockview.freeze_stock.Value.ParseInt();
            //颜色名称
            this.Color = stockview.ColorName;
            //最小库存
            this.MinStockNum = stockview.MinStockNum;
            //型号
            this.Specification = stockview.MatAndPro;
            //Sku编号
            this.SKU = stockview.SKU;
            //原材料颜色Id
            this.MaterialId = stockview.MaterialId.ToString();
        }

        /// <summary>
        ///库存Id
        /// </summary>
        public Int32? Id { get; set; }
        /// <summary>
        /// 原材料Id
        /// </summary>
        public Int32 Raw_materialsId { get; set; }
        /// <summary>
        ///中文名称
        /// </summary>
        public String ChinaProductName { get; set; }
        /// <summary>
        ///单位
        /// </summary>
        public String ChinaUnit { get; set; }
        /// <summary>
        ///型号
        /// </summary>
        public String Specification { get; set; }
        /// <summary>
        ///仓库名称
        /// </summary>
        public String WarehouseName { get; set; }
        /// <summary>
        ///供应商名称
        /// </summary>
        public String ProducerName { get; set; }
        /// <summary>
        ///库存
        /// </summary>
        public Int32? stock { get; set; }
        /// <summary>
        ///冻结库存
        /// </summary>
        public Int32? freeze_stock { get; set; }
        /// <summary>
        ///颜色
        /// </summary>
        public String Color { get; set; }
        /// <summary>
        /// 货号
        /// </summary>
        public String ProductNo { get; set; }
        /// <summary>
        /// 最小库存量
        /// </summary>
        public string MinStockNum { get; set; }
        /// <summary>
        /// Sku编号
        /// </summary>
        public string SKU { get; set; }
        /// <summary>
        /// 原材料Id
        /// </summary>
        public string MaterialId { get; set; }

        /// <summary>
        /// 原材料颜色Id
        /// </summary>
        public string matercolorId { get; set; }
    }
}