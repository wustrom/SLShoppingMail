using System;

namespace DbOpertion.Models
{
    [Serializable]
    public class Buyer_Producer_View
    {
        /// <summary>
        /// 采购表Id
        /// </summary>
        public Int32 Id { get; set; }
        /// <summary>
        /// 采购单编号
        /// </summary>
        public String BuyerNo { get; set; }
        /// <summary>
        /// 供货商Id
        /// </summary>
        public Int32? producerId { get; set; }
        /// <summary>
        /// 金额
        /// </summary>
        public Decimal? buyerMoney { get; set; }
        /// <summary>
        /// 采购日期
        /// </summary>
        public DateTime? buyerTime { get; set; }
        /// <summary>
        /// 应付日期
        /// </summary>
        public DateTime? wantTime { get; set; }
        /// <summary>
        /// 已付日期
        /// </summary>
        public DateTime? paidTime { get; set; }
        /// <summary>
        /// 已付账款
        /// </summary>
        public Decimal? wantmoney { get; set; }
        /// <summary>
        /// 状态(待下单,待送货品检,待入库,已入库,待退货,已退货,已取消)
        /// </summary>
        public String buyerStatus { get; set; }
        /// <summary>
        /// 品检结果(待品检,品检合格,品检不合格)
        /// </summary>
        public String checkStatus { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public String buyerContext { get; set; }
        /// <summary>
        /// 合同编号
        /// </summary>
        public String ContractNumber { get; set; }
        /// <summary>
        /// 合同签订日期
        /// </summary>
        public DateTime? SignedTime { get; set; }
        /// <summary>
        /// 宁波联系人
        /// </summary>
        public String SLSMContacts { get; set; }
        /// <summary>
        /// 宁波电话
        /// </summary>
        public String SLSMPhone { get; set; }
        /// <summary>
        /// 宁波传真
        /// </summary>
        public String SLSMFaxNumber { get; set; }
        /// <summary>
        /// 宁波Email
        /// </summary>
        public String SLSMEmail { get; set; }
        /// <summary>
        /// 合同条约
        /// </summary>
        public String ContractContext { get; set; }
        /// <summary>
        /// 送货物流公司
        /// </summary>
        public String DeliverCompany { get; set; }
        /// <summary>
        /// 快递单号
        /// </summary>
        public String DeeliverExpressNo { get; set; }
        /// <summary>
        /// 送货人
        /// </summary>
        public String DeliverMan { get; set; }
        /// <summary>
        /// 收货人
        /// </summary>
        public String DeliverConsignee { get; set; }
        /// <summary>
        /// 制单人
        /// </summary>
        public String SinglePerson { get; set; }
        /// <summary>
        /// 制单时间
        /// </summary>
        public DateTime? SingleTime { get; set; }
        /// <summary>
        /// 送货单制单人
        /// </summary>
        public String DeliverSinglePerson { get; set; }
        /// <summary>
        /// 送货单制单时间
        /// </summary>
        public DateTime? DeliverSingleTime { get; set; }
        /// <summary>
        /// 父节点Id
        /// </summary>
        public Int32? ParentId { get; set; }
        /// <summary>
        /// 入库金额
        /// </summary>
        public Decimal? AmountOfWare { get; set; }
        /// <summary>
        /// 不良信息
        /// </summary>
        public String BadInfo { get; set; }
        /// <summary>
        /// 检验结果
        /// </summary>
        public String TestResults { get; set; }
        /// <summary>
        /// 产品图片
        /// </summary>
        public String ProductImageInfo { get; set; }
        /// <summary>
        /// 验货员
        /// </summary>
        public String QCINSPECTOR { get; set; }
        /// <summary>
        /// 验货日期
        /// </summary>
        public DateTime? INSPECTIONDATE { get; set; }
        /// <summary>
        /// 供应商名称
        /// </summary>
        public String Name { get; set; }
        /// <summary>
        /// 企业账号
        /// </summary>
        public String AccountNumber { get; set; }
        /// <summary>
        /// 付款方式(开票后几天)
        /// </summary>
        public String AccountPeriod { get; set; }
        /// <summary>
        /// 地址
        /// </summary>
        public String Address { get; set; }
        /// <summary>
        /// 开户银行
        /// </summary>
        public String Bank { get; set; }
        /// <summary>
        /// 企业税号
        /// </summary>
        public String identify { get; set; }
        /// <summary>
        /// 供应产品
        /// </summary>
        public String SupplyProducts { get; set; }
        /// <summary>
        /// 企业传真
        /// </summary>
        public String FaxNumber { get; set; }

    }
}
