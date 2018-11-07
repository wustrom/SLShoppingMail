using System;

namespace DbOpertion.Models
{
    [Serializable]
    public class Reply
    {
        /// <summary>
        /// 回复评价Id
        /// </summary>
        public Int32 Id { get; set; }
        /// <summary>
        /// 回复评价时间
        /// </summary>
        public DateTime? CreateTime { get; set; }
        /// <summary>
        /// 回复内容
        /// </summary>
        public String Content { get; set; }
        /// <summary>
        /// 评论Id
        /// </summary>
        public Int32? EvalinfoId { get; set; }
        /// <summary>
        /// 图片列表
        /// </summary>
        public String ImageList { get; set; }

    }
}
