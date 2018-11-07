using DbOpertion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SLSM.Web.Models.Response.Order
{
    /// <summary>
    /// 订单明细设计应答
    /// </summary>
    public class OrderDetailDesignResponse
    {
        public OrderDetailDesignResponse(Orderdetaildesign design,string Printing)
        {
            this.Id = design.Id;
            this.OrderDetailId = design.OrderDetailId;
            this.Content = design.Content;
            this.PrintingPosition = design.PrintingPosition;
            this.Printing = Printing;
            this.Image = design.Image;
        }
        public OrderDetailDesignResponse()
        {
            
        }
        /// <summary>
        /// 订单设计Id
        /// </summary>
        public Int32 Id { get; set; }
        /// <summary>
        /// 订单明细Id
        /// </summary>
        public Int32? OrderDetailId { get; set; }
        /// <summary>
        /// 内容
        /// </summary>
        public String Content { get; set; }
        /// <summary>
        /// 方位
        /// </summary>
        public String PrintingPosition { get; set; }
        /// <summary>
        /// 方位
        /// </summary>
        public String Printing { get; set; }
        /// <summary>
        /// 图片
        /// </summary>
        public string Image { get; set; }
        /// <summary>
        /// 主图片
        /// </summary>
        public string MainImage { get; set; }
        /// <summary>
        /// 主图片
        /// </summary>
        public string DesignImage { get; set; }
    }
}