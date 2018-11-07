using Common;
using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common.LambdaOpertion;
using Common.Extend;
using System.Data;
using Common.Extend.LambdaFunction;
using DbOpertion.Models;

namespace DbOpertion.Operation
{
    public partial class GradefindparentOper : SingleTon<GradefindparentOper>
    {
        /// <summary>
        /// 筛选全部数据
        /// </summary>
        /// <param name="model">模型</param>
        /// <param name="connection">连接</param>
        /// <param name="transaction">事务</param>
        /// <returns>对象列表</returns>
        public List<Gradefindparent> SelectAll(Gradefindparent model = null, string SelectFiled = null, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var query = new LambdaQuery<Gradefindparent>();
            if (model != null)
            {
                if (!model.grandpaId.IsNullOrEmpty())
                {
                    query.Where(p => p.grandpaId == model.grandpaId);
                }
                if (!model.grandpaName.IsNullOrEmpty())
                {
                    query.Where(p => p.grandpaName == model.grandpaName);
                }
                if (!model.grandpaImage.IsNullOrEmpty())
                {
                    query.Where(p => p.grandpaImage == model.grandpaImage);
                }
                if (!model.grandpaBigImage.IsNullOrEmpty())
                {
                    query.Where(p => p.grandpaBigImage == model.grandpaBigImage);
                }
                if (!model.parentId.IsNullOrEmpty())
                {
                    query.Where(p => p.parentId == model.parentId);
                }
                if (!model.parentName.IsNullOrEmpty())
                {
                    query.Where(p => p.parentName == model.parentName);
                }
                if (!model.parentImage.IsNullOrEmpty())
                {
                    query.Where(p => p.parentImage == model.parentImage);
                }
                if (!model.parentBigImage.IsNullOrEmpty())
                {
                    query.Where(p => p.parentBigImage == model.parentBigImage);
                }
                if (!model.id.IsNullOrEmpty())
                {
                    query.Where(p => p.id == model.id);
                }
                if (!model.gradeName.IsNullOrEmpty())
                {
                    query.Where(p => p.gradeName == model.gradeName);
                }
                if (!model.gradeImage.IsNullOrEmpty())
                {
                    query.Where(p => p.gradeImage == model.gradeImage);
                }
                if (!model.gradeBigImage.IsNullOrEmpty())
                {
                    query.Where(p => p.gradeBigImage == model.gradeBigImage);
                }
                if (!model.HotGradeTime.IsNullOrEmpty())
                {
                    query.Where(p => p.HotGradeTime == model.HotGradeTime);
                }
                if (!model.GradeAttrName.IsNullOrEmpty())
                {
                    query.Where(p => p.GradeAttrName == model.GradeAttrName);
                }
            }
            if (SelectFiled != null)
            {
                SelectFiled = SelectFiled.ToLowerInvariant();
                if (SelectFiled.Contains("grandpaid,"))
                {
                    query.Select(p => new { p.grandpaId });
                }
                if (SelectFiled.Contains("grandpaname,"))
                {
                    query.Select(p => new { p.grandpaName });
                }
                if (SelectFiled.Contains("grandpaimage,"))
                {
                    query.Select(p => new { p.grandpaImage });
                }
                if (SelectFiled.Contains("grandpabigimage,"))
                {
                    query.Select(p => new { p.grandpaBigImage });
                }
                if (SelectFiled.Contains("parentid,"))
                {
                    query.Select(p => new { p.parentId });
                }
                if (SelectFiled.Contains("parentname,"))
                {
                    query.Select(p => new { p.parentName });
                }
                if (SelectFiled.Contains("parentimage,"))
                {
                    query.Select(p => new { p.parentImage });
                }
                if (SelectFiled.Contains("parentbigimage,"))
                {
                    query.Select(p => new { p.parentBigImage });
                }
                if (SelectFiled.Contains("id,"))
                {
                    query.Select(p => new { p.id });
                }
                if (SelectFiled.Contains("gradename,"))
                {
                    query.Select(p => new { p.gradeName });
                }
                if (SelectFiled.Contains("gradeimage,"))
                {
                    query.Select(p => new { p.gradeImage });
                }
                if (SelectFiled.Contains("gradebigimage,"))
                {
                    query.Select(p => new { p.gradeBigImage });
                }
                if (SelectFiled.Contains("hotgradetime,"))
                {
                    query.Select(p => new { p.HotGradeTime });
                }
                if (SelectFiled.Contains("gradeattrname,"))
                {
                    query.Select(p => new { p.GradeAttrName });
                }
            }
            return query.GetQueryList(connection, transaction);
        }

        /// <summary>
        /// 数据条数
        /// </summary>
        /// <param name="model">模型</param>
        /// <param name="connection">连接</param>
        /// <param name="transaction">事务</param>
        /// <returns>对象列表</returns>
        public int SelectCount(Gradefindparent model = null, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var query = new LambdaQuery<Gradefindparent>();
            if (model != null)
            {
                if (!model.grandpaId.IsNullOrEmpty())
                {
                    query.Where(p => p.grandpaId == model.grandpaId);
                }
                if (!model.grandpaName.IsNullOrEmpty())
                {
                    query.Where(p => p.grandpaName == model.grandpaName);
                }
                if (!model.grandpaImage.IsNullOrEmpty())
                {
                    query.Where(p => p.grandpaImage == model.grandpaImage);
                }
                if (!model.grandpaBigImage.IsNullOrEmpty())
                {
                    query.Where(p => p.grandpaBigImage == model.grandpaBigImage);
                }
                if (!model.parentId.IsNullOrEmpty())
                {
                    query.Where(p => p.parentId == model.parentId);
                }
                if (!model.parentName.IsNullOrEmpty())
                {
                    query.Where(p => p.parentName == model.parentName);
                }
                if (!model.parentImage.IsNullOrEmpty())
                {
                    query.Where(p => p.parentImage == model.parentImage);
                }
                if (!model.parentBigImage.IsNullOrEmpty())
                {
                    query.Where(p => p.parentBigImage == model.parentBigImage);
                }
                if (!model.id.IsNullOrEmpty())
                {
                    query.Where(p => p.id == model.id);
                }
                if (!model.gradeName.IsNullOrEmpty())
                {
                    query.Where(p => p.gradeName == model.gradeName);
                }
                if (!model.gradeImage.IsNullOrEmpty())
                {
                    query.Where(p => p.gradeImage == model.gradeImage);
                }
                if (!model.gradeBigImage.IsNullOrEmpty())
                {
                    query.Where(p => p.gradeBigImage == model.gradeBigImage);
                }
                if (!model.HotGradeTime.IsNullOrEmpty())
                {
                    query.Where(p => p.HotGradeTime == model.HotGradeTime);
                }
                if (!model.GradeAttrName.IsNullOrEmpty())
                {
                    query.Where(p => p.GradeAttrName == model.GradeAttrName);
                }
            }
            return query.GetQueryCount(connection, transaction);
        }

        /// <summary>
        /// 根据主键筛选数据
        /// </summary>
        /// <param name="KeyId">主键Id</param>
        /// <param name="connection">连接</param>
        /// <param name="transaction">事务</param>
        /// <returns>是否成功</returns>
        public Gradefindparent SelectById(int KeyId, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var query = new LambdaQuery<Gradefindparent>();
            return query.GetQueryList(connection, transaction).FirstOrDefault();
        }


        /// <summary>
        /// 根据主键筛选数据
        /// </summary>
        /// <param name="KeyId">主键Id</param>
        /// <param name="connection">连接</param>
        /// <param name="transaction">事务</param>
        /// <returns>是否成功</returns>
        public List<Gradefindparent> SelectByKeys(string Key,List<string> KeyIds, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var query = new LambdaQuery<Gradefindparent>();
            if("grandpaid" == Key.ToLowerInvariant())
            {
                query.Where(p => p.grandpaId.In(KeyIds));
            }
            if("grandpaname" == Key.ToLowerInvariant())
            {
                query.Where(p => p.grandpaName.In(KeyIds));
            }
            if("grandpaimage" == Key.ToLowerInvariant())
            {
                query.Where(p => p.grandpaImage.In(KeyIds));
            }
            if("grandpabigimage" == Key.ToLowerInvariant())
            {
                query.Where(p => p.grandpaBigImage.In(KeyIds));
            }
            if("parentid" == Key.ToLowerInvariant())
            {
                query.Where(p => p.parentId.In(KeyIds));
            }
            if("parentname" == Key.ToLowerInvariant())
            {
                query.Where(p => p.parentName.In(KeyIds));
            }
            if("parentimage" == Key.ToLowerInvariant())
            {
                query.Where(p => p.parentImage.In(KeyIds));
            }
            if("parentbigimage" == Key.ToLowerInvariant())
            {
                query.Where(p => p.parentBigImage.In(KeyIds));
            }
            if("id" == Key.ToLowerInvariant())
            {
                query.Where(p => p.id.In(KeyIds));
            }
            if("gradename" == Key.ToLowerInvariant())
            {
                query.Where(p => p.gradeName.In(KeyIds));
            }
            if("gradeimage" == Key.ToLowerInvariant())
            {
                query.Where(p => p.gradeImage.In(KeyIds));
            }
            if("gradebigimage" == Key.ToLowerInvariant())
            {
                query.Where(p => p.gradeBigImage.In(KeyIds));
            }
            if("hotgradetime" == Key.ToLowerInvariant())
            {
                query.Where(p => p.HotGradeTime.In(KeyIds));
            }
            if("gradeattrname" == Key.ToLowerInvariant())
            {
                query.Where(p => p.GradeAttrName.In(KeyIds));
            }
            return query.GetQueryList(connection, transaction);
        }

        /// <summary>
        /// 根据分页筛选数据
        /// </summary>
        /// <param name="Key">主键</param>
        /// <param name="start">开始数据</param>
        /// <param name="PageSize">页面长度</param>
        /// <param name="desc">排序</param>
        /// <param name="model">对象</param>
        /// <param name="connection">连接</param>
        /// <param name="transaction">事务</param>
        /// <returns>对象列表</returns>
        public List<Gradefindparent> SelectByPage(string Key, int start, int PageSize, bool desc = true,Gradefindparent model = null, string SelectFiled = null, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var query = new LambdaQuery<Gradefindparent>();
            if (model != null)
            {
                if (!model.grandpaId.IsNullOrEmpty())
                {
                    query.Where(p => p.grandpaId == model.grandpaId);
                }
                if (!model.grandpaName.IsNullOrEmpty())
                {
                    query.Where(p => p.grandpaName == model.grandpaName);
                }
                if (!model.grandpaImage.IsNullOrEmpty())
                {
                    query.Where(p => p.grandpaImage == model.grandpaImage);
                }
                if (!model.grandpaBigImage.IsNullOrEmpty())
                {
                    query.Where(p => p.grandpaBigImage == model.grandpaBigImage);
                }
                if (!model.parentId.IsNullOrEmpty())
                {
                    query.Where(p => p.parentId == model.parentId);
                }
                if (!model.parentName.IsNullOrEmpty())
                {
                    query.Where(p => p.parentName == model.parentName);
                }
                if (!model.parentImage.IsNullOrEmpty())
                {
                    query.Where(p => p.parentImage == model.parentImage);
                }
                if (!model.parentBigImage.IsNullOrEmpty())
                {
                    query.Where(p => p.parentBigImage == model.parentBigImage);
                }
                if (!model.id.IsNullOrEmpty())
                {
                    query.Where(p => p.id == model.id);
                }
                if (!model.gradeName.IsNullOrEmpty())
                {
                    query.Where(p => p.gradeName == model.gradeName);
                }
                if (!model.gradeImage.IsNullOrEmpty())
                {
                    query.Where(p => p.gradeImage == model.gradeImage);
                }
                if (!model.gradeBigImage.IsNullOrEmpty())
                {
                    query.Where(p => p.gradeBigImage == model.gradeBigImage);
                }
                if (!model.HotGradeTime.IsNullOrEmpty())
                {
                    query.Where(p => p.HotGradeTime == model.HotGradeTime);
                }
                if (!model.GradeAttrName.IsNullOrEmpty())
                {
                    query.Where(p => p.GradeAttrName == model.GradeAttrName);
                }
            }
            if (SelectFiled != null)
            {
                SelectFiled = SelectFiled.ToLowerInvariant();
                if (SelectFiled.Contains("grandpaid,"))
                {
                    query.Select(p => new { p.grandpaId });
                }
                if (SelectFiled.Contains("grandpaname,"))
                {
                    query.Select(p => new { p.grandpaName });
                }
                if (SelectFiled.Contains("grandpaimage,"))
                {
                    query.Select(p => new { p.grandpaImage });
                }
                if (SelectFiled.Contains("grandpabigimage,"))
                {
                    query.Select(p => new { p.grandpaBigImage });
                }
                if (SelectFiled.Contains("parentid,"))
                {
                    query.Select(p => new { p.parentId });
                }
                if (SelectFiled.Contains("parentname,"))
                {
                    query.Select(p => new { p.parentName });
                }
                if (SelectFiled.Contains("parentimage,"))
                {
                    query.Select(p => new { p.parentImage });
                }
                if (SelectFiled.Contains("parentbigimage,"))
                {
                    query.Select(p => new { p.parentBigImage });
                }
                if (SelectFiled.Contains("id,"))
                {
                    query.Select(p => new { p.id });
                }
                if (SelectFiled.Contains("gradename,"))
                {
                    query.Select(p => new { p.gradeName });
                }
                if (SelectFiled.Contains("gradeimage,"))
                {
                    query.Select(p => new { p.gradeImage });
                }
                if (SelectFiled.Contains("gradebigimage,"))
                {
                    query.Select(p => new { p.gradeBigImage });
                }
                if (SelectFiled.Contains("hotgradetime,"))
                {
                    query.Select(p => new { p.HotGradeTime });
                }
                if (SelectFiled.Contains("gradeattrname,"))
                {
                    query.Select(p => new { p.GradeAttrName });
                }
            }
            if (Key != null)
            {
                query.OrderByKey(Key, desc);
            }
            return query.GetQueryPageList(start, PageSize, connection, transaction);
        }
    }
}
