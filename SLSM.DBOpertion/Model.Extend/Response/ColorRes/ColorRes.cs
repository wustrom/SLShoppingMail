using DbOpertion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLSM.DBOpertion.Model.Extend.Response.ColorRes
{
    public class ColorRes
    {
        public ColorRes() { }
        public ColorRes(Colorinfo colorinfo)
        {
            //颜色Id
            Id = colorinfo.Id;
            //中文描述
            ChinaDescribe = colorinfo.ChinaDescribe;
            //标准色号
            StandardColor = colorinfo.StandardColor;
            //英文描述
            EngDescibe = colorinfo.EngDescibe;
            //颜色代码
            HtmlCode = colorinfo.HtmlCode;
        }
        /// <summary>
        /// 颜色Id
        /// </summary>
        public Int32 Id { get; set; }
        /// <summary>
        /// 中文描述
        /// </summary>
        public String ChinaDescribe { get; set; }
        /// <summary>
        /// 标准色号
        /// </summary>
        public String StandardColor { get; set; }
        /// <summary>
        /// 英文描述
        /// </summary>
        public String EngDescibe { get; set; }
        /// <summary>
        /// 颜色代码
        /// </summary>
        public String HtmlCode { get; set; }
        /// <summary>
        /// 颜色列表
        /// </summary>
        public List<ColorRes> listColor { get; set; }
    }
}
