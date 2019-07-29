using System.Text;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Dao
{
    class AddItemLineInspectionFormatMasterMntDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject arg)
        {

            ItemLineInspectionFormatVo inVo = (ItemLineInspectionFormatVo)arg;
            
            StringBuilder sqlQuery = new StringBuilder();

            sqlQuery.Append("Insert into m_item_line_inspection_format");
            sqlQuery.Append(" ( ");
            sqlQuery.Append(" sap_matnr_item_cd,");
            sqlQuery.Append(" line_id,");
            sqlQuery.Append(" inspection_format_id,");
            sqlQuery.Append(" registration_user_cd,");
            sqlQuery.Append(" registration_date_time,");
            sqlQuery.Append(" factory_cd");
            sqlQuery.Append(" ) ");
            sqlQuery.Append("VALUES	");
            sqlQuery.Append(" ( ");
            sqlQuery.Append(" :sapitemcd,");
            sqlQuery.Append(" :lineid,");
            sqlQuery.Append(" :inspectionformatid,");
            sqlQuery.Append(" :registrationusercode,");
            sqlQuery.Append(" :regdatetime,");
            sqlQuery.Append(" :factorycode");
            sqlQuery.Append(" ); ");

            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sqlQuery.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
                        
            sqlParameter.AddParameterString("sapitemcd", inVo.SapItemCode);
            sqlParameter.AddParameterInteger("lineid", inVo.LineId);
            sqlParameter.AddParameterInteger("inspectionformatid", inVo.InspectionFormatId);

            UserData userdata = trxContext.UserData;

            sqlParameter.AddParameterString("registrationusercode", userdata.UserCode);
            sqlParameter.AddParameterDateTime("regdatetime", trxContext.ProcessingDBDateTime);
            sqlParameter.AddParameterString("factorycode", userdata.FactoryCode);

            ItemLineInspectionFormatVo outVo = new ItemLineInspectionFormatVo { AffectedCount = sqlCommandAdapter.ExecuteNonQuery(sqlParameter) };

            return outVo;
        }
    }
}
