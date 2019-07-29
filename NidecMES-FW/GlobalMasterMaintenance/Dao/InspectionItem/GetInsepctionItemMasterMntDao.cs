using System.Text;
using System.Data;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Dao
{
    public class GetInspectionItemMasterMntDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject arg)
        {
            InspectionItemVo inVo = (InspectionItemVo)arg;

            StringBuilder sqlQuery = new StringBuilder();

            //create SQL
            sqlQuery.Append(" Select pr.inspection_process_id,  ");
            sqlQuery.Append("       inspection_process_name,it.is_inspection_item_mandatory,  ");
            sqlQuery.Append("       it.inspection_item_cd,it.inspection_item_name,COALESCE(it.parent_inspection_item_id,0) as parent_inspection_item_id,it.inspection_item_id,  ");
            sqlQuery.Append("       it.is_inspection_item_mandatory,it.is_inspection_employee_mandatory,it.is_inspection_machine_mandatory,  ");
            sqlQuery.Append("       it.inspection_item_data_type,");
            sqlQuery.Append("       it.inspection_item_result_input_decimal_digits,");
            sqlQuery.Append("       it.display_order,");
            sqlQuery.Append("       it1.inspection_item_name as parentitemname,it1.parent_inspection_item_id,   ");
            sqlQuery.Append("       ispec.inspection_specification_id,");
            sqlQuery.Append("       ispec.inspection_specification_cd,");
            sqlQuery.Append("       ispec.inspection_specification_text,");
            sqlQuery.Append("       itinsth.inspection_test_instruction_id,");
            sqlQuery.Append("       itinsth.inspection_test_instruction_cd,");
            sqlQuery.Append("       itinsth.inspection_test_instruction_text,");
            sqlQuery.Append("       itinstd.inspection_test_instruction_detail_id");
            sqlQuery.Append(" from m_inspection_item it  ");
            sqlQuery.Append(" inner join m_inspection_process pr on  it.inspection_process_id = pr.inspection_process_id  ");
            sqlQuery.Append(" left join m_inspection_item it1 on it1.inspection_item_id = it.parent_inspection_item_id  ");
            sqlQuery.Append(" left join m_inspection_specification ispec on it.inspection_item_id = ispec.inspection_item_id  ");
            sqlQuery.Append(" left join m_inspection_test_instruction itinsth on it.inspection_item_id = itinsth.inspection_item_id");

            sqlQuery.Append(" left join ");
            sqlQuery.Append("              ( select max(inspection_test_instruction_detail_id) as inspection_test_instruction_detail_id ");
            sqlQuery.Append("              ,dtl.inspection_test_instruction_id ");
            sqlQuery.Append("              from m_inspection_test_instruction_detail dtl ");
            sqlQuery.Append("              inner join m_inspection_test_instruction hd on hd.inspection_test_instruction_id=dtl.inspection_test_instruction_id ");
            sqlQuery.Append("              group by dtl.inspection_test_instruction_id )itinstd ");
            sqlQuery.Append("              on itinstd.inspection_test_instruction_id = itinsth.inspection_test_instruction_id ");
            
            sqlQuery.Append(" where it.factory_cd = :factcd");

            if (inVo.InspectionItemCode != null)
            {
                sqlQuery.Append(" and UPPER(it.inspection_item_cd) like UPPER(:Insitemcd) ");
            }

            if (inVo.InspectionItemName != null)
            {
                sqlQuery.Append(" and UPPER(it.inspection_item_name) like UPPER(:Insitemname) ");
            }

            if (inVo.ParentInspectionItemId > 0)
            {
                sqlQuery.Append(" and it.parent_inspection_item_id = :parentinspectionitemid ");
            }
            if (inVo.InspectionProcessId > 0)
            {
                sqlQuery.Append(" and pr.inspection_process_id = :inspectionprocessid ");
            }
            sqlQuery.Append(" order by it.display_order");

            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sqlQuery.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            sqlParameter.AddParameterString("Insitemcd", inVo.InspectionItemCode + "%");
            sqlParameter.AddParameterString("Insitemname", inVo.InspectionItemName + "%");
            sqlParameter.AddParameterInteger("parentinspectionitemid", inVo.ParentInspectionItemId);
            sqlParameter.AddParameterInteger("inspectionprocessid", inVo.InspectionProcessId);
            sqlParameter.AddParameterString("factcd", UserData.GetUserData().FactoryCode);

            //execute SQL
            IDataReader dataReader = sqlCommandAdapter.ExecuteReader(trxContext, sqlParameter);

            ValueObjectList<InspectionItemVo> outVo = null;

            while (dataReader.Read())
            {
                InspectionItemVo currOutVo = new InspectionItemVo();

                currOutVo.InspectionProcessId = ConvertDBNull<int>(dataReader, "inspection_process_id");
                currOutVo.InspectionProcessName = ConvertDBNull<string>(dataReader, "inspection_process_name");
                currOutVo.InspectionItemName = ConvertDBNull<string>(dataReader, "inspection_item_name");
                currOutVo.InspectionItemCode = ConvertDBNull<string>(dataReader, "inspection_item_cd");
                currOutVo.InspectionItemMandatory = ConvertDBNull<int>(dataReader, "is_inspection_item_mandatory");
                currOutVo.InspectionEmployeeMandatory = ConvertDBNull<int>(dataReader, "is_inspection_employee_mandatory");
                currOutVo.InspectionMachineMandatory = ConvertDBNull<int>(dataReader, "is_inspection_machine_mandatory");
                currOutVo.InspectionItemId = ConvertDBNull<int>(dataReader, "inspection_item_id");
                currOutVo.ParentItemName = ConvertDBNull<string>(dataReader, "parentitemname");
                currOutVo.ParentInspectionItemId = ConvertDBNull<int>(dataReader, "parent_inspection_item_id");
                currOutVo.InspectionSpecificationId = ConvertDBNull<int>(dataReader, "inspection_specification_id");
                currOutVo.InspectionSpecificationCode = ConvertDBNull<string>(dataReader, "inspection_specification_cd");
                currOutVo.InspectionSpecificationText = ConvertDBNull<string>(dataReader, "inspection_specification_text");
                currOutVo.InspectionTestInstructionId = ConvertDBNull<int>(dataReader, "inspection_test_instruction_id");
                currOutVo.InspectionTestInstructionCode = ConvertDBNull<string>(dataReader, "inspection_test_instruction_cd");
                currOutVo.InspectionTestInstructionText = ConvertDBNull<string>(dataReader, "inspection_test_instruction_text");
                currOutVo.InspectionItemDataType = ConvertDBNull<int>(dataReader, "inspection_item_data_type");
                currOutVo.InspectionResultItemDecimalDigits = ConvertDBNull<int>(dataReader, "inspection_item_result_input_decimal_digits");
                currOutVo.InspectionTestInstructionDetailId = ConvertDBNull<int>(dataReader, "inspection_test_instruction_detail_id");
                currOutVo.DisplayOrder = ConvertDBNull<int>(dataReader, "display_order");

                if (outVo == null)
                {
                    outVo = new ValueObjectList<InspectionItemVo>();
                }
                outVo.add(currOutVo);
            }

            dataReader.Close();

            return outVo;
        }


    }
}
