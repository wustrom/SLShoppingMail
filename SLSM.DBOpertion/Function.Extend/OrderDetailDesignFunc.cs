using Common;
using DbOpertion.Models;
using DbOpertion.Operation;
using System.Collections.Generic;

namespace DbOpertion.Function
{
    public partial class OrderDetailDesignFunc : SingleTon<OrderDetailDesignFunc>
    {
        /// <summary>
        /// 根据模型筛选数据
        /// </summary>
        /// <param name="model">模型</param>
        /// <returns></returns>
        public List<Orderdetaildesign> SelectByModel(Orderdetaildesign model)
        {
            return OrderdetaildesignOper.Instance.SelectAll(model);
        }

        /// <summary>
        /// 根据Id筛选数据
        /// </summary>
        /// <param name="model">模型</param>
        /// <returns></returns>
        public Orderdetaildesign SelectById(int Id)
        {
            return OrderdetaildesignOper.Instance.SelectById(Id);
        }

        /// <summary>
        /// 根据Id筛选数据
        /// </summary>
        /// <param name="model">模型</param>
        /// <returns></returns>
        public List<Orderdetaildesign> SelectById(string Key, int start, int PageSize, bool desc, Orderdetaildesign model)
        {
            return OrderdetaildesignOper.Instance.SelectByPage(Key, start, PageSize, desc, model);
        }

        /// <summary>
        /// 插入模型
        /// </summary>
        /// <param name="model">模型</param>
        /// <returns></returns>
        public bool Insert(Orderdetaildesign model)
        {
            return OrderdetaildesignOper.Instance.Insert(model);
        }

        /// <summary>
        /// 更新模型
        /// </summary>
        /// <param name="model">模型</param>
        /// <returns></returns>
        public bool Update(Orderdetaildesign model)
        {
            return OrderdetaildesignOper.Instance.Update(model);
        }

        /// <summary>
        /// 插入模型返回主键
        /// </summary>
        /// <param name="model">模型</param>
        /// <returns></returns>
        public int InsertReturnKey(Orderdetaildesign model)
        {
            return OrderdetaildesignOper.Instance.InsertReturnKey(model);
        }

        /// <summary>
        /// 根据模型删除
        /// </summary>
        /// <param name="model">模型</param>
        /// <returns></returns>
        public bool DeleteModel(Orderdetaildesign model)
        {
            return OrderdetaildesignOper.Instance.DeleteModel(model);
        }

        /// <summary>
        /// 根据Id删除
        /// </summary>
        /// <param name="model">模型</param>
        /// <returns></returns>
        public bool DeleteById(int Id)
        {
            return OrderdetaildesignOper.Instance.DeleteById(Id);
        }
    }
}