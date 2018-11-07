using Common.Extend;
using DbOpertion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SLSM.ErpWeb.Model.Response.Table
{
    public class Producer_Invoice_Views
    {
        public Producer_Invoice_Views(Producer_Invoice_View pro)
        {

            //供应商发票Id
            this.Id = pro.Id;
            //供应商Id
            this.ProducerId = pro.ProducerId;
            //发票号码
            this.InvoiceNumber = pro.InvoiceNumber;
            //开票时间
            this.InvoiceTime = pro.InvoiceTime.ParseString();
            //金额
            this.InvoiceMoney = pro.InvoiceMoney;
            //备注
            this.InvoiceContext = pro.InvoiceContext;
            //供应商名称
            this.Name = pro.Name;
            //电话
            this.InvoicePhone = pro.InvoicePhone == null ? "" : pro.InvoicePhone;
            //纳税人识别号
            this.identify = pro.identify == null ? "" : pro.InvoicePhone;
            //地址
            this.InvoiceAddress = pro.InvoiceAddress;
            //账期
            this.AccountPeriod = pro.AccountPeriod;
            //开户银行
            this.InvoiceBank = pro.InvoiceBank == null ? "" : pro.InvoicePhone;
            //是否删除
            this.IsDelete = pro.IsDelete;
            //单位名称
            this.CompanyName = pro.CompanyName;

        }
        /// <summary>
        ///供应商发票Id
        /// </summary>
        public Int32 Id { get; set; }
        /// <summary>
        ///供应商Id
        /// </summary>
        public Int32? ProducerId { get; set; }
        /// <summary>
        ///发票号码
        /// </summary>
        public String InvoiceNumber { get; set; }
        /// <summary>
        ///开票时间
        /// </summary>
        public string InvoiceTime { get; set; }
        /// <summary>
        ///金额
        /// </summary>
        public String InvoiceMoney { get; set; }
        /// <summary>
        ///备注
        /// </summary>
        public String InvoiceContext { get; set; }
        /// <summary>
        ///供应商名称
        /// </summary>
        public String Name { get; set; }
        /// <summary>
        ///电话
        /// </summary>
        public String InvoicePhone { get; set; }
        /// <summary>
        ///纳税人识别号
        /// </summary>
        public String identify { get; set; }
        /// <summary>
        ///地址
        /// </summary>
        public String InvoiceAddress { get; set; }
        /// <summary>
        ///账期
        /// </summary>
        public String AccountPeriod { get; set; }
        /// <summary>
        ///开户银行
        /// </summary>
        public String InvoiceBank { get; set; }
        /// <summary>
        ///是否删除
        /// </summary>
        public Boolean? IsDelete { get; set; }
        /// <summary>
        ///单位名称
        /// </summary>
        public String CompanyName { get; set; }
    }
}