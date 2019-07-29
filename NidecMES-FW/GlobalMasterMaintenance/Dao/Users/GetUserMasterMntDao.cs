using System;
using System.Text;
using System.Data;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Dao
{
    public class GetUserMasterMntDao : AbstractDataAccessObject
    {

        public override ValueObject Execute(TransactionContext trxContext, ValueObject arg)
        {

            UserVo inVo = (UserVo)arg;

            StringBuilder sqlQuery = new StringBuilder();

            sqlQuery.Append("Select usr.user_cd,usr.user_name,usr.multi_login_flag,");
            sqlQuery.Append(" usr.locale_id, usr.registrated_factory_cd,cn.country,cn.language");
            sqlQuery.Append(" from m_mes_user usr");
            sqlQuery.Append(" inner join m_country_language cn on usr.locale_id = cn.locale_id");

            sqlQuery.Append(" where 1 = 1 ");

            if (inVo.UserCode != null) { sqlQuery.Append(" and user_cd like :usercode ");}

            if (inVo.UserName != null) { sqlQuery.Append(" and user_name like :username ");}

            //if (inVo.Country != null) { sqlQuery.Append(" and country = :country ");}

            if (inVo.LocaleId > 0) { sqlQuery.Append(" and usr.locale_id = :locid ");  }

            //if (inVo.Language != null) { sqlQuery.Append(" and language = :language ");}

            if (inVo.RegistrationFactoryCode != null) { sqlQuery.Append(" and registrated_factory_cd = :registrationfactorycode ");}

            sqlQuery.Append(" order by user_cd");

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

            if (inVo.LocaleId > 0)
            {
                sqlParameter.AddParameterInteger("locid", inVo.LocaleId);
            }

            //if (inVo.Language != null)
            //{
            //    sqlParameter.AddParameterString("language", inVo.Language);
            //}

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
