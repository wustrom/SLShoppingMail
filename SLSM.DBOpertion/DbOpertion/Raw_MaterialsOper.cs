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
    public partial class Raw_MaterialsOper : SingleTon<Raw_MaterialsOper>
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
            var delete = new LambdaDelete<Raw_Materials>();
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
        public bool DeleteModel(Raw_Materials model = null, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var delete = new LambdaDelete<Raw_Materials>();
            if (model != null)
            {
                if (!model.Id.IsNullOrEmpty())
                {
                    delete.Where(p => p.Id == model.Id);
                }
                if (!model.ProductNo.IsNullOrEmpty())
                {
                    delete.Where(p => p.ProductNo == model.ProductNo);
                }
                if (!model.ChinaUnit.IsNullOrEmpty())
                {
                    delete.Where(p => p.ChinaUnit == model.ChinaUnit);
                }
                if (!model.ChinaProductName.IsNullOrEmpty())
                {
                    delete.Where(p => p.ChinaProductName == model.ChinaProductName);
                }
                if (!model.EnglishUnit.IsNullOrEmpty())
                {
                    delete.Where(p => p.EnglishUnit == model.EnglishUnit);
                }
                if (!model.EnglishProductName.IsNullOrEmpty())
                {
                    delete.Where(p => p.EnglishProductName == model.EnglishProductName);
                }
                if (!model.HSCODE.IsNullOrEmpty())
                {
                    delete.Where(p => p.HSCODE == model.HSCODE);
                }
                if (!model.Attributes.IsNullOrEmpty())
                {
                    delete.Where(p => p.Attributes == model.Attributes);
                }
                if (!model.TaxRate.IsNullOrEmpty())
                {
                    delete.Where(p => p.TaxRate == model.TaxRate);
                }
                if (!model.Genera.IsNullOrEmpty())
                {
                    delete.Where(p => p.Genera == model.Genera);
                }
                if (!model.Specification.IsNullOrEmpty())
                {
                    delete.Where(p => p.Specification == model.Specification);
                }
                if (!model.Subclass.IsNullOrEmpty())
                {
                    delete.Where(p => p.Subclass == model.Subclass);
                }
                if (!model.MatAndPro.IsNullOrEmpty())
                {
                    delete.Where(p => p.MatAndPro == model.MatAndPro);
                }
                if (!model.DeveTime.IsNullOrEmpty())
                {
                    delete.Where(p => p.DeveTime == model.DeveTime);
                }
                if (!model.DevePerson.IsNullOrEmpty())
                {
                    delete.Where(p => p.DevePerson == model.DevePerson);
                }
                if (!model.Description.IsNullOrEmpty())
                {
                    delete.Where(p => p.Description == model.Description);
                }
                if (!model.ProductDesibe.IsNullOrEmpty())
                {
                    delete.Where(p => p.ProductDesibe == model.ProductDesibe);
                }
                if (!model.Weight.IsNullOrEmpty())
                {
                    delete.Where(p => p.Weight == model.Weight);
                }
                if (!model.NumMiddleBoxes.IsNullOrEmpty())
                {
                    delete.Where(p => p.NumMiddleBoxes == model.NumMiddleBoxes);
                }
                if (!model.NumOuterBoxes.IsNullOrEmpty())
                {
                    delete.Where(p => p.NumOuterBoxes == model.NumOuterBoxes);
                }
                if (!model.OuterBoxesLength.IsNullOrEmpty())
                {
                    delete.Where(p => p.OuterBoxesLength == model.OuterBoxesLength);
                }
                if (!model.OuterBoxesWidth.IsNullOrEmpty())
                {
                    delete.Where(p => p.OuterBoxesWidth == model.OuterBoxesWidth);
                }
                if (!model.OuterBoxesHeight.IsNullOrEmpty())
                {
                    delete.Where(p => p.OuterBoxesHeight == model.OuterBoxesHeight);
                }
                if (!model.OuterBoxesVolume.IsNullOrEmpty())
                {
                    delete.Where(p => p.OuterBoxesVolume == model.OuterBoxesVolume);
                }
                if (!model.NetWeight.IsNullOrEmpty())
                {
                    delete.Where(p => p.NetWeight == model.NetWeight);
                }
                if (!model.SalesInfoList.IsNullOrEmpty())
                {
                    delete.Where(p => p.SalesInfoList == model.SalesInfoList);
                }
                if (!model.Remark.IsNullOrEmpty())
                {
                    delete.Where(p => p.Remark == model.Remark);
                }
                if (!model.IsDelete.IsNullOrEmpty())
                {
                    delete.Where(p => p.IsDelete == model.IsDelete);
                }
                if (!model.SyloonPatent.IsNullOrEmpty())
                {
                    delete.Where(p => p.SyloonPatent == model.SyloonPatent);
                }
                if (!model.EngDescription.IsNullOrEmpty())
                {
                    delete.Where(p => p.EngDescription == model.EngDescription);
                }
                if (!model.TypeInfo.IsNullOrEmpty())
                {
                    delete.Where(p => p.TypeInfo == model.TypeInfo);
                }
                if (!model.PrintFuncInfo.IsNullOrEmpty())
                {
                    delete.Where(p => p.PrintFuncInfo == model.PrintFuncInfo);
                }
                if (!model.Printingdetail.IsNullOrEmpty())
                {
                    delete.Where(p => p.Printingdetail == model.Printingdetail);
                }
                if (!model.PercentageInfo.IsNullOrEmpty())
                {
                    delete.Where(p => p.PercentageInfo == model.PercentageInfo);
                }
                if (!model.TipPercentInfo.IsNullOrEmpty())
                {
                    delete.Where(p => p.TipPercentInfo == model.TipPercentInfo);
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
        public bool Update(Raw_Materials model, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var update = new LambdaUpdate<Raw_Materials>();
            if (!model.Id.IsNullOrEmpty())
            {
                update.Where(p => p.Id == model.Id);
            }
            if (!model.ProductNo.IsNullOrEmpty())
            {
                update.Set(p => p.ProductNo == model.ProductNo);
            }
            if (!model.ChinaUnit.IsNullOrEmpty())
            {
                update.Set(p => p.ChinaUnit == model.ChinaUnit);
            }
            if (!model.ChinaProductName.IsNullOrEmpty())
            {
                update.Set(p => p.ChinaProductName == model.ChinaProductName);
            }
            if (!model.EnglishUnit.IsNullOrEmpty())
            {
                update.Set(p => p.EnglishUnit == model.EnglishUnit);
            }
            if (!model.EnglishProductName.IsNullOrEmpty())
            {
                update.Set(p => p.EnglishProductName == model.EnglishProductName);
            }
            if (!model.HSCODE.IsNullOrEmpty())
            {
                update.Set(p => p.HSCODE == model.HSCODE);
            }
            if (!model.Attributes.IsNullOrEmpty())
            {
                update.Set(p => p.Attributes == model.Attributes);
            }
            if (!model.TaxRate.IsNullOrEmpty())
            {
                update.Set(p => p.TaxRate == model.TaxRate);
            }
            if (!model.Genera.IsNullOrEmpty())
            {
                update.Set(p => p.Genera == model.Genera);
            }
            if (!model.Specification.IsNullOrEmpty())
            {
                update.Set(p => p.Specification == model.Specification);
            }
            if (!model.Subclass.IsNullOrEmpty())
            {
                update.Set(p => p.Subclass == model.Subclass);
            }
            if (!model.MatAndPro.IsNullOrEmpty())
            {
                update.Set(p => p.MatAndPro == model.MatAndPro);
            }
            if (!model.DeveTime.IsNullOrEmpty())
            {
                update.Set(p => p.DeveTime == model.DeveTime);
            }
            if (!model.DevePerson.IsNullOrEmpty())
            {
                update.Set(p => p.DevePerson == model.DevePerson);
            }
            if (!model.Description.IsNullOrEmpty())
            {
                update.Set(p => p.Description == model.Description);
            }
            if (!model.ProductDesibe.IsNullOrEmpty())
            {
                update.Set(p => p.ProductDesibe == model.ProductDesibe);
            }
            if (!model.Weight.IsNullOrEmpty())
            {
                update.Set(p => p.Weight == model.Weight);
            }
            if (!model.NumMiddleBoxes.IsNullOrEmpty())
            {
                update.Set(p => p.NumMiddleBoxes == model.NumMiddleBoxes);
            }
            if (!model.NumOuterBoxes.IsNullOrEmpty())
            {
                update.Set(p => p.NumOuterBoxes == model.NumOuterBoxes);
            }
            if (!model.OuterBoxesLength.IsNullOrEmpty())
            {
                update.Set(p => p.OuterBoxesLength == model.OuterBoxesLength);
            }
            if (!model.OuterBoxesWidth.IsNullOrEmpty())
            {
                update.Set(p => p.OuterBoxesWidth == model.OuterBoxesWidth);
            }
            if (!model.OuterBoxesHeight.IsNullOrEmpty())
            {
                update.Set(p => p.OuterBoxesHeight == model.OuterBoxesHeight);
            }
            if (!model.OuterBoxesVolume.IsNullOrEmpty())
            {
                update.Set(p => p.OuterBoxesVolume == model.OuterBoxesVolume);
            }
            if (!model.NetWeight.IsNullOrEmpty())
            {
                update.Set(p => p.NetWeight == model.NetWeight);
            }
            if (!model.SalesInfoList.IsNullOrEmpty())
            {
                update.Set(p => p.SalesInfoList == model.SalesInfoList);
            }
            if (!model.Remark.IsNullOrEmpty())
            {
                update.Set(p => p.Remark == model.Remark);
            }
            if (!model.IsDelete.IsNullOrEmpty())
            {
                update.Set(p => p.IsDelete == model.IsDelete);
            }
            if (!model.SyloonPatent.IsNullOrEmpty())
            {
                update.Set(p => p.SyloonPatent == model.SyloonPatent);
            }
            if (!model.EngDescription.IsNullOrEmpty())
            {
                update.Set(p => p.EngDescription == model.EngDescription);
            }
            if (!model.TypeInfo.IsNullOrEmpty())
            {
                update.Set(p => p.TypeInfo == model.TypeInfo);
            }
            if (!model.PrintFuncInfo.IsNullOrEmpty())
            {
                update.Set(p => p.PrintFuncInfo == model.PrintFuncInfo);
            }
            if (!model.Printingdetail.IsNullOrEmpty())
            {
                update.Set(p => p.Printingdetail == model.Printingdetail);
            }
            if (!model.PercentageInfo.IsNullOrEmpty())
            {
                update.Set(p => p.PercentageInfo == model.PercentageInfo);
            }
            if (!model.TipPercentInfo.IsNullOrEmpty())
            {
                update.Set(p => p.TipPercentInfo == model.TipPercentInfo);
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
        public bool Insert(Raw_Materials model, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var insert = new LambdaInsert<Raw_Materials>();
            if (!model.ProductNo.IsNullOrEmpty())
            {
                insert.Insert(p => p.ProductNo == model.ProductNo);
            }
            if (!model.ChinaUnit.IsNullOrEmpty())
            {
                insert.Insert(p => p.ChinaUnit == model.ChinaUnit);
            }
            if (!model.ChinaProductName.IsNullOrEmpty())
            {
                insert.Insert(p => p.ChinaProductName == model.ChinaProductName);
            }
            if (!model.EnglishUnit.IsNullOrEmpty())
            {
                insert.Insert(p => p.EnglishUnit == model.EnglishUnit);
            }
            if (!model.EnglishProductName.IsNullOrEmpty())
            {
                insert.Insert(p => p.EnglishProductName == model.EnglishProductName);
            }
            if (!model.HSCODE.IsNullOrEmpty())
            {
                insert.Insert(p => p.HSCODE == model.HSCODE);
            }
            if (!model.Attributes.IsNullOrEmpty())
            {
                insert.Insert(p => p.Attributes == model.Attributes);
            }
            if (!model.TaxRate.IsNullOrEmpty())
            {
                insert.Insert(p => p.TaxRate == model.TaxRate);
            }
            if (!model.Genera.IsNullOrEmpty())
            {
                insert.Insert(p => p.Genera == model.Genera);
            }
            if (!model.Specification.IsNullOrEmpty())
            {
                insert.Insert(p => p.Specification == model.Specification);
            }
            if (!model.Subclass.IsNullOrEmpty())
            {
                insert.Insert(p => p.Subclass == model.Subclass);
            }
            if (!model.MatAndPro.IsNullOrEmpty())
            {
                insert.Insert(p => p.MatAndPro == model.MatAndPro);
            }
            if (!model.DeveTime.IsNullOrEmpty())
            {
                insert.Insert(p => p.DeveTime == model.DeveTime);
            }
            if (!model.DevePerson.IsNullOrEmpty())
            {
                insert.Insert(p => p.DevePerson == model.DevePerson);
            }
            if (!model.Description.IsNullOrEmpty())
            {
                insert.Insert(p => p.Description == model.Description);
            }
            if (!model.ProductDesibe.IsNullOrEmpty())
            {
                insert.Insert(p => p.ProductDesibe == model.ProductDesibe);
            }
            if (!model.Weight.IsNullOrEmpty())
            {
                insert.Insert(p => p.Weight == model.Weight);
            }
            if (!model.NumMiddleBoxes.IsNullOrEmpty())
            {
                insert.Insert(p => p.NumMiddleBoxes == model.NumMiddleBoxes);
            }
            if (!model.NumOuterBoxes.IsNullOrEmpty())
            {
                insert.Insert(p => p.NumOuterBoxes == model.NumOuterBoxes);
            }
            if (!model.OuterBoxesLength.IsNullOrEmpty())
            {
                insert.Insert(p => p.OuterBoxesLength == model.OuterBoxesLength);
            }
            if (!model.OuterBoxesWidth.IsNullOrEmpty())
            {
                insert.Insert(p => p.OuterBoxesWidth == model.OuterBoxesWidth);
            }
            if (!model.OuterBoxesHeight.IsNullOrEmpty())
            {
                insert.Insert(p => p.OuterBoxesHeight == model.OuterBoxesHeight);
            }
            if (!model.OuterBoxesVolume.IsNullOrEmpty())
            {
                insert.Insert(p => p.OuterBoxesVolume == model.OuterBoxesVolume);
            }
            if (!model.NetWeight.IsNullOrEmpty())
            {
                insert.Insert(p => p.NetWeight == model.NetWeight);
            }
            if (!model.SalesInfoList.IsNullOrEmpty())
            {
                insert.Insert(p => p.SalesInfoList == model.SalesInfoList);
            }
            if (!model.Remark.IsNullOrEmpty())
            {
                insert.Insert(p => p.Remark == model.Remark);
            }
            if (!model.IsDelete.IsNullOrEmpty())
            {
                insert.Insert(p => p.IsDelete == model.IsDelete);
            }
            if (!model.SyloonPatent.IsNullOrEmpty())
            {
                insert.Insert(p => p.SyloonPatent == model.SyloonPatent);
            }
            if (!model.EngDescription.IsNullOrEmpty())
            {
                insert.Insert(p => p.EngDescription == model.EngDescription);
            }
            if (!model.TypeInfo.IsNullOrEmpty())
            {
                insert.Insert(p => p.TypeInfo == model.TypeInfo);
            }
            if (!model.PrintFuncInfo.IsNullOrEmpty())
            {
                insert.Insert(p => p.PrintFuncInfo == model.PrintFuncInfo);
            }
            if (!model.Printingdetail.IsNullOrEmpty())
            {
                insert.Insert(p => p.Printingdetail == model.Printingdetail);
            }
            if (!model.PercentageInfo.IsNullOrEmpty())
            {
                insert.Insert(p => p.PercentageInfo == model.PercentageInfo);
            }
            if (!model.TipPercentInfo.IsNullOrEmpty())
            {
                insert.Insert(p => p.TipPercentInfo == model.TipPercentInfo);
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
        public int InsertReturnKey(Raw_Materials model, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var insert = new LambdaInsert<Raw_Materials>();
            if (!model.ProductNo.IsNullOrEmpty())
            {
                insert.Insert(p => p.ProductNo == model.ProductNo);
            }
            if (!model.ChinaUnit.IsNullOrEmpty())
            {
                insert.Insert(p => p.ChinaUnit == model.ChinaUnit);
            }
            if (!model.ChinaProductName.IsNullOrEmpty())
            {
                insert.Insert(p => p.ChinaProductName == model.ChinaProductName);
            }
            if (!model.EnglishUnit.IsNullOrEmpty())
            {
                insert.Insert(p => p.EnglishUnit == model.EnglishUnit);
            }
            if (!model.EnglishProductName.IsNullOrEmpty())
            {
                insert.Insert(p => p.EnglishProductName == model.EnglishProductName);
            }
            if (!model.HSCODE.IsNullOrEmpty())
            {
                insert.Insert(p => p.HSCODE == model.HSCODE);
            }
            if (!model.Attributes.IsNullOrEmpty())
            {
                insert.Insert(p => p.Attributes == model.Attributes);
            }
            if (!model.TaxRate.IsNullOrEmpty())
            {
                insert.Insert(p => p.TaxRate == model.TaxRate);
            }
            if (!model.Genera.IsNullOrEmpty())
            {
                insert.Insert(p => p.Genera == model.Genera);
            }
            if (!model.Specification.IsNullOrEmpty())
            {
                insert.Insert(p => p.Specification == model.Specification);
            }
            if (!model.Subclass.IsNullOrEmpty())
            {
                insert.Insert(p => p.Subclass == model.Subclass);
            }
            if (!model.MatAndPro.IsNullOrEmpty())
            {
                insert.Insert(p => p.MatAndPro == model.MatAndPro);
            }
            if (!model.DeveTime.IsNullOrEmpty())
            {
                insert.Insert(p => p.DeveTime == model.DeveTime);
            }
            if (!model.DevePerson.IsNullOrEmpty())
            {
                insert.Insert(p => p.DevePerson == model.DevePerson);
            }
            if (!model.Description.IsNullOrEmpty())
            {
                insert.Insert(p => p.Description == model.Description);
            }
            if (!model.ProductDesibe.IsNullOrEmpty())
            {
                insert.Insert(p => p.ProductDesibe == model.ProductDesibe);
            }
            if (!model.Weight.IsNullOrEmpty())
            {
                insert.Insert(p => p.Weight == model.Weight);
            }
            if (!model.NumMiddleBoxes.IsNullOrEmpty())
            {
                insert.Insert(p => p.NumMiddleBoxes == model.NumMiddleBoxes);
            }
            if (!model.NumOuterBoxes.IsNullOrEmpty())
            {
                insert.Insert(p => p.NumOuterBoxes == model.NumOuterBoxes);
            }
            if (!model.OuterBoxesLength.IsNullOrEmpty())
            {
                insert.Insert(p => p.OuterBoxesLength == model.OuterBoxesLength);
            }
            if (!model.OuterBoxesWidth.IsNullOrEmpty())
            {
                insert.Insert(p => p.OuterBoxesWidth == model.OuterBoxesWidth);
            }
            if (!model.OuterBoxesHeight.IsNullOrEmpty())
            {
                insert.Insert(p => p.OuterBoxesHeight == model.OuterBoxesHeight);
            }
            if (!model.OuterBoxesVolume.IsNullOrEmpty())
            {
                insert.Insert(p => p.OuterBoxesVolume == model.OuterBoxesVolume);
            }
            if (!model.NetWeight.IsNullOrEmpty())
            {
                insert.Insert(p => p.NetWeight == model.NetWeight);
            }
            if (!model.SalesInfoList.IsNullOrEmpty())
            {
                insert.Insert(p => p.SalesInfoList == model.SalesInfoList);
            }
            if (!model.Remark.IsNullOrEmpty())
            {
                insert.Insert(p => p.Remark == model.Remark);
            }
            if (!model.IsDelete.IsNullOrEmpty())
            {
                insert.Insert(p => p.IsDelete == model.IsDelete);
            }
            if (!model.SyloonPatent.IsNullOrEmpty())
            {
                insert.Insert(p => p.SyloonPatent == model.SyloonPatent);
            }
            if (!model.EngDescription.IsNullOrEmpty())
            {
                insert.Insert(p => p.EngDescription == model.EngDescription);
            }
            if (!model.TypeInfo.IsNullOrEmpty())
            {
                insert.Insert(p => p.TypeInfo == model.TypeInfo);
            }
            if (!model.PrintFuncInfo.IsNullOrEmpty())
            {
                insert.Insert(p => p.PrintFuncInfo == model.PrintFuncInfo);
            }
            if (!model.Printingdetail.IsNullOrEmpty())
            {
                insert.Insert(p => p.Printingdetail == model.Printingdetail);
            }
            if (!model.PercentageInfo.IsNullOrEmpty())
            {
                insert.Insert(p => p.PercentageInfo == model.PercentageInfo);
            }
            if (!model.TipPercentInfo.IsNullOrEmpty())
            {
                insert.Insert(p => p.TipPercentInfo == model.TipPercentInfo);
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
        public List<Raw_Materials> SelectAll(Raw_Materials model = null, string SelectFiled = null, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var query = new LambdaQuery<Raw_Materials>();
            if (model != null)
            {
                if (!model.Id.IsNullOrEmpty())
                {
                    query.Where(p => p.Id == model.Id);
                }
                if (!model.ProductNo.IsNullOrEmpty())
                {
                    query.Where(p => p.ProductNo == model.ProductNo);
                }
                if (!model.ChinaUnit.IsNullOrEmpty())
                {
                    query.Where(p => p.ChinaUnit == model.ChinaUnit);
                }
                if (!model.ChinaProductName.IsNullOrEmpty())
                {
                    query.Where(p => p.ChinaProductName == model.ChinaProductName);
                }
                if (!model.EnglishUnit.IsNullOrEmpty())
                {
                    query.Where(p => p.EnglishUnit == model.EnglishUnit);
                }
                if (!model.EnglishProductName.IsNullOrEmpty())
                {
                    query.Where(p => p.EnglishProductName == model.EnglishProductName);
                }
                if (!model.HSCODE.IsNullOrEmpty())
                {
                    query.Where(p => p.HSCODE == model.HSCODE);
                }
                if (!model.Attributes.IsNullOrEmpty())
                {
                    query.Where(p => p.Attributes == model.Attributes);
                }
                if (!model.TaxRate.IsNullOrEmpty())
                {
                    query.Where(p => p.TaxRate == model.TaxRate);
                }
                if (!model.Genera.IsNullOrEmpty())
                {
                    query.Where(p => p.Genera == model.Genera);
                }
                if (!model.Specification.IsNullOrEmpty())
                {
                    query.Where(p => p.Specification == model.Specification);
                }
                if (!model.Subclass.IsNullOrEmpty())
                {
                    query.Where(p => p.Subclass == model.Subclass);
                }
                if (!model.MatAndPro.IsNullOrEmpty())
                {
                    query.Where(p => p.MatAndPro == model.MatAndPro);
                }
                if (!model.DeveTime.IsNullOrEmpty())
                {
                    query.Where(p => p.DeveTime == model.DeveTime);
                }
                if (!model.DevePerson.IsNullOrEmpty())
                {
                    query.Where(p => p.DevePerson == model.DevePerson);
                }
                if (!model.Description.IsNullOrEmpty())
                {
                    query.Where(p => p.Description == model.Description);
                }
                if (!model.ProductDesibe.IsNullOrEmpty())
                {
                    query.Where(p => p.ProductDesibe == model.ProductDesibe);
                }
                if (!model.Weight.IsNullOrEmpty())
                {
                    query.Where(p => p.Weight == model.Weight);
                }
                if (!model.NumMiddleBoxes.IsNullOrEmpty())
                {
                    query.Where(p => p.NumMiddleBoxes == model.NumMiddleBoxes);
                }
                if (!model.NumOuterBoxes.IsNullOrEmpty())
                {
                    query.Where(p => p.NumOuterBoxes == model.NumOuterBoxes);
                }
                if (!model.OuterBoxesLength.IsNullOrEmpty())
                {
                    query.Where(p => p.OuterBoxesLength == model.OuterBoxesLength);
                }
                if (!model.OuterBoxesWidth.IsNullOrEmpty())
                {
                    query.Where(p => p.OuterBoxesWidth == model.OuterBoxesWidth);
                }
                if (!model.OuterBoxesHeight.IsNullOrEmpty())
                {
                    query.Where(p => p.OuterBoxesHeight == model.OuterBoxesHeight);
                }
                if (!model.OuterBoxesVolume.IsNullOrEmpty())
                {
                    query.Where(p => p.OuterBoxesVolume == model.OuterBoxesVolume);
                }
                if (!model.NetWeight.IsNullOrEmpty())
                {
                    query.Where(p => p.NetWeight == model.NetWeight);
                }
                if (!model.SalesInfoList.IsNullOrEmpty())
                {
                    query.Where(p => p.SalesInfoList == model.SalesInfoList);
                }
                if (!model.Remark.IsNullOrEmpty())
                {
                    query.Where(p => p.Remark == model.Remark);
                }
                if (!model.IsDelete.IsNullOrEmpty())
                {
                    query.Where(p => p.IsDelete == model.IsDelete);
                }
                if (!model.SyloonPatent.IsNullOrEmpty())
                {
                    query.Where(p => p.SyloonPatent == model.SyloonPatent);
                }
                if (!model.EngDescription.IsNullOrEmpty())
                {
                    query.Where(p => p.EngDescription == model.EngDescription);
                }
                if (!model.TypeInfo.IsNullOrEmpty())
                {
                    query.Where(p => p.TypeInfo == model.TypeInfo);
                }
                if (!model.PrintFuncInfo.IsNullOrEmpty())
                {
                    query.Where(p => p.PrintFuncInfo == model.PrintFuncInfo);
                }
                if (!model.Printingdetail.IsNullOrEmpty())
                {
                    query.Where(p => p.Printingdetail == model.Printingdetail);
                }
                if (!model.PercentageInfo.IsNullOrEmpty())
                {
                    query.Where(p => p.PercentageInfo == model.PercentageInfo);
                }
                if (!model.TipPercentInfo.IsNullOrEmpty())
                {
                    query.Where(p => p.TipPercentInfo == model.TipPercentInfo);
                }
            }
            if (SelectFiled != null)
            {
                SelectFiled = SelectFiled.ToLowerInvariant();
                if (SelectFiled.Contains("id,"))
                {
                    query.Select(p => new { p.Id });
                }
                if (SelectFiled.Contains("productno,"))
                {
                    query.Select(p => new { p.ProductNo });
                }
                if (SelectFiled.Contains("chinaunit,"))
                {
                    query.Select(p => new { p.ChinaUnit });
                }
                if (SelectFiled.Contains("chinaproductname,"))
                {
                    query.Select(p => new { p.ChinaProductName });
                }
                if (SelectFiled.Contains("englishunit,"))
                {
                    query.Select(p => new { p.EnglishUnit });
                }
                if (SelectFiled.Contains("englishproductname,"))
                {
                    query.Select(p => new { p.EnglishProductName });
                }
                if (SelectFiled.Contains("hscode,"))
                {
                    query.Select(p => new { p.HSCODE });
                }
                if (SelectFiled.Contains("attributes,"))
                {
                    query.Select(p => new { p.Attributes });
                }
                if (SelectFiled.Contains("taxrate,"))
                {
                    query.Select(p => new { p.TaxRate });
                }
                if (SelectFiled.Contains("genera,"))
                {
                    query.Select(p => new { p.Genera });
                }
                if (SelectFiled.Contains("specification,"))
                {
                    query.Select(p => new { p.Specification });
                }
                if (SelectFiled.Contains("subclass,"))
                {
                    query.Select(p => new { p.Subclass });
                }
                if (SelectFiled.Contains("matandpro,"))
                {
                    query.Select(p => new { p.MatAndPro });
                }
                if (SelectFiled.Contains("devetime,"))
                {
                    query.Select(p => new { p.DeveTime });
                }
                if (SelectFiled.Contains("deveperson,"))
                {
                    query.Select(p => new { p.DevePerson });
                }
                if (SelectFiled.Contains("description,"))
                {
                    query.Select(p => new { p.Description });
                }
                if (SelectFiled.Contains("productdesibe,"))
                {
                    query.Select(p => new { p.ProductDesibe });
                }
                if (SelectFiled.Contains("weight,"))
                {
                    query.Select(p => new { p.Weight });
                }
                if (SelectFiled.Contains("nummiddleboxes,"))
                {
                    query.Select(p => new { p.NumMiddleBoxes });
                }
                if (SelectFiled.Contains("numouterboxes,"))
                {
                    query.Select(p => new { p.NumOuterBoxes });
                }
                if (SelectFiled.Contains("outerboxeslength,"))
                {
                    query.Select(p => new { p.OuterBoxesLength });
                }
                if (SelectFiled.Contains("outerboxeswidth,"))
                {
                    query.Select(p => new { p.OuterBoxesWidth });
                }
                if (SelectFiled.Contains("outerboxesheight,"))
                {
                    query.Select(p => new { p.OuterBoxesHeight });
                }
                if (SelectFiled.Contains("outerboxesvolume,"))
                {
                    query.Select(p => new { p.OuterBoxesVolume });
                }
                if (SelectFiled.Contains("netweight,"))
                {
                    query.Select(p => new { p.NetWeight });
                }
                if (SelectFiled.Contains("salesinfolist,"))
                {
                    query.Select(p => new { p.SalesInfoList });
                }
                if (SelectFiled.Contains("remark,"))
                {
                    query.Select(p => new { p.Remark });
                }
                if (SelectFiled.Contains("isdelete,"))
                {
                    query.Select(p => new { p.IsDelete });
                }
                if (SelectFiled.Contains("syloonpatent,"))
                {
                    query.Select(p => new { p.SyloonPatent });
                }
                if (SelectFiled.Contains("engdescription,"))
                {
                    query.Select(p => new { p.EngDescription });
                }
                if (SelectFiled.Contains("typeinfo,"))
                {
                    query.Select(p => new { p.TypeInfo });
                }
                if (SelectFiled.Contains("printfuncinfo,"))
                {
                    query.Select(p => new { p.PrintFuncInfo });
                }
                if (SelectFiled.Contains("printingdetail,"))
                {
                    query.Select(p => new { p.Printingdetail });
                }
                if (SelectFiled.Contains("percentageinfo,"))
                {
                    query.Select(p => new { p.PercentageInfo });
                }
                if (SelectFiled.Contains("tippercentinfo,"))
                {
                    query.Select(p => new { p.TipPercentInfo });
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
        public int SelectCount(Raw_Materials model = null, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var query = new LambdaQuery<Raw_Materials>();
            if (model != null)
            {
                if (!model.Id.IsNullOrEmpty())
                {
                    query.Where(p => p.Id == model.Id);
                }
                if (!model.ProductNo.IsNullOrEmpty())
                {
                    query.Where(p => p.ProductNo == model.ProductNo);
                }
                if (!model.ChinaUnit.IsNullOrEmpty())
                {
                    query.Where(p => p.ChinaUnit == model.ChinaUnit);
                }
                if (!model.ChinaProductName.IsNullOrEmpty())
                {
                    query.Where(p => p.ChinaProductName == model.ChinaProductName);
                }
                if (!model.EnglishUnit.IsNullOrEmpty())
                {
                    query.Where(p => p.EnglishUnit == model.EnglishUnit);
                }
                if (!model.EnglishProductName.IsNullOrEmpty())
                {
                    query.Where(p => p.EnglishProductName == model.EnglishProductName);
                }
                if (!model.HSCODE.IsNullOrEmpty())
                {
                    query.Where(p => p.HSCODE == model.HSCODE);
                }
                if (!model.Attributes.IsNullOrEmpty())
                {
                    query.Where(p => p.Attributes == model.Attributes);
                }
                if (!model.TaxRate.IsNullOrEmpty())
                {
                    query.Where(p => p.TaxRate == model.TaxRate);
                }
                if (!model.Genera.IsNullOrEmpty())
                {
                    query.Where(p => p.Genera == model.Genera);
                }
                if (!model.Specification.IsNullOrEmpty())
                {
                    query.Where(p => p.Specification == model.Specification);
                }
                if (!model.Subclass.IsNullOrEmpty())
                {
                    query.Where(p => p.Subclass == model.Subclass);
                }
                if (!model.MatAndPro.IsNullOrEmpty())
                {
                    query.Where(p => p.MatAndPro == model.MatAndPro);
                }
                if (!model.DeveTime.IsNullOrEmpty())
                {
                    query.Where(p => p.DeveTime == model.DeveTime);
                }
                if (!model.DevePerson.IsNullOrEmpty())
                {
                    query.Where(p => p.DevePerson == model.DevePerson);
                }
                if (!model.Description.IsNullOrEmpty())
                {
                    query.Where(p => p.Description == model.Description);
                }
                if (!model.ProductDesibe.IsNullOrEmpty())
                {
                    query.Where(p => p.ProductDesibe == model.ProductDesibe);
                }
                if (!model.Weight.IsNullOrEmpty())
                {
                    query.Where(p => p.Weight == model.Weight);
                }
                if (!model.NumMiddleBoxes.IsNullOrEmpty())
                {
                    query.Where(p => p.NumMiddleBoxes == model.NumMiddleBoxes);
                }
                if (!model.NumOuterBoxes.IsNullOrEmpty())
                {
                    query.Where(p => p.NumOuterBoxes == model.NumOuterBoxes);
                }
                if (!model.OuterBoxesLength.IsNullOrEmpty())
                {
                    query.Where(p => p.OuterBoxesLength == model.OuterBoxesLength);
                }
                if (!model.OuterBoxesWidth.IsNullOrEmpty())
                {
                    query.Where(p => p.OuterBoxesWidth == model.OuterBoxesWidth);
                }
                if (!model.OuterBoxesHeight.IsNullOrEmpty())
                {
                    query.Where(p => p.OuterBoxesHeight == model.OuterBoxesHeight);
                }
                if (!model.OuterBoxesVolume.IsNullOrEmpty())
                {
                    query.Where(p => p.OuterBoxesVolume == model.OuterBoxesVolume);
                }
                if (!model.NetWeight.IsNullOrEmpty())
                {
                    query.Where(p => p.NetWeight == model.NetWeight);
                }
                if (!model.SalesInfoList.IsNullOrEmpty())
                {
                    query.Where(p => p.SalesInfoList == model.SalesInfoList);
                }
                if (!model.Remark.IsNullOrEmpty())
                {
                    query.Where(p => p.Remark == model.Remark);
                }
                if (!model.IsDelete.IsNullOrEmpty())
                {
                    query.Where(p => p.IsDelete == model.IsDelete);
                }
                if (!model.SyloonPatent.IsNullOrEmpty())
                {
                    query.Where(p => p.SyloonPatent == model.SyloonPatent);
                }
                if (!model.EngDescription.IsNullOrEmpty())
                {
                    query.Where(p => p.EngDescription == model.EngDescription);
                }
                if (!model.TypeInfo.IsNullOrEmpty())
                {
                    query.Where(p => p.TypeInfo == model.TypeInfo);
                }
                if (!model.PrintFuncInfo.IsNullOrEmpty())
                {
                    query.Where(p => p.PrintFuncInfo == model.PrintFuncInfo);
                }
                if (!model.Printingdetail.IsNullOrEmpty())
                {
                    query.Where(p => p.Printingdetail == model.Printingdetail);
                }
                if (!model.PercentageInfo.IsNullOrEmpty())
                {
                    query.Where(p => p.PercentageInfo == model.PercentageInfo);
                }
                if (!model.TipPercentInfo.IsNullOrEmpty())
                {
                    query.Where(p => p.TipPercentInfo == model.TipPercentInfo);
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
        public Raw_Materials SelectById(int KeyId, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var query = new LambdaQuery<Raw_Materials>();
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
        public List<Raw_Materials> SelectByKeys(string Key,List<string> KeyIds, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var query = new LambdaQuery<Raw_Materials>();
            if("id" == Key.ToLowerInvariant())
            {
                query.Where(p => p.Id.In(KeyIds));
            }
            if("productno" == Key.ToLowerInvariant())
            {
                query.Where(p => p.ProductNo.In(KeyIds));
            }
            if("chinaunit" == Key.ToLowerInvariant())
            {
                query.Where(p => p.ChinaUnit.In(KeyIds));
            }
            if("chinaproductname" == Key.ToLowerInvariant())
            {
                query.Where(p => p.ChinaProductName.In(KeyIds));
            }
            if("englishunit" == Key.ToLowerInvariant())
            {
                query.Where(p => p.EnglishUnit.In(KeyIds));
            }
            if("englishproductname" == Key.ToLowerInvariant())
            {
                query.Where(p => p.EnglishProductName.In(KeyIds));
            }
            if("hscode" == Key.ToLowerInvariant())
            {
                query.Where(p => p.HSCODE.In(KeyIds));
            }
            if("attributes" == Key.ToLowerInvariant())
            {
                query.Where(p => p.Attributes.In(KeyIds));
            }
            if("taxrate" == Key.ToLowerInvariant())
            {
                query.Where(p => p.TaxRate.In(KeyIds));
            }
            if("genera" == Key.ToLowerInvariant())
            {
                query.Where(p => p.Genera.In(KeyIds));
            }
            if("specification" == Key.ToLowerInvariant())
            {
                query.Where(p => p.Specification.In(KeyIds));
            }
            if("subclass" == Key.ToLowerInvariant())
            {
                query.Where(p => p.Subclass.In(KeyIds));
            }
            if("matandpro" == Key.ToLowerInvariant())
            {
                query.Where(p => p.MatAndPro.In(KeyIds));
            }
            if("devetime" == Key.ToLowerInvariant())
            {
                query.Where(p => p.DeveTime.In(KeyIds));
            }
            if("deveperson" == Key.ToLowerInvariant())
            {
                query.Where(p => p.DevePerson.In(KeyIds));
            }
            if("description" == Key.ToLowerInvariant())
            {
                query.Where(p => p.Description.In(KeyIds));
            }
            if("productdesibe" == Key.ToLowerInvariant())
            {
                query.Where(p => p.ProductDesibe.In(KeyIds));
            }
            if("weight" == Key.ToLowerInvariant())
            {
                query.Where(p => p.Weight.In(KeyIds));
            }
            if("nummiddleboxes" == Key.ToLowerInvariant())
            {
                query.Where(p => p.NumMiddleBoxes.In(KeyIds));
            }
            if("numouterboxes" == Key.ToLowerInvariant())
            {
                query.Where(p => p.NumOuterBoxes.In(KeyIds));
            }
            if("outerboxeslength" == Key.ToLowerInvariant())
            {
                query.Where(p => p.OuterBoxesLength.In(KeyIds));
            }
            if("outerboxeswidth" == Key.ToLowerInvariant())
            {
                query.Where(p => p.OuterBoxesWidth.In(KeyIds));
            }
            if("outerboxesheight" == Key.ToLowerInvariant())
            {
                query.Where(p => p.OuterBoxesHeight.In(KeyIds));
            }
            if("outerboxesvolume" == Key.ToLowerInvariant())
            {
                query.Where(p => p.OuterBoxesVolume.In(KeyIds));
            }
            if("netweight" == Key.ToLowerInvariant())
            {
                query.Where(p => p.NetWeight.In(KeyIds));
            }
            if("salesinfolist" == Key.ToLowerInvariant())
            {
                query.Where(p => p.SalesInfoList.In(KeyIds));
            }
            if("remark" == Key.ToLowerInvariant())
            {
                query.Where(p => p.Remark.In(KeyIds));
            }
            if("isdelete" == Key.ToLowerInvariant())
            {
                query.Where(p => p.IsDelete.In(KeyIds));
            }
            if("syloonpatent" == Key.ToLowerInvariant())
            {
                query.Where(p => p.SyloonPatent.In(KeyIds));
            }
            if("engdescription" == Key.ToLowerInvariant())
            {
                query.Where(p => p.EngDescription.In(KeyIds));
            }
            if("typeinfo" == Key.ToLowerInvariant())
            {
                query.Where(p => p.TypeInfo.In(KeyIds));
            }
            if("printfuncinfo" == Key.ToLowerInvariant())
            {
                query.Where(p => p.PrintFuncInfo.In(KeyIds));
            }
            if("printingdetail" == Key.ToLowerInvariant())
            {
                query.Where(p => p.Printingdetail.In(KeyIds));
            }
            if("percentageinfo" == Key.ToLowerInvariant())
            {
                query.Where(p => p.PercentageInfo.In(KeyIds));
            }
            if("tippercentinfo" == Key.ToLowerInvariant())
            {
                query.Where(p => p.TipPercentInfo.In(KeyIds));
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
        public List<Raw_Materials> SelectByPage(string Key, int start, int PageSize, bool desc = true,Raw_Materials model = null, string SelectFiled = null, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var query = new LambdaQuery<Raw_Materials>();
            if (model != null)
            {
                if (!model.Id.IsNullOrEmpty())
                {
                    query.Where(p => p.Id == model.Id);
                }
                if (!model.ProductNo.IsNullOrEmpty())
                {
                    query.Where(p => p.ProductNo == model.ProductNo);
                }
                if (!model.ChinaUnit.IsNullOrEmpty())
                {
                    query.Where(p => p.ChinaUnit == model.ChinaUnit);
                }
                if (!model.ChinaProductName.IsNullOrEmpty())
                {
                    query.Where(p => p.ChinaProductName == model.ChinaProductName);
                }
                if (!model.EnglishUnit.IsNullOrEmpty())
                {
                    query.Where(p => p.EnglishUnit == model.EnglishUnit);
                }
                if (!model.EnglishProductName.IsNullOrEmpty())
                {
                    query.Where(p => p.EnglishProductName == model.EnglishProductName);
                }
                if (!model.HSCODE.IsNullOrEmpty())
                {
                    query.Where(p => p.HSCODE == model.HSCODE);
                }
                if (!model.Attributes.IsNullOrEmpty())
                {
                    query.Where(p => p.Attributes == model.Attributes);
                }
                if (!model.TaxRate.IsNullOrEmpty())
                {
                    query.Where(p => p.TaxRate == model.TaxRate);
                }
                if (!model.Genera.IsNullOrEmpty())
                {
                    query.Where(p => p.Genera == model.Genera);
                }
                if (!model.Specification.IsNullOrEmpty())
                {
                    query.Where(p => p.Specification == model.Specification);
                }
                if (!model.Subclass.IsNullOrEmpty())
                {
                    query.Where(p => p.Subclass == model.Subclass);
                }
                if (!model.MatAndPro.IsNullOrEmpty())
                {
                    query.Where(p => p.MatAndPro == model.MatAndPro);
                }
                if (!model.DeveTime.IsNullOrEmpty())
                {
                    query.Where(p => p.DeveTime == model.DeveTime);
                }
                if (!model.DevePerson.IsNullOrEmpty())
                {
                    query.Where(p => p.DevePerson == model.DevePerson);
                }
                if (!model.Description.IsNullOrEmpty())
                {
                    query.Where(p => p.Description == model.Description);
                }
                if (!model.ProductDesibe.IsNullOrEmpty())
                {
                    query.Where(p => p.ProductDesibe == model.ProductDesibe);
                }
                if (!model.Weight.IsNullOrEmpty())
                {
                    query.Where(p => p.Weight == model.Weight);
                }
                if (!model.NumMiddleBoxes.IsNullOrEmpty())
                {
                    query.Where(p => p.NumMiddleBoxes == model.NumMiddleBoxes);
                }
                if (!model.NumOuterBoxes.IsNullOrEmpty())
                {
                    query.Where(p => p.NumOuterBoxes == model.NumOuterBoxes);
                }
                if (!model.OuterBoxesLength.IsNullOrEmpty())
                {
                    query.Where(p => p.OuterBoxesLength == model.OuterBoxesLength);
                }
                if (!model.OuterBoxesWidth.IsNullOrEmpty())
                {
                    query.Where(p => p.OuterBoxesWidth == model.OuterBoxesWidth);
                }
                if (!model.OuterBoxesHeight.IsNullOrEmpty())
                {
                    query.Where(p => p.OuterBoxesHeight == model.OuterBoxesHeight);
                }
                if (!model.OuterBoxesVolume.IsNullOrEmpty())
                {
                    query.Where(p => p.OuterBoxesVolume == model.OuterBoxesVolume);
                }
                if (!model.NetWeight.IsNullOrEmpty())
                {
                    query.Where(p => p.NetWeight == model.NetWeight);
                }
                if (!model.SalesInfoList.IsNullOrEmpty())
                {
                    query.Where(p => p.SalesInfoList == model.SalesInfoList);
                }
                if (!model.Remark.IsNullOrEmpty())
                {
                    query.Where(p => p.Remark == model.Remark);
                }
                if (!model.IsDelete.IsNullOrEmpty())
                {
                    query.Where(p => p.IsDelete == model.IsDelete);
                }
                if (!model.SyloonPatent.IsNullOrEmpty())
                {
                    query.Where(p => p.SyloonPatent == model.SyloonPatent);
                }
                if (!model.EngDescription.IsNullOrEmpty())
                {
                    query.Where(p => p.EngDescription == model.EngDescription);
                }
                if (!model.TypeInfo.IsNullOrEmpty())
                {
                    query.Where(p => p.TypeInfo == model.TypeInfo);
                }
                if (!model.PrintFuncInfo.IsNullOrEmpty())
                {
                    query.Where(p => p.PrintFuncInfo == model.PrintFuncInfo);
                }
                if (!model.Printingdetail.IsNullOrEmpty())
                {
                    query.Where(p => p.Printingdetail == model.Printingdetail);
                }
                if (!model.PercentageInfo.IsNullOrEmpty())
                {
                    query.Where(p => p.PercentageInfo == model.PercentageInfo);
                }
                if (!model.TipPercentInfo.IsNullOrEmpty())
                {
                    query.Where(p => p.TipPercentInfo == model.TipPercentInfo);
                }
            }
            if (SelectFiled != null)
            {
                SelectFiled = SelectFiled.ToLowerInvariant();
                if (SelectFiled.Contains("id,"))
                {
                    query.Select(p => new { p.Id });
                }
                if (SelectFiled.Contains("productno,"))
                {
                    query.Select(p => new { p.ProductNo });
                }
                if (SelectFiled.Contains("chinaunit,"))
                {
                    query.Select(p => new { p.ChinaUnit });
                }
                if (SelectFiled.Contains("chinaproductname,"))
                {
                    query.Select(p => new { p.ChinaProductName });
                }
                if (SelectFiled.Contains("englishunit,"))
                {
                    query.Select(p => new { p.EnglishUnit });
                }
                if (SelectFiled.Contains("englishproductname,"))
                {
                    query.Select(p => new { p.EnglishProductName });
                }
                if (SelectFiled.Contains("hscode,"))
                {
                    query.Select(p => new { p.HSCODE });
                }
                if (SelectFiled.Contains("attributes,"))
                {
                    query.Select(p => new { p.Attributes });
                }
                if (SelectFiled.Contains("taxrate,"))
                {
                    query.Select(p => new { p.TaxRate });
                }
                if (SelectFiled.Contains("genera,"))
                {
                    query.Select(p => new { p.Genera });
                }
                if (SelectFiled.Contains("specification,"))
                {
                    query.Select(p => new { p.Specification });
                }
                if (SelectFiled.Contains("subclass,"))
                {
                    query.Select(p => new { p.Subclass });
                }
                if (SelectFiled.Contains("matandpro,"))
                {
                    query.Select(p => new { p.MatAndPro });
                }
                if (SelectFiled.Contains("devetime,"))
                {
                    query.Select(p => new { p.DeveTime });
                }
                if (SelectFiled.Contains("deveperson,"))
                {
                    query.Select(p => new { p.DevePerson });
                }
                if (SelectFiled.Contains("description,"))
                {
                    query.Select(p => new { p.Description });
                }
                if (SelectFiled.Contains("productdesibe,"))
                {
                    query.Select(p => new { p.ProductDesibe });
                }
                if (SelectFiled.Contains("weight,"))
                {
                    query.Select(p => new { p.Weight });
                }
                if (SelectFiled.Contains("nummiddleboxes,"))
                {
                    query.Select(p => new { p.NumMiddleBoxes });
                }
                if (SelectFiled.Contains("numouterboxes,"))
                {
                    query.Select(p => new { p.NumOuterBoxes });
                }
                if (SelectFiled.Contains("outerboxeslength,"))
                {
                    query.Select(p => new { p.OuterBoxesLength });
                }
                if (SelectFiled.Contains("outerboxeswidth,"))
                {
                    query.Select(p => new { p.OuterBoxesWidth });
                }
                if (SelectFiled.Contains("outerboxesheight,"))
                {
                    query.Select(p => new { p.OuterBoxesHeight });
                }
                if (SelectFiled.Contains("outerboxesvolume,"))
                {
                    query.Select(p => new { p.OuterBoxesVolume });
                }
                if (SelectFiled.Contains("netweight,"))
                {
                    query.Select(p => new { p.NetWeight });
                }
                if (SelectFiled.Contains("salesinfolist,"))
                {
                    query.Select(p => new { p.SalesInfoList });
                }
                if (SelectFiled.Contains("remark,"))
                {
                    query.Select(p => new { p.Remark });
                }
                if (SelectFiled.Contains("isdelete,"))
                {
                    query.Select(p => new { p.IsDelete });
                }
                if (SelectFiled.Contains("syloonpatent,"))
                {
                    query.Select(p => new { p.SyloonPatent });
                }
                if (SelectFiled.Contains("engdescription,"))
                {
                    query.Select(p => new { p.EngDescription });
                }
                if (SelectFiled.Contains("typeinfo,"))
                {
                    query.Select(p => new { p.TypeInfo });
                }
                if (SelectFiled.Contains("printfuncinfo,"))
                {
                    query.Select(p => new { p.PrintFuncInfo });
                }
                if (SelectFiled.Contains("printingdetail,"))
                {
                    query.Select(p => new { p.Printingdetail });
                }
                if (SelectFiled.Contains("percentageinfo,"))
                {
                    query.Select(p => new { p.PercentageInfo });
                }
                if (SelectFiled.Contains("tippercentinfo,"))
                {
                    query.Select(p => new { p.TipPercentInfo });
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
