using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SLSM.ErpWeb.Model.Request.Finance
{
    public class InvoiceRequest
    {
        /// <summary>
        /// 发票表Id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 供应商
        /// </summary>
        public int ProducerId { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        public string CompanyName { get; set; }
        /// <summary>
        /// 纳税人识别号
        /// </summary>
        public string InvoiceIdentify { get; set; }
        /// <summary>
        /// 发票号码
        /// </summary>
        public string InvoiceNumber { get; set; }
        /// <summary>
        /// 电话
        /// </summary>
        public string InvoicePhone { get; set; }
        public string AddressInfo { get; set; }
        public string area { get; set; }
        /// <summary>
        /// 地址
        /// </summary>
        public string InvoiceAddress { get; set; }
        /// <summary>
        /// 详细地址
        /// </summary>
        public string AddressDetail { get; set; }
        /// <summary>
        /// 开户银行
        /// </summary>
        public string InvoiceBank { get; set;}
        /// <summary>
        /// 开票时间
        /// </summary>
        public DateTime InvoiceTime{get;set; }
        /// <summary>
        /// 金额
        /// </summary>
        public string InvoiceMoney { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string InvoiceContext { get; set; }     
        /// <summary>
        /// 账期
        /// </summary>
        public int AccountPeriod { get; set; }
        /// <summary>
        /// 是否删除
        /// </summary>
        public bool IsDelete { get; set; }
        /// <summary>
        /// 订单Id
        /// </summary>
        public string ListOrderId { get; set; }
    }
}