using Common.Extend;
using Common.Filter.WebApi;
using Common.Helper;
using Common.Result;
using DbOpertion.Function;
using DbOpertion.Models;
using SLSM.AdminWeb.Model.Request.Service;
using SLSM.AdminWeb.Model.Request.User;
using SLSM.DBOpertion.Function;
using SLSM.Web.Models.Resquest.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.SessionState;

namespace SLSM.AdminWeb.Controllers.AjaxController
{
    /// <summary>
    /// 客服控制器
    /// </summary>
    public class ServiceController : BaseApiController
    {

        /// <summary>
        /// 增加客服信息
        /// </summary>
        /// <param name="request">请求</param>
        /// <returns></returns>
        [HttpPost]
        public ResultJson AddServiceInfo(AddServiceRequest request)
        {
            var result = CustomerserviceFunc.Instance.InsertModel(new DbOpertion.Models.Customerservice
            {
                ServiceName = request.ServiceName,
                ServiceALWW = request.ServiceALWW,
                ServiceQQ = request.ServiceQQ,
                ServiceWechat = request.ServiceWechat,
                ServicePhone = request.ServicePhone,
                IsService = request.IsService
            });
            if (result == "成功！")
            {
                return new ResultJson { HttpCode = 200, Message = "添加成功！" };
            }
            else
            {
                return new ResultJson { HttpCode = 300, Message = result };
            }

        }

        /// <summary>
        /// 修改客服信息
        /// </summary>
        /// <param name="request">请求</param>
        /// <returns></returns>
        [HttpPost]
        public ResultJson EditServiceInfo(AddServiceRequest request)
        {
            var name = request.ServiceName;
            var ServiceList = CustomerserviceFunc.Instance.SelectAllUserName(name);
            var Id = ServiceList.FirstOrDefault().Id;

            var result = CustomerserviceFunc.Instance.UpdateModel(new DbOpertion.Models.Customerservice
            {
                Id = request.Id,
                ServiceName = request.ServiceName,
                ServiceALWW = request.ServiceALWW,
                ServiceQQ = request.ServiceQQ,
                ServiceWechat = request.ServiceWechat,
                ServicePhone = request.ServicePhone,
                IsService = request.IsService
            });
            if (result == "成功！")
            {
                return new ResultJson { HttpCode = 200, Message = "修改成功！" };
            }
            else
            {
                return new ResultJson { HttpCode = 300, Message = result };
            }

        }

        /// <summary>
        /// 删除客服信息
        /// </summary>
        /// <param name="request">请求</param>
        /// <returns></returns>
        [HttpPost]
        public ResultJson DeleteService(ServiceInfoRequest request)
        {
            if (CustomerserviceFunc.Instance.DeleteModel(request.Id))
            {
                return new ResultJson { HttpCode = 200, Message = "删除成功！" };
            }
            else
            {
                return new ResultJson { HttpCode = 300, Message = "删除操作失败！" };
            }

        }
    }
}