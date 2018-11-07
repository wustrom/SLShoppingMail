using DbOpertion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SLSM.AdminWeb.Model.Response.Table
{
    /// <summary>
    /// 评论应答
    /// </summary>
    public class EvaluateResponse
    {
        /// <summary>
        /// 评论应答
        /// </summary>
        /// <param name="evalinfo">评论</param>
        public EvaluateResponse(Evalinfo evalinfo)
        {
            //评论Id
            this.EvaluateId = evalinfo.EvaluateId;
            //商品名称
            this.CommName = evalinfo.CommName;
            //图片列表
            this.ImageList = evalinfo.ImageList;
            //创建时间
            this.CreateTime = evalinfo.CreateTime;
            //内容
            this.Content = evalinfo.Content;
            //星级
            this.Start = evalinfo.Start;
            //前视图
            this.FrontView = evalinfo.FrontView;
            //后视图
            this.BackView = evalinfo.BackView;
            //父节点Id
            this.ParentId = evalinfo.ParentId;
            //用户名
            this.Name = evalinfo.Name;
        }
        /// <summary>
        ///评论Id
        /// </summary>
        public Int32 EvaluateId { get; set; }
        /// <summary>
        ///商品名称
        /// </summary>
        public string CommName { get; set; }
        /// <summary>
        ///
        /// </summary>
        public String ImageList { get; set; }
        /// <summary>
        ///
        /// </summary>
        public DateTime? CreateTime { get; set; }
        /// <summary>
        ///
        /// </summary>
        public String Content { get; set; }
        /// <summary>
        ///
        /// </summary>
        public Double? Start { get; set; }
        /// <summary>
        ///
        /// </summary>
        public String FrontView { get; set; }
        /// <summary>
        ///
        /// </summary>
        public String BackView { get; set; }
        /// <summary>
        ///
        /// </summary>
        public int? ParentId { get; set; }
        /// <summary>
        ///
        /// </summary>
        public String Name { get; set; }
    }
}