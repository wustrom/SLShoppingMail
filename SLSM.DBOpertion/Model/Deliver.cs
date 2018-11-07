using System;

namespace DbOpertion.Models
{
    [Serializable]
    public class Deliver
    {
        /// <summary>
        /// 送货单表Id
        /// </summary>
        public Int32 Id { get; set; }
        /// <summary>
        /// 采购单表Id
        /// </summary>
        public Int32? buyerId { get; set; }
        /// <summary>
        /// 原材料表Id
        /// </summary>
        public Int32? Raw_materialsId { get; set; }
        /// <summary>
        /// 供应商Id
        /// </summary>
        public Int32? ProducerId { get; set; }
        /// <summary>
        /// 单价
        /// </summary>
        public Decimal? buyerPrice { get; set; }
        /// <summary>
        /// 数量
        /// </summary>
        public Int32? buyerCount { get; set; }
        /// <summary>
        /// 金额
        /// </summary>
        public Decimal? DeliverMoney { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        public String IsStatus { get; set; }
        /// <summary>
        /// 颜色
        /// </summary>
        public String Color { get; set; }
        /// <summary>
        /// 说明
        /// </summary>
        public String DeliverCountext { get; set; }
        /// <summary>
        /// 制单人
        /// </summary>
        public String DeliverSinglePerson { get; set; }
        /// <summary>
        /// 制单时间
        /// </summary>
        public DateTime? DeliverSingleTime { get; set; }
        /// <summary>
        /// 已到达数量
        /// </summary>
        public Int32? AlreadyQuantity { get; set; }

    }
}
