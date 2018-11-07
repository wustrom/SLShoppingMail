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
    public partial class Erplogin_Role_ViewOper : SingleTon<Erplogin_Role_ViewOper>
    {
        /// <summary>
        /// 筛选全部数据
        /// </summary>
        /// <param name="model">模型</param>
        /// <param name="connection">连接</param>
        /// <param name="transaction">事务</param>
        /// <returns>对象列表</returns>
        public List<Erplogin_Role_View> SelectAll(Erplogin_Role_View model = null, string SelectFiled = null, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var query = new LambdaQuery<Erplogin_Role_View>();
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
                if (!model.ErproleName.IsNullOrEmpty())
                {
                    query.Where(p => p.ErproleName == model.ErproleName);
                }
                if (!model.ERProlePower.IsNullOrEmpty())
                {
                    query.Where(p => p.ERProlePower == model.ERProlePower);
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
                if (SelectFiled.Contains("erprolename,"))
                {
                    query.Select(p => new { p.ErproleName });
                }
                if (SelectFiled.Contains("erprolepower,"))
                {
                    query.Select(p => new { p.ERProlePower });
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
        public int SelectCount(Erplogin_Role_View model = null, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var query = new LambdaQuery<Erplogin_Role_View>();
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
                if (!model.ErproleName.IsNullOrEmpty())
                {
                    query.Where(p => p.ErproleName == model.ErproleName);
                }
                if (!model.ERProlePower.IsNullOrEmpty())
                {
                    query.Where(p => p.ERProlePower == model.ERProlePower);
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
        public Erplogin_Role_View SelectById(int KeyId, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var query = new LambdaQuery<Erplogin_Role_View>();
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
        public List<Erplogin_Role_View> SelectByKeys(string Key,List<string> KeyIds, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var query = new LambdaQuery<Erplogin_Role_View>();
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
            if("erprolename" == Key.ToLowerInvariant())
            {
                query.Where(p => p.ErproleName.In(KeyIds));
            }
            if("erprolepower" == Key.ToLowerInvariant())
            {
                query.Where(p => p.ERProlePower.In(KeyIds));
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
        public List<Erplogin_Role_View> SelectByPage(string Key, int start, int PageSize, bool desc = true,Erplogin_Role_View model = null, string SelectFiled = null, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var query = new LambdaQuery<Erplogin_Role_View>();
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
                if (!model.ErproleName.IsNullOrEmpty())
                {
                    query.Where(p => p.ErproleName == model.ErproleName);
                }
                if (!model.ERProlePower.IsNullOrEmpty())
                {
                    query.Where(p => p.ERProlePower == model.ERProlePower);
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
                if (SelectFiled.Contains("erprolename,"))
                {
                    query.Select(p => new { p.ErproleName });
                }
                if (SelectFiled.Contains("erprolepower,"))
                {
                    query.Select(p => new { p.ERProlePower });
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
