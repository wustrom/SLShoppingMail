using Common.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SLSM.ErpWeb.Model.Request.Table
{
    public class GetProductionRequest: LayUITableRequest
    {
        public string Production { get; set; }
    }
}