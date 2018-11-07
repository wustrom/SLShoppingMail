using Common.Extend;
using Common.Filter.WebApi;
using Common.Helper;
using log4net;
using SLSM.Web.Common.BaseController;
using SLSM.MoblieWeb.Models.Resquest.Home;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.SessionState;
using Common.Result;
using SLSM.DBOpertion.Function;
using DbOpertion.Function;

namespace SLSM.MoblieWeb.Controllers.AjaxController
{
    public class HomeController : BaseApiController
    {

        HttpSessionState Session = HttpContext.Current.Session;
        ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        /// <summary>
        /// 获得省份的信息
        /// </summary>
        [HttpPost]
        public string GetProvinceInfo(ProvinceRequest request)
        {
            if (request.Level.ToLower() == "province")
            {
                var result = ProvinceHelper.Instance.GetProvince();
                return result;
            }
            else if (request.Level.ToLower() == "city")
            {
                if (!request.AreaName.IsNullOrEmpty())
                {
                    var result = ProvinceHelper.Instance.GetCity(request.AreaName);
                    return result;
                }
            }
            else if (request.Level.ToLower() == "area")
            {
                if (!request.AreaName.IsNullOrEmpty())
                {
                    var result = ProvinceHelper.Instance.GetArea(request.AreaName);
                    return result;
                }
            }
            return "[]";
        }

        /// <summary>
        /// 发送手机验证码
        /// </summary>
        /// <param name="request">请求</param>
        [HttpPost]
        public ResultJson SendReSetPhone(LoginByPhoneRequest request)
        {
            ResultJson result = new ResultJson();
            var userGuid = CookieOper.Instance.GetUserGuid();
            var resultCode = UserFunc.Instance.SetUserPhoneCodeCached(request.UserPhone);
            if (resultCode == "手机验证码发送成功！")
            {
                result.HttpCode = 200;
                result.Message = "发送信息成功！";
            }
            else
            {
                result.HttpCode = 500;
                result.Message = resultCode;
            }
            return result;
        }

        /// <summary>
        /// 退出登入
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ResultJsonModel ExitUserLogin()
        {
            ResultJsonModel result = new ResultJsonModel();
            var userGuid = CookieOper.Instance.GetUserGuid();
            var flag = MemCacheHelper2.Instance.Cache.Delete("UserGuID_" + userGuid);
            if (flag)
            {
                result.HttpCode = 200;
                result.Message = "退出登入成功";
            }
            else
            {
                result.HttpCode = 300;
                result.Message = "退出登入失败";
            }
            return result;
        }
    }
}
