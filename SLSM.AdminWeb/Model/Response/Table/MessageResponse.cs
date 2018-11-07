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
    public class MessageResponse
    {
        /// <summary>
        /// 评论应答
        /// </summary>
        /// <param name="message">评论</param>
        public MessageResponse(Message message)
        {
            //消息Id
            this.Id = message.Id;
            //消息主标题
            this.MainTitle = message.MainTitle;
            //消息标题
            this.Title = message.Title;
            //消息内容
            this.Content = message.Content;
            //消息时间
            this.MessageTime = message.MessageTime == null ? "暂无时间" : message.MessageTime.Value.ToString("yyyy-MM-dd HH:mm:ss");
            //是否删除
            this.IsDelete = message.IsDelete;
        }

        /// <summary>
        /// 评论应答
        /// </summary>
        /// <param name="message">评论</param>
        public MessageResponse(News message)
        {
            //消息Id
            this.Id = message.Id;
            //消息主标题
            this.MainTitle = message.MainTitle;
            //消息标题
            this.Title = message.Title;
            //消息内容
            this.Content = message.Content;
            //消息时间
            this.MessageTime = message.ValidityTime == null ? "暂无时间" : message.ValidityTime.Value.ToString("yyyy-MM-dd HH:mm:ss");
        }
        /// <summary>
        ///
        /// </summary>
        public Int32 Id { get; set; }
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
        public String Content { get; set; }
        /// <summary>
        ///
        /// </summary>
        public string MessageTime { get; set; }
        /// <summary>
        ///
        /// </summary>
        public Boolean IsDelete { get; set; }
    }
}