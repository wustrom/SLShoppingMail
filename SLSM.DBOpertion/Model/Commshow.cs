using System;

namespace DbOpertion.Models
{
    [Serializable]
    public class Commshow
    {
        /// <summary>
        /// 商品展示Id
        /// </summary>
        public Int32 Id { get; set; }
        /// <summary>
        /// 一级分类Id
        /// </summary>
        public Int32? GradeId { get; set; }
        /// <summary>
        /// 排序Id
        /// </summary>
        public Int32? OrderId { get; set; }
        /// <summary>
        /// 商品ID
        /// </summary>
        public Int32? CommId { get; set; }

    }
}
