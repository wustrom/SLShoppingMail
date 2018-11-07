using Common.Extend;
using Common.Filter.WebApi;
using Common.Helper;
using Common.Result;
using DbOpertion.Function;
using DbOpertion.Models;
using DbOpertion.Operation;
using SLSM.AdminWeb.Model.Request.Grade;
using SLSM.AdminWeb.Model.Request.MainShow;
using SLSM.DBOpertion.Function;
using SLSM.DBOpertion.Model.Extend.Response.GradeRes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace SLSM.AdminWeb.Controllers.AjaxController
{

    public class GradeController : ApiController
    {
        [HttpPost]
        public LayUITableResponse<List<GradeResForWeb>> GetGrade(LayUITableRequestExtend req)
        {
            LayUITableResponse<List<GradeResForWeb>> response = new LayUITableResponse<List<GradeResForWeb>>();
            var ids = req.ids ?? new List<int>();
            response.list = GradeFunc.Instance.GetAllGradeForAdmin(ids);
            response.count = GradeFunc.Instance.SelectAllGradeCount();
            response.rel = true;
            response.msg = "成功";
            return response;
        }

        /// <summary>
        /// 获得场景列表
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        [HttpPost]
        public LayUITableResponse<List<GradeResForWeb>> GetScene(LayUITableRequestExtend req)
        {
            LayUITableResponse<List<GradeResForWeb>> response = new LayUITableResponse<List<GradeResForWeb>>();
            var ids = req.ids ?? new List<int>();
            response.list = GradeFunc.Instance.GetAllSceneForAdmin(ids);
            response.count = GradeFunc.Instance.SelectAllSceneCount();
            response.rel = true;
            response.msg = "成功";
            return response;
        }

        /// <summary>
        /// 新增分类
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        [WebApiException]
        public ResultJson Add(AllReq req)
        {
            ResultJson r = new ResultJson();
            r.HttpCode = 200;
            var gradeImg = req.gradeImg;
            var gradeName = req.gradeName;
            var fatherName = req.fatherName;
            var fatherId = req.fatherId;
            var gradeId = 0;
            var imgName = "";

            #region 添加方法
            if (!gradeImg.IsNullOrEmpty())
                imgName = gradeImg.Substring(gradeImg.LastIndexOf('/') + 1);
            var BigImgName = "";
            if (!req.gradeBigImg.IsNullOrEmpty())
                BigImgName = req.gradeBigImg.Substring(req.gradeBigImg.LastIndexOf('/') + 1);
            Grade grade = new Grade
            {
                Id = gradeId,
                Name = req.gradeName,
                Image = req.gradeImg.IsNullOrEmpty() ? null : $"/current/images/grade/{imgName}",
                BigImage = req.gradeBigImg.IsNullOrEmpty() ? null : $"/current/images/grade/{BigImgName}",
            };
            if (fatherId.IsNullOrEmpty())//添加一级分类
            {
                Grade g = new Grade();
                g.Name = gradeName;
                g.BigImage = grade.BigImage;
                g.IsScene = req.IsScence;
                if (!gradeImg.IsNullOrEmpty())
                    g.Image = $"/current/images/grade/{imgName}";
                gradeId = GradeFunc.Instance.Add(g);

            }
            //有父分类的情况
            else
            {
                Grade g = new Grade();
                g.Name = gradeName;
                g.BigImage = grade.BigImage;
                g.ParentId = Convert.ToInt32(fatherId);
                g.IsScene = req.IsScence;
                if (!gradeImg.IsNullOrEmpty())
                    g.Image = $"/current/images/grade/{imgName}";
                gradeId = GradeFunc.Instance.Add(g);
            }
            #endregion
            #region 分类更新
            grade = GradeFunc.Instance.SelectById(gradeId);
            var CommdityList = CommodityFunc.Instance.GetAllCommList();
            var CommdityIds = req.CommdityList != null ? req.CommdityList.Split('|').Where(p => !string.IsNullOrEmpty(p)).Distinct().ToList() : new List<string>();
            if (grade.IsScene == true)
            {
                var thisCommdityList = CommdityList.Where(p => p.ScenceIds != null && p.ScenceIds.Contains($",{gradeId}|")).ToList();
                #region 更新商品
                foreach (var commId in CommdityIds)
                {
                    var item = CommdityList.Where(p => p.Id.ToString() == commId).FirstOrDefault();
                    if (item.ScenceIds != null && item.ScenceIds.Contains($",{gradeId}|"))
                    {

                    }
                    else
                    {
                        var ScenceIdList = item.ScenceIds != null ? item.ScenceIds.Split('|').Where(p => !string.IsNullOrEmpty(p)).ToList() : new List<string>();
                        var ScenceItem = ScenceIdList.Where(p => p.Contains($",{gradeId}")).FirstOrDefault();
                        if (ScenceItem != null)
                        {
                            ScenceIdList.Remove(ScenceItem);
                        }
                        ScenceIdList.Add($"{grade.Name},{grade.Id}");
                        var ScenceIds = "|";
                        foreach (var ScenceId in ScenceIdList)
                        {
                            ScenceIds = $"{ScenceIds}{ScenceId}|";
                        }
                        CommodityFunc.Instance.Update(new Commodity { Id = item.Id, ScenceIds = ScenceIds });
                    }
                }
                foreach (var item in thisCommdityList)
                {
                    if (!CommdityIds.Contains(item.Id.ToString()))
                    {
                        var ScenceIdList = item.ScenceIds != null ? item.ScenceIds.Split('|').Where(p => !string.IsNullOrEmpty(p)).ToList() : new List<string>();
                        var ScenceItem = ScenceIdList.Where(p => p.Contains($",{req.gradeId}")).FirstOrDefault();
                        if (ScenceItem != null)
                        {
                            ScenceIdList.Remove(ScenceItem);
                        }
                        var ScenceIds = "|";
                        foreach (var ScenceId in ScenceIdList)
                        {
                            ScenceIds = $"{ScenceIds}{ScenceId}|";
                        }
                        CommodityFunc.Instance.Update(new Commodity { Id = item.Id, ScenceIds = ScenceIds });
                    }
                }
                #endregion
            }
            else
            {
                var thisCommdityList = CommdityList.Where(p => p.GradeId != null && p.GradeId.ToString() == req.gradeId).ToList();
                #region 更新商品
                foreach (var commId in CommdityIds)
                {
                    var item = CommdityList.Where(p => p.Id.ToString() == commId).FirstOrDefault();
                    if (item.GradeId != grade.Id)
                    {
                        CommodityFunc.Instance.Update(new Commodity { Id = item.Id, GradeId = grade.Id });
                        if (item.MaterialId != null)
                        {
                            Raw_MaterialsFunc.Instance.Update(new Raw_Materials { Id = item.MaterialId.Value, Genera = grade.Id.ToString() });
                        }
                    }
                }
                foreach (var item in thisCommdityList)
                {
                    if (!CommdityIds.Contains(item.Id.ToString()))
                    {
                        CommodityFunc.Instance.Update(new Commodity { Id = item.Id, GradeId = 0 });
                        if (item.MaterialId != null)
                        {
                            Raw_MaterialsFunc.Instance.Update(new Raw_Materials { Id = item.MaterialId.Value, Genera = "0" });
                        }
                    }
                }
                #endregion
            }
            CommodityFunc.Instance.ReGetAllCommList();
            #endregion
            #region MyRegion
            if (!req.gradeImg.IsNullOrEmpty())
            {
                CopyFile(imgName, req.gradeImg);
            }

            if (!req.gradeBigImg.IsNullOrEmpty())
            {
                var targetUrl = HttpContext.Current.Server.MapPath($"/current/images/grade/{BigImgName}");
                var sourceUrl = HttpContext.Current.Server.MapPath(req.gradeBigImg);
                if (targetUrl != sourceUrl)
                {
                    ImageUploadHelper.Instance.GetPicThumbnail(sourceUrl, targetUrl, 400, 80);
                }
            }


            #endregion

            GradeFunc.Instance.ResetCache();
            return r;
        }

        /// <summary>
        /// 更新分类
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        [WebApiException]
        public ResultJson Update(AllReq req)
        {
            ResultJson r = new ResultJson();
            r.HttpCode = 200;
            var gradeId = Convert.ToInt32(req.gradeId);
            var fatherId = req.fatherId;
            var gradeView = GradeFunc.Instance.SelectByModel(new Grade { Id = gradeId }).FirstOrDefault();
            var oldImg = gradeView.Image;
            var oldBigImg = gradeView.BigImage;
            var imgName = "";
            if (!req.gradeImg.IsNullOrEmpty())
                imgName = req.gradeImg.Substring(req.gradeImg.LastIndexOf('/') + 1);
            var BigImgName = "";
            if (!req.gradeBigImg.IsNullOrEmpty())
                BigImgName = req.gradeBigImg.Substring(req.gradeBigImg.LastIndexOf('/') + 1);

            #region 更新分类
            Grade grade = new Grade
            {
                Id = gradeId,
                Name = req.gradeName,
                Image = req.gradeImg.IsNullOrEmpty() ? null : $"/current/images/grade/{imgName}",
                BigImage = req.gradeBigImg.IsNullOrEmpty() ? null : $"/current/images/grade/{BigImgName}",
            };
            if (fatherId.IsNullOrEmpty())
            {
                GradeFunc.Instance.Update(grade);
            }
            else
            {
                grade.ParentId = Convert.ToInt32(fatherId);
                GradeFunc.Instance.Update(grade);
            }
            #region 分类更新
            grade = GradeFunc.Instance.SelectById(gradeId);
            var CommdityList = CommodityFunc.Instance.GetAllCommList();
            var CommdityIds = req.CommdityList != null ? req.CommdityList.Split('|').Where(p => !string.IsNullOrEmpty(p)).Distinct().ToList() : new List<string>();
            if (grade.IsScene == true)
            {
                var thisCommdityList = CommdityList.Where(p => p.ScenceIds != null && p.ScenceIds.Contains($",{gradeId}|")).ToList();
                #region 更新商品
                foreach (var commId in CommdityIds)
                {
                    var item = CommdityList.Where(p => p.Id.ToString() == commId).FirstOrDefault();
                    if (item.ScenceIds != null && item.ScenceIds.Contains($",{gradeId}|"))
                    {

                    }
                    else
                    {
                        var ScenceIdList = item.ScenceIds != null ? item.ScenceIds.Split('|').Where(p => !string.IsNullOrEmpty(p)).ToList() : new List<string>();
                        var ScenceItem = ScenceIdList.Where(p => p.Contains($",{gradeId}")).FirstOrDefault();
                        if (ScenceItem != null)
                        {
                            ScenceIdList.Remove(ScenceItem);
                        }
                        ScenceIdList.Add($"{grade.Name},{grade.Id}");
                        var ScenceIds = "|";
                        foreach (var ScenceId in ScenceIdList)
                        {
                            ScenceIds = $"{ScenceIds}{ScenceId}|";
                        }
                        CommodityFunc.Instance.Update(new Commodity { Id = item.Id, ScenceIds = ScenceIds });
                    }
                }
                foreach (var item in thisCommdityList)
                {
                    if (!CommdityIds.Contains(item.Id.ToString()))
                    {
                        var ScenceIdList = item.ScenceIds != null ? item.ScenceIds.Split('|').Where(p => !string.IsNullOrEmpty(p)).ToList() : new List<string>();
                        var ScenceItem = ScenceIdList.Where(p => p.Contains($",{req.gradeId}")).FirstOrDefault();
                        if (ScenceItem != null)
                        {
                            ScenceIdList.Remove(ScenceItem);
                        }
                        var ScenceIds = "|";
                        foreach (var ScenceId in ScenceIdList)
                        {
                            ScenceIds = $"{ScenceIds}{ScenceId}|";
                        }
                        CommodityFunc.Instance.Update(new Commodity { Id = item.Id, ScenceIds = ScenceIds });
                    }
                }
                #endregion
            }
            else
            {
                var thisCommdityList = CommdityList.Where(p => p.GradeId != null && p.GradeId.ToString() == req.gradeId).ToList();
                #region 更新商品
                foreach (var commId in CommdityIds)
                {
                    var item = CommdityList.Where(p => p.Id.ToString() == commId).FirstOrDefault();
                    if (item.GradeId != grade.Id)
                    {
                        CommodityFunc.Instance.Update(new Commodity { Id = item.Id, GradeId = grade.Id });
                        if (item.MaterialId != null)
                        {
                            Raw_MaterialsFunc.Instance.Update(new Raw_Materials { Id = item.MaterialId.Value, Genera = grade.Id.ToString() });
                        }
                    }
                }
                foreach (var item in thisCommdityList)
                {
                    if (!CommdityIds.Contains(item.Id.ToString()))
                    {
                        CommodityFunc.Instance.Update(new Commodity { Id = item.Id, GradeId = 0 });
                        if (item.MaterialId != null)
                        {
                            Raw_MaterialsFunc.Instance.Update(new Raw_Materials { Id = item.MaterialId.Value, Genera = "0" });
                        }
                    }
                }
                #endregion
            }
            CommodityFunc.Instance.ReGetAllCommList();
            #endregion
            
            #endregion

            #region 图片移动
            if (!req.gradeImg.IsNullOrEmpty())
            {
                CopyFile(imgName, req.gradeImg);
            }

            if (!req.gradeBigImg.IsNullOrEmpty())
            {
                var targetUrl = HttpContext.Current.Server.MapPath($"/current/images/grade/{BigImgName}");
                var sourceUrl = HttpContext.Current.Server.MapPath(req.gradeBigImg);
                if (targetUrl != sourceUrl)
                {
                    ImageUploadHelper.Instance.GetPicThumbnail(sourceUrl, targetUrl, 400, 80);
                }

            }
            #endregion
            GradeFunc.Instance.ResetCache();
            return r;
        }

        /// <summary>
        /// 移动文件
        /// </summary>
        /// <param name="FileName">文件名</param>
        /// <param name="OlderFile">文件路径</param>
        private void CopyFile(string FileName, string OlderFile)
        {
            var targetUrl = HttpContext.Current.Server.MapPath($"/current/images/grade/{FileName}");
            var sourceUrl = HttpContext.Current.Server.MapPath(OlderFile);
            if (sourceUrl != targetUrl)
            {
                if (!Directory.Exists(targetUrl.Replace(targetUrl.Split('\\').LastOrDefault(), "")))
                {
                    Directory.CreateDirectory(targetUrl.Replace(targetUrl.Split('\\').LastOrDefault(), ""));
                }
                if (!File.Exists(targetUrl) && File.Exists(sourceUrl))
                    File.Copy(sourceUrl, targetUrl);
                if (!OlderFile.IsNullOrEmpty())
                    File.Delete(sourceUrl);
            }
        }

        /// <summary>
        /// 删除分类（软）.图片彻底删除
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        [HttpPost]
        [WebApiException]
        public ResultJson Delete(AllReq req)
        {
            ResultJson r = new ResultJson();
            r.HttpCode = 200;
            var gradeId = Convert.ToInt32(req.gradeId);
            var listImgs = GradeFunc.Instance.Update(new Grade { Id = gradeId, IsDelete = true });
            return r;
        }


        #region 分类展示商品操作
        /// <summary>
        /// 修改展示商品
        /// </summary>
        /// <returns></returns>
        public ResultJson ChangeShowComm(EditShowCommRequest request)
        {
            CommshowOper.Instance.DeleteModel(new Commshow { GradeId = request.GradeId, OrderId = request.OrderID });
            if (CommshowOper.Instance.Insert(new Commshow { CommId = request.CommId, GradeId = request.GradeId, OrderId = request.OrderID }))
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
        public ResultJson DeleteImage(ShowCommRequest request)
        {
            if (CommshowOper.Instance.DeleteModel(new Commshow { Id = request.Id }))
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

    public class GradeInfo
    {
        public GradeInfo(Grade g)
        {
            Id = g.Id.ToString();
            Name = g.Name;
            Img = g.Image ?? "";
            GradeAttr = g.GradeAttrName ?? "";
        }

        public GradeInfo(Gradefindparent g)
        {
            Id = g.id.ToString();
            Name = g.gradeName;
            Img = g.gradeImage ?? "";
            GradeAttr = g.GradeAttrName ?? "";
            if (g.parentId != null)
                parentId = g.parentId.ToString();
            else
                parentId = "0";
            parentName = g.parentName ?? "";
        }
        /// <summary>
        /// 分类Id
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// 分类名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 分类图片
        /// </summary>
        public string Img { get; set; }
        /// <summary>
        /// 分类属性
        /// </summary>
        public string GradeAttr { get; set; }
        /// <summary>
        /// 父节点Id
        /// </summary>
        public string parentId { get; set; }
        /// <summary>
        /// 父节点名称
        /// </summary>
        public string parentName { get; set; }
    }
}
