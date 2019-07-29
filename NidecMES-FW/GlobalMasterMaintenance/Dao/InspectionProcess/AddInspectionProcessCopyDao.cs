using System.Text;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;
using System.Data;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Dao
{
    class AddInspectionProcessCopyDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject arg)
        {

            ValueObjectList<InspectionProcessVo> inVo = (ValueObjectList<InspectionProcessVo>)arg;

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
            //sqlQuery.Append(" ( Select");

            StringBuilder sqlValues = new StringBuilder();
            UserData userdata = trxContext.UserData;

            foreach (InspectionProcessVo getProcessVo in inVo.GetList())
            {
                if (sqlValues.Length > 0)
                {
                    sqlValues.Append(" , ");
                }

                sqlValues.Append(" (");

                sqlValues.Append( "'" + getProcessVo.InspectionProcessCode + "' ,");
                sqlValues.Append("'" + getProcessVo.InspectionProcessName + "' ,");
                sqlValues.Append( getProcessVo.InspectionFormatId + ",");
                sqlValues.Append( getProcessVo.DisplayOrder + ",");
                sqlValues.Append("'" + userdata.UserCode + "' ,");
                sqlValues.Append("'" + trxContext.ProcessingDBDateTime + "' ,");
                sqlValues.Append("'" + userdata.FactoryCode + "'");

                sqlValues.Append(" ) ");
            }

            sqlQuery.Append(sqlValues.ToString());

            //sqlQuery.Append(" ip.inspection_process_cd,");
            //sqlQuery.Append(" ip.inspection_process_name,");
            //sqlQuery.Append(" ip.inspection_format_id,");
            //sqlQuery.Append(" ip.display_order,");
            //sqlQuery.Append(" :registrationusercode,");
            //sqlQuery.Append(" :regdatetime,");
            //sqlQuery.Append(" :factorycode");
            //sqlQuery.Append(" from  ");
            //sqlQuery.Append(" m_inspection_process ip");
            //sqlQuery.Append(" where ip.inspection_format_id = :inspectionformatid");
            //sqlQuery.Append(" ) ");
            //sqlQuery.Append(" RETURNING inspection_process_id;");

            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sqlQuery.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();

            //sqlParameter.AddParameterString("inspectionprocesscd", inVo.InspectionProcessCode);
            //sqlParameter.AddParameterString("inspectionprocessname", inVo.InspectionProcessName);
            //sqlParameter.AddParameterInteger("inspectionformatid", inVo.InspectionFormatId);
            //sqlParameter.AddParameterInteger("displayorder", inVo.DisplayOrder);

            //UserData userdata = trxContext.UserData;

            //sqlParameter.AddParameterString("registrationusercode", userdata.UserCode);
            //sqlParameter.AddParameterDateTime("regdatetime", trxContext.ProcessingDBDateTime);
            //sqlParameter.AddParameterString("factorycode", userdata.FactoryCode);

            InspectionProcessVo outVo = new InspectionProcessVo();
            //int aa = (int?)sqlCommandAdapter.ExecuteScalar(sqlParameter) ?? 0;
            //execute SQL
            outVo.AffectedCount = sqlCommandAdapter.ExecuteNonQuery(sqlParameter);

            return outVo;
        }
    }
}
