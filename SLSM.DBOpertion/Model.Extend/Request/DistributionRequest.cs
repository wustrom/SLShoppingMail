using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SLSM.ErpWeb.Model.Request.Designer
{
    public class DistributionRequest
    {
        /// <summary>
        /// Id
        /// </summary>
        public int ProductionId { get; set; }
        /// <summary>
        /// 制单人
        /// </summary>
       public string ProductionPerson { get; set; }
        public List<ProcedureInfo> ProInfo { get; set; }
    }
    public class ProcedureInfo
    {
        /// <summary>
        /// 生产工序
        /// </summary>
        public string procedure { get; set; }
        /// <summary>
        /// 生产时间
        /// </summary>
        public string productionTime { get; set; }
        /// <summary>
        /// 生产人员
        /// </summary>
        public string productionMan { get; set; }
    }
}