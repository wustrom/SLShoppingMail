using Common;
using DbOpertion.Models;
using DbOpertion.Operation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLSM.DBOpertion.Function
{
    public class InspectionFunc : SingleTon<InspectionFunc>
    {
        /// <summary>
        /// 分页筛选
        /// </summary>
        /// <returns></returns>
        public Tuple<List<Buyer_Producer_View>, int> SelectInspection(int PageIndex, int PageSize, string Order, string sort, string Name,string Inspection)
        {
            return new Tuple<List<Buyer_Producer_View>, int>(item1: InspectionOper.Instance.SelectInspectionPage(sort, (PageIndex - 1) * PageSize, PageSize, Order == "desc" ? true : false, Name, Inspection),
                                                       item2: InspectionOper.Instance.SelectInspectionCount(Name, Inspection));
        }
    }
}
