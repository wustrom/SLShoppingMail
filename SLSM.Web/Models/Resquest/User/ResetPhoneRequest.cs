using Common.Attribute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SLSM.Web.Models.Resquest.User
{
    /// <summary>
    /// 重置电话请求
    /// </summary>
    public class ResetPhoneRequest
    {
        /// <summary>
        /// 手机号1
        /// </summary>
        [PhoneValid]
        public string Phone1 { get; set; }
        /// <summary>
        /// 验证码1
        /// </summary>
        public string Code1 { get; set; }
        /// <summary>
        /// 手机号2
        /// </summary>
        [PhoneValid]
        public string Phone2 { get; set; }
        /// <summary>
        /// 验证码2
        /// </summary>
        public string Code2 { get; set; }
    }
}