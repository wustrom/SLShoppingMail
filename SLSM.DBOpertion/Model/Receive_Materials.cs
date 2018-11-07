using System;

namespace DbOpertion.Models
{
    [Serializable]
    public class Receive_Materials
    {
        /// <summary>
        /// 领料单表Id
        /// </summary>
        public Int32 Id { get; set; }
        /// <summary>
        /// 生产领料表Id
        /// </summary>
        public Int32? receiveId { get; set; }
        /// <summary>
        /// 原材料表Id
        /// </summary>
        public Int32? raw_materialsId { get; set; }
        /// <summary>
        /// 基础数目
        /// </summary>
        public Int32? BaseCount { get; set; }
        /// <summary>
        /// 额外申请数量
        /// </summary>
        public Int32? additionalCount { get; set; }
        /// <summary>
        /// SKU代码
        /// </summary>
        public String SKU { get; set; }
        /// <summary>
        /// 是否为额外领料
        /// </summary>
        public Boolean? Isadditional { get; set; }

    }
}
