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
    public partial class ProducerInvoiceOper : SingleTon<ProducerInvoiceOper>
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
        public List<Producer_Invoice_View> SelectInvoicePage(string Key, int start, int PageSize, bool desc, string Name, string ProduterId)
        {
            var query = new LambdaQuery<Producer_Invoice_View>();
            if (ProduterId != null && ProduterId != "0")
            {
                query.Where(p => p.ProducerId.Like(ProduterId));
            }
            if (!Name.IsNullOrEmpty())
            {
                query.Where(p => p.Id.Like(Name) || p.Name.Like(Name) || p.Address.Like(Name) || p.InvoiceNumber.Like(Name) /*|| p.Phone.Like(Name)*/ || p.AccountPeriod.Like(Name) || p.Bank.Like(Name) || p.InvoiceMoney.Like(Name));
            }
            if (Key != null)
            {
                query.OrderByKey(Key, desc);
            }
            else
            {
                query.OrderByKey("InvoiceTime", true);
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
        public int SelectInvoiceCount(string Name, string ProduterId)
        {
            var query = new LambdaQuery<Producer_Invoice_View>();

            if (ProduterId != null && ProduterId != "0")
            {
                query.Where(p => p.ProducerId.Like(ProduterId));
            }

            if (!Name.IsNullOrEmpty())
            {
                query.Where(p => p.Id.Like(Name) || p.Name.Like(Name) || p.Address.Like(Name) || p.InvoiceNumber.Like(Name) /*|| p.Phone.Like(Name)*/ || p.AccountPeriod.Like(Name) || p.Bank.Like(Name) || p.InvoiceMoney.Like(Name));
            }
            return query.GetQueryCount();
        }
    }
}
