using Common;
using Common.Extend;
using Common.Helper;
using DbOpertion.Models;
using DbOpertion.Operation;
using log4net;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DbOpertion.Function
{
    /// <summary>
    /// 订单方法
    /// </summary>
    public partial class OrderFunc : SingleTon<OrderFunc>
    {
        #region 创建订单
        /// <summary>
        /// 创建订单
        /// </summary>
        /// <param name="Address">地址</param>
        /// <param name="userId">用户ID</param>
        /// <param name="ShopCartIds">购物车列表</param>
        /// <param name="UserDecount">用户折扣</param>
        /// <returns></returns>
        public Tuple<Order_Info, string> CreateOnline(int orderType, string Address, int userId, string ShopCartIds, decimal UserDecount, string name, string Phone, string Invoice)
        {
            var MysqlHelper = SqlHelper.GetMySqlHelper("transaction");
            var connection = MysqlHelper.CreatConn();
            var transaction = MysqlHelper.GetTransaction();
            try
            {
                #region 下单
                var order = CreateOrder(orderType, Address, userId, ShopCartIds, UserDecount, connection, transaction, 1, name, Phone, Invoice);
                if (order.Item1 != null)
                {
                    transaction.Commit();
                    connection.Close();
                    return order;
                }
                else
                {
                    transaction.Rollback();
                    connection.Close();
                }
                #endregion
                return order;
            }
            catch (Exception e)
            {
                transaction.Rollback();
                connection.Close();
                return new Tuple<Order_Info, string>(item1: null, item2: e.Message);
            }
        }

        /// <summary>
        /// 创建订单
        /// </summary>
        /// <param name="Address">地址</param>
        /// <param name="userId">用户ID</param>
        /// <param name="ShopCartIds">购物车列表</param>
        /// <param name="UserDecount">用户折扣</param>
        /// <returns></returns>
        public Tuple<Order_Info, string> CreateAlipay(int orderType, string Address, int userId, string ShopCartIds, decimal UserDecount, string name, string Phone, string Invoice)
        {
            var orderNo = DateTime.Now.ToString("yyMMddHHmmssfff") + RandHelper.Instance.Str(5);
            var MysqlHelper = SqlHelper.GetMySqlHelper("transaction");
            var connection = MysqlHelper.CreatConn();
            var transaction = MysqlHelper.GetTransaction();
            try
            {
                var order = CreateOrder(orderType, Address, userId, ShopCartIds, UserDecount, connection, transaction, 2, name, Phone, Invoice);
                #region 下单
                if (order.Item1 != null)
                {
                    transaction.Commit();
                    connection.Close();
                    return order;
                }
                else
                {
                    transaction.Rollback();
                    connection.Close();
                }
                #endregion

            }
            catch (Exception)
            {
                transaction.Rollback();
                connection.Close();
            }
            return null;
        }

        /// <summary>
        /// 创建订单
        /// </summary>
        /// <param name="Address">地址</param>
        /// <param name="userId">用户ID</param>
        /// <param name="ShopCartIds">购物车列表</param>
        /// <param name="UserDecount">用户折扣</param>
        /// <returns></returns>
        public Tuple<Order_Info, string> CreateWechat(int orderType, string Address, int userId, string ShopCartIds, decimal UserDecount, string name, string Phone, string Invoice)
        {

            var MysqlHelper = SqlHelper.GetMySqlHelper("transaction");
            var connection = MysqlHelper.CreatConn();
            var transaction = MysqlHelper.GetTransaction();
            try
            {
                var order = CreateOrder(orderType, Address, userId, ShopCartIds, UserDecount, connection, transaction, 3, name, Phone, Invoice);
                #region 下单
                if (order.Item1 != null)
                {
                    transaction.Commit();
                    connection.Close();
                    return order;
                }
                else
                {
                    transaction.Rollback();
                    connection.Close();
                }
                #endregion
            }
            catch (Exception)
            {
                transaction.Rollback();
                connection.Close();
            }
            return null;
        }

        /// <summary>
        /// 创建订单
        /// </summary>
        /// <param name="Address">地址</param>
        /// <param name="userId">用户ID</param>
        /// <param name="ShopCartIds">购物车列表</param>
        /// <param name="UserDecount">用户折扣</param>
        /// <param name="connection">链接</param>
        /// <param name="transaction">事务</param>
        /// <returns></returns>
        private Tuple<Order_Info, string> CreateOrder(int orderType, string Address, int userId, string ShopCartIds, decimal UserDecount, IDbConnection connection, IDbTransaction transaction, int PayType, string name, string Phone, string Invoice)
        {
            var orderNo = DateTime.Now.ToString("yyMMdd") + (TodayorderOper.Instance.SelectAll(null, null, connection, transaction).FirstOrDefault().OrderCount + 1).ToString("000");

            #region 地址添加
            //地址分割
            //var ArrayAddress = Address.Split(' ').Where(p => !p.IsNullOrEmpty()).ToList();
            //Address addr = new Address
            //{
            //    UserId = userId,
            //    AddrArea = $"{ArrayAddress[0]},{ArrayAddress[1]},{ArrayAddress[2]}",
            //    AddrDetail = ArrayAddress[3],
            //    ContactName = name,
            //    ContactPhone = Phone
            //};
            //if (AddressFunc.Instance.SelectAll(addr).Count == 0)
            //{
            //    if (AddressFunc.Instance.AdressAdd(addr) <= 0)
            //    {
            //        return new Tuple<Order_Info, string>(null, "地址添加失败！");
            //    }
            //}
            #endregion

            #region 订单信息处理
            Order_Info info = new Order_Info
            {
                Address = Address,
                OrderNo = orderNo,
                OrderTime = DateTime.Now,
                OrderType = orderType,
                PayType = PayType,
                Status = 1,
                UserId = userId,
                BuyName = name,
                Phone = Phone.Trim(),
                Invoice = Invoice,
                InvoiceId = Invoice.ParseInt(),
                LastCodeTime = DateTime.Now
            };

            #endregion

            #region 订单明细处理
            var listCart = ShopcartOper.Instance.SelectByIds(ShopCartIds.Split(',').ToList(), connection, transaction);
            var CommdityList = CommodityOper.Instance.SelectByKeys("id", listCart.Where(q => q != null).Select(p => p.CommodityId.Value.ToString()).ToList(), connection, transaction);
            var StockList = Materials_Stock_ViewOper.Instance.SelectByKeys("Raw_materialsId", CommdityList.Where(q => q.MaterialId != null).Select(p => p.MaterialId.Value.ToString()).ToList(), connection, transaction);
            var MaterialsList = Raw_MaterialsOper.Instance.SelectByKeys("Id", CommdityList.Where(q => q.MaterialId != null).Select(p => p.MaterialId.Value.ToString()).ToList(), connection, transaction);
            var StorageList = StorageOper.Instance.SelectByKeys("Raw_materialsId", CommdityList.Where(q => q.MaterialId != null).Select(p => p.MaterialId.Value.ToString()).ToList(), connection, transaction);
            var list = CommodityPriceFunc.Instance.SelectByIds(listCart.Select(p => p.CommodityId).ToList());
            List<Order_Detail> listDetail = new List<Order_Detail>();
            foreach (var item in listCart)
            {
                var commdity = CommdityList.Where(p => p.Id == item.CommodityId).FirstOrDefault();
                var materials = MaterialsList.Where(p => p.Id == commdity.MaterialId).FirstOrDefault();
                var priceArray = new List<Tuple<int?, decimal?>>();
                if (materials.SalesInfoList == null)
                {
                    var priceItemList = list.Where(p => p.CommodityId == commdity.Id).OrderByDescending(p => p.StageAmount);
                    foreach (var priceitem in priceItemList)
                    {
                        priceArray.Add(new Tuple<int?, decimal?>(item1: priceitem.StageAmount, item2: priceitem.StagePrice));
                    }
                }
                else
                {
                    var saleinfo = materials.SalesInfoList.Split(';').Where(p => !string.IsNullOrEmpty(p)).ToList();
                    foreach (var saleitem in saleinfo)
                    {
                        var saledetailInfo = saleitem.Split('|').Where(p => !string.IsNullOrEmpty(p)).ToList();
                        if (item.PrintingMethod == "PrintFunc2")
                        {
                            priceArray.Add(new Tuple<int?, decimal?>(item1: saledetailInfo[0].ParseInt(), item2: saledetailInfo[2].ParseDecimal()));
                        }
                        else if (item.PrintingMethod == "PrintFunc3")
                        {
                            priceArray.Add(new Tuple<int?, decimal?>(item1: saledetailInfo[0].ParseInt(), item2: saledetailInfo[3].ParseDecimal()));
                        }
                        else
                        {
                            priceArray.Add(new Tuple<int?, decimal?>(item1: saledetailInfo[0].ParseInt(), item2: saledetailInfo[1].ParseDecimal()));
                        }
                    }
                    var priceInfo = list.Where(p => p.StageAmount == 0).FirstOrDefault();
                    if (priceInfo != null)
                    {
                        priceArray.Add(new Tuple<int?, decimal?>(item1: 0, item2: priceInfo.StagePrice));
                    }
                }
                var price = priceArray.Where(p => p.Item1 < item.Amount).OrderByDescending(p => p.Item1).FirstOrDefault();

                #region 判断商品是否存在
                var Commdity = CommdityList.Where(p => p.Id == item.CommodityId).FirstOrDefault();
                if (Commdity == null)
                {
                    return new Tuple<Order_Info, string>(null, "商品不存在！");
                }
                #endregion
                #region 判断库存是否足够
                var Stock = StockList.Where(p => p.Raw_materialsId == Commdity.MaterialId && p.ColorName == item.Color).FirstOrDefault();
                if (Stock == null || (Stock.available_stock == null ? 0 : Stock.available_stock) < item.Amount)
                {
                    return new Tuple<Order_Info, string>(null, "库存不足，请联系客服！");
                }
                var ThisStorageList = StorageList.Where(p => p.Raw_materialsId == Commdity.MaterialId && p.Color == Stock.SKU).ToList();
                #region 修改库存数量
                var Amount = item.Amount;
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
                                return new Tuple<Order_Info, string>(null, "库存更新失败！");
                            }
                            break;
                        }
                        else
                        {
                            Amount = Amount - Storage.stock + Storage.freeze_stock;
                            Storage.freeze_stock = Storage.stock;
                            if (!StorageOper.Instance.Update(Storage, connection, transaction))
                            {
                                return new Tuple<Order_Info, string>(null, "库存更新失败！");
                            }
                        }
                    }
                }
                #endregion
                #endregion
                if (price != null && item.Amount != null)
                {
                    decimal? payMoney = 0;
                    payMoney = item.Amount * price.Item2.Value * UserDecount;
                    Order_Detail detail = new Order_Detail
                    {
                        Color = ColorinfoFunc.Instance.GetColorID(item.Color).ParseInt(),
                        CommodityId = item.CommodityId,
                        Amount = item.Amount,
                        ShopCartId = item.Id,
                        PayMoney = payMoney,
                        PrintingMethod = item.PrintingMethod
                    };
                    listDetail.Add(detail);
                }
                else
                {
                    return new Tuple<Order_Info, string>(null, "对不起，价格出现问题！");
                }
            }

            #endregion

            #region 添加方法
            info.TotalPrice = listDetail.Sum(p => p.PayMoney);
            if (info.TotalPrice < 10)
            {
                info.TotalPrice = 10;
                info.Freight = "10";
            }
            else if (info.TotalPrice > 10 && info.TotalPrice < 100)
            {
                info.TotalPrice = info.TotalPrice + 10;
                info.Freight = "10";
            }
            var OrderKey = Order_InfoOper.Instance.InsertReturnKey(info, connection, transaction);
            if (OrderKey <= 0)
            {
                return new Tuple<Order_Info, string>(null, "订单添加失败！");
            }
            info.Id = OrderKey;
            if (listDetail.Count == 0)
            {
                return new Tuple<Order_Info, string>(null, "至少要有一件商品！");
            }
            foreach (var item in listDetail)
            {
                item.OrderId = OrderKey;
                if (!Order_DetailOper.Instance.Insert(item, connection, transaction))
                {
                    return new Tuple<Order_Info, string>(null, "至少要有一件商品！");
                }
            }
            #endregion

            #region 删除购物车
            foreach (var item in listCart)
            {
                if (!ShopcartOper.Instance.DeleteById(item.Id, connection, transaction))
                {
                    return new Tuple<Order_Info, string>(null, "购物车删除失败！");
                }
            }
            #endregion

            return new Tuple<Order_Info, string>(info, "成功！");
        }
        #endregion

        #region 订单量
        /// <summary>
        /// 今日订单量
        /// </summary>
        /// <returns></returns>
        public Todayorder TodayOrder()
        {
            return TodayorderOper.Instance.SelectAll().FirstOrDefault();
        }
        #endregion

        #region 订单信息
        /// <summary>
        /// 获得订单的信息
        /// </summary>
        /// <param name="OrderId">订单Id</param>
        /// <returns></returns>
        public Tuple<Order_Allinfo, List<Order_Detail_View>> GetOrderInfo(int OrderId)
        {
            Order_Allinfo order = Order_AllinfoOper.Instance.SelectById(OrderId);
            List<Order_Detail_View> list = Order_Detail_ViewOper.Instance.SelectAll(new Order_Detail_View { OrderId = OrderId });
            return new Tuple<Order_Allinfo, List<Order_Detail_View>>(item1: order, item2: list);
        }

        /// <summary>
        /// 获得订单的信息
        /// </summary>
        /// <param name="OrderId">订单Id</param>
        /// <returns></returns>
        public Order_Info GetOrderById(int OrderId)
        {
            return Order_InfoOper.Instance.SelectById(OrderId);
        }

        /// <summary>
        /// 订单确认支付
        /// </summary>
        /// <param name="OrderNo">订单号码</param>
        /// <returns></returns>
        public bool OrderSurePay(string OrderNo)
        {
            return Order_InfoOper.Instance.OrderSurePay(OrderNo);
        }
        #endregion

        #region 订单状态修改
        /// <summary>
        /// 确认订单支付
        /// </summary>
        /// <param name="Id">订单Id</param>
        /// <returns></returns>
        public bool SurePay(int Id)
        {
            var orderinfo = Order_InfoOper.Instance.SelectById(Id);
            //线下支付并且订单状态为未支付的才能支付成功
            if (orderinfo.PayType == 1 && orderinfo.Status == 1)
            {
                return Order_InfoOper.Instance.Update(new Order_Info { Id = Id, Status = 3 });
            }
            else
            {
                return false;
            }

        }
        /// <summary>
        /// 发货成功
        /// </summary>
        /// <param name="Id">订单Id</param>
        /// <returns></returns>
        public string SendThing(int Id)
        {
            var orderinfo = Order_InfoOper.Instance.SelectById(Id);
            //状态为待发货才可以
            if (orderinfo.Status == 3)
            {
                if (orderinfo.ToErp != true)
                {
                    return "订单尚未转到Erp!";
                }
                var OrderdetailList = Production_Orderdetail_ViewOper.Instance.SelectAll(new Production_Orderdetail_View { OrderId = orderinfo.Id });
                OrderdetailList = OrderdetailList.Where(p => p.OrderStatus != "成品已发货").ToList();
                if (OrderdetailList.Count != 0)
                {
                    return "订单尚未制作完成!";
                }
                return Order_InfoOper.Instance.Update(new Order_Info { Id = Id, Status = 4 }).ToString();
            }
            else
            {
                return "订单状态不为待发货!";
            }
        }

        /// <summary>
        /// 发货成功
        /// </summary>
        /// <param name="Id">订单Id</param>
        /// <returns></returns>
        public string SendThing2(int Id)
        {
            var orderinfo = Order_InfoOper.Instance.SelectById(Id);
            //状态为待发货才可以
            if (orderinfo.Status == 3)
            {
                if (orderinfo.ToErp == true)
                {
                    return "订单已转到Erp!";
                }
                return Order_InfoOper.Instance.Update(new Order_Info { Id = Id, Status = 4 }).ToString();
            }
            else
            {
                return "订单状态不为待发货!";
            }
        }

        /// <summary>
        /// 更新模型
        /// </summary>
        /// <param name="model">订单模型</param>
        /// <returns></returns>
        public bool UpdateModel(Order_Info model)
        {
            return Order_InfoOper.Instance.Update(model);

        }

        /// <summary>
        /// 确认收货
        /// </summary>
        /// <param name="Id">订单Id</param>
        /// <returns></returns>
        public bool EnterThing(int Id)
        {
            var orderinfo = Order_InfoOper.Instance.SelectById(Id);
            //状态为待收货才可以
            if (orderinfo.Status == 4)
            {
                return Order_InfoOper.Instance.Update(new Order_Info { Id = Id, Status = 5 });
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 退货成功
        /// </summary>
        /// <param name="Id">订单Id</param>
        /// <returns></returns>
        public bool ReturnSuccess(int Id)
        {
            var orderinfo = Order_InfoOper.Instance.SelectById(Id);
            //状态为退货中才可以
            if (orderinfo.Status == 7)
            {
                return Order_InfoOper.Instance.Update(new Order_Info { Id = Id, Status = 9 });
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 退货失败
        /// </summary>
        /// <param name="Id">订单Id</param>
        /// <returns></returns>
        public bool ReturnFail(int Id)
        {
            var orderinfo = Order_InfoOper.Instance.SelectById(Id);
            //线下支付并且订单状态为未支付的才能支付成功
            if (orderinfo.Status == 7)
            {
                return Order_InfoOper.Instance.Update(new Order_Info { Id = Id, Status = 8 });
            }
            else
            {
                return false;
            }
        }
        #endregion


        /// <summary>
        /// 订单转到Erp
        /// </summary>
        /// <param name="Id">订单Id</param>
        /// <returns></returns>
        public bool ConvertToErp(int Id)
        {
            var userGuid = CookieOper.Instance.GetUserGuid();
            var user = MemCacheHelper2.Instance.Cache.GetModel<DbOpertion.Models.Erploginuer>("AdminUserGuID_" + userGuid);
            var MysqlHelper = SqlHelper.GetMySqlHelper("transaction");
            var connection = MysqlHelper.CreatConn();
            var transaction = MysqlHelper.GetTransaction();
            try
            {
                var orderinfo = Order_InfoOper.Instance.SelectById(Id, connection, transaction);
                if (orderinfo.ToErp == true)
                {
                    return false;
                }
                else
                {
                    orderinfo.ToErp = true;
                    if (!Order_InfoOper.Instance.Update(orderinfo))
                    {
                        return false;
                    }
                }
                var OrderDetail = Order_DetailOper.Instance.SelectAll(new Order_Detail { OrderId = Id }, null, connection, transaction);
                for (int i = 0; i < OrderDetail.Count; i++)
                {
                    var OrderType = "";
                    if (string.IsNullOrEmpty(OrderDetail[i].WordOpertion) && string.IsNullOrEmpty(OrderDetail[i].OnLineImageOpertion) && string.IsNullOrEmpty(OrderDetail[i].CustomImageOpertion))
                    {
                        OrderType = "样品";
                    }
                    else
                    {
                        OrderType = "打样";
                    }
                    if (OrderDetail[i].Amount > 20)
                    {
                        OrderType = "正常";
                    }
                    Production production = new Production
                    {
                        ProductionNo = orderinfo.OrderNo + "-" + (i + 1).ToString(),
                        order_detailId = OrderDetail[i].Id,
                        DesignerStatus = "设计未处理",
                        ProductionStatus = "待处理",
                        OrderStatus = "待处理",
                        InspectionStatus = "待处理",
                        OrderType = OrderType,
                        KefuPerson = user.erpLoginName
                    };
                    if (!ProductionOper.Instance.Insert(production, connection, transaction))
                    {
                        transaction.Rollback();
                        connection.Close();
                        return false;
                    }
                }
                transaction.Commit();
                connection.Close();
                return true;
            }
            catch (Exception)
            {
                transaction.Rollback();
                connection.Close();
                throw;
            }
        }


        /// <summary>
        /// 取消大于4小时未支付订单
        /// </summary>
        /// <param name="Id">订单Id</param>
        /// <returns></returns>
        public void CancelTodayOrder()
        {
            var ColorList = ColorinfoFunc.Instance.GetAllColorListBase();
            var orderListInfo = Order_InfoOper.Instance.SelectAll(new Order_Info { IsDelete = false, Status = 1 }, null).OrderByDescending(p => p.Id);
            var orderDetailList = Order_DetailOper.Instance.SelectByKeys("OrderId", orderListInfo.Where(q => q != null).Select(p => p.Id.ToString()).ToList());
            var CommdityList = CommodityOper.Instance.SelectByKeys("id", orderDetailList.Where(q => q != null).Select(p => p.CommodityId.Value.ToString()).ToList());
            var newOrderList = orderListInfo.Where(p => p.OrderTime.Value.AddHours(4) < DateTime.Now);
            var StockList = Materials_Stock_ViewOper.Instance.SelectByKeys("Raw_materialsId", CommdityList.Where(q => q.MaterialId != null).Select(p => p.MaterialId.Value.ToString()).ToList());
            var StorageList = StorageOper.Instance.SelectByKeys("Raw_materialsId", CommdityList.Where(q => q.MaterialId != null).Select(p => p.MaterialId.Value.ToString()).ToList());
            foreach (var item in newOrderList)
            {
                item.IsDelete = true;
                Order_InfoFunc.Instance.Update(item);
                var thisOrderDeatil = orderDetailList.Where(p => p.OrderId == item.Id).ToList();
                foreach (var itemDeatil in thisOrderDeatil)
                {
                    var commdity = CommdityList.Where(p => p.Id == itemDeatil.CommodityId).FirstOrDefault();
                    var colorItem = ColorList.Where(p => p.Id == itemDeatil.Color).FirstOrDefault();
                    #region 判断库存是否足够
                    var Stock = StockList.Where(p => p.Raw_materialsId == commdity.MaterialId && p.ColorName == colorItem.ChinaDescribe).FirstOrDefault();
                    if (Stock == null || (Stock.freeze_stock == null ? 0 : Stock.freeze_stock) < itemDeatil.Amount)
                    {
                        break;
                    }
                    var ThisStorageList = StorageList.Where(p => p.Raw_materialsId == commdity.MaterialId && p.Color == Stock.SKU).ToList();
                    #region 修改库存数量
                    var Amount = itemDeatil.Amount;
                    foreach (var Storage in ThisStorageList)
                    {
                        if (Storage.freeze_stock > 0)
                        {
                            if (Amount < Storage.freeze_stock)
                            {
                                Storage.freeze_stock = Storage.freeze_stock - Amount;
                                Amount = 0;
                                if (!StorageOper.Instance.Update(Storage))
                                {

                                }
                            }
                            else
                            {
                                Amount = Amount - Storage.freeze_stock;
                                Storage.freeze_stock = 0;
                                if (!StorageOper.Instance.Update(Storage))
                                {

                                }
                            }
                        }
                    }
                    #endregion
                    #endregion
                }
            }
        }

        /// <summary>
        /// 取消大于4小时未支付订单
        /// </summary>
        /// <param name="Id">订单Id</param>
        /// <returns></returns>
        public bool CancelOrder(int OrderId)
        {
            var ColorList = ColorinfoFunc.Instance.GetAllColorListBase();
            var orderListInfo = Order_InfoOper.Instance.SelectAll(new Order_Info { IsDelete = false, Status = 1, Id = OrderId }, null).OrderByDescending(p => p.Id);
            var orderDetailList = Order_DetailOper.Instance.SelectByKeys("OrderId", orderListInfo.Where(q => q != null).Select(p => p.Id.ToString()).ToList());
            var CommdityList = CommodityOper.Instance.SelectByKeys("id", orderDetailList.Where(q => q != null).Select(p => p.CommodityId.Value.ToString()).ToList());
            var StockList = Materials_Stock_ViewOper.Instance.SelectByKeys("Raw_materialsId", CommdityList.Where(q => q.MaterialId != null).Select(p => p.MaterialId.Value.ToString()).ToList());
            var StorageList = StorageOper.Instance.SelectByKeys("Raw_materialsId", CommdityList.Where(q => q.MaterialId != null).Select(p => p.MaterialId.Value.ToString()).ToList());
            var MysqlHelper = SqlHelper.GetMySqlHelper("transaction");
            var connection = MysqlHelper.CreatConn();
            var transaction = MysqlHelper.GetTransaction();
            try
            {
                foreach (var item in orderListInfo)
                {
                    item.IsDelete = true;
                    Order_InfoOper.Instance.Update(item, connection, transaction);
                    var thisOrderDeatil = orderDetailList.Where(p => p.OrderId == item.Id).ToList();
                    foreach (var itemDeatil in thisOrderDeatil)
                    {
                        var commdity = CommdityList.Where(p => p.Id == itemDeatil.CommodityId).FirstOrDefault();
                        var colorItem = ColorList.Where(p => p.Id == itemDeatil.Color).FirstOrDefault();
                        #region 判断库存是否足够
                        var Stock = StockList.Where(p => p.Raw_materialsId == commdity.MaterialId && p.ColorName == colorItem.ChinaDescribe).FirstOrDefault();
                        if (Stock == null || (Stock.freeze_stock == null ? 0 : Stock.freeze_stock) < itemDeatil.Amount)
                        {
                            transaction.Rollback();
                            connection.Close();
                            return false;
                        }
                        var ThisStorageList = StorageList.Where(p => p.Raw_materialsId == commdity.MaterialId && p.Color == Stock.SKU).ToList();
                        #region 修改库存数量
                        var Amount = itemDeatil.Amount;
                        foreach (var Storage in ThisStorageList)
                        {
                            if (Storage.freeze_stock > 0)
                            {
                                if (Amount < Storage.freeze_stock)
                                {
                                    Storage.freeze_stock = Storage.freeze_stock - Amount;
                                    Amount = 0;
                                    if (!StorageOper.Instance.Update(Storage))
                                    {
                                        transaction.Rollback();
                                        connection.Close();
                                        return false;
                                    }
                                }
                                else
                                {
                                    Amount = Amount - Storage.freeze_stock;
                                    Storage.freeze_stock = 0;

                                    if (!StorageOper.Instance.Update(Storage))
                                    {
                                        transaction.Rollback();
                                        connection.Close();
                                        return false;
                                    }
                                }
                            }
                        }
                        #endregion
                        #endregion
                    }
                }
                transaction.Commit();
                connection.Close();
                return true;
            }
            catch (Exception e)
            {
                transaction.Rollback();
                connection.Close();
                return false;
            }

        }
    }
}
