using DbOpertion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SLSM.AdminWeb.Model.Response.Table
{
    /// <summary>
    /// 用户信息
    /// </summary>
    public class UserInfo
    {
        /// <summary>
        /// 用户信息构造函数
        /// </summary>
        /// <param name="user">用户模型</param>
        public UserInfo(User user)
        {
            //用户ID
            this.Id = user.Id;
            //用户名
            this.Name = user.Name;
            //用户性别
            this.Sex = user.Sex == null ? "暂未选择" : user.Sex.Value ? "男" : "女";
            //用户手机号码
            this.Phone = user.Phone;
            //用户邮箱
            this.Email = user.Email == null ? "暂未填写邮箱" : user.Email;
            //几折
            this.Discount = user.Discount == null ? "暂无折扣" : user.Discount >= 1 ? "暂无折扣" : user.Discount * 10 + "折";
            //创建时间
            this.CreateTime = user.CreateTime != null ? user.CreateTime.Value.ToString("yyyy-MM-dd HH:mm:ss") : "创建时间未知";
        }

        /// <summary>
        /// 用户ID
        /// </summary>
        public Int32 Id { get; set; }
        /// <summary>
        /// 用户性别
        /// </summary>
        public string Sex { get; set; }
        /// <summary>
        /// 用户昵称
        /// </summary>
        public String Name { get; set; }
        /// <summary>
        /// 用户手机号码
        /// </summary>
        public String Phone { get; set; }
        /// <summary>
        /// 用户邮箱
        /// </summary>
        public String Email { get; set; }
        /// <summary>
        /// 几折
        /// </summary>
        public string Discount { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public string CreateTime { get; set; }
    }
}