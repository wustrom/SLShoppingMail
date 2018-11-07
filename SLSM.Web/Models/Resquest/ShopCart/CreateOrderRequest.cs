using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SLSM.AdminWeb.Model.Request.ShopCart
{
    public class CreateOrderRequest
    {
        /// <summary>
        /// 订单列表
        /// </summary>
        public string OrderList { get; set; }
        /// <summary>
        /// 用户Guid
        /// </summary>
        public string userGuid { get; set; }
    }
}