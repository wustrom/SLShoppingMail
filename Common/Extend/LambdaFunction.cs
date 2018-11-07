using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Extend.LambdaFunction
{
    public static class LambdaFunction
    {
        /// <summary>
        /// 验证Str2是否在Str里面
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="List_Int">列表</param>
        /// <returns></returns>
        public static bool Like(this object Str, string Str2)
        {
            if (Str != null)
            {
                return Str.ToString().Contains(Str2);
            }
            else
            {
                return false;
            }
            
        }

        /// <summary>
        /// 验证是否在列表内
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="List_Int">列表</param>
        /// <returns></returns>
        public static bool In(this object Id, List<string> List_Int)
        {
            if (Id != null)
            {
                return List_Int.Contains(Id.ToString());
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 验证是否在列表内
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="List_Int">列表</param>
        /// <returns></returns>
        public static bool NotIn(this object Id, List<string> List_Int)
        {
            if (Id == null)
            {
                return false;
            }
            return !List_Int.Contains(Id.ToString());
        }
    }
}
