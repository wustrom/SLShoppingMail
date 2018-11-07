using DbOpertion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SLSM.AdminWeb.Model.Response.Table
{
    public class CustomerserviceInfo
    {
        public CustomerserviceInfo(Customerservice Customerservice)
        {
            this.Id = Customerservice.Id;
            this.ServiceName = Customerservice.ServiceName;
            this.ServiceQQ = Customerservice.ServiceQQ;
            this.ServicePhone = Customerservice.ServicePhone;
            this.ServiceWechat = Customerservice.ServiceWechat;
            this.ServiceALWW = Customerservice.ServiceALWW;
            this.IsService = Customerservice.IsService == true ? "工作中": "繁忙";
        }
        /// <summary>
        ///
        /// </summary>
        public Int32? Id { get; set; }
        /// <summary>
        ///
        /// </summary>
        public String ServiceName { get; set; }
        /// <summary>
        ///
        /// </summary>
        public String ServiceQQ { get; set; }
        /// <summary>
        ///
        /// </summary>
        public String ServicePhone { get; set; }
        /// <summary>
        ///
        /// </summary>
        public String ServiceWechat { get; set; }
        /// <summary>
        ///
        /// </summary>
        public String ServiceALWW { get; set; }
        /// <summary>
        ///
        /// </summary>
        public string IsService { get; set; }
    }
}