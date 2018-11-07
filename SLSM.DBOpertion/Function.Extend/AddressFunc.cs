using Aliyun.Acs.Dysmsapi.Model.V20170525;
using AliyunHelper.SendMail;
using Common;
using Common.Extend;
using Common.Helper;
using DbOpertion.Models;
using DbOpertion.Operation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbOpertion.Function
{
    public partial class AddressFunc : SingleTon<AddressFunc>
    {
        /// <summary>
        /// 根据Id查询
        /// </summary>
        /// <param name="AddressId">地址Id</param>
        /// <returns></returns>
        public Address SelectAddrById(int AddressId)
        {
            return AddressOper.Instance.SelectById(AddressId);
        }

        /// <summary>
        /// 筛选全部查询
        /// </summary>
        /// <param name="AddressId">地址Id</param>
        /// <returns></returns>
        public List<Address> SelectAll(Address Address)
        {
            return AddressOper.Instance.SelectAll(Address);
        }


        /// <summary>
        /// 删除联系人信息
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public bool DeleteAdrr(int Id)
        {
            return AddressOper.Instance.DeleteById(Id);
        }

        /// <summary>
        /// 添加联系人信息
        /// </summary>
        /// <param name="ads"></param>
        /// <returns></returns>
        public int AdressAdd(Address ads)
        {
            return AddressOper.Instance.InsertReturnKey(ads);
        }
    }
}
