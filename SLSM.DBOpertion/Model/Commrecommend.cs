using System;

namespace DbOpertion.Models
{
    [Serializable]
    public class Commrecommend
    {
        /// <summary>
        /// 
        /// </summary>
        public Int32 Id { get; set; }
        /// <summary>
        /// 商品Id
        /// </summary>
        public Int32? CommId { get; set; }
        /// <summary>
        /// 序列Id
        /// </summary>
        public Int32? OrderID { get; set; }
        /// <summary>
        /// 前置图
        /// </summary>
        public String FrontImage { get; set; }
        /// <summary>
        /// 特性
        /// </summary>
        public String AttrSpan { get; set; }
        /// <summary>
        /// 后置图
        /// </summary>
        public String BehindImage { get; set; }

    }
}
