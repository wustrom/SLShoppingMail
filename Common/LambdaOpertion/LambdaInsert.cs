using Common.Extend;
using Common.Helper.SqlOpertion;
using Common.LambdaOpertion.Base;
using MySql.Data.MySqlClient;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Linq.Expressions;
using System.Text;


namespace Common.LambdaOpertion
{
    /// <summary>
    /// Lambda查询
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class LambdaInsert<T> : LambdaBase<T> where T : class, new()
    {
        public LambdaInsert() : base()
        {

        }

        public LambdaInsert(SqlOpertionHelper helper) : base(helper)
        {

        }

        private List<string> InsertCondition = new List<string>();

        public LambdaInsert<T> Insert(Expression<Func<T, bool>> expression)
        {
            if (expression == null)
                return this;
            string condition = FormatSetExpression(expression);
            InsertCondition.Add(condition);
            return this;
        }

        private string GetInsertSql()
        {
            string tableName = typeof(T).Name;
            StringBuilder InsertBulider = new StringBuilder();
            StringBuilder ValuesBulider = new StringBuilder();
            #region Insert条件
            if (InsertCondition.Count > 0)
            {
                foreach (var condition in InsertCondition)
                {
                    var ConditionArray = condition.Split(',');
                    foreach (var item in ConditionArray)
                    {
                        var array = item.Split('=');
                        InsertBulider.Append(array[0]).Append(",");
                        ValuesBulider.Append(array[1]).Append(",");
                    }
                }
                InsertBulider.Remove(InsertBulider.Length - 1, 1);
                ValuesBulider.Remove(ValuesBulider.Length - 1, 1);
            }
            else
            {
                return null;
            }
            #endregion
            var sql = string.Format("Insert into {0} ({1}) values ({2});", tableName, InsertBulider.ToString(), ValuesBulider.ToString());
            return sql;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="transaction"></param>
        /// <returns>返回值为-1则执行失败，返回值为0是执行成功 返回值大于0为插入Id</returns>
        public int GetInsertResult(IDbConnection connection = null, IDbTransaction transaction = null)
        {
            string Sql = GetInsertSql();
            int? Count = 0;
            if (Sql != null)
            {
                if (transaction == null || connection == null)
                {
                    var Conntype = SqlHelper.GetConnType();
                    if (Conntype == Helper.DateBaseType.SQLSERVER || Conntype == Helper.DateBaseType.MYSQL)
                    {
                        Sql += " select @@identity";
                        Count = SqlHelper.ExecuteReader(Sql, List_SqlParameter.ToArray()).Rows[0][0].ParseInt();
                        Count = Count == null ? -1 : Count.Value;
                    }
                    else
                    {
                        Count = SqlHelper.ExecuteNonQuery(Sql, List_SqlParameter.ToArray());
                        Count = Count > 0 ? 0 : -1;
                    }

                }
                else
                {
                    if (connection is SqlConnection || connection is MySqlConnection)
                    {
                        Sql += " select @@identity";
                        Count = SqlHelper.ExecuteReader(Sql, List_SqlParameter.ToArray(), connection, transaction).Rows[0][0].ParseInt();
                        Count = Count == null ? -1 : Count.Value;
                    }
                    else
                    {
                        Count = SqlHelper.ExecuteNonQuery(Sql, List_SqlParameter.ToArray(), connection, transaction);
                        Count = Count > 0 ? 0 : -1;
                    }

                }
            }
            return Count.Value;
        }

    }
}
