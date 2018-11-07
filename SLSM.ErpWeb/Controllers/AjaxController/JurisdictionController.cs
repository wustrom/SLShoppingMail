using Common.Filter.WebApi;
using Common.Result;
using DbOpertion.Function;
using SLSM.ErpWeb.Model.Request.Color;
using SLSM.ErpWeb.Model.Request.Erpuser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SLSM.ErpWeb.Controllers.AjaxController
{
    public class JurisdictionController : BaseApiController
    {
        #region 角色
        /// <summary>
        /// 添加或修改角色
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public ResultJson EditJurisdictionInfo(ErpuserRequest request)
        {
            var result = false;
            #region 添加
            if (request.ErproleId == 0)
            {
                //添加角色
                result = ErpuserFunc.Instance.Insert(request.ErproleName);
            }
            #endregion

            #region 修改
            else
            {
                result = ErpuserFunc.Instance.Update(new DbOpertion.Models.Erpuser
                {
                    ErproleId = request.ErproleId,
                    ErproleName = request.ErproleName
                });
            }
            #endregion

            if (result)
            {
                return new ResultJson { HttpCode = 200, Message = "成功!" };
            }
            else
            {
                return new ResultJson { HttpCode = 300, Message = "失败!" };
            }
        }


        #region 删除
        /// <summary>
        /// 删除定制角色
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ResultJson DelEchnologyInfo(ErpuserRequest requst)
        {
            if (ErpuserFunc.Instance.DeleteById(requst.ErproleId))
            {
                return new ResultJson { HttpCode = 200, Message = "删除成功!" };
            }
            else
            {
                return new ResultJson { HttpCode = 300, Message = "删除失败!" };
            }
        }
        #endregion
        #endregion

        #region 权限
        /// <summary>
        /// 添加权限
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public ResultJson AddJurisdiction(ErpuserRequest request)
        {
            if (request.ERProlePower == "" || request.ErproleId == 0)
            {
                return new ResultJson { HttpCode = 300, Message = "请选择角色或者权限页面!" };
            }
            else
            {
                if (ErpuserFunc.Instance.UpdateErpUserInfo(request.ErproleId, request.ERProlePower))
                {
                    return new ResultJson { HttpCode = 200, Message = "成功!" };
                }
                else
                {
                    return new ResultJson { HttpCode = 300, Message = "失败!" };
                }
            }
        }
        /// <summary>
        /// 权限
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public ResultJson ERpUserInfo(ErpuserRequest request)
        {
            var result = ErpuserFunc.Instance.SelectById(request.ErproleId);
            if (result != null)
            {
                return new ResultJson { HttpCode = 200, Message = result.ERProlePower };
            }
            return new ResultJson { HttpCode = 300, Message = "请重试!" };

        }
        #endregion

        #region 用户登录管理
        /// <summary>
        /// 修改或增加
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public ResultJson UpdateLoginUser(ErpuserRequest request)
        {
            var result = false;
            if (request.erpLoginId == 0)
            {
                //增加
                result = ErploginuerFunc.Instance.Insert(new DbOpertion.Models.Erploginuer
                {
                    erpLoginName = request.erpLoginName,
                    erpLoginPwd = request.erpLoginPwd,
                    ErproleId = request.ErproleId
                });
            }
            else
            {
                //修改
                result = ErploginuerFunc.Instance.Update(new DbOpertion.Models.Erploginuer
                {
                    erpLoginId = request.erpLoginId,
                    erpLoginName = request.erpLoginName,
                    erpLoginPwd = request.erpLoginPwd,
                    ErproleId = request.ErproleId
                });
            }
            if (result)
            {
                return new ResultJson { HttpCode = 200, Message = "成功!" };
            }
            else
            {
                return new ResultJson { HttpCode = 300, Message = "失败!" };
            }
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public ResultJson DeleteLoginUser(ErpuserRequest request)
        {
            if (ErploginuerFunc.Instance.DeleteById(request.erpLoginId))
            {
                return new ResultJson { HttpCode = 200, Message = "成功" };
            }
            else
            {
                return new ResultJson { HttpCode = 300, Message = "失败,请重试!" };
            }
        }
        #endregion
    }
}
