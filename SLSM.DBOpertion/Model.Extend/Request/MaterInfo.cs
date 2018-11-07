using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SLSM.DBOpertion.Model.Request.Material
{
    public class MaterInfo
    {
        /// <summary>
        /// 
        /// </summary>
        public int MaterInfoId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int BaseCount { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int additionalCount { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string SKU { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool Isadditional { get; set; }
    }
}