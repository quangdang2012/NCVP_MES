using System;
using System.Text;
using System.Data;

namespace Com.Nidec.Mes.Framework.Login
{
    class LoginDao : AbstractDataAccessObject
    {
            
        /// <summary>
        /// Execute the query
        /// </summary>
        /// <param name="trxContext"></param>
        /// <param name="vo"></param>
        /// <returns></returns>
        public override ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {

            LoginInVo inVo = (LoginInVo)vo;

            StringBuilder sqlQuery = new StringBuilder();

            sqlQuery.Append(" select distinct usr.user_cd,usr.user_name,cn.country,cn.language,cn.locale_id, ");
            sqlQuery.Append(" fac.factory_cd,usrfac.display_order,actrl.authority_control_cd");
            sqlQuery.Append(" from m_mes_user usr ");
            sqlQuery.Append(" inner join m_country_language cn on usr.locale_id = cn.locale_id");
            sqlQuery.Append(" inner join m_user_factory usrfac on usr.user_cd = usrfac.user_cd ");
            sqlQuery.Append(" inner join m_factory fac on usrfac.factory_cd = fac.factory_cd ");
            sqlQuery.Append(" left join m_mes_user_role usrrol on usrrol.user_cd = usr.user_cd ");
            sqlQuery.Append(" left join m_mes_role rol on rol.role_cd = usrrol.role_cd ");
            sqlQuery.Append(" left join m_role_authority_control rolactrl on rolactrl.role_cd = rol.role_cd ");
            sqlQuery.Append(" left join m_authority_control actrl on actrl.authority_control_cd = rolactrl.authority_control_cd ");
            sqlQuery.Append(" where usr.user_cd = :usercode ");
            sqlQuery.Append(" order by usrfac.display_order; ");

            LoginOutVo outVo = new LoginOutVo();

            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sqlQuery.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            sqlParameter.AddParameter("usercode", inVo.InputUserId);

            //execute SQL
            IDataReader dataReader = sqlCommandAdapter.ExecuteReader(trxContext,sqlParameter);

            int recordCount = 0;

            String FactoryCode;
            String AuthorityCode;
            while (dataReader.Read())
            {
                if (recordCount == 0)
                {
                    outVo.UserId = ConvertDBNull<string>(dataReader, "user_cd");
                    outVo.UserName = ConvertDBNull<string>(dataReader,"user_name");
                    outVo.LocaleId = ConvertDBNull<int>(dataReader, "locale_id");
                    outVo.CountryCode = ConvertDBNull<string>(dataReader,"country");
                    outVo.LanguageCode = ConvertDBNull<string>(dataReader,"language");
                }

                FactoryCode = ConvertDBNull<string>(dataReader, "factory_cd");
                if (!outVo.FactoryCodeList.Contains(FactoryCode))
                {
                    outVo.FactoryCodeList.Add(FactoryCode);
                }

                AuthorityCode = ConvertDBNull<string>(dataReader, "authority_control_cd");
                if (!outVo.ControlList.Contains(AuthorityCode))
                {
                    outVo.ControlList.Add(AuthorityCode);
                }
                recordCount += 1;
            }
            if (recordCount == 0)
            {
                outVo = null;
            }

            dataReader.Close();
            return outVo;
        }
    }
}
