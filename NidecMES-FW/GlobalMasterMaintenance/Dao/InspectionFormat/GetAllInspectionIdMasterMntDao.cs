using System;
using System.Text;
using System.Data;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Dao
{
    public class GetAllInspectionIdMasterMntDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject arg)
        {
            InspectionReturnVo inVo = (InspectionReturnVo)arg;

            StringBuilder sqlQuery = new StringBuilder();

            sqlQuery.Append(" select distinct if.inspection_format_id, ");
            sqlQuery.Append(" ip.inspection_process_id, ");
            sqlQuery.Append(" it.inspection_item_id, ");
            sqlQuery.Append(" isn.inspection_specification_id, ");
            sqlQuery.Append(" ti.inspection_test_instruction_id, ");
            sqlQuery.Append(" sv.inspection_item_selection_datatype_value_id, ");
            sqlQuery.Append(" itd.inspection_test_instruction_detail_id  ");
            sqlQuery.Append(" from m_inspection_format if ");            
            sqlQuery.Append(" left join ");
            sqlQuery.Append(" m_inspection_process ip ");
            sqlQuery.Append(" on ip.inspection_format_id = if.inspection_format_id ");
            sqlQuery.Append(" left join  ");
            sqlQuery.Append(" m_inspection_item it  ");
            sqlQuery.Append(" on it.inspection_process_id = ip.inspection_process_id ");
            sqlQuery.Append(" left join ");
            sqlQuery.Append(" m_inspection_specification isn ");
            sqlQuery.Append(" on isn.inspection_item_id = it.inspection_item_id ");
            sqlQuery.Append(" left join ");
            sqlQuery.Append(" m_inspection_test_instruction ti on ");
            sqlQuery.Append(" ti.inspection_item_id = it.inspection_item_id ");
            sqlQuery.Append(" left join  ");
            sqlQuery.Append(" m_inspection_item_selection_datatype_value sv ");
            sqlQuery.Append(" on sv.inspection_item_id = it.inspection_item_id ");
            sqlQuery.Append(" left join m_inspection_test_instruction_detail itd ");
            sqlQuery.Append(" on itd.inspection_test_instruction_id = ti.inspection_test_instruction_id ");
            sqlQuery.Append(" where if.factory_cd = :factorycd ");

            if (inVo.InspectionFormatId > 0)
            {
                sqlQuery.Append(" and if.inspection_format_id = :inspectionformatid ");
            }
            if (inVo.InspectionProcessId > 0)
            {
                sqlQuery.Append(" and ip.inspection_process_id = :inspectionprocessid ");
            }
            if (inVo.InspectionItemId > 0)
            {
                sqlQuery.Append(" and it.inspection_item_id = :inspectionitemid ");
            }
            if (inVo.InspectionSelectionValueDataTypeId > 0)
            {
                sqlQuery.Append(" and sv.inspection_item_selection_datatype_value_id = :selectiondatatypevalueid");
            }
            if (inVo.InspectionSpecificationId > 0)
            {
                sqlQuery.Append(" and isn.inspection_specification_id = :inspectionspecificationid ");
            }
            if (inVo.InspectionTestInstructionId > 0)
            {
                sqlQuery.Append(" and ti.inspection_test_instruction_id = :inspectiontestinstructionid ");
            }
            if (inVo.InspectionTestInstructionDetailId > 0)
            {
                sqlQuery.Append(" and itd.inspection_test_instruction_detail_id = :inspectiontestinstdetailid ");
            }

            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sqlQuery.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            sqlParameter.AddParameterInteger("inspectionformatid", inVo.InspectionFormatId);
            sqlParameter.AddParameterInteger("inspectionprocessid", inVo.InspectionProcessId);
            sqlParameter.AddParameterInteger("inspectionitemid", inVo.InspectionItemId);
            sqlParameter.AddParameterInteger("selectiondatatypevalueid", inVo.InspectionSelectionValueDataTypeId);
            sqlParameter.AddParameterInteger("inspectionspecificationid", inVo.InspectionSpecificationId);
            sqlParameter.AddParameterInteger("inspectiontestinstructionid", inVo.InspectionTestInstructionId);
            sqlParameter.AddParameterInteger("inspectiontestinstdetailid", inVo.InspectionTestInstructionDetailId);
            sqlParameter.AddParameterString("factorycd", trxContext.UserData.FactoryCode);

            //execute SQL
            IDataReader dataReader = sqlCommandAdapter.ExecuteReader(trxContext, sqlParameter);

            InspectionReturnVo outVo = new InspectionReturnVo();

            while (dataReader.Read())
            {
                outVo = new InspectionReturnVo();
                outVo.InspectionFormatId = ConvertDBNull<int>(dataReader, "inspection_format_id");
                outVo.InspectionProcessId = ConvertDBNull<int>(dataReader, "inspection_process_id");
                outVo.InspectionItemId = ConvertDBNull<int>(dataReader, "inspection_item_id");
                outVo.InspectionSpecificationId = ConvertDBNull<int>(dataReader, "inspection_specification_id");
                outVo.InspectionSelectionValueDataTypeId = ConvertDBNull<int>(dataReader, "inspection_item_selection_datatype_value_id");
                outVo.InspectionTestInstructionId = ConvertDBNull<int>(dataReader, "inspection_test_instruction_id");
                outVo.InspectionTestInstructionDetailId = ConvertDBNull<int>(dataReader, "inspection_test_instruction_detail_id");  
            }
            dataReader.Close();
            return outVo;
        }
    }
}
