using Common.Extend;
using Common.Helper;
using DbOpertion.Function;
using DbOpertion.Models;
using SLSM.ErpWeb.App_Start;
using SLSM.ErpWeb.Common.BaseController;
using SLSM.ErpWeb.Model.Request.Warehouses;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace SLSM.ErpWeb.Controllers.PageController
{
    public class WarehousesController : BaseMvcMasterController
    {

        #region 库存管理
        /// <summary>
        /// 库存管理
        /// </summary>
        /// <returns></returns>
        [UserAuthorize]
        public ActionResult StorageInfo()
        {
            return View();
        }
        /// <summary>
        /// 库存管理,详细信息
        /// </summary>
        /// <returns></returns>
        public ActionResult StorageDetailed()
        {
            var Id = HttpContext.Request.QueryString["Id"].ParseInt();
            var Storages = StorageFunc.Instance.SelectStorageDetailed(Id.Value);
            if (Storages != null)
            {
                ViewBag.StorageDetailedInfo = Storages;
                return View();
            }
            else
            {
                //跳转到错误页面
                return View();
            }
        }
        /// <summary>
        /// 库存,变动统计
        /// </summary>
        /// <returns></returns>
        public ActionResult ChangesCount()
        {
            var Id = HttpContext.Request.QueryString["Id"].ParseInt();
            if (Id != null)
            {
                ViewBag.ChangeId = Id;
            }
            return View();
        }
        /// <summary>
        /// 库存,调整库存
        /// </summary>
        /// <returns></returns>
        public ActionResult StorageEditInfo()
        {
            var OrderId = HttpContext.Request.QueryString["Id"].ParseInt();
            var matercolorId = HttpContext.Request.QueryString["matercolorId"].ParseInt();

            var StorageInfo = StorageFunc.Instance.SelectById(OrderId.Value);
            var warehouse = WarehouseFunc.Instance.SelectByModel(new Warehouse { IsDelete = true });
            ViewBag.WareHouseList = warehouse;
            if (StorageInfo != null)
            {
                ViewBag.StorageFullInfo = StorageInfo;
                #region 库存列表
                var StorageList = StorageFunc.Instance.SelectByModel(new Storage { Raw_materialsId = StorageInfo.Raw_materialsId, Color = StorageInfo.Color });
                var listStorage = new List<Storage>();
                foreach (var item in warehouse)
                {
                    var storage = StorageList.Where(p => p.WarehouseId == item.Id).FirstOrDefault();
                    if (storage == null)
                    {
                        storage = new Storage { WarehouseId = item.Id, stock = 0, Raw_materialsId = StorageInfo.Raw_materialsId, Color = StorageInfo.Color };
                    }
                    listStorage.Add(storage);
                }
                ViewBag.listStorage = listStorage;
                #endregion
                return View();
            }
            else
            {
                if (matercolorId != null)
                {
                    #region 库存列表
                    var matercolor = Materials_ColorinfoFunc.Instance.SelectById(matercolorId.Value);
                    var StorageList = StorageFunc.Instance.SelectByModel(new Storage { Raw_materialsId = matercolorId });
                    var listStorage = new List<Storage>();
                    foreach (var item in warehouse)
                    {
                        var storage = StorageList.Where(p => p.WarehouseId == item.Id).FirstOrDefault();
                        if (storage == null)
                        {
                            storage = new Storage { WarehouseId = item.Id, stock = 0, Raw_materialsId = matercolor.MaterialsId, Color = matercolor.SKU };
                        }
                        listStorage.Add(storage);
                    }
                    ViewBag.listStorage = listStorage;
                    #endregion
                    ViewBag.StorageFullInfo = new Storage();

                    #region 注释代码
                    //var matercolor = Materials_ColorinfoFunc.Instance.SelectById(matercolorId.Value);
                    //var warehou = WarehouseFunc.Instance.SelectByModel(new DbOpertion.Models.Warehouse { IsDelete = true }).FirstOrDefault();
                    //var returnkey = StorageFunc.Instance.InsertReturnKey(new DbOpertion.Models.Storage { Color = matercolor.SKU, freeze_stock = 0, stock = 0, Raw_materialsId = matercolor.MaterialsId, WarehouseId = warehou.Id });
                    //ViewBag.StorageFullInfo = StorageFunc.Instance.SelectById(returnkey); 
                    #endregion
                }

                //跳转到错误页面
                return View();
            }
        }
        #endregion

        #region 采购入库
        /// <summary>
        /// 采购入库
        /// </summary>
        /// <returns></returns>
        [UserAuthorize]
        public ActionResult BuyerInfo()
        {
            return View();
        }
        /// <summary>
        /// 采购入库,查看详情,送货单
        /// </summary>
        /// <returns></returns>
        public ActionResult BuyerDetailed()
        {
            var Id = HttpContext.Request.QueryString["Id"].ParseInt();
            var Buyers = BuyerFunc.Instance.SelectBuyerById(Id.Value);
            var BuyerDetaileds = BuyerFunc.Instance.SelectBuyerDetailed(Id.Value);
            if (Buyers != null || BuyerDetaileds != null)
            {
                ViewBag.BuyersInfo = Buyers;
                ViewBag.BuyersFullInfo = BuyerDetaileds;
                return View();
            }
            else
            {
                //跳转到错误页面
                return View();
            }
        }
        /// <summary>
        /// 采购入库,入库
        /// </summary>
        /// <returns></returns>
        public ActionResult BuyerDetailedInfo()
        {
            var deliverId = HttpContext.Request.QueryString["Id"].ParseInt();
            var Warehouse = WarehouseFunc.Instance.SelectWarehouse();
            var deliver = DeliverFunc.Instance.SelectById(deliverId.Value);
            ViewBag.WarehouseInfo = Warehouse;
            if (Warehouse != null || deliverId != null)
            {
                ViewBag.WarehouseInfo = Warehouse;
                ViewBag.deliverId = deliverId;
                ViewBag.Deliver = deliver;
            }
            return View();
        }
        #endregion

        #region 生产领料
        /// <summary>
        /// 生产领料
        /// </summary>
        /// <returns></returns>
        [UserAuthorize]
        public ActionResult ReceiveInfo()
        {
            return View();
        }
        /// <summary>
        /// 生产领料,查看详情
        /// </summary>
        /// <returns></returns>
        public ActionResult ReceiveDetailed()
        {
            var ReceiveId = HttpContext.Request.QueryString["Id"].ParseInt();
            var Text = HttpContext.Request.QueryString["Text"].ParseInt();
            var See = HttpContext.Request.QueryString["See"];
            var Warehouse = WarehouseFunc.Instance.SelectWarehouse();

            if (Text != null)
            {
                var OrderDetailed = ReceiveFunc.Instance.SelecOrderDetailed(ReceiveId.Value);
                var OrderInfo = Production_Orderdetail_ViewFunc.Instance.SelectById(ReceiveId.Value);
                var Receives = ReceiveFunc.Instance.SelecReceive(ReceiveId.Value);
                if (Receives != null)
                {
                    var ReceivesInfo = ReceiveFunc.Instance.SelectReceiveByDetailId(OrderDetailed[0].order_detailId.Value);
                    var ReceivesDetailed = ReceiveFunc.Instance.SelectReceiveDetailed(ReceivesInfo.ProductionId.Value);
                    if (ReceivesDetailed != null || Receives != null)
                    {
                        ViewBag.ReceiveInfo = ReceivesInfo;
                        ViewBag.ReceiveDetailedInfo = ReceivesDetailed;
                    }
                    if (See != null)
                    {
                        ViewBag.SureEnter = "确定";
                    }
                }
                ViewBag.OrderDetailedInfo = OrderDetailed;
                ViewBag.Text = OrderInfo;
            }
            else
            {
                var Receives = ReceiveFunc.Instance.SelectReceiveById(ReceiveId.Value);
                var OrderInfo = Production_Orderdetail_ViewFunc.Instance.SelectById(ReceiveId.Value);
                var ReceivesDetailed = ReceiveFunc.Instance.SelectReceiveDetailed(Receives.ProductionId.Value);
                ViewBag.Text = OrderInfo;
                ViewBag.SureEnter = "确定";
                if (ReceivesDetailed != null || Receives != null)
                {
                    ViewBag.ReceiveInfo = Receives;
                    ViewBag.ReceiveDetailedInfo = ReceivesDetailed;
                    return View();
                }
                else
                {
                    //跳转到错误页面
                    return View();
                }
            }
            ViewBag.WarehouseInfo = Warehouse;
            return View();
        }

        public ActionResult AddReciveInfo()
        {
            ViewBag.Grade = GradeFunc.Instance.GetAllGrade();
            ViewBag.Materials = Materials_Stock_ViewFunc.Instance.SelectByModel(null);

            return View();
        }
        #endregion

        #region 仓库分类
        /// <summary>
        /// 仓库分类
        /// </summary>
        /// <returns></returns>
        [UserAuthorize]
        public ActionResult WarehouseInfo()
        {
            return View();
        }
        /// <summary>
        /// 添加或修改仓库信息
        /// </summary>
        /// <returns></returns>
        public ActionResult WarehouseEdit(WarehouseRequest request)
        {
            var Warehouse = WarehouseFunc.Instance.SelectById(request.Id);
            if (Warehouse != null)
            {
                ViewBag.WarehouseFullInfo = Warehouse;
            }
            return View();
        }
        #endregion
    }
}
