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
    public partial class Receive_Raw_ViewOper : SingleTon<Receive_Raw_ViewOper>
    {
        /// <summary>
        /// 筛选全部数据
        /// </summary>
        /// <param name="model">模型</param>
        /// <param name="connection">连接</param>
        /// <param name="transaction">事务</param>
        /// <returns>对象列表</returns>
        public List<Receive_Raw_View> SelectAll(Receive_Raw_View model = null, string SelectFiled = null, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var query = new LambdaQuery<Receive_Raw_View>();
            if (model != null)
            {
                if (!model.Id.IsNullOrEmpty())
                {
                    query.Where(p => p.Id == model.Id);
                }
                if (!model.receiveId.IsNullOrEmpty())
                {
                    query.Where(p => p.receiveId == model.receiveId);
                }
                if (!model.additionalCount.IsNullOrEmpty())
                {
                    query.Where(p => p.additionalCount == model.additionalCount);
                }
                if (!model.Isadditional.IsNullOrEmpty())
                {
                    query.Where(p => p.Isadditional == model.Isadditional);
                }
                if (!model.BaseCount.IsNullOrEmpty())
                {
                    query.Where(p => p.BaseCount == model.BaseCount);
                }
                if (!model.SKU.IsNullOrEmpty())
                {
                    query.Where(p => p.SKU == model.SKU);
                }
                if (!model.productionId.IsNullOrEmpty())
                {
                    query.Where(p => p.productionId == model.productionId);
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
                if (!model.CommodityId.IsNullOrEmpty())
                {
                    query.Where(p => p.CommodityId == model.CommodityId);
                }
                if (!model.Amount.IsNullOrEmpty())
                {
                    query.Where(p => p.Amount == model.Amount);
                }
                if (!model.OrderId.IsNullOrEmpty())
                {
                    query.Where(p => p.OrderId == model.OrderId);
                }
                if (!model.MaterialId.IsNullOrEmpty())
                {
                    query.Where(p => p.MaterialId == model.MaterialId);
                }
                if (!model.ChinaProductName.IsNullOrEmpty())
                {
                    query.Where(p => p.ChinaProductName == model.ChinaProductName);
                }
                if (!model.ChinaUnit.IsNullOrEmpty())
                {
                    query.Where(p => p.ChinaUnit == model.ChinaUnit);
                }
                if (!model.Specification.IsNullOrEmpty())
                {
                    query.Where(p => p.Specification == model.Specification);
                }
            }
            if (SelectFiled != null)
            {
                SelectFiled = SelectFiled.ToLowerInvariant();
                if (SelectFiled.Contains("id,"))
                {
                    query.Select(p => new { p.Id });
                }
                if (SelectFiled.Contains("receiveid,"))
                {
                    query.Select(p => new { p.receiveId });
                }
                if (SelectFiled.Contains("additionalcount,"))
                {
                    query.Select(p => new { p.additionalCount });
                }
                if (SelectFiled.Contains("isadditional,"))
                {
                    query.Select(p => new { p.Isadditional });
                }
                if (SelectFiled.Contains("basecount,"))
                {
                    query.Select(p => new { p.BaseCount });
                }
                if (SelectFiled.Contains("sku,"))
                {
                    query.Select(p => new { p.SKU });
                }
                if (SelectFiled.Contains("productionid,"))
                {
                    query.Select(p => new { p.productionId });
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
                if (SelectFiled.Contains("commodityid,"))
                {
                    query.Select(p => new { p.CommodityId });
                }
                if (SelectFiled.Contains("amount,"))
                {
                    query.Select(p => new { p.Amount });
                }
                if (SelectFiled.Contains("orderid,"))
                {
                    query.Select(p => new { p.OrderId });
                }
                if (SelectFiled.Contains("materialid,"))
                {
                    query.Select(p => new { p.MaterialId });
                }
                if (SelectFiled.Contains("chinaproductname,"))
                {
                    query.Select(p => new { p.ChinaProductName });
                }
                if (SelectFiled.Contains("chinaunit,"))
                {
                    query.Select(p => new { p.ChinaUnit });
                }
                if (SelectFiled.Contains("specification,"))
                {
                    query.Select(p => new { p.Specification });
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
        public int SelectCount(Receive_Raw_View model = null, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var query = new LambdaQuery<Receive_Raw_View>();
            if (model != null)
            {
                if (!model.Id.IsNullOrEmpty())
                {
                    query.Where(p => p.Id == model.Id);
                }
                if (!model.receiveId.IsNullOrEmpty())
                {
                    query.Where(p => p.receiveId == model.receiveId);
                }
                if (!model.additionalCount.IsNullOrEmpty())
                {
                    query.Where(p => p.additionalCount == model.additionalCount);
                }
                if (!model.Isadditional.IsNullOrEmpty())
                {
                    query.Where(p => p.Isadditional == model.Isadditional);
                }
                if (!model.BaseCount.IsNullOrEmpty())
                {
                    query.Where(p => p.BaseCount == model.BaseCount);
                }
                if (!model.SKU.IsNullOrEmpty())
                {
                    query.Where(p => p.SKU == model.SKU);
                }
                if (!model.productionId.IsNullOrEmpty())
                {
                    query.Where(p => p.productionId == model.productionId);
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
                if (!model.CommodityId.IsNullOrEmpty())
                {
                    query.Where(p => p.CommodityId == model.CommodityId);
                }
                if (!model.Amount.IsNullOrEmpty())
                {
                    query.Where(p => p.Amount == model.Amount);
                }
                if (!model.OrderId.IsNullOrEmpty())
                {
                    query.Where(p => p.OrderId == model.OrderId);
                }
                if (!model.MaterialId.IsNullOrEmpty())
                {
                    query.Where(p => p.MaterialId == model.MaterialId);
                }
                if (!model.ChinaProductName.IsNullOrEmpty())
                {
                    query.Where(p => p.ChinaProductName == model.ChinaProductName);
                }
                if (!model.ChinaUnit.IsNullOrEmpty())
                {
                    query.Where(p => p.ChinaUnit == model.ChinaUnit);
                }
                if (!model.Specification.IsNullOrEmpty())
                {
                    query.Where(p => p.Specification == model.Specification);
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
        public Receive_Raw_View SelectById(int KeyId, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var query = new LambdaQuery<Receive_Raw_View>();
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
        public List<Receive_Raw_View> SelectByKeys(string Key,List<string> KeyIds, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var query = new LambdaQuery<Receive_Raw_View>();
            if("id" == Key.ToLowerInvariant())
            {
                query.Where(p => p.Id.In(KeyIds));
            }
            if("receiveid" == Key.ToLowerInvariant())
            {
                query.Where(p => p.receiveId.In(KeyIds));
            }
            if("additionalcount" == Key.ToLowerInvariant())
            {
                query.Where(p => p.additionalCount.In(KeyIds));
            }
            if("isadditional" == Key.ToLowerInvariant())
            {
                query.Where(p => p.Isadditional.In(KeyIds));
            }
            if("basecount" == Key.ToLowerInvariant())
            {
                query.Where(p => p.BaseCount.In(KeyIds));
            }
            if("sku" == Key.ToLowerInvariant())
            {
                query.Where(p => p.SKU.In(KeyIds));
            }
            if("productionid" == Key.ToLowerInvariant())
            {
                query.Where(p => p.productionId.In(KeyIds));
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
            if("commodityid" == Key.ToLowerInvariant())
            {
                query.Where(p => p.CommodityId.In(KeyIds));
            }
            if("amount" == Key.ToLowerInvariant())
            {
                query.Where(p => p.Amount.In(KeyIds));
            }
            if("orderid" == Key.ToLowerInvariant())
            {
                query.Where(p => p.OrderId.In(KeyIds));
            }
            if("materialid" == Key.ToLowerInvariant())
            {
                query.Where(p => p.MaterialId.In(KeyIds));
            }
            if("chinaproductname" == Key.ToLowerInvariant())
            {
                query.Where(p => p.ChinaProductName.In(KeyIds));
            }
            if("chinaunit" == Key.ToLowerInvariant())
            {
                query.Where(p => p.ChinaUnit.In(KeyIds));
            }
            if("specification" == Key.ToLowerInvariant())
            {
                query.Where(p => p.Specification.In(KeyIds));
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
        public List<Receive_Raw_View> SelectByPage(string Key, int start, int PageSize, bool desc = true,Receive_Raw_View model = null, string SelectFiled = null, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var query = new LambdaQuery<Receive_Raw_View>();
            if (model != null)
            {
                if (!model.Id.IsNullOrEmpty())
                {
                    query.Where(p => p.Id == model.Id);
                }
                if (!model.receiveId.IsNullOrEmpty())
                {
                    query.Where(p => p.receiveId == model.receiveId);
                }
                if (!model.additionalCount.IsNullOrEmpty())
                {
                    query.Where(p => p.additionalCount == model.additionalCount);
                }
                if (!model.Isadditional.IsNullOrEmpty())
                {
                    query.Where(p => p.Isadditional == model.Isadditional);
                }
                if (!model.BaseCount.IsNullOrEmpty())
                {
                    query.Where(p => p.BaseCount == model.BaseCount);
                }
                if (!model.SKU.IsNullOrEmpty())
                {
                    query.Where(p => p.SKU == model.SKU);
                }
                if (!model.productionId.IsNullOrEmpty())
                {
                    query.Where(p => p.productionId == model.productionId);
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
                if (!model.CommodityId.IsNullOrEmpty())
                {
                    query.Where(p => p.CommodityId == model.CommodityId);
                }
                if (!model.Amount.IsNullOrEmpty())
                {
                    query.Where(p => p.Amount == model.Amount);
                }
                if (!model.OrderId.IsNullOrEmpty())
                {
                    query.Where(p => p.OrderId == model.OrderId);
                }
                if (!model.MaterialId.IsNullOrEmpty())
                {
                    query.Where(p => p.MaterialId == model.MaterialId);
                }
                if (!model.ChinaProductName.IsNullOrEmpty())
                {
                    query.Where(p => p.ChinaProductName == model.ChinaProductName);
                }
                if (!model.ChinaUnit.IsNullOrEmpty())
                {
                    query.Where(p => p.ChinaUnit == model.ChinaUnit);
                }
                if (!model.Specification.IsNullOrEmpty())
                {
                    query.Where(p => p.Specification == model.Specification);
                }
            }
            if (SelectFiled != null)
            {
                SelectFiled = SelectFiled.ToLowerInvariant();
                if (SelectFiled.Contains("id,"))
                {
                    query.Select(p => new { p.Id });
                }
                if (SelectFiled.Contains("receiveid,"))
                {
                    query.Select(p => new { p.receiveId });
                }
                if (SelectFiled.Contains("additionalcount,"))
                {
                    query.Select(p => new { p.additionalCount });
                }
                if (SelectFiled.Contains("isadditional,"))
                {
                    query.Select(p => new { p.Isadditional });
                }
                if (SelectFiled.Contains("basecount,"))
                {
                    query.Select(p => new { p.BaseCount });
                }
                if (SelectFiled.Contains("sku,"))
                {
                    query.Select(p => new { p.SKU });
                }
                if (SelectFiled.Contains("productionid,"))
                {
                    query.Select(p => new { p.productionId });
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
                if (SelectFiled.Contains("commodityid,"))
                {
                    query.Select(p => new { p.CommodityId });
                }
                if (SelectFiled.Contains("amount,"))
                {
                    query.Select(p => new { p.Amount });
                }
                if (SelectFiled.Contains("orderid,"))
                {
                    query.Select(p => new { p.OrderId });
                }
                if (SelectFiled.Contains("materialid,"))
                {
                    query.Select(p => new { p.MaterialId });
                }
                if (SelectFiled.Contains("chinaproductname,"))
                {
                    query.Select(p => new { p.ChinaProductName });
                }
                if (SelectFiled.Contains("chinaunit,"))
                {
                    query.Select(p => new { p.ChinaUnit });
                }
                if (SelectFiled.Contains("specification,"))
                {
                    query.Select(p => new { p.Specification });
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
