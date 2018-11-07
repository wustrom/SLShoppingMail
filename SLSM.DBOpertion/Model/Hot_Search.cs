using System;

namespace DbOpertion.Models
{
    [Serializable]
    public class Hot_Search
    {
        /// <summary>
        /// 热门搜索表
        /// </summary>
        public Int32 Id { get; set; }
        /// <summary>
        /// 搜索词
        /// </summary>
        public Int32? SearchWord { get; set; }
        /// <summary>
        /// 搜索次数
        /// </summary>
        public Int32? Amount { get; set; }

    }
}
