using System;

namespace DbOpertion.Models
{
    [Serializable]
    public class Shopcart
    {
        /// <summary>
        /// 购物车Id
        /// </summary>
        public Int32 Id { get; set; }
        /// <summary>
        /// 用户Id
        /// </summary>
        public Int32? UserID { get; set; }
        /// <summary>
        /// 用户Guid
        /// </summary>
        public String UserGuId { get; set; }
        /// <summary>
        /// 商品Id
        /// </summary>
        public Int32? CommodityId { get; set; }
        /// <summary>
        /// 背面内容
        /// </summary>
        public String BackContent { get; set; }
        /// <summary>
        /// 正面内容
        /// </summary>
        public String ForntContent { get; set; }
        /// <summary>
        /// 背面图片
        /// </summary>
        public String BackView { get; set; }
        /// <summary>
        /// 前面图片
        /// </summary>
        public String ForntView { get; set; }
        /// <summary>
        /// 最后一次观察时间
        /// </summary>
        public DateTime? LastLookTime { get; set; }
        /// <summary>
        /// 颜色
        /// </summary>
        public String Color { get; set; }
        /// <summary>
        /// 输出方式
        /// </summary>
        public String PrintingMethod { get; set; }
        /// <summary>
        /// 属性
        /// </summary>
        public String Attr { get; set; }
        /// <summary>
        /// 数目
        /// </summary>
        public Int32? Amount { get; set; }
        /// <summary>
        /// 订单Id
        /// </summary>
        public Int32? OrderId { get; set; }
        /// <summary>
        /// 是否手机订单
        /// </summary>
        public Boolean? IsMobile { get; set; }

    }
}
