using DbOpertion.Function;
using SLSM.DBOpertion.Function;
using SLSM.MoblieWeb.Common.BaseController;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SLSM.Web.Controllers
{
    public class MainController : BaseMvcMasterController
    {
        // GET: Main
        public ActionResult Index()
        {
            ViewBag.Commrecommend = CommrecommendFunc.Instance.SelectByModel(null);
            ViewBag.Images = Carousel_ImageFunc.Instance.SelectTopImages(0, 6);
            return View();
        }

        // GET: Main
        public ActionResult Login(string Login)
        {
            ViewBag.Login = Login;
            return View();
        }
    }
}