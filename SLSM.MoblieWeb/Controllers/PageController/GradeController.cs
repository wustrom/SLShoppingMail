using DbOpertion.Function;
using SLSM.DBOpertion.Function;
using SLSM.Web.Common.BaseController;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SLSM.MoblieWeb.Controllers.PageController
{
    public class GradeController : BaseMvcMasterController
    {
        // GET: Grade
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AllGrade()
        {
            var list = GradeFunc.Instance.GetAllGrade();
            ViewBag.allGrade = list;
            return View();
        }
    }
}