using DbOpertion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SLSM.ErpWeb.Model.Response.Table
{
    public class Delivers
    {
        public Delivers(Deliver_Buyer_View deliver)
        {
            //送货单表Id
            this.Id = deliver.Id;
            //采购表Id
            this.buyerId = deliver.buyerId;
            //采购日期
            this.buyerTime = deliver.buyerTime;
            //原材料Id
            this.raw_materialsId = deliver.raw_materialsId;
            //名称
            this.raw_materialsId = deliver.raw_materialsId;
            //型号
            this.Specification = deliver.Specification;
            //单位
            this.ChinaUnit = deliver.ChinaUnit;
            //是否入库
            this.IsStatus = deliver.IsStatus;
            //金额
            this.DeliverMoney = deliver.DeliverMoney;
            //单价
            this.buyerPrice = deliver.buyerPrice;
            //已付账款
            this.wantmoney = deliver.wantmoney;
            //应付日期
            this.wantTime = deliver.wantTime;
            //采购日期
            this.buyerTime = deliver.buyerTime;
            //数量
            this.buyerCount = deliver.buyerCount;
            //备注
            this.buyerContext = deliver.buyerContext;
            //供应商Id
            this.producerId = deliver.producerId;
            //供应商名称
            this.producerIdName = deliver.producerIdName;
            //供应商名称
            this.producerName = deliver.producerName;
            //颜色
            this.Color = deliver.Color;
            //中文产品名称
            this.ChinaProductName = deliver.ChinaProductName;
        }
        /// <summary>
        ///送货单表Id
        /// </summary>
        public Int32 Id { get; set; }
        /// <summary>
        ///采购表Id
        /// </summary>
        public Int32? buyerId { get; set; }
        /// <summary>
        ///采购日期
        /// </summary>
        public DateTime? buyerTime { get; set; }
        /// <summary>
        ///原材料Id
        /// </summary>
        public Int32? raw_materialsId { get; set; }
        /// <summary>
        ///中文名称
        /// </summary>
        public String ChinaProductName { get; set; }
        /// <summary>
        ///型号
        /// </summary>
        public String Specification { get; set; }
        /// <summary>
        ///单位
        /// </summary>
        public String ChinaUnit { get; set; }
        /// <summary>
        ///是否入库
        /// </summary>
        public String IsStatus { get; set; }
        /// <summary>
        ///金额
        /// </summary>
        public Decimal? DeliverMoney { get; set; }
        /// <summary>
        ///单价
        /// </summary>
        public Decimal? buyerPrice { get; set; }
        /// <summary>
        ///已付账款
        /// </summary>
        public Decimal? wantmoney { get; set; }
        /// <summary>
        ///应付日期
        /// </summary>
        public DateTime? wantTime { get; set; }
        /// <summary>
        ///采购日期
        /// </summary>
        public Decimal? buyerMoney { get; set; }
        /// <summary>
        ///数量
        /// </summary>
        public Int32? buyerCount { get; set; }
        /// <summary>
        ///备注
        /// </summary>
        public String buyerContext { get; set; }
        /// <summary>
        ///供应商Id
        /// </summary>
        public Int32? producerId { get; set; }
        /// <summary>
        ///供应商名称
        /// </summary>
        public String producerIdName { get; set; }
        /// <summary>
        ///供应商名称
        /// </summary>
        public String producerName { get; set; }
        /// <summary>
        ///颜色
        /// </summary>
        public String Color { get; set; }

    }
}