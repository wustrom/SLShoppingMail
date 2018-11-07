using System;

namespace DbOpertion.Models
{
    [Serializable]
    public class Deliver_Buyer_View
    {
        /// <summary>
        /// 送货单表Id
        /// </summary>
        public Int32 Id { get; set; }
        /// <summary>
        /// 采购单表Id
        /// </summary>
        public Int32? buyerId { get; set; }
        /// <summary>
        /// 采购日期
        /// </summary>
        public DateTime? buyerTime { get; set; }
        /// <summary>
        /// 原材料管理表Id
        /// </summary>
        public Int32? raw_materialsId { get; set; }
        /// <summary>
        /// 中文品名
        /// </summary>
        public String ChinaProductName { get; set; }
        /// <summary>
        /// 规格型号
        /// </summary>
        public String Specification { get; set; }
        /// <summary>
        /// 中文单位
        /// </summary>
        public String ChinaUnit { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        public String IsStatus { get; set; }
        /// <summary>
        /// 金额
        /// </summary>
        public Decimal? DeliverMoney { get; set; }
        /// <summary>
        /// 单价
        /// </summary>
        public Decimal? buyerPrice { get; set; }
        /// <summary>
        /// 颜色
        /// </summary>
        public String Color { get; set; }
        /// <summary>
        /// 说明
        /// </summary>
        public String DeliverCountext { get; set; }
        /// <summary>
        /// 已到达数量
        /// </summary>
        public Int32? AlreadyQuantity { get; set; }
        /// <summary>
        /// 已付账款
        /// </summary>
        public Decimal? wantmoney { get; set; }
        /// <summary>
        /// 应付日期
        /// </summary>
        public DateTime? wantTime { get; set; }
        /// <summary>
        /// 金额
        /// </summary>
        public Decimal? buyerMoney { get; set; }
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
        /// 宁波Email
        /// </summary>
        public String SLSMEmail { get; set; }
        /// <summary>
        /// 宁波传真
        /// </summary>
        public String SLSMFaxNumber { get; set; }
        /// <summary>
        /// 宁波电话
        /// </summary>
        public String SLSMPhone { get; set; }
        /// <summary>
        /// 合同条约
        /// </summary>
        public String ContractContext { get; set; }
        /// <summary>
        /// 数量
        /// </summary>
        public Int32? buyerCount { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public String buyerContext { get; set; }
        /// <summary>
        /// 供应商表Id
        /// </summary>
        public Int32? producerId { get; set; }
        /// <summary>
        /// 工厂货号
        /// </summary>
        public String FactoryNumber { get; set; }
        /// <summary>
        /// 价格标识
        /// </summary>
        public String PriceTag { get; set; }
        /// <summary>
        /// 供应商名称
        /// </summary>
        public String producerIdName { get; set; }
        /// <summary>
        /// 供应商名称
        /// </summary>
        public String producerName { get; set; }
        /// <summary>
        /// 状态(待下单,待送货品检,待入库,已入库,待退货,已退货,已取消)
        /// </summary>
        public String buyerStatus { get; set; }
        /// <summary>
        /// 品检结果(待品检,品检合格,品检不合格)
        /// </summary>
        public String checkStatus { get; set; }
        /// <summary>
        /// 编号
        /// </summary>
        public String ProductNo { get; set; }
        /// <summary>
        /// 净重
        /// </summary>
        public String NetWeight { get; set; }
        /// <summary>
        /// 外箱数量
        /// </summary>
        public String NumOuterBoxes { get; set; }
        /// <summary>
        /// 中箱数量
        /// </summary>
        public String NumMiddleBoxes { get; set; }
        /// <summary>
        /// 外箱高
        /// </summary>
        public Double? OuterBoxesHeight { get; set; }
        /// <summary>
        /// 外箱长
        /// </summary>
        public Double? OuterBoxesLength { get; set; }
        /// <summary>
        /// 外箱宽
        /// </summary>
        public Double? OuterBoxesWidth { get; set; }
        /// <summary>
        /// 产品描述
        /// </summary>
        public String ProductDesibe { get; set; }
        /// <summary>
        /// 颜色中文描述
        /// </summary>
        public String ChinaDescribe { get; set; }
        /// <summary>
        /// 数量
        /// </summary>
        public Int32? ParentCount { get; set; }

    }
}
