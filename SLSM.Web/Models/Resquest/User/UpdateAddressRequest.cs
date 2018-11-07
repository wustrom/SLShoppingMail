using Common.Attribute;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SLSM.Web.Models.Resquest.User
{ 
    /// <summary>
    /// 联系人信息
    /// </summary>
    public class UpdateAddressRequest
    {
        /// <summary>
        /// Id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 联系人Id
        /// </summary>
        public int UserId { get; set; }
        /// <summary>
        /// 联系人姓名
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "联系人不能为空")]
        public string ContactName { get; set; }
        /// <summary>
        /// 联系人电话
        /// </summary>
        [PhoneValid]
        public string ContactPhone { get; set; }
        /// <summary>
        /// 联系人地址
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "联系人地址不能为空")]
        public string AddrArea { get; set; }
        /// <summary>
        /// 联系人详细地址
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "联系人详细地址不能为空")]
        public string AddrDetail { get; set; }

        /// <summary>
        ///添加时间
        /// </summary>
        public DateTime? DefaultTime { get; set; }

    }
}