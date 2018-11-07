using Common;
using System.Collections.Generic;
using DbOpertion.Operation;
using DbOpertion.Models;

namespace DbOpertion.Function
{
    public partial class Order_AllinfoFunc : SingleTon<Order_AllinfoFunc>
    {
        /// <summary>
        /// 筛选全部数据
        /// </summary>
        /// <param name="model">模型</param>
        /// <returns>对象列表</returns>
        public List<Order_Allinfo> SelectByModel(Order_Allinfo model)
        {
            return Order_AllinfoOper.Instance.SelectAll(model);
        }
        /// <summary>
        /// 数据条数
        /// </summary>
        /// <param name="model">模型</param>
        /// <returns>对象列表</returns>
        public int SelectCount(Order_Allinfo model)
        {
            return Order_AllinfoOper.Instance.SelectCount(model);
        }

        /// <summary>
        /// 根据主键筛选数据
        /// </summary>
        /// <param name="KeyId">主键Id</param>
        /// <returns>是否成功</returns>
        public Order_Allinfo SelectById(int KeyId)
        {
            return Order_AllinfoOper.Instance.SelectById(KeyId);
        }

        /// <summary>
        /// 根据主键筛选数据
        /// </summary>
        /// <param name="KeyId">主键Id</param>
        /// <returns>是否成功</returns>
        public List<Order_Allinfo> SelectByKeys(string Key, List<string> KeyId)
        {
            return Order_AllinfoOper.Instance.SelectByKeys(Key,KeyId);
        }
        /// <summary>
        /// 根据分页筛选数据
        /// </summary>
        /// <param name="Key">主键</param>
        /// <param name="start">开始数据</param>
        /// <param name="PageSize">页面长度</param>
        /// <param name="desc">排序</param>
        /// <param name="model">对象</param>
        /// <returns>对象列表</returns>
        public List<Order_Allinfo> SelectByPage(string Key, int start, int PageSize, bool desc, Order_Allinfo model, string SelectFiled)
        {
            return Order_AllinfoOper.Instance.SelectByPage(Key, start, PageSize, desc, model);
        }    }
}
