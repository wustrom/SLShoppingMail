using System;

namespace DbOpertion.Models
{
    [Serializable]
    public class Technology
    {
        /// <summary>
        /// 工艺表Id
        /// </summary>
        public Int32 Id { get; set; }
        /// <summary>
        /// 定制名称
        /// </summary>
        public String Name { get; set; }
        /// <summary>
        /// 是否删除(0:删除,1:未删除)
        /// </summary>
        public Boolean? IsDelete { get; set; }

    }
}
