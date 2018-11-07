using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SLSM.Web.Models.Response.Address
{
    /// <summary>
    /// 地址的分页请求
    /// </summary>
    public class AddressByPageResponse
    {
        /// <summary>
        /// 地址分类请求构造函数
        /// </summary>
        /// <param name="address">地址</param>
        public AddressByPageResponse(DbOpertion.Models.Address address)
        {
            //地址Id
            this.Id = address.Id;
            //用户Id
            this.UserId = address.UserId;
            //联系名称
            this.ContactName = address.ContactName;
            //联系电话
            this.ContactPhone = address.ContactPhone;
            //地址
            this.AddrArea = address.AddrArea;
            //地址详情
            this.AddrDetail = address.AddrDetail;
            //默认时间
            this.DefaultTime = address.DefaultTime;
        }
        /// <summary>
        /// 地址ID
        /// </summary>
        public Int32 Id { get; set; }
        /// <summary>
        /// 用户Id
        /// </summary>
        public Int32? UserId { get; set; }
        /// <summary>
        /// 联系名称
        /// </summary>
        public String ContactName { get; set; }
        /// <summary>
        /// 联系电话
        /// </summary>
        public String ContactPhone { get; set; }
        /// <summary>
        /// 地址
        /// </summary>
        public String AddrArea { get; set; }
        /// <summary>
        /// 地址详情
        /// </summary>
        public String AddrDetail { get; set; }
        /// <summary>
        /// 默认时间
        /// </summary>
        public DateTime? DefaultTime { get; set; }
        /// <summary>
        /// 是否为默认地址
        /// </summary>
        public bool? First { get; set; }
    }
}