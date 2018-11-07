using System;

namespace DbOpertion.Models
{
    [Serializable]
    public class Orderdetaildesign
    {
        /// <summary>
        /// 订单商品设计表Id
        /// </summary>
        public Int32 Id { get; set; }
        /// <summary>
        /// 订单明细Id
        /// </summary>
        public Int32? OrderDetailId { get; set; }
        /// <summary>
        /// 订单内容
        /// </summary>
        public String Content { get; set; }
        /// <summary>
        /// 位置
        /// </summary>
        public String PrintingPosition { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public String Image { get; set; }

    }
}
