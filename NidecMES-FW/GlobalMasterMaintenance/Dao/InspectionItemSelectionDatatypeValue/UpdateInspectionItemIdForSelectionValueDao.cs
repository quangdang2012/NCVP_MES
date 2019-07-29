using System.Text;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;
using System;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Dao
{
    public class UpdateInspectionItemIdForSelectionValueDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject arg)
        {
            InspectionItemSelectionDatatypeValueVo inVo = (InspectionItemSelectionDatatypeValueVo)arg;

            StringBuilder sqlQuery = new StringBuilder();

            sqlQuery.Append("Update m_inspection_item_selection_datatype_value");
            sqlQuery.Append(" Set inspection_item_id = :itemid ");
            sqlQuery.Append(" where factory_cd = :faccd ");
            sqlQuery.Append(" and UPPER(inspection_item_selection_datatype_value_cd)  like UPPER(:inspectionitemselectiondatatypevaluecd) ");
            sqlQuery.Append(" and inspection_item_id = 0 ;");

            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sqlQuery.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            sqlParameter.AddParameterString("faccd", UserData.GetUserData().FactoryCode);
            sqlParameter.AddParameterString("inspectionitemselectiondatatypevaluecd", inVo.InspectionItemCode + "%");
            sqlParameter.AddParameterInteger("itemid", inVo.InspectionItemId);

            UpdateResultVo outVo = new UpdateResultVo
            {
                AffectedCount = sqlCommandAdapter.ExecuteNonQuery(sqlParameter)
            };
            return outVo;
        }
    }
}
