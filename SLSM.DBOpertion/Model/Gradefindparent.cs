using System;

namespace DbOpertion.Models
{
    [Serializable]
    public class Gradefindparent
    {
        /// <summary>
        /// 分级父节点Id
        /// </summary>
        public Int32? grandpaId { get; set; }
        /// <summary>
        /// 分级名称
        /// </summary>
        public String grandpaName { get; set; }
        /// <summary>
        /// 分级图片
        /// </summary>
        public String grandpaImage { get; set; }
        /// <summary>
        /// 展示大图
        /// </summary>
        public String grandpaBigImage { get; set; }
        /// <summary>
        /// 分级Id
        /// </summary>
        public Int32? parentId { get; set; }
        /// <summary>
        /// 分级名称
        /// </summary>
        public String parentName { get; set; }
        /// <summary>
        /// 分级图片
        /// </summary>
        public String parentImage { get; set; }
        /// <summary>
        /// 展示大图
        /// </summary>
        public String parentBigImage { get; set; }
        /// <summary>
        /// 分级Id
        /// </summary>
        public Int32 id { get; set; }
        /// <summary>
        /// 分级名称
        /// </summary>
        public String gradeName { get; set; }
        /// <summary>
        /// 分级图片
        /// </summary>
        public String gradeImage { get; set; }
        /// <summary>
        /// 展示大图
        /// </summary>
        public String gradeBigImage { get; set; }
        /// <summary>
        /// 热门分类时间
        /// </summary>
        public DateTime? HotGradeTime { get; set; }
        /// <summary>
        /// 分级属性名称
        /// </summary>
        public String GradeAttrName { get; set; }

    }
}
