using Common;
using DbOpertion.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace SLSM.MoblieWeb.Models.Response.Evaluate
{
    /// <summary>
    /// 评价分页请求
    /// </summary>
    public class EvaluateByPageResponse
    {
        private string AdminUrl = ConfigurationManager.AppSettings["AdminUrl"];
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="evalinfo">评价信息</param>
        public EvaluateByPageResponse(Evalinfo evalinfo)
        {
            this.EvaluateId = evalinfo.EvaluateId;
            this.UserId = evalinfo.UserId;
            this.CommodityId = evalinfo.CommodityId;
            this.ImageList = evalinfo.ImageList;
            this.CreateTime = evalinfo.CreateTime.Value.ToString("yyyy-MM-dd HH:mm:ss");
            this.Content = evalinfo.Content;
            this.Start = evalinfo.Start;
            this.FrontView = AdminUrl + evalinfo.FrontView;
            this.BackView = AdminUrl + evalinfo.BackView;
            this.Name = evalinfo.Name;
        }
        /// <summary>
        /// 评价ID
        /// </summary>
        public Int32 EvaluateId { get; set; }
        /// <summary>
        /// 用户ID
        /// </summary>
        public Int32? UserId { get; set; }
        /// <summary>
        /// 商品ID
        /// </summary>
        public Int32? CommodityId { get; set; }
        /// <summary>
        /// 图片列表
        /// </summary>
        public String ImageList { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public string CreateTime { get; set; }
        /// <summary>
        /// 内容
        /// </summary>
        public String Content { get; set; }
        /// <summary>
        /// 星星数目
        /// </summary>
        public Double? Start { get; set; }
        /// <summary>
        /// 前图
        /// </summary>
        public String FrontView { get; set; }
        /// <summary>
        /// 后图
        /// </summary>
        public String BackView { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        public String Name { get; set; }
    }
}