using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLSM.DBOpertion.Model.Extend.Request.CommodityList
{
    public class CommodityListReq
    {
        public int gradeId { get; set; }

        public string sText { get; set; }
        public int? PageNo { get; set; }
    }
    public class CommListSearchReq
    {
        public int stars { get; set; }
        public int gradeId { get; set; }
        public string priceArea { get; set; }

        public string colorId { get; set; }
        public int? sales { get; set; }
        public string order { get; set; }

        public int[] commIds { get; set; }

        public bool isSearch { get; set; }
        public int index { get; set; }
        public int size { get; set; }

        public string text { get; set; }

    }
}
