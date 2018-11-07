using DbOpertion.Function;
using SLSM.AdminWeb.Common.BaseController;
using SLSM.AdminWeb.Model.Request.Commdity;
using SLSM.DBOpertion.Function;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SLSM.AdminWeb.Controllers.PageController
{
    /// <summary>
    /// 商品页面控制器
    /// </summary>
    public class CommodityController : BaseMvcMasterController
    {
        /// <summary>
        /// 商品页面首页
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 商品页面详情
        /// </summary>
        /// <returns></returns>
        public ActionResult Detail(IdRequest request)
        {
            ViewBag.colorList = ColorFunc.Instance.GetAllColorInfo();
            ViewBag.Grade = GradeFunc.Instance.GetAllGrade();
            ViewBag.Scence = GradeFunc.Instance.SelectAllScence();
            ViewBag.Materials = Raw_MaterialsFunc.Instance.SelectByModel(new DbOpertion.Models.Raw_Materials { IsDelete = false });
            if (request != null && request.Id != 0)
            {
                ViewBag.Commdity = CommodityFunc.Instance.SelectCommodityById(request.Id);
                ViewBag.PriceList = CommodityPriceFunc.Instance.SelectByIds(new List<int?> { request.Id });
                ViewBag.CommdityList = CommodityFunc.Instance.GetAllCommList();
            }
            return View();
        }
    }
}