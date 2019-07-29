using System;
using System.Text;
using System.Data;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Dao
{
    public class CheckFactoryProductionDaysMasterMntDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject arg)
        {

            FactoryProductionDaysVo inVo = (FactoryProductionDaysVo)arg;

            StringBuilder sqlQuery = new StringBuilder();

            sqlQuery.Append(" SELECT ");
            sqlQuery.Append("  Count(*) AS FactoryProductionDaysCount ");
            sqlQuery.Append(" FROM ");
            sqlQuery.Append("  m_factory_production_days ");
            sqlQuery.Append(" WHERE 1 = 1 ");
            sqlQuery.Append(" AND UPPER(factory_cd) = UPPER(:factorycode) ");
            sqlQuery.Append(" AND building_id = :buildingid ");
            sqlQuery.Append(" AND year = :iyear ");
            sqlQuery.Append(" AND month = :imonth ");

            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sqlQuery.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();

            sqlParameter.AddParameterString("factorycode", inVo.FactoryCode);
            sqlParameter.AddParameterInteger("buildingid", inVo.BuildingId);
            sqlParameter.AddParameterInteger("iyear", inVo.iYear);
            sqlParameter.AddParameterInteger("imonth", inVo.iMonth);

            //execute SQL
            IDataReader dataReader = sqlCommandAdapter.ExecuteReader(trxContext, sqlParameter);

            FactoryProductionDaysVo outVo = new FactoryProductionDaysVo();

            while (dataReader.Read())
            {
                outVo.AffectedCount = Convert.ToInt32(dataReader["FactoryProductionDaysCount"]);
            }

            dataReader.Close();

            return outVo;
        }
    }
}
