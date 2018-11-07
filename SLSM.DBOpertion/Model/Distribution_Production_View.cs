using System;

namespace DbOpertion.Models
{
    [Serializable]
    public class Distribution_Production_View
    {
        /// <summary>
        /// 生产计划分配表
        /// </summary>
        public Int32 Id { get; set; }
        /// <summary>
        /// 生产管理Id
        /// </summary>
        public Int32? ProductionId { get; set; }
        /// <summary>
        /// 生产工序
        /// </summary>
        public String procedures { get; set; }
        /// <summary>
        /// 生产时间
        /// </summary>
        public Int32? productionTime { get; set; }
        /// <summary>
        /// 生产人员
        /// </summary>
        public String productionMan { get; set; }
        /// <summary>
        /// 生产状态
        /// </summary>
        public String ProductionStatus { get; set; }

    }
}
