using Common;
using Common.Extend;
using Common.Helper;
using DbOpertion.Models;
using DbOpertion.Operation;
using SLSM.DBOpertion.Model.Extend.Response.CommodityRes;
using SLSM.DBOpertion.Model.Extend.Response.GradeRes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbOpertion.Function
{
    /// <summary>
    /// 之后简化方法 2018-5-2(吴哲)
    /// </summary>
    public partial class CommodityFunc : SingleTon<CommodityFunc>
    {
        public List<Commodity_Stageprice_View> GetListCommViewByGrade(GradeRes g)
        {
            var ids = GetGradeIdsByGradeRes(g);
            Commodity_Stageprice_View c = new Commodity_Stageprice_View
            {
                GradeId = 1
            };
            return Commodity_Stageprice_ViewOper.Instance.SelectByGradeIds(c, null, null, ids);
            //return CommodityspviewOper.Instance.SelectByGradeIds(c, null, null, ids);
        }
        /// <summary>
        /// 获取各个价格区间内的商品数量
        /// </summary>
        /// <returns></returns>
        public List<CommPrice_Amount_CommIds> GetPriceCount(List<Commodity_Stageprice_View> listCommView)
        {
            List<decimal> prices = new List<decimal>
            {
                0.99m,
                1.99m
            };

            List<CommPrice_Amount_CommIds> listR = new List<CommPrice_Amount_CommIds>();

            foreach (var item in prices)
            {
                CommPrice_Amount_CommIds c = new CommPrice_Amount_CommIds();
                c.amount = 0;
                c.price = item;
                c.commIds = new List<int>();
                listR.Add(c);
            }

            foreach (var item in listCommView)
            {
                var tempPrice = prices.Where(p => p >= item.minPrice).ToList();
                var tempPrice2 = prices.Where(p => p >= item.maxPrice).ToList();
                if (tempPrice2.Count > 0)
                {
                    var tp2Min = tempPrice2.Min(p => p);
                    tempPrice = tempPrice.Where(p => p <= tp2Min).ToList();
                }
                foreach (var item2 in tempPrice)
                {
                    listR.Where(p => p.price == item2).First().amount += 1;
                    listR.Where(p => p.price == item2).First().commIds.Add(item.Id);
                }
            }

            //for (int i = 0; i < prices.Count; i++)
            //{
            //    var temp = new List<Commodityspview>();
            //    if (i == 0)
            //        temp = listCommView.Where(p => p.StagePrice < prices[i]).ToList();
            //    else
            //        temp = listCommView.Where(p => p.StagePrice < prices[i] && prices[i - 1] < p.StagePrice).ToList();
            //    if (temp.Count > 0)
            //    {
            //        CommPrice_Amount_CommIds cac = new CommPrice_Amount_CommIds();
            //        cac.price = prices[i];
            //        cac.amount = temp.Select(p => p.Id).Distinct().ToList().Count;
            //        var commIds = temp.Select(p => p.Id).Distinct().ToArray();
            //        cac.commIds = string.Join(",", commIds);
            //        listR.Add(cac);
            //    }
            //}
            return listR;
        }

        /// <summary>
        /// 获取商品各个星级的商品数量
        /// </summary>
        /// <param name="listCommView"></param>
        /// <returns></returns>
        public List<CommStarsCount> GetStarCount(List<Commodity_Stageprice_View> listCommView)
        {
            var listId_Stars = listCommView.Select(p => new { p.Id, p.Stars }).Distinct().ToList();
            List<int> stars = new List<int> {
               5,4,3
            };
            List<CommStarsCount> listR = new List<CommStarsCount>();
            var l = stars.Count;
            for (int i = 0; i < l; i++)
            {
                var listTemp = listId_Stars;
                if (i == 0)
                {
                    listTemp = listId_Stars.Where(p => p.Stars == stars[i]).ToList();
                }
                else
                {
                    listTemp = listId_Stars.Where(p => p.Stars >= stars[i] && p.Stars < stars[i] + 1).ToList();
                }
                var amount = listTemp.Count();
                var listIds = listTemp.Select(p => p.Id).Distinct().ToList();
                var commIds = string.Join(",", listIds);
                CommStarsCount c = new CommStarsCount
                {
                    amount = amount,
                    stars = stars[i],
                    commIds = commIds
                };
                listR.Add(c);
            }
            return listR;

        }

        /// <summary>
        /// 获取商品各个销售量区间的商品数量
        /// </summary>
        /// <param name="listCommView"></param>
        /// <returns></returns>
        public List<CommSalesCount> GetSalesCount(List<Commodity_Stageprice_View> listCommView)
        {
            var listId_Sales = listCommView.Select(p => new { p.Id, p.Sales }).Distinct().ToList();
            List<int> sales = new List<int> {
               250,300,500,1000,5000
            };
            List<CommSalesCount> listR = new List<CommSalesCount>();
            var l = sales.Count;
            for (int i = 0; i < l; i++)
            {
                var listTemp = listId_Sales;
                if (i == l - 1)
                {
                    listTemp = listId_Sales.Where(p => p.Sales >= sales[i]).ToList();
                }
                else
                {
                    listTemp = listId_Sales.Where(p => p.Sales >= sales[i] && p.Sales < sales[i + 1]).ToList();
                }
                var amount = listTemp.Count();
                var listIds = listTemp.Select(p => p.Id).Distinct().ToList();
                var commIds = string.Join(",", listIds);
                CommSalesCount c = new CommSalesCount
                {
                    amount = amount,
                    sales = sales[i],
                    commIds = commIds
                };
                listR.Add(c);
            }
            return listR;
        }

        /// <summary>
        /// 获取商品各个颜色的商品数量
        /// </summary>
        /// <param name="listCommView"></param>
        /// <returns></returns>
        public List<CommColorCount> GetColorCount(List<Commodity_Stageprice_View> listCommView)
        {
            List<CommColorCount> listR = new List<CommColorCount>();
            var commId_Color = listCommView.Select(p => new { p.Id, p.Color }).Distinct().ToList();
            var colorList = XmlHelper.Instance.GetXmlNodeList("/Other.xml", "/EnumType/colors/color");
            List<CommColorCount> listColor = new List<CommColorCount>();
            for (int i = 0; i < colorList.Count; i++)
            {
                var color = colorList[i];
                var name = colorList[i].Attributes["name"].Value;
                var id = Convert.ToInt32(colorList[i].Attributes["id"].Value);
                var code = colorList[i].Attributes["code"].Value;
                CommColorCount c = new CommColorCount();
                c.name = name;
                c.colorId = id;
                c.code = code;
                var listCommIds = commId_Color.Where(p => p.Color.Contains(id.ToString())).Select(p => p.Id).ToList();
                var commIds = string.Join(",", listCommIds);
                c.commIds = commIds;
                listR.Add(c);
            }
            return listR;
        }

        /// <summary>
        /// 根据GradeRes获取所有的分类id
        /// </summary>
        /// <param name="g"></param>
        /// <returns></returns>
        public List<int> GetGradeIdsByGradeRes(GradeRes g)
        {
            List<int> ids = new List<int>();
            ids.Add(g.id);
            if (g.listGrade != null)
            {
                foreach (var item in g.listGrade)
                {
                    ids.Add(item.id);
                    if (item.listGrade != null)
                    {
                        foreach (var item2 in item.listGrade)
                        {
                            ids.Add(item2.id);
                        }
                    }
                }
            }
            return ids.Distinct().ToList();
        }

        /// <summary>
        /// 根据分类id集合获取商品id集合
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public List<int> GetCommIdsByGradeIds(List<int> ids)
        {
            List<int> r = new List<int>();
            Commodity c = new Commodity();
            c.GradeId = 1;
            var list = CommodityOper.Instance.SelectByGradeIds(c, null, null, ids);
            return list.Select(p => p.Id).Distinct().ToList();
        }

        /// <summary>
        /// 根据商品id集合获取商品信息视图
        /// </summary>
        /// <param name="index"></param>
        /// <param name="size"></param>
        /// <param name="ids"></param>
        /// <param name="sales"></param>
        /// <param name="orderStr"></param>
        /// <returns></returns>
        public List<Commodity_Stageprice_View> GetCommsByIds(int index, int size, List<int> ids = null, int? sales = null, string orderStr = null)
        {
            Commodity_Stageprice_View c = new Commodity_Stageprice_View();
            c.Id = 1;
            c.IsDelete = false;
            if (sales != null)
                c.Sales = 1;
            string key = "";
            bool desc = true;
            switch (orderStr)
            {
                case "salesDesc":
                    key = "sales";
                    desc = true;
                    break;
                case "price":
                    key = "maxPrice";
                    desc = false;
                    break;
                case "priceDesc":
                    key = "maxPrice";
                    desc = true;
                    break;
                case "starsDesc":
                    key = "stars";
                    desc = true;
                    break;
                case "createTimeDesc":
                    key = "createTime";
                    desc = true;
                    break;
            }

            return Commodity_Stageprice_ViewOper.Instance.SelectByPageForCommList(key, index * size, size, desc, c, null, null, ids, sales);

        }

        /// <summary>
        /// 获取页面刷新需要的商品信息
        /// </summary>
        /// <param name="index"></param>
        /// <param name="size"></param>
        /// <param name="gradeId"></param>
        /// <param name="sales"></param>
        /// <param name="orderStr"></param>
        /// <returns></returns>
        public CommodityRes GetCommListRes(int index, int size, int gradeId, int? sales = null, string orderStr = null)
        {
            //CommodityRes r = new CommodityRes();
            //var g = GradeFunc.Instance.GetAllGradeRes(gradeId);
            //var tempG = GradeFunc.Instance.GetBranchGradeRes(g, gradeId);

            //List<Commodity_Stageprice_View> listComm = new List<Commodity_Stageprice_View>();
            //var listCommView = GetListCommViewByGrade(tempG);
            //var ListCommIds = listCommView.Select(p => p.Id).Distinct().ToList();

            //Commodity_Stageprice_View c = new Commodity_Stageprice_View();
            //c.Id = 1;
            //c.IsDelete = false;
            //if (sales != null)
            //    c.Sales = 1;
            //var count = Commodity_Stageprice_ViewOper.Instance.SelectCountForCommList(c, null, null, ListCommIds, sales);
            //var pages = count / size;
            ////总页数
            //pages = pages * size == count ? pages : pages + 1;


            //listComm = GetCommsByIds(index, size, ListCommIds, sales, orderStr);
            //List<CommodityListRes> commList = new List<CommodityListRes>();
            //foreach (var item in listComm)
            //{
            //    //var temp = listComm.Where(p => p.Id == item).First();
            //    CommodityListRes res = new CommodityListRes();

            //    res = new CommodityListRes(item);
            //    commList.Add(res);

            //}
            //r.pages = pages;
            //r.index = index;
            //r.ListData = commList;
            return null;
        }

        /// <summary>
        /// 根据条件筛选商品
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public CommodityRes GetCommList(int index, int size, List<int> ids = null, int? sales = null, string orderStr = null)
        {
            CommodityRes r = new CommodityRes();
            if (ids != null)
            {
                Commodity_Stageprice_View c = new Commodity_Stageprice_View();
                c.Id = 1;
                c.IsDelete = false;
                if (sales != null)
                    c.Sales = 1;

                string key = "";
                bool desc = true;
                switch (orderStr)
                {
                    case "salesDesc":
                        key = "sales";
                        desc = true;
                        break;
                    case "price":
                        key = "maxPrice";
                        desc = false;
                        break;
                    case "priceDesc":
                        key = "maxPrice";
                        desc = true;
                        break;
                    case "starsDesc":
                        key = "stars";
                        desc = true;
                        break;
                    case "createTimeDesc":
                        key = "createTime";
                        desc = true;
                        break;
                }

                //CommodityspviewOper.Instance.SelectByPageForCommList(key, 0, 9, desc, c, null, null, ids, sales);

                var count = Commodity_Stageprice_ViewOper.Instance.SelectCountForCommList(c, null, null, ids, sales);

                var listComm = Commodity_Stageprice_ViewOper.Instance.SelectByPageForCommList(key, index * size, size, desc, c, null, null, ids, sales);

                List<CommodityListRes> commList = new List<CommodityListRes>();
                foreach (var item in listComm)
                {
                    var res = new CommodityListRes(item);
                    commList.Add(res);
                }

                var pages = count / size;
                //总页数
                pages = pages * size == count ? pages : pages + 1;

                r.ListData = commList;
                r.index = index;

                r.pages = pages;
                return r;
            }
            return null;
        }


        /// <summary>
        /// 筛选全部未删除的商品
        /// </summary>

        /// <returns></returns>
        public List<Commodity_Stageprice_View> GetAllCommList()
        {
            var list_Commodity = MemCacheHelper2.Instance.Cache.GetModel<List<Commodity_Stageprice_View>>("List_Commodity_Stageprice_View");
            if (list_Commodity == null || list_Commodity.Count == 0)
            {
                list_Commodity = Commodity_Stageprice_ViewFunc.Instance.SelectByModel(new Commodity_Stageprice_View { IsDelete = false, IsRelease = true });
                MemCacheHelper2.Instance.Cache.Set("List_Commodity_Stageprice_View", list_Commodity, DateTime.Now.AddHours(1.0));
            }
            return list_Commodity;
        }

        /// <summary>
        /// 筛选全部未删除的商品
        /// </summary>
        /// <returns></returns>
        public List<Commodity_Stageprice_View> ReGetAllCommList()
        {
            MemCacheHelper2.Instance.Cache.Delete("List_Commodity_Stageprice_View");
            var list_Commodity = Commodity_Stageprice_ViewFunc.Instance.SelectByModel(new Commodity_Stageprice_View { IsDelete = false, IsRelease = true });
            MemCacheHelper2.Instance.Cache.Set("List_Commodity_Stageprice_View", list_Commodity, DateTime.Now.AddHours(1.0));
            return list_Commodity;
        }

        /// <summary>
        /// 分页获得搜索数据
        /// </summary>
        /// <param name="search">搜索关键字</param>
        /// <returns>数据</returns>
        public List<Commodity_Stageprice_View> GetViewBySearch(string search, int? PageNo)
        {
            Commodity_Stageprice_View c = new Commodity_Stageprice_View();
            c.Name = search;
            c.Content = search;
            c.Introduce = search;
            return Commodity_Stageprice_ViewOper.Instance.SelectBySearch(PageNo, c);
        }

        /// <summary>
        /// 获得搜索条数
        /// </summary>
        /// <param name="search">搜索关键字</param>
        /// <returns>条数</returns>
        public int GetViewBySearchCount(string search)
        {
            Commodity_Stageprice_View c = new Commodity_Stageprice_View();
            c.Name = search;
            c.Content = search;
            c.Introduce = search;
            return Commodity_Stageprice_ViewOper.Instance.SelectBySearchCount(c);
        }

        public CommodityRes GetSearchList(int index, int size, string search, int? sales = null, string orderStr = null)
        {
            CommodityRes r = new CommodityRes();
            string key = "";
            bool desc = true;
            switch (orderStr)
            {
                case "salesDesc":
                    key = "sales";
                    desc = true;
                    break;
                case "price":
                    key = "maxPrice";
                    desc = false;
                    break;
                case "priceDesc":
                    key = "maxPrice";
                    desc = true;
                    break;
                case "starsDesc":
                    key = "stars";
                    desc = true;
                    break;
                case "createTimeDesc":
                    key = "createTime";
                    desc = true;
                    break;
            }

            Commodity_Stageprice_View c = new Commodity_Stageprice_View();
            c.Name = search;
            c.Introduce = search;
            c.Content = search;
            c.Sales = sales;
            c.IsDelete = false;

            var count = Commodity_Stageprice_ViewOper.Instance.SelectCountForSearchList(c, null, null);

            var listComm = Commodity_Stageprice_ViewOper.Instance.SelectByPageForSearchList(key, index * size, size, desc, c);

            List<CommodityListRes> commList = new List<CommodityListRes>();
            foreach (var item in listComm)
            {
                var res = new CommodityListRes(item);
                commList.Add(res);
            }

            var pages = count / size;
            //总页数
            pages = pages * size == count ? pages : pages + 1;

            r.ListData = commList;
            r.index = (int)index;
            r.pages = (int)pages;
            return r;
        }

        /// <summary>
        /// 设置置顶商品
        /// </summary>
        /// <param name="commodityId">商品Id</param>
        /// <returns></returns>
        public bool SetTopCommodity(int commodityId)
        {
            return CommodityOper.Instance.Update(new Commodity { Id = commodityId, RecommendTime = DateTime.Now });
        }

        /// <summary>
        /// 设置置顶商品
        /// </summary>
        /// <param name="commodityId">商品Id</param>
        /// <returns></returns>
        public Commodity SelectCommodityById(int commodityId)
        {
            return CommodityOper.Instance.SelectById(commodityId);
        }

        /// <summary>
        /// 设置置顶商品
        /// </summary>
        /// <param name="commodityId">商品Id</param>
        /// <returns></returns>
        public bool UpdateCommodity(Commodity commodity)
        {
            return CommodityOper.Instance.Update(commodity);
        }

        /// <summary>
        /// 获取置顶商品分页
        /// </summary>
        /// <param name="start">开始条数</param>
        /// <param name="pagesize">页面大小</param>
        /// <returns></returns>
        public List<Commodity_Stageprice_View> GetCommodityListByPage(int start, int pagesize)
        {
            return Commodity_Stageprice_ViewOper.Instance.SelectByPage("RecommendTime", start, pagesize, true, new Commodity_Stageprice_View { IsDelete = false });
        }

        /// <summary>
        /// 获取置顶商品分页
        /// </summary>
        /// <returns></returns>
        public int GetCommodityListCount()
        {
            return Commodity_Stageprice_ViewOper.Instance.SelectCount(new Commodity_Stageprice_View { IsDelete = false });
        }
        /// <summary>
        /// 筛选商品信息
        /// </summary>
        /// <param name="ListCommIds">商品信息</param>
        /// <returns></returns>
        public List<Commodity> SelectCommInfo(Commodity ListCommIds)
        {
            return CommodityOper.Instance.SelectAll(ListCommIds);
        }

        /// <summary>
        /// 分页获得商品列表
        /// </summary>
        /// <param name="Key">主键</param>
        /// <param name="start">开始数据</param>
        /// <param name="PageSize">页面长度</param>
        /// <param name="order">排序</param>
        /// <param name="model">对象</param>
        /// <returns>对象列表</returns>
        public List<Commdity_Materials_View> SelectCommodityListByPage(string Key, int start, int PageSize, string order, string name = null)
        {
            bool descFlag = order == null ? true : order.ToLower() == "desc" ? true : false;
            return CommodityOper.Instance.SelectCommodityListByPage(Key, start, PageSize, descFlag, name);
        }

        /// <summary>
        /// 分页获得商品列表
        /// </summary>
        /// <param name="Key">主键</param>
        /// <param name="start">开始数据</param>
        /// <param name="PageSize">页面长度</param>
        /// <param name="order">排序</param>
        /// <param name="model">对象</param>
        /// <returns>对象列表</returns>
        public int SelectCommodityListCount(int start, int PageSize, string name)
        {
            return CommodityOper.Instance.SelectCommodityListCount(start, PageSize, name);
        }

        /// <summary>
        /// 插入商品
        /// </summary>
        /// <param name="commodity">商品模型</param>
        /// <returns></returns>
        public bool InsertCommodity(Commodity commodity)
        {
            var MysqlHelper = SqlHelper.GetMySqlHelper("transaction");
            var connection = MysqlHelper.CreatConn();
            var transaction = MysqlHelper.GetTransaction();
            #region 初始价格区间
            var PriceArray = commodity.Points.Split('|').Where(p => !string.IsNullOrEmpty(p)).ToList();
            List<Tuple<string, string, string>> listTuple = new List<Tuple<string, string, string>>();
            foreach (var item in PriceArray)
            {
                var itemArray = item.Split(',');
                Tuple<string, string, string> tuple = new Tuple<string, string, string>(item1: itemArray[0], item2: itemArray[1], item3: itemArray[2]);
                listTuple.Add(tuple);
            }
            commodity.Points = null;
            #endregion
            if (commodity.Id == 0)
            {
                #region 插入新的商品
                try
                {
                    commodity.Sales = 0;
                    commodity.StarCount = 0;
                    commodity.Stars = 5;
                    var key = CommodityOper.Instance.InsertReturnKey(commodity, connection, transaction);
                    if (key < 0)
                    {
                        transaction.Rollback();
                        connection.Close();
                        return false;
                    }
                    foreach (var item in listTuple)
                    {
                        if (!Commodity_Stage_PriceOper.Instance.Insert(new Commodity_Stage_Price { CommodityId = key, StageAmount = item.Item2.ParseInt(), StagePrice = item.Item1.ParseDecimal(), DiscountRate = item.Item3.ParseDouble() }))
                        {
                            transaction.Rollback();
                            connection.Close();
                            return false;
                        }
                    }
                    transaction.Commit();
                    connection.Close();
                    return true;
                }
                catch (Exception e)
                {
                    transaction.Rollback();
                    connection.Close();
                }
                #endregion
                return false;
            }
            else
            {
                #region 插入旧的商品
                try
                {
                    if (!CommodityOper.Instance.Update(commodity, connection, transaction))
                    {
                        transaction.Rollback();
                        connection.Close();
                        return false;
                    }
                    Commodity_Stage_PriceOper.Instance.DeleteModel(new Commodity_Stage_Price { CommodityId = commodity.Id });
                    foreach (var item in listTuple)
                    {

                        if (!Commodity_Stage_PriceOper.Instance.Insert(new Commodity_Stage_Price { CommodityId = commodity.Id, StageAmount = item.Item2.ParseInt(), StagePrice = item.Item1.ParseDecimal(), DiscountRate = item.Item3.ParseDouble() }))
                        {
                            transaction.Rollback();
                            connection.Close();
                            return false;
                        }
                    }
                    transaction.Commit();
                    connection.Close();
                    return true;
                }
                catch (Exception e)
                {
                    transaction.Rollback();
                    connection.Close();
                }
                #endregion
                return false;
            }
        }

        /// <summary>
        /// 删除商品
        /// </summary>
        /// <param name="Id">Id</param>
        /// <returns></returns>
        public bool DeleteCommodity(int Id)
        {
            return CommodityOper.Instance.Update(new Commodity { Id = Id, IsDelete = true });
        }
    }
}
