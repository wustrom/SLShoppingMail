using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SLSM.AdminWeb.Model.Request.MainShow
{
    /// <summary>
    /// 修改展示商品请求
    /// </summary>
    public class EditCommRecommRequest
    {
        /// <summary>
        /// 展示商品Id
        /// </summary>
        public Int32 Id { get; set; }
        /// <summary>
        /// 排序Id
        /// </summary>
        public Int32? OrderID { get; set; }
        /// <summary>
        /// 商品Id
        /// </summary>
        public Int32 CommId { get; set; }

        /// <summary>
        /// 商品前置图
        /// </summary>
        public string FrontView { get; set; }
        /// <summary>
        /// 商品前置图
        /// </summary>
        public string BackView { get; set; }

        /// <summary>
        /// 特性1
        /// </summary>
        public string Attr1 { get; set; }
        /// <summary>
        /// 特性2
        /// </summary>
        public string Attr2 { get; set; }
        /// <summary>
        /// 特性3
        /// </summary>
        public string Attr3 { get; set; }
    }
}