using System;

namespace DbOpertion.Models
{
    [Serializable]
    public class Sales_Return
    {
        /// <summary>
        /// 退货表Id
        /// </summary>
        public Int32 Id { get; set; }
        /// <summary>
        /// 用户Id
        /// </summary>
        public Int32? DetailId { get; set; }
        /// <summary>
        /// 退货原因
        /// </summary>
        public String ReturnText { get; set; }
        /// <summary>
        /// 是否退货成功
        /// </summary>
        public String ISRetuen { get; set; }
        /// <summary>
        /// 退货操作理由
        /// </summary>
        public String ReturnReason { get; set; }

    }
}
