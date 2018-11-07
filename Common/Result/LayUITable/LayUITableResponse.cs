using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Result
{

    /// <summary>
    /// LayUI应答
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class LayUITableResponse<T> where T : class, new()
    {
        /// <summary>
        /// LayUI表应答
        /// </summary>
        public LayUITableResponse()
        {
            this.list = new T();
        }
        /// <summary>
        /// 是否应答成功
        /// </summary>
        public bool rel { get; set; }
        /// <summary>
        /// 应答返回信息
        /// </summary>
        public string msg { get; set; }
        /// <summary>
        /// 应答数据
        /// </summary>
        public T list { get; set; }

        /// <summary>
        /// 数据条数
        /// </summary>
        public int count { get; set; }

        /// <summary>
        /// 应答返回信息
        /// </summary>
        public string pageno { get; set; }
    }

}
