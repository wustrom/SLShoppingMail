using System;

namespace DbOpertion.Models
{
    [Serializable]
    public class Changestorage
    {
        /// <summary>
        /// 调整库存表
        /// </summary>
        public Int32 Id { get; set; }
        /// <summary>
        /// 库存表Id
        /// </summary>
        public Int32 storageId { get; set; }
        /// <summary>
        /// 时间
        /// </summary>
        public DateTime? ChangeTime { get; set; }
        /// <summary>
        /// 变动类型(手动输入原因调整,采购入库,生产领料)
        /// </summary>
        public String ChangeType { get; set; }
        /// <summary>
        /// 变动数量
        /// </summary>
        public String ChangeCount { get; set; }
        /// <summary>
        /// 调整后库存
        /// </summary>
        public Int32? ChangeAfterCount { get; set; }
        /// <summary>
        /// 变动原因
        /// </summary>
        public String ChangeContext { get; set; }

    }
}
