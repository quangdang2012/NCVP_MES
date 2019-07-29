using System;
using System.Text;
using System.Data;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Dao
{
    public class GetSapUserMasterMntDao : AbstractDataAccessObject
    {

        public override ValueObject Execute(TransactionContext trxContext, ValueObject arg)
        {

            StringBuilder sqlQuery = new StringBuilder();

            sqlQuery.Append("Select sapusr.mes_user_cd,sapusr.sap_user,sapusr.sap_password");
            sqlQuery.Append(" from m_sap_user sapusr");
            sqlQuery.Append(" inner join m_mes_user usr on usr.user_cd = sapusr.mes_user_cd");
            sqlQuery.Append(" inner join m_user_factory uf on usr.user_cd = uf.user_cd");
            sqlQuery.Append(" where usr.user_cd = :usercode ");
            sqlQuery.Append(" and uf.factory_cd = :factorycode ");

            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sqlQuery.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();

            sqlParameter.AddParameterString("usercode", trxContext.UserData.UserCode);

            sqlParameter.AddParameterString("factorycode", trxContext.UserData.FactoryCode);


            //execute SQL
            IDataReader dataReader = sqlCommandAdapter.ExecuteReader(trxContext, sqlParameter);

            SapUserVo outVo = null;
            while (dataReader.Read())
            {
                outVo = new SapUserVo();

                outVo.MesUserCode = DBDataCheckHelper.ConvertDBNullToStringNull(dataReader["mes_user_cd"]);
                outVo.SapUser = DBDataCheckHelper.ConvertDBNullToStringNull(dataReader["sap_user"]);
                outVo.SapPassWord = DBDataCheckHelper.ConvertDBNullToStringNull(dataReader["sap_password"]);

            }
            dataReader.Close();

            return outVo;
        }
    }
}
