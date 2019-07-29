using System.Text;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Dao
{
    public class AddLineWorkContentMasterMntDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject arg)
        {
            LineWorkContentVo  inVo = (LineWorkContentVo)arg;
            UpdateResultVo outVo = new UpdateResultVo();

            StringBuilder sqlQuery = new StringBuilder();

            sqlQuery.Append("Insert into m_line_work_content");
            sqlQuery.Append(" ( ");
            sqlQuery.Append(" work_content_id, ");
            sqlQuery.Append(" line_id, ");
            sqlQuery.Append(" registration_user_cd, ");
            sqlQuery.Append(" registration_date_time, ");
            sqlQuery.Append(" factory_cd ");
            sqlQuery.Append(" ) ");
            sqlQuery.Append("VALUES	");
            sqlQuery.Append(" ( ");
            sqlQuery.Append(" :workContid ,");
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
            sqlParameter.AddParameterInteger("workContid", inVo.WorkContentId);
            sqlParameter.AddParameterString("registrationusercd", UserData.GetUserData().UserCode);
            sqlParameter.AddParameterDateTime("registrationdatetime", trxContext.ProcessingDBDateTime);
            sqlParameter.AddParameterString("factrycode", UserData.GetUserData().FactoryCode);

            outVo.AffectedCount += sqlCommandAdapter.ExecuteNonQuery(sqlParameter);

            return outVo;
        }
    }
}
