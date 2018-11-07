using System;

namespace DbOpertion.Models
{
    [Serializable]
    public class Producer
    {
        /// <summary>
        /// 供应商表Id
        /// </summary>
        public Int32 Id { get; set; }
        /// <summary>
        /// 供应商代码
        /// </summary>
        public String ProducerCode { get; set; }
        /// <summary>
        /// 地址
        /// </summary>
        public String Address { get; set; }
        /// <summary>
        /// 供应商名称
        /// </summary>
        public String Name { get; set; }
        /// <summary>
        /// 所在地址
        /// </summary>
        public String AddressRegion { get; set; }
        /// <summary>
        /// 简称
        /// </summary>
        public String Abbreviation { get; set; }
        /// <summary>
        /// 邮政编码
        /// </summary>
        public String ZipCode { get; set; }
        /// <summary>
        /// 供应产品
        /// </summary>
        public String SupplyProducts { get; set; }
        /// <summary>
        /// 信用等级
        /// </summary>
        public String CreditRating { get; set; }
        /// <summary>
        /// 公司网址
        /// </summary>
        public String CompanyWebsite { get; set; }
        /// <summary>
        /// 合作等级
        /// </summary>
        public String CooperationLevel { get; set; }
        /// <summary>
        /// 企业法人
        /// </summary>
        public String EnterLegPerson { get; set; }
        /// <summary>
        /// 企业传真
        /// </summary>
        public String FaxNumber { get; set; }
        /// <summary>
        /// 付款方式(开票后几天)
        /// </summary>
        public String AccountPeriod { get; set; }
        /// <summary>
        /// 开票抬头
        /// </summary>
        public String RaiseTicket { get; set; }
        /// <summary>
        /// 开户银行
        /// </summary>
        public String Bank { get; set; }
        /// <summary>
        /// 企业税号
        /// </summary>
        public String identify { get; set; }
        /// <summary>
        /// 企业账号
        /// </summary>
        public String AccountNumber { get; set; }
        /// <summary>
        /// 是否删除
        /// </summary>
        public Boolean? IsDelete { get; set; }

    }
}
