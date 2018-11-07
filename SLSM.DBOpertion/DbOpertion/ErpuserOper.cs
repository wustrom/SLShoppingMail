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
    public partial class ErpuserOper : SingleTon<ErpuserOper>
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
            var delete = new LambdaDelete<Erpuser>();
            delete.Where(p => p.ErproleId == KeyId);
            return delete.GetDeleteResult(connection, transaction);
        }

        /// <summary>
        /// 根据模型删除数据
        /// </summary>
        /// <param name="model">模型</param>
        /// <param name="connection">连接</param>
        /// <param name="transaction">事务</param>
        /// <returns>是否成功</returns>
        public bool DeleteModel(Erpuser model = null, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var delete = new LambdaDelete<Erpuser>();
            if (model != null)
            {
                if (!model.ErproleId.IsNullOrEmpty())
                {
                    delete.Where(p => p.ErproleId == model.ErproleId);
                }
                if (!model.ErproleName.IsNullOrEmpty())
                {
                    delete.Where(p => p.ErproleName == model.ErproleName);
                }
                if (!model.ERProlePower.IsNullOrEmpty())
                {
                    delete.Where(p => p.ERProlePower == model.ERProlePower);
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
        public bool Update(Erpuser model, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var update = new LambdaUpdate<Erpuser>();
            if (!model.ErproleId.IsNullOrEmpty())
            {
                update.Where(p => p.ErproleId == model.ErproleId);
            }
            if (!model.ErproleName.IsNullOrEmpty())
            {
                update.Set(p => p.ErproleName == model.ErproleName);
            }
            if (!model.ERProlePower.IsNullOrEmpty())
            {
                update.Set(p => p.ERProlePower == model.ERProlePower);
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
        public bool Insert(Erpuser model, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var insert = new LambdaInsert<Erpuser>();
            if (!model.ErproleName.IsNullOrEmpty())
            {
                insert.Insert(p => p.ErproleName == model.ErproleName);
            }
            if (!model.ERProlePower.IsNullOrEmpty())
            {
                insert.Insert(p => p.ERProlePower == model.ERProlePower);
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
        public int InsertReturnKey(Erpuser model, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var insert = new LambdaInsert<Erpuser>();
            if (!model.ErproleName.IsNullOrEmpty())
            {
                insert.Insert(p => p.ErproleName == model.ErproleName);
            }
            if (!model.ERProlePower.IsNullOrEmpty())
            {
                insert.Insert(p => p.ERProlePower == model.ERProlePower);
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
        public List<Erpuser> SelectAll(Erpuser model = null, string SelectFiled = null, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var query = new LambdaQuery<Erpuser>();
            if (model != null)
            {
                if (!model.ErproleId.IsNullOrEmpty())
                {
                    query.Where(p => p.ErproleId == model.ErproleId);
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
                if (SelectFiled.Contains("erproleid,"))
                {
                    query.Select(p => new { p.ErproleId });
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
        public int SelectCount(Erpuser model = null, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var query = new LambdaQuery<Erpuser>();
            if (model != null)
            {
                if (!model.ErproleId.IsNullOrEmpty())
                {
                    query.Where(p => p.ErproleId == model.ErproleId);
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
        public Erpuser SelectById(int KeyId, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var query = new LambdaQuery<Erpuser>();
            query.Where(p => p.ErproleId == KeyId);
            return query.GetQueryList(connection, transaction).FirstOrDefault();
        }


        /// <summary>
        /// 根据主键筛选数据
        /// </summary>
        /// <param name="KeyId">主键Id</param>
        /// <param name="connection">连接</param>
        /// <param name="transaction">事务</param>
        /// <returns>是否成功</returns>
        public List<Erpuser> SelectByKeys(string Key,List<string> KeyIds, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var query = new LambdaQuery<Erpuser>();
            if("erproleid" == Key.ToLowerInvariant())
            {
                query.Where(p => p.ErproleId.In(KeyIds));
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
        public List<Erpuser> SelectByPage(string Key, int start, int PageSize, bool desc = true,Erpuser model = null, string SelectFiled = null, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var query = new LambdaQuery<Erpuser>();
            if (model != null)
            {
                if (!model.ErproleId.IsNullOrEmpty())
                {
                    query.Where(p => p.ErproleId == model.ErproleId);
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
                if (SelectFiled.Contains("erproleid,"))
                {
                    query.Select(p => new { p.ErproleId });
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
