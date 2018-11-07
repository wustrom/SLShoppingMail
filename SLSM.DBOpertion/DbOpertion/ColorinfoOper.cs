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
    public partial class ColorinfoOper : SingleTon<ColorinfoOper>
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
            var delete = new LambdaDelete<Colorinfo>();
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
        public bool DeleteModel(Colorinfo model = null, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var delete = new LambdaDelete<Colorinfo>();
            if (model != null)
            {
                if (!model.Id.IsNullOrEmpty())
                {
                    delete.Where(p => p.Id == model.Id);
                }
                if (!model.StandardColor.IsNullOrEmpty())
                {
                    delete.Where(p => p.StandardColor == model.StandardColor);
                }
                if (!model.ChinaDescribe.IsNullOrEmpty())
                {
                    delete.Where(p => p.ChinaDescribe == model.ChinaDescribe);
                }
                if (!model.EngDescibe.IsNullOrEmpty())
                {
                    delete.Where(p => p.EngDescibe == model.EngDescibe);
                }
                if (!model.ParentId.IsNullOrEmpty())
                {
                    delete.Where(p => p.ParentId == model.ParentId);
                }
                if (!model.HtmlCode.IsNullOrEmpty())
                {
                    delete.Where(p => p.HtmlCode == model.HtmlCode);
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
        public bool Update(Colorinfo model, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var update = new LambdaUpdate<Colorinfo>();
            if (!model.Id.IsNullOrEmpty())
            {
                update.Where(p => p.Id == model.Id);
            }
            if (!model.StandardColor.IsNullOrEmpty())
            {
                update.Set(p => p.StandardColor == model.StandardColor);
            }
            if (!model.ChinaDescribe.IsNullOrEmpty())
            {
                update.Set(p => p.ChinaDescribe == model.ChinaDescribe);
            }
            if (!model.EngDescibe.IsNullOrEmpty())
            {
                update.Set(p => p.EngDescibe == model.EngDescibe);
            }
            if (!model.ParentId.IsNullOrEmpty())
            {
                update.Set(p => p.ParentId == model.ParentId);
            }
            if (!model.HtmlCode.IsNullOrEmpty())
            {
                update.Set(p => p.HtmlCode == model.HtmlCode);
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
        public bool Insert(Colorinfo model, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var insert = new LambdaInsert<Colorinfo>();
            if (!model.StandardColor.IsNullOrEmpty())
            {
                insert.Insert(p => p.StandardColor == model.StandardColor);
            }
            if (!model.ChinaDescribe.IsNullOrEmpty())
            {
                insert.Insert(p => p.ChinaDescribe == model.ChinaDescribe);
            }
            if (!model.EngDescibe.IsNullOrEmpty())
            {
                insert.Insert(p => p.EngDescibe == model.EngDescibe);
            }
            if (!model.ParentId.IsNullOrEmpty())
            {
                insert.Insert(p => p.ParentId == model.ParentId);
            }
            if (!model.HtmlCode.IsNullOrEmpty())
            {
                insert.Insert(p => p.HtmlCode == model.HtmlCode);
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
        public int InsertReturnKey(Colorinfo model, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var insert = new LambdaInsert<Colorinfo>();
            if (!model.StandardColor.IsNullOrEmpty())
            {
                insert.Insert(p => p.StandardColor == model.StandardColor);
            }
            if (!model.ChinaDescribe.IsNullOrEmpty())
            {
                insert.Insert(p => p.ChinaDescribe == model.ChinaDescribe);
            }
            if (!model.EngDescibe.IsNullOrEmpty())
            {
                insert.Insert(p => p.EngDescibe == model.EngDescibe);
            }
            if (!model.ParentId.IsNullOrEmpty())
            {
                insert.Insert(p => p.ParentId == model.ParentId);
            }
            if (!model.HtmlCode.IsNullOrEmpty())
            {
                insert.Insert(p => p.HtmlCode == model.HtmlCode);
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
        public List<Colorinfo> SelectAll(Colorinfo model = null, string SelectFiled = null, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var query = new LambdaQuery<Colorinfo>();
            if (model != null)
            {
                if (!model.Id.IsNullOrEmpty())
                {
                    query.Where(p => p.Id == model.Id);
                }
                if (!model.StandardColor.IsNullOrEmpty())
                {
                    query.Where(p => p.StandardColor == model.StandardColor);
                }
                if (!model.ChinaDescribe.IsNullOrEmpty())
                {
                    query.Where(p => p.ChinaDescribe == model.ChinaDescribe);
                }
                if (!model.EngDescibe.IsNullOrEmpty())
                {
                    query.Where(p => p.EngDescibe == model.EngDescibe);
                }
                if (!model.ParentId.IsNullOrEmpty())
                {
                    query.Where(p => p.ParentId == model.ParentId);
                }
                if (!model.HtmlCode.IsNullOrEmpty())
                {
                    query.Where(p => p.HtmlCode == model.HtmlCode);
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
                if (SelectFiled.Contains("standardcolor,"))
                {
                    query.Select(p => new { p.StandardColor });
                }
                if (SelectFiled.Contains("chinadescribe,"))
                {
                    query.Select(p => new { p.ChinaDescribe });
                }
                if (SelectFiled.Contains("engdescibe,"))
                {
                    query.Select(p => new { p.EngDescibe });
                }
                if (SelectFiled.Contains("parentid,"))
                {
                    query.Select(p => new { p.ParentId });
                }
                if (SelectFiled.Contains("htmlcode,"))
                {
                    query.Select(p => new { p.HtmlCode });
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
        public int SelectCount(Colorinfo model = null, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var query = new LambdaQuery<Colorinfo>();
            if (model != null)
            {
                if (!model.Id.IsNullOrEmpty())
                {
                    query.Where(p => p.Id == model.Id);
                }
                if (!model.StandardColor.IsNullOrEmpty())
                {
                    query.Where(p => p.StandardColor == model.StandardColor);
                }
                if (!model.ChinaDescribe.IsNullOrEmpty())
                {
                    query.Where(p => p.ChinaDescribe == model.ChinaDescribe);
                }
                if (!model.EngDescibe.IsNullOrEmpty())
                {
                    query.Where(p => p.EngDescibe == model.EngDescibe);
                }
                if (!model.ParentId.IsNullOrEmpty())
                {
                    query.Where(p => p.ParentId == model.ParentId);
                }
                if (!model.HtmlCode.IsNullOrEmpty())
                {
                    query.Where(p => p.HtmlCode == model.HtmlCode);
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
        public Colorinfo SelectById(int KeyId, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var query = new LambdaQuery<Colorinfo>();
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
        public List<Colorinfo> SelectByKeys(string Key,List<string> KeyIds, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var query = new LambdaQuery<Colorinfo>();
            if("id" == Key.ToLowerInvariant())
            {
                query.Where(p => p.Id.In(KeyIds));
            }
            if("standardcolor" == Key.ToLowerInvariant())
            {
                query.Where(p => p.StandardColor.In(KeyIds));
            }
            if("chinadescribe" == Key.ToLowerInvariant())
            {
                query.Where(p => p.ChinaDescribe.In(KeyIds));
            }
            if("engdescibe" == Key.ToLowerInvariant())
            {
                query.Where(p => p.EngDescibe.In(KeyIds));
            }
            if("parentid" == Key.ToLowerInvariant())
            {
                query.Where(p => p.ParentId.In(KeyIds));
            }
            if("htmlcode" == Key.ToLowerInvariant())
            {
                query.Where(p => p.HtmlCode.In(KeyIds));
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
        public List<Colorinfo> SelectByPage(string Key, int start, int PageSize, bool desc = true,Colorinfo model = null, string SelectFiled = null, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var query = new LambdaQuery<Colorinfo>();
            if (model != null)
            {
                if (!model.Id.IsNullOrEmpty())
                {
                    query.Where(p => p.Id == model.Id);
                }
                if (!model.StandardColor.IsNullOrEmpty())
                {
                    query.Where(p => p.StandardColor == model.StandardColor);
                }
                if (!model.ChinaDescribe.IsNullOrEmpty())
                {
                    query.Where(p => p.ChinaDescribe == model.ChinaDescribe);
                }
                if (!model.EngDescibe.IsNullOrEmpty())
                {
                    query.Where(p => p.EngDescibe == model.EngDescibe);
                }
                if (!model.ParentId.IsNullOrEmpty())
                {
                    query.Where(p => p.ParentId == model.ParentId);
                }
                if (!model.HtmlCode.IsNullOrEmpty())
                {
                    query.Where(p => p.HtmlCode == model.HtmlCode);
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
                if (SelectFiled.Contains("standardcolor,"))
                {
                    query.Select(p => new { p.StandardColor });
                }
                if (SelectFiled.Contains("chinadescribe,"))
                {
                    query.Select(p => new { p.ChinaDescribe });
                }
                if (SelectFiled.Contains("engdescibe,"))
                {
                    query.Select(p => new { p.EngDescibe });
                }
                if (SelectFiled.Contains("parentid,"))
                {
                    query.Select(p => new { p.ParentId });
                }
                if (SelectFiled.Contains("htmlcode,"))
                {
                    query.Select(p => new { p.HtmlCode });
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
