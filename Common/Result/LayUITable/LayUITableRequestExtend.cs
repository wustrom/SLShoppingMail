using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Result
{
    /// <summary>
    /// LayUI请求
    /// </summary>
    public class LayUITableRequestExtend
    {
        /// <summary>
        /// 页码
        /// </summary>
        public int pageIndex { get; set; }
        /// <summary>
        /// 页面大小
        /// </summary>
        public int pageSize { get; set; }
        public List<int> ids { get; set; }
    }

}
