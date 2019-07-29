using System.Text;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Dao
{
    public class UpdateInspectionTestInstructionMasterMntDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject arg)
        {
            InspectionTestInstructionVo inVo = (InspectionTestInstructionVo)arg;

            StringBuilder sqlQuery = new StringBuilder();

            sqlQuery.Append("Update m_inspection_test_instruction");
            sqlQuery.Append(" Set ");
            sqlQuery.Append(" inspection_test_instruction_cd = :inspectiontestinstructioncd, ");
            sqlQuery.Append(" inspection_test_instruction_text = :inspectiontestinstructiontext, ");
            sqlQuery.Append(" inspection_item_id = :inspectionitemid ");
            sqlQuery.Append(" Where	");
            sqlQuery.Append(" inspection_test_instruction_id = :inspectiontestinstructionid ");
            sqlQuery.Append(" and factory_cd = :faccd ;");
            

            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sqlQuery.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            sqlParameter.AddParameterInteger("inspectiontestinstructionid", inVo.InspectionTestInstructionId);
            sqlParameter.AddParameterString("inspectiontestinstructioncd", inVo.InspectionTestInstructionCode);
            sqlParameter.AddParameterString("inspectiontestinstructiontext", inVo.InspectionTestInstructionText);
            sqlParameter.AddParameterInteger("inspectionitemid", inVo.InspectionItemId);
            sqlParameter.AddParameterString("faccd", UserData.GetUserData().FactoryCode);

            InspectionTestInstructionVo outVo = new InspectionTestInstructionVo { AffectedCount = sqlCommandAdapter.ExecuteNonQuery(sqlParameter)};

            return outVo;
        }

  


    }
}
