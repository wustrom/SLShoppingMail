using Common;
using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common.LambdaOpertion;
using Common.Extend;
using System.Data;
using DbOpertion.Models;

namespace DbOpertion.Operation
{
    public partial class UserOper : SingleTon<UserOper>
    {
        /// <summary>
        /// 筛选全部数据不是这个用户
        /// </summary>
        /// <param name="model">模型</param>
        /// <param name="connection">连接</param>
        /// <param name="transaction">事务</param>
        /// <returns>对象列表</returns>
        public List<User> SelectAllNotThisUser(User model = null, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var query = new LambdaQuery<User>();
            if (model != null)
            {
                if (!model.Id.IsNullOrEmpty())
                {
                    query.Where(p => p.Id != model.Id);
                }
                if (!model.Sex.IsNullOrEmpty())
                {
                    query.Where(p => p.Sex == model.Sex);
                }
                if (!model.Name.IsNullOrEmpty())
                {
                    query.Where(p => p.Name == model.Name);
                }
                if (!model.PassWord.IsNullOrEmpty())
                {
                    query.Where(p => p.PassWord == model.PassWord);
                }
                if (!model.Phone.IsNullOrEmpty())
                {
                    query.Where(p => p.Phone == model.Phone);
                }
                if (!model.QQ.IsNullOrEmpty())
                {
                    query.Where(p => p.QQ == model.QQ);
                }
                if (!model.WeChat.IsNullOrEmpty())
                {
                    query.Where(p => p.WeChat == model.WeChat);
                }
                if (!model.CreateTime.IsNullOrEmpty())
                {
                    query.Where(p => p.CreateTime == model.CreateTime);
                }
                if (!model.Image.IsNullOrEmpty())
                {
                    query.Where(p => p.Image == model.Image);
                }
                if (!model.CompanyName.IsNullOrEmpty())
                {
                    query.Where(p => p.CompanyName == model.CompanyName);
                }
                if (!model.ConmpanyType.IsNullOrEmpty())
                {
                    query.Where(p => p.ConmpanyType == model.ConmpanyType);
                }
                if (!model.CompanyPhone.IsNullOrEmpty())
                {
                    query.Where(p => p.CompanyPhone == model.CompanyPhone);
                }
                if (!model.CompanyAddr.IsNullOrEmpty())
                {
                    query.Where(p => p.CompanyAddr == model.CompanyAddr);
                }
                if (!model.Email.IsNullOrEmpty())
                {
                    query.Where(p => p.Email == model.Email);
                }
                if (!model.ZipCode.IsNullOrEmpty())
                {
                    query.Where(p => p.ZipCode == model.ZipCode);
                }
                if (!model.Discount.IsNullOrEmpty())
                {
                    query.Where(p => p.Discount == model.Discount);
                }
                if (!model.IsDelete.IsNullOrEmpty())
                {
                    query.Where(p => p.IsDelete == model.IsDelete);
                }
            }
            return query.GetQueryList(connection, transaction);
        }

    }
}
