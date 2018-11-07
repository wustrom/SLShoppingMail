using Common.Extend;
using DbOpertion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SLSM.ErpWeb.Model.Response.Table
{
    public class Receives
    {
        public Receives(Receive_Order_View res)
        {
            this.Id = res.Id;
            //生产管理单Id
            this.ProductionId = res.ProductionId;
            //状态
            this.receiveStatus = res.receiveStatus;
            //出库时间
            this.receiveOutTime = res.receiveOutTime.ParseString();
            //领料时间
            this.receiveTime = res.receiveTime.ParseString();
            //备注
            this.receiveContext = res.receiveContext;
            //订单Id
            this.order_detailId = res.ProductionNo;
            //数量
            this.Amount = res.Amount;
            //订单编号
            this.OrderNo = res.OrderNo;

        }
        /// <summary>
        ///
        /// </summary>
        public Int32 Id { get; set; }
        /// <summary>
        ///生产管理单Id
        /// </summary>
        public Int32? ProductionId { get; set; }
        /// <summary>
        ///状态
        /// </summary>
        public String receiveStatus { get; set; }
        /// <summary>
        ///出库时间
        /// </summary>
        public string receiveOutTime { get; set; }
        /// <summary>
        ///领料时间
        /// </summary>
        public string receiveTime { get; set; }
        /// <summary>
        ///备注
        /// </summary>
        public String receiveContext { get; set; }
        /// <summary>
        ///订单Id
        /// </summary>
        public string order_detailId { get; set; }
        /// <summary>
        ///数量
        /// </summary>
        public Int32? Amount { get; set; }
        /// <summary>
        ///订单No
        /// </summary>
        public String OrderNo { get; set; }





        // //领料详情单Id
        //this.Id = res.Id;
        ////领料单Id
        //this.receiveId = res.receiveId;
        ////额外领料
        //this.additionalCount = res.additionalCount;
        ////是否额外领料
        //this.Isadditional = res.Isadditional;
        ////状态
        //this.receiveStatus = res.receiveStatus;
        ////出库时间
        //this.receiveOutTime = res.receiveOutTime;
        ////领料时间
        //this.receiveTime = res.receiveTime;
        ////备注
        //this.receiveContext = res.receiveContext;
        ////商品Id
        //this.CommodityId = res.CommodityId;
        ////名称
        //this.ChinaProductName = res.ChinaProductName;
        ////单位
        //this.ChinaUnit = res.ChinaUnit;
        ////型号
        //this.Specification = res.Specification;
        ////原材料Id
        //this.MaterialId = res.MaterialId;
        ////订单数量
        //this.Amount = res.Amount;

        ///// <summary>
        /////领料详情单Id
        ///// </summary>
        //public Int32 Id { get; set; }
        ///// <summary>
        /////领料单Id
        ///// </summary>
        //public Int32? receiveId { get; set; }
        ///// <summary>
        /////额外数量
        ///// </summary>
        //public Int32? additionalCount { get; set; }
        ///// <summary>
        /////是否为额外领料
        ///// </summary>
        //public Boolean? Isadditional { get; set; }
        ///// <summary>
        /////生产管理表Id
        ///// </summary>
        //public Int32? productionId { get; set; }
        ///// <summary>
        /////状态
        ///// </summary>
        //public String receiveStatus { get; set; }
        ///// <summary>
        /////出库时间
        ///// </summary>
        //public DateTime? receiveOutTime { get; set; }
        ///// <summary>
        /////领料时间
        ///// </summary>
        //public DateTime? receiveTime { get; set; }
        ///// <summary>
        /////备注
        ///// </summary>
        //public String receiveContext { get; set; }
        ///// <summary>
        /////商品Id
        ///// </summary>
        //public Int32? CommodityId { get; set; }
        ///// <summary>
        /////名称
        ///// </summary>
        //public String ChinaProductName { get; set; }
        ///// <summary>
        /////单位
        ///// </summary>
        //public String ChinaUnit { get; set; }
        ///// <summary>
        /////型号
        ///// </summary>
        //public String Specification { get; set; }
        ///// <summary>
        /////订单数量
        ///// </summary>
        //public Int32? Amount { get; set; }
        ///// <summary>
        /////原材料Id
        ///// </summary>
        //public Int32? MaterialId { get; set; }
    }
}