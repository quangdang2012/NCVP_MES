using System;
using System.Text;
using System.Data;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Dao
{
    public class GetCountryLanguageMasterMntDao : AbstractDataAccessObject
    {

        public override ValueObject Execute(TransactionContext trxContext, ValueObject arg)
        {

            CountryLanguageVo inVo = (CountryLanguageVo)arg;

            CountryLanguageVo outVo = new CountryLanguageVo();

            StringBuilder sqlQuery = new StringBuilder();

            //create SQL
            sqlQuery.Append("Select * from m_country_language ");

            sqlQuery.Append(" where 1=1 ");

            if (inVo.Country != null)
            {
                sqlQuery.Append(" and country = :country ");
            }

            if (inVo.Language != null)
            {
                sqlQuery.Append(" and language = :language ");
            }

            sqlQuery.Append(" order by country");

            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sqlQuery.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            if (inVo.Country != null)
            {
                sqlParameter.AddParameterString("country", inVo.Country);
            }
            if (inVo.Language != null)
            {
                sqlParameter.AddParameterString("language", inVo.Language);
            }
            //execute SQL
            IDataReader dataReader = sqlCommandAdapter.ExecuteReader(trxContext, sqlParameter);

                while (dataReader.Read())
                {
                    CountryLanguageVo currOutVo = new CountryLanguageVo
                    {
                        Country = dataReader["country"].ToString(),
                        Language = dataReader["language"].ToString(),
                        LocaleId = Convert.ToInt32(dataReader["locale_id"])
                    };
                    outVo.CountryLangListVo.Add(currOutVo);
                }

            dataReader.Close();

            return outVo;
        }

 
    }
}
