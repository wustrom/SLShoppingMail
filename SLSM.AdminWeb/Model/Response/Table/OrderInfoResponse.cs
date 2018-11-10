using DbOpertion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SLSM.AdminWeb.Model.Response.Table
{
    public class OrderInfoResponse
    {
        public OrderInfoResponse(Order_Allinfo order_Allinfo, List<Tuple<string, string>> payList, List<Tuple<string, string>> statusList)
        {
            //订单Id
            this.Id = order_Allinfo.Id;
            //总价格
            this.TotalPrice = order_Allinfo.TotalPrice;
            //支付方式
            if (order_Allinfo.PayType != null)
            {
                var payTuple = payList.Where(p => p.Item1 == order_Allinfo.PayType.Value.ToString()).FirstOrDefault();
                this.PayType = payTuple == null ? "" : payTuple.Item2;
            }
            else
            {
                this.PayType = "暂时未支付！";
            }
            //状态
            if (order_Allinfo.Status != null)
            {
                var statusTuple = statusList.Where(p => p.Item1 == order_Allinfo.Status.Value.ToString()).FirstOrDefault();
                if (statusTuple != null)
                {
                    this.Status = statusTuple.Item2;
                }
                else
                {
                    this.Status = "暂无状态！";
                }

            }
            else
            {
                this.Status = "暂无状态！";
            }
            //订单编号
            this.OrderNo = order_Allinfo.OrderNo == null ? "暂无订单！" : order_Allinfo.OrderNo;
            //下单时间
            this.OrderTime = order_Allinfo.OrderTime == null ? "暂无下单时间" : order_Allinfo.OrderTime.Value.ToString("yyyy-MM-dd HH:mm");
            //订单类型
            this.OrderType = order_Allinfo.OrderType == 1 ? "网页订单" : "手机订单";
            //用户名称
            this.Name = order_Allinfo.Name == null ? (order_Allinfo.AdminName == null ? "" : order_Allinfo.AdminName) : "";
            //购买人姓名
            this.BuyName = order_Allinfo.BuyName;
            //地址区域
            if (order_Allinfo.Address != null)
            {
                this.AddrArea = order_Allinfo.Address;
            }
            else if (order_Allinfo.AddrArea != null && order_Allinfo.AddrDetail != null)
            {
                var arrayList = order_Allinfo.AddrArea.Split(',');
                foreach (var item in arrayList)
                {
                    this.AddrArea += item;
                }
                this.AddrArea += order_Allinfo.AddrDetail;
            }

            this.ToErp = order_Allinfo.ToErp == true ? true : false;
        }
        /// <summary>
        /// 订单Id
        /// </summary>
        public Int32 Id { get; set; }
        /// <summary>
        /// 支付方式
        /// </summary>
        public string PayType { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        public string Status { get; set; }
        /// <summary>
        /// 订单编号
        /// </summary>
        public string OrderNo { get; set; }
        /// <summary>
        /// 货号
        /// </summary>
        public string MaterName { get; set; }
        /// <summary>
        /// 数量
        /// </summary>
        public string ProductNum { get; set; }
        /// <summary>
        /// 总价格
        /// </summary>
        public Decimal? TotalPrice { get; set; }
        /// <summary>
        /// 下单时间
        /// </summary>
        public string OrderTime { get; set; }
        /// <summary>
        /// 订单类型
        /// </summary>
        public string OrderType { get; set; }
        /// <summary>
        /// 用户名称
        /// </summary>
        public String Name { get; set; }
        /// <summary>
        /// 购买人姓名
        /// </summary>
        public string BuyName { get; set; }
        /// <summary>
        /// 地址区域
        /// </summary>
        public String AddrArea { get; set; }
        /// <summary>
        /// 地址明细
        /// </summary>
        public String AddrDetail { get; set; }
        /// <summary>
        /// 是否是Erp
        /// </summary>
        public bool ToErp { get; set; }
        /// <summary>
        /// 是否用户确认
        /// </summary>
        public bool UserSure { get; set; }
        /// <summary>
        /// 设计师提交
        /// </summary>
        public bool DesignCommit { get; set; }
    }
}