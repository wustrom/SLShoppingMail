using Common.Helper;
using Common.Helper.JsonHelper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace Common.ThirdParty.WeChatLogin
{
    /// <summary>
    /// 微信登入帮助类
    /// </summary>
    public class WeChatLoginHelper : SingleTon<WeChatLoginHelper>
    {
        #region 基本配置
        // 应用ID,您的APPID
        private string appid = "wx6cf2e87f65bb78f2";
        // 进入Token地址
        private string AccessTokenUrl = "https://api.weixin.qq.com/sns/oauth2/access_token";

        private string userInfoUrl = "https://api.weixin.qq.com/sns/userinfo";
        // App密钥
        private string AppSecret = "255a365eac4c4ff3b0ed4756d79b15eb";
        #endregion

        /// <summary>
        /// 获得用户通行证
        /// </summary>
        /// <returns></returns>
        public WeChatAccessToken GetAccessToken(string Code)
        {
            var url = $"{AccessTokenUrl}?appid={appid}&secret={AppSecret}&code={Code}&grant_type=authorization_code";
            var result = HttpRequestHelper.Instance.GetHttpResponse(url, 600000);
            return JsonHelper.Instance.DeserializeJsonToObject<WeChatAccessToken>(result);
        }

        /// <summary>
        /// 获得用户信息
        /// </summary>
        /// <param name="AccessToken">调用凭证</param>
        /// <param name="openid">普通用户的标识，对当前开发者帐号唯一</param>
        /// <returns></returns>
        public WeChatUserInfo GetUserInfo(string AccessToken, string openid)
        {
            var url = $"{userInfoUrl}?access_token={AccessToken}&openid={openid}";
            var result = HttpRequestHelper.Instance.GetHttpResponse(url, 600000);
            return JsonHelper.Instance.DeserializeJsonToObject<WeChatUserInfo>(result);
        }
    }
}