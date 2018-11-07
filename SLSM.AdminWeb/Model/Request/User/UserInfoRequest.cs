using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Common.Attribute.Constant;
using Common.Attribute;
using System.ComponentModel.DataAnnotations;

namespace SLSM.AdminWeb.Model.Request.User
{
    public class UserInfoRequest
    {
        /// <summary>
        /// 用户Id
        /// </summary>
        public int UserId { get; set; }
    }
}