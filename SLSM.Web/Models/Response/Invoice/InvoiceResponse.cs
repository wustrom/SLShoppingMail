using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SLSM.Web.Models.Response.Invoice
{
    /// <summary>
    /// 发票应答
    /// </summary>
    public class InvoiceResponse
    {
        /// <summary>
        /// 发票应答
        /// </summary>
        /// <param name="invoice">发票</param>
        public InvoiceResponse(DbOpertion.Models.Invoice invoice)
        {
            //Id
            this.Id = invoice.Id;
            //抬头
            this.Title = invoice.Title;
            //税号
            this.DutyParagraph = invoice.DutyParagraph;
            //发票类型
            this.TypeInvoice = invoice.TypeInvoice;
            //电话
            this.MobliePhone = invoice.MobliePhone;
            //开户行
            this.OpeningBank = invoice.OpeningBank;
            //银行账户
            this.BankAccount = invoice.BankAccount;
            //地址
            this.Address = invoice.Address;
        }

        /// <summary>
        /// 
        /// </summary>
        public Int32 Id { get; set; }
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
        /// 电话
        /// </summary>
        public String MobliePhone { get; set; }
        /// <summary>
        /// 开户行
        /// </summary>
        public String OpeningBank { get; set; }
        /// <summary>
        /// 银行账户
        /// </summary>
        public String BankAccount { get; set; }
        /// <summary>
        /// 地址
        /// </summary>
        public String Address { get; set; }
    }
}