using System;

namespace DbOpertion.Models
{
    [Serializable]
    public class Colorinfo
    {
        /// <summary>
        /// 颜色信息
        /// </summary>
        public Int32 Id { get; set; }
        /// <summary>
        /// 标准色号
        /// </summary>
        public String StandardColor { get; set; }
        /// <summary>
        /// 颜色中文描述
        /// </summary>
        public String ChinaDescribe { get; set; }
        /// <summary>
        /// 颜色英文描述
        /// </summary>
        public String EngDescibe { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Int32? ParentId { get; set; }
        /// <summary>
        /// 颜色Html代码
        /// </summary>
        public String HtmlCode { get; set; }
        /// <summary>
        /// 是否删除
        /// </summary>
        public Boolean? IsDelete { get; set; }

    }
}
