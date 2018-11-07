using Common.Filter.WebApi;
using Common.Helper;
using Common.Result;
using DbOpertion.Function;
using DbOpertion.Models;
using SLSM.DBOpertion.Function;
using SLSM.Web.Models.Response.Message;
using SLSM.Web.Models.Resquest;
using SLSM.Web.Models.Resquest.Message;
using System.Collections.Generic;
using System.Web.Http;

namespace SLSM.Web.Controllers.AjaxContoller
{
    /// <summary>
    /// 信息控制器
    /// </summary>
    public class MessageController : BaseApiController
    {
        /// <summary>
        /// 信息分页查询
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>

        [HttpPost]
        public ResultJsonModel<List<MessageResponse>, int> MessagePage(MessageRequest request)
        {
            ResultJsonModel<List<MessageResponse>, int> result = new ResultJsonModel<List<MessageResponse>, int>();
            var userGuid = CookieOper.Instance.GetUserGuid();
            var user = MemCacheHelper2.Instance.Cache.GetModel<User>("UserGuID_" + userGuid);
            var listMessage = MessageFunc.Instance.SelectMessage((request.PageNo - 1) * request.PageSize, request.PageSize, user.Id, request.IsWatch);
            var flag = true;
            result.Model1 = new List<MessageResponse>();
            foreach (var item in listMessage)
            {
                MessageResponse response = new MessageResponse(item);
                if (flag && request.PageNo == 1)
                {
                    flag = false;
                }
                result.Model1.Add(response);
            }
            result.HttpCode = 200;
            result.Message = "查询数据成功！";
            result.Model2 = MessageFunc.Instance.SelectMessageCount(user.Id, request.IsWatch);
            result.Model2 = (result.Model2 % 7) == 0 ? result.Model2 / 7 : (result.Model2 / 7) + 1;
            return result;
        }

        /// <summary>
        /// 详细信息查询
        /// </summary>
        /// <param name="mes"></param>
        /// <returns></returns>
        [HttpPost]
        public ResultJsonModel<MessageResponse> selectmessageinfo(MessageRequest mes)
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
        /// <summary>
        ///  删除联系人信息
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
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
                    result.Message = MessageFunc.Instance.SelectMessageCount(message.UserId.Value, false).ToString();
                }
            }
            else
            {
                result.HttpCode = 300;
                result.Message = "删除失败！";
            }
            return result;
        }
    }
}
