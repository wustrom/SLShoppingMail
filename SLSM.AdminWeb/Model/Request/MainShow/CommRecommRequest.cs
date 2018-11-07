using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SLSM.AdminWeb.Model.Request.Grade
{
    /// <summary>
    /// 展示商品请求
    /// </summary>
    public class CommRecommRequest
    {
        /// <summary>
        /// 展示商品id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 第几个商品
        /// </summary>
        public int OrderId { get; set; }
    }
}