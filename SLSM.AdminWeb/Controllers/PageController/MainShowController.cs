using Common.Extend;
using DbOpertion.Function;
using DbOpertion.Models;
using SLSM.AdminWeb.Common.BaseController;
using SLSM.AdminWeb.Model.Request.MainShow;
using SLSM.DBOpertion.Function;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SLSM.AdminWeb.Controllers.PageController
{
    /// <summary>
    /// 商城展示页面
    /// </summary>
    public class MainShowController : BaseMvcMasterController
    {
        #region 轮播图详情
        /// <summary>
        /// 轮播图主页
        /// </summary>
        /// <returns></returns>
        public ActionResult Carousel()
        {
            ViewBag.Images = Carousel_ImageFunc.Instance.SelectTopImages(0, 6);
            ViewBag.MobileImages = Carousel_ImageFunc.Instance.SelectByModel(new Carousel_Image { IsCarousel = true, IsPC = false });
            return View();
        }

        /// <summary>
        /// 轮播图详情
        /// </summary>
        /// <returns></returns>
        public ActionResult DetailCarousel(CarouselInfoRequest request)
        {
            ViewBag.Num = request.Num;
            ViewBag.IsPC = request.IsPC;
            if (request.CarouselId != 0)
            {
                ViewBag.Carousel = Carousel_ImageFunc.Instance.SelectImageById(request.CarouselId);
                
            }
            return View();
        }
        #endregion

        /// <summary>
        /// 分类推荐列表设置
        /// </summary>
        /// <returns></returns>
        public ActionResult GradeListSetting()
        {
            return View();
        }

        /// <summary>
        /// 产品推荐列表设置
        /// </summary>
        /// <returns></returns>
        public ActionResult CommodityListSetting()
        {
            ViewBag.Commrecommend = CommrecommendFunc.Instance.SelectByModel(null);
            ViewBag.List_Comm = CommodityFunc.Instance.GetAllCommList();
            return View();
        }

        /// <summary>
        /// 产品推荐列表设置
        /// </summary>
        /// <returns></returns>
        public ActionResult CommodityListDetail()
        {
            var CommshowId = Request.QueryString["CommrecommendId"].ParseInt();
            var OrderId = Request.QueryString["OrderId"].ParseInt();
            ViewBag.List_Comm = CommodityFunc.Instance.GetAllCommList();
            if (CommshowId != null)
            {
                ViewBag.Commrecommend = CommrecommendFunc.Instance.SelectByModel(new Commrecommend { Id = CommshowId.Value }).FirstOrDefault();
            }
            ViewBag.OrderId = OrderId;
            return View();
        }

        /// <summary>
        /// 分类设置列表
        /// </summary>
        /// <returns></returns>
        public ActionResult ShowGrade()
        {
            ViewBag.ShowGradeList = ShowgradeinfoFunc.Instance.SelectByModel(null);
            ViewBag.GradeList = GradeFunc.Instance.GetAllGradeInfo();
            return View();
        }

        /// <summary>
        /// 分类设置列表
        /// </summary>
        /// <returns></returns>
        public ActionResult ShowGradeDetail(int Id)
        {
            var showgradeinfo = ShowgradeinfoFunc.Instance.SelectByModel(new Showgradeinfo { OrderCount = Id }).FirstOrDefault();
            if (showgradeinfo == null)
            {
                showgradeinfo = new Showgradeinfo { OrderCount = Id };
            }
            ViewBag.ShowGradeInfo = showgradeinfo;
            ViewBag.GradeList = GradeFunc.Instance.GetAllGradeInfo();
            return View();
        }

        #region 在线图库
        /// <summary>
        /// 在线图库
        /// </summary>
        /// <returns></returns>
        public ActionResult OnlineGallery()
        {
            ViewBag.Images = Carousel_ImageFunc.Instance.SelectAllImages().Item1;
            return View();
        }

        /// <summary>
        /// 在线图库详情
        /// </summary>
        /// <returns></returns>
        public ActionResult OnLineDetail(CarouselInfoRequest request)
        {
            if (request.CarouselId != 0)
            {
                ViewBag.Carousel = Carousel_ImageFunc.Instance.SelectImageById(request.CarouselId);
            }
            return View();
        }
        #endregion
    }
}