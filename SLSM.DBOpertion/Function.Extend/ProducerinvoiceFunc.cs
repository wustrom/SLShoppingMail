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
    public partial class ProducerinvoiceFunc : SingleTon<ProducerinvoiceFunc>
    {
        public bool UpdateProducerInfo(string ListOrderId, int ProducerId, string CompanyName, string InvoiceNumber, DateTime InvoiceTime, string InvoiceMoney, string InvoiceIdentify, string InvoicePhone, string InvoiceAddress, string InvoiceBank, string InvoiceContext)
        {

            var MysqlHelper = SqlHelper.GetMySqlHelper("transaction");
            var connection = MysqlHelper.CreatConn();
            var transaction = MysqlHelper.GetTransaction();
            try
            {
                #region 
                if (UpdateProducer(ListOrderId, ProducerId, CompanyName, InvoiceNumber, InvoiceTime, InvoiceMoney, InvoiceIdentify, InvoicePhone, InvoiceAddress, InvoiceBank, InvoiceContext, connection, transaction))
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

        public bool UpdateProducer(string ListOrderId, int ProducerId, string CompanyName, string InvoiceNumber, DateTime InvoiceTime, string InvoiceMoney, string InvoiceIdentify, string InvoicePhone, string InvoiceAddress, string InvoiceBank, string InvoiceContext, IDbConnection connection, IDbTransaction transaction)
        {
            if (ListOrderId != null)
            {
                //判断应付时间是否为空
                var arrId = ListOrderId.Split(',').Distinct().ToList();
                var ListBuyers = BuyerOper.Instance.SelectAll(new Buyer { wantTime = null }, null, connection, transaction);
                var BuyerInfoList = new List<Buyer>();

                //获得所选订单的供应商的账期
                double AccountPeriod = double.Parse(ProducerOper.Instance.SelectById(ProducerId).AccountPeriod);
                foreach (var item in arrId)
                {
                    if (item != "")
                    {
                        var arrIds = item.ParseInt();
                        var ProducerInfo = ListBuyers.Where(p => p.Id == arrIds && p.buyerStatus == "已入库").ToList();
                        if (ProducerInfo == null)
                        {
                            return false;
                        }
                        //获得新的buyer
                        BuyerInfoList.Add(ProducerInfo);
                        var BuyerInfo = BuyerOper.Instance.Update(new Buyer { Id = arrIds.Value, wantTime = InvoiceTime.AddDays(AccountPeriod) }, connection, transaction);
                        if (!BuyerInfo)
                        {
                            return false;
                        }
                    }
                }
            }

            #region  生成发票
            var ProducerinvoiceInfo = ProducerinvoiceOper.Instance.Insert(new Producerinvoice
            {
                ProducerId = ProducerId,
                CompanyName = CompanyName,
                InvoiceNumber = InvoiceNumber,
                InvoiceTime = InvoiceTime,
                InvoiceMoney = InvoiceMoney,
                InvoiceIdentify = InvoiceIdentify,
                InvoicePhone = InvoicePhone,
                InvoiceAddress = InvoiceAddress,
                InvoiceBank = InvoiceBank,
                InvoiceContext = InvoiceContext
            }, connection, transaction);

            if (!ProducerinvoiceInfo)
            {
                return false;
            }
            #endregion

            return true;
        }
    }
}
