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
    public partial class GradeOper : SingleTon<GradeOper>
    {
        /// <summary>
        /// 根据主键删除数据
        /// </summary>
        /// <param name="KeyId">主键Id</param>
        /// <param name="connection">连接</param>
        /// <param name="transaction">事务</param>
        /// <returns>是否成功</returns>
        public bool DeleteById(int KeyId, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var delete = new LambdaDelete<Grade>();
            delete.Where(p => p.Id == KeyId);
            return delete.GetDeleteResult(connection, transaction);
        }

        /// <summary>
        /// 根据模型删除数据
        /// </summary>
        /// <param name="model">模型</param>
        /// <param name="connection">连接</param>
        /// <param name="transaction">事务</param>
        /// <returns>是否成功</returns>
        public bool DeleteModel(Grade model = null, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var delete = new LambdaDelete<Grade>();
            if (model != null)
            {
                if (!model.Id.IsNullOrEmpty())
                {
                    delete.Where(p => p.Id == model.Id);
                }
                if (!model.Name.IsNullOrEmpty())
                {
                    delete.Where(p => p.Name == model.Name);
                }
                if (!model.Image.IsNullOrEmpty())
                {
                    delete.Where(p => p.Image == model.Image);
                }
                if (!model.BigImage.IsNullOrEmpty())
                {
                    delete.Where(p => p.BigImage == model.BigImage);
                }
                if (!model.ParentId.IsNullOrEmpty())
                {
                    delete.Where(p => p.ParentId == model.ParentId);
                }
                if (!model.HotGradeTime.IsNullOrEmpty())
                {
                    delete.Where(p => p.HotGradeTime == model.HotGradeTime);
                }
                if (!model.GradeAttrName.IsNullOrEmpty())
                {
                    delete.Where(p => p.GradeAttrName == model.GradeAttrName);
                }
                if (!model.IsDelete.IsNullOrEmpty())
                {
                    delete.Where(p => p.IsDelete == model.IsDelete);
                }
                if (!model.IsScene.IsNullOrEmpty())
                {
                    delete.Where(p => p.IsScene == model.IsScene);
                }
            }
            return delete.GetDeleteResult(connection, transaction);
        }

        /// <summary>
        /// 根据模型更新
        /// </summary>
        /// <param name="model">模型</param>
        /// <param name="connection">连接</param>
        /// <param name="transaction">事务</param>
        /// <returns>是否成功</returns>
        public bool Update(Grade model, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var update = new LambdaUpdate<Grade>();
            if (!model.Id.IsNullOrEmpty())
            {
                update.Where(p => p.Id == model.Id);
            }
            if (!model.Name.IsNullOrEmpty())
            {
                update.Set(p => p.Name == model.Name);
            }
            if (!model.Image.IsNullOrEmpty())
            {
                update.Set(p => p.Image == model.Image);
            }
            if (!model.BigImage.IsNullOrEmpty())
            {
                update.Set(p => p.BigImage == model.BigImage);
            }
            if (!model.ParentId.IsNullOrEmpty())
            {
                update.Set(p => p.ParentId == model.ParentId);
            }
            if (!model.HotGradeTime.IsNullOrEmpty())
            {
                update.Set(p => p.HotGradeTime == model.HotGradeTime);
            }
            if (!model.GradeAttrName.IsNullOrEmpty())
            {
                update.Set(p => p.GradeAttrName == model.GradeAttrName);
            }
            if (!model.IsDelete.IsNullOrEmpty())
            {
                update.Set(p => p.IsDelete == model.IsDelete);
            }
            if (!model.IsScene.IsNullOrEmpty())
            {
                update.Set(p => p.IsScene == model.IsScene);
            }
            return update.GetUpdateResult(connection, transaction);
        }

        /// <summary>
        /// 根据模型插入
        /// </summary>
        /// <param name="model">模型</param>
        /// <param name="connection">连接</param>
        /// <param name="transaction">事务</param>
        /// <returns>是否成功</returns>
        public bool Insert(Grade model, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var insert = new LambdaInsert<Grade>();
            if (!model.Name.IsNullOrEmpty())
            {
                insert.Insert(p => p.Name == model.Name);
            }
            if (!model.Image.IsNullOrEmpty())
            {
                insert.Insert(p => p.Image == model.Image);
            }
            if (!model.BigImage.IsNullOrEmpty())
            {
                insert.Insert(p => p.BigImage == model.BigImage);
            }
            if (!model.ParentId.IsNullOrEmpty())
            {
                insert.Insert(p => p.ParentId == model.ParentId);
            }
            if (!model.HotGradeTime.IsNullOrEmpty())
            {
                insert.Insert(p => p.HotGradeTime == model.HotGradeTime);
            }
            if (!model.GradeAttrName.IsNullOrEmpty())
            {
                insert.Insert(p => p.GradeAttrName == model.GradeAttrName);
            }
            if (!model.IsDelete.IsNullOrEmpty())
            {
                insert.Insert(p => p.IsDelete == model.IsDelete);
            }
            if (!model.IsScene.IsNullOrEmpty())
            {
                insert.Insert(p => p.IsScene == model.IsScene);
            }
            return insert.GetInsertResult(connection, transaction) >= 0;
        }

        /// <summary>
        /// 根据模型插入
        /// </summary>
        /// <param name="model">模型</param>
        /// <param name="connection">连接</param>
        /// <param name="transaction">事务</param>
        /// <returns>是否成功</returns>
        public int InsertReturnKey(Grade model, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var insert = new LambdaInsert<Grade>();
            if (!model.Name.IsNullOrEmpty())
            {
                insert.Insert(p => p.Name == model.Name);
            }
            if (!model.Image.IsNullOrEmpty())
            {
                insert.Insert(p => p.Image == model.Image);
            }
            if (!model.BigImage.IsNullOrEmpty())
            {
                insert.Insert(p => p.BigImage == model.BigImage);
            }
            if (!model.ParentId.IsNullOrEmpty())
            {
                insert.Insert(p => p.ParentId == model.ParentId);
            }
            if (!model.HotGradeTime.IsNullOrEmpty())
            {
                insert.Insert(p => p.HotGradeTime == model.HotGradeTime);
            }
            if (!model.GradeAttrName.IsNullOrEmpty())
            {
                insert.Insert(p => p.GradeAttrName == model.GradeAttrName);
            }
            if (!model.IsDelete.IsNullOrEmpty())
            {
                insert.Insert(p => p.IsDelete == model.IsDelete);
            }
            if (!model.IsScene.IsNullOrEmpty())
            {
                insert.Insert(p => p.IsScene == model.IsScene);
            }
            return insert.GetInsertResult(connection, transaction);
        }

        /// <summary>
        /// 筛选全部数据
        /// </summary>
        /// <param name="model">模型</param>
        /// <param name="connection">连接</param>
        /// <param name="transaction">事务</param>
        /// <returns>对象列表</returns>
        public List<Grade> SelectAll(Grade model = null, string SelectFiled = null, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var query = new LambdaQuery<Grade>();
            if (model != null)
            {
                if (!model.Id.IsNullOrEmpty())
                {
                    query.Where(p => p.Id == model.Id);
                }
                if (!model.Name.IsNullOrEmpty())
                {
                    query.Where(p => p.Name == model.Name);
                }
                if (!model.Image.IsNullOrEmpty())
                {
                    query.Where(p => p.Image == model.Image);
                }
                if (!model.BigImage.IsNullOrEmpty())
                {
                    query.Where(p => p.BigImage == model.BigImage);
                }
                if (!model.ParentId.IsNullOrEmpty())
                {
                    query.Where(p => p.ParentId == model.ParentId);
                }
                if (!model.HotGradeTime.IsNullOrEmpty())
                {
                    query.Where(p => p.HotGradeTime == model.HotGradeTime);
                }
                if (!model.GradeAttrName.IsNullOrEmpty())
                {
                    query.Where(p => p.GradeAttrName == model.GradeAttrName);
                }
                if (!model.IsDelete.IsNullOrEmpty())
                {
                    query.Where(p => p.IsDelete == model.IsDelete);
                }
                if (!model.IsScene.IsNullOrEmpty())
                {
                    query.Where(p => p.IsScene == model.IsScene);
                }
            }
            if (SelectFiled != null)
            {
                SelectFiled = SelectFiled.ToLowerInvariant();
                if (SelectFiled.Contains("id,"))
                {
                    query.Select(p => new { p.Id });
                }
                if (SelectFiled.Contains("name,"))
                {
                    query.Select(p => new { p.Name });
                }
                if (SelectFiled.Contains("image,"))
                {
                    query.Select(p => new { p.Image });
                }
                if (SelectFiled.Contains("bigimage,"))
                {
                    query.Select(p => new { p.BigImage });
                }
                if (SelectFiled.Contains("parentid,"))
                {
                    query.Select(p => new { p.ParentId });
                }
                if (SelectFiled.Contains("hotgradetime,"))
                {
                    query.Select(p => new { p.HotGradeTime });
                }
                if (SelectFiled.Contains("gradeattrname,"))
                {
                    query.Select(p => new { p.GradeAttrName });
                }
                if (SelectFiled.Contains("isdelete,"))
                {
                    query.Select(p => new { p.IsDelete });
                }
                if (SelectFiled.Contains("isscene,"))
                {
                    query.Select(p => new { p.IsScene });
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
        public int SelectCount(Grade model = null, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var query = new LambdaQuery<Grade>();
            if (model != null)
            {
                if (!model.Id.IsNullOrEmpty())
                {
                    query.Where(p => p.Id == model.Id);
                }
                if (!model.Name.IsNullOrEmpty())
                {
                    query.Where(p => p.Name == model.Name);
                }
                if (!model.Image.IsNullOrEmpty())
                {
                    query.Where(p => p.Image == model.Image);
                }
                if (!model.BigImage.IsNullOrEmpty())
                {
                    query.Where(p => p.BigImage == model.BigImage);
                }
                if (!model.ParentId.IsNullOrEmpty())
                {
                    query.Where(p => p.ParentId == model.ParentId);
                }
                if (!model.HotGradeTime.IsNullOrEmpty())
                {
                    query.Where(p => p.HotGradeTime == model.HotGradeTime);
                }
                if (!model.GradeAttrName.IsNullOrEmpty())
                {
                    query.Where(p => p.GradeAttrName == model.GradeAttrName);
                }
                if (!model.IsDelete.IsNullOrEmpty())
                {
                    query.Where(p => p.IsDelete == model.IsDelete);
                }
                if (!model.IsScene.IsNullOrEmpty())
                {
                    query.Where(p => p.IsScene == model.IsScene);
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
        public Grade SelectById(int KeyId, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var query = new LambdaQuery<Grade>();
            query.Where(p => p.Id == KeyId);
            return query.GetQueryList(connection, transaction).FirstOrDefault();
        }


        /// <summary>
        /// 根据主键筛选数据
        /// </summary>
        /// <param name="KeyId">主键Id</param>
        /// <param name="connection">连接</param>
        /// <param name="transaction">事务</param>
        /// <returns>是否成功</returns>
        public List<Grade> SelectByKeys(string Key,List<string> KeyIds, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var query = new LambdaQuery<Grade>();
            if("id" == Key.ToLowerInvariant())
            {
                query.Where(p => p.Id.In(KeyIds));
            }
            if("name" == Key.ToLowerInvariant())
            {
                query.Where(p => p.Name.In(KeyIds));
            }
            if("image" == Key.ToLowerInvariant())
            {
                query.Where(p => p.Image.In(KeyIds));
            }
            if("bigimage" == Key.ToLowerInvariant())
            {
                query.Where(p => p.BigImage.In(KeyIds));
            }
            if("parentid" == Key.ToLowerInvariant())
            {
                query.Where(p => p.ParentId.In(KeyIds));
            }
            if("hotgradetime" == Key.ToLowerInvariant())
            {
                query.Where(p => p.HotGradeTime.In(KeyIds));
            }
            if("gradeattrname" == Key.ToLowerInvariant())
            {
                query.Where(p => p.GradeAttrName.In(KeyIds));
            }
            if("isdelete" == Key.ToLowerInvariant())
            {
                query.Where(p => p.IsDelete.In(KeyIds));
            }
            if("isscene" == Key.ToLowerInvariant())
            {
                query.Where(p => p.IsScene.In(KeyIds));
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
        public List<Grade> SelectByPage(string Key, int start, int PageSize, bool desc = true,Grade model = null, string SelectFiled = null, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var query = new LambdaQuery<Grade>();
            if (model != null)
            {
                if (!model.Id.IsNullOrEmpty())
                {
                    query.Where(p => p.Id == model.Id);
                }
                if (!model.Name.IsNullOrEmpty())
                {
                    query.Where(p => p.Name == model.Name);
                }
                if (!model.Image.IsNullOrEmpty())
                {
                    query.Where(p => p.Image == model.Image);
                }
                if (!model.BigImage.IsNullOrEmpty())
                {
                    query.Where(p => p.BigImage == model.BigImage);
                }
                if (!model.ParentId.IsNullOrEmpty())
                {
                    query.Where(p => p.ParentId == model.ParentId);
                }
                if (!model.HotGradeTime.IsNullOrEmpty())
                {
                    query.Where(p => p.HotGradeTime == model.HotGradeTime);
                }
                if (!model.GradeAttrName.IsNullOrEmpty())
                {
                    query.Where(p => p.GradeAttrName == model.GradeAttrName);
                }
                if (!model.IsDelete.IsNullOrEmpty())
                {
                    query.Where(p => p.IsDelete == model.IsDelete);
                }
                if (!model.IsScene.IsNullOrEmpty())
                {
                    query.Where(p => p.IsScene == model.IsScene);
                }
            }
            if (SelectFiled != null)
            {
                SelectFiled = SelectFiled.ToLowerInvariant();
                if (SelectFiled.Contains("id,"))
                {
                    query.Select(p => new { p.Id });
                }
                if (SelectFiled.Contains("name,"))
                {
                    query.Select(p => new { p.Name });
                }
                if (SelectFiled.Contains("image,"))
                {
                    query.Select(p => new { p.Image });
                }
                if (SelectFiled.Contains("bigimage,"))
                {
                    query.Select(p => new { p.BigImage });
                }
                if (SelectFiled.Contains("parentid,"))
                {
                    query.Select(p => new { p.ParentId });
                }
                if (SelectFiled.Contains("hotgradetime,"))
                {
                    query.Select(p => new { p.HotGradeTime });
                }
                if (SelectFiled.Contains("gradeattrname,"))
                {
                    query.Select(p => new { p.GradeAttrName });
                }
                if (SelectFiled.Contains("isdelete,"))
                {
                    query.Select(p => new { p.IsDelete });
                }
                if (SelectFiled.Contains("isscene,"))
                {
                    query.Select(p => new { p.IsScene });
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
