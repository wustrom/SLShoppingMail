using Common.Extend;
using DbOpertion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SLSM.ErpWeb.Model.Response.Table
{
    public class Produtions
    {
        public Produtions(Production_Orderdetail_View pro)
        {
            //生产管理表Id
            this.Id = pro.Id;
            //订单编号
            this.OrderNo = pro.OrderNo;
            //时间
            this.OrderTime = pro.OrderTime.ParseString();
            //设计师状态
            this.DesignerStatus = pro.DesignerStatus;
            //生产状态
            this.ProductionStatus = pro.ProductionStatus;
            //订单状态
            this.OrderStatus = pro.OrderStatus == "设计已处理" ? "已处理" : pro.OrderStatus;
            //用户名
            this.userName = pro.userName;
            //电话
            this.Phone = pro.Phone;
            //地址
            this.CompanyAddr = pro.CompanyAddr;
            //产品名
            this.commodityName = pro.commodityName == null ? "暂无此产品" : pro.commodityName;
            //产品编号
            this.commodityId = pro.ProductNo == null ? "暂无编号" : pro.ProductNo;
            //数量
            this.Amount = pro.Amount;
            //金额
            this.PayMoney = pro.PayMoney;
            //交货时间
            this.deliveryTime = pro.deliveryTime.ParseString();
            //订单类型
            this.OrderType = pro.OrderType;
            //品检状态
            this.InspectionStatus = pro.InspectionStatus;
            //退回原因
            this.ReturnContext = pro.ReturnContext;
            //退回次数
            this.ReturnCount = pro.ReturnCount;
            //客服反馈
            this.ServiceContext = pro.ServiceContext;
            //生产注意事项
            this.InspectionContext = pro.InspectionContext;
        }
        /// <summary>
        ///生产管理表Id
        /// </summary>
        public Int32 Id { get; set; }
        /// <summary>
        ///订单编号
        /// </summary>
        public String OrderNo { get; set; }
        /// <summary>
        ///时间
        /// </summary>
        public string OrderTime { get; set; }
        /// <summary>
        ///生产状态
        /// </summary>
        public String DesignerStatus { get; set; }
        /// <summary>
        ///生产状态
        /// </summary>
        public String ProductionStatus { get; set; }
        /// <summary>
        ///订单状态
        /// </summary>
        public String OrderStatus { get; set; }
        /// <summary>
        ///用户名
        /// </summary>
        public String userName { get; set; }
        /// <summary>
        ///电话
        /// </summary>
        public String Phone { get; set; }
        /// <summary>
        ///地址
        /// </summary>
        public String CompanyAddr { get; set; }
        /// <summary>
        ///产品名
        /// </summary>
        public String commodityName { get; set; }
        /// <summary>
        ///产品编号
        /// </summary>
        public string commodityId { get; set; }
        /// <summary>
        ///数量
        /// </summary>
        public Int32? Amount { get; set; }
        /// <summary>
        ///金额
        /// </summary>
        public Decimal? PayMoney { get; set; }
        /// <summary>
        ///交货时间
        /// </summary>
        public string deliveryTime { get; set; }
        /// <summary>
        ///订单类型
        /// </summary>
        public String OrderType { get; set; }
        /// <summary>
        ///品检状态
        /// </summary>
        public String InspectionStatus { get; set; }
        /// <summary>
        /// 退回原因
        /// </summary>
        public Int32? ReturnCount { get; set; }
        /// <summary>
        ///退回次数
        /// </summary>
        public String ReturnContext { get; set; }
        /// <summary>
        ///客服反馈
        /// </summary>
        public String ServiceContext { get; set; }
        /// <summary>
        ///生产注意事项
        /// </summary>
        public String InspectionContext { get; set; }
    }
}