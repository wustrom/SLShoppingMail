using Common.Extend;
using DbOpertion.Function;
using SLSM.ErpWeb.App_Start;
using SLSM.ErpWeb.Common.BaseController;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SLSM.ErpWeb.Controllers.PageController
{
    public class ConsignmentController : BaseMvcMasterController
    {
        // GET: Consignment
        #region 发货管理
        /// <summary>
        /// 发货信息
        /// </summary>
        /// <returns></returns>
        [UserAuthorize]
        public ActionResult ConsignmentInfo()
        {
            var Consignment = HttpContext.Request.QueryString["Consignment"].ParseInt();
            if (Consignment != null)
            {
                ViewBag.Consignment = Consignment;
            }
            return View();
        }
        /// <summary>
        /// 收货人信息
        /// </summary>
        /// <returns></returns>
        public ActionResult ConsigneeInfo()
        {
            var Id = HttpContext.Request.QueryString["Id"].ParseInt();
            if (Id != null)
            {
                ViewBag.Id = Id;
                ViewBag.Production = Production_Orderdetail_ViewFunc.Instance.SelectByModel(new DbOpertion.Models.Production_Orderdetail_View {Id=Id.Value }).FirstOrDefault();
                return View();
            }
            else
            {
                //错误页面
                return View();
            }
        }
        #endregion
    }
}