using Common.Extend;
using Common.Helper;
using DbOpertion.Function;
using DbOpertion.Models;
using SLSM.ErpWeb.App_Start;
using SLSM.ErpWeb.Common.BaseController;
using System.Web.Mvc;

namespace SLSM.ErpWeb.Controllers.PageController
{
    public class InspectionController : BaseMvcMasterController
    {

        #region 原材料品检
        /// <summary>
        /// 原材料品检
        /// </summary>
        /// <returns></returns>
        [UserAuthorize]
        public ActionResult Raw_InspectionInfo()
        {
            return View();
        }
        /// <summary>
        /// 原材料品检详情
        /// </summary>
        /// <returns></returns>
        public ActionResult Raw_InspectionDetailed()
        {
            var Id = HttpContext.Request.QueryString["Id"].ParseInt();
            //送货单
            var PrintText = HttpContext.Request.QueryString["PrintText"].ParseInt();
            var Buyers = BuyerFunc.Instance.SelectBuyerById(Id.Value);
            var BuyerDetaileds = BuyerFunc.Instance.SelectBuyerDetailed(Id.Value);
            var Deliver = DeliverFunc.Instance.SelectByModel(new Deliver { buyerId = Id });
            if (Buyers != null || BuyerDetaileds != null)
            {
                ViewBag.PrintText = PrintText;
                ViewBag.BuyersInfo = Buyers;
                ViewBag.BuyersFullInfo = BuyerDetaileds;
                ViewBag.Deliver = Deliver;
                return View();
            }
            else
            {
                //跳转到错误页面
                return View();
            }
        }
        /// <summary>
        /// 品检不合格
        /// </summary>
        /// <returns></returns>
        public ActionResult Raw_InspectionNoQualified()
        {
            var Id = HttpContext.Request.QueryString["Id"].ParseInt();
            if (Id != null)
            {
                ViewBag.Id = Id;
            }
            return View();
        }
        #endregion

        #region 成品品检
        /// <summary>
        /// 成品品检
        /// </summary>
        [UserAuthorize]
        public ActionResult Product_InspectionInfo()
        {
            var ProductText = HttpContext.Request.QueryString["Text"].ParseInt();

            ViewBag.ProductText = ProductText;
            return View();
        }
        #endregion
    }
}