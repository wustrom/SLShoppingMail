using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SLSM.ErpWeb.Model.Request.Echnology
{
    public class EchnologyRequest
    {
        /// <summary>
        /// 定制工艺Id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 定制工艺名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 定制工艺Id列
        /// </summary>
        public string Ids { get; set; }
    }
}