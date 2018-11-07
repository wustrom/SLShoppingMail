using Common;
using Common.Extend;
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
    /// <summary>
    /// 采购入库,还要根据颜色进行筛选入库
    /// </summary>
    public partial class BuyerDetailedFunc : SingleTon<BuyerDetailedFunc>
    {
        /// <summary>
        /// 根据Id插入
        /// </summary>
        /// <param name="Id">用户Id</param>
        /// <returns></returns>
        public bool InsertBuyerDetailed(int WarehouseId, int deliverId, string RuKuNum)
        {
            var MysqlHelper = SqlHelper.GetMySqlHelper("transaction");
            var connection = MysqlHelper.CreatConn();
            var transaction = MysqlHelper.GetTransaction();
            try
            {
                #region 
                if (CreateStorage(WarehouseId, deliverId, RuKuNum, connection, transaction))
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
        private bool CreateStorage(int WarehouseId, int deliverId, string RuKuNum, IDbConnection connection, IDbTransaction transaction)
        {

            #region 筛选出传入参数信息,若无数据则返回false
            var deliver = DeliverOper.Instance.SelectById(deliverId, connection, transaction);
            var Warehouse = WarehouseOper.Instance.SelectById(WarehouseId, connection, transaction);
            if (deliver == null || Warehouse == null || deliver.IsStatus == "已入库")
            {
                return false;
            }
            #endregion

            var storage = StorageOper.Instance.SelectAll(new Storage { Raw_materialsId = deliver.Raw_materialsId, WarehouseId = WarehouseId, Color = deliver.Color }, null, connection, transaction).FirstOrDefault();
            var returnKey = 0;
            var ChangeAfterCount = 0;

            #region 若无记录则插入
            if (storage == null)
            {
                storage = new Storage { Raw_materialsId = deliver.Raw_materialsId, WarehouseId = WarehouseId, freeze_stock = 0, stock = RuKuNum.ParseInt(), Color = deliver.Color };
                returnKey = StorageOper.Instance.InsertReturnKey(storage, connection, transaction);
                ChangeAfterCount = deliver.buyerCount.Value;
                if (returnKey <= 0)
                {
                    return false;
                }
            }
            #endregion

            #region 若有记录则修改
            else
            {
                storage.stock = storage.stock +RuKuNum.ParseInt();
                ChangeAfterCount = storage.stock.Value;
                returnKey = storage.Id;
                if (!StorageOper.Instance.Update(storage, connection, transaction))
                {
                    return false;
                }
            }
            #endregion

            #region 变动处理
            Changestorage info = new Changestorage
            {
                storageId = returnKey,
                ChangeTime = DateTime.Now,
                ChangeType = "采购入库",
                ChangeAfterCount = ChangeAfterCount,
                ChangeCount = "增加" + RuKuNum,
            };
            if (!ChangestorageOper.Instance.Insert(info, connection, transaction))
            {
                return false;
            }
            #endregion

            #region 修改入库状态
            deliver.IsStatus = "已入库";
            if (!DeliverOper.Instance.Update(deliver, connection, transaction))
            {
                return false;
            }
            //判断是否全部入库,则修改采购表状态
            if (DeliverOper.Instance.SelectAll(new Deliver { buyerId = deliver.buyerId.Value, IsStatus = "待入库" }, null, connection, transaction).Count == 0)
            {
                ////账期
                //var AccountPeriod = Buyer_Producer_ViewOper.Instance.SelectById(deliver.Id).AccountPeriod;
                if (!BuyerOper.Instance.Update(new Buyer { Id = deliver.buyerId.Value, buyerStatus = "已入库", wantmoney = 0 }, connection, transaction))
                {
                    return false;
                }
            }
            #endregion

            return true;

        }
    }
}
