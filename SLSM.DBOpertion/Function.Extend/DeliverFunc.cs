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
    public partial class DeliverFunc : SingleTon<DeliverFunc>
    {
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public List<Deliver_Buyer_View> SelectAllDeliver(int Id)
        {
            return Deliver_Buyer_ViewOper.Instance.SelectAll(new Deliver_Buyer_View { buyerId = Id });
        }
        /// <summary>
        /// 查询数量
        /// </summary>
        /// <returns></returns>
        public int SelectAllDeliversCount()
        {
            return Deliver_Buyer_ViewOper.Instance.SelectCount(new Deliver_Buyer_View { buyerId = 0 });
        }
        /// <summary>
        /// 删除全部数据
        /// </summary>
        /// <param name="Ids"></param>
        /// <returns></returns>
        public bool DeleteListDeliver()
        {
            var SeleteDeliver = DeliverOper.Instance.SelectAll(new Deliver { buyerId = 0 });
            if (SeleteDeliver.Count != 0)
            {
                foreach (var item in SeleteDeliver)
                {
                    DeliverOper.Instance.DeleteById(item.Id);
                }
                return true;
            }
            else
            {
                return false;
            }
        }

        #region 待采购列表添加下单处理
        /// <summary>
        /// 修改状态
        /// </summary>
        /// <param name="Ids"></param>
        /// <returns></returns>
        public bool UpdateListDeliver(string Ids)
        {

            var MysqlHelper = SqlHelper.GetMySqlHelper("transaction");
            var connection = MysqlHelper.CreatConn();
            var transaction = MysqlHelper.GetTransaction();
            try
            {
                #region 
                if (UpdateDeliver(Ids, connection, transaction))
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

        public bool UpdateDeliver(string Ids, IDbConnection connection, IDbTransaction transaction)
        {
            if (Ids != null)
            {
                List<Tuple<int, int>> list = new List<Tuple<int, int>>();
                var deliverList = DeliverOper.Instance.SelectAll(new Deliver { buyerId = 0 }, null, connection, transaction);
                var deliverInfoList = new List<Deliver>();

                #region 修改送货单状态
                #region 筛选出全部符合条件的采购单
                var arrId = Ids.Split(',').Distinct().ToList();
                foreach (var item in arrId)
                {
                    #region 若Id不为数字则继续执行
                    var arrIds = item.ParseInt();
                    if (arrIds == null || arrIds == 0)
                    {
                        continue;
                    }
                    #endregion

                    #region 选出当前数据，若不包含则为缺少
                    var deliver = deliverList.Where(p => p.Id == arrIds).FirstOrDefault();
                    if (deliver == null)
                    {
                        return false;
                    }
                    #endregion
                    deliverInfoList.Add(deliver);
                }
                #endregion

                #region 建立全部订单信息
                var producerIdList = deliverInfoList.Select(p => p.ProducerId).Distinct().ToList();
                var todayBuyer = BuyerFunc.Instance.GetTodayBuyer(connection, transaction) + 1;
                foreach (var item in producerIdList)
                {
                    var prodeucerDeliverInfo = deliverInfoList.Where(p => p.ProducerId == item).ToList();
                    #region 订单没有内容，则此记录已被生成过
                    if (prodeucerDeliverInfo.Count == 0)
                    {
                        return false;
                    }
                    #endregion
                    var returnKey = BuyerOper.Instance.InsertReturnKey(new Buyer { producerId = item.Value, buyerStatus = "待下单", checkStatus = "待下单品检", buyerMoney = prodeucerDeliverInfo.Sum(p => p.DeliverMoney), BuyerNo = "ELS" + DateTime.Now.ToString("yyyyMMdd") + todayBuyer.ToString("0000"), CreateTime = DateTime.Now }, connection, transaction);
                    todayBuyer++;
                    if (returnKey <= 0)
                    {
                        return false;
                    }
                    list.Add(new Tuple<int, int>(item1: item.Value, item2: returnKey));
                }
                #endregion

                #region 修改全部采购单信息
                foreach (var item in deliverInfoList)
                {
                    var tuple = list.Where(p => p.Item1 == item.ProducerId).FirstOrDefault();
                    if (tuple == null)
                    {
                        return false;
                    }
                    if (!DeliverOper.Instance.Update(new Deliver { Id = item.Id, buyerId = tuple.Item2, IsStatus = "待下单" }, connection, transaction))
                    {
                        return false;
                    }
                }
                #endregion
                #endregion
                return true;
            }
            else
            {
                return false;
            }
        }

        #endregion

        #region  待下单时删除采购单数据处理
        /// <summary>
        /// 删除采购单单条数据,但删除最后一条时,删除采购表数据
        /// </summary>
        /// <param name="Ids"></param>
        /// <returns></returns>
        public bool DeleteDeliverById(int Id)
        {
            var MysqlHelper = SqlHelper.GetMySqlHelper("transaction");
            var connection = MysqlHelper.CreatConn();
            var transaction = MysqlHelper.GetTransaction();
            try
            {
                #region 
                if (DeleteDeliver(Id, connection, transaction))
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
        public bool DeleteDeliver(int Id, IDbConnection connection, IDbTransaction transaction)
        {
            decimal BuyerMoney = 0;
            if (Id != 0)
            {
                var Delivers = DeliverOper.Instance.SelectById(Id);
                var buyerId = Delivers.buyerId.Value;
                var List_Deliver = DeliverOper.Instance.SelectAll(new Deliver { buyerId = buyerId }, null, connection, transaction);
                #region  若为多条数据,则删除采购表
                if (List_Deliver.Count != 1)
                {
                    //删除采购单的数据
                    if (!DeliverOper.Instance.DeleteById(Id, connection, transaction))
                    {
                        return false;
                    }
                    //重新查询
                    var List_Delivers = DeliverOper.Instance.SelectAll(new Deliver { buyerId = buyerId }, null, connection, transaction);
                    //则修改采购表的金额
                    foreach (var item in List_Delivers)
                    {
                        BuyerMoney += item.DeliverMoney.Value;
                    }
                    if (!BuyerOper.Instance.Update(new Buyer { Id = buyerId, buyerMoney = BuyerMoney }, connection, transaction))
                    {
                        return false;
                    }

                }
                #endregion

                #region 若为一条数据,则直接删除采购表数据
                else
                {
                    if (!BuyerOper.Instance.DeleteById(buyerId, connection, transaction))
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

        #region 打印合同或者取消订单
        public bool UpdatePrintContract(int Id, string Status, string CheckStatus, string ContractNumber, DateTime SignedTime, string SLSMContacts, string SLSMPhone, string SLSMFaxNumber, string SLSMEmail, string ContractContext, string DeliverCountext,string SinglePerson)
        {

            var MysqlHelper = SqlHelper.GetMySqlHelper("transaction");
            var connection = MysqlHelper.CreatConn();
            var transaction = MysqlHelper.GetTransaction();
            try
            {
                #region 
                if (UpdatePrint(Id, Status, CheckStatus, ContractNumber, SignedTime, SLSMContacts, SLSMPhone, SLSMFaxNumber, SLSMEmail, ContractContext, DeliverCountext, SinglePerson, connection, transaction))
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

        public bool UpdatePrint(int Id, string Status, string CheckStatus, string ContractNumber, DateTime SignedTime, string SLSMContacts, string SLSMPhone, string SLSMFaxNumber, string SLSMEmail, string ContractContext, string DeliverCountext,string SinglePerson, IDbConnection connection, IDbTransaction transaction)
        {
            if (Id != 0)
            {
                #region 改变采购表状态
                var buyers = new Buyer
                {
                    Id = Id,
                    buyerTime = SignedTime,
                    buyerStatus = Status,
                    checkStatus = CheckStatus,
                    ContractNumber = ContractNumber,
                    SignedTime = SignedTime,
                    SLSMContacts = SLSMContacts,
                    SLSMPhone = SLSMPhone,
                    SLSMFaxNumber = SLSMFaxNumber,
                    SLSMEmail = SLSMEmail,
                    ContractContext = ContractContext,
                    SinglePerson = SinglePerson,
                    SingleTime = DateTime.Now
                };
                if (!BuyerOper.Instance.Update(buyers, connection, transaction))
                {
                    return false;
                }
                if (buyers.buyerStatus == "已取消")
                {
                    return true;
                }
                #endregion

                #region 改变送货单状态
                var DeliverCountexts = DeliverCountext.Split(',');
                var List_Deliver = DeliverOper.Instance.SelectAll(new Deliver { buyerId = Id });
                for (var i = 0; i < List_Deliver.Count; i++)
                {
                    if (!DeliverOper.Instance.Update(new Deliver { Id = List_Deliver[i].Id, IsStatus = CheckStatus, DeliverCountext = DeliverCountexts[i] }, connection, transaction))
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

    }
}
