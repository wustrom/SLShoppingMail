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
    public partial class EvaluateOper : SingleTon<EvaluateOper>
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
            var delete = new LambdaDelete<Evaluate>();
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
        public bool DeleteModel(Evaluate model = null, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var delete = new LambdaDelete<Evaluate>();
            if (model != null)
            {
                if (!model.Id.IsNullOrEmpty())
                {
                    delete.Where(p => p.Id == model.Id);
                }
                if (!model.UserId.IsNullOrEmpty())
                {
                    delete.Where(p => p.UserId == model.UserId);
                }
                if (!model.CommodityId.IsNullOrEmpty())
                {
                    delete.Where(p => p.CommodityId == model.CommodityId);
                }
                if (!model.ImageList.IsNullOrEmpty())
                {
                    delete.Where(p => p.ImageList == model.ImageList);
                }
                if (!model.CreateTime.IsNullOrEmpty())
                {
                    delete.Where(p => p.CreateTime == model.CreateTime);
                }
                if (!model.Content.IsNullOrEmpty())
                {
                    delete.Where(p => p.Content == model.Content);
                }
                if (!model.Start.IsNullOrEmpty())
                {
                    delete.Where(p => p.Start == model.Start);
                }
                if (!model.FrontView.IsNullOrEmpty())
                {
                    delete.Where(p => p.FrontView == model.FrontView);
                }
                if (!model.BackView.IsNullOrEmpty())
                {
                    delete.Where(p => p.BackView == model.BackView);
                }
                if (!model.ParentId.IsNullOrEmpty())
                {
                    delete.Where(p => p.ParentId == model.ParentId);
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
        public bool Update(Evaluate model, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var update = new LambdaUpdate<Evaluate>();
            if (!model.Id.IsNullOrEmpty())
            {
                update.Where(p => p.Id == model.Id);
            }
            if (!model.UserId.IsNullOrEmpty())
            {
                update.Set(p => p.UserId == model.UserId);
            }
            if (!model.CommodityId.IsNullOrEmpty())
            {
                update.Set(p => p.CommodityId == model.CommodityId);
            }
            if (!model.ImageList.IsNullOrEmpty())
            {
                update.Set(p => p.ImageList == model.ImageList);
            }
            if (!model.CreateTime.IsNullOrEmpty())
            {
                update.Set(p => p.CreateTime == model.CreateTime);
            }
            if (!model.Content.IsNullOrEmpty())
            {
                update.Set(p => p.Content == model.Content);
            }
            if (!model.Start.IsNullOrEmpty())
            {
                update.Set(p => p.Start == model.Start);
            }
            if (!model.FrontView.IsNullOrEmpty())
            {
                update.Set(p => p.FrontView == model.FrontView);
            }
            if (!model.BackView.IsNullOrEmpty())
            {
                update.Set(p => p.BackView == model.BackView);
            }
            if (!model.ParentId.IsNullOrEmpty())
            {
                update.Set(p => p.ParentId == model.ParentId);
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
        public bool Insert(Evaluate model, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var insert = new LambdaInsert<Evaluate>();
            if (!model.UserId.IsNullOrEmpty())
            {
                insert.Insert(p => p.UserId == model.UserId);
            }
            if (!model.CommodityId.IsNullOrEmpty())
            {
                insert.Insert(p => p.CommodityId == model.CommodityId);
            }
            if (!model.ImageList.IsNullOrEmpty())
            {
                insert.Insert(p => p.ImageList == model.ImageList);
            }
            if (!model.CreateTime.IsNullOrEmpty())
            {
                insert.Insert(p => p.CreateTime == model.CreateTime);
            }
            if (!model.Content.IsNullOrEmpty())
            {
                insert.Insert(p => p.Content == model.Content);
            }
            if (!model.Start.IsNullOrEmpty())
            {
                insert.Insert(p => p.Start == model.Start);
            }
            if (!model.FrontView.IsNullOrEmpty())
            {
                insert.Insert(p => p.FrontView == model.FrontView);
            }
            if (!model.BackView.IsNullOrEmpty())
            {
                insert.Insert(p => p.BackView == model.BackView);
            }
            if (!model.ParentId.IsNullOrEmpty())
            {
                insert.Insert(p => p.ParentId == model.ParentId);
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
        public int InsertReturnKey(Evaluate model, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var insert = new LambdaInsert<Evaluate>();
            if (!model.UserId.IsNullOrEmpty())
            {
                insert.Insert(p => p.UserId == model.UserId);
            }
            if (!model.CommodityId.IsNullOrEmpty())
            {
                insert.Insert(p => p.CommodityId == model.CommodityId);
            }
            if (!model.ImageList.IsNullOrEmpty())
            {
                insert.Insert(p => p.ImageList == model.ImageList);
            }
            if (!model.CreateTime.IsNullOrEmpty())
            {
                insert.Insert(p => p.CreateTime == model.CreateTime);
            }
            if (!model.Content.IsNullOrEmpty())
            {
                insert.Insert(p => p.Content == model.Content);
            }
            if (!model.Start.IsNullOrEmpty())
            {
                insert.Insert(p => p.Start == model.Start);
            }
            if (!model.FrontView.IsNullOrEmpty())
            {
                insert.Insert(p => p.FrontView == model.FrontView);
            }
            if (!model.BackView.IsNullOrEmpty())
            {
                insert.Insert(p => p.BackView == model.BackView);
            }
            if (!model.ParentId.IsNullOrEmpty())
            {
                insert.Insert(p => p.ParentId == model.ParentId);
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
        public List<Evaluate> SelectAll(Evaluate model = null, string SelectFiled = null, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var query = new LambdaQuery<Evaluate>();
            if (model != null)
            {
                if (!model.Id.IsNullOrEmpty())
                {
                    query.Where(p => p.Id == model.Id);
                }
                if (!model.UserId.IsNullOrEmpty())
                {
                    query.Where(p => p.UserId == model.UserId);
                }
                if (!model.CommodityId.IsNullOrEmpty())
                {
                    query.Where(p => p.CommodityId == model.CommodityId);
                }
                if (!model.ImageList.IsNullOrEmpty())
                {
                    query.Where(p => p.ImageList == model.ImageList);
                }
                if (!model.CreateTime.IsNullOrEmpty())
                {
                    query.Where(p => p.CreateTime == model.CreateTime);
                }
                if (!model.Content.IsNullOrEmpty())
                {
                    query.Where(p => p.Content == model.Content);
                }
                if (!model.Start.IsNullOrEmpty())
                {
                    query.Where(p => p.Start == model.Start);
                }
                if (!model.FrontView.IsNullOrEmpty())
                {
                    query.Where(p => p.FrontView == model.FrontView);
                }
                if (!model.BackView.IsNullOrEmpty())
                {
                    query.Where(p => p.BackView == model.BackView);
                }
                if (!model.ParentId.IsNullOrEmpty())
                {
                    query.Where(p => p.ParentId == model.ParentId);
                }
            }
            if (SelectFiled != null)
            {
                SelectFiled = SelectFiled.ToLowerInvariant();
                if (SelectFiled.Contains("id,"))
                {
                    query.Select(p => new { p.Id });
                }
                if (SelectFiled.Contains("userid,"))
                {
                    query.Select(p => new { p.UserId });
                }
                if (SelectFiled.Contains("commodityid,"))
                {
                    query.Select(p => new { p.CommodityId });
                }
                if (SelectFiled.Contains("imagelist,"))
                {
                    query.Select(p => new { p.ImageList });
                }
                if (SelectFiled.Contains("createtime,"))
                {
                    query.Select(p => new { p.CreateTime });
                }
                if (SelectFiled.Contains("content,"))
                {
                    query.Select(p => new { p.Content });
                }
                if (SelectFiled.Contains("start,"))
                {
                    query.Select(p => new { p.Start });
                }
                if (SelectFiled.Contains("frontview,"))
                {
                    query.Select(p => new { p.FrontView });
                }
                if (SelectFiled.Contains("backview,"))
                {
                    query.Select(p => new { p.BackView });
                }
                if (SelectFiled.Contains("parentid,"))
                {
                    query.Select(p => new { p.ParentId });
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
        public int SelectCount(Evaluate model = null, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var query = new LambdaQuery<Evaluate>();
            if (model != null)
            {
                if (!model.Id.IsNullOrEmpty())
                {
                    query.Where(p => p.Id == model.Id);
                }
                if (!model.UserId.IsNullOrEmpty())
                {
                    query.Where(p => p.UserId == model.UserId);
                }
                if (!model.CommodityId.IsNullOrEmpty())
                {
                    query.Where(p => p.CommodityId == model.CommodityId);
                }
                if (!model.ImageList.IsNullOrEmpty())
                {
                    query.Where(p => p.ImageList == model.ImageList);
                }
                if (!model.CreateTime.IsNullOrEmpty())
                {
                    query.Where(p => p.CreateTime == model.CreateTime);
                }
                if (!model.Content.IsNullOrEmpty())
                {
                    query.Where(p => p.Content == model.Content);
                }
                if (!model.Start.IsNullOrEmpty())
                {
                    query.Where(p => p.Start == model.Start);
                }
                if (!model.FrontView.IsNullOrEmpty())
                {
                    query.Where(p => p.FrontView == model.FrontView);
                }
                if (!model.BackView.IsNullOrEmpty())
                {
                    query.Where(p => p.BackView == model.BackView);
                }
                if (!model.ParentId.IsNullOrEmpty())
                {
                    query.Where(p => p.ParentId == model.ParentId);
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
        public Evaluate SelectById(int KeyId, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var query = new LambdaQuery<Evaluate>();
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
        public List<Evaluate> SelectByKeys(string Key,List<string> KeyIds, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var query = new LambdaQuery<Evaluate>();
            if("id" == Key.ToLowerInvariant())
            {
                query.Where(p => p.Id.In(KeyIds));
            }
            if("userid" == Key.ToLowerInvariant())
            {
                query.Where(p => p.UserId.In(KeyIds));
            }
            if("commodityid" == Key.ToLowerInvariant())
            {
                query.Where(p => p.CommodityId.In(KeyIds));
            }
            if("imagelist" == Key.ToLowerInvariant())
            {
                query.Where(p => p.ImageList.In(KeyIds));
            }
            if("createtime" == Key.ToLowerInvariant())
            {
                query.Where(p => p.CreateTime.In(KeyIds));
            }
            if("content" == Key.ToLowerInvariant())
            {
                query.Where(p => p.Content.In(KeyIds));
            }
            if("start" == Key.ToLowerInvariant())
            {
                query.Where(p => p.Start.In(KeyIds));
            }
            if("frontview" == Key.ToLowerInvariant())
            {
                query.Where(p => p.FrontView.In(KeyIds));
            }
            if("backview" == Key.ToLowerInvariant())
            {
                query.Where(p => p.BackView.In(KeyIds));
            }
            if("parentid" == Key.ToLowerInvariant())
            {
                query.Where(p => p.ParentId.In(KeyIds));
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
        public List<Evaluate> SelectByPage(string Key, int start, int PageSize, bool desc = true,Evaluate model = null, string SelectFiled = null, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var query = new LambdaQuery<Evaluate>();
            if (model != null)
            {
                if (!model.Id.IsNullOrEmpty())
                {
                    query.Where(p => p.Id == model.Id);
                }
                if (!model.UserId.IsNullOrEmpty())
                {
                    query.Where(p => p.UserId == model.UserId);
                }
                if (!model.CommodityId.IsNullOrEmpty())
                {
                    query.Where(p => p.CommodityId == model.CommodityId);
                }
                if (!model.ImageList.IsNullOrEmpty())
                {
                    query.Where(p => p.ImageList == model.ImageList);
                }
                if (!model.CreateTime.IsNullOrEmpty())
                {
                    query.Where(p => p.CreateTime == model.CreateTime);
                }
                if (!model.Content.IsNullOrEmpty())
                {
                    query.Where(p => p.Content == model.Content);
                }
                if (!model.Start.IsNullOrEmpty())
                {
                    query.Where(p => p.Start == model.Start);
                }
                if (!model.FrontView.IsNullOrEmpty())
                {
                    query.Where(p => p.FrontView == model.FrontView);
                }
                if (!model.BackView.IsNullOrEmpty())
                {
                    query.Where(p => p.BackView == model.BackView);
                }
                if (!model.ParentId.IsNullOrEmpty())
                {
                    query.Where(p => p.ParentId == model.ParentId);
                }
            }
            if (SelectFiled != null)
            {
                SelectFiled = SelectFiled.ToLowerInvariant();
                if (SelectFiled.Contains("id,"))
                {
                    query.Select(p => new { p.Id });
                }
                if (SelectFiled.Contains("userid,"))
                {
                    query.Select(p => new { p.UserId });
                }
                if (SelectFiled.Contains("commodityid,"))
                {
                    query.Select(p => new { p.CommodityId });
                }
                if (SelectFiled.Contains("imagelist,"))
                {
                    query.Select(p => new { p.ImageList });
                }
                if (SelectFiled.Contains("createtime,"))
                {
                    query.Select(p => new { p.CreateTime });
                }
                if (SelectFiled.Contains("content,"))
                {
                    query.Select(p => new { p.Content });
                }
                if (SelectFiled.Contains("start,"))
                {
                    query.Select(p => new { p.Start });
                }
                if (SelectFiled.Contains("frontview,"))
                {
                    query.Select(p => new { p.FrontView });
                }
                if (SelectFiled.Contains("backview,"))
                {
                    query.Select(p => new { p.BackView });
                }
                if (SelectFiled.Contains("parentid,"))
                {
                    query.Select(p => new { p.ParentId });
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
