using DbOpertion.Function;
using SLSM.AdminWeb.Common.BaseController;
using SLSM.AdminWeb.Model.Request.User;
using SLSM.DBOpertion.Function;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SLSM.AdminWeb.Controllers.PageController
{
    /// <summary>
    /// 用户信息控制器
    /// </summary>
    public class UserInfoController : BaseMvcMasterController
    {
        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <returns></returns>
        public ActionResult AddInfo()
        {
            return View();
        }
        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <returns></returns>
        public ActionResult EditInfo(UserInfoRequest request)
        {
            var user = UserFunc.Instance.SelectById(request.UserId);
            if (user != null)
            {
                ViewBag.UserFullInfo = user;
                return View();
            }
            else
            {
                //本来是跳转到错误页面的
                return View();
            }
            
        }

        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <returns></returns>
        public ActionResult editform()
        {
            return View();
        }
    }
}