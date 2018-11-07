using Common.Filter.WebApi;
using Common.Result;
using DbOpertion.Function;
using DbOpertion.Models;
using DbOpertion.Operation;
using SLSM.ErpWeb.Model.Request.Finance;
using SLSM.ErpWeb.Model.Response.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;

namespace SLSM.ErpWeb.Controllers.AjaxController
{
    public class FinanceController : BaseApiController
    {
        #region 应付账款
        /// <summary>
        /// 付款
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ResultJson FinanceMoney(FinaneceRequest request)
        {
            var result = false;
            Decimal wantmoney = 0;
            Decimal buyerMoney = 0;
            var IdList = request.Id.Split(',').Where(p => !string.IsNullOrEmpty(p)).ToList();
            var buyers = Buyer_Producer_ViewOper.Instance.SelectByKeys("Id", IdList);
            if (buyers.Select(p => p.producerId).Where(p => p != null).Distinct().Count() > 1)
            {
                return new ResultJson { HttpCode = 300, Message = "请选择同一供应商订单!" };
            }
            #region 判断输入金额是否大于零
            if (request.wantmoney < 1)
            {
                return new ResultJson { HttpCode = 300, Message = "请输入大于零的金额!" };
            }
            #endregion

            foreach (var item in buyers)
            {
                if (item.wantmoney != null)
                {
                    wantmoney = wantmoney + item.wantmoney.Value;
                    buyerMoney = buyerMoney + item.buyerMoney.Value;
                }
            }
            var Moneys = wantmoney + request.wantmoney;

            #region 判断输入金额与已交金额相加是否大于应付金额
            if (Moneys > buyerMoney)
            {
                return new ResultJson { HttpCode = 300, Message = "您可以输入0到" + (buyerMoney - wantmoney) + "的数值!" };
            }
            #endregion

            #region 累加金额
            else
            {
                foreach (var item in buyers)
                {
                    if (request.wantmoney > 0)
                    {
                        if (request.wantmoney < (item.buyerMoney - item.wantmoney))
                        {
                            result = BuyerOper.Instance.Update(new Buyer { Id = item.Id, wantmoney = (request.wantmoney + item.wantmoney), paidTime = DateTime.Now });
                            request.wantmoney = 0;
                        }
                        else
                        {
                            result = BuyerOper.Instance.Update(new Buyer { Id = item.Id, wantmoney = item.buyerMoney, paidTime = DateTime.Now });
                            request.wantmoney = (decimal)(request.wantmoney + item.wantmoney - item.buyerMoney);
                        }

                    }

                }
            }
            #endregion

            if (result)
            {
                return new ResultJson { HttpCode = 200, Message = "成功!" };
            }
            else
            {
                return new ResultJson { HttpCode = 300, Message = "失败!" };
            }
        }
        #endregion


        #region 发票记录
        /// <summary>
        /// 添加或者修改
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ResultJson UpDateInvoice(InvoiceRequest request)
        {
            var InvoiceAddress = request.AddressInfo + request.AddressDetail;
            #region 添加
            if (request.Id == 0 && request.ListOrderId != null)
            {
                var resultAdd = ProducerinvoiceFunc.Instance.UpdateProducerInfo(request.ListOrderId, request.ProducerId, request.CompanyName, request.InvoiceNumber, request.InvoiceTime, request.InvoiceMoney, request.InvoiceIdentify, request.InvoicePhone, InvoiceAddress, request.InvoiceBank, request.InvoiceContext);
                if (resultAdd)
                {
                    return new ResultJson { HttpCode = 200, Message = "成功!" };
                }
                else
                {
                    return new ResultJson { HttpCode = 300, Message = "失败,请重试" };
                }
            }
            #endregion

            #region 修改          
            else
            {
                var result = ProducerinvoiceOper.Instance.Update(new Producerinvoice
                {
                    Id = request.Id,
                    ProducerId = request.ProducerId,
                    CompanyName = request.CompanyName,
                    InvoicePhone = request.InvoicePhone,
                    InvoiceAddress = InvoiceAddress,
                    InvoiceIdentify = request.InvoiceIdentify,
                    InvoiceMoney = request.InvoiceMoney,
                    InvoiceBank = request.InvoiceBank,
                    InvoiceContext = request.InvoiceContext
                });
                if (result)
                {
                    return new ResultJson { HttpCode = 200, Message = "成功!" };
                }
                else
                {
                    return new ResultJson { HttpCode = 300, Message = "失败!" };
                }
            }
            #endregion            
        }
        /// <summary>
        /// 删除发票
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public ResultJson DelInvoice(InvoiceRequest request)
        {
            if (ProducerinvoiceOper.Instance.DeleteById(request.Id))
            {
                return new ResultJson { HttpCode = 200, Message = "成功!" };
            }
            else
            {
                return new ResultJson { HttpCode = 300, Message = "失败!" };
            }
        }
        #endregion
    }
}
