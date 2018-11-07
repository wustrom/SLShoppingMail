using Common;
using Common.Extend;
using DbOpertion.Models;
using DbOpertion.Operation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbOpertion.Function
{
    public partial class ShopCartFunc : SingleTon<ShopCartFunc>
    {
        
        /// <summary>
        /// 新增购物车信息
        /// </summary>
        /// <param name="model">模型</param>
        /// <returns></returns>
        public bool InsertShopCart(Shopcart model)
        {
            return ShopcartOper.Instance.Insert(model);
        }

        /// <summary>
        /// 新增购物车信息
        /// </summary>
        /// <param name="model">模型</param>
        /// <returns></returns>
        public bool UpdateShopCart(Shopcart model)
        {
            return ShopcartOper.Instance.Update(model);
        }

        /// <summary>
        /// 筛选购物车信息
        /// </summary>
        /// <param name="model">模型</param>
        /// <returns></returns>
        public Shopcart SelectShopCart(Shopcart model)
        {
            return ShopcartOper.Instance.SelectAll(model).FirstOrDefault();
        }

        /// <summary>
        /// 筛选购物车信息
        /// </summary>
        /// <param name="Id">ID</param>
        /// <returns></returns>
        public bool DeleteShopCart(int Id)
        {
            return ShopcartOper.Instance.DeleteById(Id);
        }
    }
}
