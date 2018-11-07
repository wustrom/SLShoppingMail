using System;

namespace DbOpertion.Models
{
    [Serializable]
    public class Todayorder
    {
        /// <summary>
        /// 
        /// </summary>
        public Decimal? TotalPrice { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Int64 OrderCount { get; set; }

    }
}
