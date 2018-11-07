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
    public partial class NewsFunc : SingleTon<NewsFunc>
    {
        /// <summary>
        /// 新闻轮播
        /// </summary>
        /// <param name="Start"></param>
        /// <param name="PageSize"></param>
        /// <returns></returns>
        public List<News> SelectNewsPage(int Start, int PageSize)
        {
            return NewsOper.Instance.SelectByPage("ValidityTime", Start, PageSize, true);
        }

        /// <summary>
        /// 新闻轮播
        /// </summary>
        /// <param name="Start"></param>
        /// <param name="PageSize"></param>
        /// <returns></returns>
        public List<News> SelectNewsPage(string OrderBy, string order, int Start, int PageSize)
        {
            var desc = order == "desc" ? true : false;
            return NewsOper.Instance.SelectByPage(OrderBy, Start, PageSize, desc);
        }
        /// <summary>
        /// 筛选全部数目
        /// </summary>
        /// <returns></returns>
        public int SelectNewsPageCount()
        {
            return NewsOper.Instance.SelectCount();
        }

        /// <summary>
        /// 根据Model插入
        /// </summary>
        /// <returns></returns>
        public bool InsertByModel(News news)
        {
            if (news.Id == 0)
            {
                //news.ValidityTime = DateTime.Now;
                #region 插入
                if (NewsOper.Instance.Insert(news))
                {
                    return true;
                }
                else
                {
                    return false;
                }
                #endregion
            }
            else
            {
                #region 更新
                if (NewsOper.Instance.Update(news))
                {
                    return true;
                }
                else
                {
                    return false;
                }
                #endregion
            }
        }
    }
}
