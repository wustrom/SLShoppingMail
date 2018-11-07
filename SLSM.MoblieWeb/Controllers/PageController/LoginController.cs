using DbOpertion.Models;
using SLSM.DBOpertion.Function;
using SLSM.DBOpertion.Model.Extend.Request.CommodityList;
using SLSM.DBOpertion.Model.Extend.Response.CommodityRes;
using SLSM.Web.Common.BaseController;
using System.Collections.Generic;
using System.Web.Mvc;

namespace SLSM.MoblieWeb.Controllers.PageController
{
    /// <summary>
    /// 登入控制器
    /// </summary>
    public class LoginController : BaseMvcMasterController
    {
        /// <summary>
        /// 登入页面
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }
    }
}