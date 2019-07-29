using System.Text;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Dao
{
    public class AddLineBuildingMasterMntDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject arg)
        {
            LineBuildingVo  inVo = (LineBuildingVo)arg;
            UpdateResultVo outVo = new UpdateResultVo();

            StringBuilder sqlQuery = new StringBuilder();

            sqlQuery.Append("Insert into m_line_building");
            sqlQuery.Append(" ( ");
            sqlQuery.Append(" building_id, ");
            sqlQuery.Append(" line_id, ");
            sqlQuery.Append(" registration_user_cd, ");
            sqlQuery.Append(" registration_date_time, ");
            sqlQuery.Append(" factory_cd ");
            sqlQuery.Append(" ) ");
            sqlQuery.Append("VALUES	");
            sqlQuery.Append(" ( ");
            sqlQuery.Append(" :buildingid ,");
            sqlQuery.Append(" :lineid ,");
            sqlQuery.Append(" :registrationusercd ,");
            sqlQuery.Append(" :registrationdatetime ,");
            sqlQuery.Append(" :factrycode ");
            sqlQuery.Append(" ); ");


            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sqlQuery.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();

            sqlParameter.AddParameterInteger("lineid", inVo.LineId);
            sqlParameter.AddParameterInteger("buildingid", inVo.BuildingId);
            sqlParameter.AddParameterString("registrationusercd", UserData.GetUserData().UserCode);
            sqlParameter.AddParameterDateTime("registrationdatetime", trxContext.ProcessingDBDateTime);
            sqlParameter.AddParameterString("factrycode", UserData.GetUserData().FactoryCode);

            outVo.AffectedCount += sqlCommandAdapter.ExecuteNonQuery(sqlParameter);

            return outVo;
        }
    }
}
