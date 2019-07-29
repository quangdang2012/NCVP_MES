using System.Text;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Dao
{
    public class AddLoginPasswordMasterMntDao : AbstractDataAccessObject
    {

        public override ValueObject Execute(TransactionContext trxContext, ValueObject arg)
        {

            UserVo inVo = (UserVo)arg;

            StringBuilder sqlQuery = new StringBuilder();

            sqlQuery.Append("Insert into m_login_password");
            sqlQuery.Append(" ( ");
            sqlQuery.Append(" user_cd, ");
            sqlQuery.Append(" password, ");
            sqlQuery.Append(" registration_user_cd, ");
            sqlQuery.Append(" registration_date_time, ");
            sqlQuery.Append(" factory_cd");
            sqlQuery.Append(" ) ");
            sqlQuery.Append("VALUES	");
            sqlQuery.Append(" ( ");
            sqlQuery.Append(" :usercode ,");
            sqlQuery.Append(" :password ,");
            sqlQuery.Append(" :registrationusercode ,");
            sqlQuery.Append(" now() ,");
            sqlQuery.Append(" :registrationfactorycode ");
            sqlQuery.Append(" ); ");

            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sqlQuery.ToString());

            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            sqlParameter.AddParameterString("usercode", inVo.UserCode);
            sqlParameter.AddParameterString("password", inVo.PassWord);
            sqlParameter.AddParameterString("registrationusercode ", inVo.RegistrationUserCode);
            //sqlParameter.AddParameterDateTime("registrationdatetime ", inVo.RegistrationDateTime, true);
            sqlParameter.AddParameterString("registrationfactorycode ", inVo.RegistrationFactoryCode);

            UserVo outVo = new UserVo { AffectedCount = sqlCommandAdapter.ExecuteNonQuery(sqlParameter) };

            return outVo; 
        }
    }
}
