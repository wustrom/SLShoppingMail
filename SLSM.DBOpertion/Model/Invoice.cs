using System;

namespace DbOpertion.Models
{
    [Serializable]
    public class Invoice
    {
        /// <summary>
        /// 发票Id
        /// </summary>
        public Int32 Id { get; set; }
        /// <summary>
        /// 用户Id
        /// </summary>
        public Int32? UserId { get; set; }
        /// <summary>
        /// 订单Id
        /// </summary>
        public Int32? OrderId { get; set; }
        /// <summary>
        /// 抬头
        /// </summary>
        public String Title { get; set; }
        /// <summary>
        /// 税号
        /// </summary>
        public String DutyParagraph { get; set; }
        /// <summary>
        /// 发票类型
        /// </summary>
        public String TypeInvoice { get; set; }
        /// <summary>
        /// 默认发票时间
        /// </summary>
        public DateTime? InvoiceTime { get; set; }
        /// <summary>
        /// 电话
        /// </summary>
        public String MobliePhone { get; set; }
        /// <summary>
        /// 开户行
        /// </summary>
        public String OpeningBank { get; set; }
        /// <summary>
        /// 银行账号
        /// </summary>
        public String BankAccount { get; set; }
        /// <summary>
        /// 地址
        /// </summary>
        public String Address { get; set; }

    }
}
