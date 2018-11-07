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
    public partial class Sales_ReturnOper : SingleTon<Sales_ReturnOper>
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
            var delete = new LambdaDelete<Sales_Return>();
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
        public bool DeleteModel(Sales_Return model = null, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var delete = new LambdaDelete<Sales_Return>();
            if (model != null)
            {
                if (!model.Id.IsNullOrEmpty())
                {
                    delete.Where(p => p.Id == model.Id);
                }
                if (!model.DetailId.IsNullOrEmpty())
                {
                    delete.Where(p => p.DetailId == model.DetailId);
                }
                if (!model.ReturnText.IsNullOrEmpty())
                {
                    delete.Where(p => p.ReturnText == model.ReturnText);
                }
                if (!model.ISRetuen.IsNullOrEmpty())
                {
                    delete.Where(p => p.ISRetuen == model.ISRetuen);
                }
                if (!model.ReturnReason.IsNullOrEmpty())
                {
                    delete.Where(p => p.ReturnReason == model.ReturnReason);
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
        public bool Update(Sales_Return model, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var update = new LambdaUpdate<Sales_Return>();
            if (!model.Id.IsNullOrEmpty())
            {
                update.Where(p => p.Id == model.Id);
            }
            if (!model.DetailId.IsNullOrEmpty())
            {
                update.Set(p => p.DetailId == model.DetailId);
            }
            if (!model.ReturnText.IsNullOrEmpty())
            {
                update.Set(p => p.ReturnText == model.ReturnText);
            }
            if (!model.ISRetuen.IsNullOrEmpty())
            {
                update.Set(p => p.ISRetuen == model.ISRetuen);
            }
            if (!model.ReturnReason.IsNullOrEmpty())
            {
                update.Set(p => p.ReturnReason == model.ReturnReason);
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
        public bool Insert(Sales_Return model, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var insert = new LambdaInsert<Sales_Return>();
            if (!model.DetailId.IsNullOrEmpty())
            {
                insert.Insert(p => p.DetailId == model.DetailId);
            }
            if (!model.ReturnText.IsNullOrEmpty())
            {
                insert.Insert(p => p.ReturnText == model.ReturnText);
            }
            if (!model.ISRetuen.IsNullOrEmpty())
            {
                insert.Insert(p => p.ISRetuen == model.ISRetuen);
            }
            if (!model.ReturnReason.IsNullOrEmpty())
            {
                insert.Insert(p => p.ReturnReason == model.ReturnReason);
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
        public int InsertReturnKey(Sales_Return model, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var insert = new LambdaInsert<Sales_Return>();
            if (!model.DetailId.IsNullOrEmpty())
            {
                insert.Insert(p => p.DetailId == model.DetailId);
            }
            if (!model.ReturnText.IsNullOrEmpty())
            {
                insert.Insert(p => p.ReturnText == model.ReturnText);
            }
            if (!model.ISRetuen.IsNullOrEmpty())
            {
                insert.Insert(p => p.ISRetuen == model.ISRetuen);
            }
            if (!model.ReturnReason.IsNullOrEmpty())
            {
                insert.Insert(p => p.ReturnReason == model.ReturnReason);
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
        public List<Sales_Return> SelectAll(Sales_Return model = null, string SelectFiled = null, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var query = new LambdaQuery<Sales_Return>();
            if (model != null)
            {
                if (!model.Id.IsNullOrEmpty())
                {
                    query.Where(p => p.Id == model.Id);
                }
                if (!model.DetailId.IsNullOrEmpty())
                {
                    query.Where(p => p.DetailId == model.DetailId);
                }
                if (!model.ReturnText.IsNullOrEmpty())
                {
                    query.Where(p => p.ReturnText == model.ReturnText);
                }
                if (!model.ISRetuen.IsNullOrEmpty())
                {
                    query.Where(p => p.ISRetuen == model.ISRetuen);
                }
                if (!model.ReturnReason.IsNullOrEmpty())
                {
                    query.Where(p => p.ReturnReason == model.ReturnReason);
                }
            }
            if (SelectFiled != null)
            {
                SelectFiled = SelectFiled.ToLowerInvariant();
                if (SelectFiled.Contains("id,"))
                {
                    query.Select(p => new { p.Id });
                }
                if (SelectFiled.Contains("detailid,"))
                {
                    query.Select(p => new { p.DetailId });
                }
                if (SelectFiled.Contains("returntext,"))
                {
                    query.Select(p => new { p.ReturnText });
                }
                if (SelectFiled.Contains("isretuen,"))
                {
                    query.Select(p => new { p.ISRetuen });
                }
                if (SelectFiled.Contains("returnreason,"))
                {
                    query.Select(p => new { p.ReturnReason });
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
        public int SelectCount(Sales_Return model = null, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var query = new LambdaQuery<Sales_Return>();
            if (model != null)
            {
                if (!model.Id.IsNullOrEmpty())
                {
                    query.Where(p => p.Id == model.Id);
                }
                if (!model.DetailId.IsNullOrEmpty())
                {
                    query.Where(p => p.DetailId == model.DetailId);
                }
                if (!model.ReturnText.IsNullOrEmpty())
                {
                    query.Where(p => p.ReturnText == model.ReturnText);
                }
                if (!model.ISRetuen.IsNullOrEmpty())
                {
                    query.Where(p => p.ISRetuen == model.ISRetuen);
                }
                if (!model.ReturnReason.IsNullOrEmpty())
                {
                    query.Where(p => p.ReturnReason == model.ReturnReason);
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
        public Sales_Return SelectById(int KeyId, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var query = new LambdaQuery<Sales_Return>();
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
        public List<Sales_Return> SelectByKeys(string Key,List<string> KeyIds, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var query = new LambdaQuery<Sales_Return>();
            if("id" == Key.ToLowerInvariant())
            {
                query.Where(p => p.Id.In(KeyIds));
            }
            if("detailid" == Key.ToLowerInvariant())
            {
                query.Where(p => p.DetailId.In(KeyIds));
            }
            if("returntext" == Key.ToLowerInvariant())
            {
                query.Where(p => p.ReturnText.In(KeyIds));
            }
            if("isretuen" == Key.ToLowerInvariant())
            {
                query.Where(p => p.ISRetuen.In(KeyIds));
            }
            if("returnreason" == Key.ToLowerInvariant())
            {
                query.Where(p => p.ReturnReason.In(KeyIds));
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
        public List<Sales_Return> SelectByPage(string Key, int start, int PageSize, bool desc = true,Sales_Return model = null, string SelectFiled = null, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var query = new LambdaQuery<Sales_Return>();
            if (model != null)
            {
                if (!model.Id.IsNullOrEmpty())
                {
                    query.Where(p => p.Id == model.Id);
                }
                if (!model.DetailId.IsNullOrEmpty())
                {
                    query.Where(p => p.DetailId == model.DetailId);
                }
                if (!model.ReturnText.IsNullOrEmpty())
                {
                    query.Where(p => p.ReturnText == model.ReturnText);
                }
                if (!model.ISRetuen.IsNullOrEmpty())
                {
                    query.Where(p => p.ISRetuen == model.ISRetuen);
                }
                if (!model.ReturnReason.IsNullOrEmpty())
                {
                    query.Where(p => p.ReturnReason == model.ReturnReason);
                }
            }
            if (SelectFiled != null)
            {
                SelectFiled = SelectFiled.ToLowerInvariant();
                if (SelectFiled.Contains("id,"))
                {
                    query.Select(p => new { p.Id });
                }
                if (SelectFiled.Contains("detailid,"))
                {
                    query.Select(p => new { p.DetailId });
                }
                if (SelectFiled.Contains("returntext,"))
                {
                    query.Select(p => new { p.ReturnText });
                }
                if (SelectFiled.Contains("isretuen,"))
                {
                    query.Select(p => new { p.ISRetuen });
                }
                if (SelectFiled.Contains("returnreason,"))
                {
                    query.Select(p => new { p.ReturnReason });
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
