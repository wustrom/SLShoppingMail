using Common.Helper.JsonHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.ThirdParty.KdGold.Model
{
    public class KdApiEOrderResponseModel
    {
        public KdApiEOrderResponseModel()
        {

        }
        public KdApiEOrderResponseModel(string jsonStr)
        {
            jsonStr = jsonStr.Replace("\r\n", "");
            //模板
            this.PrintTemplate = jsonStr.Substring(jsonStr.LastIndexOf("\"PrintTemplate\": ") + 18, jsonStr.Length - (jsonStr.LastIndexOf("\"PrintTemplate\": ") + 19)).Replace("\\r\\n", "").Replace("\\\"", "\"");
            jsonStr = $"{{{jsonStr.Substring(1, jsonStr.LastIndexOf("\"PrintTemplate\": ") - 4)}}}";
            var kdApiEOrderResponseModel = JsonHelper.Instance.DeserializeJsonToObject<KdApiEOrderResponseModel>(jsonStr);
            this.EBusinessID = kdApiEOrderResponseModel.EBusinessID;
            this.Order = kdApiEOrderResponseModel.Order;
            this.Reason = kdApiEOrderResponseModel.Reason;
            this.ResultCode = kdApiEOrderResponseModel.ResultCode;
        }
        /// <summary>
        /// 商户Id
        /// </summary>
        public string EBusinessID { get; set; }
        /// <summary>
        /// 是否成功
        /// </summary>
        public KdApiEOrderResponseOrder Order { get; set; }
        /// <summary>
        /// 理由
        /// </summary>
        public string Reason { get; set; }
        /// <summary>
        /// 返回编码
        /// </summary>
        public string ResultCode { get; set; }
        /// <summary>
        /// 电子面单模板
        /// </summary>
        public string PrintTemplate { get; set; }
    }

    public class KdApiEOrderResponseOrder
    {
        public string OrderCode { get; set; }
        public string ShipperCode { get; set; }
        public string LogisticCode { get; set; }
        public string OriginCode { get; set; }
        public string DestinatioCode { get; set; }
        public string KDNOrderCode { get; set; }
    }
}
