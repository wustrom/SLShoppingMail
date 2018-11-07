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
    public partial class Message_Grant_ViewOper : SingleTon<Message_Grant_ViewOper>
    {
        /// <summary>
        /// 筛选全部数据
        /// </summary>
        /// <param name="model">模型</param>
        /// <param name="connection">连接</param>
        /// <param name="transaction">事务</param>
        /// <returns>对象列表</returns>
        public List<Message_Grant_View> SelectAll(Message_Grant_View model = null, string SelectFiled = null, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var query = new LambdaQuery<Message_Grant_View>();
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
                if (!model.MessageId.IsNullOrEmpty())
                {
                    query.Where(p => p.MessageId == model.MessageId);
                }
                if (!model.IsWatch.IsNullOrEmpty())
                {
                    query.Where(p => p.IsWatch == model.IsWatch);
                }
                if (!model.MainTitle.IsNullOrEmpty())
                {
                    query.Where(p => p.MainTitle == model.MainTitle);
                }
                if (!model.Title.IsNullOrEmpty())
                {
                    query.Where(p => p.Title == model.Title);
                }
                if (!model.MessageTime.IsNullOrEmpty())
                {
                    query.Where(p => p.MessageTime == model.MessageTime);
                }
                if (!model.Content.IsNullOrEmpty())
                {
                    query.Where(p => p.Content == model.Content);
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
                if (SelectFiled.Contains("userid,"))
                {
                    query.Select(p => new { p.UserId });
                }
                if (SelectFiled.Contains("messageid,"))
                {
                    query.Select(p => new { p.MessageId });
                }
                if (SelectFiled.Contains("iswatch,"))
                {
                    query.Select(p => new { p.IsWatch });
                }
                if (SelectFiled.Contains("maintitle,"))
                {
                    query.Select(p => new { p.MainTitle });
                }
                if (SelectFiled.Contains("title,"))
                {
                    query.Select(p => new { p.Title });
                }
                if (SelectFiled.Contains("messagetime,"))
                {
                    query.Select(p => new { p.MessageTime });
                }
                if (SelectFiled.Contains("content,"))
                {
                    query.Select(p => new { p.Content });
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
        public int SelectCount(Message_Grant_View model = null, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var query = new LambdaQuery<Message_Grant_View>();
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
                if (!model.MessageId.IsNullOrEmpty())
                {
                    query.Where(p => p.MessageId == model.MessageId);
                }
                if (!model.IsWatch.IsNullOrEmpty())
                {
                    query.Where(p => p.IsWatch == model.IsWatch);
                }
                if (!model.MainTitle.IsNullOrEmpty())
                {
                    query.Where(p => p.MainTitle == model.MainTitle);
                }
                if (!model.Title.IsNullOrEmpty())
                {
                    query.Where(p => p.Title == model.Title);
                }
                if (!model.MessageTime.IsNullOrEmpty())
                {
                    query.Where(p => p.MessageTime == model.MessageTime);
                }
                if (!model.Content.IsNullOrEmpty())
                {
                    query.Where(p => p.Content == model.Content);
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
        public Message_Grant_View SelectById(int KeyId, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var query = new LambdaQuery<Message_Grant_View>();
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
        public List<Message_Grant_View> SelectByKeys(string Key,List<string> KeyIds, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var query = new LambdaQuery<Message_Grant_View>();
            if("id" == Key.ToLowerInvariant())
            {
                query.Where(p => p.Id.In(KeyIds));
            }
            if("userid" == Key.ToLowerInvariant())
            {
                query.Where(p => p.UserId.In(KeyIds));
            }
            if("messageid" == Key.ToLowerInvariant())
            {
                query.Where(p => p.MessageId.In(KeyIds));
            }
            if("iswatch" == Key.ToLowerInvariant())
            {
                query.Where(p => p.IsWatch.In(KeyIds));
            }
            if("maintitle" == Key.ToLowerInvariant())
            {
                query.Where(p => p.MainTitle.In(KeyIds));
            }
            if("title" == Key.ToLowerInvariant())
            {
                query.Where(p => p.Title.In(KeyIds));
            }
            if("messagetime" == Key.ToLowerInvariant())
            {
                query.Where(p => p.MessageTime.In(KeyIds));
            }
            if("content" == Key.ToLowerInvariant())
            {
                query.Where(p => p.Content.In(KeyIds));
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
        public List<Message_Grant_View> SelectByPage(string Key, int start, int PageSize, bool desc = true,Message_Grant_View model = null, string SelectFiled = null, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var query = new LambdaQuery<Message_Grant_View>();
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
                if (!model.MessageId.IsNullOrEmpty())
                {
                    query.Where(p => p.MessageId == model.MessageId);
                }
                if (!model.IsWatch.IsNullOrEmpty())
                {
                    query.Where(p => p.IsWatch == model.IsWatch);
                }
                if (!model.MainTitle.IsNullOrEmpty())
                {
                    query.Where(p => p.MainTitle == model.MainTitle);
                }
                if (!model.Title.IsNullOrEmpty())
                {
                    query.Where(p => p.Title == model.Title);
                }
                if (!model.MessageTime.IsNullOrEmpty())
                {
                    query.Where(p => p.MessageTime == model.MessageTime);
                }
                if (!model.Content.IsNullOrEmpty())
                {
                    query.Where(p => p.Content == model.Content);
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
                if (SelectFiled.Contains("userid,"))
                {
                    query.Select(p => new { p.UserId });
                }
                if (SelectFiled.Contains("messageid,"))
                {
                    query.Select(p => new { p.MessageId });
                }
                if (SelectFiled.Contains("iswatch,"))
                {
                    query.Select(p => new { p.IsWatch });
                }
                if (SelectFiled.Contains("maintitle,"))
                {
                    query.Select(p => new { p.MainTitle });
                }
                if (SelectFiled.Contains("title,"))
                {
                    query.Select(p => new { p.Title });
                }
                if (SelectFiled.Contains("messagetime,"))
                {
                    query.Select(p => new { p.MessageTime });
                }
                if (SelectFiled.Contains("content,"))
                {
                    query.Select(p => new { p.Content });
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
