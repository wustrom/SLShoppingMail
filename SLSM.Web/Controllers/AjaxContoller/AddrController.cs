using Common.Filter.WebApi;
using Common.Helper;
using Common.Result;
using DbOpertion.Function;
using DbOpertion.Models;
using SLSM.DBOpertion.Function;
using SLSM.Web.Models.Response.Address;
using SLSM.Web.Models.Resquest;
using SLSM.Web.Models.Resquest.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace SLSM.Web.Controllers.AjaxContoller
{
    /// <summary>
    /// 地址控制器
    /// </summary>
    public class AddrController : BaseApiController
    {
        /// <summary>
        /// 分页获得地址页面
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ResultJson<AddressByPageResponse> AddrByPage(PageRequest request)
        {
            ResultJson<AddressByPageResponse> result = new ResultJson<AddressByPageResponse>();
            var userGuid = CookieOper.Instance.GetUserGuid();
            var user = MemCacheHelper2.Instance.Cache.GetModel<User>("UserGuID_" + userGuid);
            var listAddress = UserFunc.Instance.SelectAddress((request.PageNo - 1) * request.PageSize, request.PageSize,user.Id);
            var flag = true;
            foreach (var item in listAddress)
            {
                AddressByPageResponse response = new AddressByPageResponse(item);
                if (flag && request.PageNo == 1)
                {
                    flag = false;
                }
                result.ListData.Add(response);
            }
            result.HttpCode = 200;
            result.Message = "查询数据成功！";
            return result;
        }
    }
}

