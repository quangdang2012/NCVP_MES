using System.Text;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Dao
{
    public class UpdateInstructionDetailResultCntMasterMntDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject arg)
        {
            InspectionTestInstructionVo inVo = (InspectionTestInstructionVo)arg;

            StringBuilder sqlQuery = new StringBuilder();

            sqlQuery.Append("Update m_inspection_test_instruction_detail");
            sqlQuery.Append(" Set ");            
            sqlQuery.Append(" inspection_test_instruction_detail_result_count = :inspectiontestinstructiondetailresultcount "); 
            sqlQuery.Append(" Where	");
            sqlQuery.Append(" inspection_test_instruction_id = :inspectiontestinstructionid ");
            sqlQuery.Append(" and factory_cd = :faccd ;");
            

            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sqlQuery.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();           
            sqlParameter.AddParameterInteger("inspectiontestinstructiondetailresultcount", inVo.InspectionTestInstructionDetailResultCount);
            sqlParameter.AddParameterInteger("inspectiontestinstructionid", inVo.InspectionTestInstructionId);
            sqlParameter.AddParameterString("faccd", UserData.GetUserData().FactoryCode);

            InspectionTestInstructionVo outVo = new InspectionTestInstructionVo { AffectedCount = sqlCommandAdapter.ExecuteNonQuery(sqlParameter)};

            return outVo;
        }

  


    }
}
