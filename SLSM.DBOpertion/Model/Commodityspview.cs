using System;

namespace DbOpertion.Models
{
    [Serializable]
    public class Commodityspview
    {
        /// <summary>
        /// 商品Id
        /// </summary>
        public Int32 Id { get; set; }
        /// <summary>
        /// 商品名称
        /// </summary>
        public String Name { get; set; }
        /// <summary>
        /// 商品图片
        /// </summary>
        public String Image { get; set; }
        /// <summary>
        /// 分类Id
        /// </summary>
        public Int32? GradeId { get; set; }
        /// <summary>
        /// 商品正面图
        /// </summary>
        public String FrontView { get; set; }
        /// <summary>
        /// 商品背面图
        /// </summary>
        public String BackView { get; set; }
        /// <summary>
        /// 印刷方式
        /// </summary>
        public Int32? PrintingMethod { get; set; }
        /// <summary>
        /// 商品存在颜色(,隔开)1红色2橙色3黄色4绿色5蓝色6青色7紫色
        /// </summary>
        public String Color { get; set; }
        /// <summary>
        /// 产品图文详情
        /// </summary>
        public String Content { get; set; }
        /// <summary>
        /// 商品销售量
        /// </summary>
        public Int32? Sales { get; set; }
        /// <summary>
        /// 商品上架时间,（新品）
        /// </summary>
        public DateTime? CreateTime { get; set; }
        /// <summary>
        /// 推荐时间
        /// </summary>
        public DateTime? RecommendTime { get; set; }
        /// <summary>
        /// 贴图区域左上角和右下角（x1,y1,x2,y2)
        /// </summary>
        public String Points { get; set; }
        /// <summary>
        /// 是否发布
        /// </summary>
        public Boolean? IsRelease { get; set; }
        /// <summary>
        /// 上次操作时间
        /// </summary>
        public DateTime? LastOperTime { get; set; }
        /// <summary>
        /// 上次操作人Id
        /// </summary>
        public Int32? LastOperId { get; set; }
        /// <summary>
        /// 是否删除
        /// </summary>
        public Boolean? IsDelete { get; set; }
        /// <summary>
        /// 商品访问量
        /// </summary>
        public Int32? ClickCount { get; set; }
        /// <summary>
        /// 商品星级
        /// </summary>
        public Decimal? Stars { get; set; }
        /// <summary>
        /// 评价次数
        /// </summary>
        public Int32? StarCount { get; set; }
        /// <summary>
        /// 商品介绍
        /// </summary>
        public String Introduce { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public String ImageList { get; set; }
        /// <summary>
        /// 场景Id列表
        /// </summary>
        public String ScenceIds { get; set; }
        /// <summary>
        /// 商品数量阶梯
        /// </summary>
        public Int32? StageAmount { get; set; }
        /// <summary>
        /// 商品阶梯价格
        /// </summary>
        public Decimal? StagePrice { get; set; }

    }
}
