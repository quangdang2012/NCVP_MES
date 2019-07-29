using System.Text;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;
using System.Data;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Dao
{
    public class AddInspectionFormatMasterMntDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject arg)
        {
            InspectionFormatVo inVo = (InspectionFormatVo)arg;

            StringBuilder sqlQuery = new StringBuilder();

            sqlQuery.Append("Insert into m_inspection_format");
            sqlQuery.Append(" ( ");
            sqlQuery.Append(" inspection_format_cd, ");
            sqlQuery.Append(" inspection_format_name, ");            
            sqlQuery.Append(" registration_user_cd, ");
            sqlQuery.Append(" registration_date_time, ");
            sqlQuery.Append(" is_deleted, ");
            sqlQuery.Append(" factory_cd ");
            sqlQuery.Append(" ) ");
            sqlQuery.Append("VALUES	");
            sqlQuery.Append(" ( ");
            sqlQuery.Append(" :inspectionformatcd ,");
            sqlQuery.Append(" :inspectionformatname ,");            
            sqlQuery.Append(" :registrationusercode ,");
            sqlQuery.Append(" :regdatetime ,");
            sqlQuery.Append(" :isdeleted, ");
            sqlQuery.Append(" :factorycode ");
            sqlQuery.Append(" ) ");
            sqlQuery.Append("RETURNING  inspection_format_id;");

            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sqlQuery.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            sqlParameter.AddParameterString("inspectionformatcd", inVo.InspectionFormatCode);
            sqlParameter.AddParameterString("inspectionformatname", inVo.InspectionFormatName);          

            UserData userdata = trxContext.UserData;

            sqlParameter.AddParameterString("registrationusercode", userdata.UserCode);
            sqlParameter.AddParameterDateTime("regdatetime", trxContext.ProcessingDBDateTime);
            sqlParameter.AddParameterString("factorycode", userdata.FactoryCode);
            sqlParameter.AddParameterString("isdeleted", GlobalMasterDataTypeEnum.FLAG_OFF.GetValue().ToString());

            IDataReader dataReader = sqlCommandAdapter.ExecuteReader(trxContext, sqlParameter);

            InspectionFormatVo outVo = null;

            while (dataReader.Read())
            {
                outVo = new InspectionFormatVo();
                outVo.InspectionFormatId = ConvertDBNull<int>(dataReader, "inspection_format_id");
            }
            dataReader.Close();           

            return outVo;
        }


 
    }
}
