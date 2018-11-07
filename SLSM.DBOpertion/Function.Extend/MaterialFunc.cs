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
    public partial class MaterialFunc : SingleTon<MaterialFunc>
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
        public Tuple<List<Raw_Materials>, int> GetLikePage(int PageIndex, int PageSize, string Order, string sort, string Name, List<string> MetailsID)
        {
            return new Tuple<List<Raw_Materials>, int>(item1: Raw_MaterialsOper.Instance.SelectLikePage(sort, (PageIndex - 1) * PageSize, PageSize, Order == "desc" ? true : false, Name, MetailsID),
                                                       item2: Raw_MaterialsOper.Instance.SelectLikeCount(Name, MetailsID));
        }
    }
}
