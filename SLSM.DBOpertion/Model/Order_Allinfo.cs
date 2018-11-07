using System;

namespace DbOpertion.Models
{
    [Serializable]
    public class Order_Allinfo
    {
        /// <summary>
        /// 订单表id
        /// </summary>
        public Int32 Id { get; set; }
        /// <summary>
        /// 用户id
        /// </summary>
        public Int32? UserId { get; set; }
        /// <summary>
        /// 收货人信息id
        /// </summary>
        public Int32? AddressId { get; set; }
        /// <summary>
        /// 总价
        /// </summary>
        public Decimal? TotalPrice { get; set; }
        /// <summary>
        /// 优惠价格
        /// </summary>
        public Decimal? DiscountPrice { get; set; }
        /// <summary>
        /// 优惠原因
        /// </summary>
        public String DisCountResult { get; set; }
        /// <summary>
        /// 支付方式（wechat、alipay、other）
        /// </summary>
        public Int32? PayType { get; set; }
        /// <summary>
        /// 订单状态
        /// </summary>
        public Int32? Status { get; set; }
        /// <summary>
        /// 订单编号
        /// </summary>
        public String OrderNo { get; set; }
        /// <summary>
        /// 订单时间
        /// </summary>
        public DateTime? OrderTime { get; set; }
        /// <summary>
        /// 订单类型 1为电脑订单2为手机订单
        /// </summary>
        public Int32? OrderType { get; set; }
        /// <summary>
        /// 购物人名称
        /// </summary>
        public String BuyName { get; set; }
        /// <summary>
        /// 地址
        /// </summary>
        public String Address { get; set; }
        /// <summary>
        /// 手机号码
        /// </summary>
        public String Phone { get; set; }
        /// <summary>
        /// 快递公司
        /// </summary>
        public String ExpressCompany { get; set; }
        /// <summary>
        /// 快递编号
        /// </summary>
        public String ExpressNo { get; set; }
        /// <summary>
        /// 发票(已弃用)
        /// </summary>
        public String Invoice { get; set; }
        /// <summary>
        /// 发票编号
        /// </summary>
        public Int32? InvoiceId { get; set; }
        /// <summary>
        /// 上一次扫码时间
        /// </summary>
        public DateTime? LastCodeTime { get; set; }
        /// <summary>
        /// 微信是否失败
        /// </summary>
        public Boolean? WechatFaild { get; set; }
        /// <summary>
        /// 是否转到erp
        /// </summary>
        public Boolean? ToErp { get; set; }
        /// <summary>
        /// 是否删除
        /// </summary>
        public Boolean? IsDelete { get; set; }
        /// <summary>
        /// 运费
        /// </summary>
        public String Freight { get; set; }
        /// <summary>
        /// 用户设计文件
        /// </summary>
        public String UserDesign { get; set; }
        /// <summary>
        /// 用户名称
        /// </summary>
        public String Name { get; set; }
        /// <summary>
        /// 格式：省,市,区
        /// </summary>
        public String AddrArea { get; set; }
        /// <summary>
        /// 地址详情
        /// </summary>
        public String AddrDetail { get; set; }

    }
}
