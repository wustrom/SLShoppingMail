using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SLSM.AdminWeb.Model.Request.Reply
{
    public class ReplyRequest
    {
        /// <summary>
        /// 回复Id
        /// </summary>
        public Int32 ReplyId { get; set; }
        /// <summary>
        /// 评论ID
        /// </summary>
        public Int32 ParentEvalId { get; set; }
        /// <summary>
        /// 内容
        /// </summary>
        public String Content { get; set; }
        /// <summary>
        /// 图片列表
        /// </summary>
        public string ImgList { get; set; }
    }
}
