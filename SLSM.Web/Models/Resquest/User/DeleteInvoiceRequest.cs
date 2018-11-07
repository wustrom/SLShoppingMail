using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SLSM.Web.Models.Resquest.User
{ 
    /// <summary>
    /// 删除发票请求
    /// </summary>
    public class DeleteInvoiceRequest
    {
        /// <summary>
        /// 发票Id
        /// </summary>
        public int Id { get; set; }
    }
}