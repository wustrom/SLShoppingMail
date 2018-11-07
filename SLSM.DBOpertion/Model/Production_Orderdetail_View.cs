using System;

namespace DbOpertion.Models
{
    [Serializable]
    public class Production_Orderdetail_View
    {
        /// <summary>
        /// 生产管理单
        /// </summary>
        public Int32 Id { get; set; }
        /// <summary>
        /// 生产管理单编号
        /// </summary>
        public String OrderNo { get; set; }
        /// <summary>
        /// 订单时间
        /// </summary>
        public DateTime? OrderTime { get; set; }
        /// <summary>
        /// 设计师状态
        /// </summary>
        public String DesignerStatus { get; set; }
        /// <summary>
        /// 生产状态
        /// </summary>
        public String ProductionStatus { get; set; }
        /// <summary>
        /// 订单状态
        /// </summary>
        public String OrderStatus { get; set; }
        /// <summary>
        /// 订单类型(常规定制,样品,打样)
        /// </summary>
        public String OrderType { get; set; }
        /// <summary>
        /// 品检状态
        /// </summary>
        public String InspectionStatus { get; set; }
        /// <summary>
        /// 退回次数
        /// </summary>
        public Int32? ReturnCount { get; set; }
        /// <summary>
        /// 退回原因
        /// </summary>
        public String ReturnContext { get; set; }
        /// <summary>
        /// 客服反馈
        /// </summary>
        public String ServiceContext { get; set; }
        /// <summary>
        /// 设计文件
        /// </summary>
        public String DesignerZip { get; set; }
        /// <summary>
        /// 生产文件
        /// </summary>
        public String ProductionZip { get; set; }
        /// <summary>
        /// 订单表
        /// </summary>
        public Int32? order_detailId { get; set; }
        /// <summary>
        /// 选择快递公司
        /// </summary>
        public String ExpressCompany { get; set; }
        /// <summary>
        /// 称重重量
        /// </summary>
        public Double? ExpressWeight { get; set; }
        /// <summary>
        /// 快递单备注
        /// </summary>
        public String ExpressContext { get; set; }
        /// <summary>
        /// 快递单号
        /// </summary>
        public String ExpressNo { get; set; }
        /// <summary>
        /// 验货员
        /// </summary>
        public String QCINSPECTOR { get; set; }
        /// <summary>
        /// 验货日期
        /// </summary>
        public DateTime? INSPECTIONDATE { get; set; }
        /// <summary>
        /// 不良信息
        /// </summary>
        public String BadInfo { get; set; }
        /// <summary>
        /// 产品图片
        /// </summary>
        public String ProductImageInfo { get; set; }
        /// <summary>
        /// 检验结果
        /// </summary>
        public String TestResults { get; set; }
        /// <summary>
        /// 用户名称
        /// </summary>
        public String userName { get; set; }
        /// <summary>
        /// 用户手机号码
        /// </summary>
        public String Phone { get; set; }
        /// <summary>
        /// 用户公司地址
        /// </summary>
        public String CompanyAddr { get; set; }
        /// <summary>
        /// 用户公司名称
        /// </summary>
        public String CompanyName { get; set; }
        /// <summary>
        /// 原材料Id
        /// </summary>
        public Int32? MaterialId { get; set; }
        /// <summary>
        /// 商品名称
        /// </summary>
        public String commodityName { get; set; }
        /// <summary>
        /// 商品Id
        /// </summary>
        public Int32? commodityId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public String ImageInfoList { get; set; }
        /// <summary>
        /// 数量
        /// </summary>
        public Int32? Amount { get; set; }
        /// <summary>
        /// 金额
        /// </summary>
        public Decimal? PayMoney { get; set; }
        /// <summary>
        /// 图片列表
        /// </summary>
        public String ImageList { get; set; }
        /// <summary>
        /// 文字操作列表
        /// </summary>
        public String WordOpertion { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public String OnLineImageOpertion { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public String CustomImageOpertion { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public String DesignerImage { get; set; }
        /// <summary>
        /// 订单id
        /// </summary>
        public Int32? OrderId { get; set; }
        /// <summary>
        /// 颜色中文描述
        /// </summary>
        public String Color { get; set; }
        /// <summary>
        /// 颜色信息
        /// </summary>
        public Int32? ColorId { get; set; }
        /// <summary>
        /// 交货时间
        /// </summary>
        public DateTime? deliveryTime { get; set; }
        /// <summary>
        /// 生产注意事项
        /// </summary>
        public String InspectionContext { get; set; }
        /// <summary>
        /// 编号
        /// </summary>
        public String ProductNo { get; set; }
        /// <summary>
        /// 中文品名
        /// </summary>
        public String ChinaProductName { get; set; }
        /// <summary>
        /// 中文单位
        /// </summary>
        public String ChinaUnit { get; set; }
        /// <summary>
        /// 规格型号
        /// </summary>
        public String Specification { get; set; }
        /// <summary>
        /// 印刷位置
        /// </summary>
        public String PositionInfo { get; set; }
        /// <summary>
        /// SKU编码
        /// </summary>
        public String SKU { get; set; }
        /// <summary>
        /// 购物人名称
        /// </summary>
        public String BuyName { get; set; }
        /// <summary>
        /// 地址
        /// </summary>
        public String Address { get; set; }
        /// <summary>
        /// 手机号码
        /// </summary>
        public String userphone { get; set; }
        /// <summary>
        /// 打印详情
        /// </summary>
        public String PrintFuncInfo { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public String PrintingMethod { get; set; }
        /// <summary>
        /// 设计师名字
        /// </summary>
        public String DesigerPerson { get; set; }
        /// <summary>
        /// 销售员
        /// </summary>
        public String SalePerson { get; set; }
        /// <summary>
        /// 客服名字
        /// </summary>
        public String KefuPerson { get; set; }
        /// <summary>
        /// 印刷工艺
        /// </summary>
        public String PrintInfo { get; set; }
        /// <summary>
        /// 印刷参数
        /// </summary>
        public String PrintParm { get; set; }
        /// <summary>
        /// 订单明细
        /// </summary>
        public String Printingdetail { get; set; }

    }
}
