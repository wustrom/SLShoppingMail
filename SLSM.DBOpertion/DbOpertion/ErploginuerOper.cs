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
    public partial class ErploginuerOper : SingleTon<ErploginuerOper>
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
            var delete = new LambdaDelete<Erploginuer>();
            delete.Where(p => p.erpLoginId == KeyId);
            return delete.GetDeleteResult(connection, transaction);
        }

        /// <summary>
        /// 根据模型删除数据
        /// </summary>
        /// <param name="model">模型</param>
        /// <param name="connection">连接</param>
        /// <param name="transaction">事务</param>
        /// <returns>是否成功</returns>
        public bool DeleteModel(Erploginuer model = null, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var delete = new LambdaDelete<Erploginuer>();
            if (model != null)
            {
                if (!model.erpLoginId.IsNullOrEmpty())
                {
                    delete.Where(p => p.erpLoginId == model.erpLoginId);
                }
                if (!model.ErproleId.IsNullOrEmpty())
                {
                    delete.Where(p => p.ErproleId == model.ErproleId);
                }
                if (!model.erpLoginName.IsNullOrEmpty())
                {
                    delete.Where(p => p.erpLoginName == model.erpLoginName);
                }
                if (!model.erpLoginPwd.IsNullOrEmpty())
                {
                    delete.Where(p => p.erpLoginPwd == model.erpLoginPwd);
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
        public bool Update(Erploginuer model, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var update = new LambdaUpdate<Erploginuer>();
            if (!model.erpLoginId.IsNullOrEmpty())
            {
                update.Where(p => p.erpLoginId == model.erpLoginId);
            }
            if (!model.ErproleId.IsNullOrEmpty())
            {
                update.Set(p => p.ErproleId == model.ErproleId);
            }
            if (!model.erpLoginName.IsNullOrEmpty())
            {
                update.Set(p => p.erpLoginName == model.erpLoginName);
            }
            if (!model.erpLoginPwd.IsNullOrEmpty())
            {
                update.Set(p => p.erpLoginPwd == model.erpLoginPwd);
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
        public bool Insert(Erploginuer model, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var insert = new LambdaInsert<Erploginuer>();
            if (!model.ErproleId.IsNullOrEmpty())
            {
                insert.Insert(p => p.ErproleId == model.ErproleId);
            }
            if (!model.erpLoginName.IsNullOrEmpty())
            {
                insert.Insert(p => p.erpLoginName == model.erpLoginName);
            }
            if (!model.erpLoginPwd.IsNullOrEmpty())
            {
                insert.Insert(p => p.erpLoginPwd == model.erpLoginPwd);
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
        public int InsertReturnKey(Erploginuer model, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var insert = new LambdaInsert<Erploginuer>();
            if (!model.ErproleId.IsNullOrEmpty())
            {
                insert.Insert(p => p.ErproleId == model.ErproleId);
            }
            if (!model.erpLoginName.IsNullOrEmpty())
            {
                insert.Insert(p => p.erpLoginName == model.erpLoginName);
            }
            if (!model.erpLoginPwd.IsNullOrEmpty())
            {
                insert.Insert(p => p.erpLoginPwd == model.erpLoginPwd);
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
        public List<Erploginuer> SelectAll(Erploginuer model = null, string SelectFiled = null, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var query = new LambdaQuery<Erploginuer>();
            if (model != null)
            {
                if (!model.erpLoginId.IsNullOrEmpty())
                {
                    query.Where(p => p.erpLoginId == model.erpLoginId);
                }
                if (!model.ErproleId.IsNullOrEmpty())
                {
                    query.Where(p => p.ErproleId == model.ErproleId);
                }
                if (!model.erpLoginName.IsNullOrEmpty())
                {
                    query.Where(p => p.erpLoginName == model.erpLoginName);
                }
                if (!model.erpLoginPwd.IsNullOrEmpty())
                {
                    query.Where(p => p.erpLoginPwd == model.erpLoginPwd);
                }
            }
            if (SelectFiled != null)
            {
                SelectFiled = SelectFiled.ToLowerInvariant();
                if (SelectFiled.Contains("erploginid,"))
                {
                    query.Select(p => new { p.erpLoginId });
                }
                if (SelectFiled.Contains("erproleid,"))
                {
                    query.Select(p => new { p.ErproleId });
                }
                if (SelectFiled.Contains("erploginname,"))
                {
                    query.Select(p => new { p.erpLoginName });
                }
                if (SelectFiled.Contains("erploginpwd,"))
                {
                    query.Select(p => new { p.erpLoginPwd });
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
        public int SelectCount(Erploginuer model = null, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var query = new LambdaQuery<Erploginuer>();
            if (model != null)
            {
                if (!model.erpLoginId.IsNullOrEmpty())
                {
                    query.Where(p => p.erpLoginId == model.erpLoginId);
                }
                if (!model.ErproleId.IsNullOrEmpty())
                {
                    query.Where(p => p.ErproleId == model.ErproleId);
                }
                if (!model.erpLoginName.IsNullOrEmpty())
                {
                    query.Where(p => p.erpLoginName == model.erpLoginName);
                }
                if (!model.erpLoginPwd.IsNullOrEmpty())
                {
                    query.Where(p => p.erpLoginPwd == model.erpLoginPwd);
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
        public Erploginuer SelectById(int KeyId, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var query = new LambdaQuery<Erploginuer>();
            query.Where(p => p.erpLoginId == KeyId);
            return query.GetQueryList(connection, transaction).FirstOrDefault();
        }


        /// <summary>
        /// 根据主键筛选数据
        /// </summary>
        /// <param name="KeyId">主键Id</param>
        /// <param name="connection">连接</param>
        /// <param name="transaction">事务</param>
        /// <returns>是否成功</returns>
        public List<Erploginuer> SelectByKeys(string Key,List<string> KeyIds, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var query = new LambdaQuery<Erploginuer>();
            if("erploginid" == Key.ToLowerInvariant())
            {
                query.Where(p => p.erpLoginId.In(KeyIds));
            }
            if("erproleid" == Key.ToLowerInvariant())
            {
                query.Where(p => p.ErproleId.In(KeyIds));
            }
            if("erploginname" == Key.ToLowerInvariant())
            {
                query.Where(p => p.erpLoginName.In(KeyIds));
            }
            if("erploginpwd" == Key.ToLowerInvariant())
            {
                query.Where(p => p.erpLoginPwd.In(KeyIds));
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
        public List<Erploginuer> SelectByPage(string Key, int start, int PageSize, bool desc = true,Erploginuer model = null, string SelectFiled = null, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var query = new LambdaQuery<Erploginuer>();
            if (model != null)
            {
                if (!model.erpLoginId.IsNullOrEmpty())
                {
                    query.Where(p => p.erpLoginId == model.erpLoginId);
                }
                if (!model.ErproleId.IsNullOrEmpty())
                {
                    query.Where(p => p.ErproleId == model.ErproleId);
                }
                if (!model.erpLoginName.IsNullOrEmpty())
                {
                    query.Where(p => p.erpLoginName == model.erpLoginName);
                }
                if (!model.erpLoginPwd.IsNullOrEmpty())
                {
                    query.Where(p => p.erpLoginPwd == model.erpLoginPwd);
                }
            }
            if (SelectFiled != null)
            {
                SelectFiled = SelectFiled.ToLowerInvariant();
                if (SelectFiled.Contains("erploginid,"))
                {
                    query.Select(p => new { p.erpLoginId });
                }
                if (SelectFiled.Contains("erproleid,"))
                {
                    query.Select(p => new { p.ErproleId });
                }
                if (SelectFiled.Contains("erploginname,"))
                {
                    query.Select(p => new { p.erpLoginName });
                }
                if (SelectFiled.Contains("erploginpwd,"))
                {
                    query.Select(p => new { p.erpLoginPwd });
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
