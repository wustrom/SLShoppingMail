using System;

namespace DbOpertion.Models
{
    [Serializable]
    public class Raw_Materials
    {
        /// <summary>
        /// 原材料管理表Id
        /// </summary>
        public Int32 Id { get; set; }
        /// <summary>
        /// 编号
        /// </summary>
        public String ProductNo { get; set; }
        /// <summary>
        /// 中文单位
        /// </summary>
        public String ChinaUnit { get; set; }
        /// <summary>
        /// 中文品名
        /// </summary>
        public String ChinaProductName { get; set; }
        /// <summary>
        /// 英文单位
        /// </summary>
        public String EnglishUnit { get; set; }
        /// <summary>
        /// 英文品名
        /// </summary>
        public String EnglishProductName { get; set; }
        /// <summary>
        /// 海关编码
        /// </summary>
        public String HSCODE { get; set; }
        /// <summary>
        /// 产品属性
        /// </summary>
        public String Attributes { get; set; }
        /// <summary>
        /// 退税率
        /// </summary>
        public String TaxRate { get; set; }
        /// <summary>
        /// 所属大类
        /// </summary>
        public String Genera { get; set; }
        /// <summary>
        /// 规格型号
        /// </summary>
        public String Specification { get; set; }
        /// <summary>
        /// 所属小类
        /// </summary>
        public String Subclass { get; set; }
        /// <summary>
        /// 材料及工艺
        /// </summary>
        public String MatAndPro { get; set; }
        /// <summary>
        /// 开发时间
        /// </summary>
        public DateTime? DeveTime { get; set; }
        /// <summary>
        /// 开发人员
        /// </summary>
        public String DevePerson { get; set; }
        /// <summary>
        /// 产品描述
        /// </summary>
        public String Description { get; set; }
        /// <summary>
        /// 产品描述
        /// </summary>
        public String ProductDesibe { get; set; }
        /// <summary>
        /// 重量
        /// </summary>
        public String Weight { get; set; }
        /// <summary>
        /// 中箱数量
        /// </summary>
        public String NumMiddleBoxes { get; set; }
        /// <summary>
        /// 外箱数量
        /// </summary>
        public String NumOuterBoxes { get; set; }
        /// <summary>
        /// 外箱长
        /// </summary>
        public Double? OuterBoxesLength { get; set; }
        /// <summary>
        /// 外箱宽
        /// </summary>
        public Double? OuterBoxesWidth { get; set; }
        /// <summary>
        /// 外箱高
        /// </summary>
        public Double? OuterBoxesHeight { get; set; }
        /// <summary>
        /// 外箱体积
        /// </summary>
        public Double? OuterBoxesVolume { get; set; }
        /// <summary>
        /// 净重
        /// </summary>
        public String NetWeight { get; set; }
        /// <summary>
        /// 数量价格信息
        /// </summary>
        public String SalesInfoList { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public String Remark { get; set; }
        /// <summary>
        /// 是否删除
        /// </summary>
        public Boolean IsDelete { get; set; }
        /// <summary>
        /// 赛龙专利
        /// </summary>
        public String SyloonPatent { get; set; }
        /// <summary>
        /// 英文描述
        /// </summary>
        public String EngDescription { get; set; }
        /// <summary>
        /// 类型明细详情
        /// </summary>
        public String TypeInfo { get; set; }
        /// <summary>
        /// 打印详情
        /// </summary>
        public String PrintFuncInfo { get; set; }
        /// <summary>
        /// 订单明细
        /// </summary>
        public String Printingdetail { get; set; }
        /// <summary>
        /// 百分比
        /// </summary>
        public String PercentageInfo { get; set; }
        /// <summary>
        /// 提示字段
        /// </summary>
        public String TipPercentInfo { get; set; }

    }
}
