using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SLSM.AdminWeb.Model.Request.Order
{
    /// <summary>
    /// 订单修改价格请求
    /// </summary>
    public class OrderChangePriceRequest
    {
        /// <summary>
        /// 订单Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 减少金额
        /// </summary>
        public string ChangePrice { get; set; }
        /// <summary>
        /// 减少金额原因
        /// </summary>
        public string ChangePriceResult { get; set; }
    }
}