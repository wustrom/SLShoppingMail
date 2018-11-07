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
    public partial class OrderdetaildesignOper : SingleTon<OrderdetaildesignOper>
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
            var delete = new LambdaDelete<Orderdetaildesign>();
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
        public bool DeleteModel(Orderdetaildesign model = null, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var delete = new LambdaDelete<Orderdetaildesign>();
            if (model != null)
            {
                if (!model.Id.IsNullOrEmpty())
                {
                    delete.Where(p => p.Id == model.Id);
                }
                if (!model.OrderDetailId.IsNullOrEmpty())
                {
                    delete.Where(p => p.OrderDetailId == model.OrderDetailId);
                }
                if (!model.Content.IsNullOrEmpty())
                {
                    delete.Where(p => p.Content == model.Content);
                }
                if (!model.PrintingPosition.IsNullOrEmpty())
                {
                    delete.Where(p => p.PrintingPosition == model.PrintingPosition);
                }
                if (!model.Image.IsNullOrEmpty())
                {
                    delete.Where(p => p.Image == model.Image);
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
        public bool Update(Orderdetaildesign model, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var update = new LambdaUpdate<Orderdetaildesign>();
            if (!model.Id.IsNullOrEmpty())
            {
                update.Where(p => p.Id == model.Id);
            }
            if (!model.OrderDetailId.IsNullOrEmpty())
            {
                update.Set(p => p.OrderDetailId == model.OrderDetailId);
            }
            if (!model.Content.IsNullOrEmpty())
            {
                update.Set(p => p.Content == model.Content);
            }
            if (!model.PrintingPosition.IsNullOrEmpty())
            {
                update.Set(p => p.PrintingPosition == model.PrintingPosition);
            }
            if (!model.Image.IsNullOrEmpty())
            {
                update.Set(p => p.Image == model.Image);
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
        public bool Insert(Orderdetaildesign model, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var insert = new LambdaInsert<Orderdetaildesign>();
            if (!model.OrderDetailId.IsNullOrEmpty())
            {
                insert.Insert(p => p.OrderDetailId == model.OrderDetailId);
            }
            if (!model.Content.IsNullOrEmpty())
            {
                insert.Insert(p => p.Content == model.Content);
            }
            if (!model.PrintingPosition.IsNullOrEmpty())
            {
                insert.Insert(p => p.PrintingPosition == model.PrintingPosition);
            }
            if (!model.Image.IsNullOrEmpty())
            {
                insert.Insert(p => p.Image == model.Image);
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
        public int InsertReturnKey(Orderdetaildesign model, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var insert = new LambdaInsert<Orderdetaildesign>();
            if (!model.OrderDetailId.IsNullOrEmpty())
            {
                insert.Insert(p => p.OrderDetailId == model.OrderDetailId);
            }
            if (!model.Content.IsNullOrEmpty())
            {
                insert.Insert(p => p.Content == model.Content);
            }
            if (!model.PrintingPosition.IsNullOrEmpty())
            {
                insert.Insert(p => p.PrintingPosition == model.PrintingPosition);
            }
            if (!model.Image.IsNullOrEmpty())
            {
                insert.Insert(p => p.Image == model.Image);
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
        public List<Orderdetaildesign> SelectAll(Orderdetaildesign model = null, string SelectFiled = null, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var query = new LambdaQuery<Orderdetaildesign>();
            if (model != null)
            {
                if (!model.Id.IsNullOrEmpty())
                {
                    query.Where(p => p.Id == model.Id);
                }
                if (!model.OrderDetailId.IsNullOrEmpty())
                {
                    query.Where(p => p.OrderDetailId == model.OrderDetailId);
                }
                if (!model.Content.IsNullOrEmpty())
                {
                    query.Where(p => p.Content == model.Content);
                }
                if (!model.PrintingPosition.IsNullOrEmpty())
                {
                    query.Where(p => p.PrintingPosition == model.PrintingPosition);
                }
                if (!model.Image.IsNullOrEmpty())
                {
                    query.Where(p => p.Image == model.Image);
                }
            }
            if (SelectFiled != null)
            {
                SelectFiled = SelectFiled.ToLowerInvariant();
                if (SelectFiled.Contains("id,"))
                {
                    query.Select(p => new { p.Id });
                }
                if (SelectFiled.Contains("orderdetailid,"))
                {
                    query.Select(p => new { p.OrderDetailId });
                }
                if (SelectFiled.Contains("content,"))
                {
                    query.Select(p => new { p.Content });
                }
                if (SelectFiled.Contains("printingposition,"))
                {
                    query.Select(p => new { p.PrintingPosition });
                }
                if (SelectFiled.Contains("image,"))
                {
                    query.Select(p => new { p.Image });
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
        public int SelectCount(Orderdetaildesign model = null, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var query = new LambdaQuery<Orderdetaildesign>();
            if (model != null)
            {
                if (!model.Id.IsNullOrEmpty())
                {
                    query.Where(p => p.Id == model.Id);
                }
                if (!model.OrderDetailId.IsNullOrEmpty())
                {
                    query.Where(p => p.OrderDetailId == model.OrderDetailId);
                }
                if (!model.Content.IsNullOrEmpty())
                {
                    query.Where(p => p.Content == model.Content);
                }
                if (!model.PrintingPosition.IsNullOrEmpty())
                {
                    query.Where(p => p.PrintingPosition == model.PrintingPosition);
                }
                if (!model.Image.IsNullOrEmpty())
                {
                    query.Where(p => p.Image == model.Image);
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
        public Orderdetaildesign SelectById(int KeyId, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var query = new LambdaQuery<Orderdetaildesign>();
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
        public List<Orderdetaildesign> SelectByKeys(string Key,List<string> KeyIds, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var query = new LambdaQuery<Orderdetaildesign>();
            if("id" == Key.ToLowerInvariant())
            {
                query.Where(p => p.Id.In(KeyIds));
            }
            if("orderdetailid" == Key.ToLowerInvariant())
            {
                query.Where(p => p.OrderDetailId.In(KeyIds));
            }
            if("content" == Key.ToLowerInvariant())
            {
                query.Where(p => p.Content.In(KeyIds));
            }
            if("printingposition" == Key.ToLowerInvariant())
            {
                query.Where(p => p.PrintingPosition.In(KeyIds));
            }
            if("image" == Key.ToLowerInvariant())
            {
                query.Where(p => p.Image.In(KeyIds));
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
        public List<Orderdetaildesign> SelectByPage(string Key, int start, int PageSize, bool desc = true,Orderdetaildesign model = null, string SelectFiled = null, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var query = new LambdaQuery<Orderdetaildesign>();
            if (model != null)
            {
                if (!model.Id.IsNullOrEmpty())
                {
                    query.Where(p => p.Id == model.Id);
                }
                if (!model.OrderDetailId.IsNullOrEmpty())
                {
                    query.Where(p => p.OrderDetailId == model.OrderDetailId);
                }
                if (!model.Content.IsNullOrEmpty())
                {
                    query.Where(p => p.Content == model.Content);
                }
                if (!model.PrintingPosition.IsNullOrEmpty())
                {
                    query.Where(p => p.PrintingPosition == model.PrintingPosition);
                }
                if (!model.Image.IsNullOrEmpty())
                {
                    query.Where(p => p.Image == model.Image);
                }
            }
            if (SelectFiled != null)
            {
                SelectFiled = SelectFiled.ToLowerInvariant();
                if (SelectFiled.Contains("id,"))
                {
                    query.Select(p => new { p.Id });
                }
                if (SelectFiled.Contains("orderdetailid,"))
                {
                    query.Select(p => new { p.OrderDetailId });
                }
                if (SelectFiled.Contains("content,"))
                {
                    query.Select(p => new { p.Content });
                }
                if (SelectFiled.Contains("printingposition,"))
                {
                    query.Select(p => new { p.PrintingPosition });
                }
                if (SelectFiled.Contains("image,"))
                {
                    query.Select(p => new { p.Image });
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
