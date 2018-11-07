using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SLSM.Web.Models.Resquest
{
    public class UpdateDesignInfoRequest
    {
        /// <summary>
        /// 订单明细ID
        /// </summary>
        public int DetailID { get; set; }
        /// <summary>
        /// 用户图片列表
        /// </summary>
        public List<UpImage> OnLineImageList { get; set; }
        /// <summary>
        /// 用户图片列表
        /// </summary>
        public List<UpImage> CustomerImageList { get; set; }
        /// <summary>
        /// 文字列表列表
        /// </summary>
        public List<UpWord> WordList { get; set; }
    }

    public class UpWord
    {
        /// <summary>
        /// 字体大小
        /// </summary>
        public string fontsize { get; set; }
        /// <summary>
        /// 字体
        /// </summary>
        public string fontFamily { get; set; }
        /// <summary>
        /// 颜色
        /// </summary>
        public string color { get; set; }
        /// <summary>
        /// 旋转角度
        /// </summary>
        public string rotate { get; set; }
        /// <summary>
        /// 文字内容
        /// </summary>
        public string Text { get; set; }
        /// <summary>
        /// 排序个数
        /// </summary>
        public string Count_Index { get; set; }

        /// <summary>
        /// 属于部位
        /// </summary>
        public string Position { get; set; }
    }

    public class UpImage
    {
        /// <summary>
        /// 图片路径
        /// </summary>
        public string ImageUrl { get; set; }
        /// <summary>
        /// 属于部位
        /// </summary>
        public string Position { get; set; }
        /// <summary>
        /// 旋转角度
        /// </summary>
        public string rotate { get; set; }
        /// <summary>
        /// 排序个数
        /// </summary>
        public string Count_Index { get; set; }
    }
}