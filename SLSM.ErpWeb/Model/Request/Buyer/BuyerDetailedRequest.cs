using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SLSM.ErpWeb.Model.Request.Buyer
{
    public class BuyerDetailedRequest
    {
        /// <summary>
        /// 送货单Id
        /// </summary>
        public int deliverId { get; set; }
        /// <summary>
        /// 仓库Id
        /// </summary>
        public int WarehouseId { get; set; }
        /// <summary>
        /// 入库数量
        /// </summary>
        public string RuKuNum { get; set; }
    }
}