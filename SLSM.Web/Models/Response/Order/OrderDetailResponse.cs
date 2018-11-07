using DbOpertion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SLSM.Web.Models.Response.Order
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
            }
            else
            {
                this.Color = "暂时未选择颜色";
            }
            //名称
            this.Name = detail.Name;
            //背面效果图
            this.Image = detail.Image == null ? detail.Image : detail.Image;
            this.DesignerImage = detail.DesignerImage;
            this.UserSure = detail.UserSure;
            this.DesignCommit = detail.DesignCommit;
        }

        /// <summary>
        /// 订单详情应答构造方法
        /// </summary>
        public OrderDetailResponse(Order_Detail_View detail, List<Colorinfo> tuples, string PrintFuncInfo)
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
            }
            else
            {
                this.Color = "暂时未选择颜色";
            }
            //名称
            this.Name = detail.Name;
            //背面效果图
            this.Image = detail.Image == null ? detail.Image : detail.Image;
            if (PrintFuncInfo != null)
            {
                var printInfoList = PrintFuncInfo.Split('|').Where(p => !string.IsNullOrEmpty(p)).ToList();
                foreach (var item in printInfoList)
                {
                    if (item.ToLower().Contains($"{detail.PrintingMethod}:".ToLower()))
                    {
                        var itemarray = item.Split(':').ToList();
                        this.PrintFuncInfo = itemarray[1];
                    }
                }
            }
            this.UserSure = detail.UserSure;
            this.DesignCommit = detail.DesignCommit;
            this.ProductNo = detail.ProductNo;
        }
        /// <summary>
        ///Id
        /// </summary>
        public Int32 Id { get; set; }
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
        ///商品属性
        /// </summary>
        public String DesignerImage { get; set; }
        /// <summary>
        /// 用户确定
        /// </summary>
        public bool? UserSure { get; set; }
        /// <summary>
        /// 设计师提交
        /// </summary>
        public bool? DesignCommit { get; set; }
        /// <summary>
        /// 印刷方式
        /// </summary>
        public string PrintFuncInfo { get; set; }

        /// <summary>
        /// 产品货号
        /// </summary>
        public string ProductNo { get; set; }
    }
}