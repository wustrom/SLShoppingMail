using DbOpertion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SLSM.AdminWeb.Model.Request.Grade
{
    public class AllReq
    {
        public string gradeId { get; set; }
        public string fatherId { set; get; }
        public string fatherName { get; set; }
        public string gradeImg { get; set; }
        public string gradeBigImg { get; set; }
        public string gradeName { get; set; }
        public string CommdityList { get; set; }
        public bool? IsScence { get; set; }
        
    }

    public class GradeDetailReq
    {
        public GradeDetailReq() { }
        public GradeDetailReq(string FatherId,string FatherName) {
            fatherId = FatherId??"";
            fatherName = FatherName ?? "";
        }
        public GradeDetailReq(Gradefindparent req)
        {
            gradeId = req.id.ToString();
            gradeName = req.gradeName ?? "";
            gradeAttr = req.GradeAttrName ?? "";
            if (req.parentId != null)
                fatherId = req.parentId.ToString();
            else
                fatherId = "";
            fatherName = req.parentName ?? "";
            img = req.gradeImage;
            Bigimg = req.gradeBigImage;
        }
        public string gradeId { get; set; }
        public string gradeName { get; set; }
        public string gradeAttr { get; set; }
        public string fatherId { set; get; }
        public string fatherName { get; set; }
        public string img { get; set; }
        public string Bigimg { get; set; }
        public List<string> attrList { get; set; }
    }
}