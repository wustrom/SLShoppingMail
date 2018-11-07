using System;

namespace DbOpertion.Models
{
    [Serializable]
    public class User_Tips
    {
        /// <summary>
        /// 用户消息表id
        /// </summary>
        public Int32 Id { get; set; }
        /// <summary>
        /// 用户id
        /// </summary>
        public Int32? UserId { get; set; }
        /// <summary>
        /// 消息id
        /// </summary>
        public Int32? TipsId { get; set; }
        /// <summary>
        /// 用户是否点击过
        /// </summary>
        public Boolean? IsClick { get; set; }

    }
}
