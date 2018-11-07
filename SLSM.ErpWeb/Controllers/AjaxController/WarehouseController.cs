using Common.Filter.WebApi;
using Common.Result;
using DbOpertion.Function;
using SLSM.ErpWeb.Model.Request.Buyer;
using SLSM.ErpWeb.Model.Request.Deceive;
using SLSM.ErpWeb.Model.Request.Storage;
using SLSM.ErpWeb.Model.Request.Warehouses;
using System;
using System.Web.Http;

namespace SLSM.ErpWeb.Controllers.AjaxController
{
    public class WarehouseController : BaseApiController
    {
        #region 库存管理
        /// <summary>
        /// 库存管理,调整库存
        /// </summary>
        /// <param name="request">请求</param>
        /// <returns></returns>
        [HttpPost]
        public ResultJson AddChangeInfo(ChangeRequest request)
        {
            if (ChangesFunc.Instance.InsertStorageChange(request.ChangeContext, request.ChangeCountType, request.ChangeCount, request.storageId, request.WarehouseId, request.RawmaterialsId, request.SKU))
            {
                return new ResultJson { HttpCode = 200, Message = "库存调整成功!" };
            }
            else
            {
                return new ResultJson { HttpCode = 300, Message = "库存调整失败,请判断调整后库存是否大于0!" };
            }
        }
        #endregion

        #region 采购入库
        /// <summary>
        /// 采购入库,入库
        /// </summary>
        /// <param name="request">请求</param>
        /// <returns></returns>
        [HttpPost]
        public ResultJson BuyerDetailedInfo(BuyerDetailedRequest request)
        {
            if (BuyerDetailedFunc.Instance.InsertBuyerDetailed(request.WarehouseId, request.deliverId, request.RuKuNum))
            {
                return new ResultJson { HttpCode = 200, Message = "入库成功!" };

            }
            else
            {
                return new ResultJson { HttpCode = 300, Message = "入库失败！" };
            }
        }
        #endregion

        #region 生产领料
        /// <summary>
        /// 确认出库
        /// </summary>
        /// <param name="request">请求</param>
        /// <returns></returns>
        [HttpPost]
        public ResultJson DeceiveDetailedInfo(SelectWarehousRequest request)
        {
            if (ReceiveFunc.Instance.UpdateStorageDeceive(request.ReceiveId.Value))
            {
                return new ResultJson { HttpCode = 200, Message = "出库成功!" };
            }
            else
            {
                return new ResultJson { HttpCode = 300, Message = "库存不足或者出库失败,请重试!" };
            }
        }
        /// <summary>
        /// 申请领料
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ResultJson Applywarehouse(SelectWarehousRequest request)
        {
            if (ReceiveFunc.Instance.ApplyStorageDeceive(request.productionId.Value, request.MaterList, request.receiveSinglePerson, DateTime.Now))
            {
                return new ResultJson { HttpCode = 200, Message = "申请成功" };
            }
            else
            {
                return new ResultJson { HttpCode = 300, Message = "申请失败,库存不足!" };
            }

        }
        #endregion 

        #region 仓库分类
        /// <summary>
        /// 添加或者修改仓库信息
        /// </summary>
        /// <param name="request">请求</param>
        /// <returns></returns>
        [HttpPost]
        public ResultJson EditWarehouseInfo(WarehouseRequest request)
        {
            var result = "";
            #region 添加
            if (request.Id == 0)
            {
                result = WarehouseFunc.Instance.InsertWarehouse(new DbOpertion.Models.Warehouse
                {
                    Name = request.Name,
                    IsDelete = true
                });
            }
            #endregion 

            #region 修改
            else
            {
                result = WarehouseFunc.Instance.UpdateWarehouse(new DbOpertion.Models.Warehouse
                {
                    Id = request.Id,
                    Name = request.Name
                });
            }
            #endregion

            if (result == "成功")
            {
                return new ResultJson { HttpCode = 200, Message = result };
            }
            else
            {
                return new ResultJson { HttpCode = 300, Message = "失败!" };
            }
        }
        /// <summary>
        /// 删除仓库 
        /// </summary>
        /// <param name="request">请求</param>
        /// <returns></returns>
        [HttpPost]
        public ResultJson DeleteWarehouse(WarehouseRequest request)
        {
            if (WarehouseFunc.Instance.DeleteListWarehouse(request.Ids))
            {
                return new ResultJson { HttpCode = 200, Message = "删除成功！" };
            }
            else
            {
                return new ResultJson { HttpCode = 300, Message = "删除失败！" };
            }
        }
        #endregion
    }
}