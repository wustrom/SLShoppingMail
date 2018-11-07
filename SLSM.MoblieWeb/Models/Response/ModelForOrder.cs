using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SLSM.MoblieWeb.Models.Response
{
    /// <summary>
    /// 微信订单的模型
    /// </summary>
    public class ModelForOrder
    {
        /// <summary>
        /// AppId
        /// </summary>
        public string appId { get; set; }
        /// <summary>
        /// 时间标签
        /// </summary>
        public string timeStamp { get; set; }
        /// <summary>
        /// 注意事项
        /// </summary>
        public string nonceStr { get; set; }
        /// <summary>
        /// 包赚值
        /// </summary>
        public string packageValue { get; set; }
        /// <summary>
        /// 支付标识
        /// </summary>
        public string paySign { get; set; }
        /// <summary>
        /// 返回信息
        /// </summary>

        public string msg { get; set; }
    }
}