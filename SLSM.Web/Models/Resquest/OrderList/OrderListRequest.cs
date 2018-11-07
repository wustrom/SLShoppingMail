using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SLSM.Web.Models.Resquest.OrderList
{
    /// <summary>
    /// 
    /// </summary>
    public class OrderListRequest
    {
        /// <summary>
        ///
        /// </summary>
        public Int32 OrderId { get; set; }
        /// <summary>
        /// 
        /// </summary>
       
        public Int32? Status { get; set; }      
    }
}