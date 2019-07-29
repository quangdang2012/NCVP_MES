using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Vo;
using Com.Nidec.Mes.Framework;
using System.Text;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Dao
{
    public class AddRangeLS12Dao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            RangeVo inVo = (RangeVo)vo;
            StringBuilder sql = new StringBuilder();
            sql.Append("insert into m_ovenmachinels12_range(range_model,range_process,range_lower,range_upper, registration_user_cd, registration_date_time) ");
            sql.Append("values(:range_model,:range_process,:range_lower,:range_upper, :registration_user_cd, now())");
            
            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
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
