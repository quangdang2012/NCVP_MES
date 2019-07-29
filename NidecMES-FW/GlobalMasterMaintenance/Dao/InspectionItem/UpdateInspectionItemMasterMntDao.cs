using System.Text;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;
using System;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Dao
{
    public class UpdateInspectionItemMasterMntDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject arg)
        {
            InspectionItemVo inVo = (InspectionItemVo)arg;

            StringBuilder sqlQuery = new StringBuilder();

            sqlQuery.Append("Update m_inspection_item");
            sqlQuery.Append(" Set ");
            sqlQuery.Append(" inspection_item_name = :inspectionitemname, ");
            sqlQuery.Append(" parent_inspection_item_id = :parentinspectionitemid, ");
            sqlQuery.Append(" inspection_item_result_input_decimal_digits = :inputdecimaldigits, ");
            sqlQuery.Append(" inspection_process_id = :inspectionprocessid, ");
            sqlQuery.Append(" is_inspection_item_mandatory = :inspectionitemmandatory, ");
            sqlQuery.Append(" is_inspection_employee_mandatory = :inspectionemployeemandatory, ");
            sqlQuery.Append(" is_inspection_machine_mandatory = :inspectionmachinemandatory, ");
            sqlQuery.Append(" inspection_item_data_type = :inspectionitemdatatype, ");
            sqlQuery.Append(" display_order = :displayorder ");
            sqlQuery.Append(" where factory_cd = :faccd ");
            sqlQuery.Append(" and inspection_item_id = :inspectionitemid ;");

            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sqlQuery.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            sqlParameter.AddParameterString("faccd", UserData.GetUserData().FactoryCode);
            sqlParameter.AddParameterString("inspectionitemname", inVo.InspectionItemName);

            if (inVo.ParentInspectionItemId > 0)
            {
                sqlParameter.AddParameterInteger("parentinspectionitemid", inVo.ParentInspectionItemId);
            }
            else
            {
                sqlParameter.AddParameter("parentinspectionitemid", DBNull.Value);
            }
            sqlParameter.AddParameterInteger("inspectionprocessid", inVo.InspectionProcessId);
            sqlParameter.AddParameterInteger("inspectionitemmandatory", inVo.InspectionItemMandatory);
            sqlParameter.AddParameterInteger("inspectionemployeemandatory", inVo.InspectionEmployeeMandatory);
            sqlParameter.AddParameterInteger("inspectionmachinemandatory", inVo.InspectionMachineMandatory);
            sqlParameter.AddParameterString("inspectionitemcd", inVo.InspectionItemCode);
            sqlParameter.AddParameterInteger("inspectionitemid", inVo.InspectionItemId);
            sqlParameter.AddParameterInteger("inspectionitemdatatype", inVo.InspectionItemDataType);
            sqlParameter.AddParameterInteger("inputdecimaldigits", inVo.InspectionResultItemDecimalDigits);
            sqlParameter.AddParameterInteger("displayorder", inVo.DisplayOrder);

            InspectionItemVo outVo = new InspectionItemVo
            {
                AffectedCount = sqlCommandAdapter.ExecuteNonQuery(sqlParameter)
            };
            return outVo;
        }
    }
}
