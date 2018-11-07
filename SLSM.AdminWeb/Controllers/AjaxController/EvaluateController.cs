using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SLSM.AdminWeb.Model.Request.Commdity;
using DbOpertion.Models;
using Common.Helper;
using SLSM.DBOpertion.Function;
using Common.Result;
using Common.Filter.WebApi;
using DbOpertion.Function;
using System.Web;

namespace SLSM.AdminWeb.Controllers.AjaxController
{
    public class EvaluateController : ApiController
    {
        /// <summary>
        /// 更新商品
        /// </summary>
        /// <param name="request">请求</param>
        /// <returns></returns>
        [HttpPost]
        [WebApiModelValidate]
        [WebApiException]
        public ResultJson UpdateReply(EditCommdityRequest request)
        {
            #region 检测有无临时图片
            if (request.ShowImage.Contains("temp"))
            {
                FileHelper.Instance.Move(HttpContext.Current.Server.MapPath(request.ShowImage), HttpContext.Current.Server.MapPath($"/current/images/Commodity/" + request.ShowImage.Split('/').Last()), HttpContext.Current.Server.MapPath($"/current/images/Commodity"));
                request.ShowImage = $"/current/images/Commodity/" + request.ShowImage.Split('/').Last();
            }
            if (request.FrontView.Contains("temp"))
            {
                FileHelper.Instance.Move(HttpContext.Current.Server.MapPath(request.FrontView), HttpContext.Current.Server.MapPath($"/current/images/Commodity/" + request.FrontView.Split('/').Last()), HttpContext.Current.Server.MapPath($"/current/images/Commodity"));
                request.FrontView = $"/current/images/Commodity/" + request.FrontView.Split('/').Last();
            }
            if (request.BackView.Contains("temp"))
            {
                FileHelper.Instance.Move(HttpContext.Current.Server.MapPath(request.BackView), HttpContext.Current.Server.MapPath($"/current/images/Commodity/" + request.BackView.Split('/').Last()), HttpContext.Current.Server.MapPath($"/current/images/Commodity"));
                request.BackView = $"/current/images/Commodity/" + request.BackView.Split('/').Last();
            }
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
            Commodity commodity = new Commodity
            {
                Id = request.CommId,
                BackView = request.BackView,
                Color = request.ColorIds,
                Content = request.content,
                FrontView = request.FrontView,
                GradeId = request.GradeId,
                Image = request.ShowImage,
                ImageList = request.ImgList,
                Introduce = request.Introduce,
                Name = request.CommName,
                IsRelease = request.Release == "on" ? true : false,
                Points = request.PriceList
            };
            if (CommodityFunc.Instance.InsertCommodity(commodity))
            {
                return new ResultJson { HttpCode = 200, Message = "更新成功！" };
            }
            else
            {
                return new ResultJson { HttpCode = 400, Message = "更新失败，请再次尝试！" };
            }
            return null;
        }

    }
}