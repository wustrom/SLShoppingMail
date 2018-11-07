using System;

namespace DbOpertion.Models
{
    [Serializable]
    public class Carousel_Image
    {
        /// <summary>
        /// 轮播图id
        /// </summary>
        public Int32 Id { get; set; }
        /// <summary>
        /// 轮播图地址
        /// </summary>
        public String Image { get; set; }
        /// <summary>
        /// 排序字段
        /// </summary>
        public Int32? OrderID { get; set; }
        /// <summary>
        /// 跳转地址路径
        /// </summary>
        public String AUrl { get; set; }
        /// <summary>
        /// 是否轮播图
        /// </summary>
        public Boolean IsCarousel { get; set; }
        /// <summary>
        /// 是否PC
        /// </summary>
        public Boolean? IsPC { get; set; }

    }
}
