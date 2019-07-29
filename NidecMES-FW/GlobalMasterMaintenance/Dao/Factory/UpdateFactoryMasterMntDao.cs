using System.Text;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Dao
{
    class UpdateFactoryMasterMntDao : AbstractDataAccessObject
    {

        public override ValueObject Execute(TransactionContext trxContext, ValueObject arg)
        {

            FactoryVo inVo = (FactoryVo)arg;         

            StringBuilder sqlQuery = new StringBuilder();

            sqlQuery.Append("Update m_factory");
            sqlQuery.Append(" set ");
            sqlQuery.Append(" factory_name =");
            sqlQuery.Append(" :factnm ");
            sqlQuery.Append(" Where	");
            sqlQuery.Append(" factory_cd =");
            sqlQuery.Append(" :factcd");

            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sqlQuery.ToString());

            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();

            sqlParameter.AddParameterString("factcd", inVo.FactoryCode);
            sqlParameter.AddParameterString("factnm", inVo.FactoryName);

            FactoryVo outVo = new FactoryVo {AffectedCount = sqlCommandAdapter.ExecuteNonQuery(sqlParameter)};

            return outVo;
        }      
    }
}
