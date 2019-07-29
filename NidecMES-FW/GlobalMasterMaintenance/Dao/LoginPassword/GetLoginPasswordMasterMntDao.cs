using System;
using System.Text;
using System.Data;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Dao
{
    public class GetLoginPasswordMasterMntDao : AbstractDataAccessObject
    {

        public override ValueObject Execute(TransactionContext trxContext, ValueObject arg)
        {

            UserVo inVo = (UserVo)arg;

            StringBuilder sqlQuery = new StringBuilder();

            sqlQuery.Append("Select usr.user_cd,");
            sqlQuery.Append("usr.user_name, ");
            sqlQuery.Append("cn.country,");
            sqlQuery.Append("cn.language,");
            sqlQuery.Append(" usr.locale_id,");
            sqlQuery.Append("usr.multi_login_flag,");
            sqlQuery.Append("usr.registration_user_cd,");
            sqlQuery.Append("usr.registration_date_time,");
            sqlQuery.Append("lp.password,");
            sqlQuery.Append("usr.registrated_factory_cd ");
            sqlQuery.Append(" from m_mes_user usr");
            sqlQuery.Append(" inner join m_country_language cn on usr.locale_id = cn.locale_id");
            sqlQuery.Append(" left join  m_login_password lp on lp.user_cd = usr.user_cd ");
            sqlQuery.Append(" where 1 = 1 ");

            if (inVo.UserCode != null) { sqlQuery.Append(" and usr.user_cd like :usercode ");}

            if (inVo.UserName != null) { sqlQuery.Append(" and usr.user_name like :username ");}

            //if (inVo.Country != null) { sqlQuery.Append(" and usr.country = :country ");}

            //if (inVo.Language != null) { sqlQuery.Append(" and usr.language = :language ");}

            if (inVo.LocaleId > 0) { sqlQuery.Append(" and usr.locale_id = :locid "); }

            if (inVo.RegistrationFactoryCode != null) { sqlQuery.Append(" and usr.registrated_factory_cd = :registrationfactorycode ");}

            sqlQuery.Append(" order by usr.user_cd");

            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sqlQuery.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();          

            if (inVo.UserCode != null)
            {
                sqlParameter.AddParameterString("usercode", inVo.UserCode + "%");
            }

            if (inVo.UserName != null)
            {
                sqlParameter.AddParameterString("username", inVo.UserName + "%");
            }

            //if (inVo.Country != null)
            //{
            //    sqlParameter.AddParameterString("country", inVo.Country);
            //}

            //if (inVo.Language != null)
            //{
            //    sqlParameter.AddParameterString("language", inVo.Language);
            //}

            if (inVo.LocaleId > 0)
            {
                sqlParameter.AddParameterInteger("locid", inVo.LocaleId);
            }

            if (inVo.RegistrationFactoryCode != null)
            {
                sqlParameter.AddParameterString("registrationfactorycode", inVo.RegistrationFactoryCode);
            }

            //execute SQL
            IDataReader dataReader = sqlCommandAdapter.ExecuteReader(trxContext, sqlParameter);

            UserVo outVo = new UserVo();

            while (dataReader.Read())
            {
                UserVo currOutVo = new UserVo();

                currOutVo.UserCode = DBDataCheckHelper.ConvertDBNullToStringNull(dataReader["user_cd"]);
                currOutVo.UserName = DBDataCheckHelper.ConvertDBNullToStringNull(dataReader["user_name"]);
                currOutVo.PassWord = DBDataCheckHelper.ConvertDBNullToStringNull(dataReader["password"]);
                currOutVo.Country = DBDataCheckHelper.ConvertDBNullToStringNull(dataReader["country"]);
                currOutVo.Language = DBDataCheckHelper.ConvertDBNullToStringNull(dataReader["language"]);
                currOutVo.MultiLoginFlag = DBDataCheckHelper.ConvertDBNullToStringNull(dataReader["multi_login_flag"]);
                currOutVo.RegistrationFactoryCode = DBDataCheckHelper.ConvertDBNullToStringNull(dataReader["registrated_factory_cd"]);
                currOutVo.LocaleId = Convert.ToInt32(dataReader["locale_id"]);

                outVo.UserListVo.Add(currOutVo);
            }
            dataReader.Close();

            return outVo; 
        }
    }
}
