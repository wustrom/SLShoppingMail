using Common.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SLSM.ErpWeb.Model.Request.Table
{
    /// <summary>
    /// 获得全部信息请求
    /// </summary>
    public class GetAllBuyerInfoRequest : LayUITableRequest
    {
        /// <summary>
        /// 供应商
        /// </summary>
        public string ProduterId { get; set; }
        /// <summary>
        /// 开始时间
        /// </summary>
        public DateTime StartTime { get; set; }
        /// <summary>
        /// 结束时间
        /// </summary>
        public DateTime EndTime { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        public string CheckStatus { get; set; }
    }
}