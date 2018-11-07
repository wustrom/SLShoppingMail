using Common;
using Common.Helper;
using DbOpertion.Models;
using DbOpertion.Operation;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbOpertion.Function
{
    public partial class StorageFunc : SingleTon<StorageFunc>
    {
        /// <summary>
        /// 分页筛选未删除库存
        /// </summary>
        /// <returns></returns>
        public Tuple<List<Storage_View>, int> SelectStorage(int PageIndex, int PageSize, string Order, string sort, string Name)
        {
            return new Tuple<List<Storage_View>, int>(item1: Storage_ViewOper.Instance.SelectStoragePage(sort, (PageIndex - 1) * PageSize, PageSize, Order == "desc" ? true : false, Name), item2: Storage_ViewOper.Instance.SelectStorageCount(Name));
        }
        /// <summary>
        /// 库存详细信息
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public Storage_View SelectStorageDetailed(int Id)
        {
            return Storage_ViewOper.Instance.SelectById(Id);
        }


        /// <summary>
        /// 分页筛选未删除库存
        /// </summary>
        /// <returns></returns>
        public Tuple<List<Materials_Stock_View>, int> SelectMaterial_Stock_View(int PageIndex, int PageSize, string Order, string sort, string Name, List<string> materialsIds)
        {
            return new Tuple<List<Materials_Stock_View>, int>(item1: Materials_Storage_ViewOper.Instance.SelectStockViewPage(sort, (PageIndex - 1) * PageSize, PageSize, Order == "desc" ? true : false, Name, materialsIds), item2: Materials_Storage_ViewOper.Instance.SelectStockViewCount(Name, materialsIds));
        }
    }
}
