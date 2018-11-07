using System;

namespace DbOpertion.Models
{
    [Serializable]
    public class Showgradeinfo
    {
        /// <summary>
        /// 分类设置列表Id
        /// </summary>
        public Int32 Id { get; set; }
        /// <summary>
        /// 分类Id
        /// </summary>
        public Int32? GradeId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Int32? OrderCount { get; set; }

    }
}
