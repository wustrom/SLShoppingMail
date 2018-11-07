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
    public partial class Hisdesigninfo_ViewOper : SingleTon<Hisdesigninfo_ViewOper>
    {
        /// <summary>
        /// 筛选全部数据
        /// </summary>
        /// <param name="model">模型</param>
        /// <param name="connection">连接</param>
        /// <param name="transaction">事务</param>
        /// <returns>对象列表</returns>
        public List<Hisdesigninfo_View> SelectAll(Hisdesigninfo_View model = null, string SelectFiled = null, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var query = new LambdaQuery<Hisdesigninfo_View>();
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
                if (!model.Name.IsNullOrEmpty())
                {
                    query.Where(p => p.Name == model.Name);
                }
                if (!model.Image.IsNullOrEmpty())
                {
                    query.Where(p => p.Image == model.Image);
                }
                if (!model.CommBackView.IsNullOrEmpty())
                {
                    query.Where(p => p.CommBackView == model.CommBackView);
                }
                if (!model.CommFrontView.IsNullOrEmpty())
                {
                    query.Where(p => p.CommFrontView == model.CommFrontView);
                }
                if (!model.MaterialId.IsNullOrEmpty())
                {
                    query.Where(p => p.MaterialId == model.MaterialId);
                }
                if (!model.ImageList.IsNullOrEmpty())
                {
                    query.Where(p => p.ImageList == model.ImageList);
                }
                if (!model.SalesInfoList.IsNullOrEmpty())
                {
                    query.Where(p => p.SalesInfoList == model.SalesInfoList);
                }
                if (!model.ProductNo.IsNullOrEmpty())
                {
                    query.Where(p => p.ProductNo == model.ProductNo);
                }
                if (!model.PrintFuncInfo.IsNullOrEmpty())
                {
                    query.Where(p => p.PrintFuncInfo == model.PrintFuncInfo);
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
                if (SelectFiled.Contains("name,"))
                {
                    query.Select(p => new { p.Name });
                }
                if (SelectFiled.Contains("image,"))
                {
                    query.Select(p => new { p.Image });
                }
                if (SelectFiled.Contains("commbackview,"))
                {
                    query.Select(p => new { p.CommBackView });
                }
                if (SelectFiled.Contains("commfrontview,"))
                {
                    query.Select(p => new { p.CommFrontView });
                }
                if (SelectFiled.Contains("materialid,"))
                {
                    query.Select(p => new { p.MaterialId });
                }
                if (SelectFiled.Contains("imagelist,"))
                {
                    query.Select(p => new { p.ImageList });
                }
                if (SelectFiled.Contains("salesinfolist,"))
                {
                    query.Select(p => new { p.SalesInfoList });
                }
                if (SelectFiled.Contains("productno,"))
                {
                    query.Select(p => new { p.ProductNo });
                }
                if (SelectFiled.Contains("printfuncinfo,"))
                {
                    query.Select(p => new { p.PrintFuncInfo });
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
        public int SelectCount(Hisdesigninfo_View model = null, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var query = new LambdaQuery<Hisdesigninfo_View>();
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
                if (!model.Name.IsNullOrEmpty())
                {
                    query.Where(p => p.Name == model.Name);
                }
                if (!model.Image.IsNullOrEmpty())
                {
                    query.Where(p => p.Image == model.Image);
                }
                if (!model.CommBackView.IsNullOrEmpty())
                {
                    query.Where(p => p.CommBackView == model.CommBackView);
                }
                if (!model.CommFrontView.IsNullOrEmpty())
                {
                    query.Where(p => p.CommFrontView == model.CommFrontView);
                }
                if (!model.MaterialId.IsNullOrEmpty())
                {
                    query.Where(p => p.MaterialId == model.MaterialId);
                }
                if (!model.ImageList.IsNullOrEmpty())
                {
                    query.Where(p => p.ImageList == model.ImageList);
                }
                if (!model.SalesInfoList.IsNullOrEmpty())
                {
                    query.Where(p => p.SalesInfoList == model.SalesInfoList);
                }
                if (!model.ProductNo.IsNullOrEmpty())
                {
                    query.Where(p => p.ProductNo == model.ProductNo);
                }
                if (!model.PrintFuncInfo.IsNullOrEmpty())
                {
                    query.Where(p => p.PrintFuncInfo == model.PrintFuncInfo);
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
        public Hisdesigninfo_View SelectById(int KeyId, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var query = new LambdaQuery<Hisdesigninfo_View>();
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
        public List<Hisdesigninfo_View> SelectByKeys(string Key,List<string> KeyIds, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var query = new LambdaQuery<Hisdesigninfo_View>();
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
            if("name" == Key.ToLowerInvariant())
            {
                query.Where(p => p.Name.In(KeyIds));
            }
            if("image" == Key.ToLowerInvariant())
            {
                query.Where(p => p.Image.In(KeyIds));
            }
            if("commbackview" == Key.ToLowerInvariant())
            {
                query.Where(p => p.CommBackView.In(KeyIds));
            }
            if("commfrontview" == Key.ToLowerInvariant())
            {
                query.Where(p => p.CommFrontView.In(KeyIds));
            }
            if("materialid" == Key.ToLowerInvariant())
            {
                query.Where(p => p.MaterialId.In(KeyIds));
            }
            if("imagelist" == Key.ToLowerInvariant())
            {
                query.Where(p => p.ImageList.In(KeyIds));
            }
            if("salesinfolist" == Key.ToLowerInvariant())
            {
                query.Where(p => p.SalesInfoList.In(KeyIds));
            }
            if("productno" == Key.ToLowerInvariant())
            {
                query.Where(p => p.ProductNo.In(KeyIds));
            }
            if("printfuncinfo" == Key.ToLowerInvariant())
            {
                query.Where(p => p.PrintFuncInfo.In(KeyIds));
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
        public List<Hisdesigninfo_View> SelectByPage(string Key, int start, int PageSize, bool desc = true,Hisdesigninfo_View model = null, string SelectFiled = null, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var query = new LambdaQuery<Hisdesigninfo_View>();
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
                if (!model.Name.IsNullOrEmpty())
                {
                    query.Where(p => p.Name == model.Name);
                }
                if (!model.Image.IsNullOrEmpty())
                {
                    query.Where(p => p.Image == model.Image);
                }
                if (!model.CommBackView.IsNullOrEmpty())
                {
                    query.Where(p => p.CommBackView == model.CommBackView);
                }
                if (!model.CommFrontView.IsNullOrEmpty())
                {
                    query.Where(p => p.CommFrontView == model.CommFrontView);
                }
                if (!model.MaterialId.IsNullOrEmpty())
                {
                    query.Where(p => p.MaterialId == model.MaterialId);
                }
                if (!model.ImageList.IsNullOrEmpty())
                {
                    query.Where(p => p.ImageList == model.ImageList);
                }
                if (!model.SalesInfoList.IsNullOrEmpty())
                {
                    query.Where(p => p.SalesInfoList == model.SalesInfoList);
                }
                if (!model.ProductNo.IsNullOrEmpty())
                {
                    query.Where(p => p.ProductNo == model.ProductNo);
                }
                if (!model.PrintFuncInfo.IsNullOrEmpty())
                {
                    query.Where(p => p.PrintFuncInfo == model.PrintFuncInfo);
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
                if (SelectFiled.Contains("name,"))
                {
                    query.Select(p => new { p.Name });
                }
                if (SelectFiled.Contains("image,"))
                {
                    query.Select(p => new { p.Image });
                }
                if (SelectFiled.Contains("commbackview,"))
                {
                    query.Select(p => new { p.CommBackView });
                }
                if (SelectFiled.Contains("commfrontview,"))
                {
                    query.Select(p => new { p.CommFrontView });
                }
                if (SelectFiled.Contains("materialid,"))
                {
                    query.Select(p => new { p.MaterialId });
                }
                if (SelectFiled.Contains("imagelist,"))
                {
                    query.Select(p => new { p.ImageList });
                }
                if (SelectFiled.Contains("salesinfolist,"))
                {
                    query.Select(p => new { p.SalesInfoList });
                }
                if (SelectFiled.Contains("productno,"))
                {
                    query.Select(p => new { p.ProductNo });
                }
                if (SelectFiled.Contains("printfuncinfo,"))
                {
                    query.Select(p => new { p.PrintFuncInfo });
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
