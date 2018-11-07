using Common.Result;
using DbOpertion.Function;
using DbOpertion.Models;
using Newtonsoft.Json;
using SLSM.DBOpertion.Function;
using SLSM.DBOpertion.Model.Extend.Request.CommodityList;
using SLSM.DBOpertion.Model.Extend.Response.CommodityRes;
using SLSM.DBOpertion.Model.Extend.Response.GradeRes;
using SLSM.MoblieWeb.Common.BaseController;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace SLSM.Web.Controllers.PageController
{
    public class CommodityListController : BaseMvcMasterController
    {
        // GET: CommodityList
        public ActionResult Index(CommodityListReq req)
        {
            var gradeId = req.gradeId;
            var g = GradeFunc.Instance.GetAllGradeRes(gradeId);
            var IsMoreInfo = Request.QueryString["IsMoreInfo"] != null ? Request.QueryString["IsMoreInfo"].ToString() : "";
            //用于侧边栏
            ViewBag.grade = g;
            var gradeSingle = GradeFunc.Instance.GetAllGradeResSingle(gradeId);
            var commList = CommodityFunc.Instance.GetAllCommList();
            if (gradeSingle == null)
            {
                g = GradeFunc.Instance.GetAllScenceRes(gradeId);
                gradeSingle = GradeFunc.Instance.GetAllScenceResSingle(gradeId);
                var tempG = GradeFunc.Instance.GetBranchGradeRes(g, gradeId);
                ViewBag.gradeSingle = gradeSingle;
                ViewBag.listCommView = commList.Where(p => p.ScenceIds.Contains($",{gradeId}|")).ToList();
                ViewBag.gradeId = gradeId;
                ViewBag.gradeInfo = "scence";
            }
            else
            {
                ViewBag.gradeSingle = gradeSingle;
                var Ids = CommodityFunc.Instance.GetGradeIdsByGradeRes(GradeFunc.Instance.GetBranchGradeRes(g, gradeId));
                ViewBag.listCommView = commList.Where(p => Ids.Contains(p.GradeId.Value)).ToList();
                ViewBag.gradeId = gradeId;
                ViewBag.gradeInfo = "grade";
            }
            if (IsMoreInfo.ToLower() == "true")
            {
                return View();
            }
            else
            {
                return View("GradeType");
            }
            #region 暂时废弃代码
            //List<Commodity_Stageprice_View> listComm2 = new List<Commodity_Stageprice_View>();
            //var priceCount = new List<CommPrice_Amount_CommIds>();
            //var starsCount = new List<CommStarsCount>();
            //var salesCount = new List<CommSalesCount>();
            //List<Commodityspview> listComm = new List<Commodityspview>();
            //priceCount = CommodityFunc.Instance.GetPriceCount(listCommView);
            //starsCount = CommodityFunc.Instance.GetStarCount(listCommView);
            //salesCount = CommodityFunc.Instance.GetSalesCount(listCommView);
            //var listColor = CommodityFunc.Instance.GetColorCount(listCommView);
            //var threeGrade = GradeFunc.Instance.GetThreeGrade(g, gradeId);
            //ViewBag.threeGrade = threeGrade;

            //ViewBag.priceCount = priceCount;
            //ViewBag.starsCount = starsCount;
            //ViewBag.salesCount = salesCount;
            //ViewBag.listColor = listColor; 

            #endregion

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        public ActionResult Search(CommodityListReq req)
        {
            var text = req.sText;
            var commList = CommodityFunc.Instance.GetAllCommList();
            var listCommView = commList.Where(p => p.Name.Contains(text) || (p.Content != null && p.ProductNo.Contains(text)) || (p.Introduce != null && p.Introduce.Contains(text)) || (p.ProductNo != null && p.ProductNo.Contains(text))).ToList();
            ViewBag.text = text;
            ViewBag.listCommView = listCommView;
            #region 暂时废弃代码
            //var listComm = new List<Commodity_Stageprice_View>();
            //var priceCount = CommodityFunc.Instance.GetPriceCount(listCommView);
            //var starsCount = CommodityFunc.Instance.GetStarCount(listCommView);
            //var salesCount = CommodityFunc.Instance.GetSalesCount(listCommView);
            //var listColor = CommodityFunc.Instance.GetColorCount(listCommView);
            ////价格
            //ViewBag.priceCount = priceCount;          
            ////评价
            //ViewBag.starsCount = starsCount;
            ////销量
            //ViewBag.salesCount = salesCount;
            //ViewBag.listColor = listColor; 
            #endregion
            return View();
        }




        //[HttpPost]
        //public string GetHotGrade()
        //{
        //    var list = GradeFunc.Instance.GetHotGrade();
        //    ResultJson<GradeId_Name_Img> r = new ResultJson<GradeId_Name_Img>();
        //    r.HttpCode = 200;
        //    r.ListData = list;
        //    r.Message = "";
        //    return JsonConvert.SerializeObject(r);
        //}

        //[HttpPost]
        //public string GetGrade1()
        //{
        //    var list = GradeFunc.Instance.GetGrade12();
        //    ResultJson<GradeRes> r = new ResultJson<GradeRes>();

        //    r.HttpCode = 200;
        //    r.Message = "";
        //    r.ListData = list;
        //    //}
        //    return JsonConvert.SerializeObject(r);
        //}
    }
}