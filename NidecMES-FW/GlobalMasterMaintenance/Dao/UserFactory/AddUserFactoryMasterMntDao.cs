using System.Text;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Dao
{
    public class AddUserFactoryMasterMntDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject arg)
        {
            UserFactoryVo inVo = (UserFactoryVo)arg;

            StringBuilder sqlQuery = new StringBuilder();

            sqlQuery.Append("Insert into m_user_factory");
            sqlQuery.Append(" ( ");
            sqlQuery.Append(" user_cd, ");
            sqlQuery.Append(" factory_cd, ");
            sqlQuery.Append(" display_order, ");
            sqlQuery.Append(" registration_user_cd, ");
            sqlQuery.Append(" registration_date_time");
            sqlQuery.Append(" ) ");
            sqlQuery.Append("VALUES ");
            sqlQuery.Append(" ( ");
            sqlQuery.Append(" :usercd ,");
            sqlQuery.Append(" :factorycd ,");
            sqlQuery.Append(" :displayorder,");
            sqlQuery.Append(" :registrationusercode ,");
            sqlQuery.Append(" now()");
            sqlQuery.Append(" ); ");

            int cnt = 0;
            UserFactoryVo outVo = new UserFactoryVo();

            foreach (UserFactoryVo userRecord in inVo.UserFactoryListVo)
            {                 
                //create command
                DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sqlQuery.ToString());

                //create parameter
                DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
                sqlParameter.AddParameterString("usercd", inVo.UserCode);
                sqlParameter.AddParameterString("factorycd", userRecord.FactoryCd);
                sqlParameter.AddParameterInteger("displayorder", userRecord.DisplayOrder);
                sqlParameter.AddParameterString("registrationusercode", inVo.RegistrationUserCode);

                outVo.AffectedCount = sqlCommandAdapter.ExecuteNonQuery(sqlParameter);
            }

            outVo.AffectedCount = cnt;

            return outVo;
        }
    }
}
