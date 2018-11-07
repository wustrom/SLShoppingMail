using Aliyun.Acs.Dysmsapi.Model.V20170525;
using AliyunHelper.SendMail;
using Common;
using Common.Extend;
using Common.Helper;
using DbOpertion.Models;
using DbOpertion.Operation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbOpertion.Function
{
    public partial class OrderListFunc : SingleTon<OrderListFunc>
    {
        /// <summary>
        /// 根据Id筛选
        /// </summary>
        /// <param name="Start">开始数据</param>
        /// <param name="PageSize">页面大小</param>
        /// <param name="UserId">用户Id</param>
        /// <param name="status">状态</param>
        /// <returns></returns>
        public List<Order_Info> SelectOrder(int UserId, int? status = null)
        {
            return Order_InfoOper.Instance.SelectAll(new Order_Info { UserId = UserId, Status = status, IsDelete = false }).OrderByDescending(p => p.OrderTime).ToList();
        }

        /// <summary>
        /// 根据Id筛选
        /// </summary>
        /// <param name="Start">开始数据</param>
        /// <param name="PageSize">页面大小</param>
        /// <param name="UserId">用户Id</param>
        /// <param name="status">状态</param>
        /// <returns></returns>
        public List<Order_Info> SelectOrder(int Start, int PageSize, int UserId, int? status = null)
        {
            return Order_InfoOper.Instance.SelectByPage("OrderTime", Start, PageSize, true, new Order_Info { UserId = UserId, Status = status, IsDelete = false });
        }


        public List<Order_Detail_View> SelectDetail(int Start, int PageSize, int OrderId)
        {
            return Order_Detail_ViewOper.Instance.SelectByPage("Id", Start, PageSize, true, new Order_Detail_View { OrderId = OrderId });
        }
        /// <summary>
        /// 获取订单信息
        /// </summary>
        /// <param name="ListOrderIds"></param>
        /// <returns></returns>
        public Order_Info SelectOrderInfo(int Id)
        {
            return Order_InfoOper.Instance.SelectById(Id);
        }

        /// <summary>
        /// 筛选全部数据
        /// </summary>
        /// <param name="Id">用户Id</param>
        /// <returns></returns>
        public Order_Detail SelectOrderDetailById(int KeyId)
        {
            return Order_DetailOper.Instance.SelectById(KeyId);
        }

        /// <summary>
        /// 根据Id筛选
        /// </summary>
        /// <param name="ListOrderIds"></param>
        /// <returns></returns>
        public List<Order_Detail_View> SelectOrderCommodity(List<string> ListOrderIds)
        {
            return Order_DetailOper.Instance.SelectByOrderCommodity(ListOrderIds);
        }

        /// <summary>
        /// 根据Id筛选
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public Order_Detail_View SelectOrderCommodityId(int Id)
        {
            return Order_Detail_ViewOper.Instance.SelectById(Id);
        }
        /// <summary>
        /// 判断是否已被提交退货
        /// </summary>
        /// <param name="DetailId"></param>
        /// <returns></returns>
        public bool ReturnCount(int DetailId)
        {
            return Sales_ReturnOper.Instance.SelectCount(new Sales_Return { DetailId = DetailId }) > 0 ? true : false;
        }
        /// <summary>
        /// 进行提交退货
        /// </summary>
        /// <param name="res"></param>
        /// <returns></returns>
        public string ReturnInfo(Sales_Return res)
        {
            if (!ReturnCount(res.DetailId.Value))
            {
                if (Sales_ReturnOper.Instance.Insert(res))
                {
                    return "true";
                }
                else
                {
                    return "退货信息插入失败！";
                }
            }
            else
            {
                return "该记录已有退款信息，无法重复提交！";
            }
        }

        /// <summary>
        /// 获得网站订单列表
        /// </summary>
        /// <param name="start">开始数据条数</param>
        /// <param name="PageSize">页面大小</param>
        /// <param name="sort">排序方式</param>
        /// <param name="order">升序还是降序</param>
        /// <param name="OrderType">订单类型</param>
        /// <param name="SearchName">搜索内容</param>
        /// <param name="StatusType">订单状态</param>
        /// <returns></returns>
        public List<Order_Allinfo> GetOrderList(int start, int PageSize, string sort, string order, int OrderType, string SearchName, int? StatusType)
        {
            if (sort == null)
            {
                return Order_AllinfoOper.Instance.SelectByVaguePage("Id", start, PageSize, true, new Order_Allinfo { OrderType = OrderType, Status = StatusType, IsDelete = false }, SearchName);
            }
            else
            {
                bool desc = order.ToLower() == "desc" ? true : false;
                return Order_AllinfoOper.Instance.SelectByVaguePage(sort, start, PageSize, desc, new Order_Allinfo { OrderType = OrderType, Status = StatusType, IsDelete = false }, SearchName);
            }
        }

        /// <summary>
        /// 获得网站订单计数
        /// </summary>
        /// <param name="OrderType">订单类型</param>
        /// <param name="SearchName">搜索内容</param>
        /// <returns></returns>
        public int GetOrderCount(int OrderType, string SearchName, int? StatusType)
        {
            return Order_AllinfoOper.Instance.SelectByVagueCount(new Order_Allinfo { OrderType = OrderType, Status = StatusType, IsDelete = false }, SearchName);
        }
        //判断个数
        public int SelectOrderCount(int UserId, Int32? Status = null)
        {
            return Order_InfoOper.Instance.SelectCount(new Order_Info { UserId = UserId, Status = Status });
        }


        public bool UpdateOrderStatus(Order_Info ord)
        {
            return Order_InfoOper.Instance.Update(ord);
        }

    }
}