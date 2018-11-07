using Common.Attribute;
using Common.Attribute.Constant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SLSM.Web.Models.Resquest
{
    /// <summary>
    /// 分页请求
    /// </summary>
    public class PageRequest
    {
        /// <summary>
        /// 页码
        /// </summary>
        [PageNo(DefaultNo = 1)]
        public int PageNo { get; set; }
        /// <summary>
        /// 页面大小
        /// </summary>
        [PageSize(DefaultSize = 5)]
        public int PageSize { get; set; }
        /// <summary>
        /// 降序
        /// </summary>
        public bool Desc { get; set; }
    }
}