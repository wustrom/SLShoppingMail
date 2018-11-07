using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Common.Attribute.Constant;
using Common.Attribute;
using System.ComponentModel.DataAnnotations;

namespace SLSM.AdminWeb.Model.Request.User
{
    public class AddUserRequest
    {
        /// <summary>
        /// 用户昵称
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "请填写用户昵称")]
        public string NickName { get; set; }
        /// <summary>
        /// 用户手机号码
        /// </summary>
        [PhoneValid]
        public string Phone { get; set; }
        /// <summary>
        /// 用户邮箱
        /// </summary>
        [EmailValid]
        public string Email { get; set; }
        /// <summary>
        /// 用户折扣百分比
        /// </summary>
        public int Discount { get; set; }
        /// <summary>
        /// 用户性别
        /// </summary>
        public bool Sex { get; set; }
        /// <summary>
        /// 用户公司名称
        /// </summary>
        public string CompanyName { get; set; }
        /// <summary>
        /// 用户公司电话
        /// </summary>
        public string CompanyPhone { get; set; }

        /// <summary>
        /// 用户公司地址
        /// </summary>
        public string CompanyAddr { get; set; }
        /// <summary>
        /// 用户公司邮编
        /// </summary>
        public string ZipCode { get; set; }
        /// <summary>
        /// 用户Id
        /// </summary>
        public int UserId { get; set; }
    }
}