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
    /// <summary>
    /// 发票方法
    /// </summary>
    public partial class InvoiceFunc : SingleTon<InvoiceFunc>
    {
        /// <summary>
        /// 根据模型筛选发票
        /// </summary>
        /// <param name="model">发票</param>
        /// <returns></returns>
        public List<Invoice> SelectModel(Invoice model)
        {
            return InvoiceOper.Instance.SelectAll(model);
        }


        /// <summary>
        /// 根据模型筛选发票
        /// </summary>
        /// <param name="model">发票</param>
        /// <returns></returns>
        public bool UpdateModel(Invoice model)
        {
            return InvoiceOper.Instance.Update(model);
        }

        /// <summary>
        /// 根据模型筛选发票
        /// </summary>
        /// <param name="model">发票</param>
        /// <returns></returns>
        public int InsertModelReturnkey(Invoice model)
        {
            return InvoiceOper.Instance.InsertReturnKey(model);
        }

    }
}
