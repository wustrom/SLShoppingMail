using Common;
using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common.LambdaOpertion;
using Common.Extend;
using System.Data;
using DbOpertion.Models;
using Common.Extend.LambdaFunction;

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
        public List<Hisdesigninfo_View> SelectByUser(Hisdesigninfo_View model = null, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var query = new LambdaQuery<Hisdesigninfo_View>();
            //query.Select(p => new { p.UserID, p.UserGuId, p.PrintingMethod, p.Name, p.LastLookTime, p.Image, p.Id, p.ForntView, p.CommodityId, p.Color, p.BackView, p.Attr, p.Amount, p.CommBackView, p.CommFrontView });
            if (model != null)
            {
                if (!model.Id.IsNullOrEmpty())
                {
                    query.Where(p => p.Id == model.Id);
                }
                if (!model.UserGuId.IsNullOrEmpty() && !model.UserID.IsNullOrEmpty())
                {
                    query.Where(p => p.UserID == model.UserID || p.UserGuId == model.UserGuId);
                }
                else if (!model.UserGuId.IsNullOrEmpty() && model.UserID.IsNullOrEmpty())
                {
                    query.Where(p => p.UserGuId == model.UserGuId);
                }
                else if (model.UserGuId.IsNullOrEmpty() && !model.UserID.IsNullOrEmpty())
                {
                    query.Where(p => p.UserID == model.UserID);
                }
                if (!model.CommodityId.IsNullOrEmpty())
                {
                    query.Where(p => p.CommodityId == model.CommodityId);
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
                if (!model.IsMobile.IsNullOrEmpty())
                {
                    query.Where(p => p.IsMobile == model.IsMobile);
                }
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
        public List<Hisdesigninfo_View> SelectByUserPage(string Key, int start, int PageSize, bool desc = true, Hisdesigninfo_View model = null, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var query = new LambdaQuery<Hisdesigninfo_View>();
            if (model != null)
            {
                if (!model.Id.IsNullOrEmpty())
                {
                    query.Where(p => p.Id == model.Id);
                }
                if (!model.UserGuId.IsNullOrEmpty() && !model.UserID.IsNullOrEmpty())
                {
                    query.Where(p => p.UserID == model.UserID || p.UserGuId == model.UserGuId);
                }
                else if (!model.UserGuId.IsNullOrEmpty() && model.UserID.IsNullOrEmpty())
                {
                    query.Where(p => p.UserGuId == model.UserGuId);
                }
                else if (model.UserGuId.IsNullOrEmpty() && !model.UserID.IsNullOrEmpty())
                {
                    query.Where(p => p.UserID == model.UserID);
                }
                if (!model.CommodityId.IsNullOrEmpty())
                {
                    query.Where(p => p.CommodityId == model.CommodityId);
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
                if (!model.IsMobile.IsNullOrEmpty())
                {
                    query.Where(p => p.IsMobile == model.IsMobile);
                }
            }
            if (Key != null)
            {
                query.OrderByKey(Key, desc);
            }
            return query.GetQueryPageList(start, PageSize, connection, transaction);
        }

        /// <summary>
        /// 数据条数
        /// </summary>
        /// <param name="model">模型</param>
        /// <param name="connection">连接</param>
        /// <param name="transaction">事务</param>
        /// <returns>对象列表</returns>
        public int SelectUserCount(Hisdesigninfo_View model = null, List<string> Ids = null, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var query = new LambdaQuery<Hisdesigninfo_View>();
            if (model != null)
            {
                if (Ids != null)
                {
                    query.Where(p => p.Id.In(Ids));
                }
                if (!model.UserGuId.IsNullOrEmpty() && !model.UserID.IsNullOrEmpty())
                {
                    query.Where(p => p.UserID == model.UserID || p.UserGuId == model.UserGuId);
                }
                else if (!model.UserGuId.IsNullOrEmpty() && model.UserID.IsNullOrEmpty())
                {
                    query.Where(p => p.UserGuId == model.UserGuId);
                }
                else if (model.UserGuId.IsNullOrEmpty() && !model.UserID.IsNullOrEmpty())
                {
                    query.Where(p => p.UserID == model.UserID);
                }
                if (!model.CommodityId.IsNullOrEmpty())
                {
                    query.Where(p => p.CommodityId == model.CommodityId);
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
                if (!model.IsMobile.IsNullOrEmpty())
                {
                    query.Where(p => p.IsMobile == model.IsMobile);
                }
            }
            return query.GetQueryCount(connection, transaction);
        }
    }
}
