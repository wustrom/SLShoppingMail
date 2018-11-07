using Common;
using Common.Extend;
using Common.Helper;
using DbOpertion.Models;
using DbOpertion.Operation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbOpertion.Function
{
    public partial class DiyFunc : SingleTon<DiyFunc>
    {
        /// <summary>
        /// 获得产品信息
        /// </summary>
        /// <param name="Id">产品Id</param>
        /// <returns>item1:商品模型,item2:阶梯价格</returns>
        public Tuple<Grade_Commodity_View, List<Commodity_Stage_Price>> SelectAllInfo(int Id)
        {
            var commodity = Grade_Commodity_ViewOper.Instance.SelectById(Id);
            var StagePriceList = Commodity_Stage_PriceOper.Instance.SelectAll(new Commodity_Stage_Price { CommodityId = Id }).OrderBy(p => p.StageAmount).ToList();
            return new Tuple<Grade_Commodity_View, List<Commodity_Stage_Price>>(item1: commodity, item2: StagePriceList);
        }
    }
}
