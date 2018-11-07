using Common;
using Common.Helper;
using Common.LambdaOpertion;
using DbOpertion.Models;
using DbOpertion.Operation;
using SLSM.DBOpertion.Model.Extend.Request.Purchasing;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbOpertion.Function
{
    public partial class BuyerFunc : SingleTon<BuyerFunc>
    {
        /// <summary>
        /// 筛选采购单
        /// </summary>
        /// <returns></returns>
        public Tuple<List<Buyer_Producer_View>, int> SelectAllBuyer(int PageIndex, int PageSize, string Order, string sort, string Name, string ProduterId, DateTime StartTime, DateTime EndTime, string CheckStatus)
        {
            return new Tuple<List<Buyer_Producer_View>, int>(item1: Buyer_Producer_ViewOper.Instance.SelectAllBuyerPage(sort, (PageIndex - 1) * PageSize, PageSize, Order == "desc" ? true : false, Name, ProduterId, StartTime, EndTime, CheckStatus),
                                                       item2: Buyer_Producer_ViewOper.Instance.SelectAllBuyerCount(Name, ProduterId, StartTime, EndTime, CheckStatus));
        }

        /// <summary>
        /// 筛选采购入库
        /// </summary>
        /// <returns></returns>
        public Tuple<List<Buyer_Producer_View>, int> SelectBuyer(int PageIndex, int PageSize, string Order, string sort, string Name)
        {
            return new Tuple<List<Buyer_Producer_View>, int>(item1: Buyer_Producer_ViewOper.Instance.SelectBuyerPage(sort, (PageIndex - 1) * PageSize, PageSize, Order == "desc" ? true : false, Name),
                                                       item2: Buyer_Producer_ViewOper.Instance.SelectBuyerCount(Name));
        }

        /// <summary>
        /// 筛选财务管理
        /// </summary>
        /// <param name="PageIndex"></param>
        /// <param name="PageSize"></param>
        /// <param name="Order"></param>
        /// <param name="sort"></param>
        /// <param name="Name"></param>
        /// <returns></returns>
        public Tuple<List<Buyer_Producer_View>, int> SelectBuyerFinance(int PageIndex, int PageSize, string Order, string sort, string Name, string ProduterId, DateTime StartTime, DateTime EndTime)
        {
            return new Tuple<List<Buyer_Producer_View>, int>(item1: Buyer_Producer_ViewOper.Instance.SelectFinancePage(sort, (PageIndex - 1) * PageSize, PageSize, Order == "desc" ? true : false, Name, ProduterId, StartTime, EndTime),
                                                       item2: Buyer_Producer_ViewOper.Instance.SelectFinanceCount(Name, ProduterId, StartTime, EndTime));
        }
        /// <summary>
        /// 筛选单个采购表数据
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public Buyer_Producer_View SelectBuyerById(int Id)
        {
            return Buyer_Producer_ViewOper.Instance.SelectById(Id);
        }
        /// <summary>
        /// 筛选同一采购表的商品信息
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public List<Deliver_Buyer_View> SelectBuyerDetailed(int Id)
        {
            return Deliver_Buyer_ViewOper.Instance.SelectAll(new Deliver_Buyer_View { buyerId = Id });
        }
        public bool UpdateBuyer(int Id)
        {
            return BuyerOper.Instance.Update(new Buyer { Id = Id, buyerStatus = "已退货" });
        }

        #region 品检合格操作
        public bool UpdateStatus(int Id)
        {

            var MysqlHelper = SqlHelper.GetMySqlHelper("transaction");
            var connection = MysqlHelper.CreatConn();
            var transaction = MysqlHelper.GetTransaction();
            try
            {
                #region 
                if (UpdatePrint(Id, connection, transaction))
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
        public bool UpdateStatus(int Id, string BadInfo, string ProductImageInfo, string IsQualified, string QCINSPECTOR, DateTime INSPECTIONDATE)
        {
            var MysqlHelper = SqlHelper.GetMySqlHelper("transaction");
            var connection = MysqlHelper.CreatConn();
            var transaction = MysqlHelper.GetTransaction();
            try
            {
                #region 
                if (UpdatePrint(Id, BadInfo, ProductImageInfo, IsQualified, QCINSPECTOR, INSPECTIONDATE, connection, transaction))
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

        public bool UpdatePrint(int Id, string BadInfo, string ProductImageInfo, string IsQualified, string QCINSPECTOR, DateTime INSPECTIONDATE, IDbConnection connection, IDbTransaction transaction)
        {
            if (Id != 0)
            {
                #region 改变采购单表状态
                var buyers = new Buyer
                {
                    Id = Id,
                    buyerStatus = "待入库",
                    checkStatus = "品检合格",
                    BadInfo = BadInfo,
                    ProductImageInfo = ProductImageInfo,
                    QCINSPECTOR = QCINSPECTOR,
                    INSPECTIONDATE = INSPECTIONDATE

                };
                if (!BuyerOper.Instance.Update(buyers, connection, transaction))
                {
                    return false;
                }
                #endregion

                #region 改变送货单表状态
                var DeliverInfo = DeliverFunc.Instance.SelectByModel(new DbOpertion.Models.Deliver { buyerId = Id });
                foreach (var item in DeliverInfo)
                {
                    var Delivers = new Deliver
                    {
                        Id = item.Id,
                        IsStatus = "待入库",
                    };
                    if (!DeliverOper.Instance.Update(Delivers, connection, transaction))
                    {
                        return false;
                    }
                }
                #endregion
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool UpdatePrint(int Id, IDbConnection connection, IDbTransaction transaction)
        {
            if (Id != 0)
            {
                #region 改变采购单表状态
                var buyers = new Buyer
                {
                    Id = Id,
                    buyerStatus = "待入库",
                    checkStatus = "品检合格"
                };
                if (!BuyerOper.Instance.Update(buyers, connection, transaction))
                {
                    return false;
                }
                #endregion

                #region 改变送货单表状态
                var DeliverInfo = DeliverFunc.Instance.SelectByModel(new DbOpertion.Models.Deliver { buyerId = Id });
                foreach (var item in DeliverInfo)
                {
                    var Delivers = new Deliver
                    {
                        Id = item.Id,
                        IsStatus = "待入库",
                    };
                    if (!DeliverOper.Instance.Update(Delivers, connection, transaction))
                    {
                        return false;
                    }
                }
                #endregion
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion 

        public int GetTodayBuyer(IDbConnection connection, IDbTransaction transaction)
        {
            var query = new LambdaQuery<Buyer>();
            query.Where(p => p.CreateTime > DateTime.Now.Date);
            return query.GetQueryCount(connection, transaction);
        }

        /// <summary>
        /// 筛选单个采购表数据
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public bool CrateSubmenu(PurchasingSubmenuRequest request)
        {
            var MysqlHelper = SqlHelper.GetMySqlHelper("transaction");
            var connection = MysqlHelper.CreatConn();
            var transaction = MysqlHelper.GetTransaction();
            try
            {
                #region 基础数据填充
                var buyer = BuyerOper.Instance.SelectById(request.PurchasingId.Value, connection, transaction);
                var buyerList = BuyerOper.Instance.SelectAll(new Buyer { ParentId = buyer.Id }, null, connection, transaction);
                var DeliverList = DeliverOper.Instance.SelectByKeys("Id", request.SubmenuList.Select(p => p.itemid.ToString()).ToList(), connection, transaction);
                var newbuyer = new Buyer { AmountOfWare = 0, buyerContext = buyer.buyerContext, buyerMoney = buyer.buyerMoney, BuyerNo = $"{buyer.BuyerNo}-{buyerList.Count + 1}", buyerStatus = buyer.buyerStatus, buyerTime = buyer.buyerTime, checkStatus = buyer.checkStatus, CreateTime = buyer.CreateTime, DeeliverExpressNo = buyer.DeeliverExpressNo, paidTime = buyer.paidTime, ParentId = buyer.Id, producerId = buyer.producerId, SignedTime = buyer.SignedTime, SinglePerson = buyer.SinglePerson, wantmoney = buyer.wantmoney, wantTime = buyer.wantTime, DeliverSingleTime = DateTime.Now };
                var newDeliverList = new List<Deliver>();
                foreach (var item in DeliverList)
                {
                    var subMenuModel = request.SubmenuList.Where(p => p.itemid == item.Id).FirstOrDefault();
                    if (subMenuModel.number > 0)
                    {
                        item.AlreadyQuantity = item.AlreadyQuantity == null ? subMenuModel.number : item.AlreadyQuantity + subMenuModel.number;
                        if (!DeliverOper.Instance.Update(item, connection, transaction))
                        {
                            transaction.Rollback();
                            connection.Close();
                            return false;
                        }
                        newDeliverList.Add(new Deliver { Raw_materialsId = item.Raw_materialsId, ProducerId = item.ProducerId, buyerPrice = item.buyerPrice, buyerCount = subMenuModel.number, DeliverMoney = (item.buyerPrice * subMenuModel.number), IsStatus = "待品检", Color = item.Color });
                    }
                }
                #endregion
                #region 数据更新
                newbuyer.buyerMoney = newDeliverList.Sum(p => p.DeliverMoney);
                var key = BuyerOper.Instance.InsertReturnKey(newbuyer, connection, transaction);
                if (key <= 0)
                {
                    transaction.Rollback();
                    connection.Close();
                    return false;
                }
                foreach (var item in newDeliverList)
                {
                    item.buyerId = key;
                    if (!DeliverOper.Instance.Insert(item, connection, transaction))
                    {
                        transaction.Rollback();
                        connection.Close();
                        return false;
                    }
                }
                #endregion

                transaction.Commit();
                connection.Close();
            }
            catch (Exception e)
            {
                transaction.Rollback();
                connection.Close();
                throw e;
            }
            return false;
        }
    }
}
