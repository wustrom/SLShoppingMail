using Aliyun.Acs.Dysmsapi.Model.V20170525;
using AliyunHelper.SendMail;
using Common;
using Common.Extend;
using Common.Helper;
using DbOpertion.Models;
using DbOpertion.Operation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbOpertion.Function
{
    public partial class MessageFunc : SingleTon<MessageFunc>
    {
        /// <summary>
        /// 消息
        /// </summary>
        /// <param name="Start"></param>
        /// <param name="PageSize"></param>
        /// <returns></returns>
        public List<Message_Grant_View> SelectMessage(int Start, int PageSize, int UserId, bool? IsWatch = null)
        {
            var MessageList = Message_Grant_ViewOper.Instance.SelectByPage("IsWatch", Start, PageSize, false, new Message_Grant_View { UserId = UserId, IsWatch = IsWatch });
            return MessageList;
        }
        /// <summary>
        /// 根据Id筛选
        /// </summary>
        /// <param name="MessageId">发放表Id</param>
        /// <returns></returns>
        public Message_Grant_View SelectMessageInfo(int MessageId)
        {
            var Message = Message_Grant_ViewOper.Instance.SelectById(MessageId);
            return Message;
        }
        /// <summary>
        /// 根据Id查询
        /// </summary>
        /// <param name="Id">发放表Id</param>
        /// <returns></returns>
        public Message_Grant_View SelectMessageId(int Id)
        {
            return Message_Grant_ViewOper.Instance.SelectById(Id);
        }
        /// <summary>
        /// 删除消息
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public bool DeleteMessage(int Id)
        {

            return Message_GrantOper.Instance.DeleteById(Id);
        }
        /// <summary>
        /// 筛选全部消息个数
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public int SelectMessageCount(int UserId, bool? IsWatch = null)
        {
            return Message_GrantOper.Instance.SelectCount(new Message_Grant { UserId = UserId, IsWatch = IsWatch });
        }
        /// <summary>
        /// 未读改为已读
        /// </summary>
        /// <param name="mes"></param>
        /// <returns></returns>
        public bool UpdateMessNoRead(Message_Grant mes)
        {
            return Message_GrantOper.Instance.Update(mes);
        }

        /// <summary>
        /// 筛选全部
        /// </summary>
        /// <returns></returns>
        public List<Message> SelectMessageByPage(string OrderBy, string order, int Start, int PageSize)
        {
            var desc = order == "desc" ? true : false;
            return MessageOper.Instance.SelectByPage(OrderBy, Start, PageSize, desc, new Message { IsDelete = false });
        }

        /// <summary>
        /// 筛选全部数目
        /// </summary>
        /// <returns></returns>
        public int SelectAllMessageCount()
        {
            return MessageOper.Instance.SelectCount(new Message { IsDelete = false });
        }


        /// <summary>
        /// 根据Model插入
        /// </summary>
        /// <returns></returns>
        public bool InsertByModel(Message message)
        {
            if (message.Id == 0)
            {
                message.MessageTime = DateTime.Now;
                #region 插入
                if (MessageOper.Instance.Insert(message))
                {
                    return true;
                }
                else
                {
                    return false;
                }
                #endregion
            }
            else
            {
                #region 更新
                if (MessageOper.Instance.Update(message))
                {
                    return true;
                }
                else
                {
                    return false;
                }
                #endregion
            }
        }

        /// <summary>
        /// 根据信息ID与用户Id进行发送消息
        /// </summary>
        /// <returns></returns>
        public bool SendMessage(int Id, string UserIds)
        {
            if (Id == 0 || UserIds == null)
            {
                return false;
            }
            var MysqlHelper = SqlHelper.GetMySqlHelper("transaction");
            var connection = MysqlHelper.CreatConn();
            var transaction = MysqlHelper.GetTransaction();
            var ArrayUserId = UserIds.Split(',').Where(p => !string.IsNullOrEmpty(p)).ToList();
            try
            {
                foreach (var item in ArrayUserId)
                {
                    Message_Grant grant = new Message_Grant { IsWatch = false, MessageId = Id, UserId = item.ParseInt() };
                    if (!Message_GrantOper.Instance.Insert(grant, connection, transaction))
                    {
                        transaction.Rollback();
                        connection.Close();
                        return false;
                    }
                }
                transaction.Commit();
                connection.Close();
                return true;
            }
            catch (Exception)
            {
                transaction.Rollback();
                connection.Close();
                return false;
            }


        }
    }
}
