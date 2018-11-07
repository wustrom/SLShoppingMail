using Common.Extend;
using Common.Helper;
using DbOpertion.Function;
using DbOpertion.Models;
using DbOpertion.Operation;
using SLSM.ErpWeb.App_Start;
using SLSM.ErpWeb.Common.BaseController;
using SLSM.ErpWeb.Model.Request.Warehouses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SLSM.ErpWeb.Controllers.PageController
{
    /// <summary>
    /// 原材料控制器
    /// </summary>
    public class MaterialController : BaseMvcMasterController
    {
        #region 原材料管理
        /// <summary>
        /// 原材料管理
        /// </summary>
        /// <returns></returns>
        [UserAuthorize]
        public ActionResult MaterialManger()
        {
            ViewBag.ProducerList = ProducerFunc.Instance.SelectAll();
            return View();
        }

        /// <summary>
        /// 原材料详细信息
        /// </summary>
        /// <returns></returns>
        public ActionResult MaterialDetail()
        {
            var Id = Request.QueryString["Id"].ParseInt();
            ViewBag.ColorList = ColorinfoFunc.Instance.GetColorListBase();
            ViewBag.ProducerList = ProducerFunc.Instance.SelectAll();
            ViewBag.GradeList = GradeFunc.Instance.GetAllGrade();
            ViewBag.PrintList = TechnologyFunc.Instance.SelectTechnology();
            if (Id != null)
            {
                ViewBag.Material = Raw_MaterialsFunc.Instance.SelectById(Id.Value);
                ViewBag.MyColorInfoList = Materials_ColorinfoFunc.Instance.SelectByModel(new Materials_Colorinfo { MaterialsId = Id.Value });
                ViewBag.MyProducerList = Materials_ProducerFunc.Instance.SelectByModel(new Materials_Producer { MaterialsId = Id.Value });
            }
            return View();
        }

        /// <summary>
        /// 产品采购信息
        /// </summary>
        /// <returns></returns>
        public ActionResult ProPurchase()
        {
            ViewBag.ProducerList = ProducerFunc.Instance.SelectAll();
            return View();
        }

        /// <summary>
        /// 原材料详细信息
        /// </summary>
        /// <returns></returns>
        public ActionResult BuyMaterial()
        {
            var Id = Request.QueryString["Id"].ParseInt();
            ViewBag.ProducerList = ProducerFunc.Instance.SelectAll();
            if (Id != null)
            {
                var colorInfo = Materials_ColorinfoFunc.Instance.SelectById(Id.Value);
                ViewBag.Material = Raw_MaterialsFunc.Instance.SelectById(colorInfo.MaterialsId.Value);

                ViewBag.MyProducerList = Materials_ProducerFunc.Instance.SelectByModel(new Materials_Producer { MaterialsId = colorInfo.MaterialsId.Value });
                ViewBag.ColorId = colorInfo.SKU;
            }
            return View();
        }
        #endregion

        #region 待采购列表
        /// <summary>
        /// 待采购列表
        /// </summary>
        /// <returns></returns>
        [UserAuthorize]
        public ActionResult WaitBuyerInfo()
        {
            ViewBag.RowCount = DeliverFunc.Instance.SelectAllDeliversCount();
            return View();
        }
        #endregion

        #region 采购单管理
        /// <summary>
        /// 采购单管理
        /// </summary>
        /// <returns></returns>
        [UserAuthorize]
        public ActionResult BuyerInfo()
        {
            //送货单
            var PrintText = HttpContext.Request.QueryString["PrintText"].ParseInt();
            var Id = HttpContext.Request.QueryString["Id"].ParseInt();
            if (Id != null || PrintText != null)
            {
                ViewBag.PrintText = PrintText;
                ViewBag.Id = Id;
            }
            ViewBag.Producer = ProducerFunc.Instance.SelectAll();
            return View();
        }
        /// <summary>
        /// 采购单管理详情
        /// </summary>
        /// <returns></returns>
        public ActionResult BuyerDetailInfo()
        {
            var PrintText = HttpContext.Request.QueryString["PrintText"].ParseInt();
            var Id = HttpContext.Request.QueryString["Id"].ParseInt();
            var buyers = BuyerFunc.Instance.SelectBuyerById(Id.Value);
            var List_deliver = DeliverFunc.Instance.SelectAllDeliver(Id.Value);
            if (buyers == null)
            {
                //错误页面
                return View("BuyerDetailInfoError");
            }
            if (List_deliver != null || buyers != null || PrintText != null)
            {
                ViewBag.PrintText = PrintText;
                ViewBag.BuyerInfo = buyers;
                ViewBag.DeliverFullInfo = List_deliver;
                if (buyers.buyerStatus == "待送货品检")
                {
                    return View("BuyerDetailInfoDelivery");
                }
                else
                {
                    return View();
                }
            }
            else
            {
                //错误页面
                return View("BuyerDetailInfoError");
            }
        }
        /// <summary>
        /// 电子合同
        /// </summary>
        /// <returns></returns>
        public ActionResult Contract()
        {
            var BuyerId = HttpContext.Request.QueryString["Id"].ParseInt();
            var buyerStatus = BuyerFunc.Instance.SelectBuyerById(BuyerId.Value).buyerStatus;
            var List_Deliver = DeliverFunc.Instance.SelectAllDeliver(BuyerId.Value);
            var Producer = BuyerFunc.Instance.SelectBuyerById(BuyerId.Value);
            if (List_Deliver != null || Producer != null)
            {

                ViewBag.DeliverInfo = List_Deliver;
                ViewBag.ProducerInfo = Producer;
                ViewBag.ProducerConectInfo = ProducerconectinfoOper.Instance.SelectAll(new Producerconectinfo { ProducerId = Producer.producerId.Value }).FirstOrDefault();
            }
            ViewBag.buyerStatus = buyerStatus;
            return View();
        }
        #endregion

        #region 供应商管理
        /// <summary>
        /// 供应商信息
        /// </summary>
        /// <returns></returns>
        [UserAuthorize]
        public ActionResult ProducerInfo()
        {
            return View();
        }
        /// <summary>
        /// 供应商修改或新增
        /// </summary>
        /// <returns></returns>
        public ActionResult ProducerDetail()
        {
            var Id = Request.QueryString["Id"].ParseInt();
            if (Id != null)
            {
                ViewBag.Producer = ProducerOper.Instance.SelectById(Id.Value);
                ViewBag.ConectList = ProducerconectinfoOper.Instance.SelectAll(new Producerconectinfo { ProducerId = Id });
            }
            return View();
        }
        #endregion
    }
}