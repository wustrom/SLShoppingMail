using DbOpertion.Function;
using DbOpertion.Models;
using SLSM.DBOpertion.Function;
using SLSM.DBOpertion.Model.Extend.Request.CommodityList;
using SLSM.DBOpertion.Model.Extend.Response.CommodityRes;
using SLSM.Web.Common.BaseController;
using System.Collections.Generic;
using System.Web.Mvc;

namespace SLSM.MoblieWeb.Controllers.PageController
{
    public class CommodityListController : BaseMvcMasterController
    {
        /// <summary>
        /// 主页
        /// </summary>
        /// <param name="req">请求</param>
        /// <returns></returns>
        public ActionResult Index(CommodityListReq req)
        {
            var gradeId = req.gradeId;
            var g = GradeFunc.Instance.GetAllGradeRes(gradeId);
            if (g == null)
            {
                g = GradeFunc.Instance.GetAllScenceRes(gradeId);
                ViewBag.gradeInfo = "scence";
            }
            //用于侧边栏
            ViewBag.grade = g;

            List<Commodityspview> listComm = new List<Commodityspview>();
            var tempG = GradeFunc.Instance.GetBranchGradeRes(g, gradeId);
            var listCommView = CommodityFunc.Instance.GetListCommViewByGrade(tempG);
            var threeGrade = GradeFunc.Instance.GetThreeGrade(g, gradeId);
            ViewBag.threeGrade = threeGrade;
            ViewBag.gradeId = gradeId;
            ViewBag.listCommView = listCommView;
            #region 废弃代码
            //var priceCount = new List<CommPrice_Amount_CommIds>();
            //var starsCount = new List<CommStarsCount>();
            //var salesCount = new List<CommSalesCount>();
            //priceCount = CommodityFunc.Instance.GetPriceCount(listCommView);
            //starsCount = CommodityFunc.Instance.GetStarCount(listCommView);
            //salesCount = CommodityFunc.Instance.GetSalesCount(listCommView);
            //ViewBag.priceCount = priceCount;
            //ViewBag.starsCount = starsCount;
            //ViewBag.salesCount = salesCount; 
            //var listColor = CommodityFunc.Instance.GetColorCount(listCommView);
            //ViewBag.listColor = listColor;
            //ViewBag.isCommList = 1;
            #endregion

            return View();
        }

        /// <summary>
        /// 搜索详情
        /// </summary>
        /// <param name="req">请求</param>
        /// <returns></returns>
        public ActionResult Search(CommodityListReq req)
        {
            var text = req.sText;

            var listComm = new List<Commodity_Stageprice_View>();

            var listCommView = CommodityFunc.Instance.GetViewBySearch(text, req.PageNo == null ? 1 : req.PageNo);
            var Count = CommodityFunc.Instance.GetViewBySearchCount(text);
            ViewBag.Count = Count;
            ViewBag.NowPage = req.PageNo == null ? 1 : req.PageNo;
            ViewBag.PageSum = Count % 15 == 0 ? (Count / 15) : (Count / 15 + 1);
            ViewBag.ListComm = listCommView;
            #region 废弃代码
            //var priceCount = CommodityFunc.Instance.GetPriceCount(listCommView);
            //var starsCount = CommodityFunc.Instance.GetStarCount(listCommView);
            //var salesCount = CommodityFunc.Instance.GetSalesCount(listCommView);
            //var listColor = CommodityFunc.Instance.GetColorCount(listCommView);
            //ViewBag.priceCount = priceCount;
            //ViewBag.starsCount = starsCount;
            //ViewBag.salesCount = salesCount;
            //ViewBag.listColor = listColor; 
            #endregion

            ViewBag.text = text;
            ViewBag.isCommList = 1;
            return View();
        }


        /// <summary>
        /// 主页
        /// </summary>
        /// <param name="req">请求</param>
        /// <returns></returns>
        public ActionResult GradeInfo(CommodityListReq req)
        {
            var gradeId = req.gradeId;
            var g = GradeFunc.Instance.GetAllGradeRes(gradeId);
            if (g == null)
            {
                g = GradeFunc.Instance.GetAllScenceRes(gradeId);
                ViewBag.gradeInfo = "scence";
            }
            //用于侧边栏
            ViewBag.grade = g;

            List<Commodityspview> listComm = new List<Commodityspview>();
            var tempG = GradeFunc.Instance.GetBranchGradeRes(g, gradeId);
            var listCommView = CommodityFunc.Instance.GetListCommViewByGrade(tempG);
            var threeGrade = GradeFunc.Instance.GetThreeGrade(g, gradeId);
            ViewBag.threeGrade = threeGrade;
            ViewBag.gradeId = gradeId;
            ViewBag.listCommView = listCommView;
            return View();
        }
    }
}