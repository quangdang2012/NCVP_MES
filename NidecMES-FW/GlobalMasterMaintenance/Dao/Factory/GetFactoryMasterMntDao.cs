using System.Text;
using System.Data;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Dao
{
    public class GetFactoryMasterMntDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject arg)
        {
            FactoryVo inVo = (FactoryVo)arg;

            StringBuilder sqlQuery = new StringBuilder();

            sqlQuery.Append("Select factory_cd,factory_name from m_factory");
            sqlQuery.Append(" where 1 = 1 ");

            if (inVo.FactoryCode != null)
            {
                sqlQuery.Append(" and factory_cd like :factcd ");
            }

            if (inVo.FactoryName != null)
            {
                sqlQuery.Append(" and factory_name like :factnm ");
            }

            sqlQuery.Append(" order by factory_cd ");

            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sqlQuery.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();


            if (inVo.FactoryCode != null)
            {
                sqlParameter.AddParameterString("factcd", inVo.FactoryCode + "%");
            }

            if (inVo.FactoryName != null)
            {
                sqlParameter.AddParameterString("factnm", inVo.FactoryName + "%");
            }

            //execute SQL
            IDataReader dataReader = sqlCommandAdapter.ExecuteReader(trxContext, sqlParameter);

            FactoryVo outVo = new FactoryVo();

            while (dataReader.Read())
            {
                FactoryVo currOutVo = new FactoryVo
                {
                    FactoryCode = dataReader["factory_cd"].ToString(),
                    FactoryName = dataReader["factory_name"].ToString()
                };
                outVo.FactoryListVo.Add(currOutVo);
            }
            dataReader.Close();

            return outVo;
        }
    }
}
