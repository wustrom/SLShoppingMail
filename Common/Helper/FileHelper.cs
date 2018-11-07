using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Common.Helper
{
    public class FileHelper : SingleTon<FileHelper>
    {
        /// <summary>
        /// 删除文件夹下所有文件
        /// </summary>
        /// <param name="srcPath">文件路径</param>
        public void DelectDir(string srcPath)
        {
            try
            {
                checkDir(srcPath);
                DirectoryInfo dir = new DirectoryInfo(srcPath);
                FileSystemInfo[] fileinfo = dir.GetFileSystemInfos();  //返回目录中所有文件和子目录
                foreach (FileSystemInfo i in fileinfo)
                {
                    if (i is DirectoryInfo)            //判断是否文件夹
                    {
                        DirectoryInfo subdir = new DirectoryInfo(i.FullName);
                        subdir.Delete(true);          //删除子目录和文件
                    }
                    else
                    {
                        File.Delete(i.FullName);      //删除指定文件
                    }
                }
                dir.Delete();
            }
            catch (Exception e)
            {
                throw;
            }
        }

        /// <summary>
        /// 删除文件夹下所有文件
        /// </summary>
        /// <param name="srcPath">文件路径</param>
        public void DelectDirWithOutList(string srcPath, List<string> listFile, string FileUrl = null)
        {
            try
            {
                listFile = listFile.Where(p => p != "" && p != null).Select(p => p.Split('/').Last()).ToList();
                checkDir(FileUrl + srcPath);
                DirectoryInfo dir = new DirectoryInfo(FileUrl + srcPath);
                FileInfo[] fileinfo = dir.GetFiles();  //返回目录中所有文件和子目录
                foreach (FileInfo i in fileinfo)
                {
                    var fileName = listFile.Where(p => p == i.Name).FirstOrDefault();
                    if (fileName == null)
                    {
                        File.Delete(FileUrl + i.FullName);      //删除指定文件
                    }

                }
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public void Move(string image, object p, string v)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 筛选文件夹下全部图片
        /// </summary>
        /// <param name="srcPath">路径</param>
        /// <returns></returns>
        public string SelectImageFile(string srcPath)
        {
            try
            {
                var resultstr = "";
                var path = HttpContext.Current.Server.MapPath(srcPath);
                checkDir(path);
                DirectoryInfo dir = new DirectoryInfo(path);
                FileSystemInfo[] fileinfo = dir.GetFiles();  //返回目录中所有文件和子目录
                foreach (FileInfo i in fileinfo)
                {
                    if (i.Extension == ".jpg" || i.Extension == ".png" || i.Extension == ".jpeg")
                    {
                        if (!i.FullName.Contains("/Fornt/") && !i.FullName.Contains("/Back/"))
                        {
                            resultstr = resultstr + srcPath + "/" + i.Name + ";";
                        }
                    }
                }
                return resultstr;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        /// <summary>  
        /// 检查指定目录是否存在,如不存在则创建  
        /// </summary>  
        /// <param name="url">地址</param>  
        /// <returns></returns>  
        public bool checkDir(string url)
        {
            try
            {
                if (!Directory.Exists(url))//如果不存在就创建file文件夹　　             　　                
                    Directory.CreateDirectory(url);//创建该文件夹　　              
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// 移动文件
        /// </summary>
        /// <param name="sourceFileName">源文件名称</param>
        /// <param name="destFileName">目标文件名称</param>
        /// <param name="Dic">文件路径</param>
        public void Move(string sourceFileName, string destFileName, string Dic)
        {
            checkDir(Dic);
            if (File.Exists(sourceFileName))
            {
                File.Move(sourceFileName, destFileName);
            }
        }

        /// <summary>
        /// 删除文件夹下所有文件
        /// </summary>
        /// <param name="srcPath">文件路径</param>
        public void DelectFile(string srcPath)
        {
            if (File.Exists(HttpContext.Current.Server.MapPath(srcPath)))
            {
                File.Delete(HttpContext.Current.Server.MapPath(srcPath));
            }
        }
    }
}
