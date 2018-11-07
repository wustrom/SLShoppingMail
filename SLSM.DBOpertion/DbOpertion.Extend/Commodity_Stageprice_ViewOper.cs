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
    public partial class Commodity_Stageprice_ViewOper : SingleTon<Commodity_Stageprice_ViewOper>
    {
        public List<Commodity_Stageprice_View> SelectByGradeIds(Commodity_Stageprice_View model = null, IDbConnection connection = null, IDbTransaction transaction = null, List<int> gradeIds = null)
        {
            var query = new LambdaQuery<Commodity_Stageprice_View>();
            if (model != null)
            {
                var tempIds = gradeIds.ConvertAll<string>(x => x.ToString());
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
                    query.Where(p => p.GradeId.In(tempIds));
                }

                //if (!model.GradeId.IsNullOrEmpty())
                //{
                //    query.Where(p => p.GradeId == model.GradeId);
                //}




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
                if (!model.IsDelete.IsNullOrEmpty())
                {
                    query.Where(p => p.IsDelete == model.IsDelete);
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
                if (!model.minPrice.IsNullOrEmpty())
                {
                    query.Where(p => p.minPrice == model.minPrice);
                }
                if (!model.maxPrice.IsNullOrEmpty())
                {
                    query.Where(p => p.maxPrice == model.maxPrice);
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
        public List<Commodity_Stageprice_View> SelectByPageForCommList(string Key, int start, int PageSize, bool desc = true, Commodity_Stageprice_View model = null, IDbConnection connection = null, IDbTransaction transaction = null, List<int> ids = null, int? sales = null)
        {
            var temp = ids.ConvertAll(x => x.ToString());
            var query = new LambdaQuery<Commodity_Stageprice_View>();
            if (model != null)
            {
                if (!model.Id.IsNullOrEmpty())
                {
                    query.Where(p => p.Id.In(temp));
                }
                if (!model.Sales.IsNullOrEmpty())
                {
                    query.Where(p => p.Sales >= sales);
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
                if (!model.IsDelete.IsNullOrEmpty())
                {
                    query.Where(p => p.IsDelete == model.IsDelete);
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
                if (!model.minPrice.IsNullOrEmpty())
                {
                    query.Where(p => p.minPrice == model.minPrice);
                }
                if (!model.maxPrice.IsNullOrEmpty())
                {
                    query.Where(p => p.maxPrice == model.maxPrice);
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
        public int SelectCountForCommList(Commodity_Stageprice_View model = null, IDbConnection connection = null, IDbTransaction transaction = null, List<int> ids = null, int? sales = null)
        {
            var temp = ids.ConvertAll(x => x.ToString());
            var query = new LambdaQuery<Commodity_Stageprice_View>();
            if (model != null)
            {
                if (!model.Id.IsNullOrEmpty())
                {
                    query.Where(p => p.Id.In(temp));
                }
                if (!model.Sales.IsNullOrEmpty())
                {
                    query.Where(p => p.Sales >= sales);
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
                if (!model.IsDelete.IsNullOrEmpty())
                {
                    query.Where(p => p.IsDelete == model.IsDelete);
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
                if (!model.minPrice.IsNullOrEmpty())
                {
                    query.Where(p => p.minPrice == model.minPrice);
                }
                if (!model.maxPrice.IsNullOrEmpty())
                {
                    query.Where(p => p.maxPrice == model.maxPrice);
                }
                if (!model.minAmount.IsNullOrEmpty())
                {
                    query.Where(p => p.minAmount == model.minAmount);
                }
            }
            return query.GetQueryCount(connection, transaction);
        }

        /// <summary>
        /// 通过关键词筛选数据
        /// </summary>
        /// <param name="model">模型</param>
        /// <param name="connection">连接</param>
        /// <param name="transaction">事务</param>
        /// <returns>对象列表</returns>
        public List<Commodity_Stageprice_View> SelectBySearch(int? PageNo, Commodity_Stageprice_View model = null, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var query = new LambdaQuery<Commodity_Stageprice_View>();
            query.Where(p => p.IsDelete != true);
            if (model != null)
            {
                if (!model.Name.IsNullOrEmpty())
                {
                    query.Where(p => p.Name.Contains(model.Name) || p.Content.Contains(model.Content) || p.Introduce.Contains(model.Introduce));
                }
            }
            if (PageNo == null)
            {
                return query.GetQueryList(connection, transaction);
            }
            else
            {
                return query.GetQueryPageList((PageNo.Value - 1) * 15, 15, connection, transaction);
            }
            
        }

        /// <summary>
        /// 通过关键词筛选数据数量
        /// </summary>
        /// <param name="model">模型</param>
        /// <param name="connection">连接</param>
        /// <param name="transaction">事务</param>
        /// <returns>数量</returns>
        public int SelectBySearchCount(Commodity_Stageprice_View model = null, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var query = new LambdaQuery<Commodity_Stageprice_View>();
            query.Where(p => p.IsDelete != true);
            if (model != null)
            {
                if (!model.Name.IsNullOrEmpty())
                {
                    query.Where(p => p.Name.Contains(model.Name) || p.Content.Contains(model.Content) || p.Introduce.Contains(model.Introduce));
                }
            }
            return query.GetQueryCount(connection, transaction);
        }


        /// <summary>
        /// 根据关键词筛选数据
        /// </summary>
        /// <param name="Key">主键</param>
        /// <param name="start">开始数据</param>
        /// <param name="PageSize">页面长度</param>
        /// <param name="desc">排序</param>
        /// <param name="model">对象</param>
        /// <param name="connection">连接</param>
        /// <param name="transaction">事务</param>
        /// <returns>对象列表</returns>
        public List<Commodity_Stageprice_View> SelectByPageForSearchList(string Key, int start, int PageSize, bool desc = true, Commodity_Stageprice_View model = null, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var query = new LambdaQuery<Commodity_Stageprice_View>();

            if (model != null)
            {
                if (!model.Name.IsNullOrEmpty())
                {
                    query.Where(p => p.Name.Contains(model.Name) || p.Content.Contains(model.Content) || p.Introduce.Contains(model.Introduce));
                }
                if (!model.Sales.IsNullOrEmpty())
                {
                    query.Where(p => p.Sales >= model.Sales);
                }




                if (!model.Image.IsNullOrEmpty())
                {
                    query.Where(p => p.Image == model.Image);
                }
                if (!model.GradeId.IsNullOrEmpty())
                {
                    query.Where(p => p.GradeId == model.GradeId);
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
                if (!model.IsDelete.IsNullOrEmpty())
                {
                    query.Where(p => p.IsDelete == model.IsDelete);
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

                if (!model.ImageList.IsNullOrEmpty())
                {
                    query.Where(p => p.ImageList == model.ImageList);
                }
                if (!model.minPrice.IsNullOrEmpty())
                {
                    query.Where(p => p.minPrice == model.minPrice);
                }
                if (!model.maxPrice.IsNullOrEmpty())
                {
                    query.Where(p => p.maxPrice == model.maxPrice);
                }
                if (!model.minAmount.IsNullOrEmpty())
                {
                    query.Where(p => p.minAmount == model.minAmount);
                }
            }
            if (Key != null)
            {
                query.OrderByKey(Key, desc);
            }
            return query.GetQueryPageList(start, (int)PageSize, connection, transaction);
        }

        public int SelectCountForSearchList(Commodity_Stageprice_View model = null, IDbConnection connection = null, IDbTransaction transaction = null, List<int> ids = null)
        {

            var query = new LambdaQuery<Commodity_Stageprice_View>();
            if (model != null)
            {
                if (!model.Name.IsNullOrEmpty())
                {
                    query.Where(p => p.Name.Contains(model.Name) || p.Content.Contains(model.Content) || p.Introduce.Contains(model.Introduce));
                }
                if (!model.Sales.IsNullOrEmpty())
                {
                    query.Where(p => p.Sales >= model.Sales);
                }
            }
            return query.GetQueryCount(connection, transaction);
        }
    }
}
