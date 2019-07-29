using System;
using System.Text;
using System.Data;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Dao
{
    public class CheckFactoryRelationDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject arg)
        {

            FactoryVo inVo = (FactoryVo)arg;

            StringBuilder sqlQuery = new StringBuilder();

            sqlQuery.Append("select count(uf.user_cd) as UserCount from m_factory fa");
            sqlQuery.Append(" inner join m_user_factory uf on uf.factory_cd = fa.factory_cd");
            sqlQuery.Append(" where 1 = 1 ");

            if (inVo.FactoryCode != null)
            {
                sqlQuery.Append(" and UPPER(fa.factory_cd) = UPPER(:factcd)");
            }
            
            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sqlQuery.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();


            if (inVo.FactoryCode != null)
            {
                sqlParameter.AddParameterString("factcd", inVo.FactoryCode);
            }

            //execute SQL
            IDataReader dataReader = sqlCommandAdapter.ExecuteReader(trxContext, sqlParameter);

            FactoryVo outVo = new FactoryVo();

            while (dataReader.Read())
            {
                outVo.AffectedCount = Convert.ToInt32("0" + dataReader["UserCount"]);
            }

            dataReader.Close();

            return outVo;
        }
    }
}
