using Common;
using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common.LambdaOpertion;
using Common.Extend;
using System.Data;
using Common.Extend.LambdaFunction;
using DbOpertion.Models;

namespace DbOpertion.Operation
{
    public partial class UserOper : SingleTon<UserOper>
    {
        /// <summary>
        /// 根据主键删除数据
        /// </summary>
        /// <param name="KeyId">主键Id</param>
        /// <param name="connection">连接</param>
        /// <param name="transaction">事务</param>
        /// <returns>是否成功</returns>
        public bool DeleteById(int KeyId, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var delete = new LambdaDelete<User>();
            delete.Where(p => p.Id == KeyId);
            return delete.GetDeleteResult(connection, transaction);
        }

        /// <summary>
        /// 根据模型删除数据
        /// </summary>
        /// <param name="model">模型</param>
        /// <param name="connection">连接</param>
        /// <param name="transaction">事务</param>
        /// <returns>是否成功</returns>
        public bool DeleteModel(User model = null, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var delete = new LambdaDelete<User>();
            if (model != null)
            {
                if (!model.Id.IsNullOrEmpty())
                {
                    delete.Where(p => p.Id == model.Id);
                }
                if (!model.Sex.IsNullOrEmpty())
                {
                    delete.Where(p => p.Sex == model.Sex);
                }
                if (!model.Name.IsNullOrEmpty())
                {
                    delete.Where(p => p.Name == model.Name);
                }
                if (!model.PassWord.IsNullOrEmpty())
                {
                    delete.Where(p => p.PassWord == model.PassWord);
                }
                if (!model.Phone.IsNullOrEmpty())
                {
                    delete.Where(p => p.Phone == model.Phone);
                }
                if (!model.QQ.IsNullOrEmpty())
                {
                    delete.Where(p => p.QQ == model.QQ);
                }
                if (!model.WeChat.IsNullOrEmpty())
                {
                    delete.Where(p => p.WeChat == model.WeChat);
                }
                if (!model.CreateTime.IsNullOrEmpty())
                {
                    delete.Where(p => p.CreateTime == model.CreateTime);
                }
                if (!model.Discount.IsNullOrEmpty())
                {
                    delete.Where(p => p.Discount == model.Discount);
                }
                if (!model.Image.IsNullOrEmpty())
                {
                    delete.Where(p => p.Image == model.Image);
                }
                if (!model.CompanyName.IsNullOrEmpty())
                {
                    delete.Where(p => p.CompanyName == model.CompanyName);
                }
                if (!model.ConmpanyType.IsNullOrEmpty())
                {
                    delete.Where(p => p.ConmpanyType == model.ConmpanyType);
                }
                if (!model.CompanyPhone.IsNullOrEmpty())
                {
                    delete.Where(p => p.CompanyPhone == model.CompanyPhone);
                }
                if (!model.CompanyAddr.IsNullOrEmpty())
                {
                    delete.Where(p => p.CompanyAddr == model.CompanyAddr);
                }
                if (!model.Email.IsNullOrEmpty())
                {
                    delete.Where(p => p.Email == model.Email);
                }
                if (!model.ZipCode.IsNullOrEmpty())
                {
                    delete.Where(p => p.ZipCode == model.ZipCode);
                }
                if (!model.IsDelete.IsNullOrEmpty())
                {
                    delete.Where(p => p.IsDelete == model.IsDelete);
                }
            }
            return delete.GetDeleteResult(connection, transaction);
        }

        /// <summary>
        /// 根据模型更新
        /// </summary>
        /// <param name="model">模型</param>
        /// <param name="connection">连接</param>
        /// <param name="transaction">事务</param>
        /// <returns>是否成功</returns>
        public bool Update(User model, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var update = new LambdaUpdate<User>();
            if (!model.Id.IsNullOrEmpty())
            {
                update.Where(p => p.Id == model.Id);
            }
            if (!model.Sex.IsNullOrEmpty())
            {
                update.Set(p => p.Sex == model.Sex);
            }
            if (!model.Name.IsNullOrEmpty())
            {
                update.Set(p => p.Name == model.Name);
            }
            if (!model.PassWord.IsNullOrEmpty())
            {
                update.Set(p => p.PassWord == model.PassWord);
            }
            if (!model.Phone.IsNullOrEmpty())
            {
                update.Set(p => p.Phone == model.Phone);
            }
            if (!model.QQ.IsNullOrEmpty())
            {
                update.Set(p => p.QQ == model.QQ);
            }
            if (!model.WeChat.IsNullOrEmpty())
            {
                update.Set(p => p.WeChat == model.WeChat);
            }
            if (!model.CreateTime.IsNullOrEmpty())
            {
                update.Set(p => p.CreateTime == model.CreateTime);
            }
            if (!model.Discount.IsNullOrEmpty())
            {
                update.Set(p => p.Discount == model.Discount);
            }
            if (!model.Image.IsNullOrEmpty())
            {
                update.Set(p => p.Image == model.Image);
            }
            if (!model.CompanyName.IsNullOrEmpty())
            {
                update.Set(p => p.CompanyName == model.CompanyName);
            }
            if (!model.ConmpanyType.IsNullOrEmpty())
            {
                update.Set(p => p.ConmpanyType == model.ConmpanyType);
            }
            if (!model.CompanyPhone.IsNullOrEmpty())
            {
                update.Set(p => p.CompanyPhone == model.CompanyPhone);
            }
            if (!model.CompanyAddr.IsNullOrEmpty())
            {
                update.Set(p => p.CompanyAddr == model.CompanyAddr);
            }
            if (!model.Email.IsNullOrEmpty())
            {
                update.Set(p => p.Email == model.Email);
            }
            if (!model.ZipCode.IsNullOrEmpty())
            {
                update.Set(p => p.ZipCode == model.ZipCode);
            }
            if (!model.IsDelete.IsNullOrEmpty())
            {
                update.Set(p => p.IsDelete == model.IsDelete);
            }
            return update.GetUpdateResult(connection, transaction);
        }

        /// <summary>
        /// 根据模型插入
        /// </summary>
        /// <param name="model">模型</param>
        /// <param name="connection">连接</param>
        /// <param name="transaction">事务</param>
        /// <returns>是否成功</returns>
        public bool Insert(User model, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var insert = new LambdaInsert<User>();
            if (!model.Sex.IsNullOrEmpty())
            {
                insert.Insert(p => p.Sex == model.Sex);
            }
            if (!model.Name.IsNullOrEmpty())
            {
                insert.Insert(p => p.Name == model.Name);
            }
            if (!model.PassWord.IsNullOrEmpty())
            {
                insert.Insert(p => p.PassWord == model.PassWord);
            }
            if (!model.Phone.IsNullOrEmpty())
            {
                insert.Insert(p => p.Phone == model.Phone);
            }
            if (!model.QQ.IsNullOrEmpty())
            {
                insert.Insert(p => p.QQ == model.QQ);
            }
            if (!model.WeChat.IsNullOrEmpty())
            {
                insert.Insert(p => p.WeChat == model.WeChat);
            }
            if (!model.CreateTime.IsNullOrEmpty())
            {
                insert.Insert(p => p.CreateTime == model.CreateTime);
            }
            if (!model.Discount.IsNullOrEmpty())
            {
                insert.Insert(p => p.Discount == model.Discount);
            }
            if (!model.Image.IsNullOrEmpty())
            {
                insert.Insert(p => p.Image == model.Image);
            }
            if (!model.CompanyName.IsNullOrEmpty())
            {
                insert.Insert(p => p.CompanyName == model.CompanyName);
            }
            if (!model.ConmpanyType.IsNullOrEmpty())
            {
                insert.Insert(p => p.ConmpanyType == model.ConmpanyType);
            }
            if (!model.CompanyPhone.IsNullOrEmpty())
            {
                insert.Insert(p => p.CompanyPhone == model.CompanyPhone);
            }
            if (!model.CompanyAddr.IsNullOrEmpty())
            {
                insert.Insert(p => p.CompanyAddr == model.CompanyAddr);
            }
            if (!model.Email.IsNullOrEmpty())
            {
                insert.Insert(p => p.Email == model.Email);
            }
            if (!model.ZipCode.IsNullOrEmpty())
            {
                insert.Insert(p => p.ZipCode == model.ZipCode);
            }
            if (!model.IsDelete.IsNullOrEmpty())
            {
                insert.Insert(p => p.IsDelete == model.IsDelete);
            }
            return insert.GetInsertResult(connection, transaction) >= 0;
        }

        /// <summary>
        /// 根据模型插入
        /// </summary>
        /// <param name="model">模型</param>
        /// <param name="connection">连接</param>
        /// <param name="transaction">事务</param>
        /// <returns>是否成功</returns>
        public int InsertReturnKey(User model, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var insert = new LambdaInsert<User>();
            if (!model.Sex.IsNullOrEmpty())
            {
                insert.Insert(p => p.Sex == model.Sex);
            }
            if (!model.Name.IsNullOrEmpty())
            {
                insert.Insert(p => p.Name == model.Name);
            }
            if (!model.PassWord.IsNullOrEmpty())
            {
                insert.Insert(p => p.PassWord == model.PassWord);
            }
            if (!model.Phone.IsNullOrEmpty())
            {
                insert.Insert(p => p.Phone == model.Phone);
            }
            if (!model.QQ.IsNullOrEmpty())
            {
                insert.Insert(p => p.QQ == model.QQ);
            }
            if (!model.WeChat.IsNullOrEmpty())
            {
                insert.Insert(p => p.WeChat == model.WeChat);
            }
            if (!model.CreateTime.IsNullOrEmpty())
            {
                insert.Insert(p => p.CreateTime == model.CreateTime);
            }
            if (!model.Discount.IsNullOrEmpty())
            {
                insert.Insert(p => p.Discount == model.Discount);
            }
            if (!model.Image.IsNullOrEmpty())
            {
                insert.Insert(p => p.Image == model.Image);
            }
            if (!model.CompanyName.IsNullOrEmpty())
            {
                insert.Insert(p => p.CompanyName == model.CompanyName);
            }
            if (!model.ConmpanyType.IsNullOrEmpty())
            {
                insert.Insert(p => p.ConmpanyType == model.ConmpanyType);
            }
            if (!model.CompanyPhone.IsNullOrEmpty())
            {
                insert.Insert(p => p.CompanyPhone == model.CompanyPhone);
            }
            if (!model.CompanyAddr.IsNullOrEmpty())
            {
                insert.Insert(p => p.CompanyAddr == model.CompanyAddr);
            }
            if (!model.Email.IsNullOrEmpty())
            {
                insert.Insert(p => p.Email == model.Email);
            }
            if (!model.ZipCode.IsNullOrEmpty())
            {
                insert.Insert(p => p.ZipCode == model.ZipCode);
            }
            if (!model.IsDelete.IsNullOrEmpty())
            {
                insert.Insert(p => p.IsDelete == model.IsDelete);
            }
            return insert.GetInsertResult(connection, transaction);
        }

        /// <summary>
        /// 筛选全部数据
        /// </summary>
        /// <param name="model">模型</param>
        /// <param name="connection">连接</param>
        /// <param name="transaction">事务</param>
        /// <returns>对象列表</returns>
        public List<User> SelectAll(User model = null, string SelectFiled = null, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var query = new LambdaQuery<User>();
            if (model != null)
            {
                if (!model.Id.IsNullOrEmpty())
                {
                    query.Where(p => p.Id == model.Id);
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
                if (!model.Discount.IsNullOrEmpty())
                {
                    query.Where(p => p.Discount == model.Discount);
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
                if (!model.IsDelete.IsNullOrEmpty())
                {
                    query.Where(p => p.IsDelete == model.IsDelete);
                }
            }
            if (SelectFiled != null)
            {
                SelectFiled = SelectFiled.ToLowerInvariant();
                if (SelectFiled.Contains("id,"))
                {
                    query.Select(p => new { p.Id });
                }
                if (SelectFiled.Contains("sex,"))
                {
                    query.Select(p => new { p.Sex });
                }
                if (SelectFiled.Contains("name,"))
                {
                    query.Select(p => new { p.Name });
                }
                if (SelectFiled.Contains("password,"))
                {
                    query.Select(p => new { p.PassWord });
                }
                if (SelectFiled.Contains("phone,"))
                {
                    query.Select(p => new { p.Phone });
                }
                if (SelectFiled.Contains("qq,"))
                {
                    query.Select(p => new { p.QQ });
                }
                if (SelectFiled.Contains("wechat,"))
                {
                    query.Select(p => new { p.WeChat });
                }
                if (SelectFiled.Contains("createtime,"))
                {
                    query.Select(p => new { p.CreateTime });
                }
                if (SelectFiled.Contains("discount,"))
                {
                    query.Select(p => new { p.Discount });
                }
                if (SelectFiled.Contains("image,"))
                {
                    query.Select(p => new { p.Image });
                }
                if (SelectFiled.Contains("companyname,"))
                {
                    query.Select(p => new { p.CompanyName });
                }
                if (SelectFiled.Contains("conmpanytype,"))
                {
                    query.Select(p => new { p.ConmpanyType });
                }
                if (SelectFiled.Contains("companyphone,"))
                {
                    query.Select(p => new { p.CompanyPhone });
                }
                if (SelectFiled.Contains("companyaddr,"))
                {
                    query.Select(p => new { p.CompanyAddr });
                }
                if (SelectFiled.Contains("email,"))
                {
                    query.Select(p => new { p.Email });
                }
                if (SelectFiled.Contains("zipcode,"))
                {
                    query.Select(p => new { p.ZipCode });
                }
                if (SelectFiled.Contains("isdelete,"))
                {
                    query.Select(p => new { p.IsDelete });
                }
            }
            return query.GetQueryList(connection, transaction);
        }

        /// <summary>
        /// 数据条数
        /// </summary>
        /// <param name="model">模型</param>
        /// <param name="connection">连接</param>
        /// <param name="transaction">事务</param>
        /// <returns>对象列表</returns>
        public int SelectCount(User model = null, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var query = new LambdaQuery<User>();
            if (model != null)
            {
                if (!model.Id.IsNullOrEmpty())
                {
                    query.Where(p => p.Id == model.Id);
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
                if (!model.Discount.IsNullOrEmpty())
                {
                    query.Where(p => p.Discount == model.Discount);
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
                if (!model.IsDelete.IsNullOrEmpty())
                {
                    query.Where(p => p.IsDelete == model.IsDelete);
                }
            }
            return query.GetQueryCount(connection, transaction);
        }

        /// <summary>
        /// 根据主键筛选数据
        /// </summary>
        /// <param name="KeyId">主键Id</param>
        /// <param name="connection">连接</param>
        /// <param name="transaction">事务</param>
        /// <returns>是否成功</returns>
        public User SelectById(int KeyId, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var query = new LambdaQuery<User>();
            query.Where(p => p.Id == KeyId);
            return query.GetQueryList(connection, transaction).FirstOrDefault();
        }


        /// <summary>
        /// 根据主键筛选数据
        /// </summary>
        /// <param name="KeyId">主键Id</param>
        /// <param name="connection">连接</param>
        /// <param name="transaction">事务</param>
        /// <returns>是否成功</returns>
        public List<User> SelectByKeys(string Key,List<string> KeyIds, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var query = new LambdaQuery<User>();
            if("id" == Key.ToLowerInvariant())
            {
                query.Where(p => p.Id.In(KeyIds));
            }
            if("sex" == Key.ToLowerInvariant())
            {
                query.Where(p => p.Sex.In(KeyIds));
            }
            if("name" == Key.ToLowerInvariant())
            {
                query.Where(p => p.Name.In(KeyIds));
            }
            if("password" == Key.ToLowerInvariant())
            {
                query.Where(p => p.PassWord.In(KeyIds));
            }
            if("phone" == Key.ToLowerInvariant())
            {
                query.Where(p => p.Phone.In(KeyIds));
            }
            if("qq" == Key.ToLowerInvariant())
            {
                query.Where(p => p.QQ.In(KeyIds));
            }
            if("wechat" == Key.ToLowerInvariant())
            {
                query.Where(p => p.WeChat.In(KeyIds));
            }
            if("createtime" == Key.ToLowerInvariant())
            {
                query.Where(p => p.CreateTime.In(KeyIds));
            }
            if("discount" == Key.ToLowerInvariant())
            {
                query.Where(p => p.Discount.In(KeyIds));
            }
            if("image" == Key.ToLowerInvariant())
            {
                query.Where(p => p.Image.In(KeyIds));
            }
            if("companyname" == Key.ToLowerInvariant())
            {
                query.Where(p => p.CompanyName.In(KeyIds));
            }
            if("conmpanytype" == Key.ToLowerInvariant())
            {
                query.Where(p => p.ConmpanyType.In(KeyIds));
            }
            if("companyphone" == Key.ToLowerInvariant())
            {
                query.Where(p => p.CompanyPhone.In(KeyIds));
            }
            if("companyaddr" == Key.ToLowerInvariant())
            {
                query.Where(p => p.CompanyAddr.In(KeyIds));
            }
            if("email" == Key.ToLowerInvariant())
            {
                query.Where(p => p.Email.In(KeyIds));
            }
            if("zipcode" == Key.ToLowerInvariant())
            {
                query.Where(p => p.ZipCode.In(KeyIds));
            }
            if("isdelete" == Key.ToLowerInvariant())
            {
                query.Where(p => p.IsDelete.In(KeyIds));
            }
            return query.GetQueryList(connection, transaction);
        }

        /// <summary>
        /// 根据分页筛选数据
        /// </summary>
        /// <param name="Key">主键</param>
        /// <param name="start">开始数据</param>
        /// <param name="PageSize">页面长度</param>
        /// <param name="desc">排序</param>
        /// <param name="model">对象</param>
        /// <param name="connection">连接</param>
        /// <param name="transaction">事务</param>
        /// <returns>对象列表</returns>
        public List<User> SelectByPage(string Key, int start, int PageSize, bool desc = true,User model = null, string SelectFiled = null, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var query = new LambdaQuery<User>();
            if (model != null)
            {
                if (!model.Id.IsNullOrEmpty())
                {
                    query.Where(p => p.Id == model.Id);
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
                if (!model.Discount.IsNullOrEmpty())
                {
                    query.Where(p => p.Discount == model.Discount);
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
                if (!model.IsDelete.IsNullOrEmpty())
                {
                    query.Where(p => p.IsDelete == model.IsDelete);
                }
            }
            if (SelectFiled != null)
            {
                SelectFiled = SelectFiled.ToLowerInvariant();
                if (SelectFiled.Contains("id,"))
                {
                    query.Select(p => new { p.Id });
                }
                if (SelectFiled.Contains("sex,"))
                {
                    query.Select(p => new { p.Sex });
                }
                if (SelectFiled.Contains("name,"))
                {
                    query.Select(p => new { p.Name });
                }
                if (SelectFiled.Contains("password,"))
                {
                    query.Select(p => new { p.PassWord });
                }
                if (SelectFiled.Contains("phone,"))
                {
                    query.Select(p => new { p.Phone });
                }
                if (SelectFiled.Contains("qq,"))
                {
                    query.Select(p => new { p.QQ });
                }
                if (SelectFiled.Contains("wechat,"))
                {
                    query.Select(p => new { p.WeChat });
                }
                if (SelectFiled.Contains("createtime,"))
                {
                    query.Select(p => new { p.CreateTime });
                }
                if (SelectFiled.Contains("discount,"))
                {
                    query.Select(p => new { p.Discount });
                }
                if (SelectFiled.Contains("image,"))
                {
                    query.Select(p => new { p.Image });
                }
                if (SelectFiled.Contains("companyname,"))
                {
                    query.Select(p => new { p.CompanyName });
                }
                if (SelectFiled.Contains("conmpanytype,"))
                {
                    query.Select(p => new { p.ConmpanyType });
                }
                if (SelectFiled.Contains("companyphone,"))
                {
                    query.Select(p => new { p.CompanyPhone });
                }
                if (SelectFiled.Contains("companyaddr,"))
                {
                    query.Select(p => new { p.CompanyAddr });
                }
                if (SelectFiled.Contains("email,"))
                {
                    query.Select(p => new { p.Email });
                }
                if (SelectFiled.Contains("zipcode,"))
                {
                    query.Select(p => new { p.ZipCode });
                }
                if (SelectFiled.Contains("isdelete,"))
                {
                    query.Select(p => new { p.IsDelete });
                }
            }
            if (Key != null)
            {
                query.OrderByKey(Key, desc);
            }
            return query.GetQueryPageList(start, PageSize, connection, transaction);
        }
    }
}
