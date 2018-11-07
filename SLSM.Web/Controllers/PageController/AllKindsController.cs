using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DbOpertion.Function;
using DbOpertion.Models;
using DbOpertion.Operation;
using SLSM.DBOpertion.Function;
using SLSM.DBOpertion.Model.Extend.Response.GradeRes;
using SLSM.MoblieWeb.Common.BaseController;

namespace SLSM.Web.Controllers.PageController
{
    public class AllKindsController : BaseMvcMasterController
    {
        // GET: AllKinds
        public ActionResult Index()
        {           
            ViewBag.listGrade = GradeFunc.Instance.GetAllGrade();
            return View();
        }
    }
}