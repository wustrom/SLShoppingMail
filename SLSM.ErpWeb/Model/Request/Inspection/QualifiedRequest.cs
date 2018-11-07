using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SLSM.ErpWeb.Model.Request.Inspection
{
    public class QualifiedRequest
    {
        /// <summary>
        /// 采购表Id 
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 产品内容
        /// </summary>
        public string Context { get; set; }
        /// <summary>
        /// 是否合格
        /// </summary>
        public string IsQualified { get; set; }
        /// <summary>
        /// 不良信息
        /// </summary>
        public string BadInfo { get; set; }
        /// <summary>
        /// 产品图片列表
        /// </summary>
        public string ProductImageInfo { get; set; }
        /// <summary>
        /// 验货员
        /// </summary>
        public string QCINSPECTOR { get; set; }
        /// <summary>
        /// 验货日期
        /// </summary>
        public DateTime INSPECTIONDATE { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remarks { get; set; }
    }
}