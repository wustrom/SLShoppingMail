using Common;
using System.Collections.Generic;
using DbOpertion.Operation;
using DbOpertion.Models;

namespace DbOpertion.Function
{
    public partial class EvalinfoFunc : SingleTon<EvalinfoFunc>
    {
        /// <summary>
        /// 筛选全部数据
        /// </summary>
        /// <param name="model">模型</param>
        /// <returns>对象列表</returns>
        public List<Evalinfo> SelectByModel(Evalinfo model)
        {
            return EvalinfoOper.Instance.SelectAll(model);
        }
        /// <summary>
        /// 数据条数
        /// </summary>
        /// <param name="model">模型</param>
        /// <returns>对象列表</returns>
        public int SelectCount(Evalinfo model)
        {
            return EvalinfoOper.Instance.SelectCount(model);
        }

        /// <summary>
        /// 根据主键筛选数据
        /// </summary>
        /// <param name="KeyId">主键Id</param>
        /// <returns>是否成功</returns>
        public Evalinfo SelectById(int KeyId)
        {
            return EvalinfoOper.Instance.SelectById(KeyId);
        }

        /// <summary>
        /// 根据主键筛选数据
        /// </summary>
        /// <param name="KeyId">主键Id</param>
        /// <returns>是否成功</returns>
        public List<Evalinfo> SelectByKeys(string Key, List<string> KeyId)
        {
            return EvalinfoOper.Instance.SelectByKeys(Key,KeyId);
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
        public List<Evalinfo> SelectByPage(string Key, int start, int PageSize, bool desc, Evalinfo model, string SelectFiled)
        {
            return EvalinfoOper.Instance.SelectByPage(Key, start, PageSize, desc, model);
        }    }
}
