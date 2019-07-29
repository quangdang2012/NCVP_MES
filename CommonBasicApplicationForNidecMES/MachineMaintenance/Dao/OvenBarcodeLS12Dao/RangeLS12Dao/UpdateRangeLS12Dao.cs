using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Vo;
using Com.Nidec.Mes.Framework;
using System.Text;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Dao
{
    public class UpdateRangeLS12Dao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            RangeVo inVo = (RangeVo)vo;
            StringBuilder sql = new StringBuilder();
            sql.Append(@"update m_ovenmachinels12_range set range_lower=:range_lower,range_upper=:range_upper,registration_user_cd=:registration_user_cd,registration_date_time = now()");
            sql.Append(" where ovenmachine_rangels12_id=:ovenmachine_rangels12_id ");
            
            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            sqlParameter.AddParameter("ovenmachine_rangels12_id", inVo.RangeId);
            sqlParameter.AddParameterString("range_model", inVo.Model);
            sqlParameter.AddParameterString("range_process", inVo.Process);
            sqlParameter.AddParameterString("range_lower", inVo.Lower);
            sqlParameter.AddParameterString("range_upper", inVo.Upper);

            sqlParameter.AddParameterString("registration_user_cd", inVo.RegistrationUser);
            //execute SQL

            RangeVo outVo = new RangeVo
            {
                AffectedCount = sqlCommandAdapter.ExecuteNonQuery(sqlParameter)
            };

            return outVo;
        }
    }
}
