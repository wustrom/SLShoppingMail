using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SLSM.ErpWeb.Model.Request.Material
{
    /// <summary>
    /// 供应商购买请求
    /// </summary>
    public class BuyMaterialRequest
    {
        /// <summary>
        /// 颜色SKU号码
        /// </summary>
        public string ColorInfo_SKU { get; set; }
        /// <summary>
        /// 原材料id
        /// </summary>
        public int MaterialId { get; set; }
        /// <summary>
        /// 供应商ID
        /// </summary>
        public int producerList_ProdecerCode { get; set; }
        /// <summary>
        /// 购买数目
        /// </summary>
        public int BuyerNum { get; set; }
        /// <summary>
        /// 购买单价
        /// </summary>
        public decimal producerList_PurchasePrice { get; set; }

    }
}