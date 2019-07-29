using System;
using System.Text;
using System.Data;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Dao
{
    public class GetUserFactoryMasterMntDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject arg)
        {
            UserFactoryVo inVo = (UserFactoryVo)arg;               

            StringBuilder sqlQuery = new StringBuilder();

            sqlQuery.Append("select user_cd, factory_cd, factory_name, display_order from (");
            sqlQuery.Append("select mu.user_cd, mf.factory_cd, mf.factory_name, COALESCE(uf.display_order, 99) display_order");
            sqlQuery.Append(" from m_mes_user mu ");
            sqlQuery.Append(" inner join m_factory mf on mf.factory_cd = mf.factory_cd");
            sqlQuery.Append(" left outer join m_user_factory uf on uf.user_cd = mu.user_cd and uf.factory_cd = mf.factory_cd");
            sqlQuery.Append(" where 1 = 1 ");

            if (inVo.UserCode != null)
            {
                sqlQuery.Append(" and mu.user_cd = :usercd ");
            }

            if (inVo.FactoryCd != null)
            {
                sqlQuery.Append(" and uf.factory_cd = :factorycd ");
            }

            sqlQuery.Append(") d");
            sqlQuery.Append(" order by d.user_cd, d.display_order");

            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sqlQuery.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();

            if (inVo.UserCode != null)
            {
                sqlParameter.AddParameterString("usercd", inVo.UserCode);
            }

            if (inVo.FactoryCd != null)
            {
                sqlParameter.AddParameterString("factorycd", inVo.FactoryCd);
            }

            //execute SQL
            IDataReader dataReader = sqlCommandAdapter.ExecuteReader(trxContext, sqlParameter);

            UserFactoryVo outVo = new UserFactoryVo();

            while (dataReader.Read())
            {
                UserFactoryVo currOutVo = new UserFactoryVo
                {
                    UserCode = dataReader["user_cd"].ToString(),
                    FactoryCd = dataReader["factory_cd"].ToString(),
                    FactoryName = dataReader["factory_name"].ToString(),
                    DisplayOrder = Convert.ToInt32(dataReader["display_order"])
                };

                outVo.UserFactoryListVo.Add(currOutVo);
            }

            dataReader.Close();

            return outVo;
        } 
    }
}
