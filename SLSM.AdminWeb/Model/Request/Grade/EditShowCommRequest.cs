using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SLSM.AdminWeb.Model.Request.MainShow
{
    /// <summary>
    /// 修改展示商品请求
    /// </summary>
    public class EditShowCommRequest
    {
        /// <summary>
        /// 展示商品Id
        /// </summary>
        public Int32 Id { get; set; }
        /// <summary>
        /// 分类Id
        /// </summary>
        public Int32 GradeId { get; set; }
        /// <summary>
        /// 排序Id
        /// </summary>
        public Int32? OrderID { get; set; }
        /// <summary>
        /// 商品Id
        /// </summary>
        public Int32 CommId { get; set; }
    }
}