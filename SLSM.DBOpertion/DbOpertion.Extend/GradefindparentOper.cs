using Common;
using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common.LambdaOpertion;
using Common.Extend;
using System.Data;
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
        public List<Gradefindparent> SelectAll1(Gradefindparent model = null, IDbConnection connection = null, IDbTransaction transaction = null)
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
                if (!model.HotGradeTime.IsNullOrEmpty())
                {
                    query.Where(p => p.HotGradeTime == model.HotGradeTime);
                }
                if (!model.GradeAttrName.IsNullOrEmpty())
                {
                    query.Where(p => p.GradeAttrName == model.GradeAttrName);
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
        public int SelectCount1(Gradefindparent model = null, IDbConnection connection = null, IDbTransaction transaction = null)
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
        public Gradefindparent SelectById1(int KeyId, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var query = new LambdaQuery<Gradefindparent>();
            query.Where(p => p.id == KeyId);
            return query.GetQueryList(connection, transaction).FirstOrDefault();
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
        public List<Gradefindparent> SelectByPage1(string Key, int start, int PageSize, bool desc = true, Gradefindparent model = null, IDbConnection connection = null, IDbTransaction transaction = null)
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
                if (!model.HotGradeTime.IsNullOrEmpty())
                {
                    query.Where(p => p.HotGradeTime == model.HotGradeTime);
                }
                if (!model.GradeAttrName.IsNullOrEmpty())
                {
                    query.Where(p => p.GradeAttrName == model.GradeAttrName);
                }
            }
            if (Key != null)
            {
                query.OrderByKey(Key, desc);
            }
            return query.GetQueryPageList(start, PageSize, connection, transaction);
        }

        /// <summary>
        /// 根据某一分类获取它和它的子孙分类
        /// </summary>
        /// <param name="model"></param>
        /// <param name="connection"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public List<Gradefindparent> SelectFamilyByGradeId(Gradefindparent model = null, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var query = new LambdaQuery<Gradefindparent>();
            if (model != null)
            {
                if (!model.grandpaId.IsNullOrEmpty())
                {
                    query.Where(p => p.grandpaId == model.grandpaId || p.id == model.id || p.parentId == model.parentId);
                }
            }
            return query.GetQueryList(connection, transaction);
        }
    }
}
