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
    public partial class Order_DetailOper : SingleTon<Order_DetailOper>
    {
        /// <summary>
        /// 筛选全部数据
        /// </summary>
        /// <param name="model">模型</param>
        /// <param name="connection">连接</param>
        /// <param name="transaction">事务</param>
        /// <returns>对象列表</returns>
        public List<Order_Detail_View> SelectByOrderCommodity(List<string> ListOrderIds, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var query = new LambdaQuery<Order_Detail_View>();
            if (ListOrderIds.Count != 0)
            {
                query.Where(p => p.OrderId.In(ListOrderIds));
                return query.GetQueryList(connection, transaction);
            }
            else
            {
                return new List<Order_Detail_View>();
            }

        }
    }
}
