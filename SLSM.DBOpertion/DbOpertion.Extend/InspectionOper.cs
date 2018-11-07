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
    public partial class InspectionOper : SingleTon<InspectionOper>
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
        public List<Buyer_Producer_View> SelectInspectionPage(string Key, int start, int PageSize, bool desc, string Name, string Inspection)
        {
            var query = new LambdaQuery<Buyer_Producer_View>();
            var querys = query.Where(p => p.checkStatus == "待品检" || p.checkStatus == "品检合格" || p.checkStatus == "品检不合格" || p.checkStatus == "换货");
            if (querys != null)
            {
                query.Where(p => p.DeliverSingleTime != null);
                if (Inspection != null && Inspection != "0")
                {
                    querys.Where(p => p.checkStatus.Like(Inspection));
                }
                if (!Name.IsNullOrEmpty())
                {
                    querys.Where(p => p.Id.Like(Name) || p.Name.Like(Name) || p.checkStatus.Like(Name) || p.BuyerNo.Like(Name));
                }
                if (Key != null)
                {
                    query.OrderByKey(Key, desc);
                }
                else
                {
                    query.OrderByKey("Id", true);
                }
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
        public int SelectInspectionCount(string Name, string Inspection)
        {
            var query = new LambdaQuery<Buyer_Producer_View>();
            var querys = query.Where(p => p.checkStatus == "待品检" || p.checkStatus == "品检合格" || p.checkStatus == "品检不合格"|| p.checkStatus == "换货");
            if (querys != null)
            {
                if (Inspection != null && Inspection != "0")
                {
                    querys.Where(p => p.checkStatus.Like(Inspection));
                }
                if (!Name.IsNullOrEmpty())
                {
                    querys.Where(p => p.Id.Like(Name) || p.Name.Like(Name) || p.checkStatus.Like(Name));
                }
            }
            return query.GetQueryCount();
        }
    }
}
