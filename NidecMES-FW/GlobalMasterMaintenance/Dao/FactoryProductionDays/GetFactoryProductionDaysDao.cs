using System;
using System.Text;
using System.Data;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Dao
{
    public class GetFactoryProductionDaysDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject arg)
        {
            FactoryProductionDaysVo inVo = (FactoryProductionDaysVo)arg;

            StringBuilder sqlQuery = new StringBuilder();

            sqlQuery.Append(" SELECT ");
            sqlQuery.Append("  fpd.factory_production_days_id, ");
            sqlQuery.Append("  fpd.year, ");
            sqlQuery.Append("  fpd.month, ");
            sqlQuery.Append("  fpd.days, ");
            sqlQuery.Append("  fpd.building_id, ");
            sqlQuery.Append("  bl.building_name ");
            sqlQuery.Append(" FROM ");
            sqlQuery.Append("  m_factory_production_days fpd ");
            sqlQuery.Append("  INNER JOIN m_building bl ON bl.building_id = fpd.building_id ");
            sqlQuery.Append(" WHERE ");
            sqlQuery.Append("  fpd.factory_cd = :factorycode ");
            if (inVo.iYear > 0)
            {
                sqlQuery.Append("  AND fpd.year = :iyear ");
            }
            if (inVo.BuildingId > 0)
            {
                sqlQuery.Append("  AND fpd.building_id = :buildingid ");
            }
            sqlQuery.Append(" ORDER BY bl.building_name, fpd.year, fpd.month, fpd.factory_production_days_id ");

            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sqlQuery.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            if (!string.IsNullOrEmpty(inVo.FactoryCode))
            {
                sqlParameter.AddParameterString("factorycode", inVo.FactoryCode);
            }
            else
            {
                sqlParameter.AddParameterString("factorycode", UserData.GetUserData().FactoryCode);
            }
            if (inVo.iYear > 0)
            {
                sqlParameter.AddParameterInteger("iyear", inVo.iYear);
            }
            if (inVo.BuildingId > 0)
            {
                sqlParameter.AddParameterInteger("buildingid", inVo.BuildingId);
            }

            //execute SQL
            IDataReader dataReader = sqlCommandAdapter.ExecuteReader(trxContext, sqlParameter);

            FactoryProductionDaysVo outVo = new FactoryProductionDaysVo();

            while (dataReader.Read())
            {
                FactoryProductionDaysVo currOutVo = new FactoryProductionDaysVo();
                currOutVo.FactoryProductionDaysId = ConvertDBNull<int>(dataReader, "factory_production_days_id");
                currOutVo.iYear = ConvertDBNull<int>(dataReader, "year");
                currOutVo.iMonth = ConvertDBNull<int>(dataReader, "month");
                currOutVo.iDays = ConvertDBNull<int>(dataReader, "days");
                currOutVo.BuildingId = ConvertDBNull<int>(dataReader, "building_id");
                currOutVo.BuildingName = ConvertDBNull<string>(dataReader, "building_name");
                outVo.FactoryProductionDaysListVo.Add(currOutVo);
            }
            dataReader.Close();

            return outVo;
        }
    }
}
