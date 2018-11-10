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
    public partial class Order_AllinfoOper : SingleTon<Order_AllinfoOper>
    {
        /// <summary>
        /// 模糊查找分页筛选数据
        /// </summary>
        /// <param name="Key">主键</param>
        /// <param name="start">开始数据</param>
        /// <param name="PageSize">页面长度</param>
        /// <param name="desc">排序</param>
        /// <param name="model">对象</param>
        /// <param name="connection">连接</param>
        /// <param name="transaction">事务</param>
        /// <returns>对象列表</returns>
        public List<Order_Allinfo> SelectByVaguePage(string Key, int start, int PageSize, bool desc, Order_Allinfo model, string SearchName)
        {
            var query = new LambdaQuery<Order_Allinfo>();
            if (model != null)
            {
                if (!model.Id.IsNullOrEmpty())
                {
                    query.Where(p => p.Id == model.Id);
                }
                if (!model.UserId.IsNullOrEmpty())
                {
                    query.Where(p => p.UserId == model.UserId);
                }
                if (!model.AddressId.IsNullOrEmpty())
                {
                    query.Where(p => p.AddressId == model.AddressId);
                }
                if (!model.TotalPrice.IsNullOrEmpty())
                {
                    query.Where(p => p.TotalPrice == model.TotalPrice);
                }
                if (!model.PayType.IsNullOrEmpty())
                {
                    query.Where(p => p.PayType == model.PayType);
                }
                if (!model.Status.IsNullOrEmpty())
                {
                    query.Where(p => p.Status == model.Status);
                }
                if (!model.OrderNo.IsNullOrEmpty())
                {
                    query.Where(p => p.OrderNo == model.OrderNo);
                }
                if (!model.OrderTime.IsNullOrEmpty())
                {
                    query.Where(p => p.OrderTime == model.OrderTime);
                }
                if (!model.OrderType.IsNullOrEmpty())
                {
                    query.Where(p => p.OrderType == model.OrderType);
                }
                if (!model.Name.IsNullOrEmpty())
                {
                    query.Where(p => p.Name == model.Name);
                }
                if (!model.AddrArea.IsNullOrEmpty())
                {
                    query.Where(p => p.AddrArea == model.AddrArea);
                }
                if (!model.AddrDetail.IsNullOrEmpty())
                {
                    query.Where(p => p.AddrDetail == model.AddrDetail);
                }
                if (!model.IsDelete.IsNullOrEmpty())
                {
                    query.Where(p => p.IsDelete == model.IsDelete);
                }
                if (!model.IsAdmin.IsNullOrEmpty())
                {
                    query.Where(p => p.IsAdmin == model.IsAdmin);
                }
            }
            if (SearchName != null)
            {
                query.Where(p => p.OrderNo.Like(SearchName)|| p.Name.Like(SearchName)|| p.AddrArea.Like(SearchName)|| p.AddrDetail.Like(SearchName));
            }
            if (Key != null)
            {
                query.OrderByKey(Key, desc);
            }
            return query.GetQueryPageList(start, PageSize, null, null);
        }

        /// <summary>
        /// 模糊查找数据条数
        /// </summary>
        /// <param name="Key">主键</param>
        /// <param name="start">开始数据</param>
        /// <param name="PageSize">页面长度</param>
        /// <param name="desc">排序</param>
        /// <param name="model">对象</param>
        /// <param name="connection">连接</param>
        /// <param name="transaction">事务</param>
        /// <returns>对象列表</returns>
        public int SelectByVagueCount(Order_Allinfo model, string SearchName)
        {
            var query = new LambdaQuery<Order_Allinfo>();
            if (model != null)
            {
                if (!model.Id.IsNullOrEmpty())
                {
                    query.Where(p => p.Id == model.Id);
                }
                if (!model.UserId.IsNullOrEmpty())
                {
                    query.Where(p => p.UserId == model.UserId);
                }
                if (!model.AddressId.IsNullOrEmpty())
                {
                    query.Where(p => p.AddressId == model.AddressId);
                }
                if (!model.TotalPrice.IsNullOrEmpty())
                {
                    query.Where(p => p.TotalPrice == model.TotalPrice);
                }
                if (!model.PayType.IsNullOrEmpty())
                {
                    query.Where(p => p.PayType == model.PayType);
                }
                if (!model.Status.IsNullOrEmpty())
                {
                    query.Where(p => p.Status == model.Status);
                }
                if (!model.OrderNo.IsNullOrEmpty())
                {
                    query.Where(p => p.OrderNo == model.OrderNo);
                }
                if (!model.OrderTime.IsNullOrEmpty())
                {
                    query.Where(p => p.OrderTime == model.OrderTime);
                }
                if (!model.OrderType.IsNullOrEmpty())
                {
                    query.Where(p => p.OrderType == model.OrderType);
                }
                if (!model.Name.IsNullOrEmpty())
                {
                    query.Where(p => p.Name == model.Name);
                }
                if (!model.AddrArea.IsNullOrEmpty())
                {
                    query.Where(p => p.AddrArea == model.AddrArea);
                }
                if (!model.AddrDetail.IsNullOrEmpty())
                {
                    query.Where(p => p.AddrDetail == model.AddrDetail);
                }
                if (!model.IsDelete.IsNullOrEmpty())
                {
                    query.Where(p => p.IsDelete == model.IsDelete);
                }
                if (!model.IsAdmin.IsNullOrEmpty())
                {
                    query.Where(p => p.IsAdmin == model.IsAdmin);
                }
            }
            if (SearchName != null)
            {
                query.Where(p => p.OrderNo.Like(SearchName) || p.Name.Like(SearchName) || p.AddrArea.Like(SearchName) || p.AddrDetail.Like(SearchName));
            }
            return query.GetQueryCount();
        }
    }
}
