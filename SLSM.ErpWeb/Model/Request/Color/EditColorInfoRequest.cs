using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SLSM.ErpWeb.Model.Request.Color
{
    /// <summary>
    /// 修改颜色信息请求
    /// </summary>
    public class EditColorInfoRequest
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
        /// 父节点名称
        /// </summary>
        public string fatherName { get; set; }
    }
}