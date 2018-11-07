using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Net;
using System.IO;
using Common.Helper.JsonHelper;

namespace Common.ThirdParty.KdGold
{
    public class KdApiSearchDemo : SingleTon<KdApiSearchDemo>
    {
        //电商ID
        private string EBusinessID = "1330824";
        //电商加密私钥，快递鸟提供，注意保管，不要泄漏
        private string AppKey = "7bfcab49-26e1-4356-8adf-1a0cd3f611d2";
        //请求url
        private string ReqURL = "http://api.kdniao.cc/Ebusiness/EbusinessOrderHandle.aspx";

        /// <summary>
        /// Json方式 查询订单物流轨迹
        /// </summary>
        /// <param name="ShipperCode">快递编码</param>
        /// <param name="LogisticCode">快递编号</param>
        /// <returns></returns>
        public KdApiResult getOrderTracesByJson(string ShipperCode, string LogisticCode)
        {
            ShipperCode = ConvertShipperCode(ShipperCode);
            OrderInfo info = new OrderInfo { OrderCode = "", ShipperCode = ShipperCode, LogisticCode = LogisticCode };
            //string requestData = "{'OrderCode':'','ShipperCode':'" + ShipperCode + "','LogisticCode':'" + LogisticCode + "'}";
            string requestData = JsonHelper.Instance.SerializeObject(info);
            Dictionary<string, string> param = new Dictionary<string, string>();
            param.Add("RequestData", HttpUtility.UrlEncode(requestData, Encoding.UTF8));
            param.Add("EBusinessID", EBusinessID);
            param.Add("RequestType", "1002");
            string dataSign = KdApiBaseDemo.Instance.encrypt(requestData, AppKey, "UTF-8");
            param.Add("DataSign", HttpUtility.UrlEncode(dataSign, Encoding.UTF8));
            param.Add("DataType", "2");
            string result = KdApiBaseDemo.Instance.sendPost(ReqURL, param);
            var apiResult = JsonHelper.Instance.DeserializeJsonToObject<KdApiResult>(result);
            //根据公司业务处理返回的信息......
            return apiResult;
        }

        /// <summary>
        /// 转换快递编码
        /// </summary>
        /// <param name="ShipperCode">快递名称</param>
        /// <returns></returns>
        private string ConvertShipperCode(string ShipperCode)
        {
            if (ShipperCode == "圆通速递")
                return "YTO";
            else if (ShipperCode == "中通快递")
                return "ZTO";
            else if (ShipperCode == "邮政快递包裹")
                return "YZPY";
            else if (ShipperCode == "EMS")
                return "EMS";
            else if (ShipperCode == "天天快递")
                return "EMS";
            else if (ShipperCode == "韵达速递")
                return "YD";
            //else if (ShipperCode == "京东物流")
            //    return "JD";
            //else if (ShipperCode == "全峰快递")
            //    return "QFKD";
            //else if (ShipperCode == "国通快递")
            //    return "GTO";
            //else if (ShipperCode == "优速快递")
            //    return "UC";
            //else if (ShipperCode == "德邦")
            //    return "DBL";
            //else if (ShipperCode == "快捷快递")
            //    return "FAST";
            //else if (ShipperCode == "宅急送")
            //    return "ZJS";
            else
                return null;
        }
    }
    [Serializable]
    public class KdApiResult
    {
        /// <summary>
        /// 用户ID
        /// </summary>
        public string EBusinessID { get; set; }
        /// <summary>
        /// 订单编号
        /// </summary>
        public string OrderCode { get; set; }
        /// <summary>
        /// 快递公司编码
        /// </summary>
        public string ShipperCode { get; set; }
        /// <summary>
        /// 物流运单号
        /// </summary>
        public string LogisticCode { get; set; }
        /// <summary>
        /// 成功与否
        /// </summary>
        public bool Success { get; set; }
        /// <summary>
        /// 失败原因
        /// </summary>
        public string Reason { get; set; }
        /// <summary>
        ///  物流状态：2-在途中,3-签收,4-问题件 R
        /// </summary>
        public string State { get; set; }
        public List<TracesInfo> Traces { get; set; }
    }
    [Serializable]
    public class TracesInfo
    {
        /// <summary>
        /// 时间  R
        /// </summary>
        public string AcceptTime { get; set; }
        /// <summary>
        /// 描述  R
        /// </summary>
        public string AcceptStation { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }
    }
    [Serializable]
    class OrderInfo
    {
        /// <summary>
        /// 订单代码
        /// </summary>
        public string OrderCode { get; set; }
        /// <summary>
        /// 快递编码
        /// </summary>
        public string ShipperCode { get; set; }
        /// <summary>
        /// 订单编号
        /// </summary>
        public string LogisticCode { get; set; }
    }
}
