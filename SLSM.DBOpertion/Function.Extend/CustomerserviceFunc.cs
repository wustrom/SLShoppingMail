using Common;
using DbOpertion.Models;
using DbOpertion.Operation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbOpertion.Function
{
    public partial class CustomerserviceFunc : SingleTon<CustomerserviceFunc>
    {
        /// <summary>
        /// 分页筛选未删除客服
        /// </summary>
        /// <param name="pageNo">页码</param>
        /// <param name="pageSize">页面大小</param>
        /// <returns></returns>
        public List<Customerservice> SelectUserByPage(int pageNo, int pageSize)
        {
            return CustomerserviceOper.Instance.SelectByPage("Id", (pageNo - 1) * pageSize, pageSize, true);
        }

        /// <summary>
        /// 筛选全部客服数目
        /// </summary>
        /// <returns></returns>
        public List<Customerservice> SelectAllUserName(string ServiceName)
        {
            return CustomerserviceOper.Instance.SelectAll(new Customerservice { ServiceName=ServiceName });
        }

        /// <summary>
        /// 筛选全部未删除客服数目
        /// </summary>
        /// <returns></returns>
        public int SelectAllUserCount()
        {
            return CustomerserviceOper.Instance.SelectCount(new Customerservice { IsService = false });
        }
        /// <summary>
        /// 根据Id插入
        /// </summary>
        /// <param name="Id">客服Id</param>
        /// <returns></returns>
        public string InsertModel(Customerservice model)
        {
            if (CustomerserviceOper.Instance.Insert(model))
            {
                return "成功！";
            }            
            else
            {
                return "插入失败！";
            }
        }
        /// <summary>
        /// 根据Id修改
        /// </summary>
        /// <param name="Id">客服Id</param>
        /// <returns></returns>
        public string UpdateModel(Customerservice model)
        {
            if (CustomerserviceOper.Instance.Update(model))
            {
                return "成功！";
            }
            else
            {
                return "插入失败！";
            }
        }
         /// <summary>
        /// 根据Id删除
        /// </summary>
        /// <param name="Id">用户Id</param>
        /// <returns></returns>
        public bool DeleteModel(int Id)
        {
            return CustomerserviceOper.Instance.DeleteById(Id);
        }
    }
}
