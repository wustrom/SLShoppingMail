using Common;
using DbOpertion.Operation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DbOpertion.Models;

namespace DbOpertion.Function
{
    public partial class HisdesignFunc : SingleTon<HisdesignFunc>
    {
        /// <summary>
        /// 获得历史设计信息
        /// </summary>
        /// <param name="UserID">用户Id</param>
        /// <param name="CommodityId">商品Id</param>
        /// <param name="UserGuid">用户Guid</param>
        /// <returns></returns>
        public Hisdesign GetHisdesignInfo(int? UserID, int CommodityId, string UserGuid)
        {
            Hisdesign hisdesign;
            if (UserID == null)
            {
                hisdesign = HisdesignOper.Instance.SelectAll(new Hisdesign { CommodityId = CommodityId, UserGuid = UserGuid }).FirstOrDefault();
            }
            else
            {
                hisdesign = HisdesignOper.Instance.SelectAll(new Hisdesign { CommodityId = CommodityId, UserID = UserID }).FirstOrDefault();
                //若用户ID筛选不出则用Guid在筛选一遍
                if (hisdesign == null)
                {
                    hisdesign = HisdesignOper.Instance.SelectAll(new Hisdesign { CommodityId = CommodityId, UserGuid = UserGuid }).FirstOrDefault();
                    if (hisdesign != null)
                    {
                        hisdesign.UserID = UserID;
                        HisdesignOper.Instance.Update(hisdesign);
                    }
                }
            }
            //若没有记录则生成一条
            if (hisdesign == null)
            {
                if (HisdesignOper.Instance.Insert(new Hisdesign { CommodityId = CommodityId, UserGuid = UserGuid, UserID = UserID, LastLookTime = DateTime.Now }))
                {
                    hisdesign = HisdesignOper.Instance.SelectAll(new Hisdesign { CommodityId = CommodityId, UserID = UserID, UserGuid = UserGuid }).FirstOrDefault();
                }
                else
                {
                    hisdesign = null;
                }
            }
            return hisdesign;
        }

        /// <summary>
        /// 获得全部历史设计信息
        /// </summary>
        /// <returns></returns>
        public List<Hisdesign> GetAllHisdesignInfo()
        {
            return HisdesignOper.Instance.SelectAll(); ;
        }

        /// <summary>
        /// 根据模型获取历史设计信息
        /// </summary>
        /// <param name="model">用户模型</param>
        /// <returns></returns>
        public List<Hisdesigninfo_View> GetModleHisdesign(Hisdesigninfo_View model)
        {
            return Hisdesigninfo_ViewOper.Instance.SelectByUser(model);
        }

        /// <summary>
        /// 根据模型获取历史设计信息
        /// </summary>
        /// <param name="model">用户模型</param>
        /// <param name="start">开始条数</param>
        /// <param name="PageSize">页面大小</param>
        /// <returns></returns>
        public int GetHisdesignInfoCount(Hisdesigninfo_View model, List<string> Ids = null)
        {
            return Hisdesigninfo_ViewOper.Instance.SelectUserCount(model, Ids);
        }

        /// <summary>
        /// 根据ID删除历史设计
        /// </summary>
        /// <param name="Id">设计Id</param>
        /// <returns></returns>
        public bool DeleteHisdesignById(int Id)
        {
            return HisdesignOper.Instance.DeleteById(Id);
        }

        /// <summary>
        /// 根据ID删除历史设计
        /// </summary>
        /// <param name="model">历史设计</param>
        /// <returns></returns>
        public bool UpdateHisdesign(Hisdesign model)
        {
            return HisdesignOper.Instance.Update(model);
        }
    }
}
