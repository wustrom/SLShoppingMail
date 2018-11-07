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
    public partial class ShopcartOper : SingleTon<ShopcartOper>
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
            var delete = new LambdaDelete<Shopcart>();
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
        public bool DeleteModel(Shopcart model = null, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var delete = new LambdaDelete<Shopcart>();
            if (model != null)
            {
                if (!model.Id.IsNullOrEmpty())
                {
                    delete.Where(p => p.Id == model.Id);
                }
                if (!model.UserID.IsNullOrEmpty())
                {
                    delete.Where(p => p.UserID == model.UserID);
                }
                if (!model.UserGuId.IsNullOrEmpty())
                {
                    delete.Where(p => p.UserGuId == model.UserGuId);
                }
                if (!model.CommodityId.IsNullOrEmpty())
                {
                    delete.Where(p => p.CommodityId == model.CommodityId);
                }
                if (!model.BackContent.IsNullOrEmpty())
                {
                    delete.Where(p => p.BackContent == model.BackContent);
                }
                if (!model.ForntContent.IsNullOrEmpty())
                {
                    delete.Where(p => p.ForntContent == model.ForntContent);
                }
                if (!model.BackView.IsNullOrEmpty())
                {
                    delete.Where(p => p.BackView == model.BackView);
                }
                if (!model.ForntView.IsNullOrEmpty())
                {
                    delete.Where(p => p.ForntView == model.ForntView);
                }
                if (!model.LastLookTime.IsNullOrEmpty())
                {
                    delete.Where(p => p.LastLookTime == model.LastLookTime);
                }
                if (!model.Color.IsNullOrEmpty())
                {
                    delete.Where(p => p.Color == model.Color);
                }
                if (!model.PrintingMethod.IsNullOrEmpty())
                {
                    delete.Where(p => p.PrintingMethod == model.PrintingMethod);
                }
                if (!model.Attr.IsNullOrEmpty())
                {
                    delete.Where(p => p.Attr == model.Attr);
                }
                if (!model.Amount.IsNullOrEmpty())
                {
                    delete.Where(p => p.Amount == model.Amount);
                }
                if (!model.OrderId.IsNullOrEmpty())
                {
                    delete.Where(p => p.OrderId == model.OrderId);
                }
                if (!model.IsMobile.IsNullOrEmpty())
                {
                    delete.Where(p => p.IsMobile == model.IsMobile);
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
        public bool Update(Shopcart model, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var update = new LambdaUpdate<Shopcart>();
            if (!model.Id.IsNullOrEmpty())
            {
                update.Where(p => p.Id == model.Id);
            }
            if (!model.UserID.IsNullOrEmpty())
            {
                update.Set(p => p.UserID == model.UserID);
            }
            if (!model.UserGuId.IsNullOrEmpty())
            {
                update.Set(p => p.UserGuId == model.UserGuId);
            }
            if (!model.CommodityId.IsNullOrEmpty())
            {
                update.Set(p => p.CommodityId == model.CommodityId);
            }
            if (!model.BackContent.IsNullOrEmpty())
            {
                update.Set(p => p.BackContent == model.BackContent);
            }
            if (!model.ForntContent.IsNullOrEmpty())
            {
                update.Set(p => p.ForntContent == model.ForntContent);
            }
            if (!model.BackView.IsNullOrEmpty())
            {
                update.Set(p => p.BackView == model.BackView);
            }
            if (!model.ForntView.IsNullOrEmpty())
            {
                update.Set(p => p.ForntView == model.ForntView);
            }
            if (!model.LastLookTime.IsNullOrEmpty())
            {
                update.Set(p => p.LastLookTime == model.LastLookTime);
            }
            if (!model.Color.IsNullOrEmpty())
            {
                update.Set(p => p.Color == model.Color);
            }
            if (!model.PrintingMethod.IsNullOrEmpty())
            {
                update.Set(p => p.PrintingMethod == model.PrintingMethod);
            }
            if (!model.Attr.IsNullOrEmpty())
            {
                update.Set(p => p.Attr == model.Attr);
            }
            if (!model.Amount.IsNullOrEmpty())
            {
                update.Set(p => p.Amount == model.Amount);
            }
            if (!model.OrderId.IsNullOrEmpty())
            {
                update.Set(p => p.OrderId == model.OrderId);
            }
            if (!model.IsMobile.IsNullOrEmpty())
            {
                update.Set(p => p.IsMobile == model.IsMobile);
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
        public bool Insert(Shopcart model, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var insert = new LambdaInsert<Shopcart>();
            if (!model.UserID.IsNullOrEmpty())
            {
                insert.Insert(p => p.UserID == model.UserID);
            }
            if (!model.UserGuId.IsNullOrEmpty())
            {
                insert.Insert(p => p.UserGuId == model.UserGuId);
            }
            if (!model.CommodityId.IsNullOrEmpty())
            {
                insert.Insert(p => p.CommodityId == model.CommodityId);
            }
            if (!model.BackContent.IsNullOrEmpty())
            {
                insert.Insert(p => p.BackContent == model.BackContent);
            }
            if (!model.ForntContent.IsNullOrEmpty())
            {
                insert.Insert(p => p.ForntContent == model.ForntContent);
            }
            if (!model.BackView.IsNullOrEmpty())
            {
                insert.Insert(p => p.BackView == model.BackView);
            }
            if (!model.ForntView.IsNullOrEmpty())
            {
                insert.Insert(p => p.ForntView == model.ForntView);
            }
            if (!model.LastLookTime.IsNullOrEmpty())
            {
                insert.Insert(p => p.LastLookTime == model.LastLookTime);
            }
            if (!model.Color.IsNullOrEmpty())
            {
                insert.Insert(p => p.Color == model.Color);
            }
            if (!model.PrintingMethod.IsNullOrEmpty())
            {
                insert.Insert(p => p.PrintingMethod == model.PrintingMethod);
            }
            if (!model.Attr.IsNullOrEmpty())
            {
                insert.Insert(p => p.Attr == model.Attr);
            }
            if (!model.Amount.IsNullOrEmpty())
            {
                insert.Insert(p => p.Amount == model.Amount);
            }
            if (!model.OrderId.IsNullOrEmpty())
            {
                insert.Insert(p => p.OrderId == model.OrderId);
            }
            if (!model.IsMobile.IsNullOrEmpty())
            {
                insert.Insert(p => p.IsMobile == model.IsMobile);
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
        public int InsertReturnKey(Shopcart model, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var insert = new LambdaInsert<Shopcart>();
            if (!model.UserID.IsNullOrEmpty())
            {
                insert.Insert(p => p.UserID == model.UserID);
            }
            if (!model.UserGuId.IsNullOrEmpty())
            {
                insert.Insert(p => p.UserGuId == model.UserGuId);
            }
            if (!model.CommodityId.IsNullOrEmpty())
            {
                insert.Insert(p => p.CommodityId == model.CommodityId);
            }
            if (!model.BackContent.IsNullOrEmpty())
            {
                insert.Insert(p => p.BackContent == model.BackContent);
            }
            if (!model.ForntContent.IsNullOrEmpty())
            {
                insert.Insert(p => p.ForntContent == model.ForntContent);
            }
            if (!model.BackView.IsNullOrEmpty())
            {
                insert.Insert(p => p.BackView == model.BackView);
            }
            if (!model.ForntView.IsNullOrEmpty())
            {
                insert.Insert(p => p.ForntView == model.ForntView);
            }
            if (!model.LastLookTime.IsNullOrEmpty())
            {
                insert.Insert(p => p.LastLookTime == model.LastLookTime);
            }
            if (!model.Color.IsNullOrEmpty())
            {
                insert.Insert(p => p.Color == model.Color);
            }
            if (!model.PrintingMethod.IsNullOrEmpty())
            {
                insert.Insert(p => p.PrintingMethod == model.PrintingMethod);
            }
            if (!model.Attr.IsNullOrEmpty())
            {
                insert.Insert(p => p.Attr == model.Attr);
            }
            if (!model.Amount.IsNullOrEmpty())
            {
                insert.Insert(p => p.Amount == model.Amount);
            }
            if (!model.OrderId.IsNullOrEmpty())
            {
                insert.Insert(p => p.OrderId == model.OrderId);
            }
            if (!model.IsMobile.IsNullOrEmpty())
            {
                insert.Insert(p => p.IsMobile == model.IsMobile);
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
        public List<Shopcart> SelectAll(Shopcart model = null, string SelectFiled = null, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var query = new LambdaQuery<Shopcart>();
            if (model != null)
            {
                if (!model.Id.IsNullOrEmpty())
                {
                    query.Where(p => p.Id == model.Id);
                }
                if (!model.UserID.IsNullOrEmpty())
                {
                    query.Where(p => p.UserID == model.UserID);
                }
                if (!model.UserGuId.IsNullOrEmpty())
                {
                    query.Where(p => p.UserGuId == model.UserGuId);
                }
                if (!model.CommodityId.IsNullOrEmpty())
                {
                    query.Where(p => p.CommodityId == model.CommodityId);
                }
                if (!model.BackContent.IsNullOrEmpty())
                {
                    query.Where(p => p.BackContent == model.BackContent);
                }
                if (!model.ForntContent.IsNullOrEmpty())
                {
                    query.Where(p => p.ForntContent == model.ForntContent);
                }
                if (!model.BackView.IsNullOrEmpty())
                {
                    query.Where(p => p.BackView == model.BackView);
                }
                if (!model.ForntView.IsNullOrEmpty())
                {
                    query.Where(p => p.ForntView == model.ForntView);
                }
                if (!model.LastLookTime.IsNullOrEmpty())
                {
                    query.Where(p => p.LastLookTime == model.LastLookTime);
                }
                if (!model.Color.IsNullOrEmpty())
                {
                    query.Where(p => p.Color == model.Color);
                }
                if (!model.PrintingMethod.IsNullOrEmpty())
                {
                    query.Where(p => p.PrintingMethod == model.PrintingMethod);
                }
                if (!model.Attr.IsNullOrEmpty())
                {
                    query.Where(p => p.Attr == model.Attr);
                }
                if (!model.Amount.IsNullOrEmpty())
                {
                    query.Where(p => p.Amount == model.Amount);
                }
                if (!model.OrderId.IsNullOrEmpty())
                {
                    query.Where(p => p.OrderId == model.OrderId);
                }
                if (!model.IsMobile.IsNullOrEmpty())
                {
                    query.Where(p => p.IsMobile == model.IsMobile);
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
                    query.Select(p => new { p.UserID });
                }
                if (SelectFiled.Contains("userguid,"))
                {
                    query.Select(p => new { p.UserGuId });
                }
                if (SelectFiled.Contains("commodityid,"))
                {
                    query.Select(p => new { p.CommodityId });
                }
                if (SelectFiled.Contains("backcontent,"))
                {
                    query.Select(p => new { p.BackContent });
                }
                if (SelectFiled.Contains("forntcontent,"))
                {
                    query.Select(p => new { p.ForntContent });
                }
                if (SelectFiled.Contains("backview,"))
                {
                    query.Select(p => new { p.BackView });
                }
                if (SelectFiled.Contains("forntview,"))
                {
                    query.Select(p => new { p.ForntView });
                }
                if (SelectFiled.Contains("lastlooktime,"))
                {
                    query.Select(p => new { p.LastLookTime });
                }
                if (SelectFiled.Contains("color,"))
                {
                    query.Select(p => new { p.Color });
                }
                if (SelectFiled.Contains("printingmethod,"))
                {
                    query.Select(p => new { p.PrintingMethod });
                }
                if (SelectFiled.Contains("attr,"))
                {
                    query.Select(p => new { p.Attr });
                }
                if (SelectFiled.Contains("amount,"))
                {
                    query.Select(p => new { p.Amount });
                }
                if (SelectFiled.Contains("orderid,"))
                {
                    query.Select(p => new { p.OrderId });
                }
                if (SelectFiled.Contains("ismobile,"))
                {
                    query.Select(p => new { p.IsMobile });
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
        public int SelectCount(Shopcart model = null, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var query = new LambdaQuery<Shopcart>();
            if (model != null)
            {
                if (!model.Id.IsNullOrEmpty())
                {
                    query.Where(p => p.Id == model.Id);
                }
                if (!model.UserID.IsNullOrEmpty())
                {
                    query.Where(p => p.UserID == model.UserID);
                }
                if (!model.UserGuId.IsNullOrEmpty())
                {
                    query.Where(p => p.UserGuId == model.UserGuId);
                }
                if (!model.CommodityId.IsNullOrEmpty())
                {
                    query.Where(p => p.CommodityId == model.CommodityId);
                }
                if (!model.BackContent.IsNullOrEmpty())
                {
                    query.Where(p => p.BackContent == model.BackContent);
                }
                if (!model.ForntContent.IsNullOrEmpty())
                {
                    query.Where(p => p.ForntContent == model.ForntContent);
                }
                if (!model.BackView.IsNullOrEmpty())
                {
                    query.Where(p => p.BackView == model.BackView);
                }
                if (!model.ForntView.IsNullOrEmpty())
                {
                    query.Where(p => p.ForntView == model.ForntView);
                }
                if (!model.LastLookTime.IsNullOrEmpty())
                {
                    query.Where(p => p.LastLookTime == model.LastLookTime);
                }
                if (!model.Color.IsNullOrEmpty())
                {
                    query.Where(p => p.Color == model.Color);
                }
                if (!model.PrintingMethod.IsNullOrEmpty())
                {
                    query.Where(p => p.PrintingMethod == model.PrintingMethod);
                }
                if (!model.Attr.IsNullOrEmpty())
                {
                    query.Where(p => p.Attr == model.Attr);
                }
                if (!model.Amount.IsNullOrEmpty())
                {
                    query.Where(p => p.Amount == model.Amount);
                }
                if (!model.OrderId.IsNullOrEmpty())
                {
                    query.Where(p => p.OrderId == model.OrderId);
                }
                if (!model.IsMobile.IsNullOrEmpty())
                {
                    query.Where(p => p.IsMobile == model.IsMobile);
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
        public Shopcart SelectById(int KeyId, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var query = new LambdaQuery<Shopcart>();
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
        public List<Shopcart> SelectByKeys(string Key,List<string> KeyIds, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var query = new LambdaQuery<Shopcart>();
            if("id" == Key.ToLowerInvariant())
            {
                query.Where(p => p.Id.In(KeyIds));
            }
            if("userid" == Key.ToLowerInvariant())
            {
                query.Where(p => p.UserID.In(KeyIds));
            }
            if("userguid" == Key.ToLowerInvariant())
            {
                query.Where(p => p.UserGuId.In(KeyIds));
            }
            if("commodityid" == Key.ToLowerInvariant())
            {
                query.Where(p => p.CommodityId.In(KeyIds));
            }
            if("backcontent" == Key.ToLowerInvariant())
            {
                query.Where(p => p.BackContent.In(KeyIds));
            }
            if("forntcontent" == Key.ToLowerInvariant())
            {
                query.Where(p => p.ForntContent.In(KeyIds));
            }
            if("backview" == Key.ToLowerInvariant())
            {
                query.Where(p => p.BackView.In(KeyIds));
            }
            if("forntview" == Key.ToLowerInvariant())
            {
                query.Where(p => p.ForntView.In(KeyIds));
            }
            if("lastlooktime" == Key.ToLowerInvariant())
            {
                query.Where(p => p.LastLookTime.In(KeyIds));
            }
            if("color" == Key.ToLowerInvariant())
            {
                query.Where(p => p.Color.In(KeyIds));
            }
            if("printingmethod" == Key.ToLowerInvariant())
            {
                query.Where(p => p.PrintingMethod.In(KeyIds));
            }
            if("attr" == Key.ToLowerInvariant())
            {
                query.Where(p => p.Attr.In(KeyIds));
            }
            if("amount" == Key.ToLowerInvariant())
            {
                query.Where(p => p.Amount.In(KeyIds));
            }
            if("orderid" == Key.ToLowerInvariant())
            {
                query.Where(p => p.OrderId.In(KeyIds));
            }
            if("ismobile" == Key.ToLowerInvariant())
            {
                query.Where(p => p.IsMobile.In(KeyIds));
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
        public List<Shopcart> SelectByPage(string Key, int start, int PageSize, bool desc = true,Shopcart model = null, string SelectFiled = null, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var query = new LambdaQuery<Shopcart>();
            if (model != null)
            {
                if (!model.Id.IsNullOrEmpty())
                {
                    query.Where(p => p.Id == model.Id);
                }
                if (!model.UserID.IsNullOrEmpty())
                {
                    query.Where(p => p.UserID == model.UserID);
                }
                if (!model.UserGuId.IsNullOrEmpty())
                {
                    query.Where(p => p.UserGuId == model.UserGuId);
                }
                if (!model.CommodityId.IsNullOrEmpty())
                {
                    query.Where(p => p.CommodityId == model.CommodityId);
                }
                if (!model.BackContent.IsNullOrEmpty())
                {
                    query.Where(p => p.BackContent == model.BackContent);
                }
                if (!model.ForntContent.IsNullOrEmpty())
                {
                    query.Where(p => p.ForntContent == model.ForntContent);
                }
                if (!model.BackView.IsNullOrEmpty())
                {
                    query.Where(p => p.BackView == model.BackView);
                }
                if (!model.ForntView.IsNullOrEmpty())
                {
                    query.Where(p => p.ForntView == model.ForntView);
                }
                if (!model.LastLookTime.IsNullOrEmpty())
                {
                    query.Where(p => p.LastLookTime == model.LastLookTime);
                }
                if (!model.Color.IsNullOrEmpty())
                {
                    query.Where(p => p.Color == model.Color);
                }
                if (!model.PrintingMethod.IsNullOrEmpty())
                {
                    query.Where(p => p.PrintingMethod == model.PrintingMethod);
                }
                if (!model.Attr.IsNullOrEmpty())
                {
                    query.Where(p => p.Attr == model.Attr);
                }
                if (!model.Amount.IsNullOrEmpty())
                {
                    query.Where(p => p.Amount == model.Amount);
                }
                if (!model.OrderId.IsNullOrEmpty())
                {
                    query.Where(p => p.OrderId == model.OrderId);
                }
                if (!model.IsMobile.IsNullOrEmpty())
                {
                    query.Where(p => p.IsMobile == model.IsMobile);
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
                    query.Select(p => new { p.UserID });
                }
                if (SelectFiled.Contains("userguid,"))
                {
                    query.Select(p => new { p.UserGuId });
                }
                if (SelectFiled.Contains("commodityid,"))
                {
                    query.Select(p => new { p.CommodityId });
                }
                if (SelectFiled.Contains("backcontent,"))
                {
                    query.Select(p => new { p.BackContent });
                }
                if (SelectFiled.Contains("forntcontent,"))
                {
                    query.Select(p => new { p.ForntContent });
                }
                if (SelectFiled.Contains("backview,"))
                {
                    query.Select(p => new { p.BackView });
                }
                if (SelectFiled.Contains("forntview,"))
                {
                    query.Select(p => new { p.ForntView });
                }
                if (SelectFiled.Contains("lastlooktime,"))
                {
                    query.Select(p => new { p.LastLookTime });
                }
                if (SelectFiled.Contains("color,"))
                {
                    query.Select(p => new { p.Color });
                }
                if (SelectFiled.Contains("printingmethod,"))
                {
                    query.Select(p => new { p.PrintingMethod });
                }
                if (SelectFiled.Contains("attr,"))
                {
                    query.Select(p => new { p.Attr });
                }
                if (SelectFiled.Contains("amount,"))
                {
                    query.Select(p => new { p.Amount });
                }
                if (SelectFiled.Contains("orderid,"))
                {
                    query.Select(p => new { p.OrderId });
                }
                if (SelectFiled.Contains("ismobile,"))
                {
                    query.Select(p => new { p.IsMobile });
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
