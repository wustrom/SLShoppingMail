using Common;
using Common.Helper;
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
    public partial class ChangesFunc : SingleTon<ChangesFunc>
    {
        /// <summary>
        /// 根据Id插入
        /// </summary>
        /// <param name="Id">用户Id</param>
        /// <returns></returns>
        public bool InsertStorageChange(string ChangeContext, string ChangeCountType, int ChangeCount, int StorageId, int WarehouseId, int RawmaterialsId, string SKU)
        {

            var MysqlHelper = SqlHelper.GetMySqlHelper("transaction");
            var connection = MysqlHelper.CreatConn();
            var transaction = MysqlHelper.GetTransaction();

            try
            {
                #region 
                if (CreateChange(ChangeContext, ChangeCountType, ChangeCount, connection, transaction, StorageId, WarehouseId, RawmaterialsId, SKU))
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

        /// <summary>
        /// 创建记录改变
        /// </summary>
        /// <param name="ChangeContext"></param>
        /// <param name="ChangeCountType"></param>
        /// <param name="ChangeCount"></param>
        /// <param name="connection"></param>
        /// <param name="transaction"></param>
        /// <param name="StorageId"></param>
        /// <param name="WarehouseId"></param>
        /// <param name="RawmaterialsId"></param>
        /// <param name="SKU"></param>
        /// <returns></returns>
        private bool CreateChange(string ChangeContext, string ChangeCountType, int ChangeCount, IDbConnection connection, IDbTransaction transaction, int StorageId, int WarehouseId, int RawmaterialsId, string SKU)
        {
            Storage storage;
            #region 若没有库存则新增库存
            if (StorageId == 0)
            {
                storage = StorageOper.Instance.SelectAll(new Storage { Color = SKU, Raw_materialsId = RawmaterialsId, WarehouseId = WarehouseId }, null, connection, transaction).FirstOrDefault();
                if (storage != null)
                {
                    StorageId = storage.Id;
                }
                else
                {
                    storage = new Storage { Color = SKU, Raw_materialsId = RawmaterialsId, WarehouseId = WarehouseId, stock = 0, freeze_stock = 0 };
                    StorageId = StorageOper.Instance.InsertReturnKey(storage, connection, transaction);
                    storage.Id = StorageId;
                    if (StorageId <= 0)
                    {
                        return false;
                    }
                }
            }
            #endregion
            else
            {
                storage = StorageOper.Instance.SelectById(StorageId);
            }
            //判断是增加类型还是减少类型
            var stock = storage.stock.Value;
            var stocks = 0;
            if (ChangeCountType == "增加")
            {
                stocks = stock + ChangeCount;
            }
            else
            {
                stocks = stock - ChangeCount;
                if (stocks < 0)
                {
                    return false;
                }
            }
            #region 变动处理
            Changestorage info = new Changestorage
            {
                storageId = StorageId,
                ChangeTime = DateTime.Now,
                ChangeType = "手动输入调整",
                ChangeAfterCount = stocks,
                ChangeCount = ChangeCountType + ChangeCount,
                ChangeContext = ChangeContext
            };
            var OrderKey = ChangestorageOper.Instance.InsertReturnKey(info, connection, transaction);
            if (OrderKey <= 0)
            {
                return false;
            }
            #endregion

            #region 仓库处理
            Storage stor = new Storage
            {
                Id = StorageId,
                stock = stocks
            };
            if (!StorageOper.Instance.Update(stor, connection, transaction))
            {
                return false;
            }
            #endregion

            return true;
        }
        /// <summary>
        /// 分页筛选未删除库存统计
        /// </summary>
        /// <returns></returns>
        public Tuple<List<Changestorage>, int> SelectChange(int PageIndex, int PageSize, string Order, string sort, string Name, int storageId)
        {
            return new Tuple<List<Changestorage>, int>(item1: ChangeStorageOper.Instance.SelectChangePage(sort, (PageIndex - 1) * PageSize, PageSize, Order == "desc" ? true : false, Name, storageId), item2: ChangeStorageOper.Instance.SelectChangeCount(Name, storageId));
        }
    }
}
