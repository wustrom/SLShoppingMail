using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SLSM.AdminWeb.Model.Request.MainShow
{
    /// <summary>
    /// 添加轮播图请求
    /// </summary>
    public class AddCarouselRequest
    {
        /// <summary>
        /// 轮播图Id
        /// </summary>
        public Int32 CarouselId { get; set; }
        /// <summary>
        /// 轮播图图片
        /// </summary>
        public String Image { get; set; }
        /// <summary>
        /// 轮播图排序Id
        /// </summary>
        public Int32? OrderID { get; set; }
        /// <summary>
        /// 轮播图跳转地址
        /// </summary>
        public String ImgAddress { get; set; }
        /// <summary>
        /// 是否PC
        /// </summary>
        public bool IsPC { get; set; }
    }
}