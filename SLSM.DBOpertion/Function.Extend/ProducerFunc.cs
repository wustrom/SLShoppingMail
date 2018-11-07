using Common;
using DbOpertion.Models;
using DbOpertion.Operation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbOpertion.Function
{
    public partial class ProducerFunc : SingleTon<ProducerFunc>
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
        public Tuple<List<Producer>, int> GetProducerPage(int PageIndex, int PageSize, string Order, string sort, string Name)
        {
            return new Tuple<List<Producer>, int>(item1: ProducerOper.Instance.SelectProducerPage(sort, (PageIndex - 1) * PageSize, PageSize, Order == "desc" ? true : false, Name),item2: ProducerOper.Instance.SelectProducerCount(Name));
        }
        /// <summary>
        /// 查询全部
        /// </summary>
        /// <returns></returns>
        public List<Producer> SelectAll()
        {
            return ProducerOper.Instance.SelectAll(new Producer { IsDelete=false});
        }
        /// <summary>
        /// 应付账款
        /// </summary>
        /// <returns></returns>
        public List<Buyer_Producer_View> SelectNoMoney()
        {
            return Buyer_Producer_ViewOper.Instance.SelectAll(new Buyer_Producer_View {buyerStatus="已入库" });

        }
        /// <summary>
        /// 供应商发票
        /// </summary>
        /// <param name="PageIndex"></param>
        /// <param name="PageSize"></param>
        /// <param name="Order"></param>
        /// <param name="sort"></param>
        /// <param name="Name"></param>
        /// <returns></returns>
        public Tuple<List<Producer_Invoice_View>, int> GetInvoicePage(int PageIndex, int PageSize, string Order, string sort, string Name,string ProduterId)
        {
            return new Tuple<List<Producer_Invoice_View>, int>(item1: ProducerInvoiceOper.Instance.SelectInvoicePage(sort, (PageIndex - 1) * PageSize, PageSize, Order == "desc" ? true : false, Name, ProduterId),item2: ProducerInvoiceOper.Instance.SelectInvoiceCount(Name, ProduterId));
        }
        public Producer_Invoice_View SelectinvoiceById(int Id)
        {
            return Producer_Invoice_ViewOper.Instance.SelectById(Id);
        }
    }
}
