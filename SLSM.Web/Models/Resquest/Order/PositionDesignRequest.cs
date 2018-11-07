using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SLSM.Web.Models.Resquest.Order
{
    /// <summary>
    /// 方位设计请求
    /// </summary>
    public class PositionDesignRequest
    {
        /// <summary>
        /// 设计Id
        /// </summary>
        public int DesignId { get; set; }
        /// <summary>
        /// 订单详情Id
        /// </summary>
        public int OrderDetailId { get; set; }
        /// <summary>
        /// 订单内容
        /// </summary>
        public string Content { get; set; }
        /// <summary>
        /// 位置
        /// </summary>
        public string PrintingPosition { get; set; }
        /// <summary>
        /// 印刷方式
        /// </summary>
        public string Printing { get; set; }
        /// <summary>
        /// 图片
        /// </summary>
        public string Image { get; set; }

    }
}