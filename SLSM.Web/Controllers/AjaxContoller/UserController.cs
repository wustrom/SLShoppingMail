using Common.Filter.WebApi;
using Common.Helper;
using Common.Result;
using DbOpertion.Function;
using DbOpertion.Models;
using SLSM.DBOpertion.Function;
using SLSM.MoblieWeb.Models.Resquest.User;
using SLSM.Web.Models.Response.Address;
using SLSM.Web.Models.Response.Invoice;
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
    /// 用户控制器
    /// </summary>
    public class UserController : BaseApiController
    {
        /// <summary>
        /// 用户收藏此商品
        /// </summary>
        /// <param name="likeRequest">请求</param>
        [HttpPost]
        public ResultJson UserLike(UserLikeRequest likeRequest)
        {
            ResultJson result = new ResultJson();
            var userGuid = CookieOper.Instance.GetUserGuid();
            var user = MemCacheHelper2.Instance.Cache.GetModel<User>("UserGuID_" + userGuid);
            var likeResult = UserLikeFunc.Instance.UserLikeCommodityId(user.Id, likeRequest.CommodityId, likeRequest.IsLike);
            if (likeResult.ToLower() == "true")
            {
                if (likeRequest.IsLike)
                {
                    result.HttpCode = 200;
                    result.Message = "收藏操作成功！";
                }
                else
                {
                    result.HttpCode = 200;
                    result.Message = "取消收藏操作成功！";
                }

            }
            else if (likeResult.ToLower() == "false")
            {
                if (likeRequest.IsLike)
                {
                    result.HttpCode = 200;
                    result.Message = "收藏操作失败！";
                }
                else
                {
                    result.HttpCode = 200;
                    result.Message = "取消收藏操作失败！";
                }
            }
            else
            {
                result.HttpCode = 300;
                result.Message = likeResult;
            }
            return result;
        }
        /// <summary>
        /// 设置用户姓名
        /// </summary>
        /// <param name="request">请求</param>
        /// <returns></returns>
        [HttpPost]
        public ResultJson UpdateUserName(UpdateUserNameRequest request)
        {
            ResultJson result = new ResultJson();
            if (request.Name.Length > 20)
            {
                result.HttpCode = 300;
                result.Message = "用户名长度不超过20！";
                return result;
            }
            var userGuid = CookieOper.Instance.GetUserGuid();
            var user = MemCacheHelper2.Instance.Cache.GetModel<User>("UserGuID_" + userGuid);
            if (user != null)
            {
                var userResult = UserFunc.Instance.UpdateUser(new DbOpertion.Models.User { Id = user.Id, Name = request.Name, Sex = request.Sex == "男" ? true : false });
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
        /// 设置公司信息
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public ResultJson UpdateCompany(UpdateUserCompanyRequest request)
        {
            ResultJson result = new ResultJson();
            var userGuid = CookieOper.Instance.GetUserGuid();
            var user = MemCacheHelper2.Instance.Cache.GetModel<User>("UserGuID_" + userGuid);
            var Companyresult = UserFunc.Instance.UpdateUser(new DbOpertion.Models.User { Id = user.Id, CompanyName = request.CompanyName, CompanyPhone = request.CompanyPhone, CompanyAddr = request.CompanyAddr, Email = request.Email, ZipCode = request.ZipCode, ConmpanyType = request.CompanyType, Sex = request.sex == "男" ? true : false, Name = request.Name });
            user = UserFunc.Instance.SelectById(user.Id);
            MemCacheHelper2.Instance.Cache.Set("UserGuID_" + userGuid, user, 24 * 60);
            if (Companyresult)
            {
                result.HttpCode = 200;
                result.Message = "用户信息更新成功！";
            }
            else
            {

                result.HttpCode = 300;
                result.Message = "用户信息更新失败！";
            }
            return result;
        }

        #region 地址方法
        /// <summary>
        /// 设置为默认地址
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ResultJson UpAddrTime(UpdateAddrRTimeRequest request)
        {
            ResultJson result = new ResultJson();
            var Addressresult = AddressFunc.Instance.Update(new DbOpertion.Models.Address { Id = request.Id, DefaultTime = DateTime.Now });
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
        /// 添加联系人信息
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public ResultJsonModel<AddressByPageResponse> AddressAdd(UpdateAddressRequest request)
        {
            ResultJsonModel<AddressByPageResponse> result = new ResultJsonModel<AddressByPageResponse>();
            var userGuid = CookieOper.Instance.GetUserGuid();
            var user = MemCacheHelper2.Instance.Cache.GetModel<User>("UserGuID_" + userGuid);
            if (user == null)
            {
                user = new DbOpertion.Models.User();
            }
            var Addressresult = AddressFunc.Instance.AdressAdd(new DbOpertion.Models.Address { UserId = user.Id, ContactName = request.ContactName, ContactPhone = request.ContactPhone, AddrArea = request.AddrArea, AddrDetail = request.AddrDetail, DefaultTime = DateTime.Now });
            if (Addressresult > 0)
            {
                result.HttpCode = 200;
                result.Message = "联系人信息添加成功！";
                result.Model1 = new AddressByPageResponse(AddressFunc.Instance.SelectAddrById(Addressresult));
            }
            else
            {
                result.HttpCode = 300;
                result.Message = "联系人信息添加失败！";
            }
            return result;
        }
        /// <summary>
        ///  删除联系人信息
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
                result.Message = "联系人删除成功！";
            }
            else
            {
                result.HttpCode = 300;
                result.Message = "联系人删除失败！";
            }
            return result;
        }

        /// <summary>
        /// 联系人信息修改
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public ResultJsonModel<AddressByPageResponse> UpdateAddr(UpdateAddressRequest request)
        {
            ResultJsonModel<AddressByPageResponse> result = new ResultJsonModel<AddressByPageResponse>();
            var Addressresult = AddressFunc.Instance.Update(new Address { Id = request.Id, ContactName = request.ContactName, ContactPhone = request.ContactPhone, AddrArea = request.AddrArea, AddrDetail = request.AddrDetail });
            if (Addressresult)
            {
                result.HttpCode = 200;
                result.Message = "联系人信息修改成功！";
                result.Model1 = new AddressByPageResponse(AddressFunc.Instance.SelectAddrById(request.Id));
            }
            else
            {
                result.HttpCode = 300;
                result.Message = "联系人信息修改失败！";
            }
            return result;
        }
        #endregion

        #region 发票方法
        /// <summary>
        /// 设置为默认发票
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ResultJson UpInvoiceTime(UpdateInvoiceTimeRequest request)
        {
            ResultJson result = new ResultJson();
            var Addressresult = InvoiceFunc.Instance.UpdateModel(new Invoice { Id = request.Id, InvoiceTime = DateTime.Now });
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
        /// 添加发票信息
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public ResultJsonModel<InvoiceResponse> InvoiceAdd(UpdateInvoiceRequest request)
        {
            ResultJsonModel<InvoiceResponse> result = new ResultJsonModel<InvoiceResponse>();
            var userGuid = CookieOper.Instance.GetUserGuid();
            var user = MemCacheHelper2.Instance.Cache.GetModel<User>("UserGuID_" + userGuid);
            var Addressresult = InvoiceFunc.Instance.InsertModelReturnkey(new Invoice { Address = request.Address, BankAccount = request.BankAccount, DutyParagraph = request.DutyParagraph, MobliePhone = request.MobiePhone, Title = request.Title, OpeningBank = request.OpeningBank, TypeInvoice = request.TypeInvoice, UserId = user.Id });
            if (Addressresult > 0)
            {
                result.HttpCode = 200;
                result.Message = "发票信息添加成功！";
                result.Model1 = new InvoiceResponse(InvoiceFunc.Instance.SelectById(Addressresult));
            }
            else
            {
                result.HttpCode = 300;
                result.Message = "发票信息添加失败！";
            }
            return result;
        }

        /// <summary>
        ///  删除发票信息
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public ResultJson DeleteInvoice(DeleteInvoiceRequest request)
        {
            ResultJson result = new ResultJson();
            var Addressresult = InvoiceFunc.Instance.DeleteById(request.Id);
            if (Addressresult)
            {
                result.HttpCode = 200;
                result.Message = "发票删除成功！";
            }
            else
            {
                result.HttpCode = 300;
                result.Message = "发票删除失败！";
            }
            return result;
        }

        /// <summary>
        /// 发票信息修改
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public ResultJsonModel<InvoiceResponse> InvoiceEdit(UpdateInvoiceRequest request)
        {
            ResultJsonModel<InvoiceResponse> result = new ResultJsonModel<InvoiceResponse>();
            var Addressresult = InvoiceFunc.Instance.UpdateModel(new Invoice { Id = request.Id, Address = request.Address, BankAccount = request.BankAccount, DutyParagraph = request.DutyParagraph, MobliePhone = request.MobiePhone, Title = request.Title, OpeningBank = request.OpeningBank, TypeInvoice = request.TypeInvoice });
            if (Addressresult)
            {
                result.HttpCode = 200;
                result.Message = "发票信息修改成功！";
                result.Model1 = new InvoiceResponse(InvoiceFunc.Instance.SelectById(request.Id));
            }
            else
            {
                result.HttpCode = 300;
                result.Message = "发票信息修改失败！";
            }
            return result;
        }
        #endregion

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

