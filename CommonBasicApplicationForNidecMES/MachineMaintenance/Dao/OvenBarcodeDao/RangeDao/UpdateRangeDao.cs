using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Vo;
using Com.Nidec.Mes.Framework;
using System.Text;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Dao
{
    public class UpdateRangeDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            RangeVo inVo = (RangeVo)vo;
            StringBuilder sql = new StringBuilder();
            sql.Append(@"update m_ovenmachine_range set range_lower=:range_lower,range_upper=:range_upper,registration_user_cd=:registration_user_cd,registration_date_time = now()");
            sql.Append(" where range_model=:range_model and range_line=:range_line and range_barcode=:range_barcode ");
            
            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            sqlParameter.AddParameter("ovenmachine_range_id", inVo.RangeId);
            sqlParameter.AddParameterString("range_model", inVo.Model);
            sqlParameter.AddParameterString("range_line", inVo.Line);
            sqlParameter.AddParameterString("range_barcode", inVo.Barcode);
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
