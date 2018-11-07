using Common;
using DbOpertion.Models;
using DbOpertion.Operation;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbOpertion.Function
{
    public partial class WarehouseFunc : SingleTon<WarehouseFunc>
    {
        /// <summary>
        /// 根据Id插入
        /// </summary>
        /// <param name="Id">仓库Id</param>
        /// <returns></returns>
        public string InsertWarehouse(Warehouse model)
        {
            if (WarehouseOper.Instance.SelectAll(new Warehouse { Name = model.Name }).Count != 0)
            {
                return "名称已存在！";
            }
            if (WarehouseOper.Instance.Insert(model))
            {
                return "成功";
            }
            else
            {
                return "插入失败！";
            }
        }
        /// <summary>
        /// 根据Id更新
        /// </summary>
        /// <param name="Id">仓库Id</param>
        /// <returns></returns>
        public string UpdateWarehouse(Warehouse model)
        {
            if (WarehouseOper.Instance.SelectAll(new Warehouse { Name = model.Name }).Count != 0)
            {
                return "仓库名称已存在！";
            }
            if (WarehouseOper.Instance.Update(model))
            {
                return "成功";
            }
            else
            {
                return "插入失败！";
            }
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="Ids">仓库多个Id</param>
        /// <returns></returns>
        public bool DeleteListWarehouse(string Ids)
        {
            if (Ids != null)
            {
                var arrId = Ids.Split(',').Where(p => !string.IsNullOrEmpty(p)).ToList();
                foreach (var item in arrId)
                {
                    int arrIds = 0;
                    if (item == "on")
                    {
                        arrIds = 0;
                    }
                    else
                    {
                        arrIds = int.Parse(item);
                    }
                    WarehouseOper.Instance.Update(new Warehouse { Id = arrIds, IsDelete = false });

                }
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 分页筛选未删除仓库
        /// </summary>
        /// <returns></returns>
        public List<Warehouse> SelectWarehouse()
        {
            return WarehouseOper.Instance.SelectAll(new Warehouse { IsDelete = true });
        }

        /// <summary>
        /// 筛选全部未删除仓库数目
        /// </summary>
        /// <returns></returns>
        public int SelectAllWarehouseCount()
        {
            return WarehouseOper.Instance.SelectCount(new Warehouse { IsDelete = true });
        }
    }
}
