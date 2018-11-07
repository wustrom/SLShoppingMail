using Aop.Api;
using Aop.Api.Domain;
using Aop.Api.Request;
using Aop.Api.Response;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.ThirdParty
{
    public class AlipayHelper : SingleTon<AlipayHelper>
    {
        #region 基本配置
        // 应用ID,您的APPID
        public string app_id = "2018040902525319";

        // 支付宝网关
        private string gatewayUrl = "https://openapi.alipay.com/gateway.do";

        // 商户私钥，您的原始格式RSA私钥
        private string private_key = "MIIEpAIBAAKCAQEAw9vkVYuLvyJuGb/VqD03FgYQL3bA3pHA2stM8i5exC9tqU2J1iqSv/tbdNolSB1ZGVuj/3dhxt6hbya77K74dgffGwQ5JXy46e+sbMqEVk/geUBlDR80zC2Pl99kbQKZWrztHsfl88/8yqsCs+Jwvqj92dzWgEPjxmUd7WpS5pjuNxj8XkBIPbxkkYEfxfWd/nPNJOsoUhG8egZx4+SPN2Vr7BCPwmXyW/MADpGn8OiadXueOdFVmQiwQ2gPJs1z48JuTktfohGOZyvcALin4WDQBNQ4zV7pWZilVlYiXGhqSJ/HoZoI9Gyth9MIPv3nAMfWHubzuK7sOns8Lf2s9wIDAQABAoIBACeXi9C/JMC+dQM/hDE+LqSFFUCDAPn8/L892ZAbT4zZCZHv2q0wbfnhFdvJPUAWrqwxmjVKLLnGx1twuQxfUlqJvM/5SpQJYlfn2zMivR21h+r62XKNnF6p1x0cS3C91cJB7q0KO7HNmYxehW1XmPLxtl8UBUhocOLqDeKwW5HBfd5tkIkuGMDZbv9xadcVL2esZJ9q+3sYiiW7PfddOMN4VzBvm4O/omYjL3Zzseu0Q0lNHAp8unrmaU0TJ5t8gSeRG7/D+IAkG7SLX9IcG2Mdvq23/vN/9A26g20d3Wk0Vp/yPXx08vlydMW0oRiJZKrCvP/qupijzYFyzEV6TAECgYEA4G/AWTfpdRJT0TI1uLhzoXdJ9K4GLJvhRMe5Fa5s1e77anq9a8rHRaF4M7brxuBNnhdLYZl5V7EqsKbS40hJuTFGtGVY35NVS0zZ15+kLkrqM5tgznMI7WTPIhEKsT/XooBG3nazUhWf4o+62eixCb8Q5Ox6ZFbr8MY+KuQ+MU8CgYEA32dHpwnrz8n5lV1ueDPdYMM5r2yy/q+ebxKpbIuDKTE0T83ych/oI/W77Tz/YROT5OrbaypgjYbEkIyS6qijVJbsNATHXVmfR5LDZr8mJYGSZwL7096vgAUziezYOVKjVZzkF0KpMuHJbSFXvYqob2sAYHMzxvgNr0trzC5pz9kCgYBrXSo/w957cawE/Cb02c/+4ujPEtzDREKMO5rPw2QvJybAdjzdLuEK70ZoPs4lkjGvOeeGpfuFNqx8WyGxNmiGHgt7yqusMHfyEK55VtYcixvkWiUCPcd8gOgRnONnjWnjQ8gjLdd0ogGdSTKSgZ0HU46KZJHcJDS0NrGQpSUXQwKBgQCzdr1Jw5+Kmb8ErTy8FTYGsG3brZ+RFzVYFw7BYsWnxp42acQUx+rtUE96QiEJM/f/0mcXjMBpkNTBJhwzo+spXeA73YbmR8O7dHvCQ1X6lT8tv2jbh61GU2dWqkv8qJULhnB4+xT/CgCMyVc5rXSnpLZ1xLXYZZZgtl7PdI2N6QKBgQDDg+c9gvVOfmsIYfPm1QffMnYuOU2QZ4027bSGr0f6jzjexlrazPGVtROVfpB2s5TmHiPxiYamb/9HyO7xlauqoE19COxMSZbYDMsDXd2x2n6FFpiqTAGskXN0dggkmtl6xNbciHVrrKlK2JWs5Cl9+QpoyC6lcaDvE3Jaef+5kA==";

        // 支付宝公钥,查看地址：https://openhome.alipay.com/platform/keyManage.htm 对应APPID下的支付宝公钥。
        private string alipay_public_key = "MIIBIjANBgkqhkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEAw9vkVYuLvyJuGb/VqD03FgYQL3bA3pHA2stM8i5exC9tqU2J1iqSv/tbdNolSB1ZGVuj/3dhxt6hbya77K74dgffGwQ5JXy46e+sbMqEVk/geUBlDR80zC2Pl99kbQKZWrztHsfl88/8yqsCs+Jwvqj92dzWgEPjxmUd7WpS5pjuNxj8XkBIPbxkkYEfxfWd/nPNJOsoUhG8egZx4+SPN2Vr7BCPwmXyW/MADpGn8OiadXueOdFVmQiwQ2gPJs1z48JuTktfohGOZyvcALin4WDQBNQ4zV7pWZilVlYiXGhqSJ/HoZoI9Gyth9MIPv3nAMfWHubzuK7sOns8Lf2s9wIDAQAB";

        // 签名方式
        private string sign_type = "RSA2";

        // 编码格式
        private string charset = "UTF-8";
        #endregion


        /// <summary>
        /// 阿里电脑网页支付
        /// </summary>
        /// <param name="totalAmount">支付金额</param>
        /// <param name="outTradeNo">系统订单号码</param>
        /// <param name="notifyUrl">订单成功返回路径</param>
        /// <param name="body">内容</param>
        /// <param name="subject">订单名称</param>
        /// <returns></returns>
        public string CreateAlipayPageOrder(string totalAmount, string outTradeNo, string notifyUrl, string body, string subject)
        {
            DefaultAopClient client = new DefaultAopClient(gatewayUrl, app_id, private_key, "json", "1.0", sign_type, alipay_public_key, charset, false);
            //实例化具体API对应的request类,类名称和接口名称对应,当前调用接口名称如：alipay.trade.app.pay
            
            AlipayTradePagePayModel model = new AlipayTradePagePayModel();
           
            model.Body = body;
            model.Subject = subject;
            model.TotalAmount = totalAmount;
            model.OutTradeNo = outTradeNo;
            model.ProductCode = "FAST_INSTANT_TRADE_PAY";
            //订单号
            model.TimeoutExpress = "30m";
            AlipayTradePagePayRequest request = new AlipayTradePagePayRequest();
            request.SetBizModel(model);
            request.SetNotifyUrl(notifyUrl);
            // 设置同步回调地址
            request.SetReturnUrl(notifyUrl);
            //这里和普通的接口调用不同，使用的是sdkExecute
            AlipayTradePagePayResponse response = null;
            try
            {
                response = client.pageExecute(request, null, "post");
                return response.Body;
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }


        /// <summary>
        /// 阿里手机网页支付
        /// </summary>
        /// <param name="totalAmount">支付金额</param>
        /// <param name="outTradeNo">系统订单号码</param>
        /// <param name="notifyUrl">订单成功返回路径</param>
        /// <param name="body">内容</param>
        /// <param name="subject">订单名称</param>
        /// <returns></returns>
        public string CreateAlipayWapOrder(string totalAmount, string outTradeNo, string notifyUrl, string body, string subject)
        {
            DefaultAopClient client = new DefaultAopClient(gatewayUrl, app_id, private_key, "json", "1.0", sign_type, alipay_public_key, charset, false);
            //实例化具体API对应的request类,类名称和接口名称对应,当前调用接口名称如：alipay.trade.app.pay

            AlipayTradeWapPayModel model = new AlipayTradeWapPayModel();

            model.Body = body;
            model.Subject = subject;
            model.TotalAmount = totalAmount;
            model.OutTradeNo = outTradeNo;
            model.ProductCode = "QUICK_WAP_WAY";
            //订单号
            model.TimeoutExpress = "30m";
            AlipayTradeWapPayRequest request = new AlipayTradeWapPayRequest();
            request.SetBizModel(model);
            request.SetNotifyUrl(notifyUrl);
            // 设置同步回调地址
            request.SetReturnUrl(notifyUrl);
            //这里和普通的接口调用不同，使用的是sdkExecute
            AlipayTradeWapPayResponse response = null;
            try
            {
                response = client.pageExecute(request, null, "post");
                return response.Body;
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }
    }
}
