using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SLSM.ErpWeb.Model.Request.Deceive
{
    public class DeliverRequest
    {
        /// <summary>
        /// 采购单Id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 采购单Id列
        /// </summary>
        public string Ids { get; set; }
        /// <summary>
        /// 采购单状态
        /// </summary>
        public string Status { get; set; }
        /// <summary>
        /// 品检结果
        /// </summary>
        public string CheckStatus { get; set; }
        /// <summary>
        /// 合同编号
        /// </summary>
        public string ContractNumber { get; set; }
        /// <summary>
        /// 合同签订时间
        /// </summary>
        public DateTime SignedTime { get; set; }
        /// <summary>
        /// 宁波联系人
        /// </summary>
        public string SLSMContacts { get; set; }
        /// <summary>
        /// 宁波电话
        /// </summary>
        public string SLSMPhone { get; set; }
        /// <summary>
        /// 宁波传真
        /// </summary>
        public string SLSMFaxNumber { get; set; }
        /// <summary>
        /// 宁波Email
        /// </summary>
        public string SLSMEmail { get; set; }
        /// <summary>
        /// 合同条约
        /// </summary>
        public string ContractContext { get; set; }
        /// <summary>
        /// 采购单描述
        /// </summary>
        public string DeliverCountext { get; set; }
        /// <summary>
        /// 送货单物流公司
        /// </summary>
        public string DeliverCompany { get; set; }
        /// <summary>
        /// 送货单快递单号
        /// </summary>
        public string DeeliverExpressNo { get; set; }
        /// <summary>
        /// 制单人
        /// </summary>
        public string SinglePerson { get; set; }
        /// <summary>
        /// 送货单制单人
        /// </summary>
        public string DeliverSinglePerson { get; set; }

    }
}