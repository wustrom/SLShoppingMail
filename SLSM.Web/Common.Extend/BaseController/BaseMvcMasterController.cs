using Common.Extend;
using Common.Helper;
using Common.Helper.JsonHelper;
using Common.Result;
using DbOpertion.Function;
using DbOpertion.Models;
using log4net;
using SLSM.DBOpertion.Function;
using SLSM.Web.Models.Response.Address;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Web;
using System.Web.Http.Results;
using System.Web.Mvc;

namespace SLSM.MoblieWeb.Common.BaseController
{
    /// <summary>
    /// MVC母版控制器
    /// </summary>
    public class BaseMvcMasterController : Controller
    {
        /// <summary>
        /// Mvc母版控制器构造函数
        /// </summary>
        public BaseMvcMasterController()
        {

        }

        /// <summary>
        /// 发生错误之后
        /// </summary>
        /// <param name="filterContext">条件内容</param>
        protected override void OnException(ExceptionContext filterContext)
        {
            JsonResult jsonResult = new JsonResult();
            ResultJson result = new ResultJson();
            result.HttpCode = 400;
            result.Message = filterContext.Exception.Message;
            jsonResult.Data = JsonHelper.Instance.SerializeObject(result);
            //创建日志记录组件实例
            ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
            //记录错误日志
            log.Error("error", filterContext.Exception);
            filterContext.Result = jsonResult;
        }

        /// <summary>
        /// Model验证
        /// </summary>
        /// <param name="actionContext"></param>
        protected override void OnActionExecuting(ActionExecutingContext actionContext)
        {
            var Controller = actionContext.Controller;
            ModelStateDictionary ModelState = (ModelStateDictionary)ReflexHelper.Instance.GetPropertyValue(Controller, "ModelState");
            bool? IsValid = null;
            if (ModelState != null)
            {
                IsValid = ModelState.IsValid;
            }
            if (IsValid == false)
            {
                ResultJson result = new ResultJson();
                result.HttpCode = 300;
                foreach (var item in ModelState.Values)
                {
                    foreach (var error in item.Errors)
                    {
                        if (!error.ErrorMessage.IsNullOrEmpty())
                        {
                            result.Message += error.ErrorMessage + ",";
                        }
                    }
                }

                result.Message = result.Message.Remove(result.Message.Count() - 1, 1);
                var JsonString = JsonHelper.Instance.SerializeObject(result);
                JsonResult jsonResult = new JsonResult();
                jsonResult.Data = JsonHelper.Instance.SerializeObject(result);
                jsonResult.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
                actionContext.Result = jsonResult;
            }
        }

        /// <summary>
        /// 重新设置用户的过期时间
        /// </summary>
        /// <param name="filterContext"></param>
        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            var userGuid = CookieOper.Instance.GetUserGuid();
            var user = MemCacheHelper2.Instance.Cache.GetModel<User>("UserGuID_" + userGuid);
            List<Hisdesigninfo_View> ListHisdesign = new List<Hisdesigninfo_View>();
            int? userId = null;
            if (user != null)
            {
                userId = user.Id;
                user = UserFunc.Instance.SelectById(user.Id);
                ViewBag.UserInfo = user;
                MemCacheHelper2.Instance.Cache.Set("UserGuID_" + userGuid, user, 24 * 60);
                #region 微信支付列表
                var WechatOrder = Order_InfoFunc.Instance.SelectByModel(new Order_Info { WechatFaild = false, Status = 1, UserId = user.Id });
                foreach (var item in WechatOrder)
                {
                    HttpClient client = new HttpClient();
                    client.BaseAddress = new Uri(HttpContext.Request.Url.Scheme + "://" + HttpContext.Request.Url.Authority);
                    var result = client.GetStringAsync("api/Order/WeiChatOrder?OrderNo=" + item.OrderNo);
                }
                #endregion
            }
            #region 购物车列表
            ListHisdesign = HisdesignFunc.Instance.GetModleHisdesign(new Hisdesigninfo_View { UserID = userId, UserGuId = userGuid, OrderId = 0, IsMobile = false });
            ViewBag.HisdesignCount = HisdesignFunc.Instance.GetHisdesignInfoCount(new Hisdesigninfo_View { UserID = userId, UserGuId = userGuid, OrderId = 0, IsMobile = false });
            var list = CommodityPriceFunc.Instance.SelectByIds(ListHisdesign.Select(p => p.CommodityId).ToList());
            List<HisdesigninfoResponse> listResponse = new List<HisdesigninfoResponse>();
            foreach (var item in ListHisdesign)
            {
                var priceList = list.Where(p => p.CommodityId == item.CommodityId).ToList();
                HisdesigninfoResponse response = new HisdesigninfoResponse(item, priceList);
                listResponse.Add(response);
            }
            ViewBag.HisdesignInfo = listResponse;
            ViewBag.HisdesignPrice = listResponse.Sum(p => p.Price);
            //颜色列表
            ViewBag.ColorList = ColorinfoFunc.Instance.GetColorListBase();
            #endregion
            ViewBag.listGradeOfTitle = GradeFunc.Instance.GetAllGrade();
            ViewBag.listScence = GradeFunc.Instance.GetAllScene();
            #region 分类推荐列表
            ViewBag.ShowgradeList = ShowgradeinfoFunc.Instance.SelectByModel(null);
            ViewBag.AllListGrade = GradeFunc.Instance.GetAllGradeInfo(); 
            #endregion
            ViewBag.listCommdity = CommodityFunc.Instance.GetAllCommList();
            ViewBag.CommShowList = CommshowFunc.Instance.SelectByModel(null);
            ViewBag.DisCount = user == null ? 1 : user.Discount;
            ViewBag.AdminUrl = System.Configuration.ConfigurationManager.AppSettings["AdminUrl"];
            var ServiceList = CustomerserviceFunc.Instance.SelectByModel(new Customerservice { IsService = true });
            Customerservice customerservice = new Customerservice();
            if (ServiceList.Count != 0)
            {
                Random rd = new Random();
                var rdNum = rd.Next(0, ServiceList.Count - 1);
                customerservice = ServiceList[rdNum];
            }
            ViewBag.customerservice = customerservice;
        }

    }
}