using Common;
using System.Collections.Generic;
using DbOpertion.Operation;
using DbOpertion.Models;
using SLSM.DBOpertion.Model.Request.Material;
using Common.Helper;
using Common.Extend;
using System.Linq;

namespace DbOpertion.Function
{
    public partial class Raw_MaterialsFunc : SingleTon<Raw_MaterialsFunc>
    {
        /// <summary>
        /// 更新原材料信息
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public bool UpdateMateroalsInfo(EditMaterialRequest request)
        {
            var MysqlHelper = SqlHelper.GetMySqlHelper("transaction");
            var connection = MysqlHelper.CreatConn();
            var transaction = MysqlHelper.GetTransaction();
            try
            {
                #region 更新原材料信息
                var SalesInfoList = "";
                var Key = request.MaterialId;
                foreach (var item in request.SalesList)
                {
                    SalesInfoList = SalesInfoList + "|" + item.ShopQuantity + "|" + item.ChinaPrice + "|" + item.ChinaDiscountRate + "|" + item.DollarPrice + "|" + item.DollarDiscountRate + ";";
                }
                var PrintInfoList = "";
                for (int i = 1; i <= 3; i++)
                {
                    var printdetailList = request.PrintList.Where(p => p.PrintFunc.ToLower() == $"printfunc{i}").ToList();
                    PrintInfoList = $"{PrintInfoList}PrintFunc{i}(";
                    foreach (var item in printdetailList)
                    {
                        PrintInfoList = $"{PrintInfoList}{item.PrintingProcess},{item.PrintingPosition},{item.PositionDescription},{item.MaximumArea},{item.PrintableColor}|";
                    }
                    PrintInfoList = $"{PrintInfoList})";
                }
                Raw_Materials materials = new Raw_Materials
                {
                    Attributes = request.Attributes,
                    ChinaProductName = request.ChinaProductName,
                    ChinaUnit = request.ChinaUnit,
                    Description = request.ChinaDescibe,
                    ProductDesibe = request.ProductDesibe,
                    DevePerson = request.DevePerson,
                    DeveTime = request.DeveTime,
                    EnglishProductName = request.EnglishProductName,
                    EnglishUnit = request.EnglishUnit,
                    Genera = request.Genera,
                    HSCODE = request.HSCODE,
                    Id = request.MaterialId,
                    MatAndPro = request.MatAndPro,
                    NetWeight = request.NetWeight,
                    NumMiddleBoxes = request.NumMiddleBoxes,
                    NumOuterBoxes = request.NumOuterBoxes,
                    OuterBoxesHeight = request.OuterBoxesHeight,
                    OuterBoxesLength = request.OuterBoxesLength,
                    OuterBoxesVolume = request.OuterBoxesVolume,
                    OuterBoxesWidth = request.OuterBoxesWidth,
                    ProductNo = request.ProductNo,
                    Specification = request.Specification,
                    TaxRate = request.TaxRate,
                    Weight = request.Weight,
                    Subclass = request.Subclass,
                    SalesInfoList = SalesInfoList,
                    SyloonPatent = request.SyloonPatent,
                    EngDescription = request.EngDescibe,
                    TypeInfo = request.Attributes1 + "|" + request.Attributes2 + "|" + request.Attributes3 + "|" + request.Attributes4,
                    PrintFuncInfo = "PrintFunc1:" + request.PrintFunc1 + "|" + "PrintFunc2:" + request.PrintFunc2 + "|" + "PrintFunc3:" + request.PrintFunc3 + "|",
                    Printingdetail = PrintInfoList,
                    PercentageInfo = "PrintFunc1:" + request.Percentage1 + "|" + "PrintFunc2:" + request.Percentage2 + "|" + "PrintFunc3:" + request.Percentage3 + "|",
                    TipPercentInfo = "PrintFunc1:" + request.TipPercent1 + "|" + "PrintFunc2:" + request.TipPercent2 + "|" + "PrintFunc3:" + request.TipPercent3 + "|"
                };
                #region 根据Id判断是插入还是新建
                if (request.MaterialId == 0)
                {
                    Key = Raw_MaterialsOper.Instance.InsertReturnKey(materials, connection, transaction);
                    if (Key <= 0)
                    {
                        transaction.Rollback();
                        connection.Close();
                        return false;
                    }
                }
                else
                {
                    if (!Raw_MaterialsOper.Instance.Update(materials, connection, transaction))
                    {
                        transaction.Rollback();
                        connection.Close();
                        return false;
                    }
                }
                #endregion

                #endregion

                #region 更新采购信息
                #region 删除原有信息
                Materials_ProducerOper.Instance.DeleteModel(new Materials_Producer { MaterialsId = Key }, connection, transaction);
                #endregion

                #region 遍历插入
                foreach (var item in request.producer)
                {
                    Materials_Producer producer = new Materials_Producer
                    {
                        MaterialsId = Key,
                        MinQuantity = item.MinQuantity,
                        ProCycle = item.ProCycle,
                        FactoryNumber = item.FactoryNumber,
                        PurchasePrice = item.PurchasePrice,
                        QuotationDate = item.QuotationDate,
                        ProducerId = item.ProdecerCode,
                        PriceTag = item.PriceTag
                    };
                    if (!Materials_ProducerOper.Instance.Insert(producer, connection, transaction))
                    {
                        transaction.Rollback();
                        connection.Close();
                        return false;
                    }
                }
                #endregion
                #endregion

                #region 更新颜色信息
                #region 删除原有信息
                Materials_ColorinfoOper.Instance.DeleteModel(new Materials_Colorinfo { MaterialsId = Key }, connection, transaction);
                #endregion

                #region 遍历插入
                foreach (var item in request.ColorList)
                {
                    var returnkey = 0;
                    if (item.ColorID == -1)
                    {
                        returnkey = ColorinfoFunc.Instance.InsertReturnKey(new Colorinfo { StandardColor = item.PantongColor, ChinaDescribe = item.ColorDesc, EngDescibe = item.EngColorDesc, HtmlCode = item.HtmlCode, ParentId = item.ColorSystem.ParseInt(), IsDelete = false });
                    }
                    Materials_Colorinfo colorinfo = new Materials_Colorinfo
                    {
                        ColorId = item.ColorID == -1 ? returnkey : item.ColorID,
                        MaterialsId = Key,
                        MinStockNum = item.MinStock,
                        SKU = item.SKU,
                        SKUImage = item.SKUImage,
                        PositionInfo = item.PrintInfo
                    };
                    if (!Materials_ColorinfoOper.Instance.Insert(colorinfo, connection, transaction))
                    {
                        transaction.Rollback();
                        connection.Close();
                        return false;
                    }
                }
                #endregion
                #endregion

                #region 找到对应商品
                var commdityList = CommodityOper.Instance.SelectAll(new Commodity { MaterialId = Key }, null, connection, transaction);
                foreach (var commdity in commdityList)
                {
                    Commodity comm = new Commodity();
                    comm.Id = commdity.Id;
                    #region 价格列表
                    var commodityzero = Commodity_Stage_PriceOper.Instance.SelectAll(new Commodity_Stage_Price { StageAmount = 0, CommodityId = commdity.Id }, null, connection, transaction).FirstOrDefault();
                    Commodity_Stage_PriceOper.Instance.DeleteModel(new Commodity_Stage_Price { CommodityId = commdity.Id }, connection, transaction);
                    foreach (var item in request.SalesList)
                    {
                        if (!Commodity_Stage_PriceOper.Instance.Insert(new Commodity_Stage_Price { StageAmount = item.ShopQuantity.ParseInt(), DiscountRate = item.ChinaDiscountRate.ParseDouble(), StagePrice = item.ChinaPrice.ParseDecimal(), CommodityId = commdity.Id }, connection, transaction))
                        {
                            transaction.Rollback();
                            connection.Close();
                            return false;
                        }
                    }
                    if (!Commodity_Stage_PriceOper.Instance.Insert(new Commodity_Stage_Price { StageAmount = 0, DiscountRate = 0, StagePrice = commodityzero != null ? commodityzero.StagePrice : (decimal)2.0, CommodityId = commdity.Id }, connection, transaction))
                    {
                        transaction.Rollback();
                        connection.Close();
                        return false;
                    }
                    #endregion

                    #region 设置颜色图片
                    var MaterialColorList = "";
                    var MaterialColorInfo = "";
                    var colorInfoList = ColorinfoFunc.Instance.GetColorListBase();
                    var Material_ColorList = Materials_ColorinfoOper.Instance.SelectAll(new Materials_Colorinfo { MaterialsId = Key }, null, connection, transaction);
                    foreach (var item in Material_ColorList)
                    {
                        var thisColorInfo = colorInfoList.Where(p => p.Id == item.ColorId).FirstOrDefault();
                        if (thisColorInfo != null)
                        {
                            MaterialColorInfo = $"{MaterialColorInfo}{item.ColorId};{item.SKUImage}|";
                            MaterialColorList = $"{MaterialColorList}{thisColorInfo.Id},";
                        }
                    }
                    comm.Color = MaterialColorList;
                    var ImageList = commdity.ImageList.Split('|').Where(p => !string.IsNullOrEmpty(p)).Where(p => !p.Contains(';')).ToList();
                    comm.ImageList = $"{ImageList.ConvertToStr("|")}{MaterialColorInfo}";
                    #endregion

                    #region 设置位置
                    var Position = "";
                    foreach (var item in Material_ColorList)
                    {
                        Position = $"{Position}{item.ColorId}({item.PositionInfo})";
                    }
                    #endregion
                    comm.GradeId = request.Genera.ParseInt().Value;
                    if (!CommodityOper.Instance.Update(comm, connection, transaction))
                    {
                        transaction.Rollback();
                        connection.Close();
                        return false;
                    }
                }
                #endregion

                transaction.Commit();
                connection.Close();
                return true;
            }
            catch (System.Exception ex)
            {
                transaction.Rollback();
                connection.Close();
                throw ex;
            }
        }
    }
}
