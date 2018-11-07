using DbOpertion.Models;
using SLSM.DBOpertion.Model.Extend.Response.CommodityRes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SLSM.MoblieWeb.Models.Response.Message
{
    /// <summary>
    /// 订单应答
    /// </summary>
    public class MessageResponse
    {
        /// <summary>
        /// 订单应答构造方法
        /// </summary>
        public MessageResponse(Message_Grant_View mes)
        {
            //订单ID
            this.Id = mes.Id;
            //用户id
            this.UserId = mes.UserId;
            //信息Id
            this.MessageId = mes.MessageId;
            //是否观看
            this.IsWatch = mes.IsWatch;
            //标题
            this.MainTitle = mes.MainTitle;
            //消息标题
            this.Title = mes.Title;
            //时间
            this.MessageTime = mes.MessageTime == null ? "暂无时间" : mes.MessageTime.Value.ToString("yyyy-MM-dd HH:mm:ss");
            //内容
            this.Content = mes.Content;
            //是否删除
            this.IsDelete = mes.IsDelete;

        }
        /// <summary>
        ///
        /// </summary>
        public Int32 Id { get; set; }
        /// <summary>
        ///
        /// </summary>
        public Int32? UserId { get; set; }
        /// <summary>
        ///
        /// </summary>
        public Int32? MessageId { get; set; }
        /// <summary>
        ///
        /// </summary>
        public Boolean? IsWatch { get; set; }
        /// <summary>
        ///
        /// </summary>
        public String MainTitle { get; set; }
        /// <summary>
        ///
        /// </summary>
        public String Title { get; set; }
        /// <summary>
        ///
        /// </summary>
        public string MessageTime { get; set; }
        /// <summary>
        ///
        /// </summary>
        public String Content { get; set; }
        /// <summary>
        ///
        /// </summary>
        public Boolean? IsDelete { get; set; }
    }
}