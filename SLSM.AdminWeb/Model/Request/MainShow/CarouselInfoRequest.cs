using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SLSM.AdminWeb.Model.Request.MainShow
{
    /// <summary>
    /// 轮播图信息请求
    /// </summary>
    public class CarouselInfoRequest
    {
        /// <summary>
        /// 轮播图id
        /// </summary>
        public int CarouselId { get; set; }
        /// <summary>
        /// 第几张图片
        /// </summary>
        public int Num { get; set; }
        /// <summary>
        /// 是否手机端
        /// </summary>
        public bool? IsPC { get; set; }
    }
}