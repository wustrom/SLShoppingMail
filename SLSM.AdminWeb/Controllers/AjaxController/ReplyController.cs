using Common.Filter.WebApi;
using Common.Helper;
using Common.Result;
using DbOpertion.Function;
using DbOpertion.Models;
using SLSM.AdminWeb.Model.Request.Reply;
using SLSM.DBOpertion.Function;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace SLSM.AdminWeb.Controllers.AjaxController
{
    /// <summary>
    /// 回复控制器
    /// </summary>
    public class ReplyController : ApiController
    {
        /// <summary>
        /// 插入回复
        /// </summary>
        /// <param name="request">请求</param>
        /// <returns></returns>
        [HttpPost]
        [WebApiModelValidate]
        [WebApiException]
        public ResultJson InsertReply(ReplyRequest request)
        {
            #region 检测有无临时图片
            if (request.ImgList.Contains("temp"))
            {
                var array = request.ImgList.Split('|').Where(p => !string.IsNullOrEmpty(p)).ToList();
                request.ImgList = "";
                foreach (var item in array)
                {
                    if (item.Contains("temp"))
                    {
                        FileHelper.Instance.Move(HttpContext.Current.Server.MapPath(item), HttpContext.Current.Server.MapPath($"/current/images/Commodity/" + item.Split('/').Last()), HttpContext.Current.Server.MapPath($"/current/images/Commodity"));
                        request.ImgList = request.ImgList + $"/current/images/Commodity/" + item.Split('/').Last() + "|";
                    }
                    else
                    {
                        request.ImgList = request.ImgList + item + "|";
                    }
                }
            }
            #endregion
            Reply reply = new Reply
            {
                Content = request.Content,
                EvalinfoId = request.ParentEvalId,
                ImageList = request.ImgList,
                Id = request.ReplyId
            };
            if (EvaluateFunc.Instance.InsertReply(reply))
            {
                return new ResultJson { HttpCode = 200, Message = "操作成功！" };
            }
            else
            {
                return new ResultJson { HttpCode = 400, Message = "操作失败，请再次尝试！" };
            }
        }
    }
}