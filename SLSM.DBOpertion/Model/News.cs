using System;

namespace DbOpertion.Models
{
    [Serializable]
    public class News
    {
        /// <summary>
        /// 新闻表id
        /// </summary>
        public Int32 Id { get; set; }
        /// <summary>
        /// 新闻标题
        /// </summary>
        public String Title { get; set; }
        /// <summary>
        /// 主标题
        /// </summary>
        public String MainTitle { get; set; }
        /// <summary>
        /// 新闻内容html
        /// </summary>
        public String Content { get; set; }
        /// <summary>
        /// 新闻有效时间截止日
        /// </summary>
        public DateTime? ValidityTime { get; set; }

    }
}
