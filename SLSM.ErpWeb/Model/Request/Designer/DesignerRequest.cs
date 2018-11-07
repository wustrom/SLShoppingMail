using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SLSM.ErpWeb.Model.Request.Designer
{
    public class DesignerRequest
    {
        /// <summary>
        /// Id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 退回原因
        /// </summary>
        public string Context { get; set; }
        /// <summary>
        /// 生产注意事项
        /// </summary>
        public string InspectionContext { get; set; }
        /// <summary>
        /// 交货时间
        /// </summary>
        public DateTime deliveryTime { get; set; }

        /// <summary>
        /// 印刷工艺
        /// </summary>
        public string printTech { get; set; }
        /// <summary>
        /// 印刷参数
        /// </summary>
        public string PrintParm { get; set; }
    }
}