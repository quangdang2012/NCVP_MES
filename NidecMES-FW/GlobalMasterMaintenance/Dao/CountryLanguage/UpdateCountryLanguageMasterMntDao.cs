using System.Text;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Dao
{
    public class UpdateCountryLanguageMasterMntDao : AbstractDataAccessObject
    {

        public override ValueObject Execute(TransactionContext trxContext, ValueObject arg)
        {

            CountryLanguageVo inVo = (CountryLanguageVo)arg;

            StringBuilder sqlQuery = new StringBuilder();

            sqlQuery.Append("Update m_country_language");
            sqlQuery.Append(" Set ");
            sqlQuery.Append(" country = :country ,");
            sqlQuery.Append(" language = :language ");
            sqlQuery.Append(" Where	");
            sqlQuery.Append(" country = :country ");
            sqlQuery.Append(" and ");
            sqlQuery.Append(" language = :language ;");


            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sqlQuery.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();

            sqlParameter.AddParameterString("country", inVo.Country);
            sqlParameter.AddParameterString("language ", inVo.Language);

            CountryLanguageVo outVo = new CountryLanguageVo
            {
                AffectedCount = sqlCommandAdapter.ExecuteNonQuery(sqlParameter)
            };

            return outVo;
        }
    }
}
