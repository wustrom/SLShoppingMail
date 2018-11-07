using Common.Extend;
using DbOpertion.Models;
using SLSM.DBOpertion.Model.Extend.Response.CommodityRes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SLSM.MoblieWeb.Models.Response.Order
{
    /// <summary>
    /// 订单应答
    /// </summary>
    public class OrderInfoResponse
    {
        /// <summary>
        /// 订单应答构造方法
        /// </summary>
        public OrderInfoResponse(Order_Info order, List<Tuple<string, string>> tuples)
        {
            //订单ID
            this.Id = order.Id;
            //用户id
            this.UserId = order.UserId;
            //收货人信息id
            this.AddressId = order.AddressId;
            //总价
            this.TotalPrice = order.TotalPrice;
            //支付方式
            this.PayType = order.PayType;
            //订单状态
            this.Freight = order.Freight == null ? "0" : order.Freight;
            //状态
            if (order.Status != null)
            {
                var tuple = tuples.Where(p => p.Item1 == order.Status.ToString()).FirstOrDefault();
                this.Status = tuple == null ? "店家暂时没有处理" : tuple.Item2;
            }

            //订单编号
            this.OrderNo = order.OrderNo;
            //订单时间
            this.OrderTime = order.OrderTime.Value.ToString("yyyy-MM-dd hh:mm:ss");
            //购买人名称
            this.BuyName = order.BuyName;
            //购买人电话
            this.Phone = order.Phone;
            //快递公司
            this.ExpressCompany = order.ExpressCompany;
            //快递No
            this.ExpressNo = order.ExpressNo;
            //地址详情
            this.Address = order.Address;
            //是否是erp订单
            this.IsErp = order.ToErp;
        }
        /// <summary>
        /// 订单ID
        /// </summary>
        public Int32 Id { get; set; }
        /// <summary>
        /// 用户Id
        /// </summary>
        public Int32? UserId { get; set; }
        /// <summary>
        ///收货人信息id
        /// </summary>
        public Int32? AddressId { get; set; }

        /// <summary>
        ///总价
        /// </summary>
        public Decimal? TotalPrice { get; set; }
        /// <summary>
        ///支付方式
        /// </summary>
        public Int32? PayType { get; set; }
        /// <summary>
        ///订单状态
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        ///订单编号
        /// </summary>
        public string OrderNo { get; set; }
        /// <summary>
        ///订单时间
        /// </summary>
        public string OrderTime { get; set; }
        /// <summary>
        /// 购买人名称
        /// </summary>
        public string BuyName { get; set; }
        /// <summary>
        /// 购买人电话
        /// </summary>
        public string Phone { get; set; }
        /// <summary>
        /// 快递公司
        /// </summary>
        public String ExpressCompany { get; set; }
        /// <summary>
        /// 快递No
        /// </summary>
        public String ExpressNo { get; set; }
        /// <summary>
        /// 发票
        /// </summary>
        public String Invoice { get; set; }
        /// <summary>
        /// 运费
        /// </summary>
        public String Freight { get; set; }
        /// <summary>
        /// 地址
        /// </summary>
        public String Address { get; set; }
        /// <summary>
        /// 是否是Erp订单
        /// </summary>
        public bool? IsErp { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<OrderDetailResponse> ListDetail { get; set; }
    }
}
