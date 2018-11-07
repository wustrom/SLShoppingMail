using DbOpertion.Function;
using SLSM.ErpWeb.App_Start;
using SLSM.ErpWeb.Common.BaseController;
using SLSM.ErpWeb.Model.Request.Color;
using SLSM.ErpWeb.Model.Request.Echnology;
using System.Web.Mvc;

namespace SLSM.ErpWeb.Controllers.PageController
{
    public class EquipmentController : BaseMvcMasterController
    {
        #region 定制工艺管理
        /// <summary>
        /// 定制工艺管理
        /// </summary>
        /// <returns></returns>
        [UserAuthorize]
        public ActionResult TechnologyInfo()
        {
            return View();
        }
        /// <summary>
        /// 修改定制工艺名称
        /// </summary>
        /// <param name="requst"></param>
        /// <returns></returns>
        public ActionResult EditTechnologyInfo(EchnologyRequest requst)
        {
            var Technology = TechnologyFunc.Instance.SelectById(requst.Id);
            if (Technology != null)
            {
                ViewBag.TechnologyInfo = Technology;
                return View();
            }
            else
            {
                //跳转到错误页面
                return View();
            }
        }
        #endregion

        #region 颜色管理
        /// <summary>
        /// 颜色管理
        /// </summary>
        /// <returns></returns>
        [UserAuthorize]
        public ActionResult ColorInfo()
        {
            return View();
        }
        /// <summary>
        /// 修改颜色管理
        /// </summary>
        /// <param name="requst"></param>
        /// <returns></returns>
        public ActionResult EditColorInfo(EditColorInfoRequest request)
        {
            if (request.ColorId != null)
            {
                var ColorInfo = ColorinfoFunc.Instance.SelectById(request.ColorId.Value);
                ViewBag.ColorInfo = ColorInfo;
                if (ColorInfo.ParentId != 0)
                {
                    ViewBag.FatherInfo = ColorinfoFunc.Instance.SelectById(ColorInfo.ParentId.Value);
                }
            }
            if (request.fatherId != null)
            {
                ViewBag.FatherInfo = ColorinfoFunc.Instance.SelectById(request.fatherId.Value);
            }
            return View();
        }
        #endregion
    }
}