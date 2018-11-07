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
using Common.Helper;
using Common.Helper.SqlOpertion;
using Common.Extend.LambdaFunction;

namespace DbOpertion.Operation
{
    public partial class GradeOper : SingleTon<GradeOper>
    {
        /// <summary>
        /// 将这些id的isdelete设为true
        /// </summary>
        /// <param name="model">模型</param>
        /// <param name="connection">连接</param>
        /// <param name="transaction">事务</param>
        /// <returns>是否成功</returns>
        public bool DeleteByIds(List<string> ids, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var update = new LambdaUpdate<Grade>();

            update.Where(p => p.Id.In(ids));
            update.Set(p => p.Image == "");
            update.Set(p => p.IsDelete == true);
            return update.GetUpdateResult(connection, transaction);
        }


   
    }
}
