using System.Text;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Vo.AccountWhVo;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Dao
{
    class UpdateWareHouseMainDGVDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            WareHouseMainVo inVo = (WareHouseMainVo)vo;
            StringBuilder sql = new StringBuilder();
            sql.Append(@"update t_warehouse_main set current_depreciation =:current_depreciation,
                                           monthly_depreciation=:monthly_depreciation,  
                                           accum_depreciation_now =:accum_depreciation_now,
                                           net_value =:net_value ");

            sql.Append(" where warehouse_main_id =:warehouse_main_id");

            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            sqlParameter.AddParameter("warehouse_main_id", inVo.WareHouseMainId);
            sqlParameter.AddParameter("current_depreciation", inVo.CurrentDepreciation);
            sqlParameter.AddParameter("monthly_depreciation", inVo.MonthlyDepreciation);
            sqlParameter.AddParameter("accum_depreciation_now", inVo.AccumDepreciation);
            sqlParameter.AddParameter("net_value", inVo.NetValue);
          
            //execute SQL

            WareHouseMainVo outVo = new WareHouseMainVo
            {
                AffectedCount = sqlCommandAdapter.ExecuteNonQuery(sqlParameter)
            };

            return outVo;
        }

    }
}