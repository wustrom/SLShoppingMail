using SLSM.Web.Models.Resquest.OrderList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SLSM.Web.Models.Resquest.Evaluate
{
    /// <summary>
    /// 提交评论
    /// </summary>
    public class SubmitEvaluateResquest: OrderListRequest
    {
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
        public Int32? CommodityId { get; set; }
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
    }
}