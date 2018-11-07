using Common.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SLSM.ErpWeb.Model.Request.Table
{
    public class GetInspectionInfoRequst : LayUITableRequest
    {
        public string Inspection { get; set; }
    }
}