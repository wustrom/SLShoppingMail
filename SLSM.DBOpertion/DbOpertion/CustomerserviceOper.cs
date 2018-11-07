using Common;
using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common.LambdaOpertion;
using Common.Extend;
using System.Data;
using Common.Extend.LambdaFunction;
using DbOpertion.Models;

namespace DbOpertion.Operation
{
    public partial class CustomerserviceOper : SingleTon<CustomerserviceOper>
    {
        /// <summary>
        /// 根据主键删除数据
        /// </summary>
        /// <param name="KeyId">主键Id</param>
        /// <param name="connection">连接</param>
        /// <param name="transaction">事务</param>
        /// <returns>是否成功</returns>
        public bool DeleteById(int KeyId, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var delete = new LambdaDelete<Customerservice>();
            delete.Where(p => p.Id == KeyId);
            return delete.GetDeleteResult(connection, transaction);
        }

        /// <summary>
        /// 根据模型删除数据
        /// </summary>
        /// <param name="model">模型</param>
        /// <param name="connection">连接</param>
        /// <param name="transaction">事务</param>
        /// <returns>是否成功</returns>
        public bool DeleteModel(Customerservice model = null, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var delete = new LambdaDelete<Customerservice>();
            if (model != null)
            {
                if (!model.Id.IsNullOrEmpty())
                {
                    delete.Where(p => p.Id == model.Id);
                }
                if (!model.ServiceName.IsNullOrEmpty())
                {
                    delete.Where(p => p.ServiceName == model.ServiceName);
                }
                if (!model.ServicePwd.IsNullOrEmpty())
                {
                    delete.Where(p => p.ServicePwd == model.ServicePwd);
                }
                if (!model.IsService.IsNullOrEmpty())
                {
                    delete.Where(p => p.IsService == model.IsService);
                }
                if (!model.ServiceQQ.IsNullOrEmpty())
                {
                    delete.Where(p => p.ServiceQQ == model.ServiceQQ);
                }
                if (!model.ServiceWechat.IsNullOrEmpty())
                {
                    delete.Where(p => p.ServiceWechat == model.ServiceWechat);
                }
                if (!model.ServiceALWW.IsNullOrEmpty())
                {
                    delete.Where(p => p.ServiceALWW == model.ServiceALWW);
                }
                if (!model.ServicePhone.IsNullOrEmpty())
                {
                    delete.Where(p => p.ServicePhone == model.ServicePhone);
                }
            }
            return delete.GetDeleteResult(connection, transaction);
        }

        /// <summary>
        /// 根据模型更新
        /// </summary>
        /// <param name="model">模型</param>
        /// <param name="connection">连接</param>
        /// <param name="transaction">事务</param>
        /// <returns>是否成功</returns>
        public bool Update(Customerservice model, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var update = new LambdaUpdate<Customerservice>();
            if (!model.Id.IsNullOrEmpty())
            {
                update.Where(p => p.Id == model.Id);
            }
            if (!model.ServiceName.IsNullOrEmpty())
            {
                update.Set(p => p.ServiceName == model.ServiceName);
            }
            if (!model.ServicePwd.IsNullOrEmpty())
            {
                update.Set(p => p.ServicePwd == model.ServicePwd);
            }
            if (!model.IsService.IsNullOrEmpty())
            {
                update.Set(p => p.IsService == model.IsService);
            }
            if (!model.ServiceQQ.IsNullOrEmpty())
            {
                update.Set(p => p.ServiceQQ == model.ServiceQQ);
            }
            if (!model.ServiceWechat.IsNullOrEmpty())
            {
                update.Set(p => p.ServiceWechat == model.ServiceWechat);
            }
            if (!model.ServiceALWW.IsNullOrEmpty())
            {
                update.Set(p => p.ServiceALWW == model.ServiceALWW);
            }
            if (!model.ServicePhone.IsNullOrEmpty())
            {
                update.Set(p => p.ServicePhone == model.ServicePhone);
            }
            return update.GetUpdateResult(connection, transaction);
        }

        /// <summary>
        /// 根据模型插入
        /// </summary>
        /// <param name="model">模型</param>
        /// <param name="connection">连接</param>
        /// <param name="transaction">事务</param>
        /// <returns>是否成功</returns>
        public bool Insert(Customerservice model, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var insert = new LambdaInsert<Customerservice>();
            if (!model.ServiceName.IsNullOrEmpty())
            {
                insert.Insert(p => p.ServiceName == model.ServiceName);
            }
            if (!model.ServicePwd.IsNullOrEmpty())
            {
                insert.Insert(p => p.ServicePwd == model.ServicePwd);
            }
            if (!model.IsService.IsNullOrEmpty())
            {
                insert.Insert(p => p.IsService == model.IsService);
            }
            if (!model.ServiceQQ.IsNullOrEmpty())
            {
                insert.Insert(p => p.ServiceQQ == model.ServiceQQ);
            }
            if (!model.ServiceWechat.IsNullOrEmpty())
            {
                insert.Insert(p => p.ServiceWechat == model.ServiceWechat);
            }
            if (!model.ServiceALWW.IsNullOrEmpty())
            {
                insert.Insert(p => p.ServiceALWW == model.ServiceALWW);
            }
            if (!model.ServicePhone.IsNullOrEmpty())
            {
                insert.Insert(p => p.ServicePhone == model.ServicePhone);
            }
            return insert.GetInsertResult(connection, transaction) >= 0;
        }

        /// <summary>
        /// 根据模型插入
        /// </summary>
        /// <param name="model">模型</param>
        /// <param name="connection">连接</param>
        /// <param name="transaction">事务</param>
        /// <returns>是否成功</returns>
        public int InsertReturnKey(Customerservice model, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var insert = new LambdaInsert<Customerservice>();
            if (!model.ServiceName.IsNullOrEmpty())
            {
                insert.Insert(p => p.ServiceName == model.ServiceName);
            }
            if (!model.ServicePwd.IsNullOrEmpty())
            {
                insert.Insert(p => p.ServicePwd == model.ServicePwd);
            }
            if (!model.IsService.IsNullOrEmpty())
            {
                insert.Insert(p => p.IsService == model.IsService);
            }
            if (!model.ServiceQQ.IsNullOrEmpty())
            {
                insert.Insert(p => p.ServiceQQ == model.ServiceQQ);
            }
            if (!model.ServiceWechat.IsNullOrEmpty())
            {
                insert.Insert(p => p.ServiceWechat == model.ServiceWechat);
            }
            if (!model.ServiceALWW.IsNullOrEmpty())
            {
                insert.Insert(p => p.ServiceALWW == model.ServiceALWW);
            }
            if (!model.ServicePhone.IsNullOrEmpty())
            {
                insert.Insert(p => p.ServicePhone == model.ServicePhone);
            }
            return insert.GetInsertResult(connection, transaction);
        }

        /// <summary>
        /// 筛选全部数据
        /// </summary>
        /// <param name="model">模型</param>
        /// <param name="connection">连接</param>
        /// <param name="transaction">事务</param>
        /// <returns>对象列表</returns>
        public List<Customerservice> SelectAll(Customerservice model = null, string SelectFiled = null, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var query = new LambdaQuery<Customerservice>();
            if (model != null)
            {
                if (!model.Id.IsNullOrEmpty())
                {
                    query.Where(p => p.Id == model.Id);
                }
                if (!model.ServiceName.IsNullOrEmpty())
                {
                    query.Where(p => p.ServiceName == model.ServiceName);
                }
                if (!model.ServicePwd.IsNullOrEmpty())
                {
                    query.Where(p => p.ServicePwd == model.ServicePwd);
                }
                if (!model.IsService.IsNullOrEmpty())
                {
                    query.Where(p => p.IsService == model.IsService);
                }
                if (!model.ServiceQQ.IsNullOrEmpty())
                {
                    query.Where(p => p.ServiceQQ == model.ServiceQQ);
                }
                if (!model.ServiceWechat.IsNullOrEmpty())
                {
                    query.Where(p => p.ServiceWechat == model.ServiceWechat);
                }
                if (!model.ServiceALWW.IsNullOrEmpty())
                {
                    query.Where(p => p.ServiceALWW == model.ServiceALWW);
                }
                if (!model.ServicePhone.IsNullOrEmpty())
                {
                    query.Where(p => p.ServicePhone == model.ServicePhone);
                }
            }
            if (SelectFiled != null)
            {
                SelectFiled = SelectFiled.ToLowerInvariant();
                if (SelectFiled.Contains("id,"))
                {
                    query.Select(p => new { p.Id });
                }
                if (SelectFiled.Contains("servicename,"))
                {
                    query.Select(p => new { p.ServiceName });
                }
                if (SelectFiled.Contains("servicepwd,"))
                {
                    query.Select(p => new { p.ServicePwd });
                }
                if (SelectFiled.Contains("isservice,"))
                {
                    query.Select(p => new { p.IsService });
                }
                if (SelectFiled.Contains("serviceqq,"))
                {
                    query.Select(p => new { p.ServiceQQ });
                }
                if (SelectFiled.Contains("servicewechat,"))
                {
                    query.Select(p => new { p.ServiceWechat });
                }
                if (SelectFiled.Contains("servicealww,"))
                {
                    query.Select(p => new { p.ServiceALWW });
                }
                if (SelectFiled.Contains("servicephone,"))
                {
                    query.Select(p => new { p.ServicePhone });
                }
            }
            return query.GetQueryList(connection, transaction);
        }

        /// <summary>
        /// 数据条数
        /// </summary>
        /// <param name="model">模型</param>
        /// <param name="connection">连接</param>
        /// <param name="transaction">事务</param>
        /// <returns>对象列表</returns>
        public int SelectCount(Customerservice model = null, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var query = new LambdaQuery<Customerservice>();
            if (model != null)
            {
                if (!model.Id.IsNullOrEmpty())
                {
                    query.Where(p => p.Id == model.Id);
                }
                if (!model.ServiceName.IsNullOrEmpty())
                {
                    query.Where(p => p.ServiceName == model.ServiceName);
                }
                if (!model.ServicePwd.IsNullOrEmpty())
                {
                    query.Where(p => p.ServicePwd == model.ServicePwd);
                }
                if (!model.IsService.IsNullOrEmpty())
                {
                    query.Where(p => p.IsService == model.IsService);
                }
                if (!model.ServiceQQ.IsNullOrEmpty())
                {
                    query.Where(p => p.ServiceQQ == model.ServiceQQ);
                }
                if (!model.ServiceWechat.IsNullOrEmpty())
                {
                    query.Where(p => p.ServiceWechat == model.ServiceWechat);
                }
                if (!model.ServiceALWW.IsNullOrEmpty())
                {
                    query.Where(p => p.ServiceALWW == model.ServiceALWW);
                }
                if (!model.ServicePhone.IsNullOrEmpty())
                {
                    query.Where(p => p.ServicePhone == model.ServicePhone);
                }
            }
            return query.GetQueryCount(connection, transaction);
        }

        /// <summary>
        /// 根据主键筛选数据
        /// </summary>
        /// <param name="KeyId">主键Id</param>
        /// <param name="connection">连接</param>
        /// <param name="transaction">事务</param>
        /// <returns>是否成功</returns>
        public Customerservice SelectById(int KeyId, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var query = new LambdaQuery<Customerservice>();
            query.Where(p => p.Id == KeyId);
            return query.GetQueryList(connection, transaction).FirstOrDefault();
        }


        /// <summary>
        /// 根据主键筛选数据
        /// </summary>
        /// <param name="KeyId">主键Id</param>
        /// <param name="connection">连接</param>
        /// <param name="transaction">事务</param>
        /// <returns>是否成功</returns>
        public List<Customerservice> SelectByKeys(string Key,List<string> KeyIds, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var query = new LambdaQuery<Customerservice>();
            if("id" == Key.ToLowerInvariant())
            {
                query.Where(p => p.Id.In(KeyIds));
            }
            if("servicename" == Key.ToLowerInvariant())
            {
                query.Where(p => p.ServiceName.In(KeyIds));
            }
            if("servicepwd" == Key.ToLowerInvariant())
            {
                query.Where(p => p.ServicePwd.In(KeyIds));
            }
            if("isservice" == Key.ToLowerInvariant())
            {
                query.Where(p => p.IsService.In(KeyIds));
            }
            if("serviceqq" == Key.ToLowerInvariant())
            {
                query.Where(p => p.ServiceQQ.In(KeyIds));
            }
            if("servicewechat" == Key.ToLowerInvariant())
            {
                query.Where(p => p.ServiceWechat.In(KeyIds));
            }
            if("servicealww" == Key.ToLowerInvariant())
            {
                query.Where(p => p.ServiceALWW.In(KeyIds));
            }
            if("servicephone" == Key.ToLowerInvariant())
            {
                query.Where(p => p.ServicePhone.In(KeyIds));
            }
            return query.GetQueryList(connection, transaction);
        }

        /// <summary>
        /// 根据分页筛选数据
        /// </summary>
        /// <param name="Key">主键</param>
        /// <param name="start">开始数据</param>
        /// <param name="PageSize">页面长度</param>
        /// <param name="desc">排序</param>
        /// <param name="model">对象</param>
        /// <param name="connection">连接</param>
        /// <param name="transaction">事务</param>
        /// <returns>对象列表</returns>
        public List<Customerservice> SelectByPage(string Key, int start, int PageSize, bool desc = true,Customerservice model = null, string SelectFiled = null, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var query = new LambdaQuery<Customerservice>();
            if (model != null)
            {
                if (!model.Id.IsNullOrEmpty())
                {
                    query.Where(p => p.Id == model.Id);
                }
                if (!model.ServiceName.IsNullOrEmpty())
                {
                    query.Where(p => p.ServiceName == model.ServiceName);
                }
                if (!model.ServicePwd.IsNullOrEmpty())
                {
                    query.Where(p => p.ServicePwd == model.ServicePwd);
                }
                if (!model.IsService.IsNullOrEmpty())
                {
                    query.Where(p => p.IsService == model.IsService);
                }
                if (!model.ServiceQQ.IsNullOrEmpty())
                {
                    query.Where(p => p.ServiceQQ == model.ServiceQQ);
                }
                if (!model.ServiceWechat.IsNullOrEmpty())
                {
                    query.Where(p => p.ServiceWechat == model.ServiceWechat);
                }
                if (!model.ServiceALWW.IsNullOrEmpty())
                {
                    query.Where(p => p.ServiceALWW == model.ServiceALWW);
                }
                if (!model.ServicePhone.IsNullOrEmpty())
                {
                    query.Where(p => p.ServicePhone == model.ServicePhone);
                }
            }
            if (SelectFiled != null)
            {
                SelectFiled = SelectFiled.ToLowerInvariant();
                if (SelectFiled.Contains("id,"))
                {
                    query.Select(p => new { p.Id });
                }
                if (SelectFiled.Contains("servicename,"))
                {
                    query.Select(p => new { p.ServiceName });
                }
                if (SelectFiled.Contains("servicepwd,"))
                {
                    query.Select(p => new { p.ServicePwd });
                }
                if (SelectFiled.Contains("isservice,"))
                {
                    query.Select(p => new { p.IsService });
                }
                if (SelectFiled.Contains("serviceqq,"))
                {
                    query.Select(p => new { p.ServiceQQ });
                }
                if (SelectFiled.Contains("servicewechat,"))
                {
                    query.Select(p => new { p.ServiceWechat });
                }
                if (SelectFiled.Contains("servicealww,"))
                {
                    query.Select(p => new { p.ServiceALWW });
                }
                if (SelectFiled.Contains("servicephone,"))
                {
                    query.Select(p => new { p.ServicePhone });
                }
            }
            if (Key != null)
            {
                query.OrderByKey(Key, desc);
            }
            return query.GetQueryPageList(start, PageSize, connection, transaction);
        }
    }
}
