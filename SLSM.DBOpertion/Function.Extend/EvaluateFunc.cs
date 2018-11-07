using Common;
using DbOpertion.Models;
using DbOpertion.Operation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbOpertion.Function
{
    /// <summary>
    /// 评论方法
    /// </summary>
    public partial class EvaluateFunc : SingleTon<EvaluateFunc>
    {
        /// <summary>
        /// 根据商品Id筛选评论
        /// </summary>
        /// <param name="CommodityId">商品ID</param>
        /// <param name="Start">开始条数</param>
        /// <param name="PageSize">页面大小</param>
        /// <returns>数据列表</returns>
        public List<Evalinfo> SelectByCommodityId(string OrderBy, bool desc, int CommodityId, int Start, int PageSize)
        {
            var list = EvalinfoOper.Instance.SelectByPage(OrderBy, Start, PageSize, desc, new Evalinfo { CommodityId = CommodityId, ParentId = 0 });
            return list;
        }

        /// <summary>
        /// 根据商品Id筛选评论
        /// </summary>
        /// <param name="CommodityId">商品ID</param>
        /// <returns>总数据条数</returns>
        public int SelectByCommodityIdCount(int CommodityId)
        {
            var count = EvalinfoOper.Instance.SelectCount(new Evalinfo { CommodityId = CommodityId, ParentId = 0 });
            return count;
        }


        /// <summary>
        /// 筛选全部评论
        /// </summary>
        /// <param name="CommodityId">商品ID</param>
        /// <param name="Start">开始条数</param>
        /// <param name="PageSize">页面大小</param>
        /// <returns>数据列表</returns>
        public List<Evalinfo> SelectByPage(string OrderBy, string order, int Start, int PageSize)
        {
            var desc = order == "desc" ? true : false;
            var list = EvalinfoOper.Instance.SelectByPage(OrderBy, Start, PageSize, desc, new Evalinfo { ParentId = 0 });
            return list;
        }

        /// <summary>
        /// 筛选全部评论个数
        /// </summary>
        /// <param name="CommodityId">商品ID</param>
        /// <param name="Start">开始条数</param>
        /// <param name="PageSize">页面大小</param>
        /// <returns>数据列表</returns>
        public int SelectAllCount()
        {
            var count = EvalinfoOper.Instance.SelectCount(new Evalinfo { ParentId = 0 });
            return count;
        }

        /// <summary>
        /// 根据Id筛选全部
        /// </summary>
        /// <param name="Id">评论ID</param>
        /// <returns>数据列表</returns>
        public Reply SelectReplyById(int Id)
        {
            return ReplyOper.Instance.SelectAll(new Reply { EvalinfoId = Id }).FirstOrDefault();
        }

        /// <summary>
        /// 根据ID插入回复
        /// </summary>
        /// <param name="Id">评论ID</param>
        /// <returns>数据列表</returns>
        public bool InsertReply(Reply reply)
        {
            if (reply.Id == 0)
            {
                reply.CreateTime = DateTime.Now;
                return ReplyOper.Instance.Insert(reply);
            }
            else
            {

                return ReplyOper.Instance.Update(reply);
            }
        }
        public bool SubmitEvaluate(Evaluate eva)
        {
            return EvaluateOper.Instance.Insert(eva);
        }

    }
}
