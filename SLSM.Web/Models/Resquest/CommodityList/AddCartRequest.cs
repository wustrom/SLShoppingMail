using System;

namespace SLSM.Web.Models.Resquest.CommodityList
{
    /// <summary>
    /// 添加购物车请求
    /// </summary>
    public class AddCartRequest
    {
        /// <summary>
        /// 商品Id
        /// </summary>
        public int commodityId { get; set; }
    }
}