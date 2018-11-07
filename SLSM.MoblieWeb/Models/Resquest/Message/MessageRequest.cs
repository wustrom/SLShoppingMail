using Common.Attribute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SLSM.MoblieWeb.Models.Resquest.Message
{
    /// <summary>
    /// 删除信息
    /// </summary>
    public class MessageRequest
    {
        /// <summary>
        /// 消息Id
        /// </summary>
        public int Id { get; set; }


        /// <summary>
        ///
        /// </summary>
        public Boolean? IsWatch { get; set; }
    }
}