using System.Text;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Dao
{
    public class AddProcessDefectiveReasonMasterMntNewDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject arg)
        {
            ProcessDefectiveReasonVo inVo = (ProcessDefectiveReasonVo)arg;
            ProcessDefectiveReasonVo outVo = new ProcessDefectiveReasonVo();

            StringBuilder sqlQuery = new StringBuilder();

            sqlQuery.Append("Insert into m_process_work_defective_reason");
            sqlQuery.Append(" ( ");
            sqlQuery.Append(" defective_reason_id, ");
            sqlQuery.Append(" process_work_id, ");
            sqlQuery.Append(" registration_user_cd, ");
            sqlQuery.Append(" registration_date_time, ");
            sqlQuery.Append(" factory_cd ");
            sqlQuery.Append(" ) ");
            sqlQuery.Append("VALUES	");
            sqlQuery.Append(" ( ");
            sqlQuery.Append(" :defrid ,");
            sqlQuery.Append(" :processworkid ,");
            sqlQuery.Append(" :registrationusercd ,");
            sqlQuery.Append(" :registrationdatetime ,");
            sqlQuery.Append(" :factrycode ");
            sqlQuery.Append(" ); ");


            foreach (ProcessDefectiveReasonVo curVo in inVo.ProcessDefectiveReasonListVo)
            {
                //create command
                DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sqlQuery.ToString());

                //create parameter
                DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();

                sqlParameter.AddParameterInteger("processworkid", curVo.ProcessWorkId);
                sqlParameter.AddParameterInteger("defrid", inVo.DefectiveReasonId);
                sqlParameter.AddParameterString("registrationusercd", UserData.GetUserData().UserCode);
                sqlParameter.AddParameterDateTime("registrationdatetime", trxContext.ProcessingDBDateTime);
                sqlParameter.AddParameterString("factrycode", UserData.GetUserData().FactoryCode);

                outVo.AffectedCount += sqlCommandAdapter.ExecuteNonQuery(sqlParameter);
            }

            return outVo;
        }
    }
}
