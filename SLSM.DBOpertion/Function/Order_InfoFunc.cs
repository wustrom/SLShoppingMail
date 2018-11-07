using Common;
using System.Collections.Generic;
using DbOpertion.Operation;
using DbOpertion.Models;

namespace DbOpertion.Function
{
    public partial class Order_InfoFunc : SingleTon<Order_InfoFunc>
    {
        /// <summary>
        /// 根据主键删除数据
        /// </summary>
        /// <param name="KeyId">主键Id</param>
        /// <returns>是否成功</returns>
        public bool DeleteById(int KeyId)
        {
            return Order_InfoOper.Instance.DeleteById(KeyId);
        }

        /// <summary>
        /// 根据模型删除数据
        /// </summary>
        /// <param name="model">模型</param>
        /// <returns>是否成功</returns>
        public bool DeleteModel(Order_Info model)
        {
            return Order_InfoOper.Instance.DeleteModel(model);
        }
        /// <summary>
        /// 根据模型更新
        /// </summary>
        /// <param name="model">模型</param>
        /// <returns>是否成功</returns>
        public bool Update(Order_Info model)
        {
            return Order_InfoOper.Instance.Update(model);
        }
        /// <summary>
        /// 根据模型插入
        /// </summary>
        /// <param name="model">模型</param>
        /// <returns>是否成功</returns>
        public bool Insert(Order_Info model)
        {
            return Order_InfoOper.Instance.Insert(model);
        }
        /// <summary>
        /// 根据模型插入
        /// </summary>
        /// <param name="model">模型</param>
        /// <returns>是否成功</returns>
        public int InsertReturnKey(Order_Info model)
        {
            return Order_InfoOper.Instance.InsertReturnKey(model);
        }
        /// <summary>
        /// 筛选全部数据
        /// </summary>
        /// <param name="model">模型</param>
        /// <returns>对象列表</returns>
        public List<Order_Info> SelectByModel(Order_Info model)
        {
            return Order_InfoOper.Instance.SelectAll(model);
        }
        /// <summary>
        /// 数据条数
        /// </summary>
        /// <param name="model">模型</param>
        /// <returns>对象列表</returns>
        public int SelectCount(Order_Info model)
        {
            return Order_InfoOper.Instance.SelectCount(model);
        }

        /// <summary>
        /// 根据主键筛选数据
        /// </summary>
        /// <param name="KeyId">主键Id</param>
        /// <returns>是否成功</returns>
        public Order_Info SelectById(int KeyId)
        {
            return Order_InfoOper.Instance.SelectById(KeyId);
        }

        /// <summary>
        /// 根据主键筛选数据
        /// </summary>
        /// <param name="KeyId">主键Id</param>
        /// <returns>是否成功</returns>
        public List<Order_Info> SelectByKeys(string Key, List<string> KeyId)
        {
            return Order_InfoOper.Instance.SelectByKeys(Key,KeyId);
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
        public List<Order_Info> SelectByPage(string Key, int start, int PageSize, bool desc, Order_Info model, string SelectFiled)
        {
            return Order_InfoOper.Instance.SelectByPage(Key, start, PageSize, desc, model);
        }    }
}
