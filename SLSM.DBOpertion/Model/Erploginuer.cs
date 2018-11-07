using System;

namespace DbOpertion.Models
{
    [Serializable]
    public class Erploginuer
    {
        /// <summary>
        /// erp登录Id
        /// </summary>
        public Int32 erpLoginId { get; set; }
        /// <summary>
        /// 角色表Id
        /// </summary>
        public Int32? ErproleId { get; set; }
        /// <summary>
        /// 登录账号
        /// </summary>
        public String erpLoginName { get; set; }
        /// <summary>
        /// 登录密码
        /// </summary>
        public String erpLoginPwd { get; set; }

    }
}
