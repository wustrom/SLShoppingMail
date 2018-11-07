using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SLSM.ErpWeb.Model.Request.Warehouses
{
    public class WarehouseRequest
    {
        /// <summary>
        /// 仓库ID
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 仓库名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        ///是否删除
        /// </summary>
        public Boolean? IsDelete { get; set; }
        /// <summary>
        /// 仓库多个Id
        /// </summary>
        public string Ids { get; set; }
    }
}