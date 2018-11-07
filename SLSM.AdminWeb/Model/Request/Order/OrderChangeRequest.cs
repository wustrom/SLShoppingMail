using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SLSM.AdminWeb.Model.Request.Order
{
    /// <summary>
    /// 订单信息修改请求
    /// </summary>
    public class OrderChangeRequest
    {
        /// <summary>
        /// 订单Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 快递公司
        /// </summary>
        public string ExpressCompany { get; set; }
        /// <summary>
        /// 快递编号
        /// </summary>
        public string ExpressNo { get; set; }
    }
}