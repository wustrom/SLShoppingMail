using DbOpertion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SLSM.ErpWeb.Model.Response.Table
{
    public class Technologys
    {
        /// <summary>
        /// 定制工艺构造函数
        /// </summary>
        /// <param name="tech"></param>
        public Technologys(Technology tech)
        {
            //定制工艺ID
            this.Id = tech.Id;
            //名称
            this.Name = tech.Name;
            //是否删除
            this.IsDelete = tech.IsDelete;
        }
        /// <summary>
        ///定制工艺ID
        /// </summary>
        public Int32 Id { get; set; }
        /// <summary>
        ///名称
        /// </summary>
        public String Name { get; set; }
        /// <summary>
        ///是否删除
        /// </summary>
        public Boolean? IsDelete { get; set; }
    }
}