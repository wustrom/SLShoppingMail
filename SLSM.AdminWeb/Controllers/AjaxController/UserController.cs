using Common.Extend;
using Common.Filter.WebApi;
using Common.Helper;
using Common.Result;
using DbOpertion.Function;
using DbOpertion.Models;
using SLSM.AdminWeb.Model.Request.User;
using SLSM.DBOpertion.Function;
using SLSM.Web.Models.Resquest.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.SessionState;

namespace SLSM.AdminWeb.Controllers.AjaxController
{
    /// <summary>
    /// 用户控制器
    /// </summary>
    public class UserController : BaseApiController
    {
        /// <summary>
        /// 增加用户信息
        /// </summary>
        /// <param name="request">请求</param>
        /// <returns></returns>
        [HttpPost]
        public ResultJson AddUserInfo(AddUserRequest request)
        {
            if (request.Discount > 100)
            {
                return new ResultJson { HttpCode = 300, Message = "请输入0~100的数字！" };
            }
            var result = UserFunc.Instance.InsertModel(new DbOpertion.Models.User
            {
                Name = request.NickName,
                Email = request.Email,
                Discount = (float)(request.Discount / 100),
                Phone = request.Phone,
                Sex = request.Sex,
                CreateTime = DateTime.Now,
                CompanyName = request.CompanyName,
                CompanyAddr = request.CompanyAddr,
                ZipCode = request.ZipCode,
                CompanyPhone = request.CompanyPhone
            });
            if (result == "成功！")
            {
                return new ResultJson { HttpCode = 200, Message = "添加成功！" };
            }
            else
            {
                return new ResultJson { HttpCode = 300, Message = result };
            }

        }

        /// <summary>
        /// 修改用户信息
        /// </summary>
        /// <param name="request">请求</param>
        /// <returns></returns>
        [HttpPost]
        public ResultJson EditUserInfo(AddUserRequest request)
        {
            if (request.Discount > 100)
            {
                return new ResultJson { HttpCode = 300, Message = "请输入0~100的数字！" };
            }
            var result = UserFunc.Instance.UpdateModel(new DbOpertion.Models.User
            {
                Name = request.NickName,
                Email = request.Email,
                Discount = (float)request.Discount / 100,
                Phone = request.Phone,
                Sex = request.Sex,
                CreateTime = DateTime.Now,
                CompanyName = request.CompanyName,
                CompanyAddr = request.CompanyAddr,
                ZipCode = request.ZipCode,
                Id = request.UserId,
                CompanyPhone = request.CompanyPhone
            });
            if (result == "成功！")
            {
                return new ResultJson { HttpCode = 200, Message = "修改成功！" };
            }
            else
            {
                return new ResultJson { HttpCode = 300, Message = result };
            }

        }

        /// <summary>
        /// 删除用户信息
        /// </summary>
        /// <param name="request">请求</param>
        /// <returns></returns>
        [HttpPost]
        public ResultJson DeleteUser(UserInfoRequest request)
        {
            if (UserFunc.Instance.DeleteModel(request.UserId))
            {
                return new ResultJson { HttpCode = 200, Message = "删除成功！" };
            }
            else
            {
                return new ResultJson { HttpCode = 300, Message = "删除操作失败！" };
            }

        }

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