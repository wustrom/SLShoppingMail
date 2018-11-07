using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Attribute
{
    public class PageNoAttribute : ValidationAttribute
    {

        /// <summary>
        /// 默认值
        /// </summary>
        public int DefaultNo { get; set; }
        public override bool IsValid(object value)
        {
            this.ErrorMessage = "页码不正确！";
            if (value == null)
            {
                value = DefaultNo;
            }

            return true;
        }
    }
    public class PageSizeAttribute : ValidationAttribute
    {
        /// <summary>
        /// 默认值
        /// </summary>
        public int DefaultSize { get; set; }
        public override bool IsValid(object value)
        {
            this.ErrorMessage = "页面大小不正确！";
            if (value == null)
            {
                value = DefaultSize;
            }
            return true;
        }
    }
}
