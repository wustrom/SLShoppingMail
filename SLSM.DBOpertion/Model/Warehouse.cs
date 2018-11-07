using System;

namespace DbOpertion.Models
{
    [Serializable]
    public class Warehouse
    {
        /// <summary>
        /// 仓库表
        /// </summary>
        public Int32 Id { get; set; }
        /// <summary>
        /// 仓库名
        /// </summary>
        public String Name { get; set; }
        /// <summary>
        /// 是否删除(0:已删除,1:未删除)
        /// </summary>
        public Boolean? IsDelete { get; set; }

    }
}
