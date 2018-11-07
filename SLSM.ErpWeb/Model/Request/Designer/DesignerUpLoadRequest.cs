using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SLSM.ErpWeb.Model.Request.Designer
{
    public class DesignerUpLoadRequest
    {
        /// <summary>
        /// Id
        /// </summary>
        public int ProductionId { get; set; }
        /// <summary>
        ///上传位置1图片
        /// </summary>
        public string Position1 { get; set; }
        /// <summary>
        ///上传位置1描述
        /// </summary>
        public string PositionName1 { get; set; }
        /// <summary>
        /// 上传位置2图片
        /// </summary>
        public string Position2 { get; set; }
        /// <summary>
        ///上传位置1描述
        /// </summary>
        public string PositionName2 { get; set; }
        /// <summary>
        /// 上传位置3图片
        /// </summary>
        public string Position3 { get; set; }
        /// <summary>
        ///上传位置1描述
        /// </summary>
        public string PositionName3 { get; set; }
        /// <summary>
        /// 上传文件地址
        /// </summary>
        public string UpFileAddr { get; set; }
    }
}