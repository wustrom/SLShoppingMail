using System;

namespace DbOpertion.Models
{
    [Serializable]
    public class User
    {
        /// <summary>
        /// 用户Id
        /// </summary>
        public Int32 Id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Boolean? Sex { get; set; }
        /// <summary>
        /// 用户名称
        /// </summary>
        public String Name { get; set; }
        /// <summary>
        /// 用户密码
        /// </summary>
        public String PassWord { get; set; }
        /// <summary>
        /// 用户手机号码
        /// </summary>
        public String Phone { get; set; }
        /// <summary>
        /// 用户QQ
        /// </summary>
        public String QQ { get; set; }
        /// <summary>
        /// 用户微信
        /// </summary>
        public String WeChat { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? CreateTime { get; set; }
        /// <summary>
        /// 用户折扣比例
        /// </summary>
        public Single? Discount { get; set; }
        /// <summary>
        /// 用户头像
        /// </summary>
        public String Image { get; set; }
        /// <summary>
        /// 用户公司名称
        /// </summary>
        public String CompanyName { get; set; }
        /// <summary>
        /// 用户公司性质
        /// </summary>
        public String ConmpanyType { get; set; }
        /// <summary>
        /// 用户公司电话
        /// </summary>
        public String CompanyPhone { get; set; }
        /// <summary>
        /// 用户公司地址
        /// </summary>
        public String CompanyAddr { get; set; }
        /// <summary>
        /// 用户邮箱
        /// </summary>
        public String Email { get; set; }
        /// <summary>
        /// 用户邮编
        /// </summary>
        public String ZipCode { get; set; }
        /// <summary>
        /// 是否删除
        /// </summary>
        public Boolean? IsDelete { get; set; }

    }
}
