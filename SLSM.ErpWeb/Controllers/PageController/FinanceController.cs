using Common.Extend;
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
    public class FinanceController : BaseMvcMasterController
    {
        /// <summary>
        /// 财务管理
        /// </summary>
        /// <returns></returns>
        // GET: Finance
        #region 应付账款
        [UserAuthorize]
        public ActionResult WantFinance()
        {
            //应付账款
            decimal? Num = 0;
            //已付账款
            decimal? WantNum = 0;
            var Producers = ProducerFunc.Instance.SelectAll();
            var CountMoney = ProducerFunc.Instance.SelectNoMoney();
            if (Producers != null || CountMoney != null)
            {
                foreach (var item in CountMoney)
                {
                    if (item.buyerMoney != item.wantmoney)
                    {
                        Num += (item.buyerMoney - item.wantmoney);
                    }
                    WantNum += item.wantmoney;
                }
                ViewBag.Producer = Producers;
                ViewBag.CountNumMoney = Num;
                ViewBag.CountWantMoney = WantNum;
            }
            return View();
        }
        /// <summary>
        /// 付款
        /// </summary>
        /// <returns></returns>
        public ActionResult FinanceInfo()
        {
            var Id = HttpContext.Request.QueryString["Id"];
            if (Id != null)
            {
                ViewBag.Id = Id;
            }
            return View();
        }
        /// <summary>
        /// 发票的新增
        /// </summary>
        /// <returns></returns>
        public ActionResult EntryInvoice()
        {
            //供应商
            ViewBag.Producer = ProducerFunc.Instance.SelectAll();
            //订单Id
            var OrderId = HttpContext.Request.QueryString["OrderId"];
            List<string> orderIdList = new List<string>();
            if (!OrderId.IsNullOrEmpty())
            {
                foreach (var item in OrderId.Split(','))
                {
                    if (!item.IsNullOrEmpty())
                    {
                        orderIdList.Add(item);
                    }
                }
            }
            var Buyers = Buyer_Producer_ViewFunc.Instance.SelectByKeys("Id", orderIdList);
            if (Buyers.Count == 0)
            {
                return new JsonResult { Data = "并未选择订单！", JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
            if (Buyers.Where(p => p.wantTime != null).ToList().Count != 0)
            {
                return new JsonResult { Data = "请选择未开发票的订单！", JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
            var produceIds = Buyers.Select(p => p.producerId).Where(p => !p.IsNullOrEmpty()).Distinct().ToList();
            if (produceIds.Count > 1)
            {
                return new JsonResult { Data = "选择订单的供应商必须一致！", JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }

            var Produces = ProducerFunc.Instance.SelectByModel(new Producer { Id = Buyers[0].producerId.Value }).FirstOrDefault();
            ViewBag.Produces = Produces;
            ViewBag.ListOrders = Buyers;
            ViewBag.OrderId = OrderId;
            return View();
        }
        #endregion

        #region 发票记录
        [UserAuthorize]
        public ActionResult InvoiceInfo()
        {
            //查询供应商信息
            var Id = HttpContext.Request.QueryString["Id"].ParseInt();
            if (Id != null)
            {
                ViewBag.Id = ProducerFunc.Instance.SelectById(Id.Value).Id;
            }
            return View();
        }
        /// <summary>
        /// 修改
        /// </summary>
        /// <returns></returns>
        public ActionResult EditEntryInvoice()
        {
            //供应商
            ViewBag.Producer = ProducerFunc.Instance.SelectAll();
            var Id = HttpContext.Request.QueryString["Id"].ParseInt();
            if (Id != null)
            {
                ViewBag.InvoiceInfo = ProducerFunc.Instance.SelectinvoiceById(Id.Value);

            }
            return View();
        }
        #endregion
    }
}