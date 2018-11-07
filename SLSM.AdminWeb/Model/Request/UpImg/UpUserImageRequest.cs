using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SLSM.AdminWeb.Model.Request.UpImg
{
    /// <summary>
    /// 设置用户图片请求
    /// </summary>
    public class UpUserImageRequest
    {
        /// <summary>
        /// 用户Id
        /// </summary>
        public int UserID { get; set; }
        /// <summary>
        /// 图片
        /// </summary>
        public string Pic { get; set; }
    }
}