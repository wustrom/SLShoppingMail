using Common.Extend;
using Common.Filter.WebApi;
using Common.Helper;
using Common.Result;
using DbOpertion.Function;
using DbOpertion.Models;
using SLSM.DBOpertion.Function;
using SLSM.Web.Models.Response.Address;
using SLSM.Web.Models.Resquest;
using SLSM.Web.Models.Resquest.ShopCart;
using SLSM.Web.Models.Resquest.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace SLSM.Web.Controllers.AjaxContoller
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
            if (request.Amount <= 0)
            {
                result.HttpCode = 300;
                result.Message = "数目不能为负数！";
                return result;
            }
            if (shopcart == null)
            {
                result.HttpCode = 300;
                result.Message = "购物车并没有此产品！";
            }
            else
            {

                shopcart.Amount = request.Amount;
                var CommodityPriceList = CommodityPriceFunc.Instance.SelectByIds(new List<int?> { shopcart.CommodityId });
                var commodity = CommodityFunc.Instance.SelectById(shopcart.CommodityId.Value);
                var rawmaterials = Raw_MaterialsFunc.Instance.SelectById(commodity.MaterialId.Value);
                #region 后面有用
                var priceArray = new List<Tuple<int?, decimal?>>();
                if (rawmaterials.SalesInfoList == null)
                {
                    foreach (var item in CommodityPriceList)
                    {
                        priceArray.Add(new Tuple<int?, decimal?>(item1: item.StageAmount, item2: item.StagePrice));
                    }
                }
                else
                {
                    var saleinfo = rawmaterials.SalesInfoList.Split(';').Where(p => !string.IsNullOrEmpty(p)).ToList();
                    foreach (var item in saleinfo)
                    {
                        var saledetailInfo = item.Split('|').Where(p => !string.IsNullOrEmpty(p)).ToList();
                        if (shopcart.PrintingMethod == "PrintFunc2")
                        {
                            priceArray.Add(new Tuple<int?, decimal?>(item1: saledetailInfo[0].ParseInt(), item2: saledetailInfo[2].ParseDecimal()));
                        }
                        else if (shopcart.PrintingMethod == "PrintFunc3")
                        {
                            priceArray.Add(new Tuple<int?, decimal?>(item1: saledetailInfo[0].ParseInt(), item2: saledetailInfo[3].ParseDecimal()));
                        }
                        else
                        {
                            priceArray.Add(new Tuple<int?, decimal?>(item1: saledetailInfo[0].ParseInt(), item2: saledetailInfo[1].ParseDecimal()));
                        }
                    }
                    var priceInfo = CommodityPriceList.Where(p => p.StageAmount == 0).FirstOrDefault();
                    if (priceInfo != null)
                    {
                        priceArray.Add(new Tuple<int?, decimal?>(item1: 0, item2: priceInfo.StagePrice));
                    }
                }
                var price = priceArray.Where(p => p.Item1 <= shopcart.Amount).OrderByDescending(p => p.Item1).FirstOrDefault();
                #endregion
                if (ShopCartFunc.Instance.UpdateShopCart(shopcart))
                {
                    result.HttpCode = 200;
                    result.Message = price.Item2.ToString();
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

