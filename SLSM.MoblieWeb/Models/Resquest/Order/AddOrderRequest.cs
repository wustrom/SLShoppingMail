using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SLSM.MoblieWeb.Models.Resquest.Order
{
    /// <summary>
    /// 添加订单请求
    /// </summary>
    public class AddOrderRequest
    {
        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 地址
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// 手机号码
        /// </summary>
        public string Phone { get; set; }
        /// <summary>
        /// 支付类型
        /// </summary>
        public string payType { get; set; }
        /// <summary>
        /// 购物车Ids
        /// </summary>
        public string ShopCartIds { get; set; }
        /// <summary>
        /// 发票
        /// </summary>
        public string Invoice { get; set; }
    }
}