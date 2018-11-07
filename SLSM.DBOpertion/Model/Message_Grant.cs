using System;

namespace DbOpertion.Models
{
    [Serializable]
    public class Message_Grant
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

    }
}
