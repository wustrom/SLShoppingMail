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
    public partial class Order_InfoOper : SingleTon<Order_InfoOper>
    {
        /// <summary>
        /// 订单确定支付
        /// </summary>
        /// <param name="OrderNo">订单号码</param>
        /// <returns>是否成功</returns>
        public bool OrderSurePay(string OrderNo)
        {
            var update = new LambdaUpdate<Order_Info>();
            update.Where(p => p.OrderNo == OrderNo);
            update.Set(p => p.Status == 3);
            update.Set(p => p.PayType == 2);
            return update.GetUpdateResult();
        }
    }
}
