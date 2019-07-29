using System.Text;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Dao
{
    public class AddUserMasterMntDao : AbstractDataAccessObject
    {

        public override ValueObject Execute(TransactionContext trxContext, ValueObject arg)
        {

            UserVo inVo = (UserVo)arg;

            StringBuilder sqlQuery = new StringBuilder();

            sqlQuery.Append("Insert into m_mes_user");
            sqlQuery.Append(" ( ");
            sqlQuery.Append(" user_cd, ");
            sqlQuery.Append(" user_name, ");
            //sqlQuery.Append(" country, ");
            sqlQuery.Append(" locale_id, ");
            sqlQuery.Append(" multi_login_flag, ");
            sqlQuery.Append(" registration_user_cd, ");
            sqlQuery.Append(" registration_date_time, ");
            sqlQuery.Append(" registrated_factory_cd");
            sqlQuery.Append(" ) ");
            sqlQuery.Append("VALUES	");
            sqlQuery.Append(" ( ");
            sqlQuery.Append(" :usercode ,");
            sqlQuery.Append(" :username ,");
            //sqlQuery.Append(" :country ,");
            sqlQuery.Append(" :localeid ,");
            sqlQuery.Append(" :multiloginflag  ,");
            sqlQuery.Append(" :registrationusercode ,");
            sqlQuery.Append(" now() ,");
            sqlQuery.Append(" :registrationfactorycode ");
            sqlQuery.Append(" ); ");

            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sqlQuery.ToString());

            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            sqlParameter.AddParameterString("usercode", inVo.UserCode);
            sqlParameter.AddParameterString("username", inVo.UserName);
           // sqlParameter.AddParameterString("country", inVo.Country);
            sqlParameter.AddParameterInteger("localeid ", inVo.LocaleId);
            sqlParameter.AddParameterString("multiloginflag ", inVo.MultiLoginFlag);
            sqlParameter.AddParameterString("registrationusercode ", inVo.RegistrationUserCode);
            //sqlParameter.AddParameterDateTime("registrationdatetime ", inVo.RegistrationDateTime, true);
            sqlParameter.AddParameterString("registrationfactorycode ", inVo.RegistrationFactoryCode);

            UserVo outVo = new UserVo { AffectedCount = sqlCommandAdapter.ExecuteNonQuery(sqlParameter) };

            return outVo; 
        }
    }
}
