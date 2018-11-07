using System;

namespace DbOpertion.Models
{
    [Serializable]
    public class Grade
    {
        /// <summary>
        /// 分级Id
        /// </summary>
        public Int32 Id { get; set; }
        /// <summary>
        /// 分级名称
        /// </summary>
        public String Name { get; set; }
        /// <summary>
        /// 分级图片
        /// </summary>
        public String Image { get; set; }
        /// <summary>
        /// 展示大图
        /// </summary>
        public String BigImage { get; set; }
        /// <summary>
        /// 分级父节点Id
        /// </summary>
        public Int32? ParentId { get; set; }
        /// <summary>
        /// 热门分类时间
        /// </summary>
        public DateTime? HotGradeTime { get; set; }
        /// <summary>
        /// 分级属性名称
        /// </summary>
        public String GradeAttrName { get; set; }
        /// <summary>
        /// 是否删除
        /// </summary>
        public Boolean? IsDelete { get; set; }
        /// <summary>
        /// 是否为使用场景
        /// </summary>
        public Boolean? IsScene { get; set; }

    }
}
