using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SLSM.Web.Models.Resquest.OrderList
{
    /// <summary>
    /// 确认收货
    /// </summary>
    public class ConfirmRequest
    {
        /// <summary>
        /// ID
        /// </summary>
        public int Id { set; get; }
        /// <summary>
        /// 状态
        /// </summary>
        public Int32? Status { get; set; }
    }
}