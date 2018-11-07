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
    public class ColorFunc : SingleTon<ColorFunc>
    {
        string XmlPath = "/other.xml";
        List<Tuple<string, string, string>> listTuple = new List<Tuple<string, string, string>>();
        /// <summary>
        /// 获取颜色信息列表
        /// </summary>
        /// <param name="color">颜色(已,分隔)</param>
        /// <returns>item1:id,item2:名称,item3:颜色代码</returns>
        public List<Tuple<string, string, string>> GetColorInfo(string color)
        {
            if (listTuple.Count == 0)
            {
                GetAllColorInfo();
            }
            if (!color.IsNullOrEmpty())
            {
                var arry = color.Split(',');
                List<Tuple<string, string, string>> newlistTuple = new List<Tuple<string, string, string>>();
                foreach (var item in arry)
                {
                    if (!item.IsNullOrEmpty())
                    {
                        var tuple = listTuple.Where(p => p.Item1.ToString() == item).FirstOrDefault();
                        newlistTuple.Add(tuple);
                    }
                }
                return newlistTuple;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 获得颜色ID
        /// </summary>
        /// <param name="colorName">颜色名称</param>
        /// <returns></returns>
        public string GetColorId(string colorName)
        {
            if (listTuple.Count == 0)
            {
                GetAllColorInfo();
            }
            var tuple = listTuple.Where(p => p.Item2 == colorName).FirstOrDefault();
            return tuple == null ? "1" : tuple.Item1;
        }


        /// <summary>
        /// 获取颜色信息列表
        /// </summary>
        /// <param name="color">颜色(已,分隔)</param>
        /// <returns>item1:id,item2:名称,item3:颜色代码</returns>
        public List<Tuple<string, string, string>> GetAllColorInfo()
        {
            listTuple = new List<Tuple<string, string, string>>();
            var xmlNodeList = XmlHelper.Instance.GetXmlNodeList(XmlPath, "/EnumType/colors/color");
            foreach (XmlElement item in xmlNodeList)
            {
                var id = item.Attributes["id"] == null ? null : item.Attributes["id"].InnerText;
                var name = item.Attributes["name"] == null ? null : item.Attributes["name"].InnerText;
                var code = item.Attributes["code"] == null ? null : item.Attributes["code"].InnerText;
                Tuple<string, string, string> tuple = new Tuple<string, string, string>(item1: id, item2: name, item3: code);
                listTuple.Add(tuple);
            }
            return listTuple;
        }
    }
}
