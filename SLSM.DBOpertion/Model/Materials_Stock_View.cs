using System;

namespace DbOpertion.Models
{
    [Serializable]
    public class Materials_Stock_View
    {
        /// <summary>
        /// 
        /// </summary>
        public Decimal? Stock { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Decimal? freeze_stock { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Decimal? available_stock { get; set; }
        /// <summary>
        /// 颜色信息
        /// </summary>
        public Int32? ColorId { get; set; }
        /// <summary>
        /// 颜色中文描述
        /// </summary>
        public String ColorName { get; set; }
        /// <summary>
        /// 最小库存
        /// </summary>
        public String MinStockNum { get; set; }
        /// <summary>
        /// SKU编码
        /// </summary>
        public String SKU { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Int32? Raw_materialsId { get; set; }
        /// <summary>
        /// 所属大类
        /// </summary>
        public String Genera { get; set; }
        /// <summary>
        /// 中文品名
        /// </summary>
        public String ChinaProductName { get; set; }
        /// <summary>
        /// 中文单位
        /// </summary>
        public String ChinaUnit { get; set; }
        /// <summary>
        /// 材料及工艺
        /// </summary>
        public String MatAndPro { get; set; }
        /// <summary>
        /// 编号
        /// </summary>
        public String ProductNo { get; set; }
        /// <summary>
        /// 原材料管理表Id
        /// </summary>
        public Int32? MaterialId { get; set; }
        /// <summary>
        /// 原材料颜色关系
        /// </summary>
        public Int32 Id { get; set; }

    }
}
