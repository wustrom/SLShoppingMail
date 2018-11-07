using Common.Attribute;
using Common.Attribute.Constant;
using SLSM.Web.Models.Resquest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SLSM.MoblieWeb.Models.Resquest.Evaluate
{
    /// <summary>
    /// 用户评价分页请求
    /// </summary>
    public class EvaluateByPageRequest : PageRequest
    {
        /// <summary>
        /// 排序方式
        /// </summary>
        [limitString(Limit = "EvaluateId|CreateTime|Start", AllowEmpty = false, ErrorMessage = "排序方式错误！")]
        public string OrderBy { get; set; }
        
        /// <summary>
        /// 商品Id
        /// </summary>
        public int CommodityId { get; set; }

    }
}