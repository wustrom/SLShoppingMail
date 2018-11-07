using Common;
using Common.Helper;
using Common.Result;
using DbOpertion.Models;
using DbOpertion.Operation;
using SLSM.DBOpertion.Model.Extend.Response.GradeRes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbOpertion.Function
{
    public partial class GradeFunc : SingleTon<GradeFunc>
    {

        /// <summary>
        /// 获取所有一级分类
        /// </summary>
        /// <returns></returns>
        public List<Grade> GetGrade1()
        {
            Grade g = new Grade();
            g.IsDelete = false;
            g.ParentId = 0;
            g.IsScene = false;
            return GradeOper.Instance.SelectAll(g);
        }
        /// <summary>
        /// 获取所有未删除类别和场景
        /// </summary>
        /// <returns></returns>
        public List<Grade> GetAllGradeInfo()
        {
            Grade g = new Grade();
            g.IsDelete = false;
            var listAllGrade = MemCacheHelper2.Instance.Cache.GetModel<List<Grade>>("List_AllGradeInfo");
            if (listAllGrade == null || listAllGrade.Count == 0)
            {
                listAllGrade = new List<Grade>();
                var list = GradeOper.Instance.SelectAll(g);
                var listTemp = list.Where(p => p.ParentId == 0).ToList();
                foreach (var item in listTemp)
                {
                    var listG2Temp = list.Where(p => p.ParentId == item.Id).ToList();
                    foreach (var item2 in listG2Temp)
                    {
                        var listG3Temp = list.Where(p => p.ParentId == item2.Id).ToList();
                        foreach (var item3 in listG3Temp)
                        {
                            listAllGrade.Add(item3);
                        }
                        listAllGrade.Add(item2);
                    }
                    listAllGrade.Add(item);
                }
                MemCacheHelper2.Instance.Cache.Set("List_AllGradeInfo", listAllGrade, DateTime.Now.AddHours(1.0));
            }
            return listAllGrade;
        }

        public void ResetCache()
        {
            MemCacheHelper2.Instance.Cache.Delete("List_AllGradeInfo");
            MemCacheHelper2.Instance.Cache.Delete("List_GradeRes");
            MemCacheHelper2.Instance.Cache.Delete("List_Scene");
        }
        /// <summary>
        /// 获取所有级别分类
        /// </summary>
        /// <returns></returns>
        public List<GradeRes> GetAllGrade()
        {
            Grade g = new Grade();
            g.IsDelete = false;
            g.IsScene = false;
            var listRes = MemCacheHelper2.Instance.Cache.GetModel<List<GradeRes>>("List_GradeRes");
            if (listRes == null || listRes.Count == 0)
            {
                listRes = new List<GradeRes>();
                var list = GradeOper.Instance.SelectAll(g);
                var listTemp = list.Where(p => p.ParentId == 0).ToList();
                foreach (var item in listTemp)
                {
                    GradeRes g1 = new GradeRes(item);
                    var listG2Temp = list.Where(p => p.ParentId == item.Id).ToList();
                    if (listG2Temp.Count > 0) { }

                    List<GradeRes> listG2 = new List<GradeRes>();

                    foreach (var item2 in listG2Temp)
                    {
                        GradeRes g2 = new GradeRes(item2);
                        var listG3Temp = list.Where(p => p.ParentId == item2.Id).ToList();
                        List<GradeRes> listG3 = new List<GradeRes>();
                        if (listG3Temp.Count > 0)
                        {
                            foreach (var item3 in listG3Temp)
                            {
                                GradeRes g3 = new GradeRes(item3);
                                listG3.Add(g3);
                            }
                        }
                        g2.listGrade = listG3;
                        listG2.Add(g2);
                    }
                    g1.listGrade = listG2;
                    listRes.Add(g1);
                }
                MemCacheHelper2.Instance.Cache.Set("List_GradeRes", listRes, DateTime.Now.AddHours(1.0));
            }
            return listRes;
        }

        /// <summary>
        /// 获取所有场景
        /// </summary>
        /// <returns></returns>
        public List<GradeRes> GetAllScene()
        {
            Grade g = new Grade();
            g.IsDelete = false;
            g.IsScene = true;
            var listRes = MemCacheHelper2.Instance.Cache.GetModel<List<GradeRes>>("List_Scene");
            if (listRes == null || listRes.Count == 0)
            {
                listRes = new List<GradeRes>();
                var list = GradeOper.Instance.SelectAll(g);
                var listTemp = list.Where(p => p.ParentId == 0).ToList();
                foreach (var item in listTemp)
                {
                    GradeRes g1 = new GradeRes(item);
                    var listG2Temp = list.Where(p => p.ParentId == item.Id).ToList();
                    if (listG2Temp.Count > 0) { }

                    List<GradeRes> listG2 = new List<GradeRes>();

                    foreach (var item2 in listG2Temp)
                    {
                        GradeRes g2 = new GradeRes(item2);
                        var listG3Temp = list.Where(p => p.ParentId == item2.Id).ToList();
                        List<GradeRes> listG3 = new List<GradeRes>();
                        if (listG3Temp.Count > 0)
                        {
                            foreach (var item3 in listG3Temp)
                            {
                                GradeRes g3 = new GradeRes(item3);
                                listG3.Add(g3);
                            }
                        }
                        g2.listGrade = listG3;
                        listG2.Add(g2);
                    }
                    g1.listGrade = listG2;
                    listRes.Add(g1);
                }
                MemCacheHelper2.Instance.Cache.Set("List_Scene", listRes, DateTime.Now.AddHours(1.0));
            }
            return listRes;
        }

        /// <summary>
        /// 获取所有级别分类
        /// </summary>
        /// <returns></returns>
        public List<GradeResForWeb> GetAllGradeForAdmin(List<int> ids)
        {
            Grade g = new Grade();
            g.IsDelete = false;
            g.IsScene = false;
            List<GradeResForWeb> listRes = new List<GradeResForWeb>();
            var list = GradeOper.Instance.SelectAll(g);
            var listTemp = list.Where(p => p.ParentId == 0).ToList();
            foreach (var item in listTemp)
            {
                GradeResForWeb g1 = new GradeResForWeb();
                g1.name = item.Name;
                g1.id = item.Id;
                if (ids.Where(p => p == item.Id).ToList().Count > 0)
                {
                    g1.icon = "&#xe61a;";
                    g1.classStr = "layui-colla-content layui-show";
                }
                else
                {
                    g1.icon = "&#xe602;";
                    g1.classStr = "layui-colla-content";
                }
                var listG2Temp = list.Where(p => p.ParentId == item.Id).ToList();
                if (listG2Temp.Count > 0) { }

                List<GradeResForWeb> listG2 = new List<GradeResForWeb>();

                foreach (var item2 in listG2Temp)
                {
                    GradeResForWeb g2 = new GradeResForWeb();
                    g2.name = item2.Name;
                    g2.id = item2.Id;
                    if (ids.Where(p => p == item2.Id).ToList().Count > 0)
                    {
                        g2.icon = "&#xe61a;";
                        g2.classStr = "layui-colla-content layui-show";
                    }
                    else
                    {
                        g2.icon = "&#xe602;";
                        g2.classStr = "layui-colla-content";
                    }
                    var listG3Temp = list.Where(p => p.ParentId == item2.Id).ToList();
                    List<GradeResForWeb> listG3 = new List<GradeResForWeb>();
                    if (listG3Temp.Count > 0)
                    {
                        foreach (var item3 in listG3Temp)
                        {
                            GradeResForWeb g3 = new GradeResForWeb();
                            g3.name = item3.Name;
                            g3.id = item3.Id;
                            if (ids.Where(p => p == item3.Id).ToList().Count > 0)
                            {
                                g3.icon = "&#xe61a;";
                                g3.classStr = "layui-colla-content layui-show";
                            }
                            else
                            {
                                g3.icon = "&#xe602;";
                                g3.classStr = "layui-colla-content";
                            }
                            listG3.Add(g3);
                        }
                    }
                    g2.listGrade = listG3;
                    listG2.Add(g2);
                }

                g1.listGrade = listG2;
                listRes.Add(g1);
                ////为了展示更多数据
                //listRes.Add(g1);
                //listRes.Add(g1);
            }

            return listRes;
        }

        /// <summary>
        /// 获取所有场景
        /// </summary>
        /// <returns></returns>
        public List<GradeResForWeb> GetAllSceneForAdmin(List<int> ids)
        {
            Grade g = new Grade();
            g.IsDelete = false;
            g.IsScene = true;
            List<GradeResForWeb> listRes = new List<GradeResForWeb>();
            var list = GradeOper.Instance.SelectAll(g);
            var listTemp = list.Where(p => p.ParentId == 0).ToList();
            foreach (var item in listTemp)
            {
                GradeResForWeb g1 = new GradeResForWeb();
                g1.name = item.Name;
                g1.id = item.Id;
                if (ids.Where(p => p == item.Id).ToList().Count > 0)
                {
                    g1.icon = "&#xe61a;";
                    g1.classStr = "layui-colla-content layui-show";
                }
                else
                {
                    g1.icon = "&#xe602;";
                    g1.classStr = "layui-colla-content";
                }
                var listG2Temp = list.Where(p => p.ParentId == item.Id).ToList();
                if (listG2Temp.Count > 0) { }

                List<GradeResForWeb> listG2 = new List<GradeResForWeb>();

                foreach (var item2 in listG2Temp)
                {
                    GradeResForWeb g2 = new GradeResForWeb();
                    g2.name = item2.Name;
                    g2.id = item2.Id;
                    if (ids.Where(p => p == item2.Id).ToList().Count > 0)
                    {
                        g2.icon = "&#xe61a;";
                        g2.classStr = "layui-colla-content layui-show";
                    }
                    else
                    {
                        g2.icon = "&#xe602;";
                        g2.classStr = "layui-colla-content";
                    }
                    var listG3Temp = list.Where(p => p.ParentId == item2.Id).ToList();
                    List<GradeResForWeb> listG3 = new List<GradeResForWeb>();
                    if (listG3Temp.Count > 0)
                    {
                        foreach (var item3 in listG3Temp)
                        {
                            GradeResForWeb g3 = new GradeResForWeb();
                            g3.name = item3.Name;
                            g3.id = item3.Id;
                            if (ids.Where(p => p == item3.Id).ToList().Count > 0)
                            {
                                g3.icon = "&#xe61a;";
                                g3.classStr = "layui-colla-content layui-show";
                            }
                            else
                            {
                                g3.icon = "&#xe602;";
                                g3.classStr = "layui-colla-content";
                            }
                            listG3.Add(g3);
                        }
                    }
                    g2.listGrade = listG3;
                    listG2.Add(g2);
                }

                g1.listGrade = listG2;
                listRes.Add(g1);
                ////为了展示更多数据
                //listRes.Add(g1);
                //listRes.Add(g1);
            }

            return listRes;
        }

        /// <summary>
        /// 获取一级、二级分类
        /// </summary>
        /// <returns></returns>
        public List<GradeRes> GetGrade12()
        {
            var list = GetAllGrade();
            for (int i = 0; i < list.Count; i++)
            {
                for (int j = 0; j < list[i].listGrade.Count; j++)
                {
                    list[i].listGrade[j].listGrade.Clear();
                }
            }
            return list;
        }

        /// <summary>
        /// 获取前n个热门分类，任意级别
        /// </summary>
        /// <returns></returns>
        public List<GradeId_Name_Img> GetHotGrade(int n)
        {
            List<GradeId_Name_Img> listRes = new List<GradeId_Name_Img>();
            var list = GradeOper.Instance.SelectByPage("HotGradeTime", 0, n, true, new Grade { IsScene = false, IsDelete = false });
            foreach (var item in list)
            {
                GradeId_Name_Img g = new GradeId_Name_Img(item);
                listRes.Add(g);
            }
            return listRes;
        }

        /// <summary>
        /// 根据任意分类获取从它属于的第一级分类到孙分类的所有分类
        /// </summary>
        /// <param name="gradeId"></param>
        /// <returns></returns>
        public GradeRes GetAllGradeRes(int gradeId)
        {
            var gradeList = GetAllGrade();
            foreach (var item_Level1 in gradeList)
            {
                if (gradeId == item_Level1.id)
                {
                    return item_Level1;
                }
                else
                {
                    foreach (var item_Level2 in item_Level1.listGrade)
                    {
                        if (gradeId == item_Level2.id)
                        {
                            return item_Level1;
                        }
                        else
                        {
                            foreach (var item_Level3 in item_Level2.listGrade)
                            {
                                if (gradeId == item_Level3.id)
                                {
                                    return item_Level1;
                                }
                            }
                        }
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// 根据任意分类获取从它属于的第一级分类到孙分类的所有分类
        /// </summary>
        /// <param name="gradeId"></param>
        /// <returns></returns>
        public GradeRes GetAllScenceRes(int gradeId)
        {
            var gradeList = GetAllScene();
            foreach (var item_Level1 in gradeList)
            {
                if (gradeId == item_Level1.id)
                {
                    return item_Level1;
                }
                else
                {
                    foreach (var item_Level2 in item_Level1.listGrade)
                    {
                        if (gradeId == item_Level2.id)
                        {
                            return item_Level1;
                        }
                        else
                        {
                            foreach (var item_Level3 in item_Level2.listGrade)
                            {
                                if (gradeId == item_Level3.id)
                                {
                                    return item_Level1;
                                }
                            }
                        }
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// 根据任意分类获取从它属于的第一级分类到孙分类的所有分类
        /// </summary>
        /// <param name="gradeId"></param>
        /// <returns></returns>
        public GradeRes GetAllGradeResSingle(int gradeId)
        {
            var gradeList = GetAllGrade();
            foreach (var item_Level1 in gradeList)
            {
                if (gradeId == item_Level1.id)
                {
                    item_Level1.listGrade = new List<GradeRes>();
                    return item_Level1;
                }
                else
                {
                    foreach (var item_Level2 in item_Level1.listGrade)
                    {
                        if (gradeId == item_Level2.id)
                        {
                            item_Level1.listGrade = new List<GradeRes>();
                            item_Level2.listGrade = new List<GradeRes>();
                            item_Level1.listGrade.Add(item_Level2);
                            return item_Level1;
                        }
                        else
                        {
                            foreach (var item_Level3 in item_Level2.listGrade)
                            {
                                if (gradeId == item_Level3.id)
                                {
                                    item_Level1.listGrade = new List<GradeRes>();
                                    item_Level2.listGrade = new List<GradeRes>();
                                    item_Level3.listGrade = new List<GradeRes>();
                                    item_Level1.listGrade.Add(item_Level2);
                                    item_Level2.listGrade.Add(item_Level3);
                                    return item_Level1;
                                }

                            }
                        }
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// 根据任意分类获取从它属于的第一级分类到孙分类的所有分类
        /// </summary>
        /// <param name="gradeId"></param>
        /// <returns></returns>
        public GradeRes GetAllScenceResSingle(int gradeId)
        {
            var gradeList = GetAllScene();
            foreach (var item_Level1 in gradeList)
            {
                if (gradeId == item_Level1.id)
                {
                    item_Level1.listGrade = new List<GradeRes>();
                    return item_Level1;
                }
                else
                {
                    foreach (var item_Level2 in item_Level1.listGrade)
                    {
                        if (gradeId == item_Level2.id)
                        {
                            item_Level1.listGrade = new List<GradeRes>();
                            item_Level2.listGrade = new List<GradeRes>();
                            item_Level1.listGrade.Add(item_Level2);
                            return item_Level1;
                        }
                        else
                        {
                            foreach (var item_Level3 in item_Level2.listGrade)
                            {
                                if (gradeId == item_Level3.id)
                                {
                                    item_Level1.listGrade = new List<GradeRes>();
                                    item_Level2.listGrade = new List<GradeRes>();
                                    item_Level3.listGrade = new List<GradeRes>();
                                    item_Level1.listGrade.Add(item_Level2);
                                    item_Level2.listGrade.Add(item_Level3);
                                    return item_Level1;
                                }

                            }
                        }
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// 从总分类里找出自己分类的分支
        /// </summary>
        /// <param name="g"></param>
        /// <param name="gradeId"></param>
        /// <returns></returns>
        public GradeRes GetBranchGradeRes(GradeRes g, int gradeId)
        {
            var tempG = new GradeRes();
            if (g.id == gradeId)
                tempG = g;
            else
            {
                foreach (var item in g.listGrade)
                {
                    if (item.id == gradeId)
                        tempG = item;
                    else
                    {
                        foreach (var item2 in item.listGrade)
                        {
                            if (item2.id == gradeId)
                                tempG = item2;
                        }
                    }
                }
            }
            return tempG;
        }

        /// <summary>
        /// 获取三级分类
        /// </summary>
        /// <param name="g"></param>
        /// <param name="gradeId"></param>
        /// <returns></returns>
        public ThreeGrade GetThreeGrade(GradeRes g, int gradeId)
        {
            ThreeGrade r = new ThreeGrade();
            r.id = g.id;
            r.name = g.name;
            if (g.id != gradeId)
            {
                ThreeGrade r2 = new ThreeGrade();
                foreach (var item in g.listGrade)
                {
                    if (item.id == gradeId)
                    {
                        r2.id = item.id;
                        r2.name = item.name;
                        break;
                    }
                    ThreeGrade r3 = new ThreeGrade();
                    foreach (var item2 in item.listGrade)
                    {
                        if (item2.id == gradeId)
                        {
                            r2.id = item.id;
                            r2.name = item.name;

                            r3.id = item2.id;
                            r3.name = item2.name;
                            r2.sonGrade = r3;
                            break;
                        }
                    }


                }
                r.sonGrade = r2;
            }
            return r;
        }

        /// <summary>
        /// 获得分类属性列表
        /// </summary>
        /// <param name="GradeId">分类ID</param>
        /// <returns></returns>
        public List<Grade_Attr> GradeAttrInfo(int GradeId)
        {
            return Grade_AttrOper.Instance.SelectAll(new Grade_Attr { GradeId = GradeId });
        }

        /// <summary>
        /// 分页获取分类
        /// </summary>
        /// <param name="pageNo"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public List<Gradefindparent> SelectGradeByPage(int pageNo, int pageSize)
        {
            return GradefindparentOper.Instance.SelectByPage("Id", (pageNo - 1) * pageSize, pageSize, true);
        }

        /// <summary>
        /// 分页获取分类
        /// </summary>
        /// <param name="pageNo"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public List<Gradefindparent> SelectGradeByPageByTime(int pageNo, int pageSize)
        {
            return GradefindparentOper.Instance.SelectByPage("HotGradeTime", (pageNo - 1) * pageSize, pageSize, true);
        }

        /// <summary>
        /// 获取所有分类总数
        /// </summary>
        /// <returns></returns>
        public int SelectAllGradeCount()
        {
            return GradeOper.Instance.SelectCount(new Grade { IsDelete = false, IsScene = false });
        }

        /// <summary>
        /// 获取所有分类总数
        /// </summary>
        /// <returns></returns>
        public int SelectAllSceneCount()
        {
            return GradeOper.Instance.SelectCount(new Grade { IsDelete = false, IsScene = true });
        }


        /// <summary>
        /// 获取所有分类总数
        /// </summary>
        /// <returns></returns>
        public List<Grade> SelectAll()
        {
            return GradeOper.Instance.SelectAll(new Grade { IsDelete = false, IsScene = false });
        }

        /// <summary>
        /// 获取所有分类总数
        /// </summary>
        /// <returns></returns>
        public List<Grade> SelectAllScence()
        {
            return GradeOper.Instance.SelectAll(new Grade { IsDelete = false, IsScene = true });
        }

        /// <summary>
        /// 根据分类id获取一条视图记录
        /// </summary>
        /// <param name="gradeId"></param>
        /// <returns></returns>
        public Gradefindparent GetGradefpById(int gradeId)
        {
            return GradefindparentOper.Instance.SelectById1(gradeId);
        }

        public List<string> GetAttrs(int gradeId)
        {
            Grade_Attr ga = new Grade_Attr
            {
                GradeId = gradeId
            };
            var list = Grade_AttrOper.Instance.SelectAll(ga);
            if (list == null)
                return new List<string>();
            return list.Select(p => p.Content).ToList();
        }

        public void AddAttrs(int gradeId, List<string> attrs)
        {
            Grade_AttrOper.Instance.DeleteByGradeId(gradeId);
            foreach (var item in attrs)
            {
                Grade_Attr ga = new Grade_Attr();
                ga.GradeId = gradeId;
                ga.Content = item;
                Grade_AttrOper.Instance.Insert(ga);
            }
        }

        public int Add(Grade g)
        {
            return GradeOper.Instance.InsertReturnKey(g);
        }

        /// <summary>
        /// 设置置顶分类
        /// </summary>
        /// <param name="GradeId">分类Id</param>
        /// <returns></returns>
        public bool SetTopGrade(int GradeId)
        {
            return GradeOper.Instance.Update(new Grade { Id = GradeId, HotGradeTime = DateTime.Now });
        }
    }
}
