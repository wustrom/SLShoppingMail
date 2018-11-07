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
    public partial class ChangeStorageOper : SingleTon<ChangeStorageOper>
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
        public List<Changestorage> SelectChangePage(string Key, int start, int PageSize, bool desc, string Name,int storageId)
        {
            var query = new LambdaQuery<Changestorage>();
            var querys = query.Where(p => p.storageId == storageId);
            if (storageId != 0)
            {
                if (!Name.IsNullOrEmpty())
                {
                    querys.Where(p =>p.Id.Like(Name)|| p.ChangeType.Like(Name) || p.ChangeAfterCount.Like(Name) || p.ChangeCount.Like(Name)||p.ChangeContext.Like(Name));
                }
                if (Key != null)
                {
                    querys.OrderByKey(Key);
                }
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
        public int SelectChangeCount(string Name,int storageId)
        {
            var query = new LambdaQuery<Changestorage>();
            var querys = query.Where(p => p.storageId == storageId);
            if (storageId != 0)
            {
                if (!Name.IsNullOrEmpty())
                {
                    querys.Where(p => p.Id.Like(Name) || p.ChangeType.Like(Name) || p.ChangeAfterCount.Like(Name) || p.ChangeCount.Like(Name) || p.ChangeContext.Like(Name));
                }               
            }
            return query.GetQueryCount();
        }
    }
}
