using Common.Filter.WebApi;
using Common.Result;
using DbOpertion.Function;
using DbOpertion.Models;
using SLSM.DBOpertion.Function;
using SLSM.MoblieWeb.Models.Resquest.ShopCart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SLSM.MoblieWeb.Controllers.AjaxController
{
    /// <summary>
    /// 地址控制器
    /// </summary>
    public class ShopCartController : BaseApiController
    {
        /// <summary>
        /// 购物车价格
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ResultJson ChangeAmount(ShopCartAmountRequest request)
        {
            ResultJson result = new ResultJson();
            var shopcart = ShopCartFunc.Instance.SelectShopCart(new Shopcart { Id = request.ShopCartId });
            if (shopcart == null)
            {
                result.HttpCode = 300;
                result.Message = "购物车并没有此产品！";
            }
            else
            {
                shopcart.Amount = request.Amount;
                var CommodityPriceList = CommodityPriceFunc.Instance.SelectByIds(new List<int?> { shopcart.CommodityId });
                var Price = CommodityPriceList.Where(p => p.StageAmount < request.Amount).OrderByDescending(p => p.StageAmount).FirstOrDefault();
                if (ShopCartFunc.Instance.UpdateShopCart(shopcart))
                {
                    result.HttpCode = 200;
                    result.Message = (shopcart.Amount * Price.StagePrice).ToString();
                }
                else
                {
                    result.HttpCode = 300;
                    result.Message = "更新购物车数据！";
                }
            }
            return result;
        }

        /// <summary>
        /// 购物车价格
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ResultJson DeleteShopCart(ShopCartAmountRequest request)
        {
            ResultJson result = new ResultJson();
            if (ShopCartFunc.Instance.DeleteShopCart(request.ShopCartId))
            {
                result.HttpCode = 200;
                result.Message = "删除成功！";
            }
            else
            {
                result.HttpCode = 300;
                result.Message = "删除不成功！";
            }
            return result;
        }
    }
}