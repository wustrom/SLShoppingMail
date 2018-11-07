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

namespace DbOpertion.Operation
{
    public partial class ServiceOper : SingleTon<ServiceOper>
    {
        /// <summary>
        /// 筛选全部数据不是这个用户
        /// </summary>
        /// <param name="model">模型</param>
        /// <param name="connection">连接</param>
        /// <param name="transaction">事务</param>
        /// <returns>对象列表</returns>
        public List<Customerservice> SelectAllNotThisService(Customerservice model = null, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var query = new LambdaQuery<Customerservice>();
            if (model != null)
            {
                if (!model.Id.IsNullOrEmpty())
                {
                    query.Where(p => p.Id != model.Id);
                }
               
                if (!model.ServiceName.IsNullOrEmpty())
                {
                    query.Where(p => p.ServiceName == model.ServiceName);
                }               
                if (!model.IsService.IsNullOrEmpty())
                {
                    query.Where(p => p.IsService == model.IsService);
                }
            }
            return query.GetQueryList(connection, transaction);
        }

    }
}
