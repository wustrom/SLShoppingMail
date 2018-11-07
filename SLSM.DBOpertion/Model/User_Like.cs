using System;

namespace DbOpertion.Models
{
    [Serializable]
    public class User_Like
    {
        /// <summary>
        /// 用户收藏表id
        /// </summary>
        public Int32 Id { get; set; }
        /// <summary>
        /// 用户id
        /// </summary>
        public Int32? UserId { get; set; }
        /// <summary>
        /// 商品id
        /// </summary>
        public Int32? CommodityId { get; set; }

    }
}
