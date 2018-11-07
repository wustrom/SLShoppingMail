using System;

namespace DbOpertion.Models
{
    [Serializable]
    public class Message_Grant_View
    {
        /// <summary>
        /// 发放表Id
        /// </summary>
        public Int32 Id { get; set; }
        /// <summary>
        /// 用户Id
        /// </summary>
        public Int32? UserId { get; set; }
        /// <summary>
        /// 消息表Id
        /// </summary>
        public Int32? MessageId { get; set; }
        /// <summary>
        /// 是否观看
        /// </summary>
        public Boolean? IsWatch { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public String MainTitle { get; set; }
        /// <summary>
        /// 标题
        /// </summary>
        public String Title { get; set; }
        /// <summary>
        /// 时间
        /// </summary>
        public DateTime? MessageTime { get; set; }
        /// <summary>
        /// 内容
        /// </summary>
        public String Content { get; set; }
        /// <summary>
        /// 是否删除
        /// </summary>
        public Boolean? IsDelete { get; set; }

    }
}
