using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SLSM.ErpWeb.Model.Request.wantBuyerInfo
{
    public class ConsignmentRequest
    {
        /// <summary>
        /// 订单Id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 收件人姓名
        /// </summary>
        public string AddresseeName { get; set; }
        /// <summary>
        /// 收件人电话
        /// </summary>
        public string AddresseePhone { get; set; }
        /// <summary>
        /// 选择快递公司
        /// </summary>
        public string ExpressCompany { get; set; }
        /// <summary>
        /// 快递单号
        /// </summary>
        public string ExpressNo { get; set; }
        /// <summary>
        ///快递重量
        /// </summary>
        public Double? ExpressWeight { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string ExpressContext { get; set; }
    }
}