using System;

namespace DbOpertion.Models
{
    [Serializable]
    public class Producerinvoice
    {
        /// <summary>
        /// 供应商发票表Id
        /// </summary>
        public Int32 Id { get; set; }
        /// <summary>
        /// 供应商表Id
        /// </summary>
        public Int32? ProducerId { get; set; }
        /// <summary>
        /// 单位名称
        /// </summary>
        public String CompanyName { get; set; }
        /// <summary>
        /// 发票号码
        /// </summary>
        public String InvoiceNumber { get; set; }
        /// <summary>
        /// 开票时间
        /// </summary>
        public DateTime? InvoiceTime { get; set; }
        /// <summary>
        /// 金额
        /// </summary>
        public String InvoiceMoney { get; set; }
        /// <summary>
        /// 更改后纳税人识别号
        /// </summary>
        public String InvoiceIdentify { get; set; }
        /// <summary>
        /// 更改后电话
        /// </summary>
        public String InvoicePhone { get; set; }
        /// <summary>
        /// 更改后地址
        /// </summary>
        public String InvoiceAddress { get; set; }
        /// <summary>
        /// 更改后开户银行
        /// </summary>
        public String InvoiceBank { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public String InvoiceContext { get; set; }

    }
}
