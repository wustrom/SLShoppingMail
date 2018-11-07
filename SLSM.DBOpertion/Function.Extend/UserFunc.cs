using Aliyun.Acs.Dysmsapi.Model.V20170525;
using AliyunHelper.SendMail;
using Common;
using Common.Extend;
using Common.Helper;
using DbOpertion.Models;
using DbOpertion.Operation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbOpertion.Function
{
    /// <summary>
    /// 用户方法
    /// </summary>
    public partial class UserFunc : SingleTon<UserFunc>
    {
        /// <summary>
        /// 根据Id筛选
        /// </summary>
        /// <param name="Phone">手机号码</param>
        /// <param name="用户名">Name</param>
        /// <returns></returns>
        public User CreateByPhone(string Phone, string Name)
        {
            var user = UserOper.Instance.SelectAll(new User { Phone = Phone, IsDelete = false }).FirstOrDefault();
            if (user != null)
            {
                return user;
            }
            else
            {
                user = new User { Sex = true, CreateTime = DateTime.Now, Discount = 1, Name = Name, IsDelete = false, Phone = Phone, CompanyPhone = Phone };
                if (UserOper.Instance.Insert(user))
                {
                    return UserOper.Instance.SelectAll(new User { Phone = Phone }).FirstOrDefault();
                }
                else
                {
                    return null;
                }
            }
        }

        /// <summary>
        /// 根据Id插入
        /// </summary>
        /// <param name="Id">用户Id</param>
        /// <returns></returns>
        public string InsertModel(User model)
        {
            //if (UserOper.Instance.SelectAll(new User { Name = model.Name, IsDelete = false }).Count != 0)
            //{
            //    return "昵称已存在！";
            //}
            if (UserOper.Instance.SelectAll(new User { Phone = model.Phone, IsDelete = false }).Count != 0)
            {
                return "手机号码已存在！";
            }
            //if (UserOper.Instance.SelectAll(new User { Email = model.Email, IsDelete = false }).Count != 0)
            //{
            //    return "电子邮箱已存在！";
            //}
            if (UserOper.Instance.Insert(model))
            {
                return "成功！";
            }
            else
            {
                return "插入失败！";
            }
        }

        /// <summary>
        /// 根据Id更新
        /// </summary>
        /// <param name="Id">用户Id</param>
        /// <returns></returns>
        public string UpdateModel(User model)
        {
            //if (UserOper.Instance.SelectAllNotThisUser(new User { Name = model.Name, Id = model.Id, IsDelete = false }).Count != 0)
            //{
            //    return "昵称已存在！";
            //}
            if (UserOper.Instance.SelectAllNotThisUser(new User { Phone = model.Phone, Id = model.Id, IsDelete = false }).Count != 0)
            {
                return "手机号码已存在！";
            }
            //if (UserOper.Instance.SelectAllNotThisUser(new User { Email = model.Email, Id = model.Id, IsDelete = false }).Count != 0)
            //{
            //    return "电子邮箱已存在！";
            //}
            if (UserOper.Instance.Update(model))
            {
                return "成功！";
            }
            else
            {
                return "插入失败！";
            }
        }


        /// <summary>
        /// 根据Id删除
        /// </summary>
        /// <param name="Id">用户Id</param>
        /// <returns></returns>
        public bool DeleteModel(int UserID)
        {
            return UserOper.Instance.Update(new User { Id = UserID, IsDelete = true });
        }

        /// <summary>
        /// 分页筛选未删除用户
        /// </summary>
        /// <param name="pageNo">页码</param>
        /// <param name="pageSize">页面大小</param>
        /// <returns></returns>
        public List<User> SelectUserByPage(int pageNo, int pageSize)
        {
            return UserOper.Instance.SelectByPage("Id", (pageNo - 1) * pageSize, pageSize, true, new User { IsDelete = false });
        }

        /// <summary>
        /// 筛选全部未删除用户数目
        /// </summary>
        /// <returns></returns>
        public int SelectAllUserCount()
        {
            return UserOper.Instance.SelectCount(new User { IsDelete = false });
        }

        /// <summary>
        /// 筛选用户地址
        /// </summary>
        /// <param name="Start">开始数据条数</param>
        /// <param name="PageSize">页面大小</param>
        /// <param name="UserId">用户Id</param>
        /// <returns></returns>
        public List<Address> SelectAddress(int Start, int PageSize, int UserId)
        {
            return AddressOper.Instance.SelectByPage("DefaultTime", Start, PageSize, true, new Address { UserId = UserId });
        }

        /// <summary>
        /// 筛选用户地址个数
        /// </summary>
        /// <param name="UserId">用户Id</param>
        /// <returns></returns>
        public int SelectAddressCount(int UserId)
        {
            return AddressOper.Instance.SelectCount(new Address { UserId = UserId });
        }

        /// <summary>
        /// 设置用户手机验证码
        /// </summary>
        /// <param name="Phone">手机号码</param>
        /// <returns></returns>
        public string SetUserPhoneCodeCached(string Phone)
        {
            //设置验证码是否能重新发送
            if (MemCacheHelper2.Instance.Cache.Add("ResetPhoneCode_" + Phone, true, DateTime.Now.AddMinutes(1)))
            {
                var randNum = RandHelper.Instance.Number(4);
                //发送手机验证码
                SendSmsResponse Email = SendMail.Instance.SendEmail(Phone, randNum, Enum_SendEmailCode.AuthenticationCode);
                if (Email.Code.ToUpper() == "OK")
                {
                    //储存手机验证码
                    if (MemCacheHelper2.Instance.Cache.Set("UserPhoneCode_" + Phone, randNum, DateTime.Now.AddMinutes(30)))
                    {

                        return "手机验证码发送成功！";
                    }
                    else
                    {
                        return "手机验证码储存失败，请联系管理员！";
                    }
                }
                else
                {
                    return "阿里云错误：" + Email.Message;
                }

            }
            else
            {
                return "还未到1分钟，验证码不能重新发送！";
            }

        }

        /// <summary>
        /// 用户登陆
        /// </summary>
        /// <param name="Phone">手机号码</param>
        /// <param name="PhoneCode">手机验证码</param>
        /// <returns></returns>
        public Tuple<User, string, bool> LoginUser(string Phone, string PhoneCode, string Password)
        {
            var CacheCode = MemCacheHelper2.Instance.Cache.Get("UserPhoneCode_" + Phone).ParseString();
            if (Phone.IsNullOrEmpty())
            {
                return new Tuple<User, string, bool>(item1: null, item2: "手机号不正确！", item3: false);
            }
            #region 电话号码测试
            if (Phone == "18811111111" || Phone == "18822222222" || Phone == "18833333333" || Phone == "18844444444" || Phone == "18855555555" || Phone == "18866666666" || Phone == "18877777777" || Phone == "18888888888")
            {
                var user2 = UserOper.Instance.SelectAll(new User { Phone = Phone, IsDelete = false }).FirstOrDefault();
                if (PhoneCode == "000000")
                {
                    if (user2 != null)
                    {
                        MemCacheHelper2.Instance.Cache.Delete("UserPhoneCode_" + Phone);
                        return new Tuple<User, string, bool>(item1: user2, item2: "请输入手机验证码！", item3: false);
                    }
                    else
                    {
                        if (UserOper.Instance.Insert(new User { Phone = Phone, Sex = true, Name = Phone, CreateTime = DateTime.Now }))
                        {
                            user2 = UserOper.Instance.SelectAll(new User { Phone = Phone, IsDelete = false }).FirstOrDefault();
                            MemCacheHelper2.Instance.Cache.Delete("UserPhoneCode_" + Phone);
                            return new Tuple<User, string, bool>(item1: user2, item2: "请输入手机验证码！", item3: true);
                        }
                        else
                        {
                            return new Tuple<User, string, bool>(item1: null, item2: "请重新登入！", item3: false);
                        }
                    }
                }
            }
            #endregion

            #region 手机验证码
            var user = UserOper.Instance.SelectAll(new User { Phone = Phone, IsDelete = false }).FirstOrDefault();

            #region 密码登入成功
            if (user != null && Password != null && user.PassWord != null && user.PassWord.Trim().ToLower() == Password.Trim().ToLower())
            {
                MemCacheHelper2.Instance.Cache.Delete("UserPhoneCode_" + Phone);
                return new Tuple<User, string, bool>(item1: user, item2: "登入成功！", item3: false);
            }
            #endregion

            #region 如果手机验证码与缓存验证码为空，密码不为空则登入失败
            if (CacheCode == null || PhoneCode == null)
            {
                if (Password != null)
                {
                    return new Tuple<User, string, bool>(item1: null, item2: "密码不正确！", item3: false);
                }
                else if (CacheCode == null)
                {
                    return new Tuple<User, string, bool>(item1: null, item2: "请发送手机验证码！", item3: false);
                }
                else{
                    return new Tuple<User, string, bool>(item1: null, item2: "请输入手机验证码！", item3: false);
                }
            }
            #endregion

            #region 手机登入
            if (CacheCode.Trim().ToLower() == PhoneCode.Trim().ToLower())
            {
                if (user != null)
                {
                    MemCacheHelper2.Instance.Cache.Delete("UserPhoneCode_" + Phone);
                    return new Tuple<User, string, bool>(item1: user, item2: "登入成功！", item3: false);
                }
                else
                {
                    #region 添加用户资料
                    if (UserOper.Instance.Insert(new User { Phone = Phone, Sex = true, Name = Phone, CreateTime = DateTime.Now, PassWord = "123456" }))
                    {
                        user = UserOper.Instance.SelectAll(new User { Phone = Phone, IsDelete = false }).FirstOrDefault();
                        MemCacheHelper2.Instance.Cache.Delete("UserPhoneCode_" + Phone);
                        return new Tuple<User, string, bool>(item1: user, item2: "登入成功！", item3: true);
                    }
                    else
                    {
                        return new Tuple<User, string, bool>(item1: null, item2: "请重新登入！", item3: false);
                    }
                    #endregion
                }
            }
            else
            {
                return new Tuple<User, string, bool>(item1: null, item2: "手机验证码不正确！", item3: false);
            }
            #endregion

            #endregion
        }

        /// <summary>
        /// 更新用户信息
        /// </summary>
        /// <param name="user">用户模型</param>
        /// <returns></returns>
        public bool UpdateUser(User user)
        {
            return UserOper.Instance.Update(user);
        }
    }
}
