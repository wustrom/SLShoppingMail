using Common.Extend;
using Common.Result;
using Common.ThirdParty.KdGold;
using DbOpertion.Function;
using DbOpertion.Models;
using SLSM.DBOpertion.Function;
using SLSM.DBOpertion.Model.Extend.Response.ColorRes;
using SLSM.ErpWeb.Model.Request.Table;
using SLSM.ErpWeb.Model.Response.Table;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace SLSM.AdminWeb.Controllers.AjaxController
{
    /// <summary>
    /// 表格控制器
    /// </summary>
    public class TableController : ApiController
    {
        #region 设计师管理
        /// <summary>
        /// 设计师管理
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public LayUITableResponse<List<Produtions>> GetDesigner(GetProductionRequest request)
        {
            var Status = "设计师管理";
            var List_Designer = ProductionFunc.Instance.GetProductionPage(request.pageIndex, request.pageSize, request.order, request.sort, request.name, request.Production, Status);
            LayUITableResponse<List<Produtions>> response = new LayUITableResponse<List<Produtions>>();
            foreach (var item in List_Designer.Item1)
            {
                response.list.Add(new Produtions(item));
            }
            response.count = List_Designer.Item2;
            response.rel = true;
            response.msg = "成功";
            if (response.count == 0)
            {
                response.rel = false;
                response.msg = "暂无数据";
            }
            return response;
        }
        #endregion

        #region 生产管理
        /// <summary>
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public LayUITableResponse<List<Produtions>> GetProduction(GetProductionRequest request)
        {
            var List_Production = ProductionFunc.Instance.GetProductionPage(request.pageIndex, request.pageSize, request.order, request.sort, request.name, request.Production, "生产管理");
            LayUITableResponse<List<Produtions>> response = new LayUITableResponse<List<Produtions>>();
            foreach (var item in List_Production.Item1)
            {
                response.list.Add(new Produtions(item));
            }
            response.count = List_Production.Item2;
            response.rel = true;
            response.msg = "成功";
            if (response.count == 0)
            {
                response.rel = false;
                response.msg = "暂无数据";
            }
            return response;
        }
        #endregion

        #region 客服管理
        /// <summary>
        /// 订单管理
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public LayUITableResponse<List<Produtions>> GetOrderInfo(GetProductionRequest request)
        {
            var list_Order = ProductionFunc.Instance.GetProductionPage(request.pageIndex, request.pageSize, request.order, request.sort, request.name, request.Production, "订单管理");
            LayUITableResponse<List<Produtions>> response = new LayUITableResponse<List<Produtions>>();
            foreach (var item in list_Order.Item1)
            {
                response.list.Add(new Produtions(item));
            }
            response.count = list_Order.Item2;
            response.rel = true;
            response.msg = "采购";
            if (response.count == 0)
            {
                response.rel = false;
                response.msg = "暂无数据";
            }
            return response;
        }
        #endregion

        #region 产品原材料管理
        /// <summary>
        /// 原材料管理
        /// </summary>
        /// <param name="request">请求</param>
        /// <returns></returns>
        [HttpPost]
        public LayUITableResponse<List<MaterialManger>> GetMaterialManger(GetAllBuyerInfoRequest request)
        {
            var ProduterId = request.ProduterId.ParseInt();
            List<string> materialsIds = null;
            if (ProduterId != null)
            {
                var materialsproducer = Materials_ProducerFunc.Instance.SelectByModel(new Materials_Producer { ProducerId = ProduterId });
                materialsIds = materialsproducer.Where(p => p.MaterialsId != null).Select(p => p.MaterialsId.Value.ToString()).Distinct().ToList();
            }

            //KdApiSearchDemo.Instance.getOrderTracesByJson("中通快递","218704868683");
            var List_Materials = MaterialFunc.Instance.GetLikePage(request.pageIndex, request.pageSize, request.order, request.sort, request.name, materialsIds);
            var MaterialsIDList = List_Materials.Item1.Select(p => p.Id.ToString()).ToList();
            var MaterialsStockList = Materials_Stock_ViewFunc.Instance.SelectByKeys("Raw_materialsId", MaterialsIDList);
            LayUITableResponse<List<MaterialManger>> response = new LayUITableResponse<List<MaterialManger>>();
            foreach (var item in List_Materials.Item1)
            {
                response.list.Add(new MaterialManger(item, MaterialsStockList));
            }
            response.count = List_Materials.Item2;
            response.rel = true;
            response.msg = "成功";
            if (response.count == 0)
            {
                response.rel = false;
                response.msg = "暂无数据";
            }
            return response;
        }
        /// <summary>
        /// 待采购列表
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public LayUITableResponse<List<Delivers>> GetListDeliver()
        {
            var Id = 0;
            var List_Deliver = DeliverFunc.Instance.SelectAllDeliver(Id);
            List_Deliver = List_Deliver.OrderByDescending(p => p.Id).ToList();
            LayUITableResponse<List<Delivers>> response = new LayUITableResponse<List<Delivers>>();
            foreach (var item in List_Deliver)
            {
                response.list.Add(new Delivers(item));
            }
            response.count = DeliverFunc.Instance.SelectAllDeliversCount();
            response.rel = true;
            response.msg = "成功";
            if (response.count == 0)
            {
                response.rel = false;
                response.msg = "暂无数据";
            }
            return response;
        }
        /// <summary>
        /// 采购单管理
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public LayUITableResponse<List<Buyers>> GetAllBuyerInfo(GetAllBuyerInfoRequest request)
        {
            var ProduterId = "";
            var ProducerText = HttpContext.Current.Request.QueryString["ProducerText"];
            if (ProducerText != "")
            {
                ProduterId = ProducerText;
            }
            else
            {
                ProduterId = request.ProduterId;
            }
            var List_Buyer = BuyerFunc.Instance.SelectAllBuyer(request.pageIndex, request.pageSize, request.order, request.sort, request.name, ProduterId, request.StartTime, request.EndTime, request.CheckStatus);
            LayUITableResponse<List<Buyers>> response = new LayUITableResponse<List<Buyers>>();
            foreach (var item in List_Buyer.Item1)
            {
                response.list.Add(new Buyers(item));
            }
            response.count = List_Buyer.Item2;
            response.rel = true;
            response.msg = "成功";
            response.pageno = request.pageIndex.ToString();
            if (response.count == 0)
            {
                response.rel = false;
                response.msg = "暂无数据";
            }
            return response;
        }
        /// <summary>
        /// 供应商管理
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public LayUITableResponse<List<Producers>> GetProducer(LayUITableRequest request)
        {
            var List_Producers = ProducerFunc.Instance.GetProducerPage(request.pageIndex, request.pageSize, request.order, request.sort, request.name);
            LayUITableResponse<List<Producers>> response = new LayUITableResponse<List<Producers>>();
            foreach (var item in List_Producers.Item1)
            {
                response.list.Add(new Producers(item));
            }
            response.count = List_Producers.Item2;
            response.pageno = request.pageIndex.ToString();
            response.rel = true;
            response.msg = "成功";
            if (response.count == 0)
            {
                response.rel = false;
                response.msg = "暂无数据";
            }
            return response;
        }
        #endregion

        #region 品检管理
        /// <summary>
        /// 原材料品检管理
        /// </summary>
        /// <param name="request">请求</param>
        /// <returns></returns>
        [HttpPost]
        public LayUITableResponse<List<Buyers>> GetInspectionInfo(GetInspectionInfoRequst request)
        {
            var List_Inspection = InspectionFunc.Instance.SelectInspection(request.pageIndex, request.pageSize, request.order, request.sort, request.name, request.Inspection);
            LayUITableResponse<List<Buyers>> response = new LayUITableResponse<List<Buyers>>();
            foreach (var item in List_Inspection.Item1)
            {
                response.list.Add(new Buyers(item));
            }
            response.count = List_Inspection.Item2;
            response.rel = true;
            response.msg = "成功";
            if (response.count == 0)
            {
                response.rel = false;
                response.msg = "暂无数据";
            }
            return response;
        }

        /// <summary>
        /// 成品品检
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public LayUITableResponse<List<Produtions>> GetProductInfo(GetProductionRequest request)
        {
            var List_Product = ProductionFunc.Instance.GetProductionPage(request.pageIndex, request.pageSize, request.order, request.sort, request.name, request.Production, "成品品检");
            LayUITableResponse<List<Produtions>> response = new LayUITableResponse<List<Produtions>>();
            foreach (var item in List_Product.Item1)
            {
                response.list.Add(new Produtions(item));
            }
            response.count = List_Product.Item2;
            response.rel = true;
            response.msg = "成功!";
            if (response.count == 0)
            {
                response.rel = false;
                response.msg = "暂无数据";
            }
            return response;
        }
        #endregion

        #region 仓库管理
        /// <summary>
        /// 库存管理信息
        /// </summary>
        /// <param name="request">请求</param>
        /// <returns></returns>
        [HttpPost]
        public LayUITableResponse<List<Storages>> GetStorageInfo(LayUITableRequest request)
        {

            var List_Storage = StorageFunc.Instance.SelectStorage(request.pageIndex, request.pageSize, request.order, request.sort, request.name);
            LayUITableResponse<List<Storages>> response = new LayUITableResponse<List<Storages>>();
            foreach (var item in List_Storage.Item1)
            {
                response.list.Add(new Storages(item));
            }
            response.count = List_Storage.Item2;
            response.rel = true;
            response.msg = "成功";
            response.pageno = request.pageIndex.ToString();
            if (response.count == 0)
            {
                response.rel = false;
                response.msg = "暂无数据";
            }
            return response;
        }

        /// <summary>
        /// 库存管理信息
        /// </summary>
        /// <param name="request">请求</param>
        /// <returns></returns>
        [HttpPost]
        public LayUITableResponse<List<Storages>> GetStorageBuyerInfo(GetAllBuyerInfoRequest request)
        {
            var ProduterId = request.ProduterId.ParseInt();
            List<string> materialsIds = null;
            if (ProduterId != null)
            {
                var materialsproducer = Materials_ProducerFunc.Instance.SelectByModel(new Materials_Producer { ProducerId = ProduterId });
                materialsIds = materialsproducer.Where(p => p.MaterialsId != null).Select(p => p.MaterialsId.Value.ToString()).Distinct().ToList();
            }
            var List_Storage = StorageFunc.Instance.SelectMaterial_Stock_View(request.pageIndex, request.pageSize, request.order, request.sort, request.name, materialsIds);
            LayUITableResponse<List<Storages>> response = new LayUITableResponse<List<Storages>>();
            foreach (var item in List_Storage.Item1)
            {
                response.list.Add(new Storages(item));
            }
            response.count = List_Storage.Item2;
            response.rel = true;
            response.msg = "成功";
            response.pageno = request.pageIndex.ToString();
            if (response.count == 0)
            {
                response.rel = false;
                response.msg = "暂无数据";
            }
            return response;
        }

        /// <summary>
        /// 库存变动统计
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public LayUITableResponse<List<ChangeStorages>> GetChangeStorageInfo(GetChangeStorageInfoRequest request)
        {
            var List_Change = ChangesFunc.Instance.SelectChange(request.pageIndex, request.pageSize, request.order, request.sort, request.name, request.storageId);
            LayUITableResponse<List<ChangeStorages>> response = new LayUITableResponse<List<ChangeStorages>>();
            foreach (var item in List_Change.Item1)
            {
                response.list.Add(new ChangeStorages(item));
            }
            response.count = List_Change.Item2;
            response.rel = true;
            response.msg = "成功";
            response.pageno = request.pageIndex.ToString();
            if (response.count == 0)
            {
                response.rel = false;
                response.msg = "暂无数据";
            }
            return response;
        }
        /// <summary>
        /// 采购入库管理信息
        /// </summary>
        /// <param name="request">请求</param>
        /// <returns></returns>
        [HttpPost]
        public LayUITableResponse<List<Buyers>> GetBuyerInfo(LayUITableRequest request)
        {
            var List_Buyer = BuyerFunc.Instance.SelectBuyer(request.pageIndex, request.pageSize, request.order, request.sort, request.name);
            LayUITableResponse<List<Buyers>> response = new LayUITableResponse<List<Buyers>>();
            foreach (var item in List_Buyer.Item1)
            {
                response.list.Add(new Buyers(item));
            }
            response.count = List_Buyer.Item2;
            response.pageno = request.pageIndex.ToString();
            response.rel = true;
            response.msg = "成功";
            if (response.count == 0)
            {
                response.rel = false;
                response.msg = "暂无数据";
            }
            return response;
        }
        /// <summary>
        /// 生产领料管理信息
        /// </summary>
        /// <param name="request">请求</param>
        /// <returns></returns>
        [HttpPost]
        public LayUITableResponse<List<Receives>> GetReceivesInfo(LayUITableRequest request)
        {
            var List_Receives = ReceiveFunc.Instance.SelectBuyer(request.pageIndex, request.pageSize, request.order, request.sort, request.name);
            LayUITableResponse<List<Receives>> response = new LayUITableResponse<List<Receives>>();
            foreach (var item in List_Receives.Item1)
            {
                response.list.Add(new Receives(item));
            }
            response.count = List_Receives.Item2;
            response.rel = true;
            response.msg = "成功";
            response.pageno = request.pageIndex.ToString();
            if (response.count == 0)
            {
                response.rel = false;
                response.msg = "暂无数据";
            }
            return response;
        }
        /// <summary>
        ///  仓库管理信息
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public LayUITableResponse<List<Warehouses>> GetWarehouseInfo()
        {
            var List_Warehouse = WarehouseFunc.Instance.SelectWarehouse();
            LayUITableResponse<List<Warehouses>> response = new LayUITableResponse<List<Warehouses>>();
            foreach (var item in List_Warehouse)
            {
                response.list.Add(new Warehouses(item));
            }
            response.count = WarehouseFunc.Instance.SelectAllWarehouseCount();
            response.rel = true;
            response.msg = "成功";
            if (response.count == 0)
            {
                response.rel = false;
                response.msg = "暂无数据";
            }
            return response;
        }
        #endregion

        #region 财务管理
        /// <summary>
        /// 应付账款
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public LayUITableResponse<List<Buyers>> GetFinance(GetAllBuyerInfoRequest request)
        {
            var List_Finance = BuyerFunc.Instance.SelectBuyerFinance(request.pageIndex, request.pageSize, request.order, request.sort, request.name, request.ProduterId, request.StartTime, request.EndTime);
            LayUITableResponse<List<Buyers>> response = new LayUITableResponse<List<Buyers>>();
            foreach (var item in List_Finance.Item1)
            {
                response.list.Add(new Buyers(item));
            }
            response.count = List_Finance.Item2;
            response.rel = true;
            response.msg = "成功";
            response.pageno = request.pageIndex.ToString();
            if (response.count == 0)
            {
                response.rel = false;
                response.msg = "暂无数据";
            }
            return response;
        }
        /// <summary>
        /// 供应商发票
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public LayUITableResponse<List<Producer_Invoice_Views>> GetInvoice(GetAllBuyerInfoRequest request)
        {

            var ProduterId = "";
            var ProduterSelectId = HttpContext.Current.Request.QueryString["ProduterSelectId"];
            if (ProduterSelectId != null)
            {
                ProduterId = ProduterSelectId;
            }
            else
            {
                ProduterId = request.ProduterId;
            }
            var List_Invoice = ProducerFunc.Instance.GetInvoicePage(request.pageIndex, request.pageSize, request.order, request.sort, request.name, ProduterId);
            LayUITableResponse<List<Producer_Invoice_Views>> response = new LayUITableResponse<List<Producer_Invoice_Views>>();
            foreach (var item in List_Invoice.Item1)
            {
                response.list.Add(new Producer_Invoice_Views(item));
            }
            response.count = List_Invoice.Item2;
            response.rel = true;
            response.msg = "成功";
            response.pageno = request.pageIndex.ToString();
            if (response.count == 0)
            {
                response.rel = false;
                response.msg = "暂无数据";
            }
            return response;
        }
        #endregion

        #region 发货管理
        /// <summary>
        /// 发货处理
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public LayUITableResponse<List<Produtions>> GetConsignmentInfo(GetProductionRequest request)
        {
            var List_Produtions = ProductionFunc.Instance.GetProductionPage(request.pageIndex, request.pageSize, request.order, request.sort, request.name, request.Production, "发货管理");
            LayUITableResponse<List<Produtions>> response = new LayUITableResponse<List<Produtions>>();
            foreach (var item in List_Produtions.Item1)
            {
                response.list.Add(new Produtions(item));
            }
            response.count = List_Produtions.Item2;
            response.rel = true;
            response.msg = "成功!";
            if (response.count == 0)
            {
                response.rel = false;
                response.msg = "暂无数据";
            }
            return response;
        }
        #endregion

        #region 工艺设备管理
        /// <summary>
        /// 定制工艺信息
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public LayUITableResponse<List<Technologys>> GetTechnologyInfo()
        {
            var List_Technology = TechnologyFunc.Instance.SelectTechnology();
            LayUITableResponse<List<Technologys>> response = new LayUITableResponse<List<Technologys>>();
            foreach (var item in List_Technology)
            {
                response.list.Add(new Technologys(item));
            }
            response.count = TechnologyFunc.Instance.SelectTechnologyCount();
            response.rel = true;
            response.msg = "成功";
            if (response.count == 0)
            {
                response.rel = false;
                response.msg = "暂无数据";
            }
            return response;
        }

        /// <summary>
        /// 获取颜色列表
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public LayUITableResponse<List<ColorRes>> GetColorList()
        {
            var List_Color = ColorinfoFunc.Instance.GetColorList();
            LayUITableResponse<List<ColorRes>> response = new LayUITableResponse<List<ColorRes>>();
            response.count = 1;
            response.rel = true;
            response.msg = "成功";
            response.list = List_Color;
            if (response.count == 0)
            {
                response.rel = false;
                response.msg = "暂无数据";
            }
            return response;
        }
        #endregion

        #region 账号权限设置
        /// <summary>
        /// 管理平台账号权限
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public LayUITableResponse<List<Erpusers>> GetErpUserInfo()
        {
            var List_ErpUser = ErpuserFunc.Instance.SelectByModel(new DbOpertion.Models.Erpuser { });
            LayUITableResponse<List<Erpusers>> response = new LayUITableResponse<List<Erpusers>>();
            foreach (var item in List_ErpUser)
            {
                response.list.Add(new Erpusers(item));
            }
            response.count = ErpuserFunc.Instance.SelectCount(new DbOpertion.Models.Erpuser { });
            response.rel = true;
            response.msg = "成功";
            if (response.count == 0)
            {
                response.rel = false;
                response.msg = "暂无数据";
            }
            return response;
        }
        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public LayUITableResponse<List<Erplogin_Role_Views>> GetErpLoginInfo(LayUITableRequest request)
        {

            var List_Storage = Erplogin_Role_ViewFunc.Instance.SelectloginUser(request.pageIndex, request.pageSize, request.order, request.sort, request.name);
            LayUITableResponse<List<Erplogin_Role_Views>> response = new LayUITableResponse<List<Erplogin_Role_Views>>();
            foreach (var item in List_Storage.Item1)
            {
                response.list.Add(new Erplogin_Role_Views(item));
            }
            response.count = List_Storage.Item2;
            response.rel = true;
            response.msg = "成功";
            response.pageno = request.pageIndex.ToString();
            if (response.count == 0)
            {
                response.rel = false;
                response.msg = "暂无数据";
            }
            return response;
        }
        #endregion
    }
}