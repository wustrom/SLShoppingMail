using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SLSM.AdminWeb.Model.Request.UpImg
{
    /// <summary>
    /// 更新购物车请求
    /// </summary>
    public class UpdateCartInfoRequest
    {
        /// <summary>
        /// 商品Id
        /// </summary>
        public int CommodityId { get; set; }
        /// <summary>
        /// 用户Guid
        /// </summary>
        public string userGuid { get; set; }
        /// <summary>
        /// 数目
        /// </summary>
        public int Amount { get; set; }
        /// <summary>
        /// 颜色
        /// </summary>
        public string Color { get; set; }
        /// <summary>
        /// 输出方式
        /// </summary>
        public string PrintingMethod { get; set; }
        /// <summary>
        /// 属性
        /// </summary>
        public string Attr { get; set; }

        /// <summary>
        /// 图片列表
        /// </summary>
        public string ListImg { get; set; }

        /// <summary>
        /// 购物车ID
        /// </summary>
        public int ShopCartId { get; set; }
        /// <summary>
        /// 订单类型
        /// </summary>
        public string PayType { get; set; }
    }
}