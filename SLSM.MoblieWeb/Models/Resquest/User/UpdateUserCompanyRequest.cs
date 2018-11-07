using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SLSM.MoblieWeb.Models.Resquest.User
{
    /// <summary>
    /// 更新当前用户名与用户性别请求
    /// </summary>
    public class UpdateUserCompanyRequest
    {      
        /// <summary>
        /// 更新公司信息请求
        /// 公司名称
        /// </summary>
        // [Required(AllowEmptyStrings = false, ErrorMessage = "公司名称不能为空")]
        public string CompanyName { get; set; }
        /// <summary>
        /// 公司性质
        /// </summary>
        public string ConmpanyType { get; set; }
        /// <summary>
        /// 公司电话
        /// </summary>
        //[Required(AllowEmptyStrings = false, ErrorMessage = "公司电话不能为空")]
        public string CompanyPhone { get; set; }
        /// <summary>
        /// 公司地址
        /// </summary>
        //[Required(AllowEmptyStrings = false, ErrorMessage = "公司地址不能为空")]
        public string CompanyAddr { get; set; }
        /// <summary>
        /// 公司邮箱
        /// </summary>
        //[Required(AllowEmptyStrings = false, ErrorMessage = "公司邮箱不能为空")]
        public string Email { get; set; }
        /// <summary>
        /// 公司邮编
        /// </summary>
        //[Required(AllowEmptyStrings = false, ErrorMessage = "公司邮编不能为空")]
        public string ZipCode { get; set; }
    }
}