using SLSM.DBOpertion.Model.Request.Material;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SLSM.ErpWeb.Model.Request.Deceive
{
    public class SelectWarehousRequest
    {
        /// <summary>
        /// 选择仓库Id
        /// </summary>
        public int? WarehousId { get; set; }
        /// <summary>
        /// 选择不同仓库
        /// </summary>
        public string listWarehous { get; set; }
        /// <summary>
        /// 领料单Id
        /// </summary>
        public int? receive_materialsId { get; set; }
        /// <summary>
        /// 制单人
        /// </summary>
        public string receiveSinglePerson { get; set; }
        /// <summary>
        /// 制单时间
        /// </summary>
        public DateTime receiveSingleTime { get; set; }
        /// <summary>
        /// 生产领料表Id
        /// </summary>
        public int? ReceiveId { get; set; }
        public int? productionId { get; set; }

        public List<MaterInfo> MaterList { get; set; }
    }
}