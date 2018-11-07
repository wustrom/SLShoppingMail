using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Xml;

namespace Common.Helper
{
    public class XmlHelper : SingleTon<XmlHelper>
    {
        /// <summary>
        /// 获得XML文档
        /// </summary>
        /// <param name="XmlPath">XML地址</param>
        /// <returns></returns>
        public XmlDocument GetXMLDocument(string XmlPath)
        {
            XmlDocument doc = new XmlDocument();
            string path = HttpContext.Current.Server.MapPath("");
            if (path.ToLower().Contains("\\api\\"))
            {
                path = HttpContext.Current.Server.MapPath("../../" + XmlPath);
            }
            else if (path.Split('\\').Last().ToLower() == "slsm.web" || path.Split('\\').Last().ToLower() == "slsm.moblieweb")
            {
                path = HttpContext.Current.Server.MapPath(XmlPath);
            }
            else
            {
                path = HttpContext.Current.Server.MapPath("../" + XmlPath);
            }
            doc.Load(path);
            return doc;
        }

        /// <summary>
        /// 获得节点的有序集合
        /// </summary>
        /// <param name="doc">XML文档</param>
        /// <param name="xpath">XPath表达式{/节点[@属性='{0}']/节点}</param>
        /// <returns></returns>
        public XmlNodeList GetXmlNodeList(XmlDocument doc, string xpath)
        {
            XmlNodeList lists = doc.SelectNodes(xpath);
            return lists;
        }

        /// <summary>
        /// 获得节点的有序集合
        /// </summary>
        /// <param name="XmlPath">XML地址</param>
        /// <param name="xpath">XPath表达式"/节点[@属性='{0}']/节点"</param>
        /// <returns></returns>
        public XmlNodeList GetXmlNodeList(string XmlPath, string xpath)
        {
            XmlNodeList lists = GetXMLDocument(XmlPath).SelectNodes(xpath);
            return lists;
        }

        /// <summary>
        /// 获得节点的属性值
        /// </summary>
        /// <param name="doc">XML文档</param>
        /// <param name="xpath">XPath表达式{/节点[@属性='{0}']/节点}</param>
        /// <param name="AttrText">属性文本</param>
        /// <returns></returns>
        public string GetXmlAttrValue(XmlDocument doc, string xpath, string AttrText)
        {
            XmlNodeList lists = doc.SelectNodes(xpath);
            var attr = lists[0].Attributes[AttrText];
            return attr == null ? null : attr.InnerText;
        }

        /// <summary>
        /// 获得节点的属性值
        /// </summary>
        /// <param name="doc">XML文档</param>
        /// <param name="xpath">XPath表达式{/节点[@属性='{0}']/节点}</param>
        /// <param name="AttrText">属性文本</param>
        /// <returns></returns>
        public string GetXmlAttrValue(string XmlPath, string xpath, string AttrText)
        {
            XmlNodeList lists = GetXMLDocument(XmlPath).SelectNodes(xpath);
            if (lists.Count != 0)
            {
                var attr = lists[0].Attributes[AttrText];
                return attr == null ? null : attr.InnerText;
            }
            else
            {
                return null;
            }
        }
    }
}
