using Common;
using System.Collections.Generic;
using DbOpertion.Operation;
using DbOpertion.Models;

namespace DbOpertion.Function
{
    public partial class Userlike_Commodity_ViewFunc : SingleTon<Userlike_Commodity_ViewFunc>
    {
        /// <summary>
        /// 筛选全部数据
        /// </summary>
        /// <param name="model">模型</param>
        /// <returns>对象列表</returns>
        public List<Userlike_Commodity_View> SelectByModel(Userlike_Commodity_View model)
        {
            return Userlike_Commodity_ViewOper.Instance.SelectAll(model);
        }
        /// <summary>
        /// 数据条数
        /// </summary>
        /// <param name="model">模型</param>
        /// <returns>对象列表</returns>
        public int SelectCount(Userlike_Commodity_View model)
        {
            return Userlike_Commodity_ViewOper.Instance.SelectCount(model);
        }

        /// <summary>
        /// 根据主键筛选数据
        /// </summary>
        /// <param name="KeyId">主键Id</param>
        /// <returns>是否成功</returns>
        public Userlike_Commodity_View SelectById(int KeyId)
        {
            return Userlike_Commodity_ViewOper.Instance.SelectById(KeyId);
        }

        /// <summary>
        /// 根据主键筛选数据
        /// </summary>
        /// <param name="KeyId">主键Id</param>
        /// <returns>是否成功</returns>
        public List<Userlike_Commodity_View> SelectByKeys(string Key, List<string> KeyId)
        {
            return Userlike_Commodity_ViewOper.Instance.SelectByKeys(Key,KeyId);
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
        public List<Userlike_Commodity_View> SelectByPage(string Key, int start, int PageSize, bool desc, Userlike_Commodity_View model, string SelectFiled)
        {
            return Userlike_Commodity_ViewOper.Instance.SelectByPage(Key, start, PageSize, desc, model);
        }    }
}
