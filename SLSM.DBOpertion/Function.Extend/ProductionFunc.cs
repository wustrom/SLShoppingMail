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
    public partial class ProductionFunc : SingleTon<ProductionFunc>
    {
        /// <summary>
        /// 查询生产管理
        /// </summary>
        /// <returns></returns>
        public Tuple<List<Production_Orderdetail_View>, int> GetProductionPage(int PageIndex, int PageSize, string Order, string sort, string Name, string Production, string Status)
        {
            return new Tuple<List<Production_Orderdetail_View>, int>(item1: Production_Orderdetail_ViewOper.Instance.SelectProductionPage(sort, (PageIndex - 1) * PageSize, PageSize, Order == "desc" ? true : false, Name, Production, Status), item2: Production_Orderdetail_ViewOper.Instance.SelectProductionCount(Name, Production, Status));
        }
        /// <summary>
        /// 查询单条记录
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public Production_Orderdetail_View SelectViewById(int Id)
        {
            return Production_Orderdetail_ViewOper.Instance.SelectAll(new Production_Orderdetail_View { Id = Id }).FirstOrDefault();
        }
    }
}
