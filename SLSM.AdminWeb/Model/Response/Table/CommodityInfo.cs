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
    public class CommodityInfo
    {
        /// <summary>
        /// 商品信息
        /// </summary>
        /// <param name="commodityView">信息模型</param>
        public CommodityInfo(Commodity_Stageprice_View commodityView)
        {
            //商品Id
            this.Id = commodityView.Id;
            //商品名称
            this.Name = commodityView.Name;
            //商品图片
            this.Image = commodityView.Image;
            //商品销售量
            this.Sales = commodityView.Sales;
            //创建时间
            this.CreateTime = commodityView.CreateTime == null ? "暂无创建时间" : commodityView.CreateTime.Value.ToString("yyyy-MM-dd HH:mm:ss");
            //推荐时间
            this.RecommendTime = commodityView.RecommendTime == null ? "暂无推荐时间" : commodityView.RecommendTime.Value.ToString("yyyy-MM-dd HH:mm:ss");
            //是否发布
            this.IsRelease = commodityView.IsRelease == null ? "否" : commodityView.IsRelease == true ? "是" : "否";
            //最小价格
            this.minPrice = commodityView.minPrice == null ? "暂无价格" : commodityView.minPrice.ToString();
        }

        /// <summary>
        /// 商品信息
        /// </summary>
        /// <param name="commodity">信息模型</param>
        public CommodityInfo(Commdity_Materials_View commodity)
        {
            //商品Id
            this.Id = commodity.Id;
            //商品名称
            this.Name = commodity.Name;
            //商品图片
            this.Image = commodity.Image;
            //商品销售量
            this.Sales = commodity.Sales;
            //创建时间
            this.CreateTime = commodity.CreateTime == null ? "暂无创建时间" : commodity.CreateTime.Value.ToString("yyyy-MM-dd HH:mm:ss");
            //推荐时间
            this.RecommendTime = commodity.RecommendTime == null ? "暂无推荐时间" : commodity.RecommendTime.Value.ToString("yyyy-MM-dd HH:mm:ss");
            //是否发布
            this.IsRelease = (commodity.IsRelease == null || commodity.IsRelease == false) ? "否" : "是";
            //商品星级
            this.Stars = commodity.Stars == null ? "暂无星级" : commodity.Stars.Value.ToString();
            //查看次数
            this.ClickCount = commodity.ClickCount == null ? "暂无查看！" : commodity.ClickCount.Value.ToString();
            //商品评价次数
            this.StarCount = commodity.StarCount == null ? "暂无评价！" : commodity.StarCount.Value.ToString();
            //商品介绍
            this.Introduce = commodity.Introduce;
            //产品货号
            this.ProductNo = commodity.ProductNo;
        }

        /// <summary>
        /// 商品Id
        /// </summary>
        public Int32 Id { get; set; }
        /// <summary>
        /// 商品名称
        /// </summary>
        public String Name { get; set; }
        /// <summary>
        /// 商品图片
        /// </summary>
        public String Image { get; set; }
        /// <summary>
        /// 销售量
        /// </summary>
        public Int32? Sales { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public string CreateTime { get; set; }
        /// <summary>
        /// 推荐时间
        /// </summary>
        public string RecommendTime { get; set; }
        /// <summary>
        /// 是否发布
        /// </summary>
        public string IsRelease { get; set; }
        /// <summary>
        /// 最小价格
        /// </summary>
        public string minPrice { get; set; }
        /// <summary>
        /// 商品星级
        /// </summary>
        public string Stars { get; set; }
        /// <summary>
        /// 商品评价数
        /// </summary>
        public string StarCount { get; set; }
        /// <summary>
        /// 商品点击数
        /// </summary>
        public string ClickCount { get; set; }
        /// <summary>
        /// 商品介绍
        /// </summary>
        public string Introduce { get; set; }
        /// <summary>
        /// 产品货号
        /// </summary>
        public string ProductNo { get; set; }

    }
}