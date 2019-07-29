using System.Text;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Dao
{
    public class AddAreaMasterMntDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject arg)
        {
            AreaVo inVo = (AreaVo)arg;

            StringBuilder sqlQuery = new StringBuilder();

            sqlQuery.Append("Insert into m_area");
            sqlQuery.Append(" ( ");
            sqlQuery.Append(" area_cd, ");
            sqlQuery.Append(" area_name, ");
            sqlQuery.Append(" location_id, ");
            sqlQuery.Append(" registration_user_cd, ");
            sqlQuery.Append(" registration_date_time, ");
            sqlQuery.Append(" factory_cd ");
            sqlQuery.Append(" ) ");
            sqlQuery.Append("VALUES	");
            sqlQuery.Append(" ( ");
            sqlQuery.Append(" :areacd ,");
            sqlQuery.Append(" :areaname ,");
            sqlQuery.Append(" :locationid ,");
            sqlQuery.Append(" :registrationusercode ,");
            sqlQuery.Append(" :registrationdatetime ,");
            sqlQuery.Append(" :factorycode ");
            sqlQuery.Append(" ); ");

            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sqlQuery.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            sqlParameter.AddParameterString("areacd", inVo.AreaCode);
            sqlParameter.AddParameterString("areaname", inVo.AreaName);
            sqlParameter.AddParameterInteger("locationid", inVo.LocationId);
            sqlParameter.AddParameterString("registrationusercode", trxContext.UserData.UserCode);
            sqlParameter.AddParameterDateTime("registrationdatetime", trxContext.ProcessingDBDateTime);
            sqlParameter.AddParameterString("factorycode", trxContext.UserData.FactoryCode);

            AreaVo outVo = new AreaVo {AffectedCount = sqlCommandAdapter.ExecuteNonQuery(sqlParameter)};

            return outVo;
        }


 
    }
}
