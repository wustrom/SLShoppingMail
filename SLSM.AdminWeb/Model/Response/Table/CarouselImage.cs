using DbOpertion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SLSM.AdminWeb.Model.Response.Table
{
    /// <summary>
    /// 获得分类信息
    /// </summary>
    public class CarouselImage
    {
        /// <summary>
        /// 图片信息
        /// </summary>
        /// <param name="carousel">信息模型</param>
        public CarouselImage(Carousel_Image carousel)
        {
            //图片Id
            this.Id = carousel.Id;
            //图片地址
            this.Image = carousel.Image;
        }


        /// <summary>
        /// ID
        /// </summary>
        public Int32 Id { get; set; }
        /// <summary>
        /// 图片
        /// </summary>
        public String Image { get; set; }
    }
}