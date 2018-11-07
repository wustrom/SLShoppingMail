using System;

namespace DbOpertion.Models
{
    [Serializable]
    public class Userlike_Commodity_View
    {
        /// <summary>
        /// 用户收藏表id
        /// </summary>
        public Int32 Id { get; set; }
        /// <summary>
        /// 用户id
        /// </summary>
        public Int32? UserId { get; set; }
        /// <summary>
        /// 商品id
        /// </summary>
        public Int32? CommodityId { get; set; }
        /// <summary>
        /// 商品阶梯价格
        /// </summary>
        public Decimal? minPrice { get; set; }
        /// <summary>
        /// 商品存在颜色(,隔开)1红色2橙色3黄色4绿色5蓝色6青色7紫色
        /// </summary>
        public String Color { get; set; }
        /// <summary>
        /// 商品图片
        /// </summary>
        public String Image { get; set; }
        /// <summary>
        /// 商品名称
        /// </summary>
        public String Name { get; set; }
        /// <summary>
        /// 商品介绍
        /// </summary>
        public String Introduce { get; set; }

    }
}
