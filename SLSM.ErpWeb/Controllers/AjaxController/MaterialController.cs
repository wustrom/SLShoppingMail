using Common.Extend;
using Common.Filter.WebApi;
using Common.Helper;
using Common.Result;
using DbOpertion.Function;
using DbOpertion.Models;
using DbOpertion.Operation;
using SLSM.DBOpertion.Model.Extend.Request.Purchasing;
using SLSM.DBOpertion.Model.Extend.Response.ColorRes;
using SLSM.DBOpertion.Model.Request.Material;
using SLSM.ErpWeb.Model.Request;
using SLSM.ErpWeb.Model.Request.Deceive;
using SLSM.ErpWeb.Model.Request.Material;
using SLSM.ErpWeb.Model.Request.wantBuyerInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Results;

namespace SLSM.ErpWeb.Controllers.AjaxController
{

    /// <summary>
    /// 原材料控制器
    /// </summary>
    public class MaterialController : BaseApiController
    {
        /// <summary>
        /// 管理员路径
        /// </summary>
        string AdminUrl = System.Configuration.ConfigurationManager.AppSettings["AdminUrl"];
        /// <summary>
        /// 后台路径
        /// </summary>
        string FileUrl = System.Configuration.ConfigurationManager.AppSettings["FileUrl"];
        #region 产品原材料管理

        #region 原材料管理
        /// <summary>
        /// 修改原材料信息
        /// </summary>
        /// <param name="request">请求</param>
        /// <returns></returns>
        public ResultJson EditMaterialInfo(EditMaterialRequest request)
        {
            ResultJson result = new ResultJson();

            #region 判断销售信息是否完整
            List<SalesInfo> SalesList = new List<SalesInfo>();
            foreach (var item in request.SalesList)
            {
                if (item.ShopQuantity != "" && item.ChinaPrice != "" && item.ChinaDiscountRate != "" && item.DollarPrice != "" && item.DollarDiscountRate != "")
                {
                    SalesList.Add(item);

                }
            }
            request.SalesList = SalesList;
            if (request.SalesList.Count == 0)
            {
                result.HttpCode = 300;
                result.Message = "请至少输入一条完整销售信息";
                return result;
            }
            #endregion

            #region 判断印刷信息是否完整
            List<PrintDetailInfo> PrintList = new List<PrintDetailInfo>();
            foreach (var item in request.PrintList)
            {
                if (item.MaximumArea != "" && item.PositionDescription != "" && item.PrintableColor != "" && item.PrintFunc != "" && item.PrintingPosition != "" && item.PrintingProcess != "" && item.PrintingProcess != "-1")
                {
                    PrintList.Add(item);
                }
            }
            request.PrintList = PrintList;
            //if (request.PrintList.Count == 0)
            //{
            //    result.HttpCode = 300;
            //    result.Message = "至少有一条完整印刷信息";
            //    return result;
            //}
            #endregion

            #region 产品
            var producerCount = request.producer.Select(p => p.ProdecerCode).Distinct().ToList().Count;
            if (producerCount != request.producer.Count)
            {
                result.HttpCode = 300;
                result.Message = "颜色请不要重复";
                return result;
            }
            #endregion

            #region 颜色图片
            var ColorCount = request.ColorList.Select(p => p.ColorID).Distinct().ToList().Count;
            if (ColorCount != request.ColorList.Count)
            {
                result.HttpCode = 300;
                result.Message = "颜色请不要重复";
                return result;
            }
            foreach (var item in request.ColorList)
            {
                item.SKUImage = item.SKUImage.Replace(AdminUrl, "");
                if (item.SKUImage != null && item.SKUImage.Contains("temp"))
                {
                    if (item.SKUImage.Contains("temp"))
                    {
                        FileHelper.Instance.Move(FileUrl + item.SKUImage, FileUrl + $"/current/images/Material/" + item.SKUImage.Split('/').Last(), FileUrl + $"/current/images/Material/");
                        item.SKUImage = $"/current/images/Material/{item.SKUImage.Split('/').Last()}";
                    }
                }
                item.PrintInfo = "";
                foreach (var PrintItem in item.Print)
                {
                    PrintItem.ColorInfo_Diagram = PrintItem.ColorInfo_Diagram.Replace(AdminUrl, "");
                    if (PrintItem.ColorInfo_Diagram != null && PrintItem.ColorInfo_Diagram.Contains("temp"))
                    {
                        if (PrintItem.ColorInfo_Diagram.Contains("temp"))
                        {
                            FileHelper.Instance.Move(FileUrl + PrintItem.ColorInfo_Diagram, FileUrl + $"/current/images/Material/" + PrintItem.ColorInfo_Diagram.Split('/').Last(), FileUrl + $"/current/images/Material/");
                            PrintItem.ColorInfo_Diagram = $"/current/images/Material/{PrintItem.ColorInfo_Diagram.Split('/').Last()}";
                        }
                    }
                    item.PrintInfo = $"{item.PrintInfo}{PrintItem.Print},{PrintItem.PositionDescrip},{PrintItem.ColorInfo_Diagram}|";
                }
            }
            #endregion

            if (Raw_MaterialsFunc.Instance.UpdateMateroalsInfo(request))
            {
                ColorinfoFunc.Instance.ReSetList();
                CommodityFunc.Instance.ReGetAllCommList();
                result.HttpCode = 200;
                result.Message = "更新成功！";
                return result;
            }
            else
            {
                result.HttpCode = 300;
                result.Message = "程序出现个小问题，请重新操作！";
                return result;
            }
        }

        /// <summary>
        /// 加入采购列表
        /// </summary>
        /// <param name="request">请求</param>
        /// <returns></returns>
        [HttpPost]
        public ResultJson BuyMaterial(BuyMaterialRequest request)
        {
            if (DeliverFunc.Instance.Insert(new Deliver { buyerId = 0, Raw_materialsId = request.MaterialId, ProducerId = request.producerList_ProdecerCode, buyerCount = request.BuyerNum, IsStatus = "待处理", Color = request.ColorInfo_SKU, buyerPrice = request.producerList_PurchasePrice, DeliverMoney = request.BuyerNum * request.producerList_PurchasePrice }))
            {
                return new ResultJson { HttpCode = 200, Message = "采购列表添加成功！" };
            }
            else
            {
                return new ResultJson { HttpCode = 300, Message = "采购列表添加失败！" };
            }
        }

        /// <summary>
        /// 删除原材料信息
        /// </summary>
        /// <param name="request">请求</param>
        /// <returns></returns>
        [HttpPost]
        public ResultJson DeleteMaterial(IdRequest request)
        {
            if (Raw_MaterialsOper.Instance.Update(new Raw_Materials { Id = request.Id, IsDelete = true }))
            {
                return new ResultJson { HttpCode = 200, Message = "删除成功" };
            }
            else
            {
                return new ResultJson { HttpCode = 300, Message = "删除失败，请确定记录是否存在！" };
            }
        }

        /// <summary>
        /// 根据色系获得颜色列表
        /// </summary>
        /// <param name="request">请求</param>
        /// <returns></returns>
        [HttpPost]
        public ResultJson<ColorRes> ColorListBySystem(IdRequest request)
        {
            var colorList = ColorinfoFunc.Instance.GetColorListBase();
            var colorInfoList = colorList.Where(p => p.ParentId == request.Id).ToList();
            List<ColorRes> ColorResList = new List<ColorRes>();
            foreach (var item in colorInfoList)
            {
                ColorResList.Add(new ColorRes(item));
            }
            return new ResultJson<ColorRes> { HttpCode = 200, Message = "颜色列表获取成功", ListData = ColorResList };
        }
        #endregion

        #region 待采购列表
        /// <summary>
        /// 判断是单个删除还是全部删除待采购列表数据
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public ResultJson DeleteDeliverInfo(WantbuyerInfoRequest request)
        {
            var result = false;

            #region 删除全部
            if (request == null || request.Id == 0 || request.Id == null)
            {
                result = DeliverFunc.Instance.DeleteListDeliver();
            }
            #endregion

            #region 单个删除
            else
            {
                result = DeliverFunc.Instance.DeleteModel(new Deliver { Id = request.Id.Value });
            }
            #endregion
            if (result)
            {
                return new ResultJson { HttpCode = 200, Message = "删除成功!" };
            }
            else
            {
                return new ResultJson { HttpCode = 300, Message = "删除失败!请再次尝试！" };
            }
        }
        /// <summary>
        /// 批量生成采购单
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public ResultJson ListBuyerInfo(DeliverRequest request)
        {
            if (request.Ids == "0")
            {
                return new ResultJson { HttpCode = 200, Message = "请至少选择一个采购项!" };
            }
            if (DeliverFunc.Instance.UpdateListDeliver(request.Ids))
            {
                return new ResultJson { HttpCode = 200, Message = "生成采购单成功!" };
            }
            else
            {
                return new ResultJson { HttpCode = 300, Message = "失败!请再次尝试！" };
            }
        }
        #endregion

        #region 采购单管理
        /// <summary>
        /// 待下单数据删除
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public ResultJson DeleteDeliverById(DeliverRequest request)
        {
            if (DeliverFunc.Instance.DeleteDeliverById(request.Id))
            {
                return new ResultJson { HttpCode = 200, Message = "删除成功!" };
            }
            else
            {
                return new ResultJson { HttpCode = 300, Message = "删除失败!请再次尝试！" };
            }
        }

        /// <summary>
        /// 打印合同,或者取消订单
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ResultJson PrintContract(DeliverRequest request)
        {
            if (DeliverFunc.Instance.UpdatePrintContract(request.Id, request.Status, request.CheckStatus, request.ContractNumber, request.SignedTime, request.SLSMContacts, request.SLSMPhone, request.SLSMFaxNumber, request.SLSMEmail, request.ContractContext, request.DeliverCountext, request.SinglePerson))
            {
                return new ResultJson { HttpCode = 200, Message = "成功!" };
            }
            else
            {
                return new ResultJson { HttpCode = 300, Message = "失败!请再次尝试！" };
            }
        }
        /// <summary>
        /// 退货处理
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ResultJson Return(DeliverRequest request)
        {
            if (BuyerFunc.Instance.UpdateBuyer(request.Id))
            {
                return new ResultJson { HttpCode = 200, Message = "成功!" };
            }
            else
            {
                return new ResultJson { HttpCode = 300, Message = "失败!请再次尝试!" };
            }
        }
        /// <summary>
        /// 送货单打印
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public ResultJson PrintDeliver(DeliverRequest request)
        {
            if (BuyerFunc.Instance.Update(new Buyer { Id = request.Id, DeliverCompany = request.DeliverCompany, DeeliverExpressNo = request.DeeliverExpressNo, DeliverSinglePerson = request.DeliverSinglePerson, DeliverSingleTime = DateTime.Now }))
            {
                return new ResultJson { HttpCode = 200, Message = "成功!" };
            }
            else
            {
                return new ResultJson { HttpCode = 300, Message = "操作失败,请重试!" };
            }
        }
        #endregion

        #region 供应商管理
        /// <summary>
        /// 编辑供应商信息
        /// </summary>
        /// <param name="request">请求</param>
        /// <returns></returns>
        [HttpPost]
        public ResultJson EditProducter(EditProducerRequest request)
        {
            int result = 0;
            #region 基础信息

            #region 模型建立
            var producer = new Producer
            {
                Id = request.Id,
                Name = request.Name,
                AddressRegion = request.AddressRegion,
                Address = request.Address,
                identify = request.identify,
                Bank = request.Bank,
                AccountNumber = request.AccountNumber,
                AccountPeriod = request.AccountPeriod,
                SupplyProducts = request.SupplyProducts,
                Abbreviation = request.Abbreviation,
                CompanyWebsite = request.CompanyWebsite,
                CooperationLevel = request.CooperationLevel,
                CreditRating = request.CreditRating,
                EnterLegPerson = request.EnterLegPerson,
                FaxNumber = request.FaxNumber,
                ProducerCode = request.ProducerCode,
                RaiseTicket = request.RaiseTicket,
                ZipCode = request.ZipCode
            };
            #endregion

            #endregion

            #region 新增
            if (request.Id == 0)
            {
                result = ProducerOper.Instance.InsertReturnKey(producer);
                ProducerconectinfoOper.Instance.DeleteModel(new Producerconectinfo { ProducerId = request.Id });
                foreach (var item in request.listProducer)
                {
                    ProducerconectinfoOper.Instance.Insert(new Producerconectinfo { ConectSex = item.ConectSex, ConectName = item.ConectName, Email = item.Email, Phone = item.Phone, Position = item.Position, ProducerId = result, Telephone = item.Telephone });
                }
            }
            #endregion

            #region 修改
            else
            {
                result = ProducerOper.Instance.Update(producer) == true ? 1 : 0;
                ProducerconectinfoOper.Instance.DeleteModel(new Producerconectinfo { ProducerId = request.Id });
                foreach (var item in request.listProducer)
                {
                    ProducerconectinfoOper.Instance.Insert(new Producerconectinfo { ConectSex = item.ConectSex, ConectName = item.ConectName, Email = item.Email, Phone = item.Phone, Position = item.Position, ProducerId = request.Id, Telephone = item.Telephone });
                }
            }
            #endregion
            if (result > 0)
            {
                return new ResultJson { HttpCode = 200, Message = "成功" };
            }
            else
            {
                return new ResultJson { HttpCode = 300, Message = "失败,请再次尝试！" };
            }
        }


        /// <summary>
        /// 删除供应商信息
        /// </summary>
        /// <param name="request">请求</param>
        /// <returns></returns>
        [HttpPost]
        public ResultJson DeleteProducter(IdRequest request)
        {
            if (DbOpertion.Function.ProducerFunc.Instance.Update(new Producer { Id = request.Id, IsDelete = true }))
            {
                return new ResultJson { HttpCode = 200, Message = "删除成功" };
            }
            else
            {
                return new ResultJson { HttpCode = 300, Message = "删除失败，请确定记录是否存在！" };
            }
        }
        #endregion
        #endregion

        #region MyRegion
        public ResultJson PurchasingSubmenu(PurchasingSubmenuRequest request)
        {
            var NumCount = 0;
            foreach (var item in request.SubmenuList)
            {
                NumCount = NumCount + item.number;
            }
            if (NumCount == 0)
            {
                return new ResultJson { HttpCode = 300, Message = "品检数量不能为0！" };
            }
            var listId = request.SubmenuList.Select(p => p.itemid.ToString()).ToList();
            var deliverList = DeliverFunc.Instance.SelectByKeys("Id", listId);
            foreach (var item in deliverList)
            {
                var submenuItem = request.SubmenuList.Where(p => p.itemid == item.Id).FirstOrDefault();
                if (submenuItem != null)
                {
                    if ((submenuItem.number + item.AlreadyQuantity) > item.buyerCount)
                    {
                        return new ResultJson { HttpCode = 300, Message = "此次数量不能大于未到数量！" };
                    }
                }
            }
            var buyer = BuyerFunc.Instance.CrateSubmenu(request);

            return null;
        }
        #endregion

    }

}