using Common.Attribute;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SLSM.Web.Models.Resquest.Home
{
    /// <summary>
    /// 根据手机号登入请求
    /// </summary>
    public class LoginByPhoneRequest
    {
        /// <summary>
        /// 用户手机号码
        /// </summary>
        [PhoneValid]
        public string UserPhone { get; set; }

        /// <summary>
        /// 用户图片验证码
        /// </summary>
        public string ImageCode { get; set; }

        /// <summary>
        /// 用户手机验证码
        /// </summary>
        public string PhoneCode { get; set; }

        /// <summary>
        /// 用户密码
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// 是否第三方
        /// </summary>
        public bool? IsThild { get; set; }
        /// <summary>
        /// 微信Id
        /// </summary>
        public string openWechatid { get; set; }
        /// <summary>
        /// token获取信息
        /// </summary>
        public string accessToken { get; set; }
    }
}