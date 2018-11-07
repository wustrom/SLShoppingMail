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
    public partial class Order_DetailOper : SingleTon<Order_DetailOper>
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
            var delete = new LambdaDelete<Order_Detail>();
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
        public bool DeleteModel(Order_Detail model = null, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var delete = new LambdaDelete<Order_Detail>();
            if (model != null)
            {
                if (!model.Id.IsNullOrEmpty())
                {
                    delete.Where(p => p.Id == model.Id);
                }
                if (!model.OrderId.IsNullOrEmpty())
                {
                    delete.Where(p => p.OrderId == model.OrderId);
                }
                if (!model.CommodityId.IsNullOrEmpty())
                {
                    delete.Where(p => p.CommodityId == model.CommodityId);
                }
                if (!model.Color.IsNullOrEmpty())
                {
                    delete.Where(p => p.Color == model.Color);
                }
                if (!model.Amount.IsNullOrEmpty())
                {
                    delete.Where(p => p.Amount == model.Amount);
                }
                if (!model.PayMoney.IsNullOrEmpty())
                {
                    delete.Where(p => p.PayMoney == model.PayMoney);
                }
                if (!model.ShopCartId.IsNullOrEmpty())
                {
                    delete.Where(p => p.ShopCartId == model.ShopCartId);
                }
                if (!model.ImageList.IsNullOrEmpty())
                {
                    delete.Where(p => p.ImageList == model.ImageList);
                }
                if (!model.WordOpertion.IsNullOrEmpty())
                {
                    delete.Where(p => p.WordOpertion == model.WordOpertion);
                }
                if (!model.CustomImageOpertion.IsNullOrEmpty())
                {
                    delete.Where(p => p.CustomImageOpertion == model.CustomImageOpertion);
                }
                if (!model.OnLineImageOpertion.IsNullOrEmpty())
                {
                    delete.Where(p => p.OnLineImageOpertion == model.OnLineImageOpertion);
                }
                if (!model.Opertion1.IsNullOrEmpty())
                {
                    delete.Where(p => p.Opertion1 == model.Opertion1);
                }
                if (!model.Opertion2.IsNullOrEmpty())
                {
                    delete.Where(p => p.Opertion2 == model.Opertion2);
                }
                if (!model.Opertion3.IsNullOrEmpty())
                {
                    delete.Where(p => p.Opertion3 == model.Opertion3);
                }
                if (!model.DesignerImage.IsNullOrEmpty())
                {
                    delete.Where(p => p.DesignerImage == model.DesignerImage);
                }
                if (!model.UserSure.IsNullOrEmpty())
                {
                    delete.Where(p => p.UserSure == model.UserSure);
                }
                if (!model.DesignCommit.IsNullOrEmpty())
                {
                    delete.Where(p => p.DesignCommit == model.DesignCommit);
                }
                if (!model.PrintingMethod.IsNullOrEmpty())
                {
                    delete.Where(p => p.PrintingMethod == model.PrintingMethod);
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
        public bool Update(Order_Detail model, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var update = new LambdaUpdate<Order_Detail>();
            if (!model.Id.IsNullOrEmpty())
            {
                update.Where(p => p.Id == model.Id);
            }
            if (!model.OrderId.IsNullOrEmpty())
            {
                update.Set(p => p.OrderId == model.OrderId);
            }
            if (!model.CommodityId.IsNullOrEmpty())
            {
                update.Set(p => p.CommodityId == model.CommodityId);
            }
            if (!model.Color.IsNullOrEmpty())
            {
                update.Set(p => p.Color == model.Color);
            }
            if (!model.Amount.IsNullOrEmpty())
            {
                update.Set(p => p.Amount == model.Amount);
            }
            if (!model.PayMoney.IsNullOrEmpty())
            {
                update.Set(p => p.PayMoney == model.PayMoney);
            }
            if (!model.ShopCartId.IsNullOrEmpty())
            {
                update.Set(p => p.ShopCartId == model.ShopCartId);
            }
            if (!model.ImageList.IsNullOrEmpty())
            {
                update.Set(p => p.ImageList == model.ImageList);
            }
            if (!model.WordOpertion.IsNullOrEmpty())
            {
                update.Set(p => p.WordOpertion == model.WordOpertion);
            }
            if (!model.CustomImageOpertion.IsNullOrEmpty())
            {
                update.Set(p => p.CustomImageOpertion == model.CustomImageOpertion);
            }
            if (!model.OnLineImageOpertion.IsNullOrEmpty())
            {
                update.Set(p => p.OnLineImageOpertion == model.OnLineImageOpertion);
            }
            if (!model.Opertion1.IsNullOrEmpty())
            {
                update.Set(p => p.Opertion1 == model.Opertion1);
            }
            if (!model.Opertion2.IsNullOrEmpty())
            {
                update.Set(p => p.Opertion2 == model.Opertion2);
            }
            if (!model.Opertion3.IsNullOrEmpty())
            {
                update.Set(p => p.Opertion3 == model.Opertion3);
            }
            if (!model.DesignerImage.IsNullOrEmpty())
            {
                update.Set(p => p.DesignerImage == model.DesignerImage);
            }
            if (!model.UserSure.IsNullOrEmpty())
            {
                update.Set(p => p.UserSure == model.UserSure);
            }
            if (!model.DesignCommit.IsNullOrEmpty())
            {
                update.Set(p => p.DesignCommit == model.DesignCommit);
            }
            if (!model.PrintingMethod.IsNullOrEmpty())
            {
                update.Set(p => p.PrintingMethod == model.PrintingMethod);
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
        public bool Insert(Order_Detail model, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var insert = new LambdaInsert<Order_Detail>();
            if (!model.OrderId.IsNullOrEmpty())
            {
                insert.Insert(p => p.OrderId == model.OrderId);
            }
            if (!model.CommodityId.IsNullOrEmpty())
            {
                insert.Insert(p => p.CommodityId == model.CommodityId);
            }
            if (!model.Color.IsNullOrEmpty())
            {
                insert.Insert(p => p.Color == model.Color);
            }
            if (!model.Amount.IsNullOrEmpty())
            {
                insert.Insert(p => p.Amount == model.Amount);
            }
            if (!model.PayMoney.IsNullOrEmpty())
            {
                insert.Insert(p => p.PayMoney == model.PayMoney);
            }
            if (!model.ShopCartId.IsNullOrEmpty())
            {
                insert.Insert(p => p.ShopCartId == model.ShopCartId);
            }
            if (!model.ImageList.IsNullOrEmpty())
            {
                insert.Insert(p => p.ImageList == model.ImageList);
            }
            if (!model.WordOpertion.IsNullOrEmpty())
            {
                insert.Insert(p => p.WordOpertion == model.WordOpertion);
            }
            if (!model.CustomImageOpertion.IsNullOrEmpty())
            {
                insert.Insert(p => p.CustomImageOpertion == model.CustomImageOpertion);
            }
            if (!model.OnLineImageOpertion.IsNullOrEmpty())
            {
                insert.Insert(p => p.OnLineImageOpertion == model.OnLineImageOpertion);
            }
            if (!model.Opertion1.IsNullOrEmpty())
            {
                insert.Insert(p => p.Opertion1 == model.Opertion1);
            }
            if (!model.Opertion2.IsNullOrEmpty())
            {
                insert.Insert(p => p.Opertion2 == model.Opertion2);
            }
            if (!model.Opertion3.IsNullOrEmpty())
            {
                insert.Insert(p => p.Opertion3 == model.Opertion3);
            }
            if (!model.DesignerImage.IsNullOrEmpty())
            {
                insert.Insert(p => p.DesignerImage == model.DesignerImage);
            }
            if (!model.UserSure.IsNullOrEmpty())
            {
                insert.Insert(p => p.UserSure == model.UserSure);
            }
            if (!model.DesignCommit.IsNullOrEmpty())
            {
                insert.Insert(p => p.DesignCommit == model.DesignCommit);
            }
            if (!model.PrintingMethod.IsNullOrEmpty())
            {
                insert.Insert(p => p.PrintingMethod == model.PrintingMethod);
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
        public int InsertReturnKey(Order_Detail model, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var insert = new LambdaInsert<Order_Detail>();
            if (!model.OrderId.IsNullOrEmpty())
            {
                insert.Insert(p => p.OrderId == model.OrderId);
            }
            if (!model.CommodityId.IsNullOrEmpty())
            {
                insert.Insert(p => p.CommodityId == model.CommodityId);
            }
            if (!model.Color.IsNullOrEmpty())
            {
                insert.Insert(p => p.Color == model.Color);
            }
            if (!model.Amount.IsNullOrEmpty())
            {
                insert.Insert(p => p.Amount == model.Amount);
            }
            if (!model.PayMoney.IsNullOrEmpty())
            {
                insert.Insert(p => p.PayMoney == model.PayMoney);
            }
            if (!model.ShopCartId.IsNullOrEmpty())
            {
                insert.Insert(p => p.ShopCartId == model.ShopCartId);
            }
            if (!model.ImageList.IsNullOrEmpty())
            {
                insert.Insert(p => p.ImageList == model.ImageList);
            }
            if (!model.WordOpertion.IsNullOrEmpty())
            {
                insert.Insert(p => p.WordOpertion == model.WordOpertion);
            }
            if (!model.CustomImageOpertion.IsNullOrEmpty())
            {
                insert.Insert(p => p.CustomImageOpertion == model.CustomImageOpertion);
            }
            if (!model.OnLineImageOpertion.IsNullOrEmpty())
            {
                insert.Insert(p => p.OnLineImageOpertion == model.OnLineImageOpertion);
            }
            if (!model.Opertion1.IsNullOrEmpty())
            {
                insert.Insert(p => p.Opertion1 == model.Opertion1);
            }
            if (!model.Opertion2.IsNullOrEmpty())
            {
                insert.Insert(p => p.Opertion2 == model.Opertion2);
            }
            if (!model.Opertion3.IsNullOrEmpty())
            {
                insert.Insert(p => p.Opertion3 == model.Opertion3);
            }
            if (!model.DesignerImage.IsNullOrEmpty())
            {
                insert.Insert(p => p.DesignerImage == model.DesignerImage);
            }
            if (!model.UserSure.IsNullOrEmpty())
            {
                insert.Insert(p => p.UserSure == model.UserSure);
            }
            if (!model.DesignCommit.IsNullOrEmpty())
            {
                insert.Insert(p => p.DesignCommit == model.DesignCommit);
            }
            if (!model.PrintingMethod.IsNullOrEmpty())
            {
                insert.Insert(p => p.PrintingMethod == model.PrintingMethod);
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
        public List<Order_Detail> SelectAll(Order_Detail model = null, string SelectFiled = null, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var query = new LambdaQuery<Order_Detail>();
            if (model != null)
            {
                if (!model.Id.IsNullOrEmpty())
                {
                    query.Where(p => p.Id == model.Id);
                }
                if (!model.OrderId.IsNullOrEmpty())
                {
                    query.Where(p => p.OrderId == model.OrderId);
                }
                if (!model.CommodityId.IsNullOrEmpty())
                {
                    query.Where(p => p.CommodityId == model.CommodityId);
                }
                if (!model.Color.IsNullOrEmpty())
                {
                    query.Where(p => p.Color == model.Color);
                }
                if (!model.Amount.IsNullOrEmpty())
                {
                    query.Where(p => p.Amount == model.Amount);
                }
                if (!model.PayMoney.IsNullOrEmpty())
                {
                    query.Where(p => p.PayMoney == model.PayMoney);
                }
                if (!model.ShopCartId.IsNullOrEmpty())
                {
                    query.Where(p => p.ShopCartId == model.ShopCartId);
                }
                if (!model.ImageList.IsNullOrEmpty())
                {
                    query.Where(p => p.ImageList == model.ImageList);
                }
                if (!model.WordOpertion.IsNullOrEmpty())
                {
                    query.Where(p => p.WordOpertion == model.WordOpertion);
                }
                if (!model.CustomImageOpertion.IsNullOrEmpty())
                {
                    query.Where(p => p.CustomImageOpertion == model.CustomImageOpertion);
                }
                if (!model.OnLineImageOpertion.IsNullOrEmpty())
                {
                    query.Where(p => p.OnLineImageOpertion == model.OnLineImageOpertion);
                }
                if (!model.Opertion1.IsNullOrEmpty())
                {
                    query.Where(p => p.Opertion1 == model.Opertion1);
                }
                if (!model.Opertion2.IsNullOrEmpty())
                {
                    query.Where(p => p.Opertion2 == model.Opertion2);
                }
                if (!model.Opertion3.IsNullOrEmpty())
                {
                    query.Where(p => p.Opertion3 == model.Opertion3);
                }
                if (!model.DesignerImage.IsNullOrEmpty())
                {
                    query.Where(p => p.DesignerImage == model.DesignerImage);
                }
                if (!model.UserSure.IsNullOrEmpty())
                {
                    query.Where(p => p.UserSure == model.UserSure);
                }
                if (!model.DesignCommit.IsNullOrEmpty())
                {
                    query.Where(p => p.DesignCommit == model.DesignCommit);
                }
                if (!model.PrintingMethod.IsNullOrEmpty())
                {
                    query.Where(p => p.PrintingMethod == model.PrintingMethod);
                }
            }
            if (SelectFiled != null)
            {
                SelectFiled = SelectFiled.ToLowerInvariant();
                if (SelectFiled.Contains("id,"))
                {
                    query.Select(p => new { p.Id });
                }
                if (SelectFiled.Contains("orderid,"))
                {
                    query.Select(p => new { p.OrderId });
                }
                if (SelectFiled.Contains("commodityid,"))
                {
                    query.Select(p => new { p.CommodityId });
                }
                if (SelectFiled.Contains("color,"))
                {
                    query.Select(p => new { p.Color });
                }
                if (SelectFiled.Contains("amount,"))
                {
                    query.Select(p => new { p.Amount });
                }
                if (SelectFiled.Contains("paymoney,"))
                {
                    query.Select(p => new { p.PayMoney });
                }
                if (SelectFiled.Contains("shopcartid,"))
                {
                    query.Select(p => new { p.ShopCartId });
                }
                if (SelectFiled.Contains("imagelist,"))
                {
                    query.Select(p => new { p.ImageList });
                }
                if (SelectFiled.Contains("wordopertion,"))
                {
                    query.Select(p => new { p.WordOpertion });
                }
                if (SelectFiled.Contains("customimageopertion,"))
                {
                    query.Select(p => new { p.CustomImageOpertion });
                }
                if (SelectFiled.Contains("onlineimageopertion,"))
                {
                    query.Select(p => new { p.OnLineImageOpertion });
                }
                if (SelectFiled.Contains("opertion1,"))
                {
                    query.Select(p => new { p.Opertion1 });
                }
                if (SelectFiled.Contains("opertion2,"))
                {
                    query.Select(p => new { p.Opertion2 });
                }
                if (SelectFiled.Contains("opertion3,"))
                {
                    query.Select(p => new { p.Opertion3 });
                }
                if (SelectFiled.Contains("designerimage,"))
                {
                    query.Select(p => new { p.DesignerImage });
                }
                if (SelectFiled.Contains("usersure,"))
                {
                    query.Select(p => new { p.UserSure });
                }
                if (SelectFiled.Contains("designcommit,"))
                {
                    query.Select(p => new { p.DesignCommit });
                }
                if (SelectFiled.Contains("printingmethod,"))
                {
                    query.Select(p => new { p.PrintingMethod });
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
        public int SelectCount(Order_Detail model = null, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var query = new LambdaQuery<Order_Detail>();
            if (model != null)
            {
                if (!model.Id.IsNullOrEmpty())
                {
                    query.Where(p => p.Id == model.Id);
                }
                if (!model.OrderId.IsNullOrEmpty())
                {
                    query.Where(p => p.OrderId == model.OrderId);
                }
                if (!model.CommodityId.IsNullOrEmpty())
                {
                    query.Where(p => p.CommodityId == model.CommodityId);
                }
                if (!model.Color.IsNullOrEmpty())
                {
                    query.Where(p => p.Color == model.Color);
                }
                if (!model.Amount.IsNullOrEmpty())
                {
                    query.Where(p => p.Amount == model.Amount);
                }
                if (!model.PayMoney.IsNullOrEmpty())
                {
                    query.Where(p => p.PayMoney == model.PayMoney);
                }
                if (!model.ShopCartId.IsNullOrEmpty())
                {
                    query.Where(p => p.ShopCartId == model.ShopCartId);
                }
                if (!model.ImageList.IsNullOrEmpty())
                {
                    query.Where(p => p.ImageList == model.ImageList);
                }
                if (!model.WordOpertion.IsNullOrEmpty())
                {
                    query.Where(p => p.WordOpertion == model.WordOpertion);
                }
                if (!model.CustomImageOpertion.IsNullOrEmpty())
                {
                    query.Where(p => p.CustomImageOpertion == model.CustomImageOpertion);
                }
                if (!model.OnLineImageOpertion.IsNullOrEmpty())
                {
                    query.Where(p => p.OnLineImageOpertion == model.OnLineImageOpertion);
                }
                if (!model.Opertion1.IsNullOrEmpty())
                {
                    query.Where(p => p.Opertion1 == model.Opertion1);
                }
                if (!model.Opertion2.IsNullOrEmpty())
                {
                    query.Where(p => p.Opertion2 == model.Opertion2);
                }
                if (!model.Opertion3.IsNullOrEmpty())
                {
                    query.Where(p => p.Opertion3 == model.Opertion3);
                }
                if (!model.DesignerImage.IsNullOrEmpty())
                {
                    query.Where(p => p.DesignerImage == model.DesignerImage);
                }
                if (!model.UserSure.IsNullOrEmpty())
                {
                    query.Where(p => p.UserSure == model.UserSure);
                }
                if (!model.DesignCommit.IsNullOrEmpty())
                {
                    query.Where(p => p.DesignCommit == model.DesignCommit);
                }
                if (!model.PrintingMethod.IsNullOrEmpty())
                {
                    query.Where(p => p.PrintingMethod == model.PrintingMethod);
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
        public Order_Detail SelectById(int KeyId, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var query = new LambdaQuery<Order_Detail>();
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
        public List<Order_Detail> SelectByKeys(string Key,List<string> KeyIds, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var query = new LambdaQuery<Order_Detail>();
            if("id" == Key.ToLowerInvariant())
            {
                query.Where(p => p.Id.In(KeyIds));
            }
            if("orderid" == Key.ToLowerInvariant())
            {
                query.Where(p => p.OrderId.In(KeyIds));
            }
            if("commodityid" == Key.ToLowerInvariant())
            {
                query.Where(p => p.CommodityId.In(KeyIds));
            }
            if("color" == Key.ToLowerInvariant())
            {
                query.Where(p => p.Color.In(KeyIds));
            }
            if("amount" == Key.ToLowerInvariant())
            {
                query.Where(p => p.Amount.In(KeyIds));
            }
            if("paymoney" == Key.ToLowerInvariant())
            {
                query.Where(p => p.PayMoney.In(KeyIds));
            }
            if("shopcartid" == Key.ToLowerInvariant())
            {
                query.Where(p => p.ShopCartId.In(KeyIds));
            }
            if("imagelist" == Key.ToLowerInvariant())
            {
                query.Where(p => p.ImageList.In(KeyIds));
            }
            if("wordopertion" == Key.ToLowerInvariant())
            {
                query.Where(p => p.WordOpertion.In(KeyIds));
            }
            if("customimageopertion" == Key.ToLowerInvariant())
            {
                query.Where(p => p.CustomImageOpertion.In(KeyIds));
            }
            if("onlineimageopertion" == Key.ToLowerInvariant())
            {
                query.Where(p => p.OnLineImageOpertion.In(KeyIds));
            }
            if("opertion1" == Key.ToLowerInvariant())
            {
                query.Where(p => p.Opertion1.In(KeyIds));
            }
            if("opertion2" == Key.ToLowerInvariant())
            {
                query.Where(p => p.Opertion2.In(KeyIds));
            }
            if("opertion3" == Key.ToLowerInvariant())
            {
                query.Where(p => p.Opertion3.In(KeyIds));
            }
            if("designerimage" == Key.ToLowerInvariant())
            {
                query.Where(p => p.DesignerImage.In(KeyIds));
            }
            if("usersure" == Key.ToLowerInvariant())
            {
                query.Where(p => p.UserSure.In(KeyIds));
            }
            if("designcommit" == Key.ToLowerInvariant())
            {
                query.Where(p => p.DesignCommit.In(KeyIds));
            }
            if("printingmethod" == Key.ToLowerInvariant())
            {
                query.Where(p => p.PrintingMethod.In(KeyIds));
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
        public List<Order_Detail> SelectByPage(string Key, int start, int PageSize, bool desc = true,Order_Detail model = null, string SelectFiled = null, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var query = new LambdaQuery<Order_Detail>();
            if (model != null)
            {
                if (!model.Id.IsNullOrEmpty())
                {
                    query.Where(p => p.Id == model.Id);
                }
                if (!model.OrderId.IsNullOrEmpty())
                {
                    query.Where(p => p.OrderId == model.OrderId);
                }
                if (!model.CommodityId.IsNullOrEmpty())
                {
                    query.Where(p => p.CommodityId == model.CommodityId);
                }
                if (!model.Color.IsNullOrEmpty())
                {
                    query.Where(p => p.Color == model.Color);
                }
                if (!model.Amount.IsNullOrEmpty())
                {
                    query.Where(p => p.Amount == model.Amount);
                }
                if (!model.PayMoney.IsNullOrEmpty())
                {
                    query.Where(p => p.PayMoney == model.PayMoney);
                }
                if (!model.ShopCartId.IsNullOrEmpty())
                {
                    query.Where(p => p.ShopCartId == model.ShopCartId);
                }
                if (!model.ImageList.IsNullOrEmpty())
                {
                    query.Where(p => p.ImageList == model.ImageList);
                }
                if (!model.WordOpertion.IsNullOrEmpty())
                {
                    query.Where(p => p.WordOpertion == model.WordOpertion);
                }
                if (!model.CustomImageOpertion.IsNullOrEmpty())
                {
                    query.Where(p => p.CustomImageOpertion == model.CustomImageOpertion);
                }
                if (!model.OnLineImageOpertion.IsNullOrEmpty())
                {
                    query.Where(p => p.OnLineImageOpertion == model.OnLineImageOpertion);
                }
                if (!model.Opertion1.IsNullOrEmpty())
                {
                    query.Where(p => p.Opertion1 == model.Opertion1);
                }
                if (!model.Opertion2.IsNullOrEmpty())
                {
                    query.Where(p => p.Opertion2 == model.Opertion2);
                }
                if (!model.Opertion3.IsNullOrEmpty())
                {
                    query.Where(p => p.Opertion3 == model.Opertion3);
                }
                if (!model.DesignerImage.IsNullOrEmpty())
                {
                    query.Where(p => p.DesignerImage == model.DesignerImage);
                }
                if (!model.UserSure.IsNullOrEmpty())
                {
                    query.Where(p => p.UserSure == model.UserSure);
                }
                if (!model.DesignCommit.IsNullOrEmpty())
                {
                    query.Where(p => p.DesignCommit == model.DesignCommit);
                }
                if (!model.PrintingMethod.IsNullOrEmpty())
                {
                    query.Where(p => p.PrintingMethod == model.PrintingMethod);
                }
            }
            if (SelectFiled != null)
            {
                SelectFiled = SelectFiled.ToLowerInvariant();
                if (SelectFiled.Contains("id,"))
                {
                    query.Select(p => new { p.Id });
                }
                if (SelectFiled.Contains("orderid,"))
                {
                    query.Select(p => new { p.OrderId });
                }
                if (SelectFiled.Contains("commodityid,"))
                {
                    query.Select(p => new { p.CommodityId });
                }
                if (SelectFiled.Contains("color,"))
                {
                    query.Select(p => new { p.Color });
                }
                if (SelectFiled.Contains("amount,"))
                {
                    query.Select(p => new { p.Amount });
                }
                if (SelectFiled.Contains("paymoney,"))
                {
                    query.Select(p => new { p.PayMoney });
                }
                if (SelectFiled.Contains("shopcartid,"))
                {
                    query.Select(p => new { p.ShopCartId });
                }
                if (SelectFiled.Contains("imagelist,"))
                {
                    query.Select(p => new { p.ImageList });
                }
                if (SelectFiled.Contains("wordopertion,"))
                {
                    query.Select(p => new { p.WordOpertion });
                }
                if (SelectFiled.Contains("customimageopertion,"))
                {
                    query.Select(p => new { p.CustomImageOpertion });
                }
                if (SelectFiled.Contains("onlineimageopertion,"))
                {
                    query.Select(p => new { p.OnLineImageOpertion });
                }
                if (SelectFiled.Contains("opertion1,"))
                {
                    query.Select(p => new { p.Opertion1 });
                }
                if (SelectFiled.Contains("opertion2,"))
                {
                    query.Select(p => new { p.Opertion2 });
                }
                if (SelectFiled.Contains("opertion3,"))
                {
                    query.Select(p => new { p.Opertion3 });
                }
                if (SelectFiled.Contains("designerimage,"))
                {
                    query.Select(p => new { p.DesignerImage });
                }
                if (SelectFiled.Contains("usersure,"))
                {
                    query.Select(p => new { p.UserSure });
                }
                if (SelectFiled.Contains("designcommit,"))
                {
                    query.Select(p => new { p.DesignCommit });
                }
                if (SelectFiled.Contains("printingmethod,"))
                {
                    query.Select(p => new { p.PrintingMethod });
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
