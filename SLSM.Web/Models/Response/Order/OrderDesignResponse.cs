using DbOpertion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SLSM.Web.Models.Response.Order
{
    /// <summary>
    /// 订单设计应答
    /// </summary>
    public class OrderDesignResponse
    {
        public OrderDesignResponse()
        {

        }
        /// <summary>
        /// 订单明细Id
        /// </summary>
        public Int32? OrderDetailId { get; set; }
        /// <summary>
        /// 订单明细No
        /// </summary>
        public string OrderDetailNo { get; set; }
        /// <summary>
        /// SKu
        /// </summary>
        public string SKU { get; set; }
        /// <summary>
        /// SKU图片
        /// </summary>
        public string SKUImage { get; set; }
        /// <summary>
        /// 产品名称
        /// </summary>
        public string CommodityName { get; set; }
        /// <summary>
        /// 笔芯颜色
        /// </summary>
        public string ColorName { get; set; }
        /// <summary>
        /// 印刷方式
        /// </summary>
        public string PrintingFunc { get; set; }
        /// <summary>
        /// 建议
        /// </summary>
        public string proposal { get; set; }
    }
}