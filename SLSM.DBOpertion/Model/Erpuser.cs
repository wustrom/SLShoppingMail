using System;

namespace DbOpertion.Models
{
    [Serializable]
    public class Erpuser
    {
        /// <summary>
        /// Erp角色表Id
        /// </summary>
        public Int32 ErproleId { get; set; }
        /// <summary>
        /// 角色名
        /// </summary>
        public String ErproleName { get; set; }
        /// <summary>
        /// 角色权限
        /// </summary>
        public String ERProlePower { get; set; }

    }
}
