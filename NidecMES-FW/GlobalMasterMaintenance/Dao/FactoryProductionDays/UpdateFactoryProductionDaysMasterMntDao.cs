using System.Text;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Dao
{
    class UpdateFactoryProductionDaysMasterMntDao : AbstractDataAccessObject
    {

        public override ValueObject Execute(TransactionContext trxContext, ValueObject arg)
        {

            FactoryProductionDaysVo inVo = (FactoryProductionDaysVo)arg;         

            StringBuilder sqlQuery = new StringBuilder();

            sqlQuery.Append(" UPDATE ");
            sqlQuery.Append("  m_factory_production_days ");
            sqlQuery.Append(" SET ");
            sqlQuery.Append("  year = :iyear, ");
            sqlQuery.Append("  month = :imonth, ");
            sqlQuery.Append("  days = :idays ");
            sqlQuery.Append(" WHERE	");
            sqlQuery.Append("  factory_cd = :factorycode ");
            sqlQuery.Append(" AND ");
            sqlQuery.Append("  factory_production_days_id = :factoryproductiondaysid ");

            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sqlQuery.ToString());

            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();

            sqlParameter.AddParameterInteger("iyear", inVo.iYear);
            sqlParameter.AddParameterInteger("imonth", inVo.iMonth);
            sqlParameter.AddParameterInteger("idays", inVo.iDays);
            sqlParameter.AddParameterString("factorycode", inVo.FactoryCode);
            sqlParameter.AddParameterInteger("factoryproductiondaysid", inVo.FactoryProductionDaysId);

            FactoryProductionDaysVo outVo = new FactoryProductionDaysVo { AffectedCount = sqlCommandAdapter.ExecuteNonQuery(sqlParameter)};

            return outVo;
        }      
    }
}
