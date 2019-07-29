using System.Text;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Dao
{
    class AddInspectionProcessMasterMntDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject arg)
        {

            InspectionProcessVo inVo = (InspectionProcessVo)arg;
            
            StringBuilder sqlQuery = new StringBuilder();

            sqlQuery.Append("Insert into m_inspection_process");
            sqlQuery.Append(" ( ");
            sqlQuery.Append(" inspection_process_cd,");
            sqlQuery.Append(" inspection_process_name,");
            sqlQuery.Append(" inspection_format_id,");
            sqlQuery.Append(" display_order,");
            sqlQuery.Append(" registration_user_cd,");
            sqlQuery.Append(" registration_date_time,");
            sqlQuery.Append(" factory_cd");
            sqlQuery.Append(" ) ");
            sqlQuery.Append("VALUES	");
            sqlQuery.Append(" ( ");
            sqlQuery.Append(" :inspectionprocesscd,");
            sqlQuery.Append(" :inspectionprocessname,");
            sqlQuery.Append(" :inspectionformatid,");
            sqlQuery.Append(" :displayorder,");
            sqlQuery.Append(" :registrationusercode,");
            sqlQuery.Append(" :regdatetime,");
            sqlQuery.Append(" :factorycode");
            sqlQuery.Append(" ) ");
            sqlQuery.Append(" RETURNING inspection_process_id;");

            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sqlQuery.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
                        
            sqlParameter.AddParameterString("inspectionprocesscd", inVo.InspectionProcessCode);
            sqlParameter.AddParameterString("inspectionprocessname", inVo.InspectionProcessName);
            sqlParameter.AddParameterInteger("inspectionformatid", inVo.InspectionFormatId);
            sqlParameter.AddParameterInteger("displayorder", inVo.DisplayOrder);

            UserData userdata = trxContext.UserData;

            sqlParameter.AddParameterString("registrationusercode", userdata.UserCode);
            sqlParameter.AddParameterDateTime("regdatetime", trxContext.ProcessingDBDateTime);
            sqlParameter.AddParameterString("factorycode", userdata.FactoryCode);

            InspectionProcessVo outVo = new InspectionProcessVo();
            outVo.InspectionProcessId = (int?)sqlCommandAdapter.ExecuteScalar(sqlParameter) ?? 0;            

            return outVo;
        }
    }
}
