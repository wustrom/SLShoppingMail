using Common.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SLSM.ErpWeb.Model.Request.Table
{
    public class GetChangeStorageInfoRequest: LayUITableRequest
    {
        /// <summary>
        /// 库存表Id
        /// </summary>
        public int storageId { get; set; }
    }
}