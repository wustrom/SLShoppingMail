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
    public partial class Commodity_Stage_PriceOper : SingleTon<Commodity_Stage_PriceOper>
    {

        /// <summary>
        /// 筛选数据根据Id
        /// </summary>
        /// <param name="model">模型</param>
        /// <param name="connection">连接</param>
        /// <param name="transaction">事务</param>
        /// <returns>对象列表</returns>
        public List<Commodity_Stage_Price> SelectByIds(List<string> list)
        {
            var query = new LambdaQuery<Commodity_Stage_Price>();
            query.Where(p => p.CommodityId.In(list));
            return query.GetQueryList();
        }
    }
}
