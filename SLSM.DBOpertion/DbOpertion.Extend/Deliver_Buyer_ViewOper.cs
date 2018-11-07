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
    public partial class Deliver_Buyer_ViewOper : SingleTon<Deliver_Buyer_ViewOper>
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
        public List<Deliver_Buyer_View> SelectDeliverPage(string Key, int start, int PageSize, bool desc, string Name)
        {
            var query = new LambdaQuery<Deliver_Buyer_View>();
            var SelectBuyer = query.Where(p => p.buyerId.Like("0"));
            if (SelectBuyer != null)
            {
                if (!Name.IsNullOrEmpty())
                {
                    SelectBuyer.Where(p => p.Id.Like(Name) || p.producerIdName.Like(Name) || p.buyerPrice.Like(Name) || p.buyerCount.Like(Name) || p.DeliverMoney.Like(Name));
                }
                if (Key != null)
                {
                    query.OrderByKey(Key, desc);
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
        public int SelectDeliverCount(string Name)
        {
            var query = new LambdaQuery<Deliver_Buyer_View>();
            var SelectBuyer = query.Where(p => p.buyerId.Like("0"));
            if (SelectBuyer != null)
            {
                if (!Name.IsNullOrEmpty())
                {
                    query.Where(p => p.Id.Like(Name) || p.producerIdName.Like(Name) || p.buyerPrice.Like(Name) || p.buyerCount.Like(Name) || p.DeliverMoney.Like(Name));
                }
            }
            return query.GetQueryCount();
        }
    }
}
