using System.Text;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Dao
{
    class AddInspectionTestInstructionDetailCopyDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject arg)
        {

            ValueObjectList<InspectionTestInstructionVo> inVo = (ValueObjectList<InspectionTestInstructionVo>)arg;

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

            StringBuilder sqlValues = new StringBuilder();
            UserData userdata = trxContext.UserData;

            foreach (InspectionTestInstructionVo getTestInstructionVo in inVo.GetList())
            {
                if (sqlValues.Length > 0)
                {
                    sqlValues.Append(" , ");
                }

                sqlValues.Append(" (");

                sqlValues.Append("'" + getTestInstructionVo.InspectionTestInstructionDetailCode + "' ,");
                sqlValues.Append("'" + getTestInstructionVo.InspectionTestInstructionDetailText + "' ,");
                sqlValues.Append(getTestInstructionVo.InspectionTestInstructionDetailResultCount + ",");
                sqlValues.Append("'" + getTestInstructionVo.InspectionTestInstructionDetailMachine + "' ,");
                sqlValues.Append(getTestInstructionVo.InspectionTestInstructionId + ",");
                sqlValues.Append("'" + userdata.UserCode + "' ,");
                sqlValues.Append("'" + trxContext.ProcessingDBDateTime + "' ,");
                sqlValues.Append("'" + userdata.FactoryCode + "'");

                sqlValues.Append(" ) ");
            }

            sqlQuery.Append(sqlValues.ToString());

            //sqlQuery.Append(" ( ");
            //sqlQuery.Append(" :inspectiontestinstructiondetailcd,");
            //sqlQuery.Append(" :inspectiontestinstructiondetailtext,");
            //sqlQuery.Append(" :inspectiontestinstructiondetailresultcount,");         
            //sqlQuery.Append(" :inspectiontestinstructiondetailmachine,");
            //sqlQuery.Append(" :inspectiontestinstructionid,");
            //sqlQuery.Append(" :registrationusercode,");
            //sqlQuery.Append(" :regdatetime,");
            //sqlQuery.Append(" :factorycode");
            //sqlQuery.Append(" ); ");

            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sqlQuery.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();

            //sqlParameter.AddParameterString("inspectiontestinstructiondetailcd", inVo.InspectionTestInstructionDetailCode);
            //sqlParameter.AddParameterString("inspectiontestinstructiondetailtext", inVo.InspectionTestInstructionDetailText);
            //sqlParameter.AddParameterInteger("inspectiontestinstructiondetailresultcount", inVo.InspectionTestInstructionDetailResultCount);
            //sqlParameter.AddParameterInteger("inspectiontestinstructionid", inVo.InspectionTestInstructionId);
            //sqlParameter.AddParameterString("inspectiontestinstructiondetailmachine", inVo.InspectionTestInstructionDetailMachine);
            //sqlParameter.AddParameterString("registrationusercode", UserData.GetUserData().UserCode);
            //sqlParameter.AddParameterDateTime("regdatetime", trxContext.ProcessingDBDateTime);
            //sqlParameter.AddParameterString("factorycode", UserData.GetUserData().FactoryCode);

            UpdateResultVo outVo = new UpdateResultVo { AffectedCount = sqlCommandAdapter.ExecuteNonQuery(sqlParameter) };

            return outVo;
        }
    }
}
