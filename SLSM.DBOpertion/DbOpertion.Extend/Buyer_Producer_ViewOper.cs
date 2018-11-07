using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using Common.LambdaOpertion;
using Common.Extend;
using System.Data;
using DbOpertion.Models;
using Common.Extend.LambdaFunction;
using System.Text.RegularExpressions;

namespace DbOpertion.Operation
{
    public partial class Buyer_Producer_ViewOper : SingleTon<Buyer_Producer_ViewOper>
    {

        #region 采购单
        /// <summary>
        /// 模糊分页查询
        /// </summary>
        /// <param name="Key">排序方式</param>
        /// <param name="start">开始条数</param>
        /// <param name="PageSize">页面长度</param>
        /// <param name="desc">降序</param>
        /// <param name="Name">名称</param>
        /// <returns></returns>
        public List<Buyer_Producer_View> SelectAllBuyerPage(string Key, int start, int PageSize, bool desc, string Name, string ProduterId, DateTime StartTime, DateTime EndTime, string CheckStatus)
        {
            var query = new LambdaQuery<Buyer_Producer_View>();
            query.Where(p => p.ParentId == 0);
            if (CheckStatus != null)
            {
                var List_CheckStatus = CheckStatus.Split('|').Where(p => !string.IsNullOrEmpty(p)).ToList();
                query.Where(p => p.buyerStatus.In(List_CheckStatus));
            }
            if (ProduterId != null && ProduterId != "0")
            {
                query.Where(p => p.producerId.Like(ProduterId));
            }
            if (StartTime != DateTime.MinValue)
            {
                query.Where(p => p.buyerTime >= StartTime);
            }
            if (EndTime != DateTime.MinValue)
            {
                query.Where(p => p.buyerTime <= EndTime);
            }
            if (StartTime != DateTime.MinValue && EndTime != DateTime.MinValue)
            {
                query.Where(p => p.buyerTime >= StartTime && p.buyerTime <= EndTime);
            }
            if (Key != null)
            {
                query.OrderByKey(Key, desc);
            }
            else
            {
                query.OrderByKey("Id", true);
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
        public int SelectAllBuyerCount(string Name, string ProduterId, DateTime StartTime, DateTime EndTime, string CheckStatus)
        {
            var query = new LambdaQuery<Buyer_Producer_View>();
            query.Where(p => p.ParentId == 0);
            if (CheckStatus != null)
            {
                var List_CheckStatus = CheckStatus.Split('|').Where(p => !string.IsNullOrEmpty(p)).ToList();
                query.Where(p => p.buyerStatus.In(List_CheckStatus));
            }
            if (ProduterId != null && ProduterId != "0")
            {
                query.Where(p => p.producerId.Like(ProduterId));
            }
            if (StartTime != DateTime.MinValue)
            {
                query.Where(p => p.buyerTime >= StartTime);
            }
            if (EndTime != DateTime.MinValue)
            {
                query.Where(p => p.buyerTime <= EndTime);
            }
            if (StartTime != DateTime.MinValue && EndTime != DateTime.MinValue)
            {
                query.Where(p => p.buyerTime >= StartTime && p.buyerTime <= EndTime);
            }

            return query.GetQueryCount();
        }

        #endregion

        #region 采购入库
        /// <summary>
        /// 模糊分页查询
        /// </summary>
        /// <param name="Key">排序方式</param>
        /// <param name="start">开始条数</param>
        /// <param name="PageSize">页面长度</param>
        /// <param name="desc">降序</param>
        /// <param name="Name">名称</param>
        /// <returns></returns>
        public List<Buyer_Producer_View> SelectBuyerPage(string Key, int start, int PageSize, bool desc, string Name)
        {
            var query = new LambdaQuery<Buyer_Producer_View>();

            var SelectStatus = query.Where(p => p.buyerStatus == "待入库" || p.buyerStatus == "已入库");
            if (SelectStatus != null)
            {
                if (!Name.IsNullOrEmpty())
                {
                    SelectStatus.Where(p => p.Id.Like(Name) || p.Name.Like(Name) || p.buyerStatus.Like(Name) || p.checkStatus.Like(Name) || p.BuyerNo.Like(Name));
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
        public int SelectBuyerCount(string Name)
        {
            var query = new LambdaQuery<Buyer_Producer_View>();
            var SelectStatus = query.Where(p => p.buyerStatus == "待入库" || p.buyerStatus == "已入库");
            if (SelectStatus != null)
            {
                if (!Name.IsNullOrEmpty())
                {
                    SelectStatus.Where(p => p.Id.Like(Name) || p.Name.Like(Name) || p.buyerStatus.Like(Name) || p.checkStatus.Like(Name) || p.BuyerNo.Like(Name));
                }
            }
            return query.GetQueryCount();
        }
        #endregion


        #region 财务管理
        /// <summary>
        /// 模糊分页查询
        /// </summary>
        /// <param name="Key">排序方式</param>
        /// <param name="start">开始条数</param>
        /// <param name="PageSize">页面长度</param>
        /// <param name="desc">降序</param>
        /// <param name="Name">名称</param>
        /// <returns></returns>
        public List<Buyer_Producer_View> SelectFinancePage(string Key, int start, int PageSize, bool desc, string Name, string ProduterId, DateTime StartTime, DateTime EndTime)
        {
            var query = new LambdaQuery<Buyer_Producer_View>();
            query.Where(p => p.ParentId == 0);
            query.Where(p => (p.buyerStatus == "已入库" || p.buyerStatus == "待送货品检" || p.buyerStatus == "待入库"));
            if (ProduterId != null && ProduterId != "0")
            {
                query.Where(p => p.producerId.Like(ProduterId));
            }
            if (StartTime != DateTime.MinValue)
            {
                query.Where(p => p.buyerTime >= StartTime);
            }
            if (EndTime != DateTime.MinValue)
            {
                query.Where(p => p.buyerTime <= EndTime);
            }
            if (StartTime != DateTime.MinValue && EndTime != DateTime.MinValue)
            {
                query.Where(p => p.buyerTime >= StartTime && p.buyerTime <= EndTime);
            }
            if (!Name.IsNullOrEmpty())
            {
                query.Where(p => p.Id.Like(Name) || p.Name.Like(Name) || p.AccountPeriod.Like(Name) || p.buyerMoney.Like(Name) || p.wantmoney.Like(Name));
            }
            if (Key != null)
            {
                query.OrderByKey(Key, desc);
            }
            else
            {
                query.OrderByKey("Id", true);
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
        public int SelectFinanceCount(string Name, string ProduterId, DateTime StartTime, DateTime EndTime)
        {
            var query = new LambdaQuery<Buyer_Producer_View>();
            query.Where(p => p.ParentId == 0);
            query.Where(p => (p.buyerStatus == "已入库" || p.buyerStatus == "待送货品检" || p.buyerStatus == "待入库"));
            if (ProduterId != null && ProduterId != "0")
            {
                query.Where(p => p.producerId.Like(ProduterId));
            }
            if (StartTime != DateTime.MinValue)
            {
                query.Where(p => p.buyerTime >= StartTime);
            }
            if (EndTime != DateTime.MinValue)
            {
                query.Where(p => p.buyerTime <= EndTime);
            }
            if (StartTime != DateTime.MinValue && EndTime != DateTime.MinValue)
            {
                query.Where(p => p.buyerTime >= StartTime && p.buyerTime <= EndTime);
            }
            if (!Name.IsNullOrEmpty())
            {
                query.Where(p => p.Id.Like(Name) || p.Name.Like(Name) || p.AccountPeriod.Like(Name) || p.buyerMoney.Like(Name) || p.wantmoney.Like(Name));
            }
            return query.GetQueryCount();
        }
        #endregion
    }
}
