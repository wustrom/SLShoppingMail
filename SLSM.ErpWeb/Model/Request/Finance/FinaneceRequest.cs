using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SLSM.ErpWeb.Model.Request.Finance
{
    public class FinaneceRequest
    {
        /// <summary>
        /// Id
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// 金额
        /// </summary>
        public Decimal wantmoney { get; set; }
    }
}