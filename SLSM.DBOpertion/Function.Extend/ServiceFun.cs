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
  public partial class ServiceFun : SingleTon<ServiceFun>
    {
        /// <summary>
        /// 筛选客服人员
        /// </summary>
        /// <param name="Start"></param>
        /// <param name="PageSize"></param>
        /// <param name="IsService"></param>
        /// <returns></returns>
        public List<Customerservice> SelectService(int Start, int PageSize, bool? IsService)
        {
            var ServiceList = CustomerserviceOper.Instance.SelectByPage("IsService", Start, PageSize, false, new Customerservice { IsService = IsService });
            return ServiceList;
        }
    }
}
