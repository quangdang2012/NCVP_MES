using System.Text;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Dao
{
    class AddInspectionTestInstructionMasterMntDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject arg)
        {

            InspectionTestInstructionVo inVo = (InspectionTestInstructionVo)arg;
            
            StringBuilder sqlQuery = new StringBuilder();

            sqlQuery.Append("Insert into m_inspection_test_instruction");
            sqlQuery.Append(" ( ");
            sqlQuery.Append(" inspection_test_instruction_cd,");
            sqlQuery.Append(" inspection_test_instruction_text,");
            sqlQuery.Append(" inspection_item_id,");
            sqlQuery.Append(" registration_user_cd,");
            sqlQuery.Append(" registration_date_time,");
            sqlQuery.Append(" factory_cd");
            sqlQuery.Append(" ) ");
            sqlQuery.Append("VALUES	");
            sqlQuery.Append(" ( ");
            sqlQuery.Append(" :inspectiontestinstructioncd,");
            sqlQuery.Append(" :inspectiontestinstructiontext,");
            sqlQuery.Append(" :inspectionitemid,");
            sqlQuery.Append(" :registrationusercode,");
            sqlQuery.Append(" :regdatetime,");
            sqlQuery.Append(" :factorycode");
            sqlQuery.Append(" ) ");
            sqlQuery.Append(" RETURNING inspection_test_instruction_id;");
            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sqlQuery.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
                        
            sqlParameter.AddParameterString("inspectiontestinstructioncd", inVo.InspectionTestInstructionCode);
            sqlParameter.AddParameterString("inspectiontestinstructiontext", inVo.InspectionTestInstructionText);
            sqlParameter.AddParameterInteger("inspectionitemid", inVo.InspectionItemId);

            UserData userdata = trxContext.UserData;

            sqlParameter.AddParameterString("registrationusercode", userdata.UserCode);
            sqlParameter.AddParameterDateTime("regdatetime", trxContext.ProcessingDBDateTime);
            sqlParameter.AddParameterString("factorycode", userdata.FactoryCode);

            InspectionTestInstructionVo outVo = new InspectionTestInstructionVo();
            outVo.InspectionTestInstructionId = (int?)sqlCommandAdapter.ExecuteScalar(sqlParameter) ?? 0;
            return outVo;
        }
    }
}
