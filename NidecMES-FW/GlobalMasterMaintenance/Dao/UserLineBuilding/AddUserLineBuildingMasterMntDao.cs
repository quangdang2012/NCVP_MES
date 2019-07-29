using System.Text;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Dao
{
    public class AddUserLineBuildingMasterMntDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject arg)
        {
            UserLineBuildingVo inVo = (UserLineBuildingVo)arg;

            StringBuilder sqlQuery = new StringBuilder();

            sqlQuery.Append("Insert into m_user_line_building");
            sqlQuery.Append(" ( ");
            sqlQuery.Append(" line_building_id, ");
            sqlQuery.Append(" user_cd, ");
            sqlQuery.Append(" registration_user_cd, ");
            sqlQuery.Append(" registration_date_time, ");
            sqlQuery.Append(" factory_cd ");
            sqlQuery.Append(" ) ");
            sqlQuery.Append("VALUES	");
            sqlQuery.Append(" ( ");
            sqlQuery.Append(" :linebuildingid ,");
            sqlQuery.Append(" :usercd ,");
            sqlQuery.Append(" :registrationusercode ,");
            sqlQuery.Append(" :registrationdatetime ,");
            sqlQuery.Append(" :factorycode ");
            sqlQuery.Append(" ); ");

            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sqlQuery.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();

            sqlParameter.AddParameterString("usercd", inVo.UserCode);
            sqlParameter.AddParameterInteger("linebuildingid", inVo.LineBuildingId );
            sqlParameter.AddParameterString("registrationusercode", UserData.GetUserData().UserCode);
            sqlParameter.AddParameterDateTime("registrationdatetime", trxContext.ProcessingDBDateTime);
            sqlParameter.AddParameterString("factorycode", UserData.GetUserData().FactoryCode);

            UpdateResultVo outVo = new UpdateResultVo { AffectedCount = sqlCommandAdapter.ExecuteNonQuery(sqlParameter) };

            return outVo;
        }
    }
}
