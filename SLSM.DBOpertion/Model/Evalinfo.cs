using System;

namespace DbOpertion.Models
{
    [Serializable]
    public class Evalinfo
    {
        /// <summary>
        /// 评价表id
        /// </summary>
        public Int32 EvaluateId { get; set; }
        /// <summary>
        /// 用户Id
        /// </summary>
        public Int32? UserId { get; set; }
        /// <summary>
        /// 商品Id
        /// </summary>
        public Int32? CommodityId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public String ImageList { get; set; }
        /// <summary>
        /// 提交时间
        /// </summary>
        public DateTime? CreateTime { get; set; }
        /// <summary>
        /// 提交内容
        /// </summary>
        public String Content { get; set; }
        /// <summary>
        /// 星级
        /// </summary>
        public Double? Start { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public String FrontView { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public String BackView { get; set; }
        /// <summary>
        /// 父节点Id
        /// </summary>
        public Int32? ParentId { get; set; }
        /// <summary>
        /// 用户名称
        /// </summary>
        public String Name { get; set; }
        /// <summary>
        /// 商品名称
        /// </summary>
        public String CommName { get; set; }

    }
}
