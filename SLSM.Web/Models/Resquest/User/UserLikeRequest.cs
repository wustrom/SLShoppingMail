using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SLSM.Web.Models.Resquest.User
{
    /// <summary>
    /// 用户收藏商品请求
    /// </summary>
    public class UserLikeRequest
    {
        /// <summary>
        /// 商品Id
        /// </summary>
        public int CommodityId { get; set; }

        /// <summary>
        /// 是否收藏
        /// </summary>
        public bool IsLike { get; set; }
    }
}