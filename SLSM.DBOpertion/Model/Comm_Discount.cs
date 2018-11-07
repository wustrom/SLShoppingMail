using System;

namespace DbOpertion.Models
{
    [Serializable]
    public class Comm_Discount
    {
        /// <summary>
        /// 商品优惠折扣表
        /// </summary>
        public Int32 Id { get; set; }
        /// <summary>
        /// 商品id
        /// </summary>
        public Int32? CommodityId { get; set; }
        /// <summary>
        /// 折扣比率
        /// </summary>
        public Single? rate { get; set; }
        /// <summary>
        /// 有效期截止日
        /// </summary>
        public DateTime? ValidityTime { get; set; }

    }
}
