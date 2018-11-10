using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;
using Common;

namespace Common.ThirdParty.KdGold
{
    /**
    *
    * 快递鸟电子面单接口
    *
	* @技术QQ群: 340378554
    * @see: http://kdniao.com/api-eorder
    * @copyright: 深圳市快金数据技术服务有限公司
    * 
    * ID和Key请到官网申请：http://kdniao.com/reg
    */
    public class KdApiEOrderDemo : SingleTon<KdApiEOrderDemo>
    {
        //电商ID
        private string EBusinessID = "1330824";
        //电商加密私钥，快递鸟提供，注意保管，不要泄漏
        private string AppKey = "7bfcab49-26e1-4356-8adf-1a0cd3f611d2";
        //请求url
        //正式环境地址
        //private string ReqURL = "http://api.kdniao.cc/api/Eorderservice";

        //测试环境地址
        private string ReqURL = "http://testapi.kdniao.cc:8081/api/EOrderService";

        /// <summary>
        /// Json方式  电子面单
        /// </summary>
        /// <returns></returns>
        public string orderTracesSubByJson()
        {
            string requestData ="{'OrderCode': '012657700222'," +
                                "'ShipperCode':'SF'," +
                                "'PayType':1," +
                                "'ExpType':1," +
                                "'Cost':1.0," +
                                "'OtherCost':1.0," +
                                "'Sender':" +
                                "{" +
                                "'Company':'LV','Name':'Taylor','Mobile':'15018442396','ProvinceName':'上海','CityName':'上海','ExpAreaName':'青浦区','Address':'明珠路73号'}," +
                                "'Receiver':" +
                                "{" +
                                "'Company':'GCCUI','Name':'Yann','Mobile':'15018442396','ProvinceName':'北京','CityName':'北京','ExpAreaName':'朝阳区','Address':'三里屯街道雅秀大厦'}," +
                                "'Commodity':" +
                                "[{" +
                                "'GoodsName':'鞋子','Goodsquantity':1,'GoodsWeight':1.0}]," +
                                "'Weight':1.0," +
                                "'Quantity':1," +
                                "'Volume':0.0," +
                                "'Remark':'小心轻放'," +
                                "'IsReturnPrintTemplate':1}";
            Dictionary<string, string> param = new Dictionary<string, string>();
            param.Add("RequestData", HttpUtility.UrlEncode(requestData, Encoding.UTF8));
            param.Add("EBusinessID", EBusinessID);
            param.Add("RequestType", "1007");
            string dataSign = KdApiBaseDemo.Instance.encrypt(requestData, AppKey, "UTF-8");
            param.Add("DataSign", HttpUtility.UrlEncode(dataSign, Encoding.UTF8));
            param.Add("DataType", "2");

            string result = KdApiBaseDemo.Instance.sendPost(ReqURL, param);

            //根据公司业务处理返回的信息......

            return result;
        }
    }
}