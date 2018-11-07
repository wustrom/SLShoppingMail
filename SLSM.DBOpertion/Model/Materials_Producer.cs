using System;

namespace DbOpertion.Models
{
    [Serializable]
    public class Materials_Producer
    {
        /// <summary>
        /// 供货商原材料对应表Id
        /// </summary>
        public Int32 Id { get; set; }
        /// <summary>
        /// 供应商Id
        /// </summary>
        public Int32? ProducerId { get; set; }
        /// <summary>
        /// 原材料Id
        /// </summary>
        public Int32? MaterialsId { get; set; }
        /// <summary>
        /// 工厂货号
        /// </summary>
        public String FactoryNumber { get; set; }
        /// <summary>
        /// 采购单价
        /// </summary>
        public Decimal? PurchasePrice { get; set; }
        /// <summary>
        /// 报价日期
        /// </summary>
        public DateTime? QuotationDate { get; set; }
        /// <summary>
        /// 生产周期
        /// </summary>
        public String ProCycle { get; set; }
        /// <summary>
        /// 最小起订量
        /// </summary>
        public String MinQuantity { get; set; }
        /// <summary>
        /// 价格标识
        /// </summary>
        public String PriceTag { get; set; }

    }
}
