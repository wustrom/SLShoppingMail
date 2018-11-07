using Common.Extend;
using Common.Filter.WebApi;
using Common.Helper;
using Common.Result;
using SLSM.DBOpertion.Function;
using SLSM.MoblieWeb.Models.Response.Evaluate;
using SLSM.MoblieWeb.Models.Resquest.Evaluate;
using SLSM.MoblieWeb.Models.Resquest.Home;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SLSM.MoblieWeb.Controllers.AjaxController
{
    /// <summary>
    /// 地址省份控制器
    /// </summary>
    public class AddressController : BaseApiController
    {
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
    }
}