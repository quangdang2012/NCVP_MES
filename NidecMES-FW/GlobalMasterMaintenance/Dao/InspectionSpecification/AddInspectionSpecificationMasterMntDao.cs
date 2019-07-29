using System.Text;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Dao
{
    class AddInspectionSpecificationMasterMntDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject arg)
        {

            InspectionSpecificationVo inVo = (InspectionSpecificationVo)arg;
            
            StringBuilder sqlQuery = new StringBuilder();

            sqlQuery.Append("Insert into m_inspection_specification");
            sqlQuery.Append(" ( ");
            sqlQuery.Append(" inspection_specification_cd,");
            sqlQuery.Append(" inspection_specification_text,");
            sqlQuery.Append(" value_from,");
            sqlQuery.Append(" value_to,");
            sqlQuery.Append(" unit,");
            sqlQuery.Append(" operator_from,");
            sqlQuery.Append(" operator_to,");
            sqlQuery.Append(" inspection_item_id,");
            sqlQuery.Append(" specification_result_judge_type,");
            sqlQuery.Append(" registration_user_cd,");
            sqlQuery.Append(" registration_date_time,");
            sqlQuery.Append(" factory_cd");
            sqlQuery.Append(" ) ");
            sqlQuery.Append("VALUES	");
            sqlQuery.Append(" ( ");
            sqlQuery.Append(" :inspectionspecificationcd,");
            sqlQuery.Append(" :inspectionspecificationtext,");
            sqlQuery.Append(" :valuefrom,");
            sqlQuery.Append(" :valueto,");
            sqlQuery.Append(" :unit,");
            sqlQuery.Append(" :operatorfrom,");
            sqlQuery.Append(" :operatorto,");
            sqlQuery.Append(" :inspectionitemid,");
            sqlQuery.Append(" :specificationresultjudgetype,");
            sqlQuery.Append(" :registrationusercode,");
            sqlQuery.Append(" :regdatetime,");
            sqlQuery.Append(" :factorycode");
            sqlQuery.Append(" ); ");

            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sqlQuery.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
                        
            sqlParameter.AddParameterString("inspectionspecificationcd", inVo.InspectionSpecificationCode);
            sqlParameter.AddParameterString("inspectionspecificationtext", inVo.InspectionSpecificationText);
            sqlParameter.AddParameterString("valuefrom", inVo.ValueFrom);
            sqlParameter.AddParameter("valueto", inVo.ValueTo);
            sqlParameter.AddParameterString("unit", inVo.Unit);
            sqlParameter.AddParameterString("operatorfrom", inVo.OperatorFrom);
            sqlParameter.AddParameterString("operatorto", inVo.OperatorTo);
            sqlParameter.AddParameterInteger("inspectionitemid", inVo.InspectionItemId);
            sqlParameter.AddParameterInteger("specificationresultjudgetype", inVo.SpecificationResultJudgeType);

            UserData userdata = trxContext.UserData;

            sqlParameter.AddParameterString("registrationusercode", userdata.UserCode);
            sqlParameter.AddParameterDateTime("regdatetime", trxContext.ProcessingDBDateTime);
            sqlParameter.AddParameterString("factorycode", userdata.FactoryCode);

            UpdateResultVo outVo = new UpdateResultVo { AffectedCount = sqlCommandAdapter.ExecuteNonQuery(sqlParameter) };

            return outVo;
        }
    }
}
