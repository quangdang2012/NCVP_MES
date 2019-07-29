using System;
using System.Text;
using System.Data;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Dao
{
    public class GetSapUsersMasterMntDao : AbstractDataAccessObject
    {

        public override ValueObject Execute(TransactionContext trxContext, ValueObject arg)
        {
            SapUserVo inVo = (SapUserVo)arg;
            StringBuilder sqlQuery = new StringBuilder();

            sqlQuery.Append("Select sapusr.sap_user_id,sapusr.mes_user_cd,usr.user_name,sapusr.sap_user,sapusr.sap_password");
            sqlQuery.Append(" from m_sap_user sapusr");
            sqlQuery.Append(" inner join m_mes_user usr on usr.user_cd = sapusr.mes_user_cd ");            
            sqlQuery.Append(" where 1 = 1 ");

            if(inVo.MesUserCode != null)
            {
                sqlQuery.Append(" and usr.user_cd = :usercode ");
            }
            
            if(inVo.SapUser != null)
            {
                sqlQuery.Append(" and sapusr.sap_user = :sapuser ");
            }
            sqlQuery.Append(" order by sap_user_id ");

            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sqlQuery.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();

            if (inVo.MesUserCode != null)
            {
                sqlParameter.AddParameterString("usercode", inVo.MesUserCode);
            }
            if (inVo.SapUser != null)
            {
                sqlParameter.AddParameterString("sapuser", inVo.SapUser);
            }


            //execute SQL
            IDataReader dataReader = sqlCommandAdapter.ExecuteReader(trxContext, sqlParameter);

            SapUserVo outVo = new SapUserVo();
            while (dataReader.Read())
            {
                SapUserVo currVo = new SapUserVo();

                currVo.SapUserId = Convert.ToInt32(dataReader["sap_user_id"]);
                currVo.MesUserCode = DBDataCheckHelper.ConvertDBNullToStringNull(dataReader["mes_user_cd"]);
                currVo.UserName= DBDataCheckHelper.ConvertDBNullToStringNull(dataReader["user_name"]);
                currVo.SapUser = DBDataCheckHelper.ConvertDBNullToStringNull(dataReader["sap_user"]);
                currVo.SapPassWord = DBDataCheckHelper.ConvertDBNullToStringNull(dataReader["sap_password"]);

                outVo.SapUserListVo.Add(currVo);
            }
            dataReader.Close();

            return outVo;
        }
    }
}
