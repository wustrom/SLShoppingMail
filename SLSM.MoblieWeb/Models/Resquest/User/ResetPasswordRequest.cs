using Common.Attribute;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SLSM.MoblieWeb.Models.Resquest.User
{
    /// <summary>
    /// 重置电话请求
    /// </summary>
    public class ResetPasswordRequest
    {
        /// <summary>
        /// 旧密码
        /// </summary>
        [Required(ErrorMessage = "请填写旧密码", AllowEmptyStrings = false)]
        public string Password { get; set; }
        /// <summary>
        /// 新密码
        /// </summary>
        [Required(ErrorMessage = "请填写新密码", AllowEmptyStrings = false)]
        public string NewPassword { get; set; }
    }
}