using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SLSM.DBOpertion.Model.Request.Material
{
    /// <summary>
    /// 添加材料请求
    /// </summary>
    public class EditMaterialRequest
    {
        #region 基本信息
        /// <summary>
        /// 原材料Id
        /// </summary>
        public int MaterialId { get; set; }
        /// <summary>
        /// 产品货号
        /// </summary>
        public string ProductNo { get; set; }
        /// <summary>
        /// 中文单位
        /// </summary>
        public string ChinaUnit { get; set; }
        /// <summary>
        /// 中文品名
        /// </summary>
        public string ChinaProductName { get; set; }
        /// <summary>
        /// 英文单位
        /// </summary>
        public string EnglishUnit { get; set; }
        /// <summary>
        /// 英文品名
        /// </summary>
        public string EnglishProductName { get; set; }
        /// <summary>
        /// 海关编码
        /// </summary>
        public string HSCODE { get; set; }
        /// <summary>
        /// 产品属性
        /// </summary>
        public string Attributes { get; set; }
        /// <summary>
        /// 退税率
        /// </summary>
        public string TaxRate { get; set; }
        /// <summary>
        /// 产品大类
        /// </summary>
        public string Genera { get; set; }
        /// <summary>
        /// 规格
        /// </summary>
        public string Specification { get; set; }
        /// <summary>
        /// 产品小类
        /// </summary>
        public string Subclass { get; set; }
        /// <summary>
        /// 材料及工艺
        /// </summary>
        public string MatAndPro { get; set; }
        /// <summary>
        /// 开发时间
        /// </summary>
        public DateTime DeveTime { get; set; }
        /// <summary>
        /// 开发人员
        /// </summary>
        public string DevePerson { get; set; }
        /// <summary>
        /// 是否赛龙专利
        /// </summary>
        public string SyloonPatent { get; set; }
        /// <summary>
        /// 中文描述
        /// </summary>
        public string ChinaDescibe { get; set; }

        /// <summary>
        /// 中文描述
        /// </summary>
        public string EngDescibe { get; set; }
        /// <summary>
        /// 产品描述
        /// </summary>
        public string ProductDesibe { get; set; }
        /// <summary>
        /// 印刷方式一
        /// </summary>
        public string PrintFunc1 { get; set; }
        /// <summary>
        /// 印刷方式二
        /// </summary>
        public string PrintFunc2 { get; set; }
        /// <summary>
        /// 印刷方式三
        /// </summary>
        public string PrintFunc3 { get; set; }
        /// <summary>
        /// 百分比1
        /// </summary>
        public string Percentage1 { get; set; }
        /// <summary>
        /// 百分比2
        /// </summary>
        public string Percentage2 { get; set; }
        /// <summary>
        /// 百分比3
        /// </summary>
        public string Percentage3 { get; set; }
        /// <summary>
        /// 提示字段1
        /// </summary>
        public string TipPercent1 { get; set; }
        /// <summary>
        /// 提示字段2
        /// </summary>
        public string TipPercent2 { get; set; }
        /// <summary>
        /// 提示字段3
        /// </summary>
        public string TipPercent3 { get; set; }
        /// <summary>
        /// 重点设置1
        /// </summary>
        public string Attributes1 { get; set; }
        /// <summary>
        /// 重点设置2
        /// </summary>
        public string Attributes2 { get; set; }
        /// <summary>
        /// 重点设置3
        /// </summary>
        public string Attributes3 { get; set; }
        /// <summary>
        /// 重点设置4
        /// </summary>
        public string Attributes4 { get; set; }
        #endregion

        #region 包装明细
        /// <summary>
        /// 产品重量
        /// </summary>
        public string Weight { get; set; }
        /// <summary>
        /// 中箱数量
        /// </summary>
        public string NumMiddleBoxes { get; set; }
        /// <summary>
        /// 外箱数量
        /// </summary>
        public string NumOuterBoxes { get; set; }
        /// <summary>
        /// 外箱长
        /// </summary>
        public double OuterBoxesLength { get; set; }
        /// <summary>
        /// 外箱宽
        /// </summary>
        public double OuterBoxesWidth { get; set; }
        /// <summary>
        /// 外箱高
        /// </summary>
        public double OuterBoxesHeight { get; set; }
        /// <summary>
        /// 外箱体积
        /// </summary>
        public double OuterBoxesVolume { get; set; }
        /// <summary>
        /// 毛净重
        /// </summary>
        public string NetWeight { get; set; }

        #endregion        

        /// <summary>
        /// 采购信息
        /// </summary>
        public List<ProducerInfo> producer { get; set; }
        /// <summary>
        /// 颜色信息
        /// </summary>
        public List<ColorInfo> ColorList { get; set; }
        /// <summary>
        /// 销售信息
        /// </summary>
        public List<SalesInfo> SalesList { get; set; }
        /// <summary>
        /// 印刷信息
        /// </summary>
        public List<PrintDetailInfo> PrintList { get; set; }

        #region 废弃字段
        //#region 销售价格
        ///// <summary>
        ///// 最小起售量
        ///// </summary>
        //public int? ShopQuantity1 { get; set; }
        ///// <summary>
        ///// 数量2
        ///// </summary>
        //public int? ShopQuantity2 { get; set; }
        ///// <summary>
        ///// 数量3
        ///// </summary>
        //public int? ShopQuantity3 { get; set; }
        ///// <summary>
        ///// 数量4
        ///// </summary>
        //public int? ShopQuantity4 { get; set; }
        ///// <summary>
        ///// 价格
        ///// </summary>
        //public string ShopPrice1 { get; set; }
        ///// <summary>
        ///// 价格2
        ///// </summary>
        //public string ShopPrice2 { get; set; }
        ///// <summary>
        ///// 价格3
        ///// </summary>
        //public string ShopPrice3 { get; set; }
        ///// <summary>
        ///// 价格4
        ///// </summary>
        //public string ShopPrice4 { get; set; }
        //#endregion

        //#region 定制信息
        ///// <summary>
        ///// 位置A是否勾选
        ///// </summary>
        //public string likeA { get; set; }
        ///// <summary>
        ///// 位置A的文字
        ///// </summary>
        //public string likeAText { get; set; }
        ///// <summary>
        ///// 位置B是否勾选
        ///// </summary>
        //public string likeB { get; set; }
        ///// <summary>
        ///// 位置A的文字
        ///// </summary>
        //public string likeBText { get; set; }
        ///// <summary>
        ///// 位置C是否勾选
        ///// </summary>
        //public string likeC { get; set; }
        ///// <summary>
        ///// 位置A的文字
        ///// </summary>
        //public string likeCText { get; set; }
        ///// <summary>
        ///// 所选择工艺
        ///// </summary>
        //public string TechIds { get; set; }
        ///// <summary>
        ///// 备注信息
        ///// </summary>
        //public string Remark { get; set; }
        //#endregion
        ///// <summary>
        ///// 包装方式
        ///// </summary>
        //public string PackingMethod { get; set; }
        ///// <summary>
        ///// 外形尺码
        ///// </summary>
        //public string ShapeSize { get; set; }
        ///// <summary>
        ///// 毛重
        ///// </summary>
        //public string GrossWeight { get; set; }
        ///// <summary>
        ///// 净重
        ///// </summary>
        //public string NetWeight { get; set; }
        ///// <summary>
        ///// 唛头信息
        ///// </summary>
        //public string MarkInfo { get; set; }
        ///// <summary>
        ///// 库存预警数
        ///// </summary>
        //public int StockWarningNumber { get; set; }
        #endregion
    }

    /// <summary>
    /// 供应商信息
    /// </summary>
    public class ProducerInfo
    {
        /// <summary>
        /// 供应商代码
        /// </summary>
        public int ProdecerCode { get; set; }

        /// <summary>
        /// 供应商名称
        /// </summary>
        public string ProdecerName { get; set; }
        /// <summary>
        /// 工厂货号
        /// </summary>
        public string FactoryNumber { get; set; }
        /// <summary>
        /// 采购单价
        /// </summary>
        public decimal PurchasePrice { get; set; }
        /// <summary>
        /// 报价日期
        /// </summary>
        public DateTime QuotationDate { get; set; }
        /// <summary>
        /// 生产周期
        /// </summary>
        public string ProCycle { get; set; }
        /// <summary>
        /// 最小起订量
        /// </summary>
        public string MinQuantity { get; set; }

        /// <summary>
        /// 价格标识
        /// </summary>
        public string PriceTag { get; set; }
    }

    /// <summary>
    /// 颜色信息
    /// </summary>
    public class ColorInfo
    {
        /// <summary>
        /// 颜色SKU代码
        /// </summary>
        public string SKU { get; set; }
        /// <summary>
        /// 颜色ID
        /// </summary>
        public int ColorID { get; set; }
        /// <summary>
        /// 标准色号
        /// </summary>
        public string StanColorNum { get; set; }
        /// <summary>
        /// 色系
        /// </summary>
        public string ColorSystem { get; set; }
        /// <summary>
        /// 颜色描述
        /// </summary>
        public string ColorDesc { get; set; }
        /// <summary>
        /// 英文颜色描述
        /// </summary>
        public string EngColorDesc { get; set; }
        /// <summary>
        /// 最小库存
        /// </summary>
        public string MinStock { get; set; }
        /// <summary>
        /// SKU图片
        /// </summary>
        public string SKUImage { get; set; }
        /// <summary>
        /// SKU图片
        /// </summary>
        public string PrintInfo { get; set; }
        /// <summary>
        /// 潘通颜色
        /// </summary>
        public string PantongColor { get; set; }
        /// <summary>
        /// Html代码
        /// </summary>
        public string HtmlCode { get; set; }
        public List<PrintInfo> Print { get; set; }
    }

    /// <summary>
    /// 颜色信息
    /// </summary>
    public class PrintInfo
    {
        /// <summary>
        /// 印刷方式
        /// </summary>
        public string Print { get; set; }
        /// <summary>
        /// 位置描述
        /// </summary>
        public string PositionDescrip { get; set; }
        /// <summary>
        /// 位置图片
        /// </summary>
        public string ColorInfo_Diagram { get; set; }
    }

    /// <summary>
    /// 印刷信息
    /// </summary>
    public class PrintDetailInfo
    {
        /// <summary>
        /// 印刷方式
        /// </summary>
        public string PrintFunc { get; set; }
        /// <summary>
        /// 印刷工艺
        /// </summary>
        public string PrintingProcess { get; set; }
        /// <summary>
        /// 印刷位置
        /// </summary>
        public string PrintingPosition { get; set; }
        /// <summary>
        /// 位置描述
        /// </summary>
        public string PositionDescription { get; set; }
        /// <summary>
        /// 最大可印刷面积
        /// </summary>
        public string MaximumArea { get; set; }
        /// <summary>
        /// 可印颜色
        /// </summary>
        public string PrintableColor { get; set; }
    }

    /// <summary>
    /// 销售信息
    /// </summary>
    public class SalesInfo
    {
        /// <summary>
        /// 销售数量
        /// </summary>
        public string ShopQuantity { get; set; }

        /// <summary>
        /// 人民币价格
        /// </summary>
        public string ChinaPrice { get; set; }
        /// <summary>
        /// 折扣率
        /// </summary>
        public string ChinaDiscountRate { get; set; }
        /// <summary>
        /// 美金价格
        /// </summary>
        public string DollarPrice { get; set; }
        /// <summary>
        /// 折扣率
        /// </summary>
        public string DollarDiscountRate { get; set; }
    }
}