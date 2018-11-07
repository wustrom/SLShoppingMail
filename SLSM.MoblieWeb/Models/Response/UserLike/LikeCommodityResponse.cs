using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SLSM.MoblieWeb.Models.Response.Order
{
    /// <summary>
    /// 收藏应答
    /// </summary>
    public class LikeCommodityResponse
    {
        /// <summary>
        /// 订单详情应答构造方法
        /// </summary>
        public LikeCommodityResponse(DbOpertion.Models.Userlike_Commodity_View likes, List<Tuple<string, string, string>> tuples)
        {
            //Id
            this.Id = likes.Id;
            //用户Id
            this.UserId = likes.UserId;
            //商品Id
            this.CommodityId = likes.CommodityId;
            //最小价格
            this.minPrice = likes.minPrice;
            //颜色
            if (likes.Color != null)
            {
                var tuple = tuples.Where(p => p.Item1 == likes.Color.ToString()).FirstOrDefault();
                this.Color = tuple == null ? "多种颜色" : tuple.Item2;
            }
            else
            {
                this.Color = "暂时未选择颜色";
            }
            //商品图片
            this.Image = likes.Image;
            //商品名称
            this.Name = likes.Name;
            //商品介绍
            this.Introduce = likes.Introduce;
        }
        /// <summary>
        ///收藏ID
        /// </summary>
        public Int32 Id { get; set; }
        /// <summary>
        ///用户Id
        /// </summary>
        public Int32? UserId { get; set; }
        /// <summary>
        ///商品Id
        /// </summary>
        public Int32? CommodityId { get; set; }
        /// <summary>
        ///最小价格
        /// </summary>
        public Decimal? minPrice { get; set; }
        /// <summary>
        ///商品颜色
        /// </summary>
        public String Color { get; set; }
        /// <summary>
        ///商品图片
        /// </summary>
        public String Image { get; set; }
        /// <summary>
        ///商品名称
        /// </summary>
        public String Name { get; set; }
        /// <summary>
        ///商品介绍
        /// </summary>
        public String Introduce { get; set; }

    }
}