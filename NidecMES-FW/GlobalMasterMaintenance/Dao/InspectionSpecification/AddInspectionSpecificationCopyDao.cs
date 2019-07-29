using System.Text;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Dao
{
    class AddInspectionSpecificationCopyDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject arg)
        {
            
            ValueObjectList<InspectionSpecificationVo> inVo = (ValueObjectList<InspectionSpecificationVo>)arg;

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

            StringBuilder sqlValues = new StringBuilder();
            UserData userdata = trxContext.UserData;

            foreach (InspectionSpecificationVo getItemSpecificationVo in inVo.GetList())
            {
                if (sqlValues.Length > 0)
                {
                    sqlValues.Append(" , ");
                }

                sqlValues.Append(" (");

                sqlValues.Append("'" + getItemSpecificationVo.InspectionSpecificationCode + "' ,");
                sqlValues.Append("'" + getItemSpecificationVo.InspectionSpecificationText + "' ,");
                sqlValues.Append("'" + getItemSpecificationVo.ValueFrom + "' ,");
                if (getItemSpecificationVo.ValueTo == null)
                {
                    sqlValues.Append("NULL,");
                }
                else
                {
                    sqlValues.Append(getItemSpecificationVo.ValueTo + ",");
                }
                sqlValues.Append("'" + getItemSpecificationVo.Unit + "' ,");
                sqlValues.Append("'" + getItemSpecificationVo.OperatorFrom + "' ,");
                sqlValues.Append("'" + getItemSpecificationVo.OperatorTo + "' ,");
                sqlValues.Append(getItemSpecificationVo.InspectionItemId + ",");
                sqlValues.Append(getItemSpecificationVo.SpecificationResultJudgeType + ",");
                sqlValues.Append("'" + userdata.UserCode + "' ,");
                sqlValues.Append("'" + trxContext.ProcessingDBDateTime + "' ,");
                sqlValues.Append("'" + userdata.FactoryCode + "'");

                sqlValues.Append(" ) ");
            }
            
            sqlQuery.Append(sqlValues.ToString());


            //sqlQuery.Append(" ( ");
            //sqlQuery.Append(" :inspectionspecificationcd,");
            //sqlQuery.Append(" :inspectionspecificationtext,");
            //sqlQuery.Append(" :valuefrom,");
            //sqlQuery.Append(" :valueto,");
            //sqlQuery.Append(" :unit,");
            //sqlQuery.Append(" :operatorfrom,");
            //sqlQuery.Append(" :operatorto,");
            //sqlQuery.Append(" :inspectionitemid,");
            //sqlQuery.Append(" :specificationresultjudgetype,");
            //sqlQuery.Append(" :registrationusercode,");
            //sqlQuery.Append(" :regdatetime,");
            //sqlQuery.Append(" :factorycode");
            //sqlQuery.Append(" ); ");

            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sqlQuery.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
                        
            //sqlParameter.AddParameterString("inspectionspecificationcd", inVo.InspectionSpecificationCode);
            //sqlParameter.AddParameterString("inspectionspecificationtext", inVo.InspectionSpecificationText);
            //sqlParameter.AddParameterString("valuefrom", inVo.ValueFrom);
            //sqlParameter.AddParameter("valueto", inVo.ValueTo);
            //sqlParameter.AddParameterString("unit", inVo.Unit);
            //sqlParameter.AddParameterString("operatorfrom", inVo.OperatorFrom);
            //sqlParameter.AddParameterString("operatorto", inVo.OperatorTo);
            //sqlParameter.AddParameterInteger("inspectionitemid", inVo.InspectionItemId);
            //sqlParameter.AddParameterInteger("specificationresultjudgetype", inVo.SpecificationResultJudgeType);

            //UserData userdata = trxContext.UserData;

            //sqlParameter.AddParameterString("registrationusercode", userdata.UserCode);
            //sqlParameter.AddParameterDateTime("regdatetime", trxContext.ProcessingDBDateTime);
            //sqlParameter.AddParameterString("factorycode", userdata.FactoryCode);

            UpdateResultVo outVo = new UpdateResultVo { AffectedCount = sqlCommandAdapter.ExecuteNonQuery(sqlParameter) };

            return outVo;
        }
    }
}
