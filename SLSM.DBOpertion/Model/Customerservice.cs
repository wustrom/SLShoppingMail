using System;

namespace DbOpertion.Models
{
    [Serializable]
    public class Customerservice
    {
        /// <summary>
        /// 客服表
        /// </summary>
        public Int32 Id { get; set; }
        /// <summary>
        /// 客服人员
        /// </summary>
        public String ServiceName { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        public String ServicePwd { get; set; }
        /// <summary>
        /// 是否可以答疑(0:可以)
        /// </summary>
        public Boolean? IsService { get; set; }
        /// <summary>
        /// 客服QQ
        /// </summary>
        public String ServiceQQ { get; set; }
        /// <summary>
        /// 客服微信
        /// </summary>
        public String ServiceWechat { get; set; }
        /// <summary>
        /// 客服阿里旺旺
        /// </summary>
        public String ServiceALWW { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public String ServicePhone { get; set; }

    }
}
