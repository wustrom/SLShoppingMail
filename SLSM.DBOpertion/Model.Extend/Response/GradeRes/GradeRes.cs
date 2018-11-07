using DbOpertion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLSM.DBOpertion.Model.Extend.Response.GradeRes
{
    
    public class GradeRes
    {
        public GradeRes() { }
        public GradeRes(Grade g)
        {
            id = g.Id;
            name = g.Name;
            Image = g.Image;
            BigImage = g.BigImage;
        }
        public string name { get; set; }
        public string BigImage { get; set; }
        public string Image { get; set; }
        public int id { get; set; }
        public List<GradeRes> listGrade { get; set; }
    }

    public class GradeResForWeb {
        public GradeResForWeb() { }
        public GradeResForWeb(Grade g)
        {
            id = g.Id;
            name = g.Name;
            Image = g.Image;
        }
        public string name { get; set; }
        public int id { get; set; }
        public string Image { get; set; }
        public string icon { set; get; }
        public string classStr { get; set; }
        public List<GradeResForWeb> listGrade { get; set; }
    }


    public class GradeId_Name_Img
    {
        string AdminUrl = System.Configuration.ConfigurationManager.AppSettings["AdminUrl"];
        public GradeId_Name_Img()
        {

        }

        public GradeId_Name_Img(Grade g)
        {
            id = g.Id;
            name = g.Name;
            image = AdminUrl + g.Image;//-txy
        }
        public int id { get; set; }

        public string name { get; set; }

        public string image { get; set; }
    }

    public class ThreeGrade {
        public int id { get; set; }

        public string name { get; set; }

        public ThreeGrade sonGrade { get; set; }
    }
}
