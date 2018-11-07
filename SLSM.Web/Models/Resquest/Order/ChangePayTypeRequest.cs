using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SLSM.Web.Models.Resquest.Order
{
    /// <summary>
    /// 类型转换请求
    /// </summary>
    public class ChangePayTypeRequest:IdRequest
    {
        /// <summary>
        /// 支付类型
        /// </summary>
        public int? PayType { get; set; }
    }
}