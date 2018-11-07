using Common.Helper;
using Common.Result;
using DbOpertion.Function;
using DbOpertion.Models;
using SLSM.AdminWeb.Model.Request.Grade;
using SLSM.AdminWeb.Model.Request.MainShow;
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
    public class MainShowController : ApiController
    {
        #region 轮播图信息
        /// <summary>
        /// 轮播图
        /// </summary>
        /// <returns></returns>
        public ResultJson ChangeCarousel(AddCarouselRequest request)
        {
            if (Carousel_ImageFunc.Instance.UpdateImage(new Carousel_Image { AUrl = request.ImgAddress, Id = request.CarouselId, Image = request.Image, OrderID = request.OrderID, IsCarousel = true, IsPC = request.IsPC }))
            {
                return new ResultJson { HttpCode = 200, Message = "更新成功！" };
            }
            else
            {
                return new ResultJson { HttpCode = 200, Message = "更新失败！" };
            }
        }

        /// <summary>
        /// 删除轮播图
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ResultJson DeleteImage(CarouselInfoRequest request)
        {
            if (Carousel_ImageFunc.Instance.DeleteImage(request.CarouselId))
            {
                return new ResultJson { HttpCode = 200, Message = "删除成功！" };
            }
            else
            {
                return new ResultJson { HttpCode = 200, Message = "删除失败！" };
            }
        }

        /// <summary>
        /// 轮播图
        /// </summary>
        /// <returns></returns>
        public ResultJson ChangeOnlineGallery(AddCarouselRequest request)
        {
            if (Carousel_ImageFunc.Instance.UpdateImage(new Carousel_Image { Id = request.CarouselId, Image = request.Image, IsCarousel = false }))
            {
                return new ResultJson { HttpCode = 200, Message = "更新成功！" };
            }
            else
            {
                return new ResultJson { HttpCode = 200, Message = "更新失败！" };
            }
        }
        #endregion

        #region 首页分类
        /// <summary>
        /// 修改首页分类
        /// </summary>
        /// <returns></returns>
        public ResultJson EditGradeInfo(EditGradeRequest request)
        {
            var Showgrade = ShowgradeinfoFunc.Instance.SelectByModel(new Showgradeinfo { OrderCount = request.OrderId });
            if (Showgrade.Count >= 1)
            {
                ShowgradeinfoFunc.Instance.DeleteModel(new Showgradeinfo { OrderCount = request.OrderId });
            }
            if (ShowgradeinfoFunc.Instance.Insert(new Showgradeinfo { GradeId = request.GradeId, OrderCount = request.OrderId }))
            {
                return new ResultJson { HttpCode = 200, Message = "更新成功！" };
            }
            else
            {
                return new ResultJson { HttpCode = 300, Message = "更新失败！" };
            }
        }

        /// <summary>
        /// 删除首页分类
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ResultJson DeleteGradeInfo(EditGradeRequest request)
        {
            if (ShowgradeinfoFunc.Instance.DeleteModel(new Showgradeinfo { OrderCount = request.OrderId }))
            {
                return new ResultJson { HttpCode = 200, Message = "删除成功！" };
            }
            else
            {
                return new ResultJson { HttpCode = 300, Message = "删除失败！" };
            }
        }
        #endregion

        #region 置顶推荐
        /// <summary>
        /// 置顶分类推荐
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ResultJson SetGradeTopItem(TopItemRequest request)
        {
            if (GradeFunc.Instance.SetTopGrade(request.TopId))
            {
                return new ResultJson { HttpCode = 200, Message = "置顶成功！" };
            }
            else
            {
                return new ResultJson { HttpCode = 200, Message = "置顶失败！" };
            }
        }

        /// <summary>
        /// 置顶商品推荐
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ResultJson SetCommunityTopItem(TopItemRequest request)
        {
            if (CommodityFunc.Instance.SetTopCommodity(request.TopId))
            {
                return new ResultJson { HttpCode = 200, Message = "置顶成功！" };
            }
            else
            {
                return new ResultJson { HttpCode = 200, Message = "置顶失败！" };
            }
        }
        #endregion

        #region 分类展示商品操作
        /// <summary>
        /// 修改展示商品
        /// </summary>
        /// <returns></returns>
        public ResultJson ChangeCommRecomm(EditCommRecommRequest request)
        {
            CommrecommendFunc.Instance.DeleteModel(new Commrecommend { OrderID = request.OrderID });
            #region 删除临时图片
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
            #endregion
            if (CommrecommendFunc.Instance.Insert(new Commrecommend { OrderID = request.OrderID, FrontImage = request.FrontView, BehindImage = request.BackView, CommId = request.CommId, AttrSpan = request.Attr1 + "|" + request.Attr2 + "|" + request.Attr3 }))
            {
                return new ResultJson { HttpCode = 200, Message = "更新成功！" };
            }
            else
            {
                return new ResultJson { HttpCode = 200, Message = "更新失败！" };
            }

        }

        /// <summary>
        /// 删除展示商品
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ResultJson DeleteCommRecomm(CommRecommRequest request)
        {
            if (CommrecommendFunc.Instance.DeleteModel(new Commrecommend { OrderID = request.OrderId }))
            {
                return new ResultJson { HttpCode = 200, Message = "删除成功！" };
            }
            else
            {
                return new ResultJson { HttpCode = 200, Message = "删除失败！" };
            }
        }
        #endregion
    }
}