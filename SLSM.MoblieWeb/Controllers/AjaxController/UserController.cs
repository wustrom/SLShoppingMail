using Common.Filter.WebApi;
using Common.Helper;
using Common.Result;
using DbOpertion.Function;
using DbOpertion.Models;
using SLSM.DBOpertion.Function;
using SLSM.MoblieWeb.Models.Response.Address;
using SLSM.MoblieWeb.Models.Resquest.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SLSM.MoblieWeb.Controllers.AjaxController
{
    /// <summary>
    /// 个人资料
    /// </summary>
    public class UserController : BaseApiController
    {
        /// <summary>
        /// 设置用户资料
        /// </summary>
        /// <param name="request">请求</param>
        /// <returns></returns>
        [HttpPost]
        public ResultJson UpdateUserInfo(UpdateUserNameRequest request)
        {
            ResultJson result = new ResultJson();
            var userGuid = CookieOper.Instance.GetUserGuid();
            var user = MemCacheHelper2.Instance.Cache.GetModel<User>("UserGuID_" + userGuid);
            if (user != null)
            {
                var userResult = UserFunc.Instance.UpdateUser(new DbOpertion.Models.User { Id = user.Id, Name = request.Name, Sex = request.Sex == "男" ? true : false, CompanyName = request.CompanyName, ConmpanyType = request.ConmpanyType, CompanyPhone = request.CompanyPhone, CompanyAddr = request.CompanyAddr, ZipCode = request.ZipCode });
                user = UserFunc.Instance.SelectById(user.Id);
                MemCacheHelper2.Instance.Cache.Set("UserGuID_" + userGuid, user, 24 * 60);
                if (userResult)
                {
                    result.HttpCode = 200;
                    result.Message = "用户信息更新成功！";
                }
                else
                {
                    result.HttpCode = 300;
                    result.Message = "用户信息更新失败！";
                }
            }
            else
            {
                result.HttpCode = 300;
                result.Message = "用户未登入！";
            }
            return result;
        }
        /// <summary>
        /// 设置为默认地址
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ResultJson UpAddrTime(UpdateAddrRTimeRequest request)
        {
            ResultJson result = new ResultJson();
            var Addressresult = AddressFunc.Instance.Update(new Address { Id = request.Id, DefaultTime = DateTime.Now });
            if (Addressresult)
            {
                result.HttpCode = 200;
                result.Message = "设置成功！";
            }
            else
            {
                result.HttpCode = 300;
                result.Message = "设置添加失败！";
            }
            return result;
        }
        /// <summary>
        /// 删除地址
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public ResultJson DeleteAddr(DeleteAddressRequest request)
        {
            ResultJson result = new ResultJson();
            var Addressresult = AddressFunc.Instance.DeleteAdrr(request.Id);
            if (Addressresult)
            {
                result.HttpCode = 200;
                result.Message = "收货人信息删除成功！";
            }
            else
            {
                result.HttpCode = 300;
                result.Message = "收货人信息删除失败！";
            }
            return result;
        }
        /// <summary>
        /// 新增收货人信息
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public ResultJsonModel<AddressByPageResponse> AddressAdd(UpdateAddressRequest request)
        {
            ResultJsonModel<AddressByPageResponse> result = new ResultJsonModel<AddressByPageResponse>();
            var userGuid = CookieOper.Instance.GetUserGuid();
            var user = MemCacheHelper2.Instance.Cache.GetModel<User>("UserGuID_" + userGuid);
            var Addressresult = AddressFunc.Instance.AdressAdd(new Address { UserId = user.Id, ContactName = request.ContactName, ContactPhone = request.ContactPhone, AddrArea = request.AddrArea, AddrDetail = request.AddrDetail,DefaultTime= DateTime.Now });
            if (Addressresult > 0)
            {
                result.HttpCode = 200;
                result.Message = "收货人信息添加成功！";
                result.Model1 = new AddressByPageResponse(AddressFunc.Instance.SelectAddrById(Addressresult));
            }
            else
            {
                result.HttpCode = 300;
                result.Message = "收货人信息添加失败！";
            }
            return result;
        }

        /// <summary>
        /// 联系人信息修改
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public ResultJsonModel<AddressByPageResponse> UpdateAddrr(UpdateAddressRequest request)
        {
            ResultJsonModel<AddressByPageResponse> result = new ResultJsonModel<AddressByPageResponse>();
            var Addressresult = AddressFunc.Instance.Update(new Address { Id = request.Id, ContactName = request.ContactName, ContactPhone = request.ContactPhone, AddrArea = request.AddrArea, AddrDetail = request.AddrDetail,DefaultTime= DateTime.Now });
            if (Addressresult)
            {
                result.HttpCode = 200;
                result.Message = "收货人信息修改成功！";
                result.Model1 = new AddressByPageResponse(AddressFunc.Instance.SelectAddrById(request.Id));
            }
            else
            {
                result.HttpCode = 300;
                result.Message = "收货人信息修改失败！";
            }
            return result;
        }

        /// <summary>
        /// 重置手机号码
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public ResultJson ResetPhone(ResetPhoneRequest request)
        {
            ResultJson result = new ResultJson();
            var userGuid = CookieOper.Instance.GetUserGuid();
            var user = MemCacheHelper2.Instance.Cache.GetModel<User>("UserGuID_" + userGuid);
            if (request.Phone1 != user.Phone)
            {
                result.HttpCode = 300;
                result.Message = "旧手机号码错误！";
                return result;
            }
            var code1 = MemCacheHelper2.Instance.Cache.GetModel<string>("UserPhoneCode_" + request.Phone1);
            var code2 = MemCacheHelper2.Instance.Cache.GetModel<string>("UserPhoneCode_" + request.Phone2);
            if (request.Code1 == code1 && request.Code2 == code2)
            {

                if (UserFunc.Instance.Update(new User { Id = user.Id, Phone = request.Phone2 }))
                {
                    MemCacheHelper2.Instance.Cache.Delete("UserPhoneCode_" + request.Phone1);
                    MemCacheHelper2.Instance.Cache.Delete("UserPhoneCode_" + request.Phone2);
                    user = UserFunc.Instance.SelectById(user.Id);
                    MemCacheHelper2.Instance.Cache.Set("UserGuID_" + userGuid, user, 24 * 60);
                    result.HttpCode = 200;
                    result.Message = "联系人信息修改成功！";
                }
                else
                {
                    result.HttpCode = 300;
                    result.Message = "联系人信息修改失败！";
                }

            }
            else
            {
                result.HttpCode = 300;
                result.Message = "联系人信息修改失败！";
            }
            return result;
        }

        /// <summary>
        /// 重置手机密码
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public ResultJson ResetPassword(ResetPasswordRequest request)
        {
            ResultJson result = new ResultJson();
            var userGuid = CookieOper.Instance.GetUserGuid();
            var user = MemCacheHelper2.Instance.Cache.GetModel<User>("UserGuID_" + userGuid);
            if (user.PassWord != null && request.Password.ToLower() != user.PassWord.ToLower())
            {
                result.HttpCode = 300;
                result.Message = "旧密码错误！";
                return result;
            }
            if (UserFunc.Instance.Update(new User { Id = user.Id, PassWord = request.NewPassword.Trim() }))
            {
                user = UserFunc.Instance.SelectById(user.Id);
                MemCacheHelper2.Instance.Cache.Set("UserGuID_" + userGuid, user, 24 * 60);
                result.HttpCode = 200;
                result.Message = "联系人信息修改成功！";
            }
            else
            {
                result.HttpCode = 300;
                result.Message = "联系人信息修改失败！";
            }
            return result;
        }
    }
}
