using Common.Attribute;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SLSM.Web.Models.Resquest.User
{
    /// <summary>
    /// 联系人信息
    /// </summary>
    public class UpdateInvoiceRequest
    {
        /// <summary>
        /// Id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 抬头
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "抬头不能为空")]
        public string Title { get; set; }
        /// <summary>
        /// 税号
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "税号不能为空")]
        public string DutyParagraph { get; set; }
        /// <summary>
        /// 发票类型
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "发票类型不能为空")]
        public string TypeInvoice { get; set; }
        /// <summary>
        /// 地址
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// 手机
        /// </summary>
        public string MobiePhone { get; set; }
        /// <summary>
        /// 开户行
        /// </summary>
        public string OpeningBank { get; set; }
        /// <summary>
        /// 银行账户
        /// </summary>
        public string BankAccount { get; set; }
    }
}