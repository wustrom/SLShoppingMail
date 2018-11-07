using Common.Extend;
using Common.Helper;
using DbOpertion.Function;
using DbOpertion.Models;
using SLSM.DBOpertion.Function;
using SLSM.MoblieWeb.Common.BaseController;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SLSM.Web.Controllers.PageController
{
    /// <summary>
    /// Diy控制器
    /// </summary>
    public class DiyController : BaseMvcMasterController
    {
        /// <summary>
        /// 首页
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
                    ViewBag.Material = Raw_MaterialsFunc.Instance.SelectById(result.Item1.MaterialId.Value);
                    #region 颜色列表
                    //旧
                    var color = ColorFunc.Instance.GetColorInfo(result.Item1.Color);
                    ViewBag.TupleList = color;
                    //新
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
                    ViewBag.thisColorList = thisColorList;
                    #endregion

                    #region 分类属性
                    var List_GradeAttr = GradeFunc.Instance.GradeAttrInfo(result.Item1.GradeId.Value);
                    ViewBag.GradeAttr = List_GradeAttr;
                    #endregion

                    #region 商品信息处理
                    var comm = CommodityFunc.Instance.SelectCommInfo(new Commodity { Id = CommodityId.Value }).FirstOrDefault();
                    comm.ClickCount = comm.ClickCount == null ? 1 : comm.ClickCount + 1;
                    CommodityFunc.Instance.UpdateCommodity(comm);
                    #endregion
                    ViewBag.TechnologyList = TechnologyFunc.Instance.SelectByModel(new Technology { IsDelete = true });
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
                    ViewBag.StagePriceList = result.Item2;

                    #region 废弃代码
                    //var list_EvalInfo = EvaluateFunc.Instance.SelectByCommodityId("EvaluateId", true, CommodityId.Value, 0, 5);
                    //var evalInfoCount = EvaluateFunc.Instance.SelectByCommodityIdCount(CommodityId.Value);
                    //var LikeCount = UserLikeFunc.Instance.UserLikeCount(CommodityId.Value);

                    //ViewBag.Count = evalInfoCount;
                    //ViewBag.EvalList = list_EvalInfo;
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

                    return View();
                }
                else
                {
                    return View("NoMoreThing");
                }
            }
            else
            {
                return View("NoMoreThing");
            }

        }

        /// <summary>
        /// 首页
        /// </summary>
        /// <returns></returns>
        public ActionResult NoMoreThing()
        {
            return View();
        }
    }
}