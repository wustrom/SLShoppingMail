using Common.Filter.WebApi;
using Common.Result;
using DbOpertion.Function;
using SLSM.ErpWeb.Model.Request.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SLSM.ErpWeb.Controllers.AjaxController
{
    public class LoginController : BaseApiController
    {
        /// <summary>
        /// 登入
        /// </summary>
        /// <param name="request">请求</param>
        /// <returns></returns>
        // [HttpPost]
        // public ResultJson Login(LoginRequest request)
        //{
        //    var LoginUser = ErploginuerFunc.Instance.SelectByModel(new DbOpertion.Models.Erploginuer { erpLoginName = request.UserName }).FirstOrDefault();
        //    if (LoginUser!=null)
        //    {
        //        if(request.UserPass==LoginUser.erpLoginPwd)
        //        {
        //            return new ResultJson { HttpCode = 200, Message = "正确" };
        //        }
        //        else
        //        {
        //            return new ResultJson { HttpCode = 300, Message = "密码错误！请重新输入" };
        //        }
        //    }else
        //    {
        //        return new ResultJson { HttpCode = 300, Message = "用户名错误！请重新输入" };
        //    }
        //}
    }
}
