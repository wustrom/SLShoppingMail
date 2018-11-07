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
    public class CommpanyTypeFunc : SingleTon<CommpanyTypeFunc>
    {
        string XmlPath = "/other.xml";
        List<string> listTuple = new List<string>();
        /// <summary>
        /// 获取所有公司类型
        /// </summary>
        /// <returns></returns>
        public List<string> GetAllCompanyType()
        {
            if (listTuple.Count == 0)
            {
                var xmlNodeList = XmlHelper.Instance.GetXmlNodeList(XmlPath, "/EnumType/CompanyTypes/Company");
                foreach (XmlElement item in xmlNodeList)
                {
                    var name = item.Attributes["name"] == null ? null : item.Attributes["name"].InnerText;
                    listTuple.Add(name);
                }
            }
            return listTuple;
        }
    }
}
