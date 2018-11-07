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
    public partial class TodaysuccessorderOper : SingleTon<TodaysuccessorderOper>
    {
        /// <summary>
        /// 筛选全部数据
        /// </summary>
        /// <param name="model">模型</param>
        /// <param name="connection">连接</param>
        /// <param name="transaction">事务</param>
        /// <returns>对象列表</returns>
        public List<Todaysuccessorder> SelectAll(Todaysuccessorder model = null, string SelectFiled = null, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var query = new LambdaQuery<Todaysuccessorder>();
            if (model != null)
            {
                if (!model.TotalPrice.IsNullOrEmpty())
                {
                    query.Where(p => p.TotalPrice == model.TotalPrice);
                }
                if (!model.OrderCount.IsNullOrEmpty())
                {
                    query.Where(p => p.OrderCount == model.OrderCount);
                }
            }
            if (SelectFiled != null)
            {
                SelectFiled = SelectFiled.ToLowerInvariant();
                if (SelectFiled.Contains("totalprice,"))
                {
                    query.Select(p => new { p.TotalPrice });
                }
                if (SelectFiled.Contains("ordercount,"))
                {
                    query.Select(p => new { p.OrderCount });
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
        public int SelectCount(Todaysuccessorder model = null, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var query = new LambdaQuery<Todaysuccessorder>();
            if (model != null)
            {
                if (!model.TotalPrice.IsNullOrEmpty())
                {
                    query.Where(p => p.TotalPrice == model.TotalPrice);
                }
                if (!model.OrderCount.IsNullOrEmpty())
                {
                    query.Where(p => p.OrderCount == model.OrderCount);
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
        public Todaysuccessorder SelectById(int KeyId, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var query = new LambdaQuery<Todaysuccessorder>();
            return query.GetQueryList(connection, transaction).FirstOrDefault();
        }


        /// <summary>
        /// 根据主键筛选数据
        /// </summary>
        /// <param name="KeyId">主键Id</param>
        /// <param name="connection">连接</param>
        /// <param name="transaction">事务</param>
        /// <returns>是否成功</returns>
        public List<Todaysuccessorder> SelectByKeys(string Key,List<string> KeyIds, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var query = new LambdaQuery<Todaysuccessorder>();
            if("totalprice" == Key.ToLowerInvariant())
            {
                query.Where(p => p.TotalPrice.In(KeyIds));
            }
            if("ordercount" == Key.ToLowerInvariant())
            {
                query.Where(p => p.OrderCount.In(KeyIds));
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
        public List<Todaysuccessorder> SelectByPage(string Key, int start, int PageSize, bool desc = true,Todaysuccessorder model = null, string SelectFiled = null, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var query = new LambdaQuery<Todaysuccessorder>();
            if (model != null)
            {
                if (!model.TotalPrice.IsNullOrEmpty())
                {
                    query.Where(p => p.TotalPrice == model.TotalPrice);
                }
                if (!model.OrderCount.IsNullOrEmpty())
                {
                    query.Where(p => p.OrderCount == model.OrderCount);
                }
            }
            if (SelectFiled != null)
            {
                SelectFiled = SelectFiled.ToLowerInvariant();
                if (SelectFiled.Contains("totalprice,"))
                {
                    query.Select(p => new { p.TotalPrice });
                }
                if (SelectFiled.Contains("ordercount,"))
                {
                    query.Select(p => new { p.OrderCount });
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
