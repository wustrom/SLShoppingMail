using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SLSM.AdminWeb.Model.Request.Message
{
    public class SendMessageRequest
    {
        /// <summary>
        ///
        /// </summary>
        public Int32 Id { get; set; }
        /// <summary>
        ///
        /// </summary>
        public String UserIds { get; set; }
    }
}