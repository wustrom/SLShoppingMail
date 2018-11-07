using Common.Extend;
using DbOpertion.Function;
using SLSM.ErpWeb.App_Start;
using SLSM.ErpWeb.Common.BaseController;
using SLSM.ErpWeb.Model.Request.Erpuser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SLSM.ErpWeb.Controllers.PageController
{
    public class JurisdictionController : BaseMvcMasterController
    {
        // GET: Jurisdiction
        /// <summary>
        /// 账号权限
        /// </summary>
        /// <returns></returns>
        [UserAuthorize]     
        #region 管理平台账号权限
        public ActionResult JurisdictionInfo()
        {
            return View();
        }
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public ActionResult UpdateInfo(ErpuserRequest request)
        {
            var Jurisdiction = ErpuserFunc.Instance.SelectById(request.ErproleId);
            if (Jurisdiction != null)
            {
                ViewBag.JurisdictionFullInfo = Jurisdiction;
            }
            return View();
        }
        #endregion

        #region 登录用户
        /// <summary>
        /// 用户登录
        /// </summary>
        /// <returns></returns>
        [UserAuthorize]
        public ActionResult ErpLoginUser()
        {
            return View();
        }
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public ActionResult UpdateLoginUser(ErpuserRequest request)
        {
            var LoginUsers = Erplogin_Role_ViewFunc.Instance.SelectById(request.erpLoginId);
            var Roles = ErpuserFunc.Instance.SelectByModel(new DbOpertion.Models.Erpuser { });
            if(LoginUsers!=null|| Roles!=null)
            {
                ViewBag.LoginUserInfo = LoginUsers;
                ViewBag.RolesInfo = Roles;
            }
            return View();
        }
        #endregion
    }
}