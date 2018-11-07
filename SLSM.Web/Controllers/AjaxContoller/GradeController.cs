using Common.Filter.WebApi;
using Common.Result;
using DbOpertion.Function;
using DbOpertion.Models;
using SLSM.DBOpertion.Function;
using SLSM.DBOpertion.Model.Extend.Response.GradeRes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SLSM.Web.Controllers.AjaxContoller
{
    public class GradeController : BaseApiController
    {
        /// <summary>
        /// 获取一级分类
        /// </summary>
        /// <returns></returns>
        [WebApiException]
        [WebApiModelValidate]
        [HttpPost]
        public ResultJson<GradeRes> GetGrade1()
        {
            var list = GradeFunc.Instance.GetGrade12();
            ResultJson<GradeRes> r = new ResultJson<GradeRes>();
            //if (list.Count == 0)
            //{
            //    r.HttpCode = 300;
            //    r.Message = "暂无一级属性";
            //    return r;
            //}
            //else
            //{
            r.HttpCode = 200;
            r.Message = "";
            r.ListData = list;
            //}
            return r;
        }

        /// <summary>
        /// 获取前8个热门分类
        /// </summary>
        /// <returns></returns>
        [WebApiException]
        [WebApiModelValidate]
        [HttpPost]
        public ResultJson<GradeId_Name_Img> GetHotGrade()
        {
            var list = GradeFunc.Instance.GetHotGrade(8);
            ResultJson<GradeId_Name_Img> r = new ResultJson<GradeId_Name_Img>();
            r.HttpCode = 200;
            r.ListData = list;
            r.Message = "";
            return r;
        }

    }
}
