using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SLSM.ErpWeb.Model.Request.Color
{
    /// <summary>
    /// 修改颜色信息请求
    /// </summary>
    public class EditColorDetailRequest
    {
        /// <summary>
        /// 颜色Id
        /// </summary>
        public int? ColorId { get; set; }
        /// <summary>
        /// 父节点Id
        /// </summary>
        public int? fatherId { get; set; }
        /// <summary>
        /// 中文描述
        /// </summary>
        public string ChinaDescribe { get; set; }
        /// <summary>
        /// html代码
        /// </summary>
        public string HtmlCode { get; set; }
        /// <summary>
        /// 标准色号
        /// </summary>
        public string StandardColor { get; set; }
        /// <summary>
        /// 英文描述
        /// </summary>
        public string EngDescibe { get; set; }
    }
}