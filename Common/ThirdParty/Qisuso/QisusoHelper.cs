using Common.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.ThirdParty.Qisuso
{
    /// <summary>
    /// 发票查询企速搜查询类
    /// </summary>
    public class QisusoHelper : SingleTon<QisusoHelper>
    {
        /// <summary>
        /// 连接路径
        /// </summary>
        private string ApiUrl = "http://api.qisuso.com/Basic/singleExact_v1";

        private string Token = "";

        /// <summary>
        /// 获得公司信息
        /// </summary>
        /// <param name="name">名称</param>
        /// <param name="Code">编码</param>
        /// <returns></returns>
        public string GetCompanyInfo(string name, string Code)
        {
            var url = $"{ApiUrl}?token={Token}&type=json&combo_type=&name={name}&code={Code}";
            var result = HttpRequestHelper.Instance.GetHttpResponse(url, 600000);
            return result;
        }

    }
}
