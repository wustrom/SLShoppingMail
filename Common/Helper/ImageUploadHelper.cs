using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Common.Helper
{
    public class ImageUploadHelper : SingleTon<ImageUploadHelper>
    {

        /// <summary>
        /// 上传图片
        /// </summary>
        /// <param name="Content"></param>
        /// <returns></returns>
        public Dictionary<string, string> ReadAsMultipart(HttpContent Content)
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();
            string root = HttpContext.Current.Server.MapPath("~/Content/UserImage");//指定要将文件存入的服务器物理位置
            dic.Add("path", root);
            if (!Directory.Exists(root))
            {
                Directory.CreateDirectory(root);//创建该文件
            }
            return dic;
        }

        /// <summary>
        /// 解析base64编码获取图片
        /// </summary>
        /// <param name="base64Code">base64编码</param>
        /// <returns></returns>
        public Bitmap Base64ToImg(string base64Code)
        {
            MemoryStream stream = new MemoryStream(Convert.FromBase64String(base64Code));
            return new Bitmap(stream);

        }

        /// <summary>
        /// 存储base64编码图片
        /// </summary>
        /// <param name="base64Code">存储base64编码</param>
        /// <param name="FileName">文件名称</param>
        /// <returns></returns>
        public void SaveImg(string base64Code, string FileName)
        {
            MemoryStream stream = new MemoryStream(Convert.FromBase64String(base64Code));
            using (var bitMap = new Bitmap(stream))
            {
                bitMap.Save(FileName);
            }
        }

        /// <summary>
        /// 无损压缩图片    
        /// <param name="sFile">原图片</param>    
        /// <param name="dFile">压缩后保存位置</param>    
        /// <param name="dHeight">高度</param>    
        /// <param name="dWidth"></param>    
        /// <param name="flag">压缩质量(数字越小压缩率越高) 1-100</param>    
        /// <returns></returns>    

        public bool YaSuo(Image iSource, string outPath, int flag)
        {
            ImageFormat tFormat = iSource.RawFormat;
            EncoderParameters ep = new EncoderParameters();
            long[] qy = new long[1];
            qy[0] = flag;
            EncoderParameter eParam = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, qy);
            ep.Param[0] = eParam;
            try
            {
                ImageCodecInfo[] arrayICI = ImageCodecInfo.GetImageDecoders();
                ImageCodecInfo jpegICIinfo = null;
                for (int x = 0; x < arrayICI.Length; x++)
                {
                    if (arrayICI[x].FormatDescription.Equals("JPEG"))
                    {
                        jpegICIinfo = arrayICI[x];
                        break;
                    }
                }
                string newext = outPath.Substring(outPath.LastIndexOf(".")).ToLower();
                if (newext != ".jpeg" && newext != ".jpg")
                {
                    jpegICIinfo = null;
                }
                if (jpegICIinfo != null)
                    iSource.Save(outPath, jpegICIinfo, ep);
                else
                    iSource.Save(outPath, tFormat);
                return true;
            }
            catch
            {
                return false;
            }
            iSource.Dispose();
        }

        /// <summary>
        /// 根据图片高度压缩图片
        /// </summary>
        /// <param name="InPath">图片路径</param>
        /// <param name="height">高度(px单位)</param>
        /// <param name="outPath">转移路径</param>
        /// <param name="flag">压缩质量(数字越小压缩率越高) 1-100</param>
        /// <returns></returns>
        public bool YaSuoFixedHeight(string InPath, int height, string outPath, int flag)
        {
            var iSource = (Bitmap)Image.FromFile(InPath);
            if (iSource == null)
            {
                return false;
            }
            ImageFormat tFormat = iSource.RawFormat;
            EncoderParameters ep = new EncoderParameters();
            long[] qy = new long[1];
            qy[0] = flag;
            EncoderParameter eParam = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, qy);
            ep.Param[0] = eParam;
            try
            {
                ImageCodecInfo[] arrayICI = ImageCodecInfo.GetImageDecoders();
                ImageCodecInfo jpegICIinfo = null;
                for (int x = 0; x < arrayICI.Length; x++)
                {
                    if (arrayICI[x].FormatDescription.Equals("JPEG"))
                    {
                        jpegICIinfo = arrayICI[x];
                        break;
                    }
                }
                string newext = outPath.Substring(outPath.LastIndexOf(".")).ToLower();
                if (newext != ".jpeg" && newext != ".jpg")
                {
                    jpegICIinfo = null;
                }
                if (jpegICIinfo != null)
                    iSource.Save(outPath, jpegICIinfo, ep);
                else
                    iSource.Save(outPath, tFormat);
                return true;
            }
            catch
            {
                return false;
            }
            iSource.Dispose();
        }

        /// 无损压缩图片  
        /// <param name="sFile">原图片</param>  
        /// <param name="dFile">压缩后保存位置</param>  
        /// <param name="dHeight">高度</param>  
        /// <param name="flag">压缩质量(数字越小压缩率越高) 1-100</param>  
        /// <returns></returns>  
        public bool GetPicThumbnail(string sFile, string dFile, int dHeight, int flag)
        {
            Image iSource = Image.FromFile(sFile);
            ImageFormat tFormat = iSource.RawFormat;
            int sW = 0, sH = 0;
            //按比例缩放
            Size tem_size = new Size(iSource.Width, iSource.Height);
            if (tem_size.Height > dHeight)
            {
                sH = dHeight;
                sW = (tem_size.Width * dHeight / tem_size.Height);
            }
            else
            {
                sW = tem_size.Width;
                sH = tem_size.Height;
            }

            Bitmap ob = new Bitmap(sW, sH);
            Graphics g = Graphics.FromImage(ob);

            g.Clear(Color.WhiteSmoke);
            g.CompositingQuality = CompositingQuality.HighQuality;
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;

            g.DrawImage(iSource, new Rectangle(0, 0, sW, sH), 0, 0, iSource.Width, iSource.Height, GraphicsUnit.Pixel);

            g.Dispose();
            //以下代码为保存图片时，设置压缩质量  
            EncoderParameters ep = new EncoderParameters();
            long[] qy = new long[1];
            qy[0] = flag;//设置压缩的比例1-100  
            EncoderParameter eParam = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, qy);
            ep.Param[0] = eParam;
            try
            {
                ImageCodecInfo[] arrayICI = ImageCodecInfo.GetImageEncoders();
                ImageCodecInfo jpegICIinfo = null;
                for (int x = 0; x < arrayICI.Length; x++)
                {
                    if (arrayICI[x].FormatDescription.Equals("JPEG"))
                    {
                        jpegICIinfo = arrayICI[x];
                        break;
                    }
                }
                if (jpegICIinfo != null)
                {
                    ob.Save(dFile, jpegICIinfo, ep);//dFile是压缩后的新路径  
                }
                else
                {
                    ob.Save(dFile, tFormat);
                }
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                iSource.Dispose();
                ob.Dispose();
            }
        }
    }
}
