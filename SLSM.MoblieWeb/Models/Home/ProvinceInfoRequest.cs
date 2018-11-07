using Common.Attribute.Constant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SLSM.MoblieWeb.Models.Home
{
    /// <summary>
    /// 省份请求
    /// </summary>
    public class ProvinceRequest
    {
        /// <summary>
        /// 省份等级(province|city|area)
        /// </summary>
        [limitString(AllowEmpty = false, ErrorMessage = "省份等级不正确", Limit = "province|city|area")]
        public string Level { get; set; }

        /// <summary>
        /// 用户图片验证码
        /// </summary>
        public string AreaName { get; set; }
    }
}