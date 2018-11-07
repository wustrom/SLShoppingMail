using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SLSM.MoblieWeb.Models.Resquest.User
{
    /// <summary>
    /// 设置为默认时间
    /// </summary>
    public class UpdateInvoiceTimeRequest
    {
        /// <summary>
        /// ID
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 时间
        /// </summary>
        public DateTime? DefaultTime { get; set; }
    }
}