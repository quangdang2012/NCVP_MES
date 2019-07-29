using System.Text;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Dao
{
    public class AddCountryLanguageMasterMntDao : AbstractDataAccessObject
    {

        public override ValueObject Execute(TransactionContext trxContext, ValueObject arg)
        {

            CountryLanguageVo inVo = (CountryLanguageVo)arg;

            StringBuilder sqlQuery = new StringBuilder();

            sqlQuery.Append("Insert into m_country_language");
            sqlQuery.Append(" ( ");
            sqlQuery.Append(" country, ");
            sqlQuery.Append(" language, ");
            sqlQuery.Append(" registration_user_cd, ");
            sqlQuery.Append(" registration_date_time ");
            sqlQuery.Append(" ) ");
            sqlQuery.Append("VALUES	");
            sqlQuery.Append(" ( ");
            sqlQuery.Append(" :country ,");
            sqlQuery.Append(" :language ,");
            sqlQuery.Append(" :registrationusercode ,");
            sqlQuery.Append(" now() ");
            sqlQuery.Append(" ); ");

            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sqlQuery.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();

            sqlParameter.AddParameterString("country", inVo.Country);
            sqlParameter.AddParameterString("language ", inVo.Language);
            sqlParameter.AddParameterString("registrationusercode ", inVo.RegistrationUserCode);
            //sqlParameter.AddParameterDateTime("registrationdatetime ", inVo.RegistrationDateTime);

            CountryLanguageVo outVo = new CountryLanguageVo
            {
                AffectedCount = sqlCommandAdapter.ExecuteNonQuery(sqlParameter)
            };
            return outVo;
        }

 

    }
}
