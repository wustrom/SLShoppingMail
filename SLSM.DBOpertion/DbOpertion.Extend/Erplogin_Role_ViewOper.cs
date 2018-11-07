using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using Common.LambdaOpertion;
using Common.Extend;
using System.Data;
using DbOpertion.Models;
using Common.Extend.LambdaFunction;

namespace DbOpertion.Operation
{
    public partial class Erplogin_Role_ViewOper : SingleTon<Erplogin_Role_ViewOper>
    {
        /// <summary>
        /// 模糊分页查询
        /// </summary>
        /// <param name="Key">排序方式</param>
        /// <param name="start">开始条数</param>
        /// <param name="PageSize">页面长度</param>
        /// <param name="desc">降序</param>
        /// <param name="Name">名称</param>
        /// <returns></returns>
        public List<Erplogin_Role_View> SelectLoginUserPage(string Key, int start, int PageSize, bool desc, string Name)
        {
            var query = new LambdaQuery<Erplogin_Role_View>();
            if (!Name.IsNullOrEmpty())
            {
                query.Where(p => p.erpLoginId.Like(Name) || p.erpLoginName.Like(Name) || p.erpLoginPwd.Like(Name) || p.ErproleName.Like(Name));
            }
            if (Key != null)
            {
                query.OrderByKey(Key, desc);
            }
            else
            {
                query.OrderByKey("erpLoginId", true);
            }
            return query.GetQueryPageList(start, PageSize);
        }

        /// <summary>
        /// 模糊分页查询
        /// </summary>
        /// <param name="Key">排序方式</param>
        /// <param name="start">开始条数</param>
        /// <param name="PageSize">页面长度</param>
        /// <param name="desc">降序</param>
        /// <param name="Name">名称</param>
        /// <returns></returns>
        public int SelectLoginUserCount(string Name)
        {
            var query = new LambdaQuery<Erplogin_Role_View>();
            if (!Name.IsNullOrEmpty())
            {
                query.Where(p => p.erpLoginId.Like(Name) || p.erpLoginName.Like(Name) || p.erpLoginPwd.Like(Name) || p.ErproleName.Like(Name));
            }
            return query.GetQueryCount();
        }
    }
}
