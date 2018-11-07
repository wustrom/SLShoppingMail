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
    public partial class DeliverOper : SingleTon<DeliverOper>
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
            var delete = new LambdaDelete<Deliver>();
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
        public bool DeleteModel(Deliver model = null, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var delete = new LambdaDelete<Deliver>();
            if (model != null)
            {
                if (!model.Id.IsNullOrEmpty())
                {
                    delete.Where(p => p.Id == model.Id);
                }
                if (!model.buyerId.IsNullOrEmpty())
                {
                    delete.Where(p => p.buyerId == model.buyerId);
                }
                if (!model.Raw_materialsId.IsNullOrEmpty())
                {
                    delete.Where(p => p.Raw_materialsId == model.Raw_materialsId);
                }
                if (!model.ProducerId.IsNullOrEmpty())
                {
                    delete.Where(p => p.ProducerId == model.ProducerId);
                }
                if (!model.buyerPrice.IsNullOrEmpty())
                {
                    delete.Where(p => p.buyerPrice == model.buyerPrice);
                }
                if (!model.buyerCount.IsNullOrEmpty())
                {
                    delete.Where(p => p.buyerCount == model.buyerCount);
                }
                if (!model.DeliverMoney.IsNullOrEmpty())
                {
                    delete.Where(p => p.DeliverMoney == model.DeliverMoney);
                }
                if (!model.IsStatus.IsNullOrEmpty())
                {
                    delete.Where(p => p.IsStatus == model.IsStatus);
                }
                if (!model.Color.IsNullOrEmpty())
                {
                    delete.Where(p => p.Color == model.Color);
                }
                if (!model.DeliverCountext.IsNullOrEmpty())
                {
                    delete.Where(p => p.DeliverCountext == model.DeliverCountext);
                }
                if (!model.DeliverSinglePerson.IsNullOrEmpty())
                {
                    delete.Where(p => p.DeliverSinglePerson == model.DeliverSinglePerson);
                }
                if (!model.DeliverSingleTime.IsNullOrEmpty())
                {
                    delete.Where(p => p.DeliverSingleTime == model.DeliverSingleTime);
                }
                if (!model.AlreadyQuantity.IsNullOrEmpty())
                {
                    delete.Where(p => p.AlreadyQuantity == model.AlreadyQuantity);
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
        public bool Update(Deliver model, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var update = new LambdaUpdate<Deliver>();
            if (!model.Id.IsNullOrEmpty())
            {
                update.Where(p => p.Id == model.Id);
            }
            if (!model.buyerId.IsNullOrEmpty())
            {
                update.Set(p => p.buyerId == model.buyerId);
            }
            if (!model.Raw_materialsId.IsNullOrEmpty())
            {
                update.Set(p => p.Raw_materialsId == model.Raw_materialsId);
            }
            if (!model.ProducerId.IsNullOrEmpty())
            {
                update.Set(p => p.ProducerId == model.ProducerId);
            }
            if (!model.buyerPrice.IsNullOrEmpty())
            {
                update.Set(p => p.buyerPrice == model.buyerPrice);
            }
            if (!model.buyerCount.IsNullOrEmpty())
            {
                update.Set(p => p.buyerCount == model.buyerCount);
            }
            if (!model.DeliverMoney.IsNullOrEmpty())
            {
                update.Set(p => p.DeliverMoney == model.DeliverMoney);
            }
            if (!model.IsStatus.IsNullOrEmpty())
            {
                update.Set(p => p.IsStatus == model.IsStatus);
            }
            if (!model.Color.IsNullOrEmpty())
            {
                update.Set(p => p.Color == model.Color);
            }
            if (!model.DeliverCountext.IsNullOrEmpty())
            {
                update.Set(p => p.DeliverCountext == model.DeliverCountext);
            }
            if (!model.DeliverSinglePerson.IsNullOrEmpty())
            {
                update.Set(p => p.DeliverSinglePerson == model.DeliverSinglePerson);
            }
            if (!model.DeliverSingleTime.IsNullOrEmpty())
            {
                update.Set(p => p.DeliverSingleTime == model.DeliverSingleTime);
            }
            if (!model.AlreadyQuantity.IsNullOrEmpty())
            {
                update.Set(p => p.AlreadyQuantity == model.AlreadyQuantity);
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
        public bool Insert(Deliver model, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var insert = new LambdaInsert<Deliver>();
            if (!model.buyerId.IsNullOrEmpty())
            {
                insert.Insert(p => p.buyerId == model.buyerId);
            }
            if (!model.Raw_materialsId.IsNullOrEmpty())
            {
                insert.Insert(p => p.Raw_materialsId == model.Raw_materialsId);
            }
            if (!model.ProducerId.IsNullOrEmpty())
            {
                insert.Insert(p => p.ProducerId == model.ProducerId);
            }
            if (!model.buyerPrice.IsNullOrEmpty())
            {
                insert.Insert(p => p.buyerPrice == model.buyerPrice);
            }
            if (!model.buyerCount.IsNullOrEmpty())
            {
                insert.Insert(p => p.buyerCount == model.buyerCount);
            }
            if (!model.DeliverMoney.IsNullOrEmpty())
            {
                insert.Insert(p => p.DeliverMoney == model.DeliverMoney);
            }
            if (!model.IsStatus.IsNullOrEmpty())
            {
                insert.Insert(p => p.IsStatus == model.IsStatus);
            }
            if (!model.Color.IsNullOrEmpty())
            {
                insert.Insert(p => p.Color == model.Color);
            }
            if (!model.DeliverCountext.IsNullOrEmpty())
            {
                insert.Insert(p => p.DeliverCountext == model.DeliverCountext);
            }
            if (!model.DeliverSinglePerson.IsNullOrEmpty())
            {
                insert.Insert(p => p.DeliverSinglePerson == model.DeliverSinglePerson);
            }
            if (!model.DeliverSingleTime.IsNullOrEmpty())
            {
                insert.Insert(p => p.DeliverSingleTime == model.DeliverSingleTime);
            }
            if (!model.AlreadyQuantity.IsNullOrEmpty())
            {
                insert.Insert(p => p.AlreadyQuantity == model.AlreadyQuantity);
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
        public int InsertReturnKey(Deliver model, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var insert = new LambdaInsert<Deliver>();
            if (!model.buyerId.IsNullOrEmpty())
            {
                insert.Insert(p => p.buyerId == model.buyerId);
            }
            if (!model.Raw_materialsId.IsNullOrEmpty())
            {
                insert.Insert(p => p.Raw_materialsId == model.Raw_materialsId);
            }
            if (!model.ProducerId.IsNullOrEmpty())
            {
                insert.Insert(p => p.ProducerId == model.ProducerId);
            }
            if (!model.buyerPrice.IsNullOrEmpty())
            {
                insert.Insert(p => p.buyerPrice == model.buyerPrice);
            }
            if (!model.buyerCount.IsNullOrEmpty())
            {
                insert.Insert(p => p.buyerCount == model.buyerCount);
            }
            if (!model.DeliverMoney.IsNullOrEmpty())
            {
                insert.Insert(p => p.DeliverMoney == model.DeliverMoney);
            }
            if (!model.IsStatus.IsNullOrEmpty())
            {
                insert.Insert(p => p.IsStatus == model.IsStatus);
            }
            if (!model.Color.IsNullOrEmpty())
            {
                insert.Insert(p => p.Color == model.Color);
            }
            if (!model.DeliverCountext.IsNullOrEmpty())
            {
                insert.Insert(p => p.DeliverCountext == model.DeliverCountext);
            }
            if (!model.DeliverSinglePerson.IsNullOrEmpty())
            {
                insert.Insert(p => p.DeliverSinglePerson == model.DeliverSinglePerson);
            }
            if (!model.DeliverSingleTime.IsNullOrEmpty())
            {
                insert.Insert(p => p.DeliverSingleTime == model.DeliverSingleTime);
            }
            if (!model.AlreadyQuantity.IsNullOrEmpty())
            {
                insert.Insert(p => p.AlreadyQuantity == model.AlreadyQuantity);
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
        public List<Deliver> SelectAll(Deliver model = null, string SelectFiled = null, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var query = new LambdaQuery<Deliver>();
            if (model != null)
            {
                if (!model.Id.IsNullOrEmpty())
                {
                    query.Where(p => p.Id == model.Id);
                }
                if (!model.buyerId.IsNullOrEmpty())
                {
                    query.Where(p => p.buyerId == model.buyerId);
                }
                if (!model.Raw_materialsId.IsNullOrEmpty())
                {
                    query.Where(p => p.Raw_materialsId == model.Raw_materialsId);
                }
                if (!model.ProducerId.IsNullOrEmpty())
                {
                    query.Where(p => p.ProducerId == model.ProducerId);
                }
                if (!model.buyerPrice.IsNullOrEmpty())
                {
                    query.Where(p => p.buyerPrice == model.buyerPrice);
                }
                if (!model.buyerCount.IsNullOrEmpty())
                {
                    query.Where(p => p.buyerCount == model.buyerCount);
                }
                if (!model.DeliverMoney.IsNullOrEmpty())
                {
                    query.Where(p => p.DeliverMoney == model.DeliverMoney);
                }
                if (!model.IsStatus.IsNullOrEmpty())
                {
                    query.Where(p => p.IsStatus == model.IsStatus);
                }
                if (!model.Color.IsNullOrEmpty())
                {
                    query.Where(p => p.Color == model.Color);
                }
                if (!model.DeliverCountext.IsNullOrEmpty())
                {
                    query.Where(p => p.DeliverCountext == model.DeliverCountext);
                }
                if (!model.DeliverSinglePerson.IsNullOrEmpty())
                {
                    query.Where(p => p.DeliverSinglePerson == model.DeliverSinglePerson);
                }
                if (!model.DeliverSingleTime.IsNullOrEmpty())
                {
                    query.Where(p => p.DeliverSingleTime == model.DeliverSingleTime);
                }
                if (!model.AlreadyQuantity.IsNullOrEmpty())
                {
                    query.Where(p => p.AlreadyQuantity == model.AlreadyQuantity);
                }
            }
            if (SelectFiled != null)
            {
                SelectFiled = SelectFiled.ToLowerInvariant();
                if (SelectFiled.Contains("id,"))
                {
                    query.Select(p => new { p.Id });
                }
                if (SelectFiled.Contains("buyerid,"))
                {
                    query.Select(p => new { p.buyerId });
                }
                if (SelectFiled.Contains("raw_materialsid,"))
                {
                    query.Select(p => new { p.Raw_materialsId });
                }
                if (SelectFiled.Contains("producerid,"))
                {
                    query.Select(p => new { p.ProducerId });
                }
                if (SelectFiled.Contains("buyerprice,"))
                {
                    query.Select(p => new { p.buyerPrice });
                }
                if (SelectFiled.Contains("buyercount,"))
                {
                    query.Select(p => new { p.buyerCount });
                }
                if (SelectFiled.Contains("delivermoney,"))
                {
                    query.Select(p => new { p.DeliverMoney });
                }
                if (SelectFiled.Contains("isstatus,"))
                {
                    query.Select(p => new { p.IsStatus });
                }
                if (SelectFiled.Contains("color,"))
                {
                    query.Select(p => new { p.Color });
                }
                if (SelectFiled.Contains("delivercountext,"))
                {
                    query.Select(p => new { p.DeliverCountext });
                }
                if (SelectFiled.Contains("deliversingleperson,"))
                {
                    query.Select(p => new { p.DeliverSinglePerson });
                }
                if (SelectFiled.Contains("deliversingletime,"))
                {
                    query.Select(p => new { p.DeliverSingleTime });
                }
                if (SelectFiled.Contains("alreadyquantity,"))
                {
                    query.Select(p => new { p.AlreadyQuantity });
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
        public int SelectCount(Deliver model = null, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var query = new LambdaQuery<Deliver>();
            if (model != null)
            {
                if (!model.Id.IsNullOrEmpty())
                {
                    query.Where(p => p.Id == model.Id);
                }
                if (!model.buyerId.IsNullOrEmpty())
                {
                    query.Where(p => p.buyerId == model.buyerId);
                }
                if (!model.Raw_materialsId.IsNullOrEmpty())
                {
                    query.Where(p => p.Raw_materialsId == model.Raw_materialsId);
                }
                if (!model.ProducerId.IsNullOrEmpty())
                {
                    query.Where(p => p.ProducerId == model.ProducerId);
                }
                if (!model.buyerPrice.IsNullOrEmpty())
                {
                    query.Where(p => p.buyerPrice == model.buyerPrice);
                }
                if (!model.buyerCount.IsNullOrEmpty())
                {
                    query.Where(p => p.buyerCount == model.buyerCount);
                }
                if (!model.DeliverMoney.IsNullOrEmpty())
                {
                    query.Where(p => p.DeliverMoney == model.DeliverMoney);
                }
                if (!model.IsStatus.IsNullOrEmpty())
                {
                    query.Where(p => p.IsStatus == model.IsStatus);
                }
                if (!model.Color.IsNullOrEmpty())
                {
                    query.Where(p => p.Color == model.Color);
                }
                if (!model.DeliverCountext.IsNullOrEmpty())
                {
                    query.Where(p => p.DeliverCountext == model.DeliverCountext);
                }
                if (!model.DeliverSinglePerson.IsNullOrEmpty())
                {
                    query.Where(p => p.DeliverSinglePerson == model.DeliverSinglePerson);
                }
                if (!model.DeliverSingleTime.IsNullOrEmpty())
                {
                    query.Where(p => p.DeliverSingleTime == model.DeliverSingleTime);
                }
                if (!model.AlreadyQuantity.IsNullOrEmpty())
                {
                    query.Where(p => p.AlreadyQuantity == model.AlreadyQuantity);
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
        public Deliver SelectById(int KeyId, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var query = new LambdaQuery<Deliver>();
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
        public List<Deliver> SelectByKeys(string Key,List<string> KeyIds, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var query = new LambdaQuery<Deliver>();
            if("id" == Key.ToLowerInvariant())
            {
                query.Where(p => p.Id.In(KeyIds));
            }
            if("buyerid" == Key.ToLowerInvariant())
            {
                query.Where(p => p.buyerId.In(KeyIds));
            }
            if("raw_materialsid" == Key.ToLowerInvariant())
            {
                query.Where(p => p.Raw_materialsId.In(KeyIds));
            }
            if("producerid" == Key.ToLowerInvariant())
            {
                query.Where(p => p.ProducerId.In(KeyIds));
            }
            if("buyerprice" == Key.ToLowerInvariant())
            {
                query.Where(p => p.buyerPrice.In(KeyIds));
            }
            if("buyercount" == Key.ToLowerInvariant())
            {
                query.Where(p => p.buyerCount.In(KeyIds));
            }
            if("delivermoney" == Key.ToLowerInvariant())
            {
                query.Where(p => p.DeliverMoney.In(KeyIds));
            }
            if("isstatus" == Key.ToLowerInvariant())
            {
                query.Where(p => p.IsStatus.In(KeyIds));
            }
            if("color" == Key.ToLowerInvariant())
            {
                query.Where(p => p.Color.In(KeyIds));
            }
            if("delivercountext" == Key.ToLowerInvariant())
            {
                query.Where(p => p.DeliverCountext.In(KeyIds));
            }
            if("deliversingleperson" == Key.ToLowerInvariant())
            {
                query.Where(p => p.DeliverSinglePerson.In(KeyIds));
            }
            if("deliversingletime" == Key.ToLowerInvariant())
            {
                query.Where(p => p.DeliverSingleTime.In(KeyIds));
            }
            if("alreadyquantity" == Key.ToLowerInvariant())
            {
                query.Where(p => p.AlreadyQuantity.In(KeyIds));
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
        public List<Deliver> SelectByPage(string Key, int start, int PageSize, bool desc = true,Deliver model = null, string SelectFiled = null, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var query = new LambdaQuery<Deliver>();
            if (model != null)
            {
                if (!model.Id.IsNullOrEmpty())
                {
                    query.Where(p => p.Id == model.Id);
                }
                if (!model.buyerId.IsNullOrEmpty())
                {
                    query.Where(p => p.buyerId == model.buyerId);
                }
                if (!model.Raw_materialsId.IsNullOrEmpty())
                {
                    query.Where(p => p.Raw_materialsId == model.Raw_materialsId);
                }
                if (!model.ProducerId.IsNullOrEmpty())
                {
                    query.Where(p => p.ProducerId == model.ProducerId);
                }
                if (!model.buyerPrice.IsNullOrEmpty())
                {
                    query.Where(p => p.buyerPrice == model.buyerPrice);
                }
                if (!model.buyerCount.IsNullOrEmpty())
                {
                    query.Where(p => p.buyerCount == model.buyerCount);
                }
                if (!model.DeliverMoney.IsNullOrEmpty())
                {
                    query.Where(p => p.DeliverMoney == model.DeliverMoney);
                }
                if (!model.IsStatus.IsNullOrEmpty())
                {
                    query.Where(p => p.IsStatus == model.IsStatus);
                }
                if (!model.Color.IsNullOrEmpty())
                {
                    query.Where(p => p.Color == model.Color);
                }
                if (!model.DeliverCountext.IsNullOrEmpty())
                {
                    query.Where(p => p.DeliverCountext == model.DeliverCountext);
                }
                if (!model.DeliverSinglePerson.IsNullOrEmpty())
                {
                    query.Where(p => p.DeliverSinglePerson == model.DeliverSinglePerson);
                }
                if (!model.DeliverSingleTime.IsNullOrEmpty())
                {
                    query.Where(p => p.DeliverSingleTime == model.DeliverSingleTime);
                }
                if (!model.AlreadyQuantity.IsNullOrEmpty())
                {
                    query.Where(p => p.AlreadyQuantity == model.AlreadyQuantity);
                }
            }
            if (SelectFiled != null)
            {
                SelectFiled = SelectFiled.ToLowerInvariant();
                if (SelectFiled.Contains("id,"))
                {
                    query.Select(p => new { p.Id });
                }
                if (SelectFiled.Contains("buyerid,"))
                {
                    query.Select(p => new { p.buyerId });
                }
                if (SelectFiled.Contains("raw_materialsid,"))
                {
                    query.Select(p => new { p.Raw_materialsId });
                }
                if (SelectFiled.Contains("producerid,"))
                {
                    query.Select(p => new { p.ProducerId });
                }
                if (SelectFiled.Contains("buyerprice,"))
                {
                    query.Select(p => new { p.buyerPrice });
                }
                if (SelectFiled.Contains("buyercount,"))
                {
                    query.Select(p => new { p.buyerCount });
                }
                if (SelectFiled.Contains("delivermoney,"))
                {
                    query.Select(p => new { p.DeliverMoney });
                }
                if (SelectFiled.Contains("isstatus,"))
                {
                    query.Select(p => new { p.IsStatus });
                }
                if (SelectFiled.Contains("color,"))
                {
                    query.Select(p => new { p.Color });
                }
                if (SelectFiled.Contains("delivercountext,"))
                {
                    query.Select(p => new { p.DeliverCountext });
                }
                if (SelectFiled.Contains("deliversingleperson,"))
                {
                    query.Select(p => new { p.DeliverSinglePerson });
                }
                if (SelectFiled.Contains("deliversingletime,"))
                {
                    query.Select(p => new { p.DeliverSingleTime });
                }
                if (SelectFiled.Contains("alreadyquantity,"))
                {
                    query.Select(p => new { p.AlreadyQuantity });
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
