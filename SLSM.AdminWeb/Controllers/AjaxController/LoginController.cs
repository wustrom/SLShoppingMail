using Common.Result;
using SLSM.AdminWeb.Model.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SLSM.AdminWeb.Controllers.AjaxController
{
    public class LoginController : ApiController
    {
        /// <summary>
        /// 登入
        /// </summary>
        /// <param name="request">请求</param>
        /// <returns></returns>
        [HttpPost]
        public ResultJson Login(LoginRequest request)
        {
            if (request.UserName.ToLower() == "admin" && request.UserPass.ToLower() == "admin")
            {
                return new ResultJson { HttpCode = 200, Message = "登入成功" };
            }
            else
            {
                return new ResultJson { HttpCode = 300, Message = "用户名或密码错误！" };
            }
        }
    }
}