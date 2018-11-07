using System;

namespace DbOpertion.Models
{
    [Serializable]
    public class Grade_Attr
    {
        /// <summary>
        /// 分级属性(2,3级才有)
        /// </summary>
        public Int32 Id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Int32? GradeId { get; set; }
        /// <summary>
        /// 分级属性名称
        /// </summary>
        public String Content { get; set; }

    }
}
