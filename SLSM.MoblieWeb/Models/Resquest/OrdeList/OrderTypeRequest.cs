using SLSM.Web.Models.Resquest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SLSM.MoblieWeb.Models.Resquest.OrderList
{
    /// <summary>
    /// 
    /// </summary>
    public class OrderTypeRequest: PageRequest
    {
        /// <summary>
        ///状态
        /// </summary>
        public string Name { get; set; }

    }
}
