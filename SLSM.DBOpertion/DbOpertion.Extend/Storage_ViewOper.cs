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
    public partial class Storage_ViewOper : SingleTon<Storage_ViewOper>
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
        public List<Storage_View> SelectStoragePage(string Key, int start, int PageSize, bool desc, string Name)
        {
            var query = new LambdaQuery<Storage_View>();
            if (!Name.IsNullOrEmpty())
            {
                query.Where(p => p.Id.Like(Name) || p.ChinaProductName.Like(Name) || p.Specification.Like(Name)  || p.stock.Like(Name) || p.freeze_stock.Like(Name) || p.WarehouseName.Like(Name)||p.Color.Like(Name));
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
        public int SelectStorageCount(string Name)
        {
            var query = new LambdaQuery<Storage_View>();
            if (!Name.IsNullOrEmpty())
            {
                query.Where(p => p.Id.Like(Name) || p.ChinaProductName.Like(Name) || p.Specification.Like(Name) || p.stock.Like(Name) || p.freeze_stock.Like(Name) || p.WarehouseName.Like(Name) || p.Color.Like(Name));
            }
            return query.GetQueryCount();
        }
    }
}
