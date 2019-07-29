using System.Text;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;
using System;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Dao
{
    public class AddInspectionItemSelectionDatatypeValueDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject arg)
        {
            InspectionItemSelectionDatatypeValueVo inVo = (InspectionItemSelectionDatatypeValueVo)arg;

            StringBuilder sqlQuery = new StringBuilder();

            sqlQuery.Append("Insert into m_inspection_item_selection_datatype_value");
            sqlQuery.Append(" ( ");
            sqlQuery.Append(" inspection_item_selection_datatype_value_cd, ");
            sqlQuery.Append(" inspection_item_selection_datatype_value_text, ");
            sqlQuery.Append(" display_order,");
            sqlQuery.Append(" inspection_item_id, ");
            sqlQuery.Append(" registration_user_cd, ");
            sqlQuery.Append(" registration_date_time, ");
            sqlQuery.Append(" factory_cd ");
            sqlQuery.Append(" ) ");
            sqlQuery.Append("VALUES	");
            sqlQuery.Append(" ( ");
            sqlQuery.Append(" :datatypevaluecd ,");
            sqlQuery.Append(" :datatypevaluetext ,");
            sqlQuery.Append(" :displayorder,");
            sqlQuery.Append(" :itemid,");
            sqlQuery.Append(" :registrationusercode ,");
            sqlQuery.Append(" :registrationdatetime, ");
            sqlQuery.Append(" :factorycode ");
            sqlQuery.Append(" ); ");

            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sqlQuery.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            sqlParameter.AddParameterString("datatypevaluecd", inVo.InspectionItemSelectionDatatypeValueCode);
            sqlParameter.AddParameterString("datatypevaluetext", inVo.InspectionItemSelectionDatatypeValueText);
            sqlParameter.AddParameterInteger("displayorder", inVo.DisplayOrder);
            sqlParameter.AddParameterInteger("itemid", inVo.InspectionItemId);
            sqlParameter.AddParameterString("registrationusercode", UserData.GetUserData().UserCode);
            sqlParameter.AddParameterDateTime("registrationdatetime", trxContext.ProcessingDBDateTime);
            sqlParameter.AddParameterString("factorycode", UserData.GetUserData().FactoryCode);

            UpdateResultVo outVo = new UpdateResultVo
            {
                AffectedCount = sqlCommandAdapter.ExecuteNonQuery(sqlParameter)
            };

            return outVo;
        }
    }
}
