using Common;
using Common.Extend;
using Common.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace DbOpertion.Function
{
    public partial class PayTypeFunc : SingleTon<PayTypeFunc>
    {
        string XmlPath = "/Base/NotChange.xml";

        /// <summary>
        /// 获取支付方式列表
        /// </summary>
        /// <returns>item1:id,item2:名称</returns>
        public List<Tuple<string, string>> GetAllPayTypeInfo()
        {
            List<Tuple<string, string>> listTuple = new List<Tuple<string, string>>();
            var xmlNodeList = XmlHelper.Instance.GetXmlNodeList(XmlPath, "/EnumType/PayInfo/PayType");
            foreach (XmlElement item in xmlNodeList)
            {
                var id = item.Attributes["id"] == null ? null : item.Attributes["id"].InnerText;
                var name = item.Attributes["name"] == null ? null : item.Attributes["name"].InnerText;
                Tuple<string, string> tuple = new Tuple<string, string>(item1: id, item2: name);
                listTuple.Add(tuple);
            }
            return listTuple;
        }

        /// <summary>
        /// 获取支付方式列表
        /// </summary>
        /// <returns>item1:id,item2:名称</returns>
        public string GetPayTypeName(int? Id)
        {
            var listTuple = GetAllPayTypeInfo();
            var tuple = listTuple.Where(p => p.Item1 == Id.ToString()).FirstOrDefault();
            if (tuple != null)
            {
                return tuple.Item2;
            }
            else
            {
                return null;
            }
        }
    }
}
