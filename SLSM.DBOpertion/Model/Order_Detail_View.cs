using System;

namespace DbOpertion.Models
{
    [Serializable]
    public class Order_Detail_View
    {
        /// <summary>
        /// 订单详情表id
        /// </summary>
        public Int32 Id { get; set; }
        /// <summary>
        /// 订单id
        /// </summary>
        public Int32? OrderId { get; set; }
        /// <summary>
        /// 商品id
        /// </summary>
        public Int32? CommodityId { get; set; }
        /// <summary>
        /// 颜色
        /// </summary>
        public Int32? Color { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Int32? Amount { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Decimal? PayMoney { get; set; }
        /// <summary>
        /// 购物车Id
        /// </summary>
        public Int32? ShopCartId { get; set; }
        /// <summary>
        /// 图片列表
        /// </summary>
        public String ImageList { get; set; }
        /// <summary>
        /// 文字操作列表
        /// </summary>
        public String WordOpertion { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public String CustomImageOpertion { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public String OnLineImageOpertion { get; set; }
        /// <summary>
        /// 操作Html1(最多3个)
        /// </summary>
        public String Opertion1 { get; set; }
        /// <summary>
        /// 操作Html2(最多3个)
        /// </summary>
        public String Opertion2 { get; set; }
        /// <summary>
        /// 操作Html3(最多3个)
        /// </summary>
        public String Opertion3 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public String DesignerImage { get; set; }
        /// <summary>
        /// 用户确认
        /// </summary>
        public Boolean? UserSure { get; set; }
        /// <summary>
        /// 设计师提交
        /// </summary>
        public Boolean? DesignCommit { get; set; }
        /// <summary>
        /// 输出方式
        /// </summary>
        public String PrintingMethod { get; set; }
        /// <summary>
        /// 商品名称
        /// </summary>
        public String Name { get; set; }
        /// <summary>
        /// 商品图片
        /// </summary>
        public String Image { get; set; }
        /// <summary>
        /// 商品介绍
        /// </summary>
        public String Introduce { get; set; }
        /// <summary>
        /// 商品背面图
        /// </summary>
        public String BackView { get; set; }
        /// <summary>
        /// 商品正面图
        /// </summary>
        public String FrontView { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public String comImageList { get; set; }
        /// <summary>
        /// 编号
        /// </summary>
        public String ProductNo { get; set; }

    }
}
