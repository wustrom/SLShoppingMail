using Common.Filter.WebApi;
using Common.Result;
using DbOpertion.Function;
using SLSM.DBOpertion.Function;
using SLSM.MoblieWeb.Models.Response.Message;
using SLSM.MoblieWeb.Models.Resquest.Message;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SLSM.MoblieWeb.Controllers.AjaxController
{
    /// <summary>
    /// 消息
    /// </summary>
    public class MessageController : BaseApiController
    {
        /// <summary>
        /// 详细信息加载
        /// </summary>
        /// <param name="mes"></param>
        /// <returns></returns>
        [HttpPost]
        public ResultJsonModel<MessageResponse> SelectMessageInfo(MessageRequest mes)
        {
            ResultJsonModel<MessageResponse> result = new ResultJsonModel<MessageResponse>();
            var messInfo = MessageFunc.Instance.SelectMessageId(mes.Id);
            if (messInfo != null)
            {
                result.HttpCode = 200;
                result.Message = "查询数据成功！";
                result.Model1 = new MessageResponse(messInfo);
            }
            else
            {
                result.HttpCode = 300;
                result.Message = "查询数据失败！";
            }
            return result;
        }
        /// <summary>
        ///  删除信息
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public ResultJson DelateMessInfo(MessageRequest request)
        {
            ResultJson result = new ResultJson();
            var message = MessageFunc.Instance.SelectMessageInfo(request.Id);
            var Messageresult = MessageFunc.Instance.DeleteMessage(request.Id);
            if (Messageresult)
            {
                result.HttpCode = 200;
                if (message != null)
                {
                    result.Message = "删除成功！";
                }
            }
            else
            {
                result.HttpCode = 300;
                result.Message = "删除失败！";
            }
            return result;
        }
        /// <summary>
        /// 未读改为已读
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public ResultJson UpdateRead(MessageRequest request)
        {
            ResultJson result = new ResultJson();
            var message = MessageFunc.Instance.SelectMessageInfo(request.Id);
            var Addressresult = MessageFunc.Instance.UpdateMessNoRead(new DbOpertion.Models.Message_Grant { Id = request.Id, IsWatch = true });
            if (Addressresult)
            {
                result.HttpCode = 200;
                if (message != null)
                {
                    result.Message = MessageFunc.Instance.SelectMessageCount(message.UserId.Value, false).ToString();
                }
            }
            else
            {
                result.HttpCode = 300;
                result.Message = "操作错误！";
            }
            return result;
        }

    }
}
