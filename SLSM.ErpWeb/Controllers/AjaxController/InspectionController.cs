using Common.Filter.WebApi;
using Common.Helper;
using Common.Result;
using DbOpertion.Function;
using DbOpertion.Operation;
using SLSM.ErpWeb.Model.Request.Inspection;
using System.Linq;
using System.Web.Http;
using DbOpertion.Models;

namespace SLSM.ErpWeb.Controllers.AjaxController
{
    public class InspectionController : BaseApiController
    {
        #region 原材料品检
        /// <summary>
        /// 原材料品检是否合格操作,(写成回滚事件)
        /// </summary>
        /// <param name="requst"></param>
        /// <returns></returns>
        [HttpPost]
        public ResultJson InspectionQualified(QualifiedRequest requst)
        {
            var result = false;
            #region 原材料品检合格
            if (requst.Context == null)
            {
                result = BuyerFunc.Instance.UpdateStatus(requst.Id);
            }
            #endregion 

            #region 原材料品检不合格
            else
            {
                result = DbOpertion.Function.BuyerFunc.Instance.Update(new DbOpertion.Models.Buyer
                {
                    Id = requst.Id,
                    buyerStatus = "待退货",
                    checkStatus = "品检不合格",
                    buyerContext = requst.Context
                });
            }
            #endregion
            if (result)
            {
                return new ResultJson { HttpCode = 200, Message = "操作成功" };
            }
            else
            {
                return new ResultJson { HttpCode = 300, Message = "操作失败" };
            }
        }

        /// <summary>
        /// 后台路径
        /// </summary>
        string FileUrl = System.Configuration.ConfigurationManager.AppSettings["FileUrl"];

        /// <summary>
        /// 原材料品检是否合格操作,(写成回滚事件)
        /// </summary>
        /// <param name="requst"></param>
        /// <returns></returns>
        [HttpPost]
        public ResultJson InspectionReportInfo(QualifiedRequest requst)
        {
            var result = false;
            if (requst.ProductImageInfo.Contains("temp"))
            {
                var ProductImageInfo = "";
                var ProductImageList = requst.ProductImageInfo.Split('|').Where(p => !string.IsNullOrEmpty(p)).ToList();
                foreach (var item in ProductImageList)
                {
                    if (item.Contains("temp"))
                    {
                        var itemarray = item.Split(':').ToList();
                        FileHelper.Instance.Move(FileUrl + itemarray[1], FileUrl + $"/current/images/Material/" + itemarray[1].Split('/').Last(), FileUrl + $"/current/images/Material/");
                        itemarray[1] = $"/current/images/Material/{itemarray[1].Split('/').Last()}";
                        ProductImageInfo = $"{ProductImageInfo}{itemarray[0]}:{itemarray[1]}|";
                    }
                    else
                    {
                        ProductImageInfo = $"{ProductImageInfo}{item}|";
                    }
                }
                requst.ProductImageInfo = ProductImageInfo;
            }
            #region 原材料品检合格
            if (requst.IsQualified.ToLower() == "qualified")
            {
                result = BuyerFunc.Instance.UpdateStatus(requst.Id, requst.BadInfo, requst.ProductImageInfo, requst.IsQualified, requst.QCINSPECTOR, requst.INSPECTIONDATE);
            }
            #endregion 
            #region 原材料品检不合格
            else if (requst.IsQualified.ToLower() == "noqualified")
            {
                result = BuyerFunc.Instance.Update(new DbOpertion.Models.Buyer
                {
                    Id = requst.Id,
                    buyerStatus = "待退货",
                    checkStatus = "品检不合格",
                    buyerContext = requst.Context,
                    QCINSPECTOR = requst.QCINSPECTOR,
                    INSPECTIONDATE = requst.INSPECTIONDATE,
                    BadInfo = requst.BadInfo,
                    ProductImageInfo = requst.ProductImageInfo
                });
            }
            #endregion
            #region 原材料换货
            else if (requst.IsQualified.ToLower() == "exchangegoods")
            {
                result = BuyerFunc.Instance.Update(new Buyer
                {
                    Id = requst.Id,
                    buyerStatus = "换货",
                    checkStatus = "换货",
                    buyerContext = requst.Context,
                    QCINSPECTOR = requst.QCINSPECTOR,
                    INSPECTIONDATE = requst.INSPECTIONDATE,
                    BadInfo = requst.BadInfo,
                    ProductImageInfo = requst.ProductImageInfo
                });
                var buyer = BuyerFunc.Instance.SelectById(requst.Id);
                var deliver = DeliverFunc.Instance.SelectByModel(new Deliver { buyerId = requst.Id });
                if (buyer.ParentId != null)
                {
                    var parentbuyer = BuyerFunc.Instance.SelectById(buyer.ParentId.Value);
                    var parentdeliverlist = DeliverFunc.Instance.SelectByModel(new Deliver { buyerId = buyer.ParentId.Value });
                    foreach (var item in deliver)
                    {
                        var parentdeliver = parentdeliverlist.Where(p => p.Color == item.Color).FirstOrDefault();
                        parentdeliver.AlreadyQuantity = (parentdeliver.AlreadyQuantity == null ? 0 : parentdeliver.AlreadyQuantity) - item.buyerCount;
                        result = DeliverFunc.Instance.Update(parentdeliver);
                    }
                }

            }
            #endregion
            if (result)
            {
                return new ResultJson { HttpCode = 200, Message = "操作成功" };
            }
            else
            {
                return new ResultJson { HttpCode = 300, Message = "操作失败" };
            }
        }
        #endregion


        #region 成品品检
        [HttpPost]
        public ResultJson ProductQualified(QualifiedRequest request)
        {
            var result = false;
            if (request.ProductImageInfo.Contains("temp"))
            {
                var ProductImageInfo = "";
                var ProductImageList = request.ProductImageInfo.Split('|').Where(p => !string.IsNullOrEmpty(p)).ToList();
                foreach (var item in ProductImageList)
                {
                    if (item.Contains("temp"))
                    {
                        var itemarray = item.Split(':').ToList();
                        FileHelper.Instance.Move(FileUrl + itemarray[1], FileUrl + $"/current/images/Material/" + itemarray[1].Split('/').Last(), FileUrl + $"/current/images/Material/");
                        itemarray[1] = $"/current/images/Material/{itemarray[1].Split('/').Last()}";
                        ProductImageInfo = $"{ProductImageInfo}{itemarray[0]}:{itemarray[1]}|";
                    }
                    else
                    {
                        ProductImageInfo = $"{ProductImageInfo}{item}|";
                    }
                }
                request.ProductImageInfo = ProductImageInfo;
            }
            #region 合格
            if (request.IsQualified.ToLower() == "qualified")
            {
                result = ProductionFunc.Instance.Update(new Production { Id = request.Id, OrderStatus = "品检合格待发货", InspectionStatus = "成品品检合格", BadInfo = request.BadInfo, ProductImageInfo = request.ProductImageInfo, QCINSPECTOR = request.QCINSPECTOR, INSPECTIONDATE = request.INSPECTIONDATE, TestResults = request.Remarks });
            }
            #endregion

            #region 不合格
            else if (request.IsQualified.ToLower() == "noqualified")
            {
                result = ProductionFunc.Instance.Update(new Production { Id = request.Id, OrderStatus = "成品品检不合格", InspectionStatus = "成品品检不合格", BadInfo = request.BadInfo, ProductImageInfo = request.ProductImageInfo, QCINSPECTOR = request.QCINSPECTOR, INSPECTIONDATE = request.INSPECTIONDATE, InspectionContext = request.Context, TestResults = request.Remarks });
            }
            #endregion
            #region 换货
            else if (request.IsQualified.ToLower() == "exchangegoods")
            {
                result = ProductionFunc.Instance.Update(new Production { Id = request.Id, OrderStatus = "成品品检不合格", InspectionStatus = "成品品检不合格", BadInfo = request.BadInfo, ProductImageInfo = request.ProductImageInfo, QCINSPECTOR = request.QCINSPECTOR, INSPECTIONDATE = request.INSPECTIONDATE, InspectionContext = request.Context, TestResults = request.Remarks });
            }
            #endregion
            if (result)
            {
                return new ResultJson { HttpCode = 200, Message = "成功!" };
            }
            else
            {
                return new ResultJson { HttpCode = 300, Message = "失败!" };
            }
        }
        #endregion
    }
}
