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
    public partial class Receive_Order_ViewOper : SingleTon<Receive_Order_ViewOper>
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
        public List<Receive_Order_View> SelectReceivePage(string Key, int start, int PageSize, bool desc, string Name)
        {
            var query = new LambdaQuery<Receive_Order_View>();
            var SelectStatus = query.Where(p => p.receiveStatus.Like("待出库") || p.receiveStatus.Like("已出库"));
            if (SelectStatus != null)
            {
                if (!Name.IsNullOrEmpty())
                {
                    query.Where(p => p.Id.Like(Name) || p.order_detailId.Like(Name) || p.Amount.Like(Name) || p.receiveStatus.Like(Name));
                }
                if (Key != null)
                {
                    query.OrderByKey(Key, desc);
                }
                else
                {
                    query.OrderByKey("receiveTime", true);
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
        public int SelectReceiveCount(string Name)
        {
            var query = new LambdaQuery<Receive_Order_View>();
            var SelectStatus = query.Where(p => p.receiveStatus.Like("待出库") || p.receiveStatus.Like("已出库"));
            if (SelectStatus != null)
            {
                if (!Name.IsNullOrEmpty())
                {
                    query.Where(p => p.Id.Like(Name) || p.order_detailId.Like(Name) || p.Amount.Like(Name) || p.receiveStatus.Like(Name));
                }
            }
            return query.GetQueryCount();
        }
    }
}
