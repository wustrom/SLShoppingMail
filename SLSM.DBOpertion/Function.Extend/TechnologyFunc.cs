using Common;
using DbOpertion.Models;
using DbOpertion.Operation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbOpertion.Function
{
    public partial class TechnologyFunc : SingleTon<TechnologyFunc>
    {
        /// <summary>
        /// 分页筛选未删除定制工艺
        /// </summary>
        /// <returns></returns>
        public List<Technology> SelectTechnology()
        {
            return TechnologyOper.Instance.SelectAll(new Technology { IsDelete = true });
        }
        /// <summary>
        /// 筛选未删除定制工艺数目
        /// </summary>
        /// <returns></returns>
        public int SelectTechnologyCount()
        {
            return TechnologyOper.Instance.SelectCount(new Technology { IsDelete = true });
        }
        /// <summary>
        /// 插入数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public string InsertTechnology(Technology model)
        {
            if (TechnologyOper.Instance.SelectAll(new Technology { Name = model.Name }).Count != 0)
            {
                return "名称已存在!";
            }
            if (TechnologyOper.Instance.Insert(model))
            {
                return "成功!";
            }
            else
            {
                return "插入失败!";
            }
        }
        /// <summary>
        /// 根据Id修改
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public string UpdateTechnology(Technology model)
        {
            if (TechnologyOper.Instance.SelectAll(new Technology { Name = model.Name }).Count != 0)
            {
                return "名称已存在!";
            }
            if (TechnologyOper.Instance.Update(model))
            {
                return "成功!";
            }
            else
            {
                return "修改失败!";
            }
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="Ids">工艺多个Id</param>
        /// <returns></returns>
        public bool DelListTechnology(string Ids)
        {
            if (Ids != null)
            {
                var arrId = Ids.Split(',');
                foreach (var item in arrId)
                {
                    int arrIds = 0;
                    if (item=="on")
                    {
                        arrIds = 0;
                    }
                    else
                    {
                        arrIds = int.Parse(item);
                    }                 
                    TechnologyOper.Instance.Update(new Technology { Id = arrIds, IsDelete = false });
                }
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
