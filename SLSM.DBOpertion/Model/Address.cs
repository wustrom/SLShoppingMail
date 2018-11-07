using System;

namespace DbOpertion.Models
{
    [Serializable]
    public class Address
    {
        /// <summary>
        /// 地址Id
        /// </summary>
        public Int32 Id { get; set; }
        /// <summary>
        /// 用户Id
        /// </summary>
        public Int32? UserId { get; set; }
        /// <summary>
        /// 联系人姓名
        /// </summary>
        public String ContactName { get; set; }
        /// <summary>
        /// 联系电话
        /// </summary>
        public String ContactPhone { get; set; }
        /// <summary>
        /// 格式：省,市,区
        /// </summary>
        public String AddrArea { get; set; }
        /// <summary>
        /// 地址详情
        /// </summary>
        public String AddrDetail { get; set; }
        /// <summary>
        /// 默认时间
        /// </summary>
        public DateTime? DefaultTime { get; set; }

    }
}
