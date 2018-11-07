using System;

namespace DbOpertion.Models
{
    [Serializable]
    public class Receive_Raw_View
    {
        /// <summary>
        /// 领料单表Id
        /// </summary>
        public Int32 Id { get; set; }
        /// <summary>
        /// 生产领料表Id
        /// </summary>
        public Int32? receiveId { get; set; }
        /// <summary>
        /// 额外申请数量
        /// </summary>
        public Int32? additionalCount { get; set; }
        /// <summary>
        /// 是否为额外领料
        /// </summary>
        public Boolean? Isadditional { get; set; }
        /// <summary>
        /// 基础数目
        /// </summary>
        public Int32? BaseCount { get; set; }
        /// <summary>
        /// SKU代码
        /// </summary>
        public String SKU { get; set; }
        /// <summary>
        /// 生产管理表Id
        /// </summary>
        public Int32? productionId { get; set; }
        /// <summary>
        /// 状态(待申请,待出库,已出库,已取消)
        /// </summary>
        public String receiveStatus { get; set; }
        /// <summary>
        /// 出库时间
        /// </summary>
        public DateTime? receiveOutTime { get; set; }
        /// <summary>
        /// 申领时间
        /// </summary>
        public DateTime? receiveTime { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public String receiveContext { get; set; }
        /// <summary>
        /// 商品id
        /// </summary>
        public Int32? CommodityId { get; set; }
        /// <summary>
        /// 数量
        /// </summary>
        public Int32? Amount { get; set; }
        /// <summary>
        /// 订单id
        /// </summary>
        public Int32? OrderId { get; set; }
        /// <summary>
        /// 原材料表Id
        /// </summary>
        public Int32? MaterialId { get; set; }
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

    }
}
