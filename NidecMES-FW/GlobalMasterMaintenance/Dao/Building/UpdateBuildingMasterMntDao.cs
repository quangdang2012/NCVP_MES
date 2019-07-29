using System.Text;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Dao
{
    public class UpdateBuildingMasterMntDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject arg)
        {
            BuildingVo inVo = (BuildingVo)arg;

            StringBuilder sqlQuery = new StringBuilder();

            sqlQuery.Append("Update m_building");
            sqlQuery.Append(" Set ");
            sqlQuery.Append(" building_name = :buildingname, ");
            sqlQuery.Append(" factory_cd = :factorycd ");
            sqlQuery.Append(" Where	");
            sqlQuery.Append(" building_id = :buildingid;");

            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sqlQuery.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            sqlParameter.AddParameterInteger("buildingid", inVo.BuildingId);
            sqlParameter.AddParameterString("buildingname", inVo.BuildingName);
            sqlParameter.AddParameterString("factorycd", inVo.FactoryCode);

            BuildingVo outVo = new BuildingVo { AffectedCount = sqlCommandAdapter.ExecuteNonQuery(sqlParameter)};

            return outVo;
        }

  


    }
}
