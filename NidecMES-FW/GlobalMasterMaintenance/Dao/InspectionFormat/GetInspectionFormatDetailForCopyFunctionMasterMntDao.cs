using System;
using System.Text;
using System.Data;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Dao
{
    public class GetInspectionFormatDetailForCopyFunctionMasterMntDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject arg)
        {
            CopyInspectionFormatVo inVo = (CopyInspectionFormatVo)arg;

            StringBuilder sqlQuery = new StringBuilder();

            sqlQuery.Append(" select distinct if.* ");
            sqlQuery.Append(" ,ilf.line_id,ilf.sap_matnr_item_cd ");
            sqlQuery.Append(" from m_inspection_format if ");
            sqlQuery.Append(" inner join m_item_line_inspection_format ilf ");
            sqlQuery.Append(" on if.inspection_format_id  = ilf.inspection_format_id  ");
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

            if(inVo.InspectionFormatId > 0)
            {
                sqlQuery.Append(" and if.inspection_format_id = :inspectionformatid ");
            }
            if(inVo.InspectionProcessId > 0)
            {
                sqlQuery.Append(" and ip.inspection_process_id = :inspectionprocessid ");
            }
            if (inVo.InspectionItemId > 0)
            {
                sqlQuery.Append(" and it.inspection_item_id = :inspectionitemid ");
            }
            if (inVo.InspectionSelectionDataTypeValueId > 0)
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
            sqlParameter.AddParameterInteger("selectiondatatypevalueid", inVo.InspectionSelectionDataTypeValueId);
            sqlParameter.AddParameterInteger("inspectionspecificationid", inVo.InspectionSpecificationId);
            sqlParameter.AddParameterInteger("inspectiontestinstructionid", inVo.InspectionTestInstructionId);
            sqlParameter.AddParameterInteger("inspectiontestinstdetailid", inVo.InspectionTestInstructionDetailId);
            sqlParameter.AddParameterString("factorycd", trxContext.UserData.FactoryCode);

            //execute SQL
            IDataReader dataReader = sqlCommandAdapter.ExecuteReader(trxContext, sqlParameter);

            InspectionFormatVo outVo = new InspectionFormatVo();

            while (dataReader.Read())
            {
                outVo = new InspectionFormatVo();
                outVo.InspectionFormatId = ConvertDBNull<Int32>(dataReader, "inspection_format_id");
                outVo.InspectionFormatCode = ConvertDBNull<string>(dataReader, "inspection_format_cd");
                outVo.InspectionFormatName = ConvertDBNull<string>(dataReader, "inspection_format_name");
                outVo.SapItemCode = ConvertDBNull<string>(dataReader, "sap_matnr_item_cd");
                //outVo.ItemCode = ConvertDBNull<string>(dataReader, "global_item_cd");
                outVo.LineId = ConvertDBNull<int>(dataReader, "line_id");
                //outVo.LineCode = ConvertDBNull<string>(dataReader, "line_cd");  
            }
            dataReader.Close();            
            return outVo;
        }
    }
}
