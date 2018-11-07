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
    public partial class Raw_MaterialsOper : SingleTon<Raw_MaterialsOper>
    {
        /// <summary>
        /// 模糊分页查询
        /// </summary>
        /// <param name="Key">排序方式</param>
        /// <param name="start">开始条数</param>
        /// <param name="PageSize">页面长度</param>
        /// <param name="desc">降序</param>
        /// <param name="Name">名称</param>
        /// <returns></returns>
        public List<Raw_Materials> SelectLikePage(string Key, int start, int PageSize, bool desc, string Name, List<string> MetailsID)
        {
            var query = new LambdaQuery<Raw_Materials>();
            query.Where(p => p.IsDelete == false);
            if (!Name.IsNullOrEmpty())
            {
                query.Where(p => p.ProductNo.Like(Name) || p.Specification.Like(Name) || p.ChinaProductName.Like(Name));
            }
            if (MetailsID != null)
            {
                query.Where(p => p.Id.In(MetailsID));
            }
            if (Key != null)
            {
                query.OrderByKey(Key, desc);
            }
            return query.GetQueryPageList(start, PageSize);
        }

        /// <summary>
        /// 模糊分页查询
        /// </summary>
        /// <param name="Key">排序方式</param>
        /// <param name="start">开始条数</param>
        /// <param name="PageSize">页面长度</param>
        /// <param name="desc">降序</param>
        /// <param name="Name">名称</param>
        /// <returns></returns>
        public int SelectLikeCount(string Name, List<string> MetailsID)
        {
            var query = new LambdaQuery<Raw_Materials>();
            query.Where(p => p.IsDelete == false);
            if (!Name.IsNullOrEmpty())
            {
                query.Where(p => p.ProductNo.Like(Name) || p.Specification.Like(Name) || p.ChinaProductName.Like(Name));
            }
            if (MetailsID != null)
            {
                query.Where(p => p.Id.In(MetailsID));
            }
            return query.GetQueryCount();
        }
    }
}
