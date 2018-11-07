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
    /// 消息控制器
    /// </summary>
    public class MessageController : BaseMvcMasterController
    {
        /// <summary>
        /// 消息首页
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
                ViewBag.Message = MessageFunc.Instance.SelectById(request.Id);
            }
            return View();
        }

        /// <summary>
        /// 消息首页详情
        /// </summary>
        /// <returns></returns>
        public ActionResult SendMessage(IdRequest request)
        {
            if (request != null)
            {
                ViewBag.Id = request.Id;
            }
            return View();
        }
    }
}