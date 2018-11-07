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
    public partial class CommodityOper : SingleTon<CommodityOper>
    {

        /// <summary>
        /// 筛选全部数据
        /// </summary>
        /// <param name="model">模型</param>
        /// <param name="connection">连接</param>
        /// <param name="transaction">事务</param>
        /// <returns>对象列表</returns>
        public List<Commodity> SelectByIds(Commodity model = null, IDbConnection connection = null, IDbTransaction transaction = null, List<int> gradeIds = null)
        {
            var temp = gradeIds.ConvertAll(x => x.ToString());
            var query = new LambdaQuery<Commodity>();
            if (model != null)
            {
                if (!model.Id.IsNullOrEmpty())
                {
                    query.Where(p => p.Id.In(temp));
                }

                if (!model.Image.IsNullOrEmpty())
                {
                    query.Where(p => p.Image == model.Image);
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
                if (!model.IsDelete.IsNullOrEmpty())
                {
                    query.Where(p => p.IsDelete == model.IsDelete);
                }
                if (!model.ClickCount.IsNullOrEmpty())
                {
                    query.Where(p => p.ClickCount == model.ClickCount);
                }
            }
            return query.GetQueryList(connection, transaction);
        }

        public List<Commodity> SelectByGradeIds(Commodity model = null, IDbConnection connection = null, IDbTransaction transaction = null, List<int> gradeIds = null)
        {
            var temp = gradeIds.ConvertAll(x => x.ToString());
            var query = new LambdaQuery<Commodity>();
            if (model != null)
            {

                if (!model.GradeId.IsNullOrEmpty())
                {
                    query.Where(p => p.GradeId.In(temp));
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
                if (!model.IsDelete.IsNullOrEmpty())
                {
                    query.Where(p => p.IsDelete == model.IsDelete);
                }
                if (!model.ClickCount.IsNullOrEmpty())
                {
                    query.Where(p => p.ClickCount == model.ClickCount);
                }
            }
            return query.GetQueryList(connection, transaction);
        }

        /// <summary>
        /// 分页获得商品列表
        /// </summary>
        /// <param name="Key">主键</param>
        /// <param name="start">开始数据</param>
        /// <param name="PageSize">页面长度</param>
        /// <param name="desc">排序</param>
        /// <param name="model">对象</param>
        /// <returns>对象列表</returns>
        public List<Commdity_Materials_View> SelectCommodityListByPage(string Key, int start, int PageSize, bool desc = true, string name = null)
        {
            var query = new LambdaQuery<Commdity_Materials_View>();
            if (name != null)
            {
                query.Where(p => p.Name.Like(name) || p.Introduce.Like(name) || p.Sales.Like(name) || p.StarCount.Like(name));
            }
            query.Where(p => p.IsDelete != true);
            if (Key != null)
            {
                query.OrderByKey(Key, desc);
            }
            return query.GetQueryPageList(start, PageSize);
        }

        /// <summary>
        /// 分页获得商品列表
        /// </summary>
        /// <param name="Key">主键</param>
        /// <param name="start">开始数据</param>
        /// <param name="PageSize">页面长度</param>
        /// <param name="desc">排序</param>
        /// <param name="model">对象</param>
        /// <returns>对象列表</returns>
        public int SelectCommodityListCount(int start, int PageSize, string name = null)
        {
            var query = new LambdaQuery<Commdity_Materials_View>();
            if (name != null)
            {
                query.Where(p => p.Name.Like(name) || p.Introduce.Like(name) || p.Sales.Like(name) || p.StarCount.Like(name));
            }
            query.Where(p => p.IsDelete != true);
            return query.GetQueryCount();
        }
    }
}
