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
    public partial class ProducerOper : SingleTon<ProducerOper>
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
        public List<Producer> SelectProducerPage(string Key, int start, int PageSize, bool desc, string Name)
        {
            var query = new LambdaQuery<Producer>();
            var querys = query.Where(p => p.IsDelete.Like("0"));
            if (!Name.IsNullOrEmpty())
            {
                querys.Where(p => p.Name.Like(Name) || p.Address.Like(Name) /*|| p.Relation.Like(Name)||p.Phone.Like(Name)*/|| p.AccountPeriod.Like(Name));
            }
            if (Key != null)
            {
                querys.OrderByKey(Key, desc);
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
        public int SelectProducerCount(string Name)
        {
            var query = new LambdaQuery<Producer>();
            var querys = query.Where(p => p.IsDelete.Like("0"));
            if (!Name.IsNullOrEmpty())
            {
                querys.Where(p => p.Name.Like(Name) || p.Address.Like(Name)/* || p.Relation.Like(Name) || p.Phone.Like(Name)*/ || p.AccountPeriod.Like(Name));
            }
            return query.GetQueryCount();
        }
    }
}
