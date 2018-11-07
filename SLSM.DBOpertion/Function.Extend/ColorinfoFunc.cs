using Common;
using System.Collections.Generic;
using DbOpertion.Operation;
using DbOpertion.Models;
using Common.Helper;
using SLSM.DBOpertion.Model.Extend.Response.ColorRes;
using System.Linq;

namespace DbOpertion.Function
{
    public partial class ColorinfoFunc : SingleTon<ColorinfoFunc>
    {
        /// <summary>
        /// 颜色重新编排
        /// </summary>
        /// <returns></returns>
        private List<ColorRes> ReSortColor(List<Colorinfo> list)
        {
            var ColorList = new List<ColorRes>();
            var parentColor = list.Where(p => p.ParentId == 0).ToList();
            foreach (var item in parentColor)
            {
                var colorRes = new ColorRes(item);
                var childColors = list.Where(p => p.ParentId == item.Id).ToList();
                colorRes.listColor = new List<ColorRes>();
                foreach (var childColor in childColors)
                {
                    colorRes.listColor.Add(new ColorRes(childColor));
                }
                ColorList.Add(colorRes);
            }
            return ColorList;
        }

        /// <summary>
        /// 获得未删除颜色列表
        /// </summary>
        /// <returns></returns>
        public List<ColorRes> GetColorList()
        {
            return ReSortColor(GetColorListBase());
        }

        /// <summary>
        /// 获得未删除颜色列表
        /// </summary>
        /// <returns></returns>
        public int GetColorID(string name)
        {
            var colorList = GetColorListBase();
            var colorInfo = colorList.Where(p => p.ChinaDescribe == name && p.ParentId != 0).FirstOrDefault();
            return colorInfo.Id;
        }

        /// <summary>
        /// 获得未删除颜色列表
        /// </summary>
        /// <returns></returns>
        public List<Colorinfo> GetColorListBase()
        {
            var ListColor = MemCacheHelper2.Instance.Cache.GetModel<List<Colorinfo>>("ColorResList");
            if (ListColor == null || ListColor.Count == 0)
            {
                ListColor = SelectByModel(new Colorinfo { IsDelete = false });
                MemCacheHelper2.Instance.Cache.Set("ColorResList", ListColor);
            }
            return ListColor;
        }



        /// <summary>
        /// 获得全部颜色列表
        /// </summary>
        /// <returns></returns>
        public List<ColorRes> GetAllColorList()
        {
            return ReSortColor(GetAllColorListBase());
        }

        /// <summary>
        /// 获得全部颜色列表
        /// </summary>
        /// <returns></returns>
        public List<Colorinfo> GetAllColorListBase()
        {
            var ListColor = MemCacheHelper2.Instance.Cache.GetModel<List<Colorinfo>>("ColorResAllList");
            if (ListColor == null || ListColor.Count == 0)
            {
                ListColor = SelectByModel(null);
                MemCacheHelper2.Instance.Cache.Set("ColorResAllList", ListColor);
            }
            return ListColor;
        }

        /// <summary>
        /// 重置颜色列表
        /// </summary>
        /// <returns></returns>
        public void ReSetList()
        {
            var result = MemCacheHelper2.Instance.Cache.Delete("ColorResList");
            GetColorList();
            var result2 = MemCacheHelper2.Instance.Cache.Delete("ColorResAllList");
            GetAllColorList();
        }
    }
}
