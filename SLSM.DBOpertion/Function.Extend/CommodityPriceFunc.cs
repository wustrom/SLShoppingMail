using Common;
using Common.Extend;
using DbOpertion.Models;
using DbOpertion.Operation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbOpertion.Function
{
    public partial class CommodityPriceFunc : SingleTon<CommodityPriceFunc>
    {
        /// <summary>
        /// 推荐产品根据时间进行排序
        /// </summary>
        /// <param name="OrderBy"></param>
        /// <param name="desc"></param>
        /// <param name="Start"></param>
        /// <param name="PageSize"></param>
        /// <returns></returns>
        public List<Commodity_Stageprice_View> SelectByRecommendTime(int Start, int PageSize)
        {
            return Commodity_Stageprice_ViewOper.Instance.SelectByPage("RecommendTime", Start, PageSize, true, new Commodity_Stageprice_View { IsDelete = false, IsRelease = true });

        }/// <summary>
         /// 热门产品分类根据时间进行排序
         /// </summary>
         /// <param name="Start"></param>
         /// <param name="PageSize"></param>
         /// <returns></returns>
        public List<Grade> SelectGradeType(int Start, int PageSize)
        {
            return GradeOper.Instance.SelectByPage("HotGradeTime", Start, PageSize, true, new Grade { IsDelete = false });

        }
        /// <summary>
        /// 根据IDS列表筛选数据
        /// </summary>
        /// <param name="list">Id列表</param>
        /// <returns></returns>
        public List<Commodity_Stage_Price> SelectByIds(List<int?> list)
        {
            return Commodity_Stage_PriceOper.Instance.SelectByIds(list.ConvertToString());
        }
    }
}
