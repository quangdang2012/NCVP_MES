using System.Text;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Dao
{
    public class AddBuildingMasterMntDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject arg)
        {
            BuildingVo inVo = (BuildingVo)arg;

            StringBuilder sqlQuery = new StringBuilder();

            sqlQuery.Append("Insert into m_building");
            sqlQuery.Append(" ( ");
            sqlQuery.Append(" building_cd, ");
            sqlQuery.Append(" building_name, ");
            //sqlQuery.Append(" building_id, ");
            sqlQuery.Append(" registration_user_cd, ");
            sqlQuery.Append(" registration_date_time, ");
            sqlQuery.Append(" factory_cd ");
            sqlQuery.Append(" ) ");
            sqlQuery.Append("VALUES	");
            sqlQuery.Append(" ( ");
            sqlQuery.Append(" :buildingcd ,");
            sqlQuery.Append(" :buildingname ,");
            //sqlQuery.Append(" :buildingid ,");
            sqlQuery.Append(" :registrationusercode ,");
            sqlQuery.Append(" :registrationdatetime ,");
            sqlQuery.Append(" :factorycode ");
            sqlQuery.Append(" ); ");

            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sqlQuery.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            sqlParameter.AddParameterString("buildingcd", inVo.BuildingCode);
            sqlParameter.AddParameterString("buildingname", inVo.BuildingName);
            //sqlParameter.AddParameterInteger("buildingid", inVo.BuildingId);
            sqlParameter.AddParameterString("registrationusercode", trxContext.UserData.UserCode);
            sqlParameter.AddParameterDateTime("registrationdatetime", trxContext.ProcessingDBDateTime);
            sqlParameter.AddParameterString("factorycode", inVo.FactoryCode);

            BuildingVo outVo = new BuildingVo { AffectedCount = sqlCommandAdapter.ExecuteNonQuery(sqlParameter)};

            return outVo;
        }


 
    }
}
