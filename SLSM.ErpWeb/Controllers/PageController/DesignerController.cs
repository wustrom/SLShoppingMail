using Common.Extend;
using Common.Helper;
using DbOpertion.Function;
using DbOpertion.Models;
using SLSM.ErpWeb.App_Start;
using SLSM.ErpWeb.Common.BaseController;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SLSM.ErpWeb.Controllers.PageController
{
    public class DesignerController : BaseMvcMasterController
    {
        #region 设计师管理
        /// <summary>
        /// 设计师
        /// </summary>
        /// <returns></returns>
        [UserAuthorize]
        public ActionResult DesignerInfo()
        {
            return View();
        }

        /// <summary>
        /// 设计师
        /// </summary>
        /// <returns></returns>
        public ActionResult DesignerUpLoadDetail()
        {
            var Id = HttpContext.Request.QueryString["Id"].ParseInt();
            if (Id != null)
            {
                ViewBag.ProductionInfo = Production_Orderdetail_ViewFunc.Instance.SelectByModel(new DbOpertion.Models.Production_Orderdetail_View { Id = Id.Value }).FirstOrDefault();
            }

            return View();
        }
        #endregion

        #region 生产管理
        /// <summary>
        /// 订单管理
        /// </summary>
        /// <returns></returns>
        [UserAuthorize]
        public ActionResult ManufactureInfo()
        {
            var OrderText = HttpContext.Request.QueryString["OrderText"].ParseInt();
            ViewBag.OrderText = OrderText;
            return View();
        }
        /// <summary>
        /// 生产工艺单
        /// </summary>
        /// <returns></returns>
        public ActionResult ProductionInfo()
        {
            //订单Id
            var Id = HttpContext.Request.QueryString["Id"].ParseInt();
            //生产管理
            var OrderText = HttpContext.Request.QueryString["OrderText"].ParseInt();
            //成品品检
            var text = HttpContext.Request.QueryString["text"].ParseInt();
            //订单管理
            var ReturnText = HttpContext.Request.QueryString["ReturnText"].ParseInt();
            //发货管理
            var Consignment = HttpContext.Request.QueryString["Consignment"].ParseInt();
            //生产管理单
            var Productions = ProductionFunc.Instance.SelectViewById(Id.Value);
            var receive = ReceiveFunc.Instance.SelectByModel(new DbOpertion.Models.Receive { ProductionId = Id.Value }).FirstOrDefault();
            ViewBag.TechnologyList = TechnologyFunc.Instance.SelectByModel(new DbOpertion.Models.Technology { IsDelete = true });
            ViewBag.receive = receive;
            if (Productions != null || text != null || ReturnText != null || Consignment != null)
            {
                ViewBag.Text = text;
                ViewBag.ReturnText = ReturnText;
                ViewBag.ProductionInfo = Productions;
                ViewBag.Consignment = Consignment;
                ViewBag.OrderText = OrderText;
                var order_info = Order_InfoFunc.Instance.SelectByModel(new DbOpertion.Models.Order_Info { Id = Productions.OrderId.Value }).FirstOrDefault();
                ViewBag.OrderInfo = order_info;
            }
            var FinishedProduct = HttpContext.Request.QueryString["FinishedProduct"];
            if (FinishedProduct != null)
            {
                return View("FinalInspectionReport");
            }
            return View();
        }
        /// <summary>
        /// 退回客服
        /// </summary>
        /// <returns></returns>
        public ActionResult ReturnServiceInfo()
        {
            var Id = HttpContext.Request.QueryString["Id"].ParseInt();
            if (Id != null)
            {
                ViewBag.Id = Id;
            }
            return View();
        }
        /// <summary>
        /// 生产计划分配
        /// </summary>
        /// <returns></returns>
        public ActionResult PlannedDistribution()
        {
            var Id = HttpContext.Request.QueryString["Id"].ParseInt();
            if (Id != null)
            {
                //订单信息
                ViewBag.ProductionInfo = ProductionFunc.Instance.SelectById(Id.Value);
                var Distribution = Distribution_Production_ViewFunc.Instance.SelectByModel(new DbOpertion.Models.Distribution_Production_View { ProductionId = Id });
                ViewBag.Distribution = Distribution;
                #region 该订单时间
                var productionTime = 0;
                foreach (var item in Distribution)
                {
                    productionTime += (item.productionTime != null ? item.productionTime.Value : 0);
                }
                ViewBag.productionTime = productionTime;
                #endregion

                #region 未生产订单时间
                var NotProductionTime = 0;
                var NotProductionTimes = Distribution_Production_ViewFunc.Instance.SelectByModel(new DbOpertion.Models.Distribution_Production_View { ProductionStatus = "待生产" });
                foreach (var item in NotProductionTimes)
                {
                    NotProductionTime += (item.productionTime != null ? item.productionTime.Value : 0);
                }
                ViewBag.NotProductionTime = NotProductionTime;
                #endregion

                #region 在生产订单时间
                var EndProductionTime = 0;
                var EndProductionTimes = Distribution_Production_ViewFunc.Instance.SelectByModel(new DbOpertion.Models.Distribution_Production_View { ProductionStatus = "生产中" });
                foreach (var item in EndProductionTimes)
                {
                    EndProductionTime += (item.productionTime != null ? item.productionTime.Value : 0);
                }
                ViewBag.EndProductionTime = EndProductionTime;
                #endregion 
            }
            return View();
        }
        #endregion
    }
}