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
    public partial class Order_AllinfoOper : SingleTon<Order_AllinfoOper>
    {
        /// <summary>
        /// 筛选全部数据
        /// </summary>
        /// <param name="model">模型</param>
        /// <param name="connection">连接</param>
        /// <param name="transaction">事务</param>
        /// <returns>对象列表</returns>
        public List<Order_Allinfo> SelectAll(Order_Allinfo model = null, string SelectFiled = null, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var query = new LambdaQuery<Order_Allinfo>();
            if (model != null)
            {
                if (!model.Id.IsNullOrEmpty())
                {
                    query.Where(p => p.Id == model.Id);
                }
                if (!model.UserId.IsNullOrEmpty())
                {
                    query.Where(p => p.UserId == model.UserId);
                }
                if (!model.AddressId.IsNullOrEmpty())
                {
                    query.Where(p => p.AddressId == model.AddressId);
                }
                if (!model.TotalPrice.IsNullOrEmpty())
                {
                    query.Where(p => p.TotalPrice == model.TotalPrice);
                }
                if (!model.DiscountPrice.IsNullOrEmpty())
                {
                    query.Where(p => p.DiscountPrice == model.DiscountPrice);
                }
                if (!model.DisCountResult.IsNullOrEmpty())
                {
                    query.Where(p => p.DisCountResult == model.DisCountResult);
                }
                if (!model.PayType.IsNullOrEmpty())
                {
                    query.Where(p => p.PayType == model.PayType);
                }
                if (!model.Status.IsNullOrEmpty())
                {
                    query.Where(p => p.Status == model.Status);
                }
                if (!model.OrderNo.IsNullOrEmpty())
                {
                    query.Where(p => p.OrderNo == model.OrderNo);
                }
                if (!model.OrderTime.IsNullOrEmpty())
                {
                    query.Where(p => p.OrderTime == model.OrderTime);
                }
                if (!model.OrderType.IsNullOrEmpty())
                {
                    query.Where(p => p.OrderType == model.OrderType);
                }
                if (!model.BuyName.IsNullOrEmpty())
                {
                    query.Where(p => p.BuyName == model.BuyName);
                }
                if (!model.Address.IsNullOrEmpty())
                {
                    query.Where(p => p.Address == model.Address);
                }
                if (!model.Phone.IsNullOrEmpty())
                {
                    query.Where(p => p.Phone == model.Phone);
                }
                if (!model.ExpressCompany.IsNullOrEmpty())
                {
                    query.Where(p => p.ExpressCompany == model.ExpressCompany);
                }
                if (!model.ExpressNo.IsNullOrEmpty())
                {
                    query.Where(p => p.ExpressNo == model.ExpressNo);
                }
                if (!model.Invoice.IsNullOrEmpty())
                {
                    query.Where(p => p.Invoice == model.Invoice);
                }
                if (!model.InvoiceId.IsNullOrEmpty())
                {
                    query.Where(p => p.InvoiceId == model.InvoiceId);
                }
                if (!model.LastCodeTime.IsNullOrEmpty())
                {
                    query.Where(p => p.LastCodeTime == model.LastCodeTime);
                }
                if (!model.WechatFaild.IsNullOrEmpty())
                {
                    query.Where(p => p.WechatFaild == model.WechatFaild);
                }
                if (!model.ToErp.IsNullOrEmpty())
                {
                    query.Where(p => p.ToErp == model.ToErp);
                }
                if (!model.IsDelete.IsNullOrEmpty())
                {
                    query.Where(p => p.IsDelete == model.IsDelete);
                }
                if (!model.Freight.IsNullOrEmpty())
                {
                    query.Where(p => p.Freight == model.Freight);
                }
                if (!model.UserDesign.IsNullOrEmpty())
                {
                    query.Where(p => p.UserDesign == model.UserDesign);
                }
                if (!model.IsAdmin.IsNullOrEmpty())
                {
                    query.Where(p => p.IsAdmin == model.IsAdmin);
                }
                if (!model.AdminName.IsNullOrEmpty())
                {
                    query.Where(p => p.AdminName == model.AdminName);
                }
                if (!model.Name.IsNullOrEmpty())
                {
                    query.Where(p => p.Name == model.Name);
                }
                if (!model.AddrArea.IsNullOrEmpty())
                {
                    query.Where(p => p.AddrArea == model.AddrArea);
                }
                if (!model.AddrDetail.IsNullOrEmpty())
                {
                    query.Where(p => p.AddrDetail == model.AddrDetail);
                }
            }
            if (SelectFiled != null)
            {
                SelectFiled = SelectFiled.ToLowerInvariant();
                if (SelectFiled.Contains("id,"))
                {
                    query.Select(p => new { p.Id });
                }
                if (SelectFiled.Contains("userid,"))
                {
                    query.Select(p => new { p.UserId });
                }
                if (SelectFiled.Contains("addressid,"))
                {
                    query.Select(p => new { p.AddressId });
                }
                if (SelectFiled.Contains("totalprice,"))
                {
                    query.Select(p => new { p.TotalPrice });
                }
                if (SelectFiled.Contains("discountprice,"))
                {
                    query.Select(p => new { p.DiscountPrice });
                }
                if (SelectFiled.Contains("discountresult,"))
                {
                    query.Select(p => new { p.DisCountResult });
                }
                if (SelectFiled.Contains("paytype,"))
                {
                    query.Select(p => new { p.PayType });
                }
                if (SelectFiled.Contains("status,"))
                {
                    query.Select(p => new { p.Status });
                }
                if (SelectFiled.Contains("orderno,"))
                {
                    query.Select(p => new { p.OrderNo });
                }
                if (SelectFiled.Contains("ordertime,"))
                {
                    query.Select(p => new { p.OrderTime });
                }
                if (SelectFiled.Contains("ordertype,"))
                {
                    query.Select(p => new { p.OrderType });
                }
                if (SelectFiled.Contains("buyname,"))
                {
                    query.Select(p => new { p.BuyName });
                }
                if (SelectFiled.Contains("address,"))
                {
                    query.Select(p => new { p.Address });
                }
                if (SelectFiled.Contains("phone,"))
                {
                    query.Select(p => new { p.Phone });
                }
                if (SelectFiled.Contains("expresscompany,"))
                {
                    query.Select(p => new { p.ExpressCompany });
                }
                if (SelectFiled.Contains("expressno,"))
                {
                    query.Select(p => new { p.ExpressNo });
                }
                if (SelectFiled.Contains("invoice,"))
                {
                    query.Select(p => new { p.Invoice });
                }
                if (SelectFiled.Contains("invoiceid,"))
                {
                    query.Select(p => new { p.InvoiceId });
                }
                if (SelectFiled.Contains("lastcodetime,"))
                {
                    query.Select(p => new { p.LastCodeTime });
                }
                if (SelectFiled.Contains("wechatfaild,"))
                {
                    query.Select(p => new { p.WechatFaild });
                }
                if (SelectFiled.Contains("toerp,"))
                {
                    query.Select(p => new { p.ToErp });
                }
                if (SelectFiled.Contains("isdelete,"))
                {
                    query.Select(p => new { p.IsDelete });
                }
                if (SelectFiled.Contains("freight,"))
                {
                    query.Select(p => new { p.Freight });
                }
                if (SelectFiled.Contains("userdesign,"))
                {
                    query.Select(p => new { p.UserDesign });
                }
                if (SelectFiled.Contains("isadmin,"))
                {
                    query.Select(p => new { p.IsAdmin });
                }
                if (SelectFiled.Contains("adminname,"))
                {
                    query.Select(p => new { p.AdminName });
                }
                if (SelectFiled.Contains("name,"))
                {
                    query.Select(p => new { p.Name });
                }
                if (SelectFiled.Contains("addrarea,"))
                {
                    query.Select(p => new { p.AddrArea });
                }
                if (SelectFiled.Contains("addrdetail,"))
                {
                    query.Select(p => new { p.AddrDetail });
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
        public int SelectCount(Order_Allinfo model = null, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var query = new LambdaQuery<Order_Allinfo>();
            if (model != null)
            {
                if (!model.Id.IsNullOrEmpty())
                {
                    query.Where(p => p.Id == model.Id);
                }
                if (!model.UserId.IsNullOrEmpty())
                {
                    query.Where(p => p.UserId == model.UserId);
                }
                if (!model.AddressId.IsNullOrEmpty())
                {
                    query.Where(p => p.AddressId == model.AddressId);
                }
                if (!model.TotalPrice.IsNullOrEmpty())
                {
                    query.Where(p => p.TotalPrice == model.TotalPrice);
                }
                if (!model.DiscountPrice.IsNullOrEmpty())
                {
                    query.Where(p => p.DiscountPrice == model.DiscountPrice);
                }
                if (!model.DisCountResult.IsNullOrEmpty())
                {
                    query.Where(p => p.DisCountResult == model.DisCountResult);
                }
                if (!model.PayType.IsNullOrEmpty())
                {
                    query.Where(p => p.PayType == model.PayType);
                }
                if (!model.Status.IsNullOrEmpty())
                {
                    query.Where(p => p.Status == model.Status);
                }
                if (!model.OrderNo.IsNullOrEmpty())
                {
                    query.Where(p => p.OrderNo == model.OrderNo);
                }
                if (!model.OrderTime.IsNullOrEmpty())
                {
                    query.Where(p => p.OrderTime == model.OrderTime);
                }
                if (!model.OrderType.IsNullOrEmpty())
                {
                    query.Where(p => p.OrderType == model.OrderType);
                }
                if (!model.BuyName.IsNullOrEmpty())
                {
                    query.Where(p => p.BuyName == model.BuyName);
                }
                if (!model.Address.IsNullOrEmpty())
                {
                    query.Where(p => p.Address == model.Address);
                }
                if (!model.Phone.IsNullOrEmpty())
                {
                    query.Where(p => p.Phone == model.Phone);
                }
                if (!model.ExpressCompany.IsNullOrEmpty())
                {
                    query.Where(p => p.ExpressCompany == model.ExpressCompany);
                }
                if (!model.ExpressNo.IsNullOrEmpty())
                {
                    query.Where(p => p.ExpressNo == model.ExpressNo);
                }
                if (!model.Invoice.IsNullOrEmpty())
                {
                    query.Where(p => p.Invoice == model.Invoice);
                }
                if (!model.InvoiceId.IsNullOrEmpty())
                {
                    query.Where(p => p.InvoiceId == model.InvoiceId);
                }
                if (!model.LastCodeTime.IsNullOrEmpty())
                {
                    query.Where(p => p.LastCodeTime == model.LastCodeTime);
                }
                if (!model.WechatFaild.IsNullOrEmpty())
                {
                    query.Where(p => p.WechatFaild == model.WechatFaild);
                }
                if (!model.ToErp.IsNullOrEmpty())
                {
                    query.Where(p => p.ToErp == model.ToErp);
                }
                if (!model.IsDelete.IsNullOrEmpty())
                {
                    query.Where(p => p.IsDelete == model.IsDelete);
                }
                if (!model.Freight.IsNullOrEmpty())
                {
                    query.Where(p => p.Freight == model.Freight);
                }
                if (!model.UserDesign.IsNullOrEmpty())
                {
                    query.Where(p => p.UserDesign == model.UserDesign);
                }
                if (!model.IsAdmin.IsNullOrEmpty())
                {
                    query.Where(p => p.IsAdmin == model.IsAdmin);
                }
                if (!model.AdminName.IsNullOrEmpty())
                {
                    query.Where(p => p.AdminName == model.AdminName);
                }
                if (!model.Name.IsNullOrEmpty())
                {
                    query.Where(p => p.Name == model.Name);
                }
                if (!model.AddrArea.IsNullOrEmpty())
                {
                    query.Where(p => p.AddrArea == model.AddrArea);
                }
                if (!model.AddrDetail.IsNullOrEmpty())
                {
                    query.Where(p => p.AddrDetail == model.AddrDetail);
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
        public Order_Allinfo SelectById(int KeyId, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var query = new LambdaQuery<Order_Allinfo>();
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
        public List<Order_Allinfo> SelectByKeys(string Key,List<string> KeyIds, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var query = new LambdaQuery<Order_Allinfo>();
            if("id" == Key.ToLowerInvariant())
            {
                query.Where(p => p.Id.In(KeyIds));
            }
            if("userid" == Key.ToLowerInvariant())
            {
                query.Where(p => p.UserId.In(KeyIds));
            }
            if("addressid" == Key.ToLowerInvariant())
            {
                query.Where(p => p.AddressId.In(KeyIds));
            }
            if("totalprice" == Key.ToLowerInvariant())
            {
                query.Where(p => p.TotalPrice.In(KeyIds));
            }
            if("discountprice" == Key.ToLowerInvariant())
            {
                query.Where(p => p.DiscountPrice.In(KeyIds));
            }
            if("discountresult" == Key.ToLowerInvariant())
            {
                query.Where(p => p.DisCountResult.In(KeyIds));
            }
            if("paytype" == Key.ToLowerInvariant())
            {
                query.Where(p => p.PayType.In(KeyIds));
            }
            if("status" == Key.ToLowerInvariant())
            {
                query.Where(p => p.Status.In(KeyIds));
            }
            if("orderno" == Key.ToLowerInvariant())
            {
                query.Where(p => p.OrderNo.In(KeyIds));
            }
            if("ordertime" == Key.ToLowerInvariant())
            {
                query.Where(p => p.OrderTime.In(KeyIds));
            }
            if("ordertype" == Key.ToLowerInvariant())
            {
                query.Where(p => p.OrderType.In(KeyIds));
            }
            if("buyname" == Key.ToLowerInvariant())
            {
                query.Where(p => p.BuyName.In(KeyIds));
            }
            if("address" == Key.ToLowerInvariant())
            {
                query.Where(p => p.Address.In(KeyIds));
            }
            if("phone" == Key.ToLowerInvariant())
            {
                query.Where(p => p.Phone.In(KeyIds));
            }
            if("expresscompany" == Key.ToLowerInvariant())
            {
                query.Where(p => p.ExpressCompany.In(KeyIds));
            }
            if("expressno" == Key.ToLowerInvariant())
            {
                query.Where(p => p.ExpressNo.In(KeyIds));
            }
            if("invoice" == Key.ToLowerInvariant())
            {
                query.Where(p => p.Invoice.In(KeyIds));
            }
            if("invoiceid" == Key.ToLowerInvariant())
            {
                query.Where(p => p.InvoiceId.In(KeyIds));
            }
            if("lastcodetime" == Key.ToLowerInvariant())
            {
                query.Where(p => p.LastCodeTime.In(KeyIds));
            }
            if("wechatfaild" == Key.ToLowerInvariant())
            {
                query.Where(p => p.WechatFaild.In(KeyIds));
            }
            if("toerp" == Key.ToLowerInvariant())
            {
                query.Where(p => p.ToErp.In(KeyIds));
            }
            if("isdelete" == Key.ToLowerInvariant())
            {
                query.Where(p => p.IsDelete.In(KeyIds));
            }
            if("freight" == Key.ToLowerInvariant())
            {
                query.Where(p => p.Freight.In(KeyIds));
            }
            if("userdesign" == Key.ToLowerInvariant())
            {
                query.Where(p => p.UserDesign.In(KeyIds));
            }
            if("isadmin" == Key.ToLowerInvariant())
            {
                query.Where(p => p.IsAdmin.In(KeyIds));
            }
            if("adminname" == Key.ToLowerInvariant())
            {
                query.Where(p => p.AdminName.In(KeyIds));
            }
            if("name" == Key.ToLowerInvariant())
            {
                query.Where(p => p.Name.In(KeyIds));
            }
            if("addrarea" == Key.ToLowerInvariant())
            {
                query.Where(p => p.AddrArea.In(KeyIds));
            }
            if("addrdetail" == Key.ToLowerInvariant())
            {
                query.Where(p => p.AddrDetail.In(KeyIds));
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
        public List<Order_Allinfo> SelectByPage(string Key, int start, int PageSize, bool desc = true,Order_Allinfo model = null, string SelectFiled = null, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var query = new LambdaQuery<Order_Allinfo>();
            if (model != null)
            {
                if (!model.Id.IsNullOrEmpty())
                {
                    query.Where(p => p.Id == model.Id);
                }
                if (!model.UserId.IsNullOrEmpty())
                {
                    query.Where(p => p.UserId == model.UserId);
                }
                if (!model.AddressId.IsNullOrEmpty())
                {
                    query.Where(p => p.AddressId == model.AddressId);
                }
                if (!model.TotalPrice.IsNullOrEmpty())
                {
                    query.Where(p => p.TotalPrice == model.TotalPrice);
                }
                if (!model.DiscountPrice.IsNullOrEmpty())
                {
                    query.Where(p => p.DiscountPrice == model.DiscountPrice);
                }
                if (!model.DisCountResult.IsNullOrEmpty())
                {
                    query.Where(p => p.DisCountResult == model.DisCountResult);
                }
                if (!model.PayType.IsNullOrEmpty())
                {
                    query.Where(p => p.PayType == model.PayType);
                }
                if (!model.Status.IsNullOrEmpty())
                {
                    query.Where(p => p.Status == model.Status);
                }
                if (!model.OrderNo.IsNullOrEmpty())
                {
                    query.Where(p => p.OrderNo == model.OrderNo);
                }
                if (!model.OrderTime.IsNullOrEmpty())
                {
                    query.Where(p => p.OrderTime == model.OrderTime);
                }
                if (!model.OrderType.IsNullOrEmpty())
                {
                    query.Where(p => p.OrderType == model.OrderType);
                }
                if (!model.BuyName.IsNullOrEmpty())
                {
                    query.Where(p => p.BuyName == model.BuyName);
                }
                if (!model.Address.IsNullOrEmpty())
                {
                    query.Where(p => p.Address == model.Address);
                }
                if (!model.Phone.IsNullOrEmpty())
                {
                    query.Where(p => p.Phone == model.Phone);
                }
                if (!model.ExpressCompany.IsNullOrEmpty())
                {
                    query.Where(p => p.ExpressCompany == model.ExpressCompany);
                }
                if (!model.ExpressNo.IsNullOrEmpty())
                {
                    query.Where(p => p.ExpressNo == model.ExpressNo);
                }
                if (!model.Invoice.IsNullOrEmpty())
                {
                    query.Where(p => p.Invoice == model.Invoice);
                }
                if (!model.InvoiceId.IsNullOrEmpty())
                {
                    query.Where(p => p.InvoiceId == model.InvoiceId);
                }
                if (!model.LastCodeTime.IsNullOrEmpty())
                {
                    query.Where(p => p.LastCodeTime == model.LastCodeTime);
                }
                if (!model.WechatFaild.IsNullOrEmpty())
                {
                    query.Where(p => p.WechatFaild == model.WechatFaild);
                }
                if (!model.ToErp.IsNullOrEmpty())
                {
                    query.Where(p => p.ToErp == model.ToErp);
                }
                if (!model.IsDelete.IsNullOrEmpty())
                {
                    query.Where(p => p.IsDelete == model.IsDelete);
                }
                if (!model.Freight.IsNullOrEmpty())
                {
                    query.Where(p => p.Freight == model.Freight);
                }
                if (!model.UserDesign.IsNullOrEmpty())
                {
                    query.Where(p => p.UserDesign == model.UserDesign);
                }
                if (!model.IsAdmin.IsNullOrEmpty())
                {
                    query.Where(p => p.IsAdmin == model.IsAdmin);
                }
                if (!model.AdminName.IsNullOrEmpty())
                {
                    query.Where(p => p.AdminName == model.AdminName);
                }
                if (!model.Name.IsNullOrEmpty())
                {
                    query.Where(p => p.Name == model.Name);
                }
                if (!model.AddrArea.IsNullOrEmpty())
                {
                    query.Where(p => p.AddrArea == model.AddrArea);
                }
                if (!model.AddrDetail.IsNullOrEmpty())
                {
                    query.Where(p => p.AddrDetail == model.AddrDetail);
                }
            }
            if (SelectFiled != null)
            {
                SelectFiled = SelectFiled.ToLowerInvariant();
                if (SelectFiled.Contains("id,"))
                {
                    query.Select(p => new { p.Id });
                }
                if (SelectFiled.Contains("userid,"))
                {
                    query.Select(p => new { p.UserId });
                }
                if (SelectFiled.Contains("addressid,"))
                {
                    query.Select(p => new { p.AddressId });
                }
                if (SelectFiled.Contains("totalprice,"))
                {
                    query.Select(p => new { p.TotalPrice });
                }
                if (SelectFiled.Contains("discountprice,"))
                {
                    query.Select(p => new { p.DiscountPrice });
                }
                if (SelectFiled.Contains("discountresult,"))
                {
                    query.Select(p => new { p.DisCountResult });
                }
                if (SelectFiled.Contains("paytype,"))
                {
                    query.Select(p => new { p.PayType });
                }
                if (SelectFiled.Contains("status,"))
                {
                    query.Select(p => new { p.Status });
                }
                if (SelectFiled.Contains("orderno,"))
                {
                    query.Select(p => new { p.OrderNo });
                }
                if (SelectFiled.Contains("ordertime,"))
                {
                    query.Select(p => new { p.OrderTime });
                }
                if (SelectFiled.Contains("ordertype,"))
                {
                    query.Select(p => new { p.OrderType });
                }
                if (SelectFiled.Contains("buyname,"))
                {
                    query.Select(p => new { p.BuyName });
                }
                if (SelectFiled.Contains("address,"))
                {
                    query.Select(p => new { p.Address });
                }
                if (SelectFiled.Contains("phone,"))
                {
                    query.Select(p => new { p.Phone });
                }
                if (SelectFiled.Contains("expresscompany,"))
                {
                    query.Select(p => new { p.ExpressCompany });
                }
                if (SelectFiled.Contains("expressno,"))
                {
                    query.Select(p => new { p.ExpressNo });
                }
                if (SelectFiled.Contains("invoice,"))
                {
                    query.Select(p => new { p.Invoice });
                }
                if (SelectFiled.Contains("invoiceid,"))
                {
                    query.Select(p => new { p.InvoiceId });
                }
                if (SelectFiled.Contains("lastcodetime,"))
                {
                    query.Select(p => new { p.LastCodeTime });
                }
                if (SelectFiled.Contains("wechatfaild,"))
                {
                    query.Select(p => new { p.WechatFaild });
                }
                if (SelectFiled.Contains("toerp,"))
                {
                    query.Select(p => new { p.ToErp });
                }
                if (SelectFiled.Contains("isdelete,"))
                {
                    query.Select(p => new { p.IsDelete });
                }
                if (SelectFiled.Contains("freight,"))
                {
                    query.Select(p => new { p.Freight });
                }
                if (SelectFiled.Contains("userdesign,"))
                {
                    query.Select(p => new { p.UserDesign });
                }
                if (SelectFiled.Contains("isadmin,"))
                {
                    query.Select(p => new { p.IsAdmin });
                }
                if (SelectFiled.Contains("adminname,"))
                {
                    query.Select(p => new { p.AdminName });
                }
                if (SelectFiled.Contains("name,"))
                {
                    query.Select(p => new { p.Name });
                }
                if (SelectFiled.Contains("addrarea,"))
                {
                    query.Select(p => new { p.AddrArea });
                }
                if (SelectFiled.Contains("addrdetail,"))
                {
                    query.Select(p => new { p.AddrDetail });
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
