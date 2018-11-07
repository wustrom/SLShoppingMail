using Common.Extend;
using Common.Helper;
using DbOpertion.Function;
using DbOpertion.Models;
using SLSM.DBOpertion.Function;
using SLSM.DBOpertion.Model.Extend.Request.CommodityList;
using SLSM.DBOpertion.Model.Extend.Response.CommodityRes;
using SLSM.Web.Common.BaseController;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace SLSM.MoblieWeb.Controllers.PageController
{
    /// <summary>
    /// 商品详情页
    /// </summary>
    public class CommodityController : BaseMvcMasterController
    {
        /// <summary>
        /// 商品首页
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            var CommodityId = Request.QueryString["CommodityId"].ParseInt();
            if (CommodityId != null)
            {
                var result = DiyFunc.Instance.SelectAllInfo(CommodityId.Value);
                if (result.Item1 != null)
                {
                    var ColorArray = result.Item1.Color != null ? result.Item1.Color.Split(',').ToList() : new List<string>();
                    var colorList = ColorinfoFunc.Instance.GetColorListBase();
                    List<Colorinfo> thisColorList = new List<Colorinfo>();
                    foreach (var item in colorList)
                    {
                        var colorItem = ColorArray.Where(p => p == item.Id.ToString()).FirstOrDefault();
                        if (colorItem != null)
                        {
                            thisColorList.Add(item);
                        }
                    }
                    ViewBag.TupleList = thisColorList;
                    //var color = ColorFunc.Instance.GetColorInfo(result.Item1.Color);                    
                    #region MemCache获取用户信息
                    var userGuid = CookieOper.Instance.GetUserGuid();
                    var user = MemCacheHelper2.Instance.Cache.GetModel<User>("UserGuID_" + userGuid);
                    if (user != null)
                    {
                        var IsLike = UserLikeFunc.Instance.UserLikeCount(user.Id, CommodityId.Value);
                        ViewBag.IsLike = IsLike;
                        ViewBag.UserInfo = user;
                    }
                    #endregion
                    ViewBag.Commodity = result.Item1;
                    ViewBag.Material = Raw_MaterialsFunc.Instance.SelectByModel(new Raw_Materials { Id = result.Item1.MaterialId.Value }).FirstOrDefault();
                    ViewBag.StagePriceList = result.Item2;
                    //ViewBag.TupleList = color;
                    #region 废弃代码
                    //var List_GradeAttr = GradeFunc.Instance.GradeAttrInfo(result.Item1.GradeId.Value);
                    //ViewBag.GradeAttr = List_GradeAttr;
                    //var evalInfoCount = EvaluateFunc.Instance.SelectByCommodityIdCount(CommodityId.Value);
                    //ViewBag.Count = evalInfoCount;
                    //var list_EvalInfo = EvaluateFunc.Instance.SelectByCommodityId("EvaluateId", true, CommodityId.Value, 0, 5);
                    //ViewBag.EvalList = list_EvalInfo;
                    //var LikeCount = UserLikeFunc.Instance.UserLikeCount(CommodityId.Value);
                    //ViewBag.LikeCount = LikeCount;
                    //ViewBag.AllImage = Carousel_ImageFunc.Instance.SelectAllImages().Item1; 
                    #endregion
                    #region 购物车信息
                    var ShopCartId = Request.QueryString["ShopCartId"].ParseInt();
                    if (ShopCartId != null)
                    {
                        var shopCart = ShopCartFunc.Instance.SelectShopCart(new Shopcart { Id = ShopCartId.Value });
                        if (shopCart.CommodityId == CommodityId)
                        {
                            ViewBag.ShopCart = shopCart;
                        }
                    }
                    #endregion
                    #region 库存信息
                    //库存信息
                    var Materials_StockList = result.Item1.MaterialId != null ? Materials_Stock_ViewFunc.Instance.SelectByModel(new Materials_Stock_View { Raw_materialsId = result.Item1.MaterialId }) : new List<Materials_Stock_View>();
                    ViewBag.StockList = Materials_StockList;
                    ViewBag.TechnologyList = TechnologyFunc.Instance.SelectByModel(new Technology { IsDelete = true });
                    #endregion
                    return View();
                }
                else
                {
                    return View("Index");
                }
            }
            else
            {
                return View("Index");
            }
        }
    }
}