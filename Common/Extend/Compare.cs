using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Extend
{
    /// <summary>
    /// 比较
    /// </summary>
    public static class Compare
    {
        /// <summary>
        /// 比较字符串是否一致
        /// </summary>
        /// <param name="str1">原字符串</param>
        /// <param name="str2">比较字符串</param>
        /// <returns></returns>
        public static bool CompareWith(this string str1, string str2)
        {
            if (str1 == null && str2 == null)
            {
                return true;
            }
            else if (str1 != null && str2 != null)
            {
                if (str1.ToUpper().Trim() == str2.ToUpper().Trim())
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
    }
}
