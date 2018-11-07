using Common.Extend;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SLSM.MoblieWeb.Models.Response.ShopCart
{
    /// <summary>
    /// 购物车记录分页请求
    /// </summary>
    public class HisdesigninfoResponse
    {
        /// <summary>
        /// 购物车记录分页请求构造函数
        /// </summary>
        /// <param name="hisdesigninfo">购物车模型</param>
        /// <param name="list">列表</param>
        /// <param name="UserDecount">用户折扣价</param>
        public HisdesigninfoResponse(DbOpertion.Models.Hisdesigninfo_View hisdesigninfo, List<DbOpertion.Models.Commodity_Stage_Price> list, decimal? UserDecount = 1)
        {
            this.ShopCartId = hisdesigninfo.Id;
            this.CommodityId = hisdesigninfo.CommodityId.Value;
            this.Amount = hisdesigninfo.Amount;

            var priceArray = new List<Tuple<int?, decimal?>>();
            if (hisdesigninfo.SalesInfoList == null)
            {
                foreach (var item in list)
                {
                    priceArray.Add(new Tuple<int?, decimal?>(item1: item.StageAmount, item2: item.StagePrice));
                }
            }
            else
            {
                var saleinfo = hisdesigninfo.SalesInfoList.Split(';').Where(p => !string.IsNullOrEmpty(p)).ToList();
                foreach (var item in saleinfo)
                {
                    var saledetailInfo = item.Split('|').Where(p => !string.IsNullOrEmpty(p)).ToList();
                    if (hisdesigninfo.PrintingMethod == "PrintFunc2")
                    {
                        priceArray.Add(new Tuple<int?, decimal?>(item1: saledetailInfo[0].ParseInt(), item2: saledetailInfo[2].ParseDecimal()));
                    }
                    else if (hisdesigninfo.PrintingMethod == "PrintFunc3")
                    {
                        priceArray.Add(new Tuple<int?, decimal?>(item1: saledetailInfo[0].ParseInt(), item2: saledetailInfo[3].ParseDecimal()));
                    }
                    else
                    {
                        priceArray.Add(new Tuple<int?, decimal?>(item1: saledetailInfo[0].ParseInt(), item2: saledetailInfo[1].ParseDecimal()));
                    }
                }
                var priceInfo = list.Where(p => p.StageAmount == 0).FirstOrDefault();
                if (priceInfo != null)
                {
                    priceArray.Add(new Tuple<int?, decimal?>(item1: 0, item2: priceInfo.StagePrice));
                }

            }
            var price = priceArray.Where(p => p.Item1 <= hisdesigninfo.Amount).OrderByDescending(p => p.Item1).FirstOrDefault();
            if (price != null && hisdesigninfo.Amount != null)
            {
                this.OnePrice = price.Item2.Value;
                this.Price = hisdesigninfo.Amount.Value * price.Item2.Value;
                this.DiscountRate = 0;
            }
            this.PrintingMethod = hisdesigninfo.PrintingMethod;
            this.CommodityName = hisdesigninfo.Name;
            this.CommodityImg = hisdesigninfo.Image;
            this.Color = hisdesigninfo.Color;
            this.Attr = hisdesigninfo.Attr;
            this.BackView = hisdesigninfo.BackView == null ? hisdesigninfo.CommBackView : hisdesigninfo.BackView;
            this.ForntView = hisdesigninfo.ForntView == null ? hisdesigninfo.CommFrontView : hisdesigninfo.ForntView;
            this.ProduceNo = hisdesigninfo.ProductNo;
            this.PrintFuncInfo = hisdesigninfo.PrintFuncInfo;
            this.MaterialId = hisdesigninfo.MaterialId == null ? 0 : hisdesigninfo.MaterialId.Value;
            this.ImageList = hisdesigninfo.ImageList;
        }
        /// <summary>
        /// 商品ID
        /// </summary>
        public int ShopCartId { get; set; }
        /// <summary>
        /// 商品ID
        /// </summary>
        public int CommodityId { get; set; }
        /// <summary>
        /// 数目
        /// </summary>
        public Int32? Amount { get; set; }
        /// <summary>
        /// 价格
        /// </summary>
        public decimal? Price { get; set; }
        /// <summary>
        /// 单件价格
        /// </summary>
        public decimal? OnePrice { get; set; }
        /// <summary>
        /// 印刷方式
        /// </summary>
        public string PrintingMethod { get; set; }
        /// <summary>
        /// 商品名称
        /// </summary>
        public string CommodityName { get; set; }
        /// <summary>
        /// 商品图片
        /// </summary>
        public string CommodityImg { get; set; }
        /// <summary>
        /// 商品颜色
        /// </summary>
        public string Color { get; set; }
        /// <summary>
        /// 商品属性
        /// </summary>
        public string Attr { get; set; }
        /// <summary>
        /// 后面图片
        /// </summary>
        public string BackView { get; set; }
        /// <summary>
        /// 前面图片
        /// </summary>
        public string ForntView { get; set; }
        /// <summary>
        /// 折扣率
        /// </summary>
        public decimal? DiscountRate { get; set; }
        /// <summary>
        /// 商品货号
        /// </summary>
        public string ProduceNo { get; set; }
        /// <summary>
        /// 印刷方式
        /// </summary>
        public string PrintFuncInfo { get; set; }
        /// <summary>
        /// 原材料Id
        /// </summary>
        public int MaterialId { get; set; }
        /// <summary>
        /// 图片列表
        /// </summary>
        public string ImageList { get; set; }

    }
}