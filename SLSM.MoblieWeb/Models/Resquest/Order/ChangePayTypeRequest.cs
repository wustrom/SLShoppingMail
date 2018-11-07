using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SLSM.MoblieWeb.Models.Resquest.Order
{
    public class ChangePayTypeRequest
    {
        /// <summary>
        /// id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 支付类型
        /// </summary>
        public int? PayType { get; set; }
    }
}