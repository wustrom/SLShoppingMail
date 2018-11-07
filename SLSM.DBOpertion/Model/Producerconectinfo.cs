using System;

namespace DbOpertion.Models
{
    [Serializable]
    public class Producerconectinfo
    {
        /// <summary>
        /// 供应商公司联系人信息Id
        /// </summary>
        public Int32 Id { get; set; }
        /// <summary>
        /// 联系人姓名
        /// </summary>
        public String ConectName { get; set; }
        /// <summary>
        /// 职位
        /// </summary>
        public String Position { get; set; }
        /// <summary>
        /// 性别
        /// </summary>
        public String ConectSex { get; set; }
        /// <summary>
        /// 电话
        /// </summary>
        public String Telephone { get; set; }
        /// <summary>
        /// 手机号码
        /// </summary>
        public String Phone { get; set; }
        /// <summary>
        /// 电子邮箱
        /// </summary>
        public String Email { get; set; }
        /// <summary>
        /// 供应商Id
        /// </summary>
        public Int32? ProducerId { get; set; }

    }
}
