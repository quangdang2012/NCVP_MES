using System.Text;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Dao
{
    public class AddRoleMasterMntDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject arg)
        {
            RoleVo inVo = (RoleVo)arg;

            StringBuilder sqlQuery = new StringBuilder();

            sqlQuery.Append("Insert into m_mes_role");
            sqlQuery.Append(" ( ");
            sqlQuery.Append(" role_cd, ");
            sqlQuery.Append(" role_name, ");
            sqlQuery.Append(" registration_user_cd, ");
            sqlQuery.Append(" registration_date_time, ");
            sqlQuery.Append(" factory_cd ");
            sqlQuery.Append(" ) ");
            sqlQuery.Append("VALUES	");
            sqlQuery.Append(" ( ");
            sqlQuery.Append(" :rolecd ,");
            sqlQuery.Append(" :rolename ,");
            sqlQuery.Append(" :registrationusercode ,");
            sqlQuery.Append(" now() ,");
            sqlQuery.Append(" :factorycode ");
            sqlQuery.Append(" ); ");

            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sqlQuery.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            sqlParameter.AddParameterString("rolecd", inVo.RoleCode);
            sqlParameter.AddParameterString("rolename", inVo.RoleName);
            sqlParameter.AddParameterString("registrationusercode", inVo.RegistrationUserCode);
            //sqlParameter.AddParameterDateTime("registrationdatetime", inVo.RegistrationDateTime);
            sqlParameter.AddParameterString("factorycode", inVo.FactoryCode);

            RoleVo outVo = new RoleVo {AffectedCount = sqlCommandAdapter.ExecuteNonQuery(sqlParameter)};

            return outVo;
        }
    }
}
