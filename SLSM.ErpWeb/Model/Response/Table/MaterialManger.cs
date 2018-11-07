using Common.Extend;
using DbOpertion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SLSM.ErpWeb.Model.Response.Table
{
    public class MaterialManger
    {
        public MaterialManger(Raw_Materials raw_Materials, List<Materials_Stock_View> MaterialsStockList)
        {
            this.AlarmString = "";
            var ListStock = MaterialsStockList.Where(p => p.Raw_materialsId == raw_Materials.Id && (p.Stock < p.MinStockNum.ParseDecimal() || p.Stock == null)).ToList();
            if (ListStock.Count > 0)
            {
                this.AlarmValue = "1000";
                this.StockCount = 500;
                foreach (var item in ListStock)
                {
                    this.AlarmString = this.AlarmString + item.SKU + ",";
                }
                this.AlarmString = this.AlarmString.Substring(0, this.AlarmString.Count() - 1);
            }
            else
            {
                this.AlarmValue = "500";
                this.StockCount = 1000;
            }
            this.Id = raw_Materials.Id;
            this.No = raw_Materials.ProductNo;
            this.Name = raw_Materials.ChinaProductName;
            this.Specification = raw_Materials.Specification;
            this.Unit = raw_Materials.ChinaUnit;
            this.Attributes = raw_Materials.Attributes;
            this.MatAndPro = raw_Materials.MatAndPro;

        }
        /// <summary>
        /// 原材料Id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 原材料编号
        /// </summary>
        public string No { get; set; }
        /// <summary>
        /// 原材料名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 原材料规格型号
        /// </summary>
        public string Specification { get; set; }
        /// <summary>
        /// 定制工艺
        /// </summary>
        public string DiyTechnology { get; set; }
        /// <summary>
        /// 单价
        /// </summary>
        public string SinglePrice { get; set; }
        /// <summary>
        /// 单位
        /// </summary>
        public string Unit { get; set; }
        /// <summary>
        /// 采购周期
        /// </summary>
        public string Cycle { get; set; }
        /// <summary>
        /// 报警值
        /// </summary>
        public string AlarmValue { get; set; }
        /// <summary>
        ///剩余库存
        /// </summary>
        public Int32? StockCount { get; set; }
        /// <summary>
        /// 属性
        /// </summary>
        public string Attributes { get; set; }
        /// <summary>
        /// 材料及工艺
        /// </summary>
        public string MatAndPro { get; set; }
        /// <summary>
        /// 警示SKU
        /// </summary>
        public string AlarmString { get; set; }
    }
}