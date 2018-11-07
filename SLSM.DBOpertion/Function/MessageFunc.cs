using Common;
using System.Collections.Generic;
using DbOpertion.Operation;
using DbOpertion.Models;

namespace DbOpertion.Function
{
    public partial class MessageFunc : SingleTon<MessageFunc>
    {
        /// <summary>
        /// 根据主键删除数据
        /// </summary>
        /// <param name="KeyId">主键Id</param>
        /// <returns>是否成功</returns>
        public bool DeleteById(int KeyId)
        {
            return MessageOper.Instance.DeleteById(KeyId);
        }

        /// <summary>
        /// 根据模型删除数据
        /// </summary>
        /// <param name="model">模型</param>
        /// <returns>是否成功</returns>
        public bool DeleteModel(Message model)
        {
            return MessageOper.Instance.DeleteModel(model);
        }
        /// <summary>
        /// 根据模型更新
        /// </summary>
        /// <param name="model">模型</param>
        /// <returns>是否成功</returns>
        public bool Update(Message model)
        {
            return MessageOper.Instance.Update(model);
        }
        /// <summary>
        /// 根据模型插入
        /// </summary>
        /// <param name="model">模型</param>
        /// <returns>是否成功</returns>
        public bool Insert(Message model)
        {
            return MessageOper.Instance.Insert(model);
        }
        /// <summary>
        /// 根据模型插入
        /// </summary>
        /// <param name="model">模型</param>
        /// <returns>是否成功</returns>
        public int InsertReturnKey(Message model)
        {
            return MessageOper.Instance.InsertReturnKey(model);
        }
        /// <summary>
        /// 筛选全部数据
        /// </summary>
        /// <param name="model">模型</param>
        /// <returns>对象列表</returns>
        public List<Message> SelectByModel(Message model)
        {
            return MessageOper.Instance.SelectAll(model);
        }
        /// <summary>
        /// 数据条数
        /// </summary>
        /// <param name="model">模型</param>
        /// <returns>对象列表</returns>
        public int SelectCount(Message model)
        {
            return MessageOper.Instance.SelectCount(model);
        }

        /// <summary>
        /// 根据主键筛选数据
        /// </summary>
        /// <param name="KeyId">主键Id</param>
        /// <returns>是否成功</returns>
        public Message SelectById(int KeyId)
        {
            return MessageOper.Instance.SelectById(KeyId);
        }

        /// <summary>
        /// 根据主键筛选数据
        /// </summary>
        /// <param name="KeyId">主键Id</param>
        /// <returns>是否成功</returns>
        public List<Message> SelectByKeys(string Key, List<string> KeyId)
        {
            return MessageOper.Instance.SelectByKeys(Key,KeyId);
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
        public List<Message> SelectByPage(string Key, int start, int PageSize, bool desc, Message model, string SelectFiled)
        {
            return MessageOper.Instance.SelectByPage(Key, start, PageSize, desc, model);
        }    }
}
