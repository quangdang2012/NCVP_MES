using System.Text;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Vo.AccountWhVo;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Dao
{
    class UpdateAccountMainDGVDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            AccountMainVo inVo = (AccountMainVo)vo;
            StringBuilder sql = new StringBuilder();
            sql.Append(@"update t_account_main set current_depreciation =:current_depreciation,
                                           monthly_depreciation=:monthly_depreciation,  
                                           accum_depreciation_now =:accum_depreciation_now,
                                           net_value =:net_value ");

            sql.Append(" where account_main_id =:account_main_id");

            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            sqlParameter.AddParameter("account_main_id", inVo.AcountMainId);
            sqlParameter.AddParameter("current_depreciation", inVo.CurrentDepreciation);
            sqlParameter.AddParameter("monthly_depreciation", inVo.MonthlyDepreciation);
            sqlParameter.AddParameter("accum_depreciation_now", inVo.AccumDepreciation);
            sqlParameter.AddParameter("net_value", inVo.NetValue);
          
            //execute SQL

            AccountMainVo outVo = new AccountMainVo
            {
                AffectedCount = sqlCommandAdapter.ExecuteNonQuery(sqlParameter)
            };

            return outVo;
        }

    }
}