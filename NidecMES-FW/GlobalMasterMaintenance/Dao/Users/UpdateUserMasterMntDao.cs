using System.Text;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Dao
{
    public class UpdateUserMasterMntDao : AbstractDataAccessObject
    {

        public override ValueObject Execute(TransactionContext trxContext, ValueObject arg)
        {

            UserVo inVo = (UserVo)arg;

            StringBuilder sqlQuery = new StringBuilder();

            sqlQuery.Append("Update m_mes_user");
            sqlQuery.Append(" Set ");
            sqlQuery.Append(" user_name = :username, ");
            //sqlQuery.Append(" country = :country, ");
            //sqlQuery.Append(" language = :language, ");
            sqlQuery.Append(" locale_id = :locid, ");
            sqlQuery.Append(" multi_login_flag = :multiloginflag, ");
            sqlQuery.Append(" registrated_factory_cd = :registrationfactorycode ");
            sqlQuery.Append(" Where	");
            sqlQuery.Append(" user_cd = :usercode ");           

            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sqlQuery.ToString());

            //create parameter
            DbParameterList sqlParameter= sqlCommandAdapter.CreateParameterList();
            sqlParameter.AddParameterString("usercode", inVo.UserCode);
            sqlParameter.AddParameterString("username", inVo.UserName);
            //sqlParameter.AddParameterString("country", inVo.Country);
            //sqlParameter.AddParameterString("language ", inVo.Language);
            sqlParameter.AddParameterString("multiloginflag ", inVo.MultiLoginFlag);
            sqlParameter.AddParameterString("registrationfactorycode ", inVo.RegistrationFactoryCode);
            sqlParameter.AddParameterInteger("locid ", inVo.LocaleId);

            UserVo outVo = new UserVo {AffectedCount = sqlCommandAdapter.ExecuteNonQuery(sqlParameter)};

            // outVo.TableName = "m_mes_user";

            //outVo.LogContents = sqlQuery.ToString();

            return outVo; 
        }
    }
}
