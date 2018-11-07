using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SLSM.Web.Models.Resquest.User
{
    /// <summary>
    /// 更新当前用户名与用户性别请求
    /// </summary>
    public class UpdateUserNameRequest
    {
        /// <summary>
        /// 用户名
        /// </summary>
        [Required(AllowEmptyStrings = false,ErrorMessage ="用户名不能为空")]
        public string Name { get; set; }

        /// <summary>
        /// 用户性别
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "用户性别不能为空")]
        public string Sex { get; set; }
    }
}