using System;

namespace DbOpertion.Models
{
    [Serializable]
    public class Storage_View
    {
        /// <summary>
        /// 库存表Id
        /// </summary>
        public Int32? Id { get; set; }
        /// <summary>
        /// 编号
        /// </summary>
        public String ProductNo { get; set; }
        /// <summary>
        /// 原材料管理表Id
        /// </summary>
        public Int32? Raw_materialsId { get; set; }
        /// <summary>
        /// 中文品名
        /// </summary>
        public String ChinaProductName { get; set; }
        /// <summary>
        /// 中文单位
        /// </summary>
        public String ChinaUnit { get; set; }
        /// <summary>
        /// 规格型号
        /// </summary>
        public String Specification { get; set; }
        /// <summary>
        /// 材料及工艺
        /// </summary>
        public String MatAndPro { get; set; }
        /// <summary>
        /// 产品属性
        /// </summary>
        public String Attributes { get; set; }
        /// <summary>
        /// 海关编码
        /// </summary>
        public String HSCODE { get; set; }
        /// <summary>
        /// 是否删除
        /// </summary>
        public Boolean? IsDelete { get; set; }
        /// <summary>
        /// 仓库表
        /// </summary>
        public Int32? WarehouseId { get; set; }
        /// <summary>
        /// 仓库名
        /// </summary>
        public String WarehouseName { get; set; }
        /// <summary>
        /// 库存
        /// </summary>
        public Int32? stock { get; set; }
        /// <summary>
        /// 冻结库存
        /// </summary>
        public Int32? freeze_stock { get; set; }
        /// <summary>
        /// SKU编码
        /// </summary>
        public String Color { get; set; }
        /// <summary>
        /// 净重
        /// </summary>
        public String NetWeight { get; set; }
        /// <summary>
        /// 材料及工艺
        /// </summary>
        public String Material { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public String Remark { get; set; }
        /// <summary>
        /// 重量
        /// </summary>
        public String Weight { get; set; }
        /// <summary>
        /// 原材料颜色关系
        /// </summary>
        public Int32 matercolorId { get; set; }

    }
}
