using Common.Filter.MvcAjax;
using Common.Helper;
using log4net;
using Newtonsoft.Json;
using SLSM.MoblieWeb.Common.BaseController;
using SLSM.Web.Models.Resquest.Test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace SLSM.Web.Controllers
{
    /// <summary>
    /// 首页控制器
    /// </summary>
    public class HomeController : BaseMvcMasterController
    {
        ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        /// <summary>
        /// 首页
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 获得验证码图片
        /// </summary>
        /// <returns></returns>
        public ActionResult GetYZMImage()
        {
            YZMHelper yzmhelper = new YZMHelper();
            MemCacheHelper2.Instance.Cache.Set("yzmCode_" + Session.SessionID, yzmhelper.Text, DateTime.Now.AddMinutes(30));
            //log.Error("页面SessionID" + Session.SessionID);
            return File(yzmhelper.GetVaildateBytes(), "image/Jepg");
        }
    }
}