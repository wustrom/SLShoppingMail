using System;

namespace DbOpertion.Models
{
    [Serializable]
    public class Commodity_Stage_Price
    {
        /// <summary>
        /// 商品阶梯价表id
        /// </summary>
        public Int32 Id { get; set; }
        /// <summary>
        /// 商品id
        /// </summary>
        public Int32? CommodityId { get; set; }
        /// <summary>
        /// 商品数量阶梯
        /// </summary>
        public Int32? StageAmount { get; set; }
        /// <summary>
        /// 商品阶梯价格
        /// </summary>
        public Decimal? StagePrice { get; set; }
        /// <summary>
        /// 折扣率
        /// </summary>
        public Double? DiscountRate { get; set; }

    }
}
