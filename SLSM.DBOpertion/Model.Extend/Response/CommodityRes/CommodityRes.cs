using DbOpertion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLSM.DBOpertion.Model.Extend.Response.CommodityRes
{
    
    public class CommodityRes
    {
        public List<CommodityListRes> ListData { get; set; }
        public int pages { get; set; }
        public int index { get; set; }
    }

    public class CommodityListRes
    {
        string AdminUrl = System.Configuration.ConfigurationManager.AppSettings["AdminUrl"];
        public CommodityListRes() { }

        public CommodityListRes(List<Commodityspview> comms)
        {
            var comm = comms.First();
            id = comm.Id;
            image = comm.Image;
            name = comm.Name;
            comms.Min(p => p.StagePrice);
            price = $"价格从{comms.Min(p => p.StagePrice)}元到{comms.Max(p => p.StagePrice)}元";
            intro = comm.Introduce;
            minAmount = (int)comms.OrderBy(p => p.StageAmount).ToList()[1].StageAmount;
            stars = Convert.ToInt32(Math.Floor((decimal)comm.Stars));
        }

        public CommodityListRes(Commodity_Stageprice_View comm)
        {
            id = comm.Id;
            image = AdminUrl+comm.Image;//-txy
            name = comm.Name;

            price = $"价格从{comm.minPrice}元到{comm.maxPrice}元";
            intro = comm.Introduce;
            if (comm.minAmount != null)
                minAmount = (int)comm.minAmount;
            stars = Convert.ToInt32(Math.Floor((decimal)comm.Stars));
        }

        public int id { get; set; }
        public string image { get; set; }

        public string name { get; set; }

        public string price { get; set; }

        public string intro { get; set; }

        public int minAmount { get; set; }

        public int stars { get; set; }
    }

    public class CommPrice_Amount_CommIds
    {

        public decimal price { get; set; }
        public int amount { get; set; }

        public List<int> commIds { get; set; }
    }

    public class CommStarsCount
    {
        public int stars { get; set; }
        public int amount { get; set; }
        public string commIds { get; set; }
    }

    public class CommSalesCount
    {
        public int sales { get; set; }

        public int amount { get; set; }

        public string commIds { get; set; }
    }

    public class CommColorCount
    {
        public int colorId { get; set; }
        public string name { get; set; }
        public string code { get; set; }
        public string commIds { get; set; }
    }

    public class CommId_Colors
    {
        public CommId_Colors(int id, string str)
        {

        }
        public int commId { get; set; }
        public List<int> colorIds { get; set; }
    }
}
