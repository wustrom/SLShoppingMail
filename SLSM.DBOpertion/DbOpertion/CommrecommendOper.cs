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
    public partial class CommrecommendOper : SingleTon<CommrecommendOper>
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
            var delete = new LambdaDelete<Commrecommend>();
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
        public bool DeleteModel(Commrecommend model = null, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var delete = new LambdaDelete<Commrecommend>();
            if (model != null)
            {
                if (!model.Id.IsNullOrEmpty())
                {
                    delete.Where(p => p.Id == model.Id);
                }
                if (!model.CommId.IsNullOrEmpty())
                {
                    delete.Where(p => p.CommId == model.CommId);
                }
                if (!model.OrderID.IsNullOrEmpty())
                {
                    delete.Where(p => p.OrderID == model.OrderID);
                }
                if (!model.FrontImage.IsNullOrEmpty())
                {
                    delete.Where(p => p.FrontImage == model.FrontImage);
                }
                if (!model.AttrSpan.IsNullOrEmpty())
                {
                    delete.Where(p => p.AttrSpan == model.AttrSpan);
                }
                if (!model.BehindImage.IsNullOrEmpty())
                {
                    delete.Where(p => p.BehindImage == model.BehindImage);
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
        public bool Update(Commrecommend model, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var update = new LambdaUpdate<Commrecommend>();
            if (!model.Id.IsNullOrEmpty())
            {
                update.Where(p => p.Id == model.Id);
            }
            if (!model.CommId.IsNullOrEmpty())
            {
                update.Set(p => p.CommId == model.CommId);
            }
            if (!model.OrderID.IsNullOrEmpty())
            {
                update.Set(p => p.OrderID == model.OrderID);
            }
            if (!model.FrontImage.IsNullOrEmpty())
            {
                update.Set(p => p.FrontImage == model.FrontImage);
            }
            if (!model.AttrSpan.IsNullOrEmpty())
            {
                update.Set(p => p.AttrSpan == model.AttrSpan);
            }
            if (!model.BehindImage.IsNullOrEmpty())
            {
                update.Set(p => p.BehindImage == model.BehindImage);
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
        public bool Insert(Commrecommend model, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var insert = new LambdaInsert<Commrecommend>();
            if (!model.CommId.IsNullOrEmpty())
            {
                insert.Insert(p => p.CommId == model.CommId);
            }
            if (!model.OrderID.IsNullOrEmpty())
            {
                insert.Insert(p => p.OrderID == model.OrderID);
            }
            if (!model.FrontImage.IsNullOrEmpty())
            {
                insert.Insert(p => p.FrontImage == model.FrontImage);
            }
            if (!model.AttrSpan.IsNullOrEmpty())
            {
                insert.Insert(p => p.AttrSpan == model.AttrSpan);
            }
            if (!model.BehindImage.IsNullOrEmpty())
            {
                insert.Insert(p => p.BehindImage == model.BehindImage);
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
        public int InsertReturnKey(Commrecommend model, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var insert = new LambdaInsert<Commrecommend>();
            if (!model.CommId.IsNullOrEmpty())
            {
                insert.Insert(p => p.CommId == model.CommId);
            }
            if (!model.OrderID.IsNullOrEmpty())
            {
                insert.Insert(p => p.OrderID == model.OrderID);
            }
            if (!model.FrontImage.IsNullOrEmpty())
            {
                insert.Insert(p => p.FrontImage == model.FrontImage);
            }
            if (!model.AttrSpan.IsNullOrEmpty())
            {
                insert.Insert(p => p.AttrSpan == model.AttrSpan);
            }
            if (!model.BehindImage.IsNullOrEmpty())
            {
                insert.Insert(p => p.BehindImage == model.BehindImage);
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
        public List<Commrecommend> SelectAll(Commrecommend model = null, string SelectFiled = null, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var query = new LambdaQuery<Commrecommend>();
            if (model != null)
            {
                if (!model.Id.IsNullOrEmpty())
                {
                    query.Where(p => p.Id == model.Id);
                }
                if (!model.CommId.IsNullOrEmpty())
                {
                    query.Where(p => p.CommId == model.CommId);
                }
                if (!model.OrderID.IsNullOrEmpty())
                {
                    query.Where(p => p.OrderID == model.OrderID);
                }
                if (!model.FrontImage.IsNullOrEmpty())
                {
                    query.Where(p => p.FrontImage == model.FrontImage);
                }
                if (!model.AttrSpan.IsNullOrEmpty())
                {
                    query.Where(p => p.AttrSpan == model.AttrSpan);
                }
                if (!model.BehindImage.IsNullOrEmpty())
                {
                    query.Where(p => p.BehindImage == model.BehindImage);
                }
            }
            if (SelectFiled != null)
            {
                SelectFiled = SelectFiled.ToLowerInvariant();
                if (SelectFiled.Contains("id,"))
                {
                    query.Select(p => new { p.Id });
                }
                if (SelectFiled.Contains("commid,"))
                {
                    query.Select(p => new { p.CommId });
                }
                if (SelectFiled.Contains("orderid,"))
                {
                    query.Select(p => new { p.OrderID });
                }
                if (SelectFiled.Contains("frontimage,"))
                {
                    query.Select(p => new { p.FrontImage });
                }
                if (SelectFiled.Contains("attrspan,"))
                {
                    query.Select(p => new { p.AttrSpan });
                }
                if (SelectFiled.Contains("behindimage,"))
                {
                    query.Select(p => new { p.BehindImage });
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
        public int SelectCount(Commrecommend model = null, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var query = new LambdaQuery<Commrecommend>();
            if (model != null)
            {
                if (!model.Id.IsNullOrEmpty())
                {
                    query.Where(p => p.Id == model.Id);
                }
                if (!model.CommId.IsNullOrEmpty())
                {
                    query.Where(p => p.CommId == model.CommId);
                }
                if (!model.OrderID.IsNullOrEmpty())
                {
                    query.Where(p => p.OrderID == model.OrderID);
                }
                if (!model.FrontImage.IsNullOrEmpty())
                {
                    query.Where(p => p.FrontImage == model.FrontImage);
                }
                if (!model.AttrSpan.IsNullOrEmpty())
                {
                    query.Where(p => p.AttrSpan == model.AttrSpan);
                }
                if (!model.BehindImage.IsNullOrEmpty())
                {
                    query.Where(p => p.BehindImage == model.BehindImage);
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
        public Commrecommend SelectById(int KeyId, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var query = new LambdaQuery<Commrecommend>();
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
        public List<Commrecommend> SelectByKeys(string Key,List<string> KeyIds, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var query = new LambdaQuery<Commrecommend>();
            if("id" == Key.ToLowerInvariant())
            {
                query.Where(p => p.Id.In(KeyIds));
            }
            if("commid" == Key.ToLowerInvariant())
            {
                query.Where(p => p.CommId.In(KeyIds));
            }
            if("orderid" == Key.ToLowerInvariant())
            {
                query.Where(p => p.OrderID.In(KeyIds));
            }
            if("frontimage" == Key.ToLowerInvariant())
            {
                query.Where(p => p.FrontImage.In(KeyIds));
            }
            if("attrspan" == Key.ToLowerInvariant())
            {
                query.Where(p => p.AttrSpan.In(KeyIds));
            }
            if("behindimage" == Key.ToLowerInvariant())
            {
                query.Where(p => p.BehindImage.In(KeyIds));
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
        public List<Commrecommend> SelectByPage(string Key, int start, int PageSize, bool desc = true,Commrecommend model = null, string SelectFiled = null, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var query = new LambdaQuery<Commrecommend>();
            if (model != null)
            {
                if (!model.Id.IsNullOrEmpty())
                {
                    query.Where(p => p.Id == model.Id);
                }
                if (!model.CommId.IsNullOrEmpty())
                {
                    query.Where(p => p.CommId == model.CommId);
                }
                if (!model.OrderID.IsNullOrEmpty())
                {
                    query.Where(p => p.OrderID == model.OrderID);
                }
                if (!model.FrontImage.IsNullOrEmpty())
                {
                    query.Where(p => p.FrontImage == model.FrontImage);
                }
                if (!model.AttrSpan.IsNullOrEmpty())
                {
                    query.Where(p => p.AttrSpan == model.AttrSpan);
                }
                if (!model.BehindImage.IsNullOrEmpty())
                {
                    query.Where(p => p.BehindImage == model.BehindImage);
                }
            }
            if (SelectFiled != null)
            {
                SelectFiled = SelectFiled.ToLowerInvariant();
                if (SelectFiled.Contains("id,"))
                {
                    query.Select(p => new { p.Id });
                }
                if (SelectFiled.Contains("commid,"))
                {
                    query.Select(p => new { p.CommId });
                }
                if (SelectFiled.Contains("orderid,"))
                {
                    query.Select(p => new { p.OrderID });
                }
                if (SelectFiled.Contains("frontimage,"))
                {
                    query.Select(p => new { p.FrontImage });
                }
                if (SelectFiled.Contains("attrspan,"))
                {
                    query.Select(p => new { p.AttrSpan });
                }
                if (SelectFiled.Contains("behindimage,"))
                {
                    query.Select(p => new { p.BehindImage });
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
