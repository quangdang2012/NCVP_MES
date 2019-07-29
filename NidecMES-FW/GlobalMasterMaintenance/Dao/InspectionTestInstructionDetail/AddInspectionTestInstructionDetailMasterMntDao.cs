using System.Text;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Dao
{
    class AddInspectionTestInstructionDetailMasterMntDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject arg)
        {

            InspectionTestInstructionVo inVo = (InspectionTestInstructionVo)arg;

            StringBuilder sqlQuery = new StringBuilder();

            sqlQuery.Append("Insert into m_inspection_test_instruction_detail");
            sqlQuery.Append(" ( ");
            sqlQuery.Append(" inspection_test_instruction_detail_cd,");
            sqlQuery.Append(" inspection_test_instruction_detail_text,");
            sqlQuery.Append(" inspection_test_instruction_detail_result_count,");           
            sqlQuery.Append(" inspection_test_instruction_detail_machine_text, ");
            sqlQuery.Append(" inspection_test_instruction_id,");
            sqlQuery.Append(" registration_user_cd,");
            sqlQuery.Append(" registration_date_time,");
            sqlQuery.Append(" factory_cd");
            sqlQuery.Append(" ) ");
            sqlQuery.Append("VALUES	");
            sqlQuery.Append(" ( ");
            sqlQuery.Append(" :inspectiontestinstructiondetailcd,");
            sqlQuery.Append(" :inspectiontestinstructiondetailtext,");
            sqlQuery.Append(" :inspectiontestinstructiondetailresultcount,");         
            sqlQuery.Append(" :inspectiontestinstructiondetailmachine,");
            sqlQuery.Append(" :inspectiontestinstructionid,");
            sqlQuery.Append(" :registrationusercode,");
            sqlQuery.Append(" :regdatetime,");
            sqlQuery.Append(" :factorycode");
            sqlQuery.Append(" ); ");

            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sqlQuery.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();

            sqlParameter.AddParameterString("inspectiontestinstructiondetailcd", inVo.InspectionTestInstructionDetailCode);
            sqlParameter.AddParameterString("inspectiontestinstructiondetailtext", inVo.InspectionTestInstructionDetailText);
            sqlParameter.AddParameterInteger("inspectiontestinstructiondetailresultcount", inVo.InspectionTestInstructionDetailResultCount);
            sqlParameter.AddParameterInteger("inspectiontestinstructionid", inVo.InspectionTestInstructionId);
            sqlParameter.AddParameterString("inspectiontestinstructiondetailmachine", inVo.InspectionTestInstructionDetailMachine);
            sqlParameter.AddParameterString("registrationusercode", UserData.GetUserData().UserCode);
            sqlParameter.AddParameterDateTime("regdatetime", trxContext.ProcessingDBDateTime);
            sqlParameter.AddParameterString("factorycode", UserData.GetUserData().FactoryCode);

            UpdateResultVo outVo = new UpdateResultVo { AffectedCount = sqlCommandAdapter.ExecuteNonQuery(sqlParameter) };

            return outVo;
        }
    }
}
