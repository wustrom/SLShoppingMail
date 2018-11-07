using Common;
using System.Collections.Generic;
using DbOpertion.Operation;
using DbOpertion.Models;

namespace DbOpertion.Function
{
    public partial class Materials_ColorinfoFunc : SingleTon<Materials_ColorinfoFunc>
    {
        /// <summary>
        /// 根据主键删除数据
        /// </summary>
        /// <param name="KeyId">主键Id</param>
        /// <returns>是否成功</returns>
        public bool DeleteById(int KeyId)
        {
            return Materials_ColorinfoOper.Instance.DeleteById(KeyId);
        }

        /// <summary>
        /// 根据模型删除数据
        /// </summary>
        /// <param name="model">模型</param>
        /// <returns>是否成功</returns>
        public bool DeleteModel(Materials_Colorinfo model)
        {
            return Materials_ColorinfoOper.Instance.DeleteModel(model);
        }
        /// <summary>
        /// 根据模型更新
        /// </summary>
        /// <param name="model">模型</param>
        /// <returns>是否成功</returns>
        public bool Update(Materials_Colorinfo model)
        {
            return Materials_ColorinfoOper.Instance.Update(model);
        }
        /// <summary>
        /// 根据模型插入
        /// </summary>
        /// <param name="model">模型</param>
        /// <returns>是否成功</returns>
        public bool Insert(Materials_Colorinfo model)
        {
            return Materials_ColorinfoOper.Instance.Insert(model);
        }
        /// <summary>
        /// 根据模型插入
        /// </summary>
        /// <param name="model">模型</param>
        /// <returns>是否成功</returns>
        public int InsertReturnKey(Materials_Colorinfo model)
        {
            return Materials_ColorinfoOper.Instance.InsertReturnKey(model);
        }
        /// <summary>
        /// 筛选全部数据
        /// </summary>
        /// <param name="model">模型</param>
        /// <returns>对象列表</returns>
        public List<Materials_Colorinfo> SelectByModel(Materials_Colorinfo model)
        {
            return Materials_ColorinfoOper.Instance.SelectAll(model);
        }
        /// <summary>
        /// 数据条数
        /// </summary>
        /// <param name="model">模型</param>
        /// <returns>对象列表</returns>
        public int SelectCount(Materials_Colorinfo model)
        {
            return Materials_ColorinfoOper.Instance.SelectCount(model);
        }

        /// <summary>
        /// 根据主键筛选数据
        /// </summary>
        /// <param name="KeyId">主键Id</param>
        /// <returns>是否成功</returns>
        public Materials_Colorinfo SelectById(int KeyId)
        {
            return Materials_ColorinfoOper.Instance.SelectById(KeyId);
        }

        /// <summary>
        /// 根据主键筛选数据
        /// </summary>
        /// <param name="KeyId">主键Id</param>
        /// <returns>是否成功</returns>
        public List<Materials_Colorinfo> SelectByKeys(string Key, List<string> KeyId)
        {
            return Materials_ColorinfoOper.Instance.SelectByKeys(Key,KeyId);
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
        public List<Materials_Colorinfo> SelectByPage(string Key, int start, int PageSize, bool desc, Materials_Colorinfo model, string SelectFiled)
        {
            return Materials_ColorinfoOper.Instance.SelectByPage(Key, start, PageSize, desc, model);
        }    }
}
