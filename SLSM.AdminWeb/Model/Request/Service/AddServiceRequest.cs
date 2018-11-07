using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SLSM.AdminWeb.Model.Request.Service
{
    public class AddServiceRequest
    {
        /// <summary>
        ///
        /// </summary>
        public Int32 Id { get; set; }
        /// <summary>
        ///
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "请填写客服人员姓名")]
        public String ServiceName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public String ServiceQQ { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public String ServiceWechat { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public String ServicePhone { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public String ServiceALWW { get; set; }
        /// <summary>
        ///
        /// </summary>
        public Boolean? IsService { get; set; }
        

    }
}