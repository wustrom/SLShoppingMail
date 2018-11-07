using Common.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SLSM.AdminWeb.Model.Request.Table
{
    /// <summary>
    /// layui表格订单请求
    /// </summary>
    public class LayTableOrderRequest: LayUITableRequest
    {
        /// <summary>
        /// 订单状态
        /// </summary>
        public int StatusType { get; set; }
    }
}