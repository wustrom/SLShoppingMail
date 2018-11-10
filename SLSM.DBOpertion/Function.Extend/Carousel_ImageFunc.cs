using Aliyun.Acs.Dysmsapi.Model.V20170525;
using AliyunHelper.SendMail;
using Common;
using Common.Extend;
using Common.Helper;
using DbOpertion.Models;
using DbOpertion.Operation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace DbOpertion.Function
{
    /// <summary>
    /// 轮播图方法
    /// </summary>
    public partial class Carousel_ImageFunc : SingleTon<Carousel_ImageFunc>
    {
        /// <summary>
        /// 筛选图片
        /// </summary>
        /// <param name="Start">开始数据条数</param>
        /// <param name="PageSize">页面大小</param>
        /// <returns></returns>
        public List<Carousel_Image> SelectTopImages(int Start, int PageSize)
        {
            return Carousel_ImageOper.Instance.SelectByPage("OrderId", Start, PageSize, true, new Carousel_Image { IsCarousel = true, IsPC = true });
        }

        /// <summary>
        /// 筛选图片
        /// </summary>
        /// <param name="Start">开始数据条数</param>
        /// <param name="PageSize">页面大小</param>
        /// <returns></returns>
        public List<Carousel_Image> SelectTopMobileImages(int Start, int PageSize)
        {
            return Carousel_ImageOper.Instance.SelectByPage("OrderId", Start, PageSize, true, new Carousel_Image { IsCarousel = true, IsPC = false });
        }

        /// <summary>
        /// 筛选图片
        /// </summary>
        /// <param name="Start">开始数据条数</param>
        /// <param name="PageSize">页面大小</param>
        /// <returns></returns>
        public Tuple<List<Carousel_Image>, int> SelectAllImages()
        {
            return new Tuple<List<Carousel_Image>, int>(item1: Carousel_ImageOper.Instance.SelectAll(new Carousel_Image { IsCarousel = false }), item2: Carousel_ImageOper.Instance.SelectCount(new Carousel_Image { IsCarousel = false }));
        }

        /// <summary>
        /// 根据图片Id筛选图片
        /// </summary>
        /// <param name="ImageId">图片Id</param>
        /// <returns></returns>
        public Carousel_Image SelectImageById(int ImageId)
        {
            return Carousel_ImageOper.Instance.SelectById(ImageId);
        }


        /// <summary>
        /// 根据模型更新(若没有就插入)
        /// </summary>
        /// <param name="model">模型</param>
        /// <returns></returns>
        public bool UpdateImage(Carousel_Image model)
        {
            if (!model.Image.Contains("current/images/TitlePage/"))
            {
                ImageUploadHelper.Instance.GetPicThumbnail(HttpContext.Current.Server.MapPath(model.Image), HttpContext.Current.Server.MapPath($"/current/images/TitlePage/" + model.Image.Split('/').Last()), 500, 80);
                model.Image = $"/current/images/TitlePage/" + model.Image.Split('/').Last();
            }

            var Image = Carousel_ImageOper.Instance.SelectAll(new Carousel_Image { Id = model.Id, IsCarousel = model.IsCarousel }).FirstOrDefault();
            if (Image != null && model.Id != 0)
            {
                if (Image.Image != model.Image)
                {
                    FileHelper.Instance.DelectFile(Image.Image);
                }
                model.Id = Image.Id;
                return Carousel_ImageOper.Instance.Update(model);
            }
            else
            {

                return Carousel_ImageOper.Instance.Insert(model);
            }

        }

        /// <summary>
        /// 根据Id删除
        /// </summary>
        /// <param name="Id">轮播图Id</param>
        /// <returns></returns>
        public bool DeleteImage(int Id)
        {
            return Carousel_ImageOper.Instance.DeleteById(Id);
        }
    }
}
