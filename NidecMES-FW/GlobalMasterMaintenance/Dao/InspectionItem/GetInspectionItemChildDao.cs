using System.Text;
using System.Data;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Dao
{
    public class GetInspectionItemChildDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject arg)
        {
            InspectionItemVo inVo = (InspectionItemVo)arg;

            StringBuilder sqlQuery = new StringBuilder();

            //create SQL
            sqlQuery.Append(" Select * from m_inspection_item  ");
                        
            sqlQuery.Append(" where factory_cd = :factcd");

            if (inVo.InspectionItemCode != null)
            {
                sqlQuery.Append(" and UPPER(inspection_item_cd) like UPPER(:Insitemcd) ");
            }

            if (inVo.InspectionItemName != null)
            {
                sqlQuery.Append(" and UPPER(iinspection_item_name) like UPPER(:Insitemname) ");
            }

            if (inVo.ParentInspectionItemId > 0)
            {
                sqlQuery.Append(" and parent_inspection_item_id = :parentinspectionitemid ");
            }
            if (inVo.InspectionProcessId > 0)
            {
                sqlQuery.Append(" and inspection_process_id = :inspectionprocessid ");
            }
            sqlQuery.Append(" order by display_order");

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
                currOutVo.InspectionItemName = ConvertDBNull<string>(dataReader, "inspection_item_name");
                currOutVo.InspectionItemCode = ConvertDBNull<string>(dataReader, "inspection_item_cd");
                currOutVo.InspectionItemMandatory = ConvertDBNull<int>(dataReader, "is_inspection_item_mandatory");
                currOutVo.InspectionEmployeeMandatory = ConvertDBNull<int>(dataReader, "is_inspection_employee_mandatory");
                currOutVo.InspectionMachineMandatory = ConvertDBNull<int>(dataReader, "is_inspection_machine_mandatory");
                currOutVo.InspectionItemId = ConvertDBNull<int>(dataReader, "inspection_item_id");
                currOutVo.ParentInspectionItemId = ConvertDBNull<int>(dataReader, "parent_inspection_item_id");
                currOutVo.InspectionItemDataType = ConvertDBNull<int>(dataReader, "inspection_item_data_type");
                currOutVo.InspectionResultItemDecimalDigits = ConvertDBNull<int>(dataReader, "inspection_item_result_input_decimal_digits");
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
