using System.Text;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;
namespace Com.Nidec.Mes.GlobalMasterMaintenance.Dao
{
    public class AddAuthorityControlMasterMntDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject arg)
        {
            AuthorityControlVo inVo = (AuthorityControlVo)arg;

            StringBuilder sqlQuery = new StringBuilder();

            sqlQuery.Append("Insert into m_authority_control");
            sqlQuery.Append(" ( ");
            sqlQuery.Append(" authority_control_cd, ");
            sqlQuery.Append(" authority_control_name, ");

            if (inVo.ParentControlCode != null)
            {
                sqlQuery.Append(" parent_control_cd, ");
            }
            sqlQuery.Append(" registration_user_cd, ");
            sqlQuery.Append(" registration_date_time ");
            sqlQuery.Append(" ) ");
            sqlQuery.Append("VALUES	");
            sqlQuery.Append(" ( ");
            sqlQuery.Append(" :authcontcd ,");
            sqlQuery.Append(" :authcontname ,");

            if (inVo.ParentControlCode != null)
            {
                sqlQuery.Append(" :parentcontcd ,");
            }
            sqlQuery.Append(" :registrationusercode ,");
            sqlQuery.Append(" now() ");
            sqlQuery.Append(" ); ");

            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sqlQuery.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            sqlParameter.AddParameterString("authcontcd", inVo.AuthorityControlCode);
            sqlParameter.AddParameterString("authcontname", inVo.AuthorityControlName);

            if (inVo.ParentControlCode != null)
            {
                sqlParameter.AddParameterString("parentcontcd", inVo.ParentControlCode);
            }

            sqlParameter.AddParameterString("registrationusercode", inVo.RegistrationUserCode);
            //sqlParameter.AddParameterDateTime("registrationdatetime", inVo.RegistrationDateTime);

            AuthorityControlVo outVo = new AuthorityControlVo
            {
                AffectedCount = sqlCommandAdapter.ExecuteNonQuery(sqlParameter)
            };

            return outVo;
        }
    }
}
