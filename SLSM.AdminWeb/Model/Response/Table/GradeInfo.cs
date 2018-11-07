using DbOpertion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SLSM.AdminWeb.Model.Response.Table
{
    /// <summary>
    /// 获得分类信息
    /// </summary>
    public class GradeInfo
    {
        /// <summary>
        /// 分类信息构造函数
        /// </summary>
        /// <param name="grade">分类</param>
        public GradeInfo(Grade grade)
        {
            Id = grade.Id.ToString();
            Name = grade.Name;
            Img = grade.Image ?? "";
            GradeAttr = grade.GradeAttrName ?? "";
        }

        /// <summary>
        /// 分类信息构造函数
        /// </summary>
        /// <param name="gradefindparent">分类父节点</param>
        public GradeInfo(Gradefindparent gradefindparent)
        {
            Id = gradefindparent.id.ToString();
            Name = gradefindparent.gradeName;
            Img = gradefindparent.gradeImage ?? "暂无图片";
            GradeAttr = gradefindparent.GradeAttrName ?? "";
            if (gradefindparent.parentId != null)
                parentId = gradefindparent.parentId.ToString();
            else
                parentId = "0";
            parentName = gradefindparent.parentName ?? "暂无父节点";
            HotGradeTime = gradefindparent.HotGradeTime != null ? gradefindparent.HotGradeTime.Value.ToString("yyyy-MM-dd HH:mm:ss") : "暂无推荐时间";
        }
        /// <summary>
        /// 分类Id
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// 分类名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 分类图片
        /// </summary>
        public string Img { get; set; }
        /// <summary>
        /// 分类属性
        /// </summary>
        public string GradeAttr { get; set; }
        /// <summary>
        /// 父节点Id
        /// </summary>
        public string parentId { get; set; }
        /// <summary>
        /// 父节点名称
        /// </summary>
        public string parentName { get; set; }
        /// <summary>
        /// 热门时间
        /// </summary>
        public string HotGradeTime { get; set; }
    }
}