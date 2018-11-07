﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SLSM.AdminWeb.Models.Resquest.ShopCart
{
    /// <summary>
    /// 购物车数目改变请求
    /// </summary>
    public class ShopCartAmountRequest
    {
        /// <summary>
        /// 购物车Id
        /// </summary>
        public int ShopCartId { get; set; }
    }
}