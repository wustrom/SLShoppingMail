using DbOpertion.Function;
using SLSM.AdminWeb.Common.BaseController;
using SLSM.AdminWeb.Model.Request.Service;
using SLSM.DBOpertion.Function;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SLSM.AdminWeb.Controllers.PageController
{
    public class ServiceController : BaseMvcMasterController
    {
        /// <summary>
        /// 回复
        /// </summary>
        /// <returns></returns>
        public ActionResult ServiceInfo()
        {
            return View();
        }
        /// <summary>
        /// 工位管理
        /// </summary>
        /// <returns></returns>
        public ActionResult Services()
        {
            return View();
        }
        /// <summary>
        /// 获取客服信息
        /// </summary>
        /// <returns></returns>
        public ActionResult EditInfo(ServiceInfoRequest request)
        {
            var Service = CustomerserviceFunc.Instance.SelectById(request.Id);
            if (Service != null)
            {
                ViewBag.ServiceInfo = Service;
                return View();
            }
            else
            {
                //本来是跳转到错误页面的
                return View();
            }

        }
        /// <summary>
        /// 获取客服信息
        /// </summary>
        /// <returns></returns>
        public ActionResult AddInfo()
        {
            return View();
        }
    }
}