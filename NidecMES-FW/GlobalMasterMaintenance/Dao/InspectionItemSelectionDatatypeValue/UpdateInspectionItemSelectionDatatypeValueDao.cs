using System.Text;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;
using System;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Dao
{
    public class UpdateInspectionItemSelectionDatatypeValueDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject arg)
        {
            InspectionItemSelectionDatatypeValueVo inVo = (InspectionItemSelectionDatatypeValueVo)arg;

            StringBuilder sqlQuery = new StringBuilder();

            sqlQuery.Append("Update m_inspection_item_selection_datatype_value");
            sqlQuery.Append(" Set ");
            sqlQuery.Append(" inspection_item_selection_datatype_value_text = :datatypevaluetext, ");
            sqlQuery.Append(" display_order = :displayorder ");
            sqlQuery.Append(" where factory_cd = :faccd ");
            sqlQuery.Append(" and inspection_item_selection_datatype_value_id = :datatypeid ;");

            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sqlQuery.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            sqlParameter.AddParameterString("faccd", UserData.GetUserData().FactoryCode);
            sqlParameter.AddParameterInteger("datatypeid", inVo.InspectionItemSelectionDatatypeValueId);
            sqlParameter.AddParameterString("datatypevaluetext", inVo.InspectionItemSelectionDatatypeValueText);
            sqlParameter.AddParameterInteger("displayorder", inVo.DisplayOrder);

            UpdateResultVo outVo = new UpdateResultVo
            {
                AffectedCount = sqlCommandAdapter.ExecuteNonQuery(sqlParameter)
            };
            return outVo;
        }
    }
}
