using DbOpertion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SLSM.ErpWeb.Model.Response.Table
{
    public class Erpusers
    {
        public Erpusers(Erpuser erpuser)
        {
            //Id
            this.ErproleId = erpuser.ErproleId;
            //角色
            this.ErproleName = erpuser.ErproleName;
            //权限
            this.ERProlePower = erpuser.ERProlePower;
        }
        /// <summary>
        ///id 
        /// </summary>
        public Int32 ErproleId { get; set; }
        /// <summary>
        ///角色名
        /// </summary>
        public String ErproleName { get; set; }
        /// <summary>
        ///权限
        /// </summary>
        public String ERProlePower { get; set; }
    }
}