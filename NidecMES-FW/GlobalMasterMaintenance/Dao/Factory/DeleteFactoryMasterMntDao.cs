using System.Text;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Dao
{
    public class DeleteFactoryMasterMntDao : AbstractDataAccessObject
    {

        public override ValueObject Execute(TransactionContext trxContext, ValueObject arg)
        {

            FactoryVo inVo = (FactoryVo)arg;

            StringBuilder sqlQuery=new StringBuilder();

            sqlQuery.Append("Delete from m_factory");
            sqlQuery.Append(" Where	");
            sqlQuery.Append(" factory_cd =");
            sqlQuery.Append(" :factcd");

            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sqlQuery.ToString());

            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();

            sqlParameter.AddParameterString("factcd", inVo.FactoryCode);

            FactoryVo outVo = new FactoryVo {AffectedCount = sqlCommandAdapter.ExecuteNonQuery(sqlParameter)};

            return outVo;
        }        
    }
}
