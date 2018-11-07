using DbOpertion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SLSM.Web.Models.Response.UserLike
{
    public class UserLikeResponse
    {
        public UserLikeResponse(User_Like us)
        {
            this.Id =us.Id;
            this.UserId = us.UserId;
            this.CommodityId = us.CommodityId;
        }
             /// <summary>
             ///
             /// </summary>
        public Int32 Id { get; set; }
        /// <summary>
        ///
        /// </summary>
        public Int32? UserId { get; set; }
        /// <summary>
        ///
        /// </summary>
        public Int32? CommodityId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<CommodityResponse> ListCommdity { get; set; }
    }




    public class CommodityResponse
    {
        public CommodityResponse(Commodity com)
        {
            this.Id = com.Id;
            this.Name = com.Name;
            this.Image = com.Image;
            this.GradeId = com.GradeId;
            this.FrontView = com.FrontView;

            this.BackView = com.BackView;
            this.PrintingMethod = com.PrintingMethod;
            this.Color = com.Color;
            this.Content = com.Content;
        }
        /// <summary>
        ///
        /// </summary>
        public Int32 Id { get; set; }
        /// <summary>
        ///
        /// </summary>
        public String Name { get; set; }
        /// <summary>
        ///
        /// </summary>
        public String Image { get; set; }
        /// <summary>
        ///
        /// </summary>
        public Int32? GradeId { get; set; }
        /// <summary>
        ///
        /// </summary>
        public String FrontView { get; set; }
        /// <summary>
        ///
        /// </summary>
        public String BackView { get; set; }
        /// <summary>
        ///
        /// </summary>
        public Int32? PrintingMethod { get; set; }
        /// <summary>
        ///
        /// </summary>
        public String Color { get; set; }
        /// <summary>
        ///
        /// </summary>
        public String Content { get; set; }
        /// <summary>
        ///
        /// </summary>
        public Int32? Sales { get; set; }
        /// <summary>
        ///
        /// </summary>
        public DateTime? CreateTime { get; set; }
        /// <summary>
        ///
        /// </summary>
        public DateTime? RecommendTime { get; set; }
        /// <summary>
        ///
        /// </summary>
        public String Points { get; set; }
        /// <summary>
        ///
        /// </summary>
        public Boolean? IsRelease { get; set; }
        /// <summary>
        ///
        /// </summary>
        public DateTime? LastOperTime { get; set; }
        /// <summary>
        ///
        /// </summary>
        public Int32? LastOperId { get; set; }
        /// <summary>
        ///
        /// </summary>
        public Int32? ClickCount { get; set; }
        /// <summary>
        ///
        /// </summary>
        public Decimal? Stars { get; set; }
        /// <summary>
        ///
        /// </summary>
        public Int32? StarCount { get; set; }
        /// <summary>
        ///
        /// </summary>
        public String Introduce { get; set; }
        /// <summary>
        ///
        /// </summary>
        public String ImageList { get; set; }
        /// <summary>
        ///
        /// </summary>
        public Boolean? IsDelete { get; set; }

    }

}