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
    public class LayUITableRequest
    {
        /// <summary>
        /// 页码
        /// </summary>
        public int pageIndex { get; set; }
        /// <summary>
        /// 页面大小
        /// </summary>
        public int pageSize { get; set; }
        /// <summary>
        /// 排序方式
        /// </summary>
        public string sort { get; set; }
        /// <summary>
        /// 升序还是降序
        /// </summary>
        public string order { get; set; }
        /// <summary>
        /// 搜索内容
        /// </summary>
        public string name { get; set; }
    }

}
