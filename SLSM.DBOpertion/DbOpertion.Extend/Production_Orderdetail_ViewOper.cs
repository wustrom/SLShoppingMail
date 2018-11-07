using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common.LambdaOpertion;
using Common.Extend;
using System.Data;
using DbOpertion.Models;
using Common.Extend.LambdaFunction;

namespace DbOpertion.Operation
{
    public partial class Production_Orderdetail_ViewOper : SingleTon<Production_Orderdetail_ViewOper>
    {
        #region 生产管理
        /// <summary>
        /// 模糊分页查询
        /// </summary>
        /// <param name="Key">排序方式</param>
        /// <param name="start">开始条数</param>
        /// <param name="PageSize">页面长度</param>
        /// <param name="desc">降序</param>
        /// <param name="Name">名称</param>
        /// <returns></returns>
        public List<Production_Orderdetail_View> SelectProductionPage(string Key, int start, int PageSize, bool desc, string Name, string Production, string Status)
        {
            var query = new LambdaQuery<Production_Orderdetail_View>();
            var querys = new LambdaQuery<Production_Orderdetail_View>();
            if (Status == "生产管理")
            {
                querys = query.Where(p => p.ProductionStatus == "待生产确认" || p.ProductionStatus == "待生产" || p.ProductionStatus == "生产中" || p.ProductionStatus == "生产已完成");
                if (Production != null && Production != "0")
                {
                    querys.Where(p => p.ProductionStatus == Production);
                }
            }
            else if (Status == "设计师管理")
            {
                querys = query.Where(p => (p.DesignerStatus == "生产退回待处理" && p.ReturnCount == 1) || p.DesignerStatus == "设计未处理" || p.DesignerStatus == "设计已处理" || p.DesignerStatus == "待客户确认" || (p.DesignerStatus == "设计已完成" && p.DesignerStatus == "生产已完成"));
                if (Production != null && Production != "0")
                {
                    querys.Where(p => p.DesignerStatus == Production);
                }
            }
            else if (Status == "订单管理")
            {
                querys = query.Where(p => p.OrderStatus == "设计退回待处理" || (p.OrderStatus == "生产退回待处理" && p.ReturnCount == 2) || p.OrderStatus == "设计已处理");
                if (Production != null && Production != "0")
                {
                    querys.Where(p => p.OrderStatus == Production);
                }
            }
            else if (Status == "成品品检")
            {
                querys = query.Where(p => p.InspectionStatus == "生产完成待品检" || p.InspectionStatus == "成品品检不合格" || p.InspectionStatus == "成品品检合格");
                if (Production != null && Production != "0")
                {
                    querys.Where(p => p.InspectionStatus.Like(Production));
                }
            }
            else if (Status == "发货管理")
            {
                querys = query.Where(p => p.OrderStatus == "品检合格待发货" || p.OrderStatus == "成品已发货");
                if (Production != null && Production != "0")
                {
                    querys.Where(p => p.OrderStatus == Production);
                }
            }
            if (Status == "成品品检")
            {
                if (!Name.IsNullOrEmpty())
                {
                    querys.Where(p => p.Id.Like(Name) || p.InspectionStatus.Like(Name) || p.commodityName.Like(Name) || p.OrderNo.Like(Name) || p.Amount.Like(Name) || p.Phone.Like(Name) || p.userName.Like(Name));
                }
            }
            if (Key != null)
            {
                querys.OrderByKey(Key, desc);
            }
            else
            {
                query.OrderBy(p => p.OrderTime, true);
            }
            return query.GetQueryPageList(start, PageSize);
        }

        /// <summary>
        /// 模糊分页查询数量
        /// </summary>
        /// <param name="Key">排序方式</param>
        /// <param name="start">开始条数</param>
        /// <param name="PageSize">页面长度</param>
        /// <param name="desc">降序</param>
        /// <param name="Name">名称</param>
        /// <returns></returns>
        public int SelectProductionCount(string Name, string Production, string Status)
        {
            var query = new LambdaQuery<Production_Orderdetail_View>();
            var querys = new LambdaQuery<Production_Orderdetail_View>();
            if (Status == "生产管理")
            {
                querys = query.Where(p => p.ProductionStatus == "待生产确认" || p.ProductionStatus == "待生产" || p.ProductionStatus == "生产中" || p.ProductionStatus == "生产已完成");
                if (Production != null && Production != "0")
                {
                    querys.Where(p => p.ProductionStatus == Production);
                }
            }
            else if (Status == "设计师管理")
            {
                querys = query.Where(p => (p.DesignerStatus == "生产退回待处理" && p.ReturnCount == 1) || p.DesignerStatus == "设计未处理" || p.DesignerStatus == "设计已处理" || p.DesignerStatus == "待客户确认");
                if (Production != null && Production != "0")
                {
                    querys.Where(p => p.DesignerStatus == Production);
                }
            }
            else if (Status == "订单管理")
            {
                querys = query.Where(p => p.OrderStatus == "设计退回待处理" || (p.OrderStatus == "生产退回待处理" && p.ReturnCount == 2) || p.OrderStatus == "设计已处理");
                if (Production != null && Production != "0")
                {
                    querys.Where(p => p.OrderStatus == Production);
                }
            }
            else if (Status == "成品品检")
            {
                querys = query.Where(p => p.InspectionStatus == "生产完成待品检" || p.InspectionStatus == "成品品检不合格" || p.InspectionStatus == "成品品检合格");
                if (Production != null && Production != "0")
                {
                    querys.Where(p => p.InspectionStatus.Like(Production));
                }
            }
            else if (Status == "发货管理")
            {
                querys = query.Where(p => p.OrderStatus == "品检合格待发货" || p.OrderStatus == "成品已发货");
                if (Production != null && Production != "0")
                {
                    querys.Where(p => p.OrderStatus == Production);
                }
            }
            if (Status == "成品品检")
            {
                if (!Name.IsNullOrEmpty())
                {
                    querys.Where(p => p.Id.Like(Name) || p.InspectionStatus.Like(Name) || p.commodityName.Like(Name) || p.OrderNo.Like(Name) || p.Amount.Like(Name) || p.Phone.Like(Name) || p.userName.Like(Name));
                }
            }
            return query.GetQueryCount();
        }
        #endregion
    }
}
