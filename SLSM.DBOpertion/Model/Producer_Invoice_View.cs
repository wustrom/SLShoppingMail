using System;

namespace DbOpertion.Models
{
    [Serializable]
    public class Producer_Invoice_View
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
        /// 备注
        /// </summary>
        public String InvoiceContext { get; set; }
        /// <summary>
        /// 单位名称
        /// </summary>
        public String CompanyName { get; set; }
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
        /// 供应商名称
        /// </summary>
        public String Name { get; set; }
        /// <summary>
        /// 企业税号
        /// </summary>
        public String identify { get; set; }
        /// <summary>
        /// 地址
        /// </summary>
        public String Address { get; set; }
        /// <summary>
        /// 付款方式(开票后几天)
        /// </summary>
        public String AccountPeriod { get; set; }
        /// <summary>
        /// 开户银行
        /// </summary>
        public String Bank { get; set; }
        /// <summary>
        /// 是否删除
        /// </summary>
        public Boolean? IsDelete { get; set; }

    }
}
