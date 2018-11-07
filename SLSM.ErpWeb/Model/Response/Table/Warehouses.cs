using DbOpertion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SLSM.ErpWeb.Model.Response.Table
{
    public class Warehouses
    {
        /// <summary>
        /// 仓库信息构造函数
        /// </summary>
        /// <param name="ware"></param>
        public Warehouses(Warehouse ware)
        {
            //Id
            this.Id = ware.Id;
            //仓库名称
            this.Name = ware.Name;
            //是否删除
            this.IsDelete = ware.IsDelete;
        }
        /// <summary>
        ///仓库Id
        /// </summary>
        public Int32 Id { get; set; }
        /// <summary>
        ///仓库名称
        /// </summary>
        public String Name { get; set; }
        /// <summary>
        ///是否删除
        /// </summary>
        public Boolean? IsDelete { get; set; }
    }
}