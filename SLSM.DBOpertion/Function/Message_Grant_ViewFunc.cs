using Common;
using System.Collections.Generic;
using DbOpertion.Operation;
using DbOpertion.Models;

namespace DbOpertion.Function
{
    public partial class Message_Grant_ViewFunc : SingleTon<Message_Grant_ViewFunc>
    {
        /// <summary>
        /// 筛选全部数据
        /// </summary>
        /// <param name="model">模型</param>
        /// <returns>对象列表</returns>
        public List<Message_Grant_View> SelectByModel(Message_Grant_View model)
        {
            return Message_Grant_ViewOper.Instance.SelectAll(model);
        }
        /// <summary>
        /// 数据条数
        /// </summary>
        /// <param name="model">模型</param>
        /// <returns>对象列表</returns>
        public int SelectCount(Message_Grant_View model)
        {
            return Message_Grant_ViewOper.Instance.SelectCount(model);
        }

        /// <summary>
        /// 根据主键筛选数据
        /// </summary>
        /// <param name="KeyId">主键Id</param>
        /// <returns>是否成功</returns>
        public Message_Grant_View SelectById(int KeyId)
        {
            return Message_Grant_ViewOper.Instance.SelectById(KeyId);
        }

        /// <summary>
        /// 根据主键筛选数据
        /// </summary>
        /// <param name="KeyId">主键Id</param>
        /// <returns>是否成功</returns>
        public List<Message_Grant_View> SelectByKeys(string Key, List<string> KeyId)
        {
            return Message_Grant_ViewOper.Instance.SelectByKeys(Key,KeyId);
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
        public List<Message_Grant_View> SelectByPage(string Key, int start, int PageSize, bool desc, Message_Grant_View model, string SelectFiled)
        {
            return Message_Grant_ViewOper.Instance.SelectByPage(Key, start, PageSize, desc, model);
        }    }
}
