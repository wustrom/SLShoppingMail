using Common.Filter.WebApi;
using Common.Result;
using DbOpertion.Function;
using SLSM.ErpWeb.Model.Request.Color;
using SLSM.ErpWeb.Model.Request.Echnology;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SLSM.ErpWeb.Controllers.AjaxController
{
    public class EquipmentController : BaseApiController
    {
        #region 定制工艺
        /// <summary>
        /// 添加或修改工艺
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public ResultJson EditEchnologyInfo(EchnologyRequest request)
        {
            var result = "";
            #region 添加
            if (request.Id == 0)
            {
                result = TechnologyFunc.Instance.InsertTechnology(new DbOpertion.Models.Technology
                {
                    Name = request.Name,
                    IsDelete = true
                });
                #endregion

                #region 修改
            }
            else
            {
                result = TechnologyFunc.Instance.UpdateTechnology(new DbOpertion.Models.Technology
                {
                    Id = request.Id,
                    Name = request.Name
                });
            }
            #endregion

            if (result == "成功!")
            {
                return new ResultJson { HttpCode = 200, Message = result };
            }
            else
            {
                return new ResultJson { HttpCode = 300, Message = "失败!" };
            }
        }
        /// <summary>
        /// 删除定制工艺
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ResultJson DelEchnologyInfo(EchnologyRequest requst)
        {
            if (TechnologyFunc.Instance.DelListTechnology(requst.Ids))
            {
                return new ResultJson { HttpCode = 200, Message = "删除成功!" };
            }
            else
            {
                return new ResultJson { HttpCode = 300, Message = "删除失败!" };
            }
        }
        #endregion

        #region 颜色方法
        /// <summary>
        /// 添加或修改颜色
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public ResultJson EditColorInfo(EditColorDetailRequest request)
        {
            #region 颜色为空，添加颜色
            if (request.ColorId == null || request.ColorId == 0)
            {
                if (request.fatherId == null)
                {
                    if (ColorinfoFunc.Instance.Insert(new DbOpertion.Models.Colorinfo { IsDelete = false, ChinaDescribe = request.ChinaDescribe, ParentId = 0 }))
                    {
                        ColorinfoFunc.Instance.ReSetList();
                        return new ResultJson { HttpCode = 200, Message = "色系添加成功！" };
                    }
                }
                else
                {
                    if (ColorinfoFunc.Instance.Insert(new DbOpertion.Models.Colorinfo { IsDelete = false, StandardColor = request.StandardColor, ParentId = request.fatherId, ChinaDescribe = request.ChinaDescribe, EngDescibe = request.EngDescibe, HtmlCode = request.HtmlCode }))
                    {
                        ColorinfoFunc.Instance.ReSetList();
                        return new ResultJson { HttpCode = 200, Message = "颜色添加成功！" };
                    }
                }
                return new ResultJson { HttpCode = 300, Message = "颜色添加失败请重新尝试！" };
            }
            #endregion

            #region 颜色不为空，修改颜色
            else
            {
                if (request.fatherId == null)
                {
                    if (ColorinfoFunc.Instance.Update(new DbOpertion.Models.Colorinfo { ChinaDescribe = request.ChinaDescribe, Id = request.ColorId.Value }))
                    {
                        ColorinfoFunc.Instance.ReSetList();
                        return new ResultJson { HttpCode = 200, Message = "色系修改成功！" };
                    }
                }
                else
                {
                    if (ColorinfoFunc.Instance.Update(new DbOpertion.Models.Colorinfo { StandardColor = request.StandardColor, ChinaDescribe = request.ChinaDescribe, EngDescibe = request.EngDescibe, HtmlCode = request.HtmlCode, Id = request.ColorId.Value }))
                    {
                        ColorinfoFunc.Instance.ReSetList();
                        return new ResultJson { HttpCode = 200, Message = "颜色修改成功！" };
                    }
                }
                return new ResultJson { HttpCode = 300, Message = "颜色修改失败请重新尝试！" };
            }
            #endregion

        }
        /// <summary>
        /// 删除颜色
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ResultJson DelColorInfo(EditColorDetailRequest requst)
        {
            if (requst.ColorId == null)
            {
                return new ResultJson { HttpCode = 200, Message = "请上传颜色ID!" };
            }
            if (ColorinfoFunc.Instance.Update(new DbOpertion.Models.Colorinfo { IsDelete = true, Id = requst.ColorId.Value }))
            {
                ColorinfoFunc.Instance.ReSetList();
                return new ResultJson { HttpCode = 200, Message = "删除成功!" };
            }
            else
            {
                return new ResultJson { HttpCode = 300, Message = "删除失败!" };
            }
        }

        #endregion
    }
}
