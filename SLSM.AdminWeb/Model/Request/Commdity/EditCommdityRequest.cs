using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SLSM.AdminWeb.Model.Request.Commdity
{
    /// <summary>
    /// 修改商品信息请求
    /// </summary>
    public class EditCommdityRequest
    {
        /// <summary>
        /// 商品id
        /// </summary>
        public int CommId { get; set; }
        /// <summary>
        /// 商品名称
        /// </summary>
        public string CommName { get; set; }
        /// <summary>
        /// 类别Id
        /// </summary>
        public int GradeId { get; set; }
        /// <summary>
        /// 图片列表
        /// </summary>
        //[Required(AllowEmptyStrings = false, ErrorMessage = "至少选择一张图片")]
        public string ImgList { get; set; }
        /// <summary>
        /// 价格列表
        /// </summary>
        public string PriceList { get; set; }
        /// <summary>
        /// 商品单价
        /// </summary>
        public string CommPrice { get; set; }
        /// <summary>
        /// 介绍
        /// </summary>
        public string Introduce { get; set; }
        /// <summary>
        /// 后面图片
        /// </summary>
        public string BackView { get; set; }
        /// <summary>
        /// 前面图片
        /// </summary>
        public string FrontView { get; set; }
        /// <summary>
        /// 显示图片
        /// </summary>
        public string ShowImage { get; set; }
        /// <summary>
        /// 颜色
        /// </summary>
        //[Required(AllowEmptyStrings = false, ErrorMessage = "至少选择一个颜色")]
        public string ColorIds { get; set; }
        /// <summary>
        /// 内容
        /// </summary>
        public string content { get; set; }

        /// <summary>
        /// 是否上架
        /// </summary>
        public string Release { get;set;}
        /// <summary>
        /// 场景IDs
        /// </summary>
        public string SceneIds { get; set; }
        /// <summary>
        /// 推荐商品IDs
        /// </summary>
        public string Collocations { get; set; }
        /// <summary>
        /// 原材料ID
        /// </summary>
        public string MaterialId { get; set; }
        /// <summary>
        /// 位置图片
        /// </summary>
        public string Position { get; set; }
    }
}