using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SLSM.Web.Model.Request.UpImg
{
    public class UpdateImgCrossRequest
    {
        /// <summary>
        /// 图片已base64进行传输
        /// </summary>
        public string Pic { get; set; }
        /// <summary>
        /// 商品Id
        /// </summary>
        public int CommodityId { get; set; }
        /// <summary>
        /// 用户Guid
        /// </summary>
        public string userGuid { get; set; }
        /// <summary>
        /// 购物车Id
        /// </summary>
        public int ShopCartId { get; set; }
        /// <summary>
        /// 用户Guid
        /// </summary>
        public string Div { get; set; }
    }
}