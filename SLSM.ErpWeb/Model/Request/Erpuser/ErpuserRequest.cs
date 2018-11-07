using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SLSM.ErpWeb.Model.Request.Erpuser
{
    public class ErpuserRequest
    {
        /// <summary>
        /// 角色Id
        /// </summary>
        public int ErproleId { get; set; }
        /// <summary>
        /// 角色名
        /// </summary>
        public string ErproleName { get; set; }
        /// <summary>
        /// 账号
        /// </summary>
        public string erpLoginName { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        public string erpLoginPwd { get; set; }
        /// <summary>
        /// 权限
        /// </summary>
        public string ERProlePower { get; set; }
        /// <summary>
        /// 登录Id
        /// </summary>
        public int erpLoginId { get; set; }
    }
}