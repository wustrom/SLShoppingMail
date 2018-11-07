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
    /// 评价控制器
    /// </summary>
    public class EvaluateController : BaseMvcMasterController
    {
        /// <summary>
        /// 评价首页
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 评价首页详情
        /// </summary>
        /// <returns></returns>
        public ActionResult Detail(IdRequest request)
        {
            if (request != null && request.Id != 0)
            {
                ViewBag.Evaluate = EvaluateFunc.Instance.SelectById(request.Id);
            }
            return View();
        }

        /// <summary>
        /// 评价首页详情
        /// </summary>
        /// <returns></returns>
        public ActionResult ReturnDetail(IdRequest request)
        {
            if (request != null && request.Id != 0)
            {
                ViewBag.EvaluateParentId = request.Id;
                ViewBag.Reply = EvaluateFunc.Instance.SelectReplyById(request.Id);
            }
            return View();
        }
    }
}