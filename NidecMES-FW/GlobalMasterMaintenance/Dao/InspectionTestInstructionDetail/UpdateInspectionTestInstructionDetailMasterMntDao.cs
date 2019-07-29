using System.Text;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Dao
{
    public class UpdateInspectionTestInstructionDetailMasterMntDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject arg)
        {
            InspectionTestInstructionVo inVo = (InspectionTestInstructionVo)arg;

            StringBuilder sqlQuery = new StringBuilder();

            sqlQuery.Append("Update m_inspection_test_instruction_detail");
            sqlQuery.Append(" Set ");
            sqlQuery.Append(" inspection_test_instruction_detail_cd = :inspectiontestinstructiondetailcd, ");
            sqlQuery.Append(" inspection_test_instruction_detail_text = :inspectiontestinstructiondetailtext, ");
            sqlQuery.Append(" inspection_test_instruction_detail_result_count = :inspectiontestinstructiondetailresultcount, ");
            sqlQuery.Append(" inspection_test_instruction_id = :inspectiontestinstructionid, ");
            sqlQuery.Append(" inspection_test_instruction_detail_machine_text = :inspectiontestinstructiondetailmachine ");
            sqlQuery.Append(" Where	");
            sqlQuery.Append(" inspection_test_instruction_detail_id = :inspectiontestinstructiondetailid ");
            sqlQuery.Append(" and factory_cd = :faccd ;");
            

            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sqlQuery.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            sqlParameter.AddParameterInteger("inspectiontestinstructiondetailid", inVo.InspectionTestInstructionDetailId);
            sqlParameter.AddParameterString("inspectiontestinstructiondetailcd", inVo.InspectionTestInstructionDetailCode);
            sqlParameter.AddParameterString("inspectiontestinstructiondetailtext", inVo.InspectionTestInstructionDetailText);
            sqlParameter.AddParameterInteger("inspectiontestinstructiondetailresultcount", inVo.InspectionTestInstructionDetailResultCount);
            sqlParameter.AddParameterInteger("inspectiontestinstructionid", inVo.InspectionTestInstructionId);
            sqlParameter.AddParameterString("inspectiontestinstructiondetailmachine", inVo.InspectionTestInstructionDetailMachine);
            sqlParameter.AddParameterString("faccd", UserData.GetUserData().FactoryCode);

            InspectionTestInstructionVo outVo = new InspectionTestInstructionVo { AffectedCount = sqlCommandAdapter.ExecuteNonQuery(sqlParameter)};

            return outVo;
        }

  


    }
}
