using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLSM.DBOpertion.Model.Extend.Request.Purchasing
{
    public class PurchasingSubmenuRequest
    {
        /// <summary>
        /// 购物单Id
        /// </summary>
        public int? PurchasingId { get; set; }
        /// <summary>
        /// 子订单列表
        /// </summary>
        public List<SubmenuModel> SubmenuList { get; set; }
    }

    public class SubmenuModel
    {
        /// <summary>
        /// 数目
        /// </summary>
        public int number { get; set; }
        /// <summary>
        /// 项目Id
        /// </summary>
        public int itemid { get; set; }
    }
}
