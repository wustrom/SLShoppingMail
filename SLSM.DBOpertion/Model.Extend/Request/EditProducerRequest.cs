using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SLSM.DBOpertion.Model.Request.Material
{
    /// <summary>
    /// 修改供应商请求
    /// </summary>
    public class EditProducerRequest
    {
        /// <summary>
        /// 供应商id(为0时新增)
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 供应商代码
        /// </summary>
        public string ProducerCode { get; set; }
        /// <summary>
        /// 供应商地址
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// 供应商名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 所在地区
        /// </summary>
        public string AddressRegion { get; set; }
        /// <summary>
        /// 供应商简称
        /// </summary>
        public string Abbreviation { get; set; }
        /// <summary>
        /// 邮政编码
        /// </summary>
        public string ZipCode { get; set; }
        /// <summary>
        /// 主营产品
        /// </summary>
        public string SupplyProducts { get; set; }
        /// <summary>
        /// 信用等级
        /// </summary>
        public string CreditRating { get; set; }
        /// <summary>
        /// 公司网址
        /// </summary>
        public string CompanyWebsite { get; set; }
        /// <summary>
        /// 合作等级
        /// </summary>
        public string CooperationLevel { get; set; }
        /// <summary>
        /// 企业法人
        /// </summary>
        public string EnterLegPerson { get; set; }
        /// <summary>
        /// 企业传真
        /// </summary>
        public string FaxNumber { get; set; }
        /// <summary>
        /// 付款方式(开票后几天)
        /// </summary>
        public string AccountPeriod { get; set; }
        /// <summary>
        /// 开票抬头
        /// </summary>
        public string RaiseTicket { get; set; }
        /// <summary>
        /// 开户银行
        /// </summary>
        public string Bank { get; set; }

        /// <summary>
        /// 企业税号
        /// </summary>
        public string identify { get; set; }
        /// <summary>
        /// 企业账号
        /// </summary>
        public string AccountNumber { get; set; }

        public List<ProducerConect> listProducer { get; set; }
    }
    /// <summary>
    /// 供应商联系人
    /// </summary>
    public class ProducerConect
    {
        /// <summary>
        /// 姓名
        /// </summary>
        public string ConectName { get; set; }
        /// <summary>
        /// 职位
        /// </summary>
        public string Position { get; set; }
        /// <summary>
        /// 性别
        /// </summary>
        public string ConectSex { get; set; }
        /// <summary>
        /// 电话
        /// </summary>
        public string Telephone { get; set; }
        /// <summary>
        /// 手机
        /// </summary>
        public string Phone { get; set; }
        /// <summary>
        /// 电子邮箱
        /// </summary>
        public string Email { get; set; }
    }
}