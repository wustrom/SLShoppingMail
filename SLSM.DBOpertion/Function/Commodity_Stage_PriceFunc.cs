using Common;
using System.Collections.Generic;
using DbOpertion.Operation;
using DbOpertion.Models;

namespace DbOpertion.Function
{
    public partial class Commodity_Stage_PriceFunc : SingleTon<Commodity_Stage_PriceFunc>
    {
        /// <summary>
        /// 根据主键删除数据
        /// </summary>
        /// <param name="KeyId">主键Id</param>
        /// <returns>是否成功</returns>
        public bool DeleteById(int KeyId)
        {
            return Commodity_Stage_PriceOper.Instance.DeleteById(KeyId);
        }

        /// <summary>
        /// 根据模型删除数据
        /// </summary>
        /// <param name="model">模型</param>
        /// <returns>是否成功</returns>
        public bool DeleteModel(Commodity_Stage_Price model)
        {
            return Commodity_Stage_PriceOper.Instance.DeleteModel(model);
        }
        /// <summary>
        /// 根据模型更新
        /// </summary>
        /// <param name="model">模型</param>
        /// <returns>是否成功</returns>
        public bool Update(Commodity_Stage_Price model)
        {
            return Commodity_Stage_PriceOper.Instance.Update(model);
        }
        /// <summary>
        /// 根据模型插入
        /// </summary>
        /// <param name="model">模型</param>
        /// <returns>是否成功</returns>
        public bool Insert(Commodity_Stage_Price model)
        {
            return Commodity_Stage_PriceOper.Instance.Insert(model);
        }
        /// <summary>
        /// 根据模型插入
        /// </summary>
        /// <param name="model">模型</param>
        /// <returns>是否成功</returns>
        public int InsertReturnKey(Commodity_Stage_Price model)
        {
            return Commodity_Stage_PriceOper.Instance.InsertReturnKey(model);
        }
        /// <summary>
        /// 筛选全部数据
        /// </summary>
        /// <param name="model">模型</param>
        /// <returns>对象列表</returns>
        public List<Commodity_Stage_Price> SelectByModel(Commodity_Stage_Price model)
        {
            return Commodity_Stage_PriceOper.Instance.SelectAll(model);
        }
        /// <summary>
        /// 数据条数
        /// </summary>
        /// <param name="model">模型</param>
        /// <returns>对象列表</returns>
        public int SelectCount(Commodity_Stage_Price model)
        {
            return Commodity_Stage_PriceOper.Instance.SelectCount(model);
        }

        /// <summary>
        /// 根据主键筛选数据
        /// </summary>
        /// <param name="KeyId">主键Id</param>
        /// <returns>是否成功</returns>
        public Commodity_Stage_Price SelectById(int KeyId)
        {
            return Commodity_Stage_PriceOper.Instance.SelectById(KeyId);
        }

        /// <summary>
        /// 根据主键筛选数据
        /// </summary>
        /// <param name="KeyId">主键Id</param>
        /// <returns>是否成功</returns>
        public List<Commodity_Stage_Price> SelectByKeys(string Key, List<string> KeyId)
        {
            return Commodity_Stage_PriceOper.Instance.SelectByKeys(Key,KeyId);
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
        public List<Commodity_Stage_Price> SelectByPage(string Key, int start, int PageSize, bool desc, Commodity_Stage_Price model, string SelectFiled)
        {
            return Commodity_Stage_PriceOper.Instance.SelectByPage(Key, start, PageSize, desc, model);
        }    }
}
