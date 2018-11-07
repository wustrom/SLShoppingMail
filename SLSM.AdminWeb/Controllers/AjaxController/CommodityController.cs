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
using Common.Extend;
using DbOpertion.Function;
using System.Web;

namespace SLSM.AdminWeb.Controllers.AjaxController
{
    public class CommodityController : ApiController
    {
        /// <summary>
        /// 更新商品
        /// </summary>
        /// <param name="request">请求</param>
        /// <returns></returns>
        [HttpPost]
        [WebApiModelValidate]
        [WebApiException]
        public ResultJson UpdateComm(EditCommdityRequest request)
        {
            #region 若有原材料ID
            var MaterialId = request.MaterialId.ParseInt();
            var MaterialColorInfo = "";
            var MaterialColorList = "";
            if (MaterialId != null)
            {
                var Material = Raw_MaterialsFunc.Instance.SelectById(MaterialId.Value);
                if (Material != null)
                {
                    #region 重设价格列表
                    request.PriceList = "";
                    var saleInfoList = Material.SalesInfoList.Split(';').Where(p => !string.IsNullOrEmpty(p)).ToList();
                    foreach (var item in saleInfoList)
                    {
                        var saleInfoDetail = item.Split('|').Where(p => !string.IsNullOrEmpty(p)).ToList();
                        request.PriceList = request.PriceList + "|" + saleInfoDetail[1] + "," + saleInfoDetail[0] + "," + saleInfoDetail[2];
                    }
                    #endregion

                    #region 设置颜色图片
                    var colorInfoList = ColorinfoFunc.Instance.GetColorListBase();
                    var Material_ColorList = Materials_ColorinfoFunc.Instance.SelectByModel(new Materials_Colorinfo { MaterialsId = Material.Id });
                    foreach (var item in Material_ColorList)
                    {
                        var thisColorInfo = colorInfoList.Where(p => p.Id == item.ColorId).FirstOrDefault();
                        if (thisColorInfo != null)
                        {
                            MaterialColorInfo = MaterialColorInfo + $"{item.ColorId};{item.SKUImage}|";
                            MaterialColorList = MaterialColorList + thisColorInfo.Id + ",";
                        }
                    }
                    #endregion

                    #region 设置位置
                    request.Position = "";
                    foreach (var item in Material_ColorList)
                    {
                        request.Position = $"{request.Position}{item.ColorId}({item.PositionInfo})";
                    }
                    #endregion
                    request.GradeId = Material.Genera.ParseInt().Value;
                }
            }
            #endregion

            #region 初始判断
            var price = request.CommPrice.ParseDouble();
            if (price == null || price <= 0)
            {
                return new ResultJson { HttpCode = 300, Message = "价格不正确！" };
            }
            if (request.ImgList == null && MaterialColorInfo == "")
            {
                return new ResultJson { HttpCode = 300, Message = "至少有一张图片！" };
            }
            else if (request.ImgList == null)
            {
                request.ImgList = "";
            }
            if (request.ColorIds == null && MaterialColorList == "")
            {
                return new ResultJson { HttpCode = 300, Message = "至少有一个颜色！" };
            }
            else if (request.ColorIds == null)
            {
                request.ImgList = "";
            }
            #endregion

            #region 价格判断
            if (request.PriceList == null)
            {
                request.PriceList = "";
            }
            #endregion

            #region 检测有无临时图片
            if (request.ShowImage.Contains("temp"))
            {
                FileHelper.Instance.Move(HttpContext.Current.Server.MapPath(request.ShowImage), HttpContext.Current.Server.MapPath($"/current/images/Commodity/" + request.ShowImage.Split('/').Last()), HttpContext.Current.Server.MapPath($"/current/images/Commodity"));
                request.ShowImage = $"/current/images/Commodity/" + request.ShowImage.Split('/').Last();
            }
            var FrontViewArray = request.FrontView.Split('|').Where(p => !string.IsNullOrEmpty(p)).ToList();
            request.FrontView = "";
            foreach (var item in FrontViewArray)
            {
                if (item.Contains("temp"))
                {
                    FileHelper.Instance.Move(HttpContext.Current.Server.MapPath(item), HttpContext.Current.Server.MapPath($"/current/images/Commodity/" + item.Split('/').Last()), HttpContext.Current.Server.MapPath($"/current/images/Commodity"));
                    request.FrontView = request.FrontView + $"/current/images/Commodity/" + item.Split('/').Last() + "|";
                }
                else
                {
                    request.FrontView = request.FrontView + item + "|";
                }
            }
            if (request.BackView.Contains("temp"))
            {
                FileHelper.Instance.Move(HttpContext.Current.Server.MapPath(request.BackView), HttpContext.Current.Server.MapPath($"/current/images/Commodity/" + request.BackView.Split('/').Last()), HttpContext.Current.Server.MapPath($"/current/images/Commodity"));
                request.BackView = $"/current/images/Commodity/" + request.BackView.Split('/').Last();
            }

            var array = request.ImgList.Split('|').Where(p => !string.IsNullOrEmpty(p)).ToList();

            var colorList = request.ColorIds.Split(',').Where(p => !string.IsNullOrEmpty(p)).ToList();
            request.ImgList = "";
            foreach (var item in array)
            {
                if (item.Contains("temp"))
                {
                    if (item.Contains(';'))
                    {
                        var color = colorList.Where(p => p == item.Split(';')[0]).FirstOrDefault();
                        if (color != null)
                        {
                            var array2 = item.Split(';')[1];
                            FileHelper.Instance.Move(HttpContext.Current.Server.MapPath(array2), HttpContext.Current.Server.MapPath($"/current/images/Commodity/" + item.Split('/').Last()), HttpContext.Current.Server.MapPath($"/current/images/Commodity"));
                            request.ImgList = request.ImgList + $"{item.Split(';')[0]};/current/images/Commodity/" + item.Split('/').Last() + "|";
                        }
                    }
                    else
                    {
                        FileHelper.Instance.Move(HttpContext.Current.Server.MapPath(item), HttpContext.Current.Server.MapPath($"/current/images/Commodity/" + item.Split('/').Last()), HttpContext.Current.Server.MapPath($"/current/images/Commodity"));
                        request.ImgList = request.ImgList + $"/current/images/Commodity/" + item.Split('/').Last() + "|";
                    }

                }
                else
                {
                    if (item.Contains(';'))
                    {
                        var color = colorList.Where(p => p == item.Split(';')[0]).FirstOrDefault();
                        if (color != null)
                        {
                            request.ImgList = request.ImgList + item + "|";
                        }
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
                Color = request.ColorIds + MaterialColorList,
                Content = request.content,
                FrontView = request.FrontView,
                GradeId = request.GradeId,
                Image = request.ShowImage,
                ImageList = request.ImgList + MaterialColorInfo,
                Introduce = request.Introduce,
                Name = request.CommName,
                IsRelease = request.Release == "on" ? true : false,
                Points = request.PriceList + "|" + request.CommPrice + ",0,0",
                ScenceIds = request.SceneIds,
                MaterialId = request.MaterialId.ParseInt(),
                PringtingPosition = request.Position,
                CommodityInfo = request.Collocations
            };
            if (CommodityFunc.Instance.InsertCommodity(commodity))
            {
                CommodityFunc.Instance.ReGetAllCommList();
                return new ResultJson { HttpCode = 200, Message = "操作成功！" };
            }
            else
            {
                return new ResultJson { HttpCode = 400, Message = "操作失败，请再次尝试！" };
            }
        }

        /// <summary>
        /// 删除商品
        /// </summary>
        /// <param name="request">请求</param>
        /// <returns></returns>
        [HttpPost]
        [WebApiModelValidate]
        [WebApiException]
        public ResultJson DeleteComm(IdRequest request)
        {
            if (CommodityFunc.Instance.DeleteCommodity(request.Id))
            {
                CommodityFunc.Instance.ReGetAllCommList();
                return new ResultJson { HttpCode = 200, Message = "删除成功！" };
            }
            else
            {
                return new ResultJson { HttpCode = 400, Message = "删除失败，请再次尝试！" };
            }
        }
    }
}