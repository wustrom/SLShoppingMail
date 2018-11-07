using Common;
using DbOpertion.Operation;
using DbOpertion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbOpertion.Function
{
    /// <summary>
    /// 用户喜欢方法
    /// </summary>
    public partial class UserLikeFunc : SingleTon<UserLikeFunc>
    {
        /// <summary>
        /// 该商品的收藏数目
        /// </summary>
        /// <param name="CommodityId">商品Id</param>
        /// <returns></returns>
        public int UserLikeCount(int CommodityId)
        {
            return User_LikeOper.Instance.SelectCount(new User_Like { CommodityId = CommodityId });
        }
        /// <summary>
        /// 筛选用户收藏个数
        /// </summary>
        /// <param name="UserId">用户Id</param>
        /// <returns></returns>
        public int SelectLikeCount(int UserId)
        {
            return User_LikeOper.Instance.SelectCount(new User_Like { UserId = UserId });
        }
        /// <summary>
        /// 用户是否收藏该商品
        /// </summary>
        /// <param name="UserId">用户Id</param>
        /// <param name="CommodityId">商品Id</param>
        /// <returns></returns>
        public bool UserLikeCount(int UserId, int CommodityId)
        {
            return User_LikeOper.Instance.SelectCount(new User_Like { UserId = UserId, CommodityId = CommodityId }) > 0 ? true : false;
        }

        /// <summary>
        /// 用户收藏该商品
        /// </summary>
        /// <param name="UserId">用户Id</param>
        /// <param name="CommodityId">商品Id</param>
        /// <param name="Opertion">操作(是否为收藏)</param>
        /// <returns></returns>
        public string UserLikeCommodityId(int UserId, int CommodityId, bool Opertion)
        {
            if (!UserLikeCount(UserId, CommodityId))
            {
                return User_LikeOper.Instance.Insert(new User_Like { CommodityId = CommodityId, UserId = UserId }).ToString();
            }
            else
            {
                if (Opertion)
                {
                    return "该商品已被收藏！";
                }
                else
                {
                    return User_LikeOper.Instance.DeleteModel(new User_Like { CommodityId = CommodityId, UserId = UserId }).ToString();
                }

            }
        }
        /// <summary>
        ///根据Id进行筛选 
        /// </summary>
        /// <param name="start"></param>
        /// <param name="PageSize"></param>
        /// <param name="UserId"></param>
        /// <returns></returns>
        public List<Userlike_Commodity_View> SelectLikePage(int start,int PageSize,int UserId)
        {
            return Userlike_Commodity_ViewOper.Instance.SelectByPage("Id", start,PageSize,true, new Userlike_Commodity_View { UserId = UserId });
        }
        /// <summary>
        /// 取消收藏
        /// </summary>
        /// <returns></returns>
        public bool DeleteLike(int Id)
        {
            return User_LikeOper.Instance.DeleteById(Id);

        }
    }
}
