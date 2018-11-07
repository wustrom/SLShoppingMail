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
    public partial class Commdity_Materials_ViewOper : SingleTon<Commdity_Materials_ViewOper>
    {
        /// <summary>
        /// 筛选全部数据
        /// </summary>
        /// <param name="model">模型</param>
        /// <param name="connection">连接</param>
        /// <param name="transaction">事务</param>
        /// <returns>对象列表</returns>
        public List<Commdity_Materials_View> SelectAll(Commdity_Materials_View model = null, string SelectFiled = null, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var query = new LambdaQuery<Commdity_Materials_View>();
            if (model != null)
            {
                if (!model.Id.IsNullOrEmpty())
                {
                    query.Where(p => p.Id == model.Id);
                }
                if (!model.Name.IsNullOrEmpty())
                {
                    query.Where(p => p.Name == model.Name);
                }
                if (!model.Image.IsNullOrEmpty())
                {
                    query.Where(p => p.Image == model.Image);
                }
                if (!model.GradeId.IsNullOrEmpty())
                {
                    query.Where(p => p.GradeId == model.GradeId);
                }
                if (!model.ScenceIds.IsNullOrEmpty())
                {
                    query.Where(p => p.ScenceIds == model.ScenceIds);
                }
                if (!model.FrontView.IsNullOrEmpty())
                {
                    query.Where(p => p.FrontView == model.FrontView);
                }
                if (!model.BackView.IsNullOrEmpty())
                {
                    query.Where(p => p.BackView == model.BackView);
                }
                if (!model.PrintingMethod.IsNullOrEmpty())
                {
                    query.Where(p => p.PrintingMethod == model.PrintingMethod);
                }
                if (!model.Color.IsNullOrEmpty())
                {
                    query.Where(p => p.Color == model.Color);
                }
                if (!model.Content.IsNullOrEmpty())
                {
                    query.Where(p => p.Content == model.Content);
                }
                if (!model.Sales.IsNullOrEmpty())
                {
                    query.Where(p => p.Sales == model.Sales);
                }
                if (!model.CreateTime.IsNullOrEmpty())
                {
                    query.Where(p => p.CreateTime == model.CreateTime);
                }
                if (!model.RecommendTime.IsNullOrEmpty())
                {
                    query.Where(p => p.RecommendTime == model.RecommendTime);
                }
                if (!model.Points.IsNullOrEmpty())
                {
                    query.Where(p => p.Points == model.Points);
                }
                if (!model.IsRelease.IsNullOrEmpty())
                {
                    query.Where(p => p.IsRelease == model.IsRelease);
                }
                if (!model.LastOperTime.IsNullOrEmpty())
                {
                    query.Where(p => p.LastOperTime == model.LastOperTime);
                }
                if (!model.LastOperId.IsNullOrEmpty())
                {
                    query.Where(p => p.LastOperId == model.LastOperId);
                }
                if (!model.ClickCount.IsNullOrEmpty())
                {
                    query.Where(p => p.ClickCount == model.ClickCount);
                }
                if (!model.Stars.IsNullOrEmpty())
                {
                    query.Where(p => p.Stars == model.Stars);
                }
                if (!model.StarCount.IsNullOrEmpty())
                {
                    query.Where(p => p.StarCount == model.StarCount);
                }
                if (!model.Introduce.IsNullOrEmpty())
                {
                    query.Where(p => p.Introduce == model.Introduce);
                }
                if (!model.ImageList.IsNullOrEmpty())
                {
                    query.Where(p => p.ImageList == model.ImageList);
                }
                if (!model.PringtingPosition.IsNullOrEmpty())
                {
                    query.Where(p => p.PringtingPosition == model.PringtingPosition);
                }
                if (!model.MaterialId.IsNullOrEmpty())
                {
                    query.Where(p => p.MaterialId == model.MaterialId);
                }
                if (!model.IsDelete.IsNullOrEmpty())
                {
                    query.Where(p => p.IsDelete == model.IsDelete);
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
                if (SelectFiled.Contains("name,"))
                {
                    query.Select(p => new { p.Name });
                }
                if (SelectFiled.Contains("image,"))
                {
                    query.Select(p => new { p.Image });
                }
                if (SelectFiled.Contains("gradeid,"))
                {
                    query.Select(p => new { p.GradeId });
                }
                if (SelectFiled.Contains("scenceids,"))
                {
                    query.Select(p => new { p.ScenceIds });
                }
                if (SelectFiled.Contains("frontview,"))
                {
                    query.Select(p => new { p.FrontView });
                }
                if (SelectFiled.Contains("backview,"))
                {
                    query.Select(p => new { p.BackView });
                }
                if (SelectFiled.Contains("printingmethod,"))
                {
                    query.Select(p => new { p.PrintingMethod });
                }
                if (SelectFiled.Contains("color,"))
                {
                    query.Select(p => new { p.Color });
                }
                if (SelectFiled.Contains("content,"))
                {
                    query.Select(p => new { p.Content });
                }
                if (SelectFiled.Contains("sales,"))
                {
                    query.Select(p => new { p.Sales });
                }
                if (SelectFiled.Contains("createtime,"))
                {
                    query.Select(p => new { p.CreateTime });
                }
                if (SelectFiled.Contains("recommendtime,"))
                {
                    query.Select(p => new { p.RecommendTime });
                }
                if (SelectFiled.Contains("points,"))
                {
                    query.Select(p => new { p.Points });
                }
                if (SelectFiled.Contains("isrelease,"))
                {
                    query.Select(p => new { p.IsRelease });
                }
                if (SelectFiled.Contains("lastopertime,"))
                {
                    query.Select(p => new { p.LastOperTime });
                }
                if (SelectFiled.Contains("lastoperid,"))
                {
                    query.Select(p => new { p.LastOperId });
                }
                if (SelectFiled.Contains("clickcount,"))
                {
                    query.Select(p => new { p.ClickCount });
                }
                if (SelectFiled.Contains("stars,"))
                {
                    query.Select(p => new { p.Stars });
                }
                if (SelectFiled.Contains("starcount,"))
                {
                    query.Select(p => new { p.StarCount });
                }
                if (SelectFiled.Contains("introduce,"))
                {
                    query.Select(p => new { p.Introduce });
                }
                if (SelectFiled.Contains("imagelist,"))
                {
                    query.Select(p => new { p.ImageList });
                }
                if (SelectFiled.Contains("pringtingposition,"))
                {
                    query.Select(p => new { p.PringtingPosition });
                }
                if (SelectFiled.Contains("materialid,"))
                {
                    query.Select(p => new { p.MaterialId });
                }
                if (SelectFiled.Contains("isdelete,"))
                {
                    query.Select(p => new { p.IsDelete });
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
        public int SelectCount(Commdity_Materials_View model = null, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var query = new LambdaQuery<Commdity_Materials_View>();
            if (model != null)
            {
                if (!model.Id.IsNullOrEmpty())
                {
                    query.Where(p => p.Id == model.Id);
                }
                if (!model.Name.IsNullOrEmpty())
                {
                    query.Where(p => p.Name == model.Name);
                }
                if (!model.Image.IsNullOrEmpty())
                {
                    query.Where(p => p.Image == model.Image);
                }
                if (!model.GradeId.IsNullOrEmpty())
                {
                    query.Where(p => p.GradeId == model.GradeId);
                }
                if (!model.ScenceIds.IsNullOrEmpty())
                {
                    query.Where(p => p.ScenceIds == model.ScenceIds);
                }
                if (!model.FrontView.IsNullOrEmpty())
                {
                    query.Where(p => p.FrontView == model.FrontView);
                }
                if (!model.BackView.IsNullOrEmpty())
                {
                    query.Where(p => p.BackView == model.BackView);
                }
                if (!model.PrintingMethod.IsNullOrEmpty())
                {
                    query.Where(p => p.PrintingMethod == model.PrintingMethod);
                }
                if (!model.Color.IsNullOrEmpty())
                {
                    query.Where(p => p.Color == model.Color);
                }
                if (!model.Content.IsNullOrEmpty())
                {
                    query.Where(p => p.Content == model.Content);
                }
                if (!model.Sales.IsNullOrEmpty())
                {
                    query.Where(p => p.Sales == model.Sales);
                }
                if (!model.CreateTime.IsNullOrEmpty())
                {
                    query.Where(p => p.CreateTime == model.CreateTime);
                }
                if (!model.RecommendTime.IsNullOrEmpty())
                {
                    query.Where(p => p.RecommendTime == model.RecommendTime);
                }
                if (!model.Points.IsNullOrEmpty())
                {
                    query.Where(p => p.Points == model.Points);
                }
                if (!model.IsRelease.IsNullOrEmpty())
                {
                    query.Where(p => p.IsRelease == model.IsRelease);
                }
                if (!model.LastOperTime.IsNullOrEmpty())
                {
                    query.Where(p => p.LastOperTime == model.LastOperTime);
                }
                if (!model.LastOperId.IsNullOrEmpty())
                {
                    query.Where(p => p.LastOperId == model.LastOperId);
                }
                if (!model.ClickCount.IsNullOrEmpty())
                {
                    query.Where(p => p.ClickCount == model.ClickCount);
                }
                if (!model.Stars.IsNullOrEmpty())
                {
                    query.Where(p => p.Stars == model.Stars);
                }
                if (!model.StarCount.IsNullOrEmpty())
                {
                    query.Where(p => p.StarCount == model.StarCount);
                }
                if (!model.Introduce.IsNullOrEmpty())
                {
                    query.Where(p => p.Introduce == model.Introduce);
                }
                if (!model.ImageList.IsNullOrEmpty())
                {
                    query.Where(p => p.ImageList == model.ImageList);
                }
                if (!model.PringtingPosition.IsNullOrEmpty())
                {
                    query.Where(p => p.PringtingPosition == model.PringtingPosition);
                }
                if (!model.MaterialId.IsNullOrEmpty())
                {
                    query.Where(p => p.MaterialId == model.MaterialId);
                }
                if (!model.IsDelete.IsNullOrEmpty())
                {
                    query.Where(p => p.IsDelete == model.IsDelete);
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
        public Commdity_Materials_View SelectById(int KeyId, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var query = new LambdaQuery<Commdity_Materials_View>();
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
        public List<Commdity_Materials_View> SelectByKeys(string Key,List<string> KeyIds, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var query = new LambdaQuery<Commdity_Materials_View>();
            if("id" == Key.ToLowerInvariant())
            {
                query.Where(p => p.Id.In(KeyIds));
            }
            if("name" == Key.ToLowerInvariant())
            {
                query.Where(p => p.Name.In(KeyIds));
            }
            if("image" == Key.ToLowerInvariant())
            {
                query.Where(p => p.Image.In(KeyIds));
            }
            if("gradeid" == Key.ToLowerInvariant())
            {
                query.Where(p => p.GradeId.In(KeyIds));
            }
            if("scenceids" == Key.ToLowerInvariant())
            {
                query.Where(p => p.ScenceIds.In(KeyIds));
            }
            if("frontview" == Key.ToLowerInvariant())
            {
                query.Where(p => p.FrontView.In(KeyIds));
            }
            if("backview" == Key.ToLowerInvariant())
            {
                query.Where(p => p.BackView.In(KeyIds));
            }
            if("printingmethod" == Key.ToLowerInvariant())
            {
                query.Where(p => p.PrintingMethod.In(KeyIds));
            }
            if("color" == Key.ToLowerInvariant())
            {
                query.Where(p => p.Color.In(KeyIds));
            }
            if("content" == Key.ToLowerInvariant())
            {
                query.Where(p => p.Content.In(KeyIds));
            }
            if("sales" == Key.ToLowerInvariant())
            {
                query.Where(p => p.Sales.In(KeyIds));
            }
            if("createtime" == Key.ToLowerInvariant())
            {
                query.Where(p => p.CreateTime.In(KeyIds));
            }
            if("recommendtime" == Key.ToLowerInvariant())
            {
                query.Where(p => p.RecommendTime.In(KeyIds));
            }
            if("points" == Key.ToLowerInvariant())
            {
                query.Where(p => p.Points.In(KeyIds));
            }
            if("isrelease" == Key.ToLowerInvariant())
            {
                query.Where(p => p.IsRelease.In(KeyIds));
            }
            if("lastopertime" == Key.ToLowerInvariant())
            {
                query.Where(p => p.LastOperTime.In(KeyIds));
            }
            if("lastoperid" == Key.ToLowerInvariant())
            {
                query.Where(p => p.LastOperId.In(KeyIds));
            }
            if("clickcount" == Key.ToLowerInvariant())
            {
                query.Where(p => p.ClickCount.In(KeyIds));
            }
            if("stars" == Key.ToLowerInvariant())
            {
                query.Where(p => p.Stars.In(KeyIds));
            }
            if("starcount" == Key.ToLowerInvariant())
            {
                query.Where(p => p.StarCount.In(KeyIds));
            }
            if("introduce" == Key.ToLowerInvariant())
            {
                query.Where(p => p.Introduce.In(KeyIds));
            }
            if("imagelist" == Key.ToLowerInvariant())
            {
                query.Where(p => p.ImageList.In(KeyIds));
            }
            if("pringtingposition" == Key.ToLowerInvariant())
            {
                query.Where(p => p.PringtingPosition.In(KeyIds));
            }
            if("materialid" == Key.ToLowerInvariant())
            {
                query.Where(p => p.MaterialId.In(KeyIds));
            }
            if("isdelete" == Key.ToLowerInvariant())
            {
                query.Where(p => p.IsDelete.In(KeyIds));
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
        public List<Commdity_Materials_View> SelectByPage(string Key, int start, int PageSize, bool desc = true,Commdity_Materials_View model = null, string SelectFiled = null, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var query = new LambdaQuery<Commdity_Materials_View>();
            if (model != null)
            {
                if (!model.Id.IsNullOrEmpty())
                {
                    query.Where(p => p.Id == model.Id);
                }
                if (!model.Name.IsNullOrEmpty())
                {
                    query.Where(p => p.Name == model.Name);
                }
                if (!model.Image.IsNullOrEmpty())
                {
                    query.Where(p => p.Image == model.Image);
                }
                if (!model.GradeId.IsNullOrEmpty())
                {
                    query.Where(p => p.GradeId == model.GradeId);
                }
                if (!model.ScenceIds.IsNullOrEmpty())
                {
                    query.Where(p => p.ScenceIds == model.ScenceIds);
                }
                if (!model.FrontView.IsNullOrEmpty())
                {
                    query.Where(p => p.FrontView == model.FrontView);
                }
                if (!model.BackView.IsNullOrEmpty())
                {
                    query.Where(p => p.BackView == model.BackView);
                }
                if (!model.PrintingMethod.IsNullOrEmpty())
                {
                    query.Where(p => p.PrintingMethod == model.PrintingMethod);
                }
                if (!model.Color.IsNullOrEmpty())
                {
                    query.Where(p => p.Color == model.Color);
                }
                if (!model.Content.IsNullOrEmpty())
                {
                    query.Where(p => p.Content == model.Content);
                }
                if (!model.Sales.IsNullOrEmpty())
                {
                    query.Where(p => p.Sales == model.Sales);
                }
                if (!model.CreateTime.IsNullOrEmpty())
                {
                    query.Where(p => p.CreateTime == model.CreateTime);
                }
                if (!model.RecommendTime.IsNullOrEmpty())
                {
                    query.Where(p => p.RecommendTime == model.RecommendTime);
                }
                if (!model.Points.IsNullOrEmpty())
                {
                    query.Where(p => p.Points == model.Points);
                }
                if (!model.IsRelease.IsNullOrEmpty())
                {
                    query.Where(p => p.IsRelease == model.IsRelease);
                }
                if (!model.LastOperTime.IsNullOrEmpty())
                {
                    query.Where(p => p.LastOperTime == model.LastOperTime);
                }
                if (!model.LastOperId.IsNullOrEmpty())
                {
                    query.Where(p => p.LastOperId == model.LastOperId);
                }
                if (!model.ClickCount.IsNullOrEmpty())
                {
                    query.Where(p => p.ClickCount == model.ClickCount);
                }
                if (!model.Stars.IsNullOrEmpty())
                {
                    query.Where(p => p.Stars == model.Stars);
                }
                if (!model.StarCount.IsNullOrEmpty())
                {
                    query.Where(p => p.StarCount == model.StarCount);
                }
                if (!model.Introduce.IsNullOrEmpty())
                {
                    query.Where(p => p.Introduce == model.Introduce);
                }
                if (!model.ImageList.IsNullOrEmpty())
                {
                    query.Where(p => p.ImageList == model.ImageList);
                }
                if (!model.PringtingPosition.IsNullOrEmpty())
                {
                    query.Where(p => p.PringtingPosition == model.PringtingPosition);
                }
                if (!model.MaterialId.IsNullOrEmpty())
                {
                    query.Where(p => p.MaterialId == model.MaterialId);
                }
                if (!model.IsDelete.IsNullOrEmpty())
                {
                    query.Where(p => p.IsDelete == model.IsDelete);
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
                if (SelectFiled.Contains("name,"))
                {
                    query.Select(p => new { p.Name });
                }
                if (SelectFiled.Contains("image,"))
                {
                    query.Select(p => new { p.Image });
                }
                if (SelectFiled.Contains("gradeid,"))
                {
                    query.Select(p => new { p.GradeId });
                }
                if (SelectFiled.Contains("scenceids,"))
                {
                    query.Select(p => new { p.ScenceIds });
                }
                if (SelectFiled.Contains("frontview,"))
                {
                    query.Select(p => new { p.FrontView });
                }
                if (SelectFiled.Contains("backview,"))
                {
                    query.Select(p => new { p.BackView });
                }
                if (SelectFiled.Contains("printingmethod,"))
                {
                    query.Select(p => new { p.PrintingMethod });
                }
                if (SelectFiled.Contains("color,"))
                {
                    query.Select(p => new { p.Color });
                }
                if (SelectFiled.Contains("content,"))
                {
                    query.Select(p => new { p.Content });
                }
                if (SelectFiled.Contains("sales,"))
                {
                    query.Select(p => new { p.Sales });
                }
                if (SelectFiled.Contains("createtime,"))
                {
                    query.Select(p => new { p.CreateTime });
                }
                if (SelectFiled.Contains("recommendtime,"))
                {
                    query.Select(p => new { p.RecommendTime });
                }
                if (SelectFiled.Contains("points,"))
                {
                    query.Select(p => new { p.Points });
                }
                if (SelectFiled.Contains("isrelease,"))
                {
                    query.Select(p => new { p.IsRelease });
                }
                if (SelectFiled.Contains("lastopertime,"))
                {
                    query.Select(p => new { p.LastOperTime });
                }
                if (SelectFiled.Contains("lastoperid,"))
                {
                    query.Select(p => new { p.LastOperId });
                }
                if (SelectFiled.Contains("clickcount,"))
                {
                    query.Select(p => new { p.ClickCount });
                }
                if (SelectFiled.Contains("stars,"))
                {
                    query.Select(p => new { p.Stars });
                }
                if (SelectFiled.Contains("starcount,"))
                {
                    query.Select(p => new { p.StarCount });
                }
                if (SelectFiled.Contains("introduce,"))
                {
                    query.Select(p => new { p.Introduce });
                }
                if (SelectFiled.Contains("imagelist,"))
                {
                    query.Select(p => new { p.ImageList });
                }
                if (SelectFiled.Contains("pringtingposition,"))
                {
                    query.Select(p => new { p.PringtingPosition });
                }
                if (SelectFiled.Contains("materialid,"))
                {
                    query.Select(p => new { p.MaterialId });
                }
                if (SelectFiled.Contains("isdelete,"))
                {
                    query.Select(p => new { p.IsDelete });
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
