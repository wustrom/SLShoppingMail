using Common.Extend;
using DbOpertion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SLSM.ErpWeb.Model.Response.Table
{
    public class Buyers

    {
        /// <summary>
        /// 送货单表信息构造函数
        /// </summary>
        /// <param name="ware"></param>
        public Buyers(Buyer_Producer_View buyer)
        {
            //采购表Id
            this.Id = buyer.Id;
            //采购表No
            this.BuyerNo = buyer.BuyerNo;
            //供货商名称
            this.Name = buyer.Name;
            //采购时间
            this.buyerTime = buyer.buyerTime.ParseString();
            //采购状态
            this.buyerStatus = buyer.buyerStatus;
            //备注
            this.buyerContext = buyer.buyerContext;
            //金额
            this.buyerMoney = buyer.buyerMoney;
            //已付金额
            this.wantmoney = buyer.wantmoney == null ? 0 : buyer.wantmoney;
            //已付日期
            this.paidTime = buyer.paidTime.ParseString();
            //应付日期
            this.wantTime = buyer.wantTime.ParseString();
            //品检结果
            this.checkStatus = buyer.checkStatus;
            //传真
            this.FaxNumber = buyer.FaxNumber;
            //合同编号
            this.ContractNumber = buyer.ContractNumber;
            //签订时间
            this.SignedTime = buyer.SignedTime;
            //宁波Email
            this.SLSMEmail = buyer.SLSMEmail;
            //宁波传真
            this.SLSMFaxNumber = buyer.SLSMFaxNumber;
            //宁波电话
            this.SLSMPhone = buyer.SLSMPhone;
            //入库金额
            this.AmountOfWare = buyer.AmountOfWare == null ? 0 : buyer.AmountOfWare;
            //账期
            this.AccountPeriod = buyer.AccountPeriod;
        }
        /// <summary>
        ///采购表Id
        /// </summary>
        public Int32 Id { get; set; }
        /// <summary>
        /// 采购表No
        /// </summary>
        public string BuyerNo { get; set; }
        /// <summary>
        /// 供货商Id
        /// </summary>
        public Int32? producerId { get; set; }
        /// <summary>
        /// 金额
        /// </summary>
        public Decimal? buyerMoney { get; set; }
        /// <summary>
        /// 采购时间
        /// </summary>
        public string buyerTime { get; set; }
        /// <summary>
        /// 应付时间
        /// </summary>
        public string wantTime { get; set; }
        /// <summary>
        /// 已付时间
        /// </summary>
        public string paidTime { get; set; }
        /// <summary>
        /// 已付金额
        /// </summary>
        public Decimal? wantmoney { get; set; }
        /// <summary>
        /// 采购状态
        /// </summary>
        public String buyerStatus { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public String buyerContext { get; set; }
        /// <summary>
        ///品检结果
        /// </summary>
        public String checkStatus { get; set; }
        /// <summary>
        /// 供应商名称
        /// </summary>
        public String Name { get; set; }
        /// <summary>
        /// 账期
        /// </summary>
        public String AccountPeriod { get; set; }
        /// <summary>
        /// 传真
        /// </summary>
        public String FaxNumber { get; set; }
        /// <summary>
        /// 合同编号
        /// </summary>
        public String ContractNumber { get; set; }
        /// <summary>
        /// 签订时间
        /// </summary>
        public DateTime? SignedTime { get; set; }
        /// <summary>
        /// 宁波Email
        /// </summary>
        public String SLSMEmail { get; set; }
        /// <summary>
        /// 宁波传真
        /// </summary>
        public String SLSMFaxNumber { get; set; }
        /// <summary>
        /// 宁波电话
        /// </summary>
        public String SLSMPhone { get; set; }
        /// <summary>
        /// 合同条约
        /// </summary>
        public String ContractContext { get; set; }
        /// <summary>
        /// 入库金额
        /// </summary>
        public decimal? AmountOfWare { get; set; }

    }
}