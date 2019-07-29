using System.Text;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;
using System;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Dao
{
    public class AddInspectionItemSelectionDatatypeValueCopyDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject arg)
        {
            ValueObjectList<InspectionItemSelectionDatatypeValueVo> inVo = (ValueObjectList<InspectionItemSelectionDatatypeValueVo>)arg;

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

            StringBuilder sqlValues = new StringBuilder();
            UserData userdata = trxContext.UserData;

            foreach (InspectionItemSelectionDatatypeValueVo getItemSelectionVo in inVo.GetList())
            {
                if (sqlValues.Length > 0)
                {
                    sqlValues.Append(" , ");
                }

                sqlValues.Append(" (");

                sqlValues.Append("'" + getItemSelectionVo.InspectionItemSelectionDatatypeValueCode + "' ,");
                sqlValues.Append("'" + getItemSelectionVo.InspectionItemSelectionDatatypeValueText + "' ,");
                sqlValues.Append(getItemSelectionVo.DisplayOrder + ",");
                sqlValues.Append(getItemSelectionVo.InspectionItemId + ",");
                sqlValues.Append("'" + userdata.UserCode + "' ,");
                sqlValues.Append("'" + trxContext.ProcessingDBDateTime + "' ,");
                sqlValues.Append("'" + userdata.FactoryCode + "'");

                sqlValues.Append(" ) ");
            }

            sqlQuery.Append(sqlValues.ToString());

            //sqlQuery.Append(" ( ");
            //sqlQuery.Append(" :datatypevaluecd ,");
            //sqlQuery.Append(" :datatypevaluetext ,");
            //sqlQuery.Append(" :displayorder,");
            //sqlQuery.Append(" :itemid,");
            //sqlQuery.Append(" :registrationusercode ,");
            //sqlQuery.Append(" :registrationdatetime, ");
            //sqlQuery.Append(" :factorycode ");
            //sqlQuery.Append(" ); ");

            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sqlQuery.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            //sqlParameter.AddParameterString("datatypevaluecd", inVo.InspectionItemSelectionDatatypeValueCode);
            //sqlParameter.AddParameterString("datatypevaluetext", inVo.InspectionItemSelectionDatatypeValueText);
            //sqlParameter.AddParameterInteger("displayorder", inVo.DisplayOrder);
            //sqlParameter.AddParameterInteger("itemid", inVo.InspectionItemId);
            //sqlParameter.AddParameterString("registrationusercode", UserData.GetUserData().UserCode);
            //sqlParameter.AddParameterDateTime("registrationdatetime", trxContext.ProcessingDBDateTime);
            //sqlParameter.AddParameterString("factorycode", UserData.GetUserData().FactoryCode);

            UpdateResultVo outVo = new UpdateResultVo
            {
                AffectedCount = sqlCommandAdapter.ExecuteNonQuery(sqlParameter)
            };

            return outVo;
        }
    }
}
