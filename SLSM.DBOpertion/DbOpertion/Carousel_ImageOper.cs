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
    public partial class Carousel_ImageOper : SingleTon<Carousel_ImageOper>
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
            var delete = new LambdaDelete<Carousel_Image>();
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
        public bool DeleteModel(Carousel_Image model = null, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var delete = new LambdaDelete<Carousel_Image>();
            if (model != null)
            {
                if (!model.Id.IsNullOrEmpty())
                {
                    delete.Where(p => p.Id == model.Id);
                }
                if (!model.Image.IsNullOrEmpty())
                {
                    delete.Where(p => p.Image == model.Image);
                }
                if (!model.OrderID.IsNullOrEmpty())
                {
                    delete.Where(p => p.OrderID == model.OrderID);
                }
                if (!model.AUrl.IsNullOrEmpty())
                {
                    delete.Where(p => p.AUrl == model.AUrl);
                }
                if (!model.IsCarousel.IsNullOrEmpty())
                {
                    delete.Where(p => p.IsCarousel == model.IsCarousel);
                }
                if (!model.IsPC.IsNullOrEmpty())
                {
                    delete.Where(p => p.IsPC == model.IsPC);
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
        public bool Update(Carousel_Image model, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var update = new LambdaUpdate<Carousel_Image>();
            if (!model.Id.IsNullOrEmpty())
            {
                update.Where(p => p.Id == model.Id);
            }
            if (!model.Image.IsNullOrEmpty())
            {
                update.Set(p => p.Image == model.Image);
            }
            if (!model.OrderID.IsNullOrEmpty())
            {
                update.Set(p => p.OrderID == model.OrderID);
            }
            if (!model.AUrl.IsNullOrEmpty())
            {
                update.Set(p => p.AUrl == model.AUrl);
            }
            if (!model.IsCarousel.IsNullOrEmpty())
            {
                update.Set(p => p.IsCarousel == model.IsCarousel);
            }
            if (!model.IsPC.IsNullOrEmpty())
            {
                update.Set(p => p.IsPC == model.IsPC);
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
        public bool Insert(Carousel_Image model, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var insert = new LambdaInsert<Carousel_Image>();
            if (!model.Image.IsNullOrEmpty())
            {
                insert.Insert(p => p.Image == model.Image);
            }
            if (!model.OrderID.IsNullOrEmpty())
            {
                insert.Insert(p => p.OrderID == model.OrderID);
            }
            if (!model.AUrl.IsNullOrEmpty())
            {
                insert.Insert(p => p.AUrl == model.AUrl);
            }
            if (!model.IsCarousel.IsNullOrEmpty())
            {
                insert.Insert(p => p.IsCarousel == model.IsCarousel);
            }
            if (!model.IsPC.IsNullOrEmpty())
            {
                insert.Insert(p => p.IsPC == model.IsPC);
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
        public int InsertReturnKey(Carousel_Image model, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var insert = new LambdaInsert<Carousel_Image>();
            if (!model.Image.IsNullOrEmpty())
            {
                insert.Insert(p => p.Image == model.Image);
            }
            if (!model.OrderID.IsNullOrEmpty())
            {
                insert.Insert(p => p.OrderID == model.OrderID);
            }
            if (!model.AUrl.IsNullOrEmpty())
            {
                insert.Insert(p => p.AUrl == model.AUrl);
            }
            if (!model.IsCarousel.IsNullOrEmpty())
            {
                insert.Insert(p => p.IsCarousel == model.IsCarousel);
            }
            if (!model.IsPC.IsNullOrEmpty())
            {
                insert.Insert(p => p.IsPC == model.IsPC);
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
        public List<Carousel_Image> SelectAll(Carousel_Image model = null, string SelectFiled = null, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var query = new LambdaQuery<Carousel_Image>();
            if (model != null)
            {
                if (!model.Id.IsNullOrEmpty())
                {
                    query.Where(p => p.Id == model.Id);
                }
                if (!model.Image.IsNullOrEmpty())
                {
                    query.Where(p => p.Image == model.Image);
                }
                if (!model.OrderID.IsNullOrEmpty())
                {
                    query.Where(p => p.OrderID == model.OrderID);
                }
                if (!model.AUrl.IsNullOrEmpty())
                {
                    query.Where(p => p.AUrl == model.AUrl);
                }
                if (!model.IsCarousel.IsNullOrEmpty())
                {
                    query.Where(p => p.IsCarousel == model.IsCarousel);
                }
                if (!model.IsPC.IsNullOrEmpty())
                {
                    query.Where(p => p.IsPC == model.IsPC);
                }
            }
            if (SelectFiled != null)
            {
                SelectFiled = SelectFiled.ToLowerInvariant();
                if (SelectFiled.Contains("id,"))
                {
                    query.Select(p => new { p.Id });
                }
                if (SelectFiled.Contains("image,"))
                {
                    query.Select(p => new { p.Image });
                }
                if (SelectFiled.Contains("orderid,"))
                {
                    query.Select(p => new { p.OrderID });
                }
                if (SelectFiled.Contains("aurl,"))
                {
                    query.Select(p => new { p.AUrl });
                }
                if (SelectFiled.Contains("iscarousel,"))
                {
                    query.Select(p => new { p.IsCarousel });
                }
                if (SelectFiled.Contains("ispc,"))
                {
                    query.Select(p => new { p.IsPC });
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
        public int SelectCount(Carousel_Image model = null, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var query = new LambdaQuery<Carousel_Image>();
            if (model != null)
            {
                if (!model.Id.IsNullOrEmpty())
                {
                    query.Where(p => p.Id == model.Id);
                }
                if (!model.Image.IsNullOrEmpty())
                {
                    query.Where(p => p.Image == model.Image);
                }
                if (!model.OrderID.IsNullOrEmpty())
                {
                    query.Where(p => p.OrderID == model.OrderID);
                }
                if (!model.AUrl.IsNullOrEmpty())
                {
                    query.Where(p => p.AUrl == model.AUrl);
                }
                if (!model.IsCarousel.IsNullOrEmpty())
                {
                    query.Where(p => p.IsCarousel == model.IsCarousel);
                }
                if (!model.IsPC.IsNullOrEmpty())
                {
                    query.Where(p => p.IsPC == model.IsPC);
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
        public Carousel_Image SelectById(int KeyId, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var query = new LambdaQuery<Carousel_Image>();
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
        public List<Carousel_Image> SelectByKeys(string Key,List<string> KeyIds, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var query = new LambdaQuery<Carousel_Image>();
            if("id" == Key.ToLowerInvariant())
            {
                query.Where(p => p.Id.In(KeyIds));
            }
            if("image" == Key.ToLowerInvariant())
            {
                query.Where(p => p.Image.In(KeyIds));
            }
            if("orderid" == Key.ToLowerInvariant())
            {
                query.Where(p => p.OrderID.In(KeyIds));
            }
            if("aurl" == Key.ToLowerInvariant())
            {
                query.Where(p => p.AUrl.In(KeyIds));
            }
            if("iscarousel" == Key.ToLowerInvariant())
            {
                query.Where(p => p.IsCarousel.In(KeyIds));
            }
            if("ispc" == Key.ToLowerInvariant())
            {
                query.Where(p => p.IsPC.In(KeyIds));
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
        public List<Carousel_Image> SelectByPage(string Key, int start, int PageSize, bool desc = true,Carousel_Image model = null, string SelectFiled = null, IDbConnection connection = null, IDbTransaction transaction = null)
        {
            var query = new LambdaQuery<Carousel_Image>();
            if (model != null)
            {
                if (!model.Id.IsNullOrEmpty())
                {
                    query.Where(p => p.Id == model.Id);
                }
                if (!model.Image.IsNullOrEmpty())
                {
                    query.Where(p => p.Image == model.Image);
                }
                if (!model.OrderID.IsNullOrEmpty())
                {
                    query.Where(p => p.OrderID == model.OrderID);
                }
                if (!model.AUrl.IsNullOrEmpty())
                {
                    query.Where(p => p.AUrl == model.AUrl);
                }
                if (!model.IsCarousel.IsNullOrEmpty())
                {
                    query.Where(p => p.IsCarousel == model.IsCarousel);
                }
                if (!model.IsPC.IsNullOrEmpty())
                {
                    query.Where(p => p.IsPC == model.IsPC);
                }
            }
            if (SelectFiled != null)
            {
                SelectFiled = SelectFiled.ToLowerInvariant();
                if (SelectFiled.Contains("id,"))
                {
                    query.Select(p => new { p.Id });
                }
                if (SelectFiled.Contains("image,"))
                {
                    query.Select(p => new { p.Image });
                }
                if (SelectFiled.Contains("orderid,"))
                {
                    query.Select(p => new { p.OrderID });
                }
                if (SelectFiled.Contains("aurl,"))
                {
                    query.Select(p => new { p.AUrl });
                }
                if (SelectFiled.Contains("iscarousel,"))
                {
                    query.Select(p => new { p.IsCarousel });
                }
                if (SelectFiled.Contains("ispc,"))
                {
                    query.Select(p => new { p.IsPC });
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
