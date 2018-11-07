using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common.Extend
{
    public static class ListOpertion
    {
        /// <summary>
        /// 分离字符串成为列表
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static List<int> SplitToIntList(this string s, char car)
        {
            if (s != null)
            {
                var arry = s.Split(car);
                if (arry.Count() != 0)
                {
                    List<int> listInt = new List<int>();
                    foreach (var item in arry)
                    {
                        int? result = item.ParseInt();
                        if (result != null)
                        {
                            listInt.Add(result.Value);
                        }
                    }
                    return listInt;
                }
            }
            return new List<int>();

        }

        /// <summary>
        /// list互相叠加
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static List<T> Add<T>(this List<T> list1, List<T> list2)
        {
            foreach (var item in list2)
            {
                if (!item.ToString().IsNullOrEmpty())
                {
                    list1.Add(item);
                }
            }
            return list1;
        }
    }
}
