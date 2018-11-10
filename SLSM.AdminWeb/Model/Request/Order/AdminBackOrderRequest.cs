using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SLSM.AdminWeb.Model.Request.Order
{
    /// <summary>
    /// 后台下单请求
    /// </summary>
    public class AdminBackOrderRequest
    {
        /// <summary>
        /// 商品Id
        /// </summary>
        public int CommID { get; set; }
        /// <summary>
        /// 商品颜色
        /// </summary>
        public int CommColor { get; set; }
        /// <summary>
        /// 印刷方式
        /// </summary>
        public string CommPrint { get; set; }
        /// <summary>
        /// 商品数量
        /// </summary>
        public int CommNum { get; set; }
        /// <summary>
        /// 收货人姓名
        /// </summary>
        public string CommName { get; set; }
        /// <summary>
        /// 收货人手机
        /// </summary>
        public string CommPhone { get; set; }
        /// <summary>
        /// 收货人地区
        /// </summary>
        public string CommArea { get; set; }
        /// <summary>
        /// 收货人详细地址
        /// </summary>
        public string CommDetailArea { get; set; }
        /// <summary>
        /// 发票信息
        /// </summary>
        public int InvoiceInfo { get; set; }
        /// <summary>
        /// 发票抬头
        /// </summary>
        public string InvoicesRaised { get; set; }
        /// <summary>
        /// 企业税号
        /// </summary>
        public string EnterpriseTaxNumber { get; set; }
        /// <summary>
        /// 订单类型
        /// </summary>
        public int OrderType { get; set; }
    }   
}