using DbOpertion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SLSM.ErpWeb.Model.Response.Table
{
    public class Erplogin_Role_Views
    {
        public Erplogin_Role_Views(Erplogin_Role_View user)
        {
            //Id
            this.erpLoginId = user.erpLoginId;
            //角色Id
            this.ErproleId = user.ErproleId;
            //账号
            this.erpLoginName = user.erpLoginName;
            //角色名
            this.ErproleName = user.ErproleName;
            //密码
            this.erpLoginPwd = user.erpLoginPwd;
            //权限
            this.ERProlePower = user.ERProlePower;
        }
        /// <summary>
        ///Id
        /// </summary>
        public Int32 erpLoginId { get; set; }
        /// <summary>
        ///角色Id
        /// </summary>
        public Int32? ErproleId { get; set; }
        /// <summary>
        ///账号
        /// </summary>
        public String erpLoginName { get; set; }
        /// <summary>
        ///密码
        /// </summary>
        public String erpLoginPwd { get; set; }
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