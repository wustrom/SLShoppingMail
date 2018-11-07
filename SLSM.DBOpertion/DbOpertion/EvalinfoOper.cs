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
    public partial class EvalinfoOper : SingleTon<EvalinfoOper>
    {
        /// <summary>
        /// 筛选全部数据
        /// </summary>
        /// <param name="model">模型</param>
        /// <param name="connection">连接</param>
        /// <param name="transaction">事务</param>
        /// <returns>对象列表</returns>
        public List<Evalinfo> SelectAll(Evalinfo model = null, string SelectFiled = null, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var query = new LambdaQuery<Evalinfo>();
            if (model != null)
            {
                if (!model.EvaluateId.IsNullOrEmpty())
                {
                    query.Where(p => p.EvaluateId == model.EvaluateId);
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
                if (!model.Name.IsNullOrEmpty())
                {
                    query.Where(p => p.Name == model.Name);
                }
                if (!model.CommName.IsNullOrEmpty())
                {
                    query.Where(p => p.CommName == model.CommName);
                }
            }
            if (SelectFiled != null)
            {
                SelectFiled = SelectFiled.ToLowerInvariant();
                if (SelectFiled.Contains("evaluateid,"))
                {
                    query.Select(p => new { p.EvaluateId });
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
                if (SelectFiled.Contains("name,"))
                {
                    query.Select(p => new { p.Name });
                }
                if (SelectFiled.Contains("commname,"))
                {
                    query.Select(p => new { p.CommName });
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
        public int SelectCount(Evalinfo model = null, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var query = new LambdaQuery<Evalinfo>();
            if (model != null)
            {
                if (!model.EvaluateId.IsNullOrEmpty())
                {
                    query.Where(p => p.EvaluateId == model.EvaluateId);
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
                if (!model.Name.IsNullOrEmpty())
                {
                    query.Where(p => p.Name == model.Name);
                }
                if (!model.CommName.IsNullOrEmpty())
                {
                    query.Where(p => p.CommName == model.CommName);
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
        public Evalinfo SelectById(int KeyId, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var query = new LambdaQuery<Evalinfo>();
            query.Where(p => p.EvaluateId == KeyId);
            return query.GetQueryList(connection, transaction).FirstOrDefault();
        }


        /// <summary>
        /// 根据主键筛选数据
        /// </summary>
        /// <param name="KeyId">主键Id</param>
        /// <param name="connection">连接</param>
        /// <param name="transaction">事务</param>
        /// <returns>是否成功</returns>
        public List<Evalinfo> SelectByKeys(string Key,List<string> KeyIds, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var query = new LambdaQuery<Evalinfo>();
            if("evaluateid" == Key.ToLowerInvariant())
            {
                query.Where(p => p.EvaluateId.In(KeyIds));
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
            if("name" == Key.ToLowerInvariant())
            {
                query.Where(p => p.Name.In(KeyIds));
            }
            if("commname" == Key.ToLowerInvariant())
            {
                query.Where(p => p.CommName.In(KeyIds));
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
        public List<Evalinfo> SelectByPage(string Key, int start, int PageSize, bool desc = true,Evalinfo model = null, string SelectFiled = null, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var query = new LambdaQuery<Evalinfo>();
            if (model != null)
            {
                if (!model.EvaluateId.IsNullOrEmpty())
                {
                    query.Where(p => p.EvaluateId == model.EvaluateId);
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
                if (!model.Name.IsNullOrEmpty())
                {
                    query.Where(p => p.Name == model.Name);
                }
                if (!model.CommName.IsNullOrEmpty())
                {
                    query.Where(p => p.CommName == model.CommName);
                }
            }
            if (SelectFiled != null)
            {
                SelectFiled = SelectFiled.ToLowerInvariant();
                if (SelectFiled.Contains("evaluateid,"))
                {
                    query.Select(p => new { p.EvaluateId });
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
                if (SelectFiled.Contains("name,"))
                {
                    query.Select(p => new { p.Name });
                }
                if (SelectFiled.Contains("commname,"))
                {
                    query.Select(p => new { p.CommName });
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
