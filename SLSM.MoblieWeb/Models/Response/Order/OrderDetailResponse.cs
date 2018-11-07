using DbOpertion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SLSM.MoblieWeb.Models.Response.Order
{
    /// <summary>
    /// 订单详情应答
    /// </summary>
    public class OrderDetailResponse
    {
        /// <summary>
        /// 订单详情应答构造方法
        /// </summary>
        public OrderDetailResponse(Order_Detail_View detail, List<Colorinfo> tuples)
        {
            //Id
            this.Id = detail.Id;
            //订单id
            this.OrderId = detail.OrderId;
            //商品id
            this.CommodityId = detail.CommodityId;
            //定制数量
            this.Amount = detail.Amount.Value;
            //实付价格
            this.PayMoney = detail.PayMoney;
            //颜色
            if (detail.Color != null)
            {
                var tuple = tuples.Where(p => p.Id == detail.Color).FirstOrDefault();
                this.Color = tuple == null ? "暂时没有此颜色" : tuple.ChinaDescribe;
                this.ColorId = detail.Color == null ? 0 : detail.Color.Value;
            }
            else
            {
                this.Color = "暂时未选择颜色";
            }
            //名称
            this.Name = detail.Name;
            this.ImageList = detail.comImageList;
            ////正面效果图
            //this.FrontImage = detail.FrontImage == null ? detail.FrontView : detail.FrontImage;
            ////正面图参数
            //this.FrontParams = detail.FrontParams;
            ////背面效果图
            //this.BackImage = detail.BackImage == null ? detail.BackView : detail.BackImage; ;
            ////背面图参数
            //this.BackParams = detail.BackParams;
            //背面效果图
            this.Image = detail.Image == null ? detail.Image : detail.Image; ;
            ////商品属性
            //this.Attribute = detail.Attribute;
        }
        /// <summary>
        ///Id
        /// </summary>
        public Int32 Id { get; set; }
        /// <summary>
        ///Id
        /// </summary>
        public Int32 ColorId { get; set; }
        /// <summary>
        ///订单id
        /// </summary>
        public Int32? OrderId { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        ///商品id
        /// </summary>
        public Int32? CommodityId { get; set; }
        /// <summary>
        ///定制数量
        /// </summary>
        public int Amount { get; set; }
        /// <summary>
        ///实付价格
        /// </summary>
        public Decimal? PayMoney { get; set; }
        /// <summary>
        ///颜色
        /// </summary>
        public string Color { get; set; }
        /// <summary>
        ///正面效果图
        /// </summary>
        public String FrontImage { get; set; }
        /// <summary>
        ///正面图参数
        /// </summary>
        public String FrontParams { get; set; }
        /// <summary>
        ///背面效果图
        /// </summary>
        public String BackImage { get; set; }
        /// <summary>
        ///图片
        /// </summary>
        public String Image { get; set; }
        /// <summary>
        ///背面图参数
        /// </summary>
        public String BackParams { get; set; }
        /// <summary>
        ///商品属性
        /// </summary>
        public String Attribute { get; set; }
        /// <summary>
        /// 图片列表
        /// </summary>
        public String ImageList { get; set; }
    }
}