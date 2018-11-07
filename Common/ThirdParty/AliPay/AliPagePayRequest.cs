using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.ThirdParty.AliPay
{
    public class AliPagePayRequest
    {
        /// <summary>
        /// 总计金额
        /// </summary>
        public decimal total_amount { get; set; }
        /// <summary>
        /// 时间邮编
        /// </summary>
        public string timestamp { get; set; }
        /// <summary>
        /// 签名
        /// </summary>
        public string sign { get; set; }
        /// <summary>
        /// 支付宝订单编号
        /// </summary>
        public string trade_no { get; set; }
        /// <summary>
        /// 签名类型
        /// </summary>
        public string sign_type { get; set; }
        /// <summary>
        /// 用户AppId
        /// </summary>
        public string auth_app_id { get; set; }
        /// <summary>
        /// AppId
        /// </summary>
        public string app_id { get; set; }
        /// <summary>
        /// 编码方式
        /// </summary>
        public string charset { get; set; }
        /// <summary>
        /// 商家Id
        /// </summary>
        public string seller_id { get; set; }
        /// <summary>
        /// 方法
        /// </summary>
        public string method { get; set; }
        /// <summary>
        /// 网站订单编号
        /// </summary>
        public string out_trade_no { get; set; }
        /// <summary>
        /// 版本
        /// </summary>
        public string version { get; set; }
    }
}
