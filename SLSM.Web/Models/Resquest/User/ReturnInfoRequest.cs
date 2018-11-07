using SLSM.Web.Models.Resquest.OrderList;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SLSM.Web.Models.Resquest.User
{ 
    /// <summary>
    /// 退货请求
    /// </summary>
    public class ReturnInfoRequest: OrderListRequest
    {
        /// <summary>
        /// 退货表Id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 订单详情表Id
        /// </summary>
        public int DetailId { get; set; }
        /// <summary>
        /// 退货详情
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "退货原因不能为空！")]
        public string ReturnText { get; set; }
    }
}