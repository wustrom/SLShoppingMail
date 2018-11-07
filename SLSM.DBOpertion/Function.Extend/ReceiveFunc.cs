using Common;
using Common.Helper;
using DbOpertion.Models;
using DbOpertion.Operation;
using SLSM.DBOpertion.Model.Request.Material;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbOpertion.Function
{
    public partial class ReceiveFunc : SingleTon<ReceiveFunc>
    {
        /// <summary>
        /// 筛选
        /// </summary>
        /// <returns></returns>
        public Tuple<List<Receive_Order_View>, int> SelectBuyer(int PageIndex, int PageSize, string Order, string sort, string Name)
        {
            return new Tuple<List<Receive_Order_View>, int>(item1: Receive_Order_ViewOper.Instance.SelectReceivePage(sort, (PageIndex - 1) * PageSize, PageSize, Order == "desc" ? true : false, Name),
                                                       item2: Receive_Order_ViewOper.Instance.SelectReceiveCount(Name));
        }
        /// <summary>
        /// 筛选单个
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public Receive_Order_View SelectReceiveById(int Id)
        {
            return Receive_Order_ViewOper.Instance.SelectAll(new Receive_Order_View {Id=Id }).FirstOrDefault();
        }

        /// <summary>
        /// 筛选单个
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public Receive_Order_View SelectReceiveByDetailId(int Id)
        {
            return Receive_Order_ViewOper.Instance.SelectAll(new Receive_Order_View { order_detailId = Id }).FirstOrDefault();
        }
        /// <summary>
        /// 筛选生产领料详情
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public List<Receive_Raw_View> SelectReceiveDetailed(int Id)
        {
            return Receive_Raw_ViewOper.Instance.SelectAll(new Receive_Raw_View { productionId = Id });
        }
        /// <summary>
        /// 筛选待申请
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public List<Production_Orderdetail_View> SelecOrderDetailed(int Id)
        {
            return Production_Orderdetail_ViewOper.Instance.SelectAll(new Production_Orderdetail_View { Id = Id });
        }

        /// <summary>
        /// 筛选待申请
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public Receive SelecReceive(int Id)
        {
            return ReceiveOper.Instance.SelectAll(new Receive { ProductionId = Id }).FirstOrDefault();
        }
        /// <summary>
        /// 判断库存数量
        /// </summary>
        /// <param name="WarehouseId"></param>
        /// <param name="receive_materialsId"></param>
        /// <returns></returns>
        public bool SelectWarehousInfo(int WarehouseId, int receive_materialsId)
        {
            var Receive_Material = Receive_MaterialsOper.Instance.SelectById(receive_materialsId);
            var Raw_materialsId = Receive_Material.Id;
            //判断该库存管理信息,选择的仓库是否存在该商品
            var Storage_Views = Storage_ViewOper.Instance.SelectAll(new Storage_View { WarehouseId = WarehouseId, Raw_materialsId = Raw_materialsId }).FirstOrDefault();
            if (Storage_Views != null)
            {
                //存在,进行仓库数量比较
                var Receive_Material_stock = Receive_Material.additionalCount;
                var Storage_stock = Storage_Views.stock - Storage_Views.freeze_stock;
                if (Receive_Material_stock <= Storage_stock)
                {
                    return true;
                }
            }
            return false;
        }

        #region 领料单出库
        public bool UpdateStorageDeceive(int ReceiveId)
        {

            var MysqlHelper = SqlHelper.GetMySqlHelper("transaction");
            var connection = MysqlHelper.CreatConn();
            var transaction = MysqlHelper.GetTransaction();
            try
            {
                #region 
                if (UpdateStorage(ReceiveId, connection, transaction))
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

        public bool UpdateStorage(int ReceiveId, IDbConnection connection, IDbTransaction transaction)
        {
            var Stock = 0;
            var List_Storage = new List<Storage_View>();
            //查找到所有生产领料表Id
            var Receive_Material = Receive_MaterialsOper.Instance.SelectAll(new Receive_Materials { receiveId = ReceiveId }, null, connection, transaction);
            //查找该表的所有库存数据(颜色)
            List_Storage = Storage_ViewOper.Instance.SelectByKeys("Raw_materialsId", Receive_Material.Where(p => p.raw_materialsId != null).Select(p => p.raw_materialsId.Value.ToString()).ToList(), connection, transaction);
            foreach (var item in Receive_Material)
            {
                var Count = item.BaseCount + item.additionalCount;
                var thisList_Storage = List_Storage.Where(p => p.Raw_materialsId == item.raw_materialsId && p.Color == item.SKU).ToList();
                if (Count > 0)
                {
                    //查找跟生产领料表Id对应的库存Id             
                    for (var i = 0; i < thisList_Storage.Count; i++)
                    {
                        //判断是否要从其他仓库出库
                        if (Count > thisList_Storage[i].freeze_stock)
                        {
                            Count -= thisList_Storage[i].freeze_stock;
                            StorageOper.Instance.Update(new Storage { Id = thisList_Storage[i].Id.Value, freeze_stock = 0, stock = thisList_Storage[i].stock - thisList_Storage[i].freeze_stock }, connection, transaction);
                            #region 变动处理
                            Changestorage infos = new Changestorage
                            {
                                storageId = thisList_Storage[i].Id.Value,
                                ChangeTime = DateTime.Now,
                                ChangeType = "生产领料",
                                ChangeAfterCount = thisList_Storage[i].stock - thisList_Storage[i].freeze_stock,
                                ChangeCount = "减少" + thisList_Storage[i].freeze_stock,
                            };
                            if (!ChangestorageOper.Instance.Insert(infos, connection, transaction))
                            {
                                return false;
                            }
                            #endregion
                            //所有库存都比冻结库存少
                            if (i == (List_Storage.Count - 1) && Count != 0)
                            {
                                return false;
                            }
                        }
                        else if (Count != 0)
                        {
                            StorageOper.Instance.Update(new Storage { Id = thisList_Storage[i].Id.Value, freeze_stock = thisList_Storage[i].freeze_stock - Count, stock = thisList_Storage[i].stock - Count }, connection, transaction);
                            #region 变动处理
                            Changestorage infos = new Changestorage
                            {
                                storageId = List_Storage[i].Id.Value,
                                ChangeTime = DateTime.Now,
                                ChangeType = "生产领料",
                                ChangeAfterCount = List_Storage[i].stock - Count,
                                ChangeCount = "减少" + Count,
                            };
                            if (!ChangestorageOper.Instance.Insert(infos, connection, transaction))
                            {
                                Stock = (thisList_Storage[i].freeze_stock - Count).Value;
                                if (Stock == 0)
                                {
                                    return false;
                                }
                            }
                            #endregion
                        }
                    }
                }
            }
            #region 修改订单状态
            Receive receive = new Receive
            {
                Id = ReceiveId,
                receiveOutTime = DateTime.Now,
                receiveStatus = "已出库"
            };
            if (!ReceiveOper.Instance.Update(receive, connection, transaction))
            {
                return false;
            }
            #endregion
            return true;
        }
        #endregion

        #region 领料单申请
        public bool ApplyStorageDeceive(int productionId, List<MaterInfo> MaterInfoList, string receiveSinglePerson, DateTime receiveSingleTime)
        {

            var MysqlHelper = SqlHelper.GetMySqlHelper("transaction");
            var connection = MysqlHelper.CreatConn();
            var transaction = MysqlHelper.GetTransaction();
            try
            {
                #region 
                if (ApplyStorage(productionId, MaterInfoList, receiveSinglePerson, receiveSingleTime, connection, transaction))
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

        public bool ApplyStorage(int productionId, List<MaterInfo> MaterInfoList, string receiveSinglePerson, DateTime receiveSingleTime, IDbConnection connection, IDbTransaction transaction)
        {
            var StockList = Materials_Stock_ViewOper.Instance.SelectAll(null, null, connection, transaction);
            var StorageList = StorageOper.Instance.SelectAll(null, null, connection, transaction);
            var Receive = ReceiveOper.Instance.SelectAll(new Receive { ProductionId = productionId }, null, connection, transaction).FirstOrDefault();
            if (Receive != null)
            {
                #region 还原库存
                if (Receive.receiveStatus == "待出库")
                {
                    ReceiveOper.Instance.DeleteById(Receive.Id, connection, transaction);
                    var Receive_Materials = Receive_MaterialsOper.Instance.SelectAll(new Models.Receive_Materials { receiveId = Receive.Id });
                    foreach (var item in Receive_Materials)
                    {
                        if (item.additionalCount > 0)
                        {
                            #region 判断库存是否足够
                            var Stock = StockList.Where(p => p.Raw_materialsId == item.raw_materialsId && p.SKU == item.SKU).FirstOrDefault();

                            if (Stock == null || (Stock.freeze_stock == null ? 0 : Stock.freeze_stock) < item.additionalCount)
                            {
                                return false;
                            }
                            var ThisStorageList = StorageList.Where(p => p.Raw_materialsId == item.raw_materialsId && p.Color == Stock.SKU).ToList();
                            #region 修改库存数量
                            var Amount = item.additionalCount;
                            foreach (var Storage in ThisStorageList)
                            {
                                if (Amount < Storage.freeze_stock)
                                {
                                    Storage.freeze_stock = Storage.freeze_stock - Amount;
                                    Amount = 0;
                                    if (!StorageOper.Instance.Update(Storage, connection, transaction))
                                    {
                                        return false;
                                    }
                                    break;
                                }
                                else
                                {
                                    Storage.freeze_stock = 0;
                                    Amount = Amount - Storage.freeze_stock.Value;
                                    if (!StorageOper.Instance.Update(Storage, connection, transaction))
                                    {
                                        return false;
                                    }
                                }
                            }
                            #endregion
                            #endregion
                        }
                    }
                }
                #endregion
                else
                {
                    return false;
                }
            }
            var resultkey = ReceiveOper.Instance.InsertReturnKey(new Receive { ProductionId = productionId, receiveTime = DateTime.Now, receiveStatus = "待出库", receiveSinglePerson = receiveSinglePerson, receiveSingleTime = receiveSingleTime }, connection, transaction);
            if (resultkey <= 0)
            {
                return false;
            }
            foreach (var item in MaterInfoList)
            {
                if (!Receive_MaterialsOper.Instance.Insert(new Receive_Materials { receiveId = resultkey, additionalCount = item.additionalCount, Isadditional = item.Isadditional, BaseCount = item.BaseCount, raw_materialsId = item.MaterInfoId, SKU = item.SKU }, connection, transaction))
                {
                    return false;
                }
                if (item.additionalCount > 0)
                {
                    #region 判断库存是否足够
                    var Stock = StockList.Where(p => p.Raw_materialsId == item.MaterInfoId && p.SKU == item.SKU).FirstOrDefault();
                    if (Stock == null || (Stock.available_stock == null ? 0 : Stock.available_stock) < item.additionalCount)
                    {
                        return false;
                    }
                    var ThisStorageList = StorageList.Where(p => p.Raw_materialsId == item.MaterInfoId && p.Color == Stock.SKU).ToList();
                    #region 修改库存数量
                    var Amount = item.additionalCount;
                    foreach (var Storage in ThisStorageList)
                    {
                        if (Storage.stock > Storage.freeze_stock)
                        {
                            if ((Amount + Storage.freeze_stock) < Storage.stock)
                            {
                                Storage.freeze_stock = Storage.freeze_stock + Amount;
                                Amount = 0;
                                if (!StorageOper.Instance.Update(Storage, connection, transaction))
                                {
                                    return false;
                                }
                                break;
                            }
                            else
                            {
                                Amount = Amount - Storage.stock.Value + Storage.freeze_stock.Value;
                                Storage.freeze_stock = Storage.stock;
                               
                                if (!StorageOper.Instance.Update(Storage, connection, transaction))
                                {
                                    return false;
                                }
                            }
                        }
                    }
                    if (Amount > 0)
                    {
                        return false;
                    }
                    #endregion
                    #endregion
                }
            }
            return true;

        }
        #endregion
    }
}
