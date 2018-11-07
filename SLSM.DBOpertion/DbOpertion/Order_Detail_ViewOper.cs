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
    public partial class Order_Detail_ViewOper : SingleTon<Order_Detail_ViewOper>
    {
        /// <summary>
        /// 筛选全部数据
        /// </summary>
        /// <param name="model">模型</param>
        /// <param name="connection">连接</param>
        /// <param name="transaction">事务</param>
        /// <returns>对象列表</returns>
        public List<Order_Detail_View> SelectAll(Order_Detail_View model = null, string SelectFiled = null, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var query = new LambdaQuery<Order_Detail_View>();
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
                if (!model.Name.IsNullOrEmpty())
                {
                    query.Where(p => p.Name == model.Name);
                }
                if (!model.Image.IsNullOrEmpty())
                {
                    query.Where(p => p.Image == model.Image);
                }
                if (!model.Introduce.IsNullOrEmpty())
                {
                    query.Where(p => p.Introduce == model.Introduce);
                }
                if (!model.BackView.IsNullOrEmpty())
                {
                    query.Where(p => p.BackView == model.BackView);
                }
                if (!model.FrontView.IsNullOrEmpty())
                {
                    query.Where(p => p.FrontView == model.FrontView);
                }
                if (!model.comImageList.IsNullOrEmpty())
                {
                    query.Where(p => p.comImageList == model.comImageList);
                }
                if (!model.ProductNo.IsNullOrEmpty())
                {
                    query.Where(p => p.ProductNo == model.ProductNo);
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
                if (SelectFiled.Contains("name,"))
                {
                    query.Select(p => new { p.Name });
                }
                if (SelectFiled.Contains("image,"))
                {
                    query.Select(p => new { p.Image });
                }
                if (SelectFiled.Contains("introduce,"))
                {
                    query.Select(p => new { p.Introduce });
                }
                if (SelectFiled.Contains("backview,"))
                {
                    query.Select(p => new { p.BackView });
                }
                if (SelectFiled.Contains("frontview,"))
                {
                    query.Select(p => new { p.FrontView });
                }
                if (SelectFiled.Contains("comimagelist,"))
                {
                    query.Select(p => new { p.comImageList });
                }
                if (SelectFiled.Contains("productno,"))
                {
                    query.Select(p => new { p.ProductNo });
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
        public int SelectCount(Order_Detail_View model = null, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var query = new LambdaQuery<Order_Detail_View>();
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
                if (!model.Name.IsNullOrEmpty())
                {
                    query.Where(p => p.Name == model.Name);
                }
                if (!model.Image.IsNullOrEmpty())
                {
                    query.Where(p => p.Image == model.Image);
                }
                if (!model.Introduce.IsNullOrEmpty())
                {
                    query.Where(p => p.Introduce == model.Introduce);
                }
                if (!model.BackView.IsNullOrEmpty())
                {
                    query.Where(p => p.BackView == model.BackView);
                }
                if (!model.FrontView.IsNullOrEmpty())
                {
                    query.Where(p => p.FrontView == model.FrontView);
                }
                if (!model.comImageList.IsNullOrEmpty())
                {
                    query.Where(p => p.comImageList == model.comImageList);
                }
                if (!model.ProductNo.IsNullOrEmpty())
                {
                    query.Where(p => p.ProductNo == model.ProductNo);
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
        public Order_Detail_View SelectById(int KeyId, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var query = new LambdaQuery<Order_Detail_View>();
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
        public List<Order_Detail_View> SelectByKeys(string Key,List<string> KeyIds, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var query = new LambdaQuery<Order_Detail_View>();
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
            if("name" == Key.ToLowerInvariant())
            {
                query.Where(p => p.Name.In(KeyIds));
            }
            if("image" == Key.ToLowerInvariant())
            {
                query.Where(p => p.Image.In(KeyIds));
            }
            if("introduce" == Key.ToLowerInvariant())
            {
                query.Where(p => p.Introduce.In(KeyIds));
            }
            if("backview" == Key.ToLowerInvariant())
            {
                query.Where(p => p.BackView.In(KeyIds));
            }
            if("frontview" == Key.ToLowerInvariant())
            {
                query.Where(p => p.FrontView.In(KeyIds));
            }
            if("comimagelist" == Key.ToLowerInvariant())
            {
                query.Where(p => p.comImageList.In(KeyIds));
            }
            if("productno" == Key.ToLowerInvariant())
            {
                query.Where(p => p.ProductNo.In(KeyIds));
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
        public List<Order_Detail_View> SelectByPage(string Key, int start, int PageSize, bool desc = true,Order_Detail_View model = null, string SelectFiled = null, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var query = new LambdaQuery<Order_Detail_View>();
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
                if (!model.Name.IsNullOrEmpty())
                {
                    query.Where(p => p.Name == model.Name);
                }
                if (!model.Image.IsNullOrEmpty())
                {
                    query.Where(p => p.Image == model.Image);
                }
                if (!model.Introduce.IsNullOrEmpty())
                {
                    query.Where(p => p.Introduce == model.Introduce);
                }
                if (!model.BackView.IsNullOrEmpty())
                {
                    query.Where(p => p.BackView == model.BackView);
                }
                if (!model.FrontView.IsNullOrEmpty())
                {
                    query.Where(p => p.FrontView == model.FrontView);
                }
                if (!model.comImageList.IsNullOrEmpty())
                {
                    query.Where(p => p.comImageList == model.comImageList);
                }
                if (!model.ProductNo.IsNullOrEmpty())
                {
                    query.Where(p => p.ProductNo == model.ProductNo);
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
                if (SelectFiled.Contains("name,"))
                {
                    query.Select(p => new { p.Name });
                }
                if (SelectFiled.Contains("image,"))
                {
                    query.Select(p => new { p.Image });
                }
                if (SelectFiled.Contains("introduce,"))
                {
                    query.Select(p => new { p.Introduce });
                }
                if (SelectFiled.Contains("backview,"))
                {
                    query.Select(p => new { p.BackView });
                }
                if (SelectFiled.Contains("frontview,"))
                {
                    query.Select(p => new { p.FrontView });
                }
                if (SelectFiled.Contains("comimagelist,"))
                {
                    query.Select(p => new { p.comImageList });
                }
                if (SelectFiled.Contains("productno,"))
                {
                    query.Select(p => new { p.ProductNo });
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
