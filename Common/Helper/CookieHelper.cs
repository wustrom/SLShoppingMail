using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Common.Helper
{
    public class CookieHelper : SingleTon<CookieHelper>
    {
        /// <summary>  
        /// 清除指定Cookie  
        /// </summary>  
        /// <param name="cookiename">cookiename</param>  
        public void ClearCookie(string cookiename)
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies[cookiename];
            if (cookie != null)
            {
                cookie.Expires = DateTime.Now.AddYears(-3);
                HttpContext.Current.Response.Cookies.Add(cookie);
            }
        }
        /// <summary>  
        /// 获取指定Cookie值  
        /// </summary>  
        /// <param name="cookiename">cookiename</param>  
        /// <returns></returns>  
        public string GetCookieValue(string cookiename)
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies[cookiename];
            string str = string.Empty;
            if (cookie != null)
            {
                str = cookie.Value;
            }
            return str;
        }
        /// <summary>  
        /// 添加一个Cookie（24小时过期）  
        /// </summary>  
        /// <param name="cookiename"></param>  
        /// <param name="cookievalue"></param>  
        public void SetCookie(string cookiename, string cookievalue)
        {
            SetCookie(cookiename, cookievalue, DateTime.Now.AddDays(1.0));
        }
        /// <summary>  
        /// 添加一个Cookie  
        /// </summary>  
        /// <param name="cookiename">cookie名</param>  
        /// <param name="cookievalue">cookie值</param>  
        /// <param name="expires">过期时间 DateTime</param>  
        public void SetCookie(string cookiename, string cookievalue, DateTime expires)
        {
            HttpCookie cookie = new HttpCookie(cookiename)
            {
                Value = cookievalue,
                Expires = expires
            };
            HttpContext.Current.Response.Cookies.Add(cookie);
        }
    }

    public class CookieOper : SingleTon<CookieOper>
    {
        /// <summary>
        /// 获取用户的Guid
        /// </summary>
        /// <returns></returns>
        public string GetUserGuid()
        {
            var userGuid = HttpContext.Current.Request.Cookies["UserGuid"];
            if (userGuid == null)
            {
                var guid = Guid.NewGuid();
                var cookie = new HttpCookie("UserGuid", guid.ToString());
                cookie.Expires = DateTime.Now.AddDays(180);
                HttpContext.Current.Response.Cookies.Add(cookie);
                return cookie.Value;
            }
            else
            {
                userGuid.Expires = DateTime.Now.AddDays(180);
                //HttpContext.Current.Response.Cookies.Set(userGuid);
                return userGuid.Value;
            }
        }
    }
}
