using System.Text;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Dao
{
    public class DeleteBuildingMasterMntDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject arg)
        {
            BuildingVo inVo = (BuildingVo)arg;

            StringBuilder sqlQuery = new StringBuilder();

            sqlQuery.Append("Delete From m_building");
            sqlQuery.Append(" Where	");
            sqlQuery.Append(" building_id = :buildingid ");
            sqlQuery.Append(" and factory_cd = :faccd ;");
            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sqlQuery.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            sqlParameter.AddParameterInteger("buildingid", inVo.BuildingId);
            sqlParameter.AddParameterString("faccd", UserData.GetUserData().FactoryCode);
            BuildingVo outVo = new BuildingVo { AffectedCount = sqlCommandAdapter.ExecuteNonQuery(sqlParameter)};

            return outVo;
        }
    }
}
