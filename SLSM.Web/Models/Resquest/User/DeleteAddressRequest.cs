using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SLSM.Web.Models.Resquest.User
{ 
    /// <summary>
    /// 删除联系人信息
    /// </summary>
    public class DeleteAddressRequest
    {
        /// <summary>
        /// 地址Id
        /// </summary>
        public int Id { get; set; }
    }
}