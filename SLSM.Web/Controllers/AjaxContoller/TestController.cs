using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SLSM.Web.Models.Resquest.Test;
using Common.Helper;
using System.Web;
using System.IO;
using System.Data;
using SLSM.DBOpertion.Function;
using Common.Filter.WebApi;

namespace SLSM.Web.Controllers.AjaxContoller
{
    public class TestController : BaseApiController
    {

        [HttpPost]
        public void GetImg(Test req)
        {
            var base64 = req.img;
            //var bmp = Base64Helper.Base64ToImage(img);
            base64 = base64.Substring(base64.IndexOf(',') + 1);
            byte[] byteArray = Convert.FromBase64String(base64);
            string saveFileName = DateTime.Now.ToFileTime().ToString();
            string shortPath = $"/current/images/test2{saveFileName}.jpg";
            string path = HttpContext.Current.Server.MapPath(shortPath);
            Stream s = new FileStream(path, FileMode.Append);
            s.Write(byteArray, 0, byteArray.Length);

            s.Close();
        }
    }
}
