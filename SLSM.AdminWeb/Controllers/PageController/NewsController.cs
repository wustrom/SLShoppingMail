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
    /// 新闻控制器
    /// </summary>
    public class NewsController : BaseMvcMasterController
    {
        /// <summary>
        /// 控制器首页
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 消息首页详情
        /// </summary>
        /// <returns></returns>
        public ActionResult Detail(IdRequest request)
        {
            if (request != null && request.Id != 0)
            {
                ViewBag.News = NewsFunc.Instance.SelectById(request.Id);
            }
            return View();
        }
    }
}