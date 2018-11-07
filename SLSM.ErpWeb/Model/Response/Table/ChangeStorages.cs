using Common.Extend;
using DbOpertion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SLSM.ErpWeb.Model.Response.Table
{
    public class ChangeStorages
    {
        /// <summary>
        /// 库存变动统计
        /// </summary>
        /// <param name="change"></param>
        public ChangeStorages(Changestorage change)
        {
            //变动表Id
            this.Id = change.Id;
            //库存表Id
            this.storageId = change.Id;
            //变动时间
            this.ChangeTime = change.ChangeTime.ParseString();
            //变动类型
            this.ChangeType = change.ChangeType;
            //变动数量
            this.ChangeCount = change.ChangeCount;
            //变动后数量
            this.ChangeAfterCount = change.ChangeAfterCount;
            //变动描述
            this.ChangeContext = change.ChangeContext == null ? "" : change.ChangeContext;
        }


        /// <summary>
        ///
        /// </summary>
        public Int32 Id { get; set; }
        /// <summary>
        ///
        /// </summary>
        public Int32 storageId { get; set; }
        /// <summary>
        ///
        /// </summary>
        public string ChangeTime { get; set; }
        /// <summary>
        ///
        /// </summary>
        public String ChangeType { get; set; }
        /// <summary>
        ///
        /// </summary>
        public String ChangeCount { get; set; }
        /// <summary>
        ///
        /// </summary>
        public Int32? ChangeAfterCount { get; set; }
        /// <summary>
        ///
        /// </summary>
        public String ChangeContext { get; set; }
    }
}