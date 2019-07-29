using System.Text;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Dao
{
    public class UpdateInspectionSpecificationMasterMntDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject arg)
        {
            InspectionSpecificationVo inVo = (InspectionSpecificationVo)arg;

            StringBuilder sqlQuery = new StringBuilder();

            sqlQuery.Append("Update m_inspection_specification");
            sqlQuery.Append(" Set ");
            sqlQuery.Append(" inspection_specification_cd = :inspectionspecificationcd, ");
            sqlQuery.Append(" inspection_specification_text = :inspectionspecificationtext, ");
            sqlQuery.Append(" value_from = :valuefrom, ");
            sqlQuery.Append(" value_to = :valueto, ");
            sqlQuery.Append(" unit = :unit, ");
            sqlQuery.Append(" operator_from = :operatorform, ");
            sqlQuery.Append(" operator_to = :operatorto, ");
            sqlQuery.Append(" inspection_item_id = :inspectionitemid, ");
            sqlQuery.Append(" specification_result_judge_type = :specificationresultjudgetype ");
            sqlQuery.Append(" Where	");
            sqlQuery.Append(" inspection_specification_id = :inspectionspecificationid ");
            sqlQuery.Append(" and factory_cd = :faccd ;");
            

            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sqlQuery.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            sqlParameter.AddParameterInteger("inspectionspecificationid", inVo.InspectionSpecificationId);
            sqlParameter.AddParameterString("inspectionspecificationcd", inVo.InspectionSpecificationCode);
            sqlParameter.AddParameterString("inspectionspecificationtext", inVo.InspectionSpecificationText);
            sqlParameter.AddParameterString("valuefrom", inVo.ValueFrom);
            sqlParameter.AddParameter("valueto", inVo.ValueTo);
            sqlParameter.AddParameterString("unit", inVo.Unit);
            sqlParameter.AddParameterString("operatorform", inVo.OperatorFrom);
            sqlParameter.AddParameterString("operatorto", inVo.OperatorTo);
            sqlParameter.AddParameterInteger("inspectionitemid", inVo.InspectionItemId);
            sqlParameter.AddParameterInteger("specificationresultjudgetype", inVo.SpecificationResultJudgeType);
            sqlParameter.AddParameterString("faccd", UserData.GetUserData().FactoryCode);

            InspectionSpecificationVo outVo = new InspectionSpecificationVo { AffectedCount = sqlCommandAdapter.ExecuteNonQuery(sqlParameter)};

            return outVo;
        }

  


    }
}
