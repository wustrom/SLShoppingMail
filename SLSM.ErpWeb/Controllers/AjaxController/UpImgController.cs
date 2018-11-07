using Common.Filter.WebApi;
using Common.Helper;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace SLSM.ErpWeb.Controllers.AjaxController
{
    public class UpImgController : BaseApiController
    {
        /// <summary>
        /// 后台路径
        /// </summary>
        string AdminUrl = System.Configuration.ConfigurationManager.AppSettings["AdminUrl"];
        /// <summary>
        /// 后台路径
        /// </summary>
        string FileUrl = System.Configuration.ConfigurationManager.AppSettings["FileUrl"];
        /// <summary>
        /// 上传图片
        /// </summary>
        /// <returns>图片路径</returns>
        [HttpPost]
        public string UpImg()
        {
            var httpFile = HttpContext.Current.Request.Files;
            if (HttpContext.Current.Request.Files.Count == 0)
            {
                return null;
            }
            string fileName = httpFile[0].FileName;
            string newext = fileName.Substring(fileName.LastIndexOf("."));
            string url = "/current/images/temp/" + RandHelper.Instance.Str(6) + DateTime.Now.ToString("yyyyMMddHHmmss") + newext;
            ImageUploadHelper.Instance.YaSuo((Bitmap)Image.FromStream(httpFile[0].InputStream), FileUrl + url, 80);
            return AdminUrl + url;
        }


        /// <summary>
        /// 上传图片
        /// </summary>
        /// <returns>图片路径</returns>
        [HttpPost]
        public string UpZiper()
        {
            var httpFile = HttpContext.Current.Request.Files;
            string fileName = httpFile[0].FileName;
            string newext = fileName.Substring(fileName.LastIndexOf("."));
            string url = "/current/UpZiper/temp/" + RandHelper.Instance.Str(6) + DateTime.Now.ToString("yyyyMMddHHmmss") + newext;
            FileHelper.Instance.checkDir(FileUrl + "/current/UpZiper/temp");
            httpFile[0].SaveAs(FileUrl + url);
            return AdminUrl + url;
        }
    }
}
