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
    public partial class Distribution_Production_ViewOper : SingleTon<Distribution_Production_ViewOper>
    {
        /// <summary>
        /// 筛选全部数据
        /// </summary>
        /// <param name="model">模型</param>
        /// <param name="connection">连接</param>
        /// <param name="transaction">事务</param>
        /// <returns>对象列表</returns>
        public List<Distribution_Production_View> SelectAll(Distribution_Production_View model = null, string SelectFiled = null, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var query = new LambdaQuery<Distribution_Production_View>();
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
                if (!model.procedures.IsNullOrEmpty())
                {
                    query.Where(p => p.procedures == model.procedures);
                }
                if (!model.productionTime.IsNullOrEmpty())
                {
                    query.Where(p => p.productionTime == model.productionTime);
                }
                if (!model.productionMan.IsNullOrEmpty())
                {
                    query.Where(p => p.productionMan == model.productionMan);
                }
                if (!model.ProductionStatus.IsNullOrEmpty())
                {
                    query.Where(p => p.ProductionStatus == model.ProductionStatus);
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
                if (SelectFiled.Contains("procedures,"))
                {
                    query.Select(p => new { p.procedures });
                }
                if (SelectFiled.Contains("productiontime,"))
                {
                    query.Select(p => new { p.productionTime });
                }
                if (SelectFiled.Contains("productionman,"))
                {
                    query.Select(p => new { p.productionMan });
                }
                if (SelectFiled.Contains("productionstatus,"))
                {
                    query.Select(p => new { p.ProductionStatus });
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
        public int SelectCount(Distribution_Production_View model = null, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var query = new LambdaQuery<Distribution_Production_View>();
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
                if (!model.procedures.IsNullOrEmpty())
                {
                    query.Where(p => p.procedures == model.procedures);
                }
                if (!model.productionTime.IsNullOrEmpty())
                {
                    query.Where(p => p.productionTime == model.productionTime);
                }
                if (!model.productionMan.IsNullOrEmpty())
                {
                    query.Where(p => p.productionMan == model.productionMan);
                }
                if (!model.ProductionStatus.IsNullOrEmpty())
                {
                    query.Where(p => p.ProductionStatus == model.ProductionStatus);
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
        public Distribution_Production_View SelectById(int KeyId, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var query = new LambdaQuery<Distribution_Production_View>();
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
        public List<Distribution_Production_View> SelectByKeys(string Key,List<string> KeyIds, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var query = new LambdaQuery<Distribution_Production_View>();
            if("id" == Key.ToLowerInvariant())
            {
                query.Where(p => p.Id.In(KeyIds));
            }
            if("productionid" == Key.ToLowerInvariant())
            {
                query.Where(p => p.ProductionId.In(KeyIds));
            }
            if("procedures" == Key.ToLowerInvariant())
            {
                query.Where(p => p.procedures.In(KeyIds));
            }
            if("productiontime" == Key.ToLowerInvariant())
            {
                query.Where(p => p.productionTime.In(KeyIds));
            }
            if("productionman" == Key.ToLowerInvariant())
            {
                query.Where(p => p.productionMan.In(KeyIds));
            }
            if("productionstatus" == Key.ToLowerInvariant())
            {
                query.Where(p => p.ProductionStatus.In(KeyIds));
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
        public List<Distribution_Production_View> SelectByPage(string Key, int start, int PageSize, bool desc = true,Distribution_Production_View model = null, string SelectFiled = null, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var query = new LambdaQuery<Distribution_Production_View>();
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
                if (!model.procedures.IsNullOrEmpty())
                {
                    query.Where(p => p.procedures == model.procedures);
                }
                if (!model.productionTime.IsNullOrEmpty())
                {
                    query.Where(p => p.productionTime == model.productionTime);
                }
                if (!model.productionMan.IsNullOrEmpty())
                {
                    query.Where(p => p.productionMan == model.productionMan);
                }
                if (!model.ProductionStatus.IsNullOrEmpty())
                {
                    query.Where(p => p.ProductionStatus == model.ProductionStatus);
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
                if (SelectFiled.Contains("procedures,"))
                {
                    query.Select(p => new { p.procedures });
                }
                if (SelectFiled.Contains("productiontime,"))
                {
                    query.Select(p => new { p.productionTime });
                }
                if (SelectFiled.Contains("productionman,"))
                {
                    query.Select(p => new { p.productionMan });
                }
                if (SelectFiled.Contains("productionstatus,"))
                {
                    query.Select(p => new { p.ProductionStatus });
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
