using Common;
using Common.Helper;
using Common.LambdaOpertion;
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
    public partial class ErpuserFunc : SingleTon<ErpuserFunc>
    {
        public bool Insert(string ErproleName)
        {
            return ErpuserOper.Instance.Insert(new Erpuser { ErproleName = ErproleName });
        }

        public bool UpdateErpUserInfo(int ErproleId, string ERProlePowers)
        {
            var MysqlHelper = SqlHelper.GetMySqlHelper("transaction");
            var connection = MysqlHelper.CreatConn();
            var transaction = MysqlHelper.GetTransaction();
            try
            {
                #region 
                if (UpdateErpUser(ErproleId, ERProlePowers, connection, transaction))
                {
                    transaction.Commit();
                    connection.Close();
                    return true;
                }
                else
                {
                    transaction.Rollback();
                    connection.Close();
                }
                #endregion
            }
            catch (Exception e)
            {
                transaction.Rollback();
                connection.Close();
            }
            return false;
        }
        private bool UpdateErpUser(int ErproleId, string ERProlePowers, IDbConnection connection, IDbTransaction transaction)
        {
            //先清空再添加
            if (!ErpuserOper.Instance.Update(new Erpuser { ErproleId = ErproleId, ERProlePower = " " }, connection, transaction))
            {
                return false;
            }
            if (!ErpuserOper.Instance.Update(new Erpuser { ErproleId = ErproleId, ERProlePower = ERProlePowers },connection,transaction))
            {
                return false;
            }
            return true;

        }
    }
}
