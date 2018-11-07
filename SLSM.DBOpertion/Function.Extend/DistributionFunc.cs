using Common;
using Common.Extend;
using Common.Helper;
using DbOpertion.Models;
using DbOpertion.Operation;
using SLSM.ErpWeb.Model.Request.Designer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbOpertion.Function
{
    public partial class DistributionFunc : SingleTon<DistributionFunc>
    {
        //public bool AddDistribution(int ProductionId,string ProductionPerson, List<ProcedureInfo> ProcedureInfoList)
        //{
        //    var SumTime = 0;
        //    var proceduress = ProcedureInfoList.Select(p => p.procedure).Where(p => !string.IsNullOrEmpty(p)).ToList();
        //    var productionTimes = ProcedureInfoList.Select(p => p.productionTime).Where(p => !string.IsNullOrEmpty(p)).ToList();
        //    var productionMans = ProcedureInfoList.Select(p => p.productionMan).Where(p => !string.IsNullOrEmpty(p)).ToList();
        //    DistributionOper.Instance.DeleteModel(new Distribution { ProductionId = ProductionId });
        //    if (proceduress.Count() == productionTimes.Count() && proceduress.Count() == productionMans.Count())
        //    {
        //        for (var i = 0; i < proceduress.Count(); i++)
        //        {
        //            var Distributions = DistributionOper.Instance.InsertReturnKey(new Distribution { ProductionId = ProductionId, procedures = proceduress[i], productionTime = productionTimes[i].ParseInt(), productionMan = productionMans[i] });
        //            if (Distributions <= 0)
        //            {
        //                return false;
        //            }
                   
        //            SumTime += productionTimes[i].ParseInt().Value;
                   
        //        }
        //        //添加交货时间
        //       ProductionFunc.Instance.Update(new Production { Id = ProductionId, deliveryTime = DateTime.Now.AddDays(SumTime) });
        //    }
        //    return true;
        //}

        #region 
        public bool AddDistribution(int ProductionId, string ProductionPerson, List<ProcedureInfo> ProcedureInfoList)
        {

            var MysqlHelper = SqlHelper.GetMySqlHelper("transaction");
            var connection = MysqlHelper.CreatConn();
            var transaction = MysqlHelper.GetTransaction();
            try
            {
                #region 
                if (UpdatePrint(ProductionId,ProductionPerson, ProcedureInfoList, connection, transaction))
                {
                    transaction.Commit();
                    connection.Close();
                    return true;
                }
                else
                {
                    transaction.Rollback();
                    connection.Close();
                }
                #endregion
            }
            catch (Exception e)
            {
                transaction.Rollback();
                connection.Close();
            }
            return false;
        }

        public bool UpdatePrint(int ProductionId, string ProductionPerson, List<ProcedureInfo> ProcedureInfoList, IDbConnection connection, IDbTransaction transaction)
        {
            if(ProductionId!=0)
            {
                var SumTime = 0;
                var proceduress = ProcedureInfoList.Select(p => p.procedure).Where(p => !string.IsNullOrEmpty(p)).ToList();
                var productionTimes = ProcedureInfoList.Select(p => p.productionTime).Where(p => !string.IsNullOrEmpty(p)).ToList();
                var productionMans = ProcedureInfoList.Select(p => p.productionMan).Where(p => !string.IsNullOrEmpty(p)).ToList();
                DistributionOper.Instance.DeleteModel(new Distribution { ProductionId = ProductionId });
                if (proceduress.Count() == productionTimes.Count() && proceduress.Count() == productionMans.Count())
                {
                    for (var i = 0; i < proceduress.Count(); i++)
                    {
                        var Distributions = DistributionOper.Instance.InsertReturnKey(new Distribution { ProductionId = ProductionId, procedures = proceduress[i], productionTime = productionTimes[i].ParseInt(), productionMan = productionMans[i] });
                        if (Distributions <= 0)
                        {
                            return false;
                        }

                        SumTime += productionTimes[i].ParseInt().Value;

                    }
                    //添加交货时间
                    ProductionFunc.Instance.Update(new Production { Id = ProductionId, deliveryTime = DateTime.Now.AddDays(SumTime) });
                }
                if (!ProductionFunc.Instance.Update(new Production { Id = ProductionId, ProductionPerson = ProductionPerson, ProductionTime=DateTime.Now }))
                {
                    return false;
                }
                return true;
            }else
            {
                return false;
            }
           
        }

        #endregion 
    }
}
