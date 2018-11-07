using Common.Extend;
using DbOpertion.Function;
using DbOpertion.Models;
using log4net;
using SLSM.AdminWeb.Common.BaseController;
using SLSM.AdminWeb.Model.Request.Grade;
using SLSM.DBOpertion.Function;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace SLSM.AdminWeb.Controllers.PageController
{
    public class GradeController : BaseMvcMasterController
    {
        #region 分类
        // GET: Grade
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 详情页面
        /// </summary>
        /// <param name="req">请求</param>
        /// <returns></returns>
        public ActionResult Detail(AllReq req)
        {
            if (req.gradeId == null)
            {
                var fatherId = req.fatherId;
                var fatherName = req.fatherName;
                ViewBag.req = new GradeDetailReq(fatherId, fatherName);
                ViewBag.attrs = new List<string>();

            }
            else
            {
                var gradeId = Convert.ToInt32(req.gradeId);
                var gradeView = GradeFunc.Instance.GetGradefpById(gradeId);
                ViewBag.attrs = GradeFunc.Instance.GetAttrs(gradeId);
                ViewBag.req = new GradeDetailReq(gradeView);
            }
            var CommdityList = CommodityFunc.Instance.GetAllCommList();
            var thisCommdityList = new List<Commodity_Stageprice_View>();
            ViewBag.CommdityList = CommdityList;
            ViewBag.thisCommdityList = thisCommdityList;
            ViewBag.IsScence = req.IsScence;
            if (req.IsScence == true)
            {
                thisCommdityList = CommdityList.Where(p => p.ScenceIds != null && p.ScenceIds.Contains($",{req.gradeId}|")).ToList();
            }
            else
            {
                thisCommdityList = CommdityList.Where(p => p.GradeId != null && p.GradeId.ToString() == req.gradeId).ToList();
            }
            ViewBag.thisCommdityList = thisCommdityList;
            return View();
        }
        # endregion

        #region 商品设置页面
        /// <summary>
        /// 展示商品设置页面
        /// </summary>
        /// <param name="req">请求</param>
        /// <returns></returns>
        public ActionResult GradeShow()
        {
            var GradeId = Request.QueryString["GradeId"].ParseInt();
            var gradeList = GradeFunc.Instance.GetAllGrade();
            var gradeLevel1 = gradeList.Where(p => p.id == GradeId).FirstOrDefault();
            if (gradeLevel1 == null)
            {
                ViewBag.Type = false;
            }
            else
            {
                ViewBag.Type = true;
            }
            if (GradeId != null)
            {
                ViewBag.List_Show = CommshowFunc.Instance.SelectByModel(new DbOpertion.Models.Commshow { GradeId = GradeId });
                ViewBag.List_Comm = CommodityFunc.Instance.GetAllCommList();
            }
            ViewBag.GradeId = GradeId;
            return View();
        }

        /// <summary>
        /// 展示商品设置详情页面
        /// </summary>
        /// <param name="req">请求</param>
        /// <returns></returns>
        public ActionResult GradeShowDetail()
        {
            var GradeId = Request.QueryString["GradeId"].ParseInt();
            var CommshowId = Request.QueryString["CommshowId"].ParseInt();
            var OrderId = Request.QueryString["OrderId"].ParseInt();
            if (GradeId != null)
            {
                ViewBag.List_Show = CommshowFunc.Instance.SelectByModel(new DbOpertion.Models.Commshow { GradeId = GradeId });
                List<Commodity_Stageprice_View> result_list = new List<Commodity_Stageprice_View>();
                var List_Comm = CommodityFunc.Instance.GetAllCommList();
                #region 分类商品列表添加
                #region 一级添加
                var gradeList = GradeFunc.Instance.GetAllGrade();
                var gradeLevel1 = gradeList.Where(p => p.id == GradeId).FirstOrDefault();
                result_list.Add(List_Comm.Where(p => p.GradeId == GradeId).ToList());
                if (gradeLevel1 == null)
                {
                    List_Comm = List_Comm.Where(p => p.ScenceIds != null).ToList();
                    gradeList = GradeFunc.Instance.GetAllScene();
                    gradeLevel1 = gradeList.Where(p => p.id == GradeId).FirstOrDefault();
                    result_list.Add(List_Comm.Where(p => p.ScenceIds.Contains("," + GradeId + "|")).ToList());
                    #region 二级添加
                    foreach (var item_Level1 in gradeLevel1.listGrade)
                    {
                        var list = List_Comm.Where(p => p.ScenceIds.Contains("," + item_Level1.id + "|")).ToList();
                        result_list.Add(list);
                        #region 三级添加
                        foreach (var item_Level2 in item_Level1.listGrade)
                        {
                            list = List_Comm.Where(p => p.ScenceIds.Contains("," + item_Level2.id + "|")).ToList();
                            result_list.Add(list);
                        }
                        #endregion
                    }
                    #endregion
                }
                else
                {
                    #region 二级添加
                    foreach (var item_Level1 in gradeLevel1.listGrade)
                    {
                        var list = List_Comm.Where(p => p.GradeId == item_Level1.id).ToList();
                        result_list.Add(list);
                        #region 三级添加
                        foreach (var item_Level2 in item_Level1.listGrade)
                        {
                            list = List_Comm.Where(p => p.GradeId == item_Level2.id).ToList();
                            result_list.Add(list);
                        }
                        #endregion
                    }
                    #endregion
                }
                #endregion

                #endregion
                ViewBag.List_Comm = result_list;
            }
            if (CommshowId != null)
            {
                ViewBag.CommShow = CommshowFunc.Instance.SelectByModel(new Commshow { Id = CommshowId.Value }).FirstOrDefault();
            }
            ViewBag.GradeId = GradeId;
            ViewBag.OrderId = OrderId;
            return View();
        }
        #endregion

        #region 分类
        // GET: Grade
        public ActionResult Scene()
        {
            return View();
        }
        # endregion

    }
}