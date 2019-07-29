using System.Text;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Dao
{
    public class AddUserRoleMasterMntDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject arg)
        {
            UserRoleVo inVo = (UserRoleVo)arg;

            StringBuilder sqlQuery = new StringBuilder();

            sqlQuery.Append("Insert into m_mes_user_role");
            sqlQuery.Append(" ( ");
            sqlQuery.Append(" user_cd, ");
            sqlQuery.Append(" role_cd, ");
            sqlQuery.Append(" registration_user_cd, ");
            sqlQuery.Append(" registration_date_time, ");
            sqlQuery.Append(" factory_cd ");
            sqlQuery.Append(" ) ");
            sqlQuery.Append("VALUES	");
            sqlQuery.Append(" ( ");
            sqlQuery.Append(" :usercd ,");
            sqlQuery.Append(" :rolecd ,");
            sqlQuery.Append(" :registrationusercode ,");
            sqlQuery.Append(" now() ,");
            sqlQuery.Append(" :factorycode ");
            sqlQuery.Append(" ); ");

            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sqlQuery.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            sqlParameter.AddParameterString("rolecd", inVo.RoleCode);
            sqlParameter.AddParameterString("usercd", inVo.UserCode);
            sqlParameter.AddParameterString("registrationusercode", inVo.RegistrationUserCode);
            //sqlParameter.AddParameterDateTime("registrationdatetime", inVo.RegistrationDateTime);
            sqlParameter.AddParameterString("factorycode", inVo.FactoryCode);

            UserRoleVo outVo = new UserRoleVo {AffectedCount = sqlCommandAdapter.ExecuteNonQuery(sqlParameter)};

            return outVo;
        }
    }
}
