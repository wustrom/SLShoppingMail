using System;

namespace DbOpertion.Models
{
    [Serializable]
    public class Materials_Colorinfo
    {
        /// <summary>
        /// 原材料颜色关系
        /// </summary>
        public Int32 Id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Int32? MaterialsId { get; set; }
        /// <summary>
        /// SKU编码
        /// </summary>
        public String SKU { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Int32? ColorId { get; set; }
        /// <summary>
        /// 最小库存
        /// </summary>
        public String MinStockNum { get; set; }
        /// <summary>
        /// SKU图片
        /// </summary>
        public String SKUImage { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public String PositionInfo { get; set; }

    }
}
