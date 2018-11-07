using System;

namespace DbOpertion.Models
{
    [Serializable]
    public class Storage
    {
        /// <summary>
        /// 库存表Id
        /// </summary>
        public Int32 Id { get; set; }
        /// <summary>
        /// 仓库表Id
        /// </summary>
        public Int32? WarehouseId { get; set; }
        /// <summary>
        /// 供应商表Id
        /// </summary>
        public Int32? ProducerId { get; set; }
        /// <summary>
        /// 原材料管理表Id
        /// </summary>
        public Int32? Raw_materialsId { get; set; }
        /// <summary>
        /// 库存
        /// </summary>
        public Int32? stock { get; set; }
        /// <summary>
        /// 冻结库存
        /// </summary>
        public Int32? freeze_stock { get; set; }
        /// <summary>
        /// 颜色
        /// </summary>
        public String Color { get; set; }

    }
}
