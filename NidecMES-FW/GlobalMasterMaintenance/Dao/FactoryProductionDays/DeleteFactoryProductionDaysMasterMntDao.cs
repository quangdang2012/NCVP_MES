using System;
using System.Text;
using System.Data;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Dao
{
    public class DeleteFactoryProductionDaysMasterMntDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject arg)
        {
            FactoryProductionDaysVo inVo = (FactoryProductionDaysVo)arg;
            StringBuilder sqlQuery = new StringBuilder();

            sqlQuery.Append(" DELETE from");
            sqlQuery.Append("  m_factory_production_days ");
            sqlQuery.Append(" WHERE	");
            sqlQuery.Append("  factory_production_days_id = :factoryproductiondaysid; ");

            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sqlQuery.ToString());

            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            sqlParameter.AddParameterInteger("factoryproductiondaysid", inVo.FactoryProductionDaysId);

            FactoryProductionDaysVo outVo = new FactoryProductionDaysVo { AffectedCount = sqlCommandAdapter.ExecuteNonQuery(sqlParameter) };

            return outVo;
        }
    }
}
