using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SLSM.Web.Models.Resquest.User
{
    /// <summary>
    /// 更新公司信息请求
    /// </summary>
    public class UpdateUserCompanyRequest
    {      
        /// <summary>
        /// 公司名称
        /// </summary>
        public string CompanyName { get; set; }
        /// <summary>
        /// 公司电话
        /// </summary>
        public string CompanyPhone { get; set; }
        /// <summary>
        /// 公司地址
        /// </summary>
        public string CompanyAddr { get; set; }
        /// <summary>
        /// 公司邮箱
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// 公司邮编
        /// </summary>
        public string ZipCode { get; set; }
        /// <summary>
        /// 公司类型
        /// </summary>
        public string CompanyType { get; set; }

        /// <summary>
        /// 公司类型
        /// </summary>
        public string sex { get; set; }
        /// <summary>
        /// 公司类型
        /// </summary>
        public string Name { get; set; }
    }
}