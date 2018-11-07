using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Result.LayUITable
{
    /// <summary>
    /// lay编辑器应答
    /// </summary>
    public class LayEditResponse
    {
        /// <summary>
        /// 0表示成功，其它失败
        /// </summary>
        public int code { get; set; }
        /// <summary>
        /// 提示信息 一般上传失败后返回
        /// </summary>
        public string msg { get; set; }
        /// <summary>
        /// 数据
        /// </summary>
        public DataClass data { get; set; }
    }
    public class DataClass
    {
        /// <summary>
        /// 图片路径
        /// </summary>
        public string src { get; set; }
        /// <summary>
        /// 图片路径
        /// </summary>
        public string title { get; set; }
    }
}
