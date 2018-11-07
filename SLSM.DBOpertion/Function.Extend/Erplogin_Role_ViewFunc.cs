using Common;
using Common.Helper;
using DbOpertion.Models;
using DbOpertion.Operation;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbOpertion.Function
{
    public partial class Erplogin_Role_ViewFunc : SingleTon<Erplogin_Role_ViewFunc>
    {
        /// <summary>
        /// 分页筛选未删除库存
        /// </summary>
        /// <returns></returns>
        public Tuple<List<Erplogin_Role_View>, int> SelectloginUser(int PageIndex, int PageSize, string Order, string sort, string Name)
        {
            return new Tuple<List<Erplogin_Role_View>, int>(item1: Erplogin_Role_ViewOper.Instance.SelectLoginUserPage(sort, (PageIndex - 1) * PageSize, PageSize, Order == "desc" ? true : false,Name),item2:Erplogin_Role_ViewOper.Instance.SelectLoginUserCount(Name));
        }
    }
}
