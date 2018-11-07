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
    public partial class ProducerconectinfoOper : SingleTon<ProducerconectinfoOper>
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
            var delete = new LambdaDelete<Producerconectinfo>();
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
        public bool DeleteModel(Producerconectinfo model = null, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var delete = new LambdaDelete<Producerconectinfo>();
            if (model != null)
            {
                if (!model.Id.IsNullOrEmpty())
                {
                    delete.Where(p => p.Id == model.Id);
                }
                if (!model.ConectName.IsNullOrEmpty())
                {
                    delete.Where(p => p.ConectName == model.ConectName);
                }
                if (!model.Position.IsNullOrEmpty())
                {
                    delete.Where(p => p.Position == model.Position);
                }
                if (!model.ConectSex.IsNullOrEmpty())
                {
                    delete.Where(p => p.ConectSex == model.ConectSex);
                }
                if (!model.Telephone.IsNullOrEmpty())
                {
                    delete.Where(p => p.Telephone == model.Telephone);
                }
                if (!model.Phone.IsNullOrEmpty())
                {
                    delete.Where(p => p.Phone == model.Phone);
                }
                if (!model.Email.IsNullOrEmpty())
                {
                    delete.Where(p => p.Email == model.Email);
                }
                if (!model.ProducerId.IsNullOrEmpty())
                {
                    delete.Where(p => p.ProducerId == model.ProducerId);
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
        public bool Update(Producerconectinfo model, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var update = new LambdaUpdate<Producerconectinfo>();
            if (!model.Id.IsNullOrEmpty())
            {
                update.Where(p => p.Id == model.Id);
            }
            if (!model.ConectName.IsNullOrEmpty())
            {
                update.Set(p => p.ConectName == model.ConectName);
            }
            if (!model.Position.IsNullOrEmpty())
            {
                update.Set(p => p.Position == model.Position);
            }
            if (!model.ConectSex.IsNullOrEmpty())
            {
                update.Set(p => p.ConectSex == model.ConectSex);
            }
            if (!model.Telephone.IsNullOrEmpty())
            {
                update.Set(p => p.Telephone == model.Telephone);
            }
            if (!model.Phone.IsNullOrEmpty())
            {
                update.Set(p => p.Phone == model.Phone);
            }
            if (!model.Email.IsNullOrEmpty())
            {
                update.Set(p => p.Email == model.Email);
            }
            if (!model.ProducerId.IsNullOrEmpty())
            {
                update.Set(p => p.ProducerId == model.ProducerId);
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
        public bool Insert(Producerconectinfo model, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var insert = new LambdaInsert<Producerconectinfo>();
            if (!model.ConectName.IsNullOrEmpty())
            {
                insert.Insert(p => p.ConectName == model.ConectName);
            }
            if (!model.Position.IsNullOrEmpty())
            {
                insert.Insert(p => p.Position == model.Position);
            }
            if (!model.ConectSex.IsNullOrEmpty())
            {
                insert.Insert(p => p.ConectSex == model.ConectSex);
            }
            if (!model.Telephone.IsNullOrEmpty())
            {
                insert.Insert(p => p.Telephone == model.Telephone);
            }
            if (!model.Phone.IsNullOrEmpty())
            {
                insert.Insert(p => p.Phone == model.Phone);
            }
            if (!model.Email.IsNullOrEmpty())
            {
                insert.Insert(p => p.Email == model.Email);
            }
            if (!model.ProducerId.IsNullOrEmpty())
            {
                insert.Insert(p => p.ProducerId == model.ProducerId);
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
        public int InsertReturnKey(Producerconectinfo model, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var insert = new LambdaInsert<Producerconectinfo>();
            if (!model.ConectName.IsNullOrEmpty())
            {
                insert.Insert(p => p.ConectName == model.ConectName);
            }
            if (!model.Position.IsNullOrEmpty())
            {
                insert.Insert(p => p.Position == model.Position);
            }
            if (!model.ConectSex.IsNullOrEmpty())
            {
                insert.Insert(p => p.ConectSex == model.ConectSex);
            }
            if (!model.Telephone.IsNullOrEmpty())
            {
                insert.Insert(p => p.Telephone == model.Telephone);
            }
            if (!model.Phone.IsNullOrEmpty())
            {
                insert.Insert(p => p.Phone == model.Phone);
            }
            if (!model.Email.IsNullOrEmpty())
            {
                insert.Insert(p => p.Email == model.Email);
            }
            if (!model.ProducerId.IsNullOrEmpty())
            {
                insert.Insert(p => p.ProducerId == model.ProducerId);
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
        public List<Producerconectinfo> SelectAll(Producerconectinfo model = null, string SelectFiled = null, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var query = new LambdaQuery<Producerconectinfo>();
            if (model != null)
            {
                if (!model.Id.IsNullOrEmpty())
                {
                    query.Where(p => p.Id == model.Id);
                }
                if (!model.ConectName.IsNullOrEmpty())
                {
                    query.Where(p => p.ConectName == model.ConectName);
                }
                if (!model.Position.IsNullOrEmpty())
                {
                    query.Where(p => p.Position == model.Position);
                }
                if (!model.ConectSex.IsNullOrEmpty())
                {
                    query.Where(p => p.ConectSex == model.ConectSex);
                }
                if (!model.Telephone.IsNullOrEmpty())
                {
                    query.Where(p => p.Telephone == model.Telephone);
                }
                if (!model.Phone.IsNullOrEmpty())
                {
                    query.Where(p => p.Phone == model.Phone);
                }
                if (!model.Email.IsNullOrEmpty())
                {
                    query.Where(p => p.Email == model.Email);
                }
                if (!model.ProducerId.IsNullOrEmpty())
                {
                    query.Where(p => p.ProducerId == model.ProducerId);
                }
            }
            if (SelectFiled != null)
            {
                SelectFiled = SelectFiled.ToLowerInvariant();
                if (SelectFiled.Contains("id,"))
                {
                    query.Select(p => new { p.Id });
                }
                if (SelectFiled.Contains("conectname,"))
                {
                    query.Select(p => new { p.ConectName });
                }
                if (SelectFiled.Contains("position,"))
                {
                    query.Select(p => new { p.Position });
                }
                if (SelectFiled.Contains("conectsex,"))
                {
                    query.Select(p => new { p.ConectSex });
                }
                if (SelectFiled.Contains("telephone,"))
                {
                    query.Select(p => new { p.Telephone });
                }
                if (SelectFiled.Contains("phone,"))
                {
                    query.Select(p => new { p.Phone });
                }
                if (SelectFiled.Contains("email,"))
                {
                    query.Select(p => new { p.Email });
                }
                if (SelectFiled.Contains("producerid,"))
                {
                    query.Select(p => new { p.ProducerId });
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
        public int SelectCount(Producerconectinfo model = null, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var query = new LambdaQuery<Producerconectinfo>();
            if (model != null)
            {
                if (!model.Id.IsNullOrEmpty())
                {
                    query.Where(p => p.Id == model.Id);
                }
                if (!model.ConectName.IsNullOrEmpty())
                {
                    query.Where(p => p.ConectName == model.ConectName);
                }
                if (!model.Position.IsNullOrEmpty())
                {
                    query.Where(p => p.Position == model.Position);
                }
                if (!model.ConectSex.IsNullOrEmpty())
                {
                    query.Where(p => p.ConectSex == model.ConectSex);
                }
                if (!model.Telephone.IsNullOrEmpty())
                {
                    query.Where(p => p.Telephone == model.Telephone);
                }
                if (!model.Phone.IsNullOrEmpty())
                {
                    query.Where(p => p.Phone == model.Phone);
                }
                if (!model.Email.IsNullOrEmpty())
                {
                    query.Where(p => p.Email == model.Email);
                }
                if (!model.ProducerId.IsNullOrEmpty())
                {
                    query.Where(p => p.ProducerId == model.ProducerId);
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
        public Producerconectinfo SelectById(int KeyId, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var query = new LambdaQuery<Producerconectinfo>();
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
        public List<Producerconectinfo> SelectByKeys(string Key,List<string> KeyIds, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var query = new LambdaQuery<Producerconectinfo>();
            if("id" == Key.ToLowerInvariant())
            {
                query.Where(p => p.Id.In(KeyIds));
            }
            if("conectname" == Key.ToLowerInvariant())
            {
                query.Where(p => p.ConectName.In(KeyIds));
            }
            if("position" == Key.ToLowerInvariant())
            {
                query.Where(p => p.Position.In(KeyIds));
            }
            if("conectsex" == Key.ToLowerInvariant())
            {
                query.Where(p => p.ConectSex.In(KeyIds));
            }
            if("telephone" == Key.ToLowerInvariant())
            {
                query.Where(p => p.Telephone.In(KeyIds));
            }
            if("phone" == Key.ToLowerInvariant())
            {
                query.Where(p => p.Phone.In(KeyIds));
            }
            if("email" == Key.ToLowerInvariant())
            {
                query.Where(p => p.Email.In(KeyIds));
            }
            if("producerid" == Key.ToLowerInvariant())
            {
                query.Where(p => p.ProducerId.In(KeyIds));
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
        public List<Producerconectinfo> SelectByPage(string Key, int start, int PageSize, bool desc = true,Producerconectinfo model = null, string SelectFiled = null, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var query = new LambdaQuery<Producerconectinfo>();
            if (model != null)
            {
                if (!model.Id.IsNullOrEmpty())
                {
                    query.Where(p => p.Id == model.Id);
                }
                if (!model.ConectName.IsNullOrEmpty())
                {
                    query.Where(p => p.ConectName == model.ConectName);
                }
                if (!model.Position.IsNullOrEmpty())
                {
                    query.Where(p => p.Position == model.Position);
                }
                if (!model.ConectSex.IsNullOrEmpty())
                {
                    query.Where(p => p.ConectSex == model.ConectSex);
                }
                if (!model.Telephone.IsNullOrEmpty())
                {
                    query.Where(p => p.Telephone == model.Telephone);
                }
                if (!model.Phone.IsNullOrEmpty())
                {
                    query.Where(p => p.Phone == model.Phone);
                }
                if (!model.Email.IsNullOrEmpty())
                {
                    query.Where(p => p.Email == model.Email);
                }
                if (!model.ProducerId.IsNullOrEmpty())
                {
                    query.Where(p => p.ProducerId == model.ProducerId);
                }
            }
            if (SelectFiled != null)
            {
                SelectFiled = SelectFiled.ToLowerInvariant();
                if (SelectFiled.Contains("id,"))
                {
                    query.Select(p => new { p.Id });
                }
                if (SelectFiled.Contains("conectname,"))
                {
                    query.Select(p => new { p.ConectName });
                }
                if (SelectFiled.Contains("position,"))
                {
                    query.Select(p => new { p.Position });
                }
                if (SelectFiled.Contains("conectsex,"))
                {
                    query.Select(p => new { p.ConectSex });
                }
                if (SelectFiled.Contains("telephone,"))
                {
                    query.Select(p => new { p.Telephone });
                }
                if (SelectFiled.Contains("phone,"))
                {
                    query.Select(p => new { p.Phone });
                }
                if (SelectFiled.Contains("email,"))
                {
                    query.Select(p => new { p.Email });
                }
                if (SelectFiled.Contains("producerid,"))
                {
                    query.Select(p => new { p.ProducerId });
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
