using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Xml;

namespace Common.Helper
{
    public class ProvinceHelper : SingleTon<ProvinceHelper>
    {
        public string GetProvince()
        {
            XmlNodeList lists = XmlHelper.Instance.GetXmlNodeList("./Area.xml", @"/address/province");
            string provinceJson = GetXmlToJson(lists);
            return provinceJson;
        }

        public List<string> GetProvinceList()
        {
            XmlNodeList lists = XmlHelper.Instance.GetXmlNodeList("./Area.xml", @"/address/province");
            return GetXmlToList(lists);
        }

        public string GetCity(string provname)
        {
            string xpath = string.Format("/address/province[@name='{0}']/city", provname);//要研究
            XmlNodeList lists = XmlHelper.Instance.GetXmlNodeList("./Area.xml", xpath);
            string cityJson = GetXmlToJson(lists);
            return cityJson;
        }

        public List<string> GetCityList(string provname)
        {
            string xpath = string.Format("/address/province[@name='{0}']/city", provname);//要研究
            XmlNodeList lists = XmlHelper.Instance.GetXmlNodeList("./Area.xml", xpath);
            return GetXmlToList(lists);
        }

        public string GetArea(string cityname)
        {
            string xpath = string.Format("/address/province/city[@name='{0}']/country", cityname);
            XmlNodeList lists = XmlHelper.Instance.GetXmlNodeList("./Area.xml", xpath);
            string cityJson = GetXmlToJson(lists);
            return cityJson;
        }

        public List<string> GetAreaList(string provname)
        {
            string xpath = string.Format("/address/province/city[@name='{0}']/country", provname);
            XmlNodeList lists = XmlHelper.Instance.GetXmlNodeList("./Area.xml", xpath);
            return GetXmlToList(lists);
        }

        private string GetXmlToJson(XmlNodeList nodeList)
        {
            try
            {
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                if (nodeList != null)
                {
                    sb.Append("[");
                    foreach (XmlNode node in nodeList)
                    {
                        sb.Append("{\"name\":\"" + node.Attributes["name"].InnerText + "\"},");
                    }
                    sb.Remove(sb.Length - 1, 1);
                    sb.Append("]");
                }
                return sb.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private List<string> GetXmlToList(XmlNodeList nodeList)
        {
            try
            {
                List<string> list = new List<string>();
                if (nodeList != null)
                {
                    foreach (XmlNode node in nodeList)
                    {
                        list.Add(node.Attributes["name"].InnerText);
                    }
                }
                return list;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
