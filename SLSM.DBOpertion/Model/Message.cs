using System;

namespace DbOpertion.Models
{
    [Serializable]
    public class Message
    {
        /// <summary>
        /// 消息Id
        /// </summary>
        public Int32 Id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public String MainTitle { get; set; }
        /// <summary>
        /// 标题
        /// </summary>
        public String Title { get; set; }
        /// <summary>
        /// 内容
        /// </summary>
        public String Content { get; set; }
        /// <summary>
        /// 时间
        /// </summary>
        public DateTime? MessageTime { get; set; }
        /// <summary>
        /// 是否删除
        /// </summary>
        public Boolean IsDelete { get; set; }

    }
}
