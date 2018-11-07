using System;

namespace DbOpertion.Models
{
    [Serializable]
    public class Platalink
    {
        /// <summary>
        /// 平台链接
        /// </summary>
        public Int32 Id { get; set; }
        /// <summary>
        /// 链接头部
        /// </summary>
        public String Title { get; set; }
        /// <summary>
        /// 链接内容
        /// </summary>
        public String Content { get; set; }

    }
}
