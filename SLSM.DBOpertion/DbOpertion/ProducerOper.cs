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
    public partial class ProducerOper : SingleTon<ProducerOper>
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
            var delete = new LambdaDelete<Producer>();
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
        public bool DeleteModel(Producer model = null, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var delete = new LambdaDelete<Producer>();
            if (model != null)
            {
                if (!model.Id.IsNullOrEmpty())
                {
                    delete.Where(p => p.Id == model.Id);
                }
                if (!model.ProducerCode.IsNullOrEmpty())
                {
                    delete.Where(p => p.ProducerCode == model.ProducerCode);
                }
                if (!model.Address.IsNullOrEmpty())
                {
                    delete.Where(p => p.Address == model.Address);
                }
                if (!model.Name.IsNullOrEmpty())
                {
                    delete.Where(p => p.Name == model.Name);
                }
                if (!model.AddressRegion.IsNullOrEmpty())
                {
                    delete.Where(p => p.AddressRegion == model.AddressRegion);
                }
                if (!model.Abbreviation.IsNullOrEmpty())
                {
                    delete.Where(p => p.Abbreviation == model.Abbreviation);
                }
                if (!model.ZipCode.IsNullOrEmpty())
                {
                    delete.Where(p => p.ZipCode == model.ZipCode);
                }
                if (!model.SupplyProducts.IsNullOrEmpty())
                {
                    delete.Where(p => p.SupplyProducts == model.SupplyProducts);
                }
                if (!model.CreditRating.IsNullOrEmpty())
                {
                    delete.Where(p => p.CreditRating == model.CreditRating);
                }
                if (!model.CompanyWebsite.IsNullOrEmpty())
                {
                    delete.Where(p => p.CompanyWebsite == model.CompanyWebsite);
                }
                if (!model.CooperationLevel.IsNullOrEmpty())
                {
                    delete.Where(p => p.CooperationLevel == model.CooperationLevel);
                }
                if (!model.EnterLegPerson.IsNullOrEmpty())
                {
                    delete.Where(p => p.EnterLegPerson == model.EnterLegPerson);
                }
                if (!model.FaxNumber.IsNullOrEmpty())
                {
                    delete.Where(p => p.FaxNumber == model.FaxNumber);
                }
                if (!model.AccountPeriod.IsNullOrEmpty())
                {
                    delete.Where(p => p.AccountPeriod == model.AccountPeriod);
                }
                if (!model.RaiseTicket.IsNullOrEmpty())
                {
                    delete.Where(p => p.RaiseTicket == model.RaiseTicket);
                }
                if (!model.Bank.IsNullOrEmpty())
                {
                    delete.Where(p => p.Bank == model.Bank);
                }
                if (!model.identify.IsNullOrEmpty())
                {
                    delete.Where(p => p.identify == model.identify);
                }
                if (!model.AccountNumber.IsNullOrEmpty())
                {
                    delete.Where(p => p.AccountNumber == model.AccountNumber);
                }
                if (!model.IsDelete.IsNullOrEmpty())
                {
                    delete.Where(p => p.IsDelete == model.IsDelete);
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
        public bool Update(Producer model, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var update = new LambdaUpdate<Producer>();
            if (!model.Id.IsNullOrEmpty())
            {
                update.Where(p => p.Id == model.Id);
            }
            if (!model.ProducerCode.IsNullOrEmpty())
            {
                update.Set(p => p.ProducerCode == model.ProducerCode);
            }
            if (!model.Address.IsNullOrEmpty())
            {
                update.Set(p => p.Address == model.Address);
            }
            if (!model.Name.IsNullOrEmpty())
            {
                update.Set(p => p.Name == model.Name);
            }
            if (!model.AddressRegion.IsNullOrEmpty())
            {
                update.Set(p => p.AddressRegion == model.AddressRegion);
            }
            if (!model.Abbreviation.IsNullOrEmpty())
            {
                update.Set(p => p.Abbreviation == model.Abbreviation);
            }
            if (!model.ZipCode.IsNullOrEmpty())
            {
                update.Set(p => p.ZipCode == model.ZipCode);
            }
            if (!model.SupplyProducts.IsNullOrEmpty())
            {
                update.Set(p => p.SupplyProducts == model.SupplyProducts);
            }
            if (!model.CreditRating.IsNullOrEmpty())
            {
                update.Set(p => p.CreditRating == model.CreditRating);
            }
            if (!model.CompanyWebsite.IsNullOrEmpty())
            {
                update.Set(p => p.CompanyWebsite == model.CompanyWebsite);
            }
            if (!model.CooperationLevel.IsNullOrEmpty())
            {
                update.Set(p => p.CooperationLevel == model.CooperationLevel);
            }
            if (!model.EnterLegPerson.IsNullOrEmpty())
            {
                update.Set(p => p.EnterLegPerson == model.EnterLegPerson);
            }
            if (!model.FaxNumber.IsNullOrEmpty())
            {
                update.Set(p => p.FaxNumber == model.FaxNumber);
            }
            if (!model.AccountPeriod.IsNullOrEmpty())
            {
                update.Set(p => p.AccountPeriod == model.AccountPeriod);
            }
            if (!model.RaiseTicket.IsNullOrEmpty())
            {
                update.Set(p => p.RaiseTicket == model.RaiseTicket);
            }
            if (!model.Bank.IsNullOrEmpty())
            {
                update.Set(p => p.Bank == model.Bank);
            }
            if (!model.identify.IsNullOrEmpty())
            {
                update.Set(p => p.identify == model.identify);
            }
            if (!model.AccountNumber.IsNullOrEmpty())
            {
                update.Set(p => p.AccountNumber == model.AccountNumber);
            }
            if (!model.IsDelete.IsNullOrEmpty())
            {
                update.Set(p => p.IsDelete == model.IsDelete);
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
        public bool Insert(Producer model, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var insert = new LambdaInsert<Producer>();
            if (!model.ProducerCode.IsNullOrEmpty())
            {
                insert.Insert(p => p.ProducerCode == model.ProducerCode);
            }
            if (!model.Address.IsNullOrEmpty())
            {
                insert.Insert(p => p.Address == model.Address);
            }
            if (!model.Name.IsNullOrEmpty())
            {
                insert.Insert(p => p.Name == model.Name);
            }
            if (!model.AddressRegion.IsNullOrEmpty())
            {
                insert.Insert(p => p.AddressRegion == model.AddressRegion);
            }
            if (!model.Abbreviation.IsNullOrEmpty())
            {
                insert.Insert(p => p.Abbreviation == model.Abbreviation);
            }
            if (!model.ZipCode.IsNullOrEmpty())
            {
                insert.Insert(p => p.ZipCode == model.ZipCode);
            }
            if (!model.SupplyProducts.IsNullOrEmpty())
            {
                insert.Insert(p => p.SupplyProducts == model.SupplyProducts);
            }
            if (!model.CreditRating.IsNullOrEmpty())
            {
                insert.Insert(p => p.CreditRating == model.CreditRating);
            }
            if (!model.CompanyWebsite.IsNullOrEmpty())
            {
                insert.Insert(p => p.CompanyWebsite == model.CompanyWebsite);
            }
            if (!model.CooperationLevel.IsNullOrEmpty())
            {
                insert.Insert(p => p.CooperationLevel == model.CooperationLevel);
            }
            if (!model.EnterLegPerson.IsNullOrEmpty())
            {
                insert.Insert(p => p.EnterLegPerson == model.EnterLegPerson);
            }
            if (!model.FaxNumber.IsNullOrEmpty())
            {
                insert.Insert(p => p.FaxNumber == model.FaxNumber);
            }
            if (!model.AccountPeriod.IsNullOrEmpty())
            {
                insert.Insert(p => p.AccountPeriod == model.AccountPeriod);
            }
            if (!model.RaiseTicket.IsNullOrEmpty())
            {
                insert.Insert(p => p.RaiseTicket == model.RaiseTicket);
            }
            if (!model.Bank.IsNullOrEmpty())
            {
                insert.Insert(p => p.Bank == model.Bank);
            }
            if (!model.identify.IsNullOrEmpty())
            {
                insert.Insert(p => p.identify == model.identify);
            }
            if (!model.AccountNumber.IsNullOrEmpty())
            {
                insert.Insert(p => p.AccountNumber == model.AccountNumber);
            }
            if (!model.IsDelete.IsNullOrEmpty())
            {
                insert.Insert(p => p.IsDelete == model.IsDelete);
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
        public int InsertReturnKey(Producer model, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var insert = new LambdaInsert<Producer>();
            if (!model.ProducerCode.IsNullOrEmpty())
            {
                insert.Insert(p => p.ProducerCode == model.ProducerCode);
            }
            if (!model.Address.IsNullOrEmpty())
            {
                insert.Insert(p => p.Address == model.Address);
            }
            if (!model.Name.IsNullOrEmpty())
            {
                insert.Insert(p => p.Name == model.Name);
            }
            if (!model.AddressRegion.IsNullOrEmpty())
            {
                insert.Insert(p => p.AddressRegion == model.AddressRegion);
            }
            if (!model.Abbreviation.IsNullOrEmpty())
            {
                insert.Insert(p => p.Abbreviation == model.Abbreviation);
            }
            if (!model.ZipCode.IsNullOrEmpty())
            {
                insert.Insert(p => p.ZipCode == model.ZipCode);
            }
            if (!model.SupplyProducts.IsNullOrEmpty())
            {
                insert.Insert(p => p.SupplyProducts == model.SupplyProducts);
            }
            if (!model.CreditRating.IsNullOrEmpty())
            {
                insert.Insert(p => p.CreditRating == model.CreditRating);
            }
            if (!model.CompanyWebsite.IsNullOrEmpty())
            {
                insert.Insert(p => p.CompanyWebsite == model.CompanyWebsite);
            }
            if (!model.CooperationLevel.IsNullOrEmpty())
            {
                insert.Insert(p => p.CooperationLevel == model.CooperationLevel);
            }
            if (!model.EnterLegPerson.IsNullOrEmpty())
            {
                insert.Insert(p => p.EnterLegPerson == model.EnterLegPerson);
            }
            if (!model.FaxNumber.IsNullOrEmpty())
            {
                insert.Insert(p => p.FaxNumber == model.FaxNumber);
            }
            if (!model.AccountPeriod.IsNullOrEmpty())
            {
                insert.Insert(p => p.AccountPeriod == model.AccountPeriod);
            }
            if (!model.RaiseTicket.IsNullOrEmpty())
            {
                insert.Insert(p => p.RaiseTicket == model.RaiseTicket);
            }
            if (!model.Bank.IsNullOrEmpty())
            {
                insert.Insert(p => p.Bank == model.Bank);
            }
            if (!model.identify.IsNullOrEmpty())
            {
                insert.Insert(p => p.identify == model.identify);
            }
            if (!model.AccountNumber.IsNullOrEmpty())
            {
                insert.Insert(p => p.AccountNumber == model.AccountNumber);
            }
            if (!model.IsDelete.IsNullOrEmpty())
            {
                insert.Insert(p => p.IsDelete == model.IsDelete);
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
        public List<Producer> SelectAll(Producer model = null, string SelectFiled = null, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var query = new LambdaQuery<Producer>();
            if (model != null)
            {
                if (!model.Id.IsNullOrEmpty())
                {
                    query.Where(p => p.Id == model.Id);
                }
                if (!model.ProducerCode.IsNullOrEmpty())
                {
                    query.Where(p => p.ProducerCode == model.ProducerCode);
                }
                if (!model.Address.IsNullOrEmpty())
                {
                    query.Where(p => p.Address == model.Address);
                }
                if (!model.Name.IsNullOrEmpty())
                {
                    query.Where(p => p.Name == model.Name);
                }
                if (!model.AddressRegion.IsNullOrEmpty())
                {
                    query.Where(p => p.AddressRegion == model.AddressRegion);
                }
                if (!model.Abbreviation.IsNullOrEmpty())
                {
                    query.Where(p => p.Abbreviation == model.Abbreviation);
                }
                if (!model.ZipCode.IsNullOrEmpty())
                {
                    query.Where(p => p.ZipCode == model.ZipCode);
                }
                if (!model.SupplyProducts.IsNullOrEmpty())
                {
                    query.Where(p => p.SupplyProducts == model.SupplyProducts);
                }
                if (!model.CreditRating.IsNullOrEmpty())
                {
                    query.Where(p => p.CreditRating == model.CreditRating);
                }
                if (!model.CompanyWebsite.IsNullOrEmpty())
                {
                    query.Where(p => p.CompanyWebsite == model.CompanyWebsite);
                }
                if (!model.CooperationLevel.IsNullOrEmpty())
                {
                    query.Where(p => p.CooperationLevel == model.CooperationLevel);
                }
                if (!model.EnterLegPerson.IsNullOrEmpty())
                {
                    query.Where(p => p.EnterLegPerson == model.EnterLegPerson);
                }
                if (!model.FaxNumber.IsNullOrEmpty())
                {
                    query.Where(p => p.FaxNumber == model.FaxNumber);
                }
                if (!model.AccountPeriod.IsNullOrEmpty())
                {
                    query.Where(p => p.AccountPeriod == model.AccountPeriod);
                }
                if (!model.RaiseTicket.IsNullOrEmpty())
                {
                    query.Where(p => p.RaiseTicket == model.RaiseTicket);
                }
                if (!model.Bank.IsNullOrEmpty())
                {
                    query.Where(p => p.Bank == model.Bank);
                }
                if (!model.identify.IsNullOrEmpty())
                {
                    query.Where(p => p.identify == model.identify);
                }
                if (!model.AccountNumber.IsNullOrEmpty())
                {
                    query.Where(p => p.AccountNumber == model.AccountNumber);
                }
                if (!model.IsDelete.IsNullOrEmpty())
                {
                    query.Where(p => p.IsDelete == model.IsDelete);
                }
            }
            if (SelectFiled != null)
            {
                SelectFiled = SelectFiled.ToLowerInvariant();
                if (SelectFiled.Contains("id,"))
                {
                    query.Select(p => new { p.Id });
                }
                if (SelectFiled.Contains("producercode,"))
                {
                    query.Select(p => new { p.ProducerCode });
                }
                if (SelectFiled.Contains("address,"))
                {
                    query.Select(p => new { p.Address });
                }
                if (SelectFiled.Contains("name,"))
                {
                    query.Select(p => new { p.Name });
                }
                if (SelectFiled.Contains("addressregion,"))
                {
                    query.Select(p => new { p.AddressRegion });
                }
                if (SelectFiled.Contains("abbreviation,"))
                {
                    query.Select(p => new { p.Abbreviation });
                }
                if (SelectFiled.Contains("zipcode,"))
                {
                    query.Select(p => new { p.ZipCode });
                }
                if (SelectFiled.Contains("supplyproducts,"))
                {
                    query.Select(p => new { p.SupplyProducts });
                }
                if (SelectFiled.Contains("creditrating,"))
                {
                    query.Select(p => new { p.CreditRating });
                }
                if (SelectFiled.Contains("companywebsite,"))
                {
                    query.Select(p => new { p.CompanyWebsite });
                }
                if (SelectFiled.Contains("cooperationlevel,"))
                {
                    query.Select(p => new { p.CooperationLevel });
                }
                if (SelectFiled.Contains("enterlegperson,"))
                {
                    query.Select(p => new { p.EnterLegPerson });
                }
                if (SelectFiled.Contains("faxnumber,"))
                {
                    query.Select(p => new { p.FaxNumber });
                }
                if (SelectFiled.Contains("accountperiod,"))
                {
                    query.Select(p => new { p.AccountPeriod });
                }
                if (SelectFiled.Contains("raiseticket,"))
                {
                    query.Select(p => new { p.RaiseTicket });
                }
                if (SelectFiled.Contains("bank,"))
                {
                    query.Select(p => new { p.Bank });
                }
                if (SelectFiled.Contains("identify,"))
                {
                    query.Select(p => new { p.identify });
                }
                if (SelectFiled.Contains("accountnumber,"))
                {
                    query.Select(p => new { p.AccountNumber });
                }
                if (SelectFiled.Contains("isdelete,"))
                {
                    query.Select(p => new { p.IsDelete });
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
        public int SelectCount(Producer model = null, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var query = new LambdaQuery<Producer>();
            if (model != null)
            {
                if (!model.Id.IsNullOrEmpty())
                {
                    query.Where(p => p.Id == model.Id);
                }
                if (!model.ProducerCode.IsNullOrEmpty())
                {
                    query.Where(p => p.ProducerCode == model.ProducerCode);
                }
                if (!model.Address.IsNullOrEmpty())
                {
                    query.Where(p => p.Address == model.Address);
                }
                if (!model.Name.IsNullOrEmpty())
                {
                    query.Where(p => p.Name == model.Name);
                }
                if (!model.AddressRegion.IsNullOrEmpty())
                {
                    query.Where(p => p.AddressRegion == model.AddressRegion);
                }
                if (!model.Abbreviation.IsNullOrEmpty())
                {
                    query.Where(p => p.Abbreviation == model.Abbreviation);
                }
                if (!model.ZipCode.IsNullOrEmpty())
                {
                    query.Where(p => p.ZipCode == model.ZipCode);
                }
                if (!model.SupplyProducts.IsNullOrEmpty())
                {
                    query.Where(p => p.SupplyProducts == model.SupplyProducts);
                }
                if (!model.CreditRating.IsNullOrEmpty())
                {
                    query.Where(p => p.CreditRating == model.CreditRating);
                }
                if (!model.CompanyWebsite.IsNullOrEmpty())
                {
                    query.Where(p => p.CompanyWebsite == model.CompanyWebsite);
                }
                if (!model.CooperationLevel.IsNullOrEmpty())
                {
                    query.Where(p => p.CooperationLevel == model.CooperationLevel);
                }
                if (!model.EnterLegPerson.IsNullOrEmpty())
                {
                    query.Where(p => p.EnterLegPerson == model.EnterLegPerson);
                }
                if (!model.FaxNumber.IsNullOrEmpty())
                {
                    query.Where(p => p.FaxNumber == model.FaxNumber);
                }
                if (!model.AccountPeriod.IsNullOrEmpty())
                {
                    query.Where(p => p.AccountPeriod == model.AccountPeriod);
                }
                if (!model.RaiseTicket.IsNullOrEmpty())
                {
                    query.Where(p => p.RaiseTicket == model.RaiseTicket);
                }
                if (!model.Bank.IsNullOrEmpty())
                {
                    query.Where(p => p.Bank == model.Bank);
                }
                if (!model.identify.IsNullOrEmpty())
                {
                    query.Where(p => p.identify == model.identify);
                }
                if (!model.AccountNumber.IsNullOrEmpty())
                {
                    query.Where(p => p.AccountNumber == model.AccountNumber);
                }
                if (!model.IsDelete.IsNullOrEmpty())
                {
                    query.Where(p => p.IsDelete == model.IsDelete);
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
        public Producer SelectById(int KeyId, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var query = new LambdaQuery<Producer>();
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
        public List<Producer> SelectByKeys(string Key,List<string> KeyIds, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var query = new LambdaQuery<Producer>();
            if("id" == Key.ToLowerInvariant())
            {
                query.Where(p => p.Id.In(KeyIds));
            }
            if("producercode" == Key.ToLowerInvariant())
            {
                query.Where(p => p.ProducerCode.In(KeyIds));
            }
            if("address" == Key.ToLowerInvariant())
            {
                query.Where(p => p.Address.In(KeyIds));
            }
            if("name" == Key.ToLowerInvariant())
            {
                query.Where(p => p.Name.In(KeyIds));
            }
            if("addressregion" == Key.ToLowerInvariant())
            {
                query.Where(p => p.AddressRegion.In(KeyIds));
            }
            if("abbreviation" == Key.ToLowerInvariant())
            {
                query.Where(p => p.Abbreviation.In(KeyIds));
            }
            if("zipcode" == Key.ToLowerInvariant())
            {
                query.Where(p => p.ZipCode.In(KeyIds));
            }
            if("supplyproducts" == Key.ToLowerInvariant())
            {
                query.Where(p => p.SupplyProducts.In(KeyIds));
            }
            if("creditrating" == Key.ToLowerInvariant())
            {
                query.Where(p => p.CreditRating.In(KeyIds));
            }
            if("companywebsite" == Key.ToLowerInvariant())
            {
                query.Where(p => p.CompanyWebsite.In(KeyIds));
            }
            if("cooperationlevel" == Key.ToLowerInvariant())
            {
                query.Where(p => p.CooperationLevel.In(KeyIds));
            }
            if("enterlegperson" == Key.ToLowerInvariant())
            {
                query.Where(p => p.EnterLegPerson.In(KeyIds));
            }
            if("faxnumber" == Key.ToLowerInvariant())
            {
                query.Where(p => p.FaxNumber.In(KeyIds));
            }
            if("accountperiod" == Key.ToLowerInvariant())
            {
                query.Where(p => p.AccountPeriod.In(KeyIds));
            }
            if("raiseticket" == Key.ToLowerInvariant())
            {
                query.Where(p => p.RaiseTicket.In(KeyIds));
            }
            if("bank" == Key.ToLowerInvariant())
            {
                query.Where(p => p.Bank.In(KeyIds));
            }
            if("identify" == Key.ToLowerInvariant())
            {
                query.Where(p => p.identify.In(KeyIds));
            }
            if("accountnumber" == Key.ToLowerInvariant())
            {
                query.Where(p => p.AccountNumber.In(KeyIds));
            }
            if("isdelete" == Key.ToLowerInvariant())
            {
                query.Where(p => p.IsDelete.In(KeyIds));
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
        public List<Producer> SelectByPage(string Key, int start, int PageSize, bool desc = true,Producer model = null, string SelectFiled = null, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var query = new LambdaQuery<Producer>();
            if (model != null)
            {
                if (!model.Id.IsNullOrEmpty())
                {
                    query.Where(p => p.Id == model.Id);
                }
                if (!model.ProducerCode.IsNullOrEmpty())
                {
                    query.Where(p => p.ProducerCode == model.ProducerCode);
                }
                if (!model.Address.IsNullOrEmpty())
                {
                    query.Where(p => p.Address == model.Address);
                }
                if (!model.Name.IsNullOrEmpty())
                {
                    query.Where(p => p.Name == model.Name);
                }
                if (!model.AddressRegion.IsNullOrEmpty())
                {
                    query.Where(p => p.AddressRegion == model.AddressRegion);
                }
                if (!model.Abbreviation.IsNullOrEmpty())
                {
                    query.Where(p => p.Abbreviation == model.Abbreviation);
                }
                if (!model.ZipCode.IsNullOrEmpty())
                {
                    query.Where(p => p.ZipCode == model.ZipCode);
                }
                if (!model.SupplyProducts.IsNullOrEmpty())
                {
                    query.Where(p => p.SupplyProducts == model.SupplyProducts);
                }
                if (!model.CreditRating.IsNullOrEmpty())
                {
                    query.Where(p => p.CreditRating == model.CreditRating);
                }
                if (!model.CompanyWebsite.IsNullOrEmpty())
                {
                    query.Where(p => p.CompanyWebsite == model.CompanyWebsite);
                }
                if (!model.CooperationLevel.IsNullOrEmpty())
                {
                    query.Where(p => p.CooperationLevel == model.CooperationLevel);
                }
                if (!model.EnterLegPerson.IsNullOrEmpty())
                {
                    query.Where(p => p.EnterLegPerson == model.EnterLegPerson);
                }
                if (!model.FaxNumber.IsNullOrEmpty())
                {
                    query.Where(p => p.FaxNumber == model.FaxNumber);
                }
                if (!model.AccountPeriod.IsNullOrEmpty())
                {
                    query.Where(p => p.AccountPeriod == model.AccountPeriod);
                }
                if (!model.RaiseTicket.IsNullOrEmpty())
                {
                    query.Where(p => p.RaiseTicket == model.RaiseTicket);
                }
                if (!model.Bank.IsNullOrEmpty())
                {
                    query.Where(p => p.Bank == model.Bank);
                }
                if (!model.identify.IsNullOrEmpty())
                {
                    query.Where(p => p.identify == model.identify);
                }
                if (!model.AccountNumber.IsNullOrEmpty())
                {
                    query.Where(p => p.AccountNumber == model.AccountNumber);
                }
                if (!model.IsDelete.IsNullOrEmpty())
                {
                    query.Where(p => p.IsDelete == model.IsDelete);
                }
            }
            if (SelectFiled != null)
            {
                SelectFiled = SelectFiled.ToLowerInvariant();
                if (SelectFiled.Contains("id,"))
                {
                    query.Select(p => new { p.Id });
                }
                if (SelectFiled.Contains("producercode,"))
                {
                    query.Select(p => new { p.ProducerCode });
                }
                if (SelectFiled.Contains("address,"))
                {
                    query.Select(p => new { p.Address });
                }
                if (SelectFiled.Contains("name,"))
                {
                    query.Select(p => new { p.Name });
                }
                if (SelectFiled.Contains("addressregion,"))
                {
                    query.Select(p => new { p.AddressRegion });
                }
                if (SelectFiled.Contains("abbreviation,"))
                {
                    query.Select(p => new { p.Abbreviation });
                }
                if (SelectFiled.Contains("zipcode,"))
                {
                    query.Select(p => new { p.ZipCode });
                }
                if (SelectFiled.Contains("supplyproducts,"))
                {
                    query.Select(p => new { p.SupplyProducts });
                }
                if (SelectFiled.Contains("creditrating,"))
                {
                    query.Select(p => new { p.CreditRating });
                }
                if (SelectFiled.Contains("companywebsite,"))
                {
                    query.Select(p => new { p.CompanyWebsite });
                }
                if (SelectFiled.Contains("cooperationlevel,"))
                {
                    query.Select(p => new { p.CooperationLevel });
                }
                if (SelectFiled.Contains("enterlegperson,"))
                {
                    query.Select(p => new { p.EnterLegPerson });
                }
                if (SelectFiled.Contains("faxnumber,"))
                {
                    query.Select(p => new { p.FaxNumber });
                }
                if (SelectFiled.Contains("accountperiod,"))
                {
                    query.Select(p => new { p.AccountPeriod });
                }
                if (SelectFiled.Contains("raiseticket,"))
                {
                    query.Select(p => new { p.RaiseTicket });
                }
                if (SelectFiled.Contains("bank,"))
                {
                    query.Select(p => new { p.Bank });
                }
                if (SelectFiled.Contains("identify,"))
                {
                    query.Select(p => new { p.identify });
                }
                if (SelectFiled.Contains("accountnumber,"))
                {
                    query.Select(p => new { p.AccountNumber });
                }
                if (SelectFiled.Contains("isdelete,"))
                {
                    query.Select(p => new { p.IsDelete });
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
