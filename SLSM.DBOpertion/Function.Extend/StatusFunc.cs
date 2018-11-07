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
    public class StatusFunc : SingleTon<StatusFunc>
    {
        string XmlPath = "/Base/NotChange.xml";

        /// <summary>
        /// 获取订单状态信息列表
        /// </summary>
        /// <param name="status">状态(已,分隔)</param>
        /// <returns>item1:id,item2:名称</returns>
        public List<Tuple<string, string>> GetAllStatusInfo()
        {
            List<Tuple<string, string>> listTuple = new List<Tuple<string, string>>();
            var xmlNodeList = XmlHelper.Instance.GetXmlNodeList(XmlPath, "/EnumType/OrderStatus/status");
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
        /// 获取不同状态订单信息列表
        /// </summary>
        /// <param name="status">状态(已,分隔)</param>
        /// <returns>item1:id,item2:名称</returns>
        public int? GetTypeStatus(string statusName)
        {
            var listTuple = GetAllStatusInfo();
            var tuple = listTuple.Where(p => p.Item2 == statusName).FirstOrDefault();
            if (tuple != null)
            {
                return tuple.Item1.ParseInt();
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 获取不同状态订单信息列表
        /// </summary>
        /// <param name="status">状态(已,分隔)</param>
        /// <returns>item1:id,item2:名称</returns>
        public string GetStatusName(int? Id)
        {
            var listTuple = GetAllStatusInfo();
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
