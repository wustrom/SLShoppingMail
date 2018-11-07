using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SLSM.Web.Models.Resquest.Order
{
    /// <summary>
    /// 方位设计请求
    /// </summary>
    public class OrderDesignRequest
    {
        /// <summary>
        /// 订单Id
        /// </summary>
        public int OrderId { get; set; }
        /// <summary>
        /// 设计图片
        /// </summary>
        public string DesignImage { get; set; }

    }
}