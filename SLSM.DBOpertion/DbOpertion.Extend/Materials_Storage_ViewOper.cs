using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using Common.LambdaOpertion;
using Common.Extend;
using System.Data;
using DbOpertion.Models;
using Common.Extend.LambdaFunction;

namespace DbOpertion.Operation
{
    public partial class Materials_Storage_ViewOper : SingleTon<Materials_Storage_ViewOper>
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
        public List<Materials_Stock_View> SelectStockViewPage(string Key, int start, int PageSize, bool desc, string Name, List<string> materialsIds)
        {
            var query = new LambdaQuery<Materials_Stock_View>();
            var querys = query.Where(p => p.Id != 0);
            if (!Name.IsNullOrEmpty())
            {
                querys.Where(p => p.ChinaProductName.Like(Name) || p.SKU.Like(Name) || p.ProductNo.Like(Name) || p.freeze_stock.Like(Name) || p.Stock.Like(Name) || p.ColorName.Like(Name));
            }
            if (Key != null)
            {
                querys.OrderByKey(Key, desc);
            }
            else
            {
                query.OrderByKey("Id", true);
            }
            if (materialsIds != null)
            {
                query.Where(p => p.MaterialId.In(materialsIds));
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
        public int SelectStockViewCount(string Name, List<string> materialsIds)
        {
            var query = new LambdaQuery<Materials_Stock_View>();
            var querys = query.Where(p => p.Id != 0);
            if (!Name.IsNullOrEmpty())
            {
                querys.Where(p => p.ChinaProductName.Like(Name) || p.SKU.Like(Name) || p.ProductNo.Like(Name) || p.freeze_stock.Like(Name) || p.Stock.Like(Name) || p.ColorName.Like(Name));
            }
            if (materialsIds != null)
            {
                query.Where(p => p.MaterialId.In(materialsIds));
            }
            return query.GetQueryCount();
        }
    }
}
