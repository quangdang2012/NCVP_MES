using System;
using System.Text;
using System.Data;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Dao
{
    public class CheckFactoryMasterMntDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject arg)
        {

            FactoryVo inVo = (FactoryVo)arg;

            StringBuilder sqlQuery = new StringBuilder();

            sqlQuery.Append("Select Count(*) as FactoryCount from m_factory");
            sqlQuery.Append(" where 1 = 1 ");

            if (inVo.FactoryCode != null)
            {
                sqlQuery.Append(" and UPPER(factory_cd) = UPPER(:factcd)");
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
                outVo.AffectedCount = Convert.ToInt32(dataReader["FactoryCount"]);
            }

            dataReader.Close();

            return outVo;
        }
    }
}
