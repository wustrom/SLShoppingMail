﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web;
using Common.Helper;
using System.IO;
using Common.Result;
using SLSM.AdminWeb.Model.Request.UpImg;
using SLSM.DBOpertion.Function;
using DbOpertion.Models;
using System.Web.Http.Cors;
using Common.Extend;
using SLSM.AdminWeb.Models.Resquest.ShopCart;
using Common.Result.LayUITable;
using System.Drawing;
using DbOpertion.Function;

namespace SLSM.AdminWeb.Controllers.AjaxController
{
    public class UpImgController : ApiController
    {
        /// <summary>
        /// 后台路径
        /// </summary>
        string AdminUrl = System.Configuration.ConfigurationManager.AppSettings["AdminUrl"];
        /// <summary>
        /// 上传图片
        /// </summary>
        /// <returns>图片路径</returns>
        [HttpPost]
        public string UpImg()
        {
            var httpFile = HttpContext.Current.Request.Files;
            string fileName = httpFile[0].FileName;
            string newext = fileName.Substring(fileName.LastIndexOf("."));
            string url = "/current/images/temp/" + RandHelper.Instance.Str(6) + DateTime.Now.ToString("yyyyMMddHHmmss") + newext;
            ImageUploadHelper.Instance.YaSuo((Bitmap)Image.FromStream(httpFile[0].InputStream), HttpContext.Current.Server.MapPath(url), 60);
            return url;
        }

        public LayEditResponse LayerEdit()
        {
            var httpFile = HttpContext.Current.Request.Files;
            try
            {

                if (httpFile.Count > 0)
                {
                    string fileName = httpFile[0].FileName;
                    string newext = fileName.Substring(fileName.LastIndexOf("."));
                    FileHelper.Instance.checkDir(HttpContext.Current.Server.MapPath("/current/images/Content/"));
                    string url = "/current/images/Content/" + RandHelper.Instance.Str(6) + DateTime.Now.ToString("yyyyMMddHHmmss") + newext;
                    ImageUploadHelper.Instance.YaSuo((Bitmap)Image.FromStream(httpFile[0].InputStream), HttpContext.Current.Server.MapPath(url), 80);
                    //httpFile[0].SaveAs(HttpContext.Current.Server.MapPath(url));
                    return new LayEditResponse { code = 0, msg = "就是失败了", data = new DataClass { src = AdminUrl + url, title = "图片" } };
                }
                else
                {
                    return new LayEditResponse { code = 3, msg = "就是失败了" };
                }
            }
            catch (Exception e)
            {
                return new LayEditResponse { code = 3, msg = e.Message };
            }



        }

        #region 用户头像
        /// <summary>
        /// 上传图片
        /// </summary>
        /// <returns>图片路径</returns>
        [HttpPost]
        public ResultJson SaveUserImage(UpUserImageRequest request)
        {
            FileHelper.Instance.DelectDir(HttpContext.Current.Server.MapPath($"/current/images/User/{request.UserID}/"));
            var url = SaveImg(request.Pic, $"/current/images/User/{request.UserID}/");
            if (url == null)
            {
                return new ResultJson { HttpCode = 300, Message = "上传图片失败！" };
            }
            else
            {
                if (UserFunc.Instance.Update(new User { Image = url, Id = request.UserID }))
                {
                    return new ResultJson { HttpCode = 300, Message = "上传图片失败！" };
                }
                return new ResultJson { HttpCode = 200, Message = AdminUrl + url };
            }
        }
        #endregion

        #region 商品定制页面
        /// <summary>
        /// 上传图片
        /// </summary>
        /// <returns>图片路径</returns>
        [HttpPost]
        public ResultJson UpdateOrderCross(UpdateImgCrossRequest request)
        {
            #region 首次
            if (request.ShopCartId == 0)
            {
                var hisdesign = GetHisdesign(request.CommodityId, request.userGuid);
                var url = SaveImg(request.Pic, $"/current/images/Order/{hisdesign.Id}/");
                if (url == null)
                {
                    return new ResultJson { HttpCode = 300, Message = "上传图片失败！" };
                }
                else
                {
                    return new ResultJson { HttpCode = 200, Message = AdminUrl + url };
                }
            }
            #endregion

            #region 购物车里的
            else
            {
                var url = SaveImg(request.Pic, $"/current/images/ShopCart/{request.ShopCartId}/");
                if (url == null)
                {
                    return new ResultJson { HttpCode = 300, Message = "上传图片失败！" };
                }
                else
                {
                    return new ResultJson { HttpCode = 200, Message = AdminUrl + url };
                }
            }
            #endregion

        }

        /// <summary>
        /// 上传前部图片
        /// </summary>
        /// <returns>图片路径</returns>
        [HttpPost]
        public ResultJson UpdateForntView(UpdateImgCrossRequest request)
        {
            #region 首次
            if (request.ShopCartId == 0)
            {
                var hisdesign = GetHisdesign(request.CommodityId, request.userGuid);
                var dirFile = $"/current/images/Order/{hisdesign.Id}/Fornt/";
                FileHelper.Instance.DelectDir(HttpContext.Current.Server.MapPath(dirFile));
                var url = SaveImg(request.Pic, dirFile);
                hisdesign.ForntContent = HtmlCodeHelper.HtmlToString(request.Div);
                hisdesign.ForntView = url;
                if (url == null || !HisdesignFunc.Instance.UpdateHisdesign(hisdesign))
                {
                    return new ResultJson { HttpCode = 300, Message = "上传图片失败！" };
                }
                else
                {
                    return new ResultJson { HttpCode = 200, Message = AdminUrl + url };
                }
            }
            #endregion

            #region 购物车里的
            else
            {
                var shopCart = GetShopCart(request.ShopCartId);
                var dirFile = $"/current/images/ShopCart/{shopCart.Id}/Fornt/";
                FileHelper.Instance.DelectDir(HttpContext.Current.Server.MapPath(dirFile));
                var url = SaveImg(request.Pic, dirFile);
                shopCart.ForntContent = HtmlCodeHelper.HtmlToString(request.Div);
                shopCart.ForntView = url;
                if (url == null || !ShopCartFunc.Instance.UpdateShopCart(shopCart))
                {
                    return new ResultJson { HttpCode = 300, Message = "上传图片失败！" };
                }
                else
                {
                    return new ResultJson { HttpCode = 200, Message = AdminUrl + url };
                }
            }
            #endregion
        }

        /// <summary>
        /// 上传后部图片
        /// </summary>
        /// <returns>图片路径</returns>
        [HttpPost]
        public ResultJson UpdateBackView(UpdateImgCrossRequest request)
        {
            #region 首次的
            if (request.ShopCartId == 0)
            {
                var hisdesign = GetHisdesign(request.CommodityId, request.userGuid);
                var dirFile = $"/current/images/Order/{hisdesign.Id}/Back/";
                FileHelper.Instance.DelectDir(HttpContext.Current.Server.MapPath(dirFile));
                hisdesign.BackContent = HtmlCodeHelper.HtmlToString(request.Div);
                var url = SaveImg(request.Pic, dirFile);
                hisdesign.BackView = url;
                if (url == null || !HisdesignFunc.Instance.UpdateHisdesign(hisdesign))
                {
                    return new ResultJson { HttpCode = 300, Message = "上传图片失败！" };
                }
                else
                {
                    return new ResultJson { HttpCode = 200, Message = AdminUrl + url };
                }
            }
            #endregion

            #region 购物车里的
            else
            {
                var shopCart = GetShopCart(request.ShopCartId);
                var dirFile = $"/current/images/ShopCart/{shopCart.Id}/Back/";
                FileHelper.Instance.DelectDir(HttpContext.Current.Server.MapPath(dirFile));
                var url = SaveImg(request.Pic, dirFile);
                shopCart.BackContent = HtmlCodeHelper.HtmlToString(request.Div);
                shopCart.BackView = url;
                if (url == null || !ShopCartFunc.Instance.UpdateShopCart(shopCart))
                {
                    return new ResultJson { HttpCode = 300, Message = "上传图片失败！" };
                }
                else
                {
                    return new ResultJson { HttpCode = 200, Message = AdminUrl + url };
                }
            }
            #endregion
        }

        /// <summary>
        /// 加入购物车方法
        /// </summary>
        /// <returns></returns>
        public ResultJson AddCartFunc(UpdateCartInfoRequest request)
        {
            if (request.ShopCartId == 0)
            {
                var Hisdesign = GetHisdesign(request.CommodityId, request.userGuid);
                Shopcart shopcart = new Shopcart
                {
                    UserID = Hisdesign.UserID,
                    UserGuId = Hisdesign.UserGuid,
                    CommodityId = Hisdesign.CommodityId,
                    BackContent = Hisdesign.BackContent,
                    ForntContent = Hisdesign.ForntContent,
                    BackView = Hisdesign.BackView,
                    ForntView = Hisdesign.ForntView,
                    LastLookTime = DateTime.Now,
                    Color = request.Color,
                    PrintingMethod = request.PrintingMethod,
                    Attr = request.Attr,
                    Amount = request.Amount,
                    IsMobile = request.PayType == "moblie"
                };
                if (ShopCartFunc.Instance.InsertShopCart(shopcart))
                {
                    #region 图片复制，没用的图片删除
                    shopcart = ShopCartFunc.Instance.SelectShopCart(shopcart);
                    if (request.ListImg != null)
                    {
                        var ImgArry = request.ListImg.Split(',');
                        foreach (var item in ImgArry)
                        {
                            if (!item.IsNullOrEmpty())
                            {
                                shopcart.BackContent = shopcart.BackContent.Replace(item, $"/current/images/ShopCart/{ shopcart.Id}/" + item.Split('/').Last());
                                shopcart.ForntContent = shopcart.ForntContent.Replace(item, $"/current/images/ShopCart/{ shopcart.Id}/" + item.Split('/').Last());
                                FileHelper.Instance.Move(HttpContext.Current.Server.MapPath(item), HttpContext.Current.Server.MapPath($"/current/images/ShopCart/{ shopcart.Id}/" + item.Split('/').Last()), HttpContext.Current.Server.MapPath($"/current/images/ShopCart/{ shopcart.Id}/"));
                            }
                        }
                        if (!shopcart.BackView.IsNullOrEmpty())
                        {
                            FileHelper.Instance.Move(HttpContext.Current.Server.MapPath(shopcart.BackView), HttpContext.Current.Server.MapPath($"/current/images/ShopCart/{ shopcart.Id}/Back/" + shopcart.BackView.Split('/').Last()), HttpContext.Current.Server.MapPath($"/current/images/ShopCart/{ shopcart.Id}/Back/"));
                            shopcart.BackView = $"/current/images/ShopCart/{ shopcart.Id}/Back/" + shopcart.BackView.Split('/').Last();
                        }
                        if (!shopcart.ForntView.IsNullOrEmpty())
                        {
                            FileHelper.Instance.Move(HttpContext.Current.Server.MapPath(shopcart.ForntView), HttpContext.Current.Server.MapPath($"/current/images/ShopCart/{ shopcart.Id}/Fornt/" + shopcart.ForntView.Split('/').Last()), HttpContext.Current.Server.MapPath($"/current/images/ShopCart/{ shopcart.Id}/Fornt/"));
                            shopcart.ForntView = $"/current/images/ShopCart/{ shopcart.Id}/Fornt/" + shopcart.ForntView.Split('/').Last();
                        }
                        FileHelper.Instance.DelectDir(HttpContext.Current.Server.MapPath($"/current/images/ShopCart/{ Hisdesign.Id}/"));
                    }
                    #endregion

                    #region 更新购物车的前图与后图,删除历史设计信息
                    ShopCartFunc.Instance.UpdateShopCart(shopcart);
                    HisdesignFunc.Instance.DeleteHisdesignById(Hisdesign.Id);
                    #endregion
                    return new ResultJson { HttpCode = 200, Message = shopcart.Id.ToString() };
                }
                return new ResultJson { HttpCode = 300, Message = "插入不成功！" };
            }
            else
            {
                var shopcart = GetShopCart(request.ShopCartId);
                shopcart.Color = request.Color;
                shopcart.PrintingMethod = request.PrintingMethod;
                shopcart.Attr = request.Attr;
                shopcart.Amount = request.Amount;
                if (ShopCartFunc.Instance.UpdateShopCart(shopcart))
                {
                    #region 图片复制，没用的图片删除
                    var ImgArry = request.ListImg.Split(',').Where(p => p != "" && p != null).ToList();
                    foreach (var item in ImgArry)
                    {
                        if (!item.IsNullOrEmpty())
                        {
                            FileHelper.Instance.DelectDirWithOutList($"/current/images/ShopCart/{ shopcart.Id}/", ImgArry);
                        }
                    }
                    #endregion

                    return new ResultJson { HttpCode = 200, Message = "程序执行成功！" };
                }
                return new ResultJson { HttpCode = 300, Message = "插入不成功！" };
            }

        }
        #endregion

        #region 购物车页面
        /// <summary>
        /// 购物车价格
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ResultJson DeleteShopCart(ShopCartAmountRequest request)
        {
            ResultJson result = new ResultJson();
            if (ShopCartFunc.Instance.DeleteShopCart(request.ShopCartId))
            {
                var dirFile = $"/current/images/ShopCart/{request.ShopCartId}";
                FileHelper.Instance.DelectDir(HttpContext.Current.Server.MapPath(dirFile));
                result.HttpCode = 200;
                result.Message = "删除成功！";
            }
            else
            {
                result.HttpCode = 300;
                result.Message = "删除不成功！";
            }
            return result;
        }
        #endregion

        #region 清理过期图片
        /// <summary>
        /// 清理全部过期图片
        /// </summary>
        public ResultJson ClearAllTempImage()
        {
            var url = HttpContext.Current.Server.MapPath("/current/images/temp");
            var ClearTime = MemCacheHelper2.Instance.Cache.GetModel<DateTime?>("ClearTime");
            var flag = false;
            #region 查看是否到清理时间
            if (ClearTime != null)
            {
                if (ClearTime.Value.Day != DateTime.Now.Day)
                {
                    flag = true;
                    MemCacheHelper2.Instance.Cache.Set("ClearTime", DateTime.Now);
                }
            }
            else
            {
                MemCacheHelper2.Instance.Cache.Set("ClearTime", DateTime.Now);
                flag = true;
            }
            #endregion
            if (flag)
            {
                #region 清除临时文件夹下超过3天的图片;
                DirectoryInfo TheFolder = new DirectoryInfo(url);
                foreach (FileInfo NextFile in TheFolder.GetFiles())
                {
                    if (DateTime.Now.Subtract(NextFile.CreationTime).TotalDays > 3)
                    {
                        NextFile.Delete();
                    }
                }
                #endregion

                #region 清除超过三天历史设计的图片(没有登入的用户)
                var Listhisdesign = HisdesignFunc.Instance.GetAllHisdesignInfo();
                foreach (var item in Listhisdesign)
                {
                    var deleteFlag = false;
                    if (item.LastLookTime.Value == null)
                    {
                        deleteFlag = true;
                    }
                    else if (DateTime.Now.Subtract(item.LastLookTime.Value).TotalDays > 3 && item.UserID == null)
                    {
                        deleteFlag = true;
                    }
                    if (deleteFlag)
                    {
                        var dirFile = $"/current/images/Order/{item.Id}";
                        FileHelper.Instance.DelectDir(HttpContext.Current.Server.MapPath(dirFile));
                        HisdesignFunc.Instance.DeleteHisdesignById(item.Id);
                    }
                }
                #endregion
            }
            return new ResultJson { HttpCode = 200, Message = "删除成功！" };
        }
        #endregion

        #region 私有方法
        /// <summary>
        /// 根据用户gudi和商品ID找出用户设计信息
        /// </summary>
        /// <param name="CommodityId">商品ID</param>
        /// <param name="userGuid">用户Guid</param>
        /// <returns></returns>
        private Hisdesign GetHisdesign(int CommodityId, string userGuid)
        {
            var user = MemCacheHelper2.Instance.Cache.GetModel<User>("UserGuID_" + userGuid);
            Hisdesign hisdesign;
            if (user == null)
            {
                hisdesign = HisdesignFunc.Instance.GetHisdesignInfo(null, CommodityId, userGuid);
            }
            else
            {
                hisdesign = HisdesignFunc.Instance.GetHisdesignInfo(user.Id, CommodityId, userGuid);
            }
            return hisdesign;
        }

        /// <summary>
        /// 根据用户gudi和商品ID找出用户设计信息
        /// </summary>
        /// <param name="ShopCartId">购物车Id</param>
        /// <returns></returns>
        private Shopcart GetShopCart(int ShopCartId)
        {
            return ShopCartFunc.Instance.SelectShopCart(new Shopcart { Id = ShopCartId });
        }


        /// <summary>
        /// 根据base64编码保存图片
        /// </summary>
        /// <param name="Pic">base64编码图片</param>
        /// <param name="DicUrl">文件目录</param>
        /// <returns></returns>
        private string SaveImg(string Pic, string DicUrl)
        {
            try
            {
                if (Pic == null)
                {
                    return null;
                }
                var arrayImg = Pic.Split(',');
                string extension = null;
                extension = arrayImg[0].Split(':')[1].Split('/')[1].Split(';')[0];
                if (extension != null)
                {
                    string DicFullUrl = HttpContext.Current.Server.MapPath(DicUrl);
                    if (FileHelper.Instance.checkDir(DicFullUrl))
                    {
                        string AllUrl = DicUrl + "/" + RandHelper.Instance.Str(6) + DateTime.Now.ToString("yyyyMMddHHmmss") + "." + extension;
                        string AllFullUrl = HttpContext.Current.Server.MapPath(AllUrl);
                        ImageUploadHelper.Instance.SaveImg(arrayImg[1], AllFullUrl);
                        return AllUrl;
                    }
                }
            }
            catch (Exception)
            {
                return null;
            }
            return null;
        }
        #endregion

    }
}