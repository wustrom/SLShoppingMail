using DbOpertion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SLSM.ErpWeb.Model.Response.Table
{
    public class Producers
    {
        public Producers(Producer producer)
        {
            //供应商Id
            this.Id = producer.Id;
            //供应商名称
            this.Name = producer.Name;
            ////工厂货号
            //this.FactoryNumber = producer.FactoryNumber;
            //地址
            this.Address = producer.AddressRegion + " " + producer.Address;
            ////联系人
            //this.Relation = producer.Relation;
            ////电话
            //this.Phone = producer.Phone;
            //供应商代码
            this.ProducerCode = producer.ProducerCode;
            //企业法人
            this.EnterLegPerson = producer.EnterLegPerson;
            //纳税人识别号
            this.identify = producer.identify;
            //开户银行
            this.Bank = producer.Bank;
            //账号
            this.AccountNumber = producer.AccountNumber;
            //账期
            this.AccountPeriod = producer.AccountPeriod + "天";
            //供应产品
            this.SupplyProducts = producer.SupplyProducts;
        }
        /// <summary>
        ///供应商Id
        /// </summary>
        public Int32 Id { get; set; }
        /// <summary>
        ///供应商名称
        /// </summary>
        public String Name { get; set; }
        /// <summary>
        /// 供应商代码
        /// </summary>
        public String ProducerCode { get; set; }
        /// <summary>
        /// 企业法人
        /// </summary>
        public String EnterLegPerson { get; set; }
        /// <summary>
        ///工厂货号
        /// </summary>
        public String FactoryNumber { get; set; }
        /// <summary>
        ///地址
        /// </summary>
        public String Address { get; set; }
        /// <summary>
        ///联系人
        /// </summary>
        public String Relation { get; set; }
        /// <summary>
        ///电话
        /// </summary>
        public String Phone { get; set; }
        /// <summary>
        ///纳税人识别号
        /// </summary>
        public String identify { get; set; }
        /// <summary>
        ///开户银行
        /// </summary>
        public String Bank { get; set; }
        /// <summary>
        ///账号
        /// </summary>
        public string AccountNumber { get; set; }
        /// <summary>
        ///账期
        /// </summary>
        public String AccountPeriod { get; set; }
        /// <summary>
        ///供应产品
        /// </summary>
        public String SupplyProducts { get; set; }
        /// <summary>
        ///最小采购数量
        /// </summary>
        public Int32? MinbuyerCount { get; set; }
        /// <summary>
        ///生产周期
        /// </summary>
        public Int32? productionCycle { get; set; }
        /// <summary>
        ///报价日期
        /// </summary>
        public DateTime? quotedPriceTime { get; set; }
        /// <summary>
        ///价格标示
        /// </summary>
        public String PriceMarking { get; set; }

    }
}