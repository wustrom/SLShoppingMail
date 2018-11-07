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
    public partial class Receive_Order_ViewOper : SingleTon<Receive_Order_ViewOper>
    {
        /// <summary>
        /// 筛选全部数据
        /// </summary>
        /// <param name="model">模型</param>
        /// <param name="connection">连接</param>
        /// <param name="transaction">事务</param>
        /// <returns>对象列表</returns>
        public List<Receive_Order_View> SelectAll(Receive_Order_View model = null, string SelectFiled = null, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var query = new LambdaQuery<Receive_Order_View>();
            if (model != null)
            {
                if (!model.Id.IsNullOrEmpty())
                {
                    query.Where(p => p.Id == model.Id);
                }
                if (!model.ProductionId.IsNullOrEmpty())
                {
                    query.Where(p => p.ProductionId == model.ProductionId);
                }
                if (!model.receiveStatus.IsNullOrEmpty())
                {
                    query.Where(p => p.receiveStatus == model.receiveStatus);
                }
                if (!model.receiveOutTime.IsNullOrEmpty())
                {
                    query.Where(p => p.receiveOutTime == model.receiveOutTime);
                }
                if (!model.receiveTime.IsNullOrEmpty())
                {
                    query.Where(p => p.receiveTime == model.receiveTime);
                }
                if (!model.receiveContext.IsNullOrEmpty())
                {
                    query.Where(p => p.receiveContext == model.receiveContext);
                }
                if (!model.receiveSinglePerson.IsNullOrEmpty())
                {
                    query.Where(p => p.receiveSinglePerson == model.receiveSinglePerson);
                }
                if (!model.receiveSingleTime.IsNullOrEmpty())
                {
                    query.Where(p => p.receiveSingleTime == model.receiveSingleTime);
                }
                if (!model.order_detailId.IsNullOrEmpty())
                {
                    query.Where(p => p.order_detailId == model.order_detailId);
                }
                if (!model.Amount.IsNullOrEmpty())
                {
                    query.Where(p => p.Amount == model.Amount);
                }
                if (!model.OrderNo.IsNullOrEmpty())
                {
                    query.Where(p => p.OrderNo == model.OrderNo);
                }
                if (!model.ProductionNo.IsNullOrEmpty())
                {
                    query.Where(p => p.ProductionNo == model.ProductionNo);
                }
            }
            if (SelectFiled != null)
            {
                SelectFiled = SelectFiled.ToLowerInvariant();
                if (SelectFiled.Contains("id,"))
                {
                    query.Select(p => new { p.Id });
                }
                if (SelectFiled.Contains("productionid,"))
                {
                    query.Select(p => new { p.ProductionId });
                }
                if (SelectFiled.Contains("receivestatus,"))
                {
                    query.Select(p => new { p.receiveStatus });
                }
                if (SelectFiled.Contains("receiveouttime,"))
                {
                    query.Select(p => new { p.receiveOutTime });
                }
                if (SelectFiled.Contains("receivetime,"))
                {
                    query.Select(p => new { p.receiveTime });
                }
                if (SelectFiled.Contains("receivecontext,"))
                {
                    query.Select(p => new { p.receiveContext });
                }
                if (SelectFiled.Contains("receivesingleperson,"))
                {
                    query.Select(p => new { p.receiveSinglePerson });
                }
                if (SelectFiled.Contains("receivesingletime,"))
                {
                    query.Select(p => new { p.receiveSingleTime });
                }
                if (SelectFiled.Contains("order_detailid,"))
                {
                    query.Select(p => new { p.order_detailId });
                }
                if (SelectFiled.Contains("amount,"))
                {
                    query.Select(p => new { p.Amount });
                }
                if (SelectFiled.Contains("orderno,"))
                {
                    query.Select(p => new { p.OrderNo });
                }
                if (SelectFiled.Contains("productionno,"))
                {
                    query.Select(p => new { p.ProductionNo });
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
        public int SelectCount(Receive_Order_View model = null, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var query = new LambdaQuery<Receive_Order_View>();
            if (model != null)
            {
                if (!model.Id.IsNullOrEmpty())
                {
                    query.Where(p => p.Id == model.Id);
                }
                if (!model.ProductionId.IsNullOrEmpty())
                {
                    query.Where(p => p.ProductionId == model.ProductionId);
                }
                if (!model.receiveStatus.IsNullOrEmpty())
                {
                    query.Where(p => p.receiveStatus == model.receiveStatus);
                }
                if (!model.receiveOutTime.IsNullOrEmpty())
                {
                    query.Where(p => p.receiveOutTime == model.receiveOutTime);
                }
                if (!model.receiveTime.IsNullOrEmpty())
                {
                    query.Where(p => p.receiveTime == model.receiveTime);
                }
                if (!model.receiveContext.IsNullOrEmpty())
                {
                    query.Where(p => p.receiveContext == model.receiveContext);
                }
                if (!model.receiveSinglePerson.IsNullOrEmpty())
                {
                    query.Where(p => p.receiveSinglePerson == model.receiveSinglePerson);
                }
                if (!model.receiveSingleTime.IsNullOrEmpty())
                {
                    query.Where(p => p.receiveSingleTime == model.receiveSingleTime);
                }
                if (!model.order_detailId.IsNullOrEmpty())
                {
                    query.Where(p => p.order_detailId == model.order_detailId);
                }
                if (!model.Amount.IsNullOrEmpty())
                {
                    query.Where(p => p.Amount == model.Amount);
                }
                if (!model.OrderNo.IsNullOrEmpty())
                {
                    query.Where(p => p.OrderNo == model.OrderNo);
                }
                if (!model.ProductionNo.IsNullOrEmpty())
                {
                    query.Where(p => p.ProductionNo == model.ProductionNo);
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
        public Receive_Order_View SelectById(int KeyId, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var query = new LambdaQuery<Receive_Order_View>();
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
        public List<Receive_Order_View> SelectByKeys(string Key,List<string> KeyIds, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var query = new LambdaQuery<Receive_Order_View>();
            if("id" == Key.ToLowerInvariant())
            {
                query.Where(p => p.Id.In(KeyIds));
            }
            if("productionid" == Key.ToLowerInvariant())
            {
                query.Where(p => p.ProductionId.In(KeyIds));
            }
            if("receivestatus" == Key.ToLowerInvariant())
            {
                query.Where(p => p.receiveStatus.In(KeyIds));
            }
            if("receiveouttime" == Key.ToLowerInvariant())
            {
                query.Where(p => p.receiveOutTime.In(KeyIds));
            }
            if("receivetime" == Key.ToLowerInvariant())
            {
                query.Where(p => p.receiveTime.In(KeyIds));
            }
            if("receivecontext" == Key.ToLowerInvariant())
            {
                query.Where(p => p.receiveContext.In(KeyIds));
            }
            if("receivesingleperson" == Key.ToLowerInvariant())
            {
                query.Where(p => p.receiveSinglePerson.In(KeyIds));
            }
            if("receivesingletime" == Key.ToLowerInvariant())
            {
                query.Where(p => p.receiveSingleTime.In(KeyIds));
            }
            if("order_detailid" == Key.ToLowerInvariant())
            {
                query.Where(p => p.order_detailId.In(KeyIds));
            }
            if("amount" == Key.ToLowerInvariant())
            {
                query.Where(p => p.Amount.In(KeyIds));
            }
            if("orderno" == Key.ToLowerInvariant())
            {
                query.Where(p => p.OrderNo.In(KeyIds));
            }
            if("productionno" == Key.ToLowerInvariant())
            {
                query.Where(p => p.ProductionNo.In(KeyIds));
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
        public List<Receive_Order_View> SelectByPage(string Key, int start, int PageSize, bool desc = true,Receive_Order_View model = null, string SelectFiled = null, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var query = new LambdaQuery<Receive_Order_View>();
            if (model != null)
            {
                if (!model.Id.IsNullOrEmpty())
                {
                    query.Where(p => p.Id == model.Id);
                }
                if (!model.ProductionId.IsNullOrEmpty())
                {
                    query.Where(p => p.ProductionId == model.ProductionId);
                }
                if (!model.receiveStatus.IsNullOrEmpty())
                {
                    query.Where(p => p.receiveStatus == model.receiveStatus);
                }
                if (!model.receiveOutTime.IsNullOrEmpty())
                {
                    query.Where(p => p.receiveOutTime == model.receiveOutTime);
                }
                if (!model.receiveTime.IsNullOrEmpty())
                {
                    query.Where(p => p.receiveTime == model.receiveTime);
                }
                if (!model.receiveContext.IsNullOrEmpty())
                {
                    query.Where(p => p.receiveContext == model.receiveContext);
                }
                if (!model.receiveSinglePerson.IsNullOrEmpty())
                {
                    query.Where(p => p.receiveSinglePerson == model.receiveSinglePerson);
                }
                if (!model.receiveSingleTime.IsNullOrEmpty())
                {
                    query.Where(p => p.receiveSingleTime == model.receiveSingleTime);
                }
                if (!model.order_detailId.IsNullOrEmpty())
                {
                    query.Where(p => p.order_detailId == model.order_detailId);
                }
                if (!model.Amount.IsNullOrEmpty())
                {
                    query.Where(p => p.Amount == model.Amount);
                }
                if (!model.OrderNo.IsNullOrEmpty())
                {
                    query.Where(p => p.OrderNo == model.OrderNo);
                }
                if (!model.ProductionNo.IsNullOrEmpty())
                {
                    query.Where(p => p.ProductionNo == model.ProductionNo);
                }
            }
            if (SelectFiled != null)
            {
                SelectFiled = SelectFiled.ToLowerInvariant();
                if (SelectFiled.Contains("id,"))
                {
                    query.Select(p => new { p.Id });
                }
                if (SelectFiled.Contains("productionid,"))
                {
                    query.Select(p => new { p.ProductionId });
                }
                if (SelectFiled.Contains("receivestatus,"))
                {
                    query.Select(p => new { p.receiveStatus });
                }
                if (SelectFiled.Contains("receiveouttime,"))
                {
                    query.Select(p => new { p.receiveOutTime });
                }
                if (SelectFiled.Contains("receivetime,"))
                {
                    query.Select(p => new { p.receiveTime });
                }
                if (SelectFiled.Contains("receivecontext,"))
                {
                    query.Select(p => new { p.receiveContext });
                }
                if (SelectFiled.Contains("receivesingleperson,"))
                {
                    query.Select(p => new { p.receiveSinglePerson });
                }
                if (SelectFiled.Contains("receivesingletime,"))
                {
                    query.Select(p => new { p.receiveSingleTime });
                }
                if (SelectFiled.Contains("order_detailid,"))
                {
                    query.Select(p => new { p.order_detailId });
                }
                if (SelectFiled.Contains("amount,"))
                {
                    query.Select(p => new { p.Amount });
                }
                if (SelectFiled.Contains("orderno,"))
                {
                    query.Select(p => new { p.OrderNo });
                }
                if (SelectFiled.Contains("productionno,"))
                {
                    query.Select(p => new { p.ProductionNo });
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
