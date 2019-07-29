using System;
using System.Text;
using System.Data;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Dao
{
    public class GetInspectionSpecificationMasterMntDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject arg)
        {
            InspectionSpecificationVo inVo = (InspectionSpecificationVo)arg;

            StringBuilder sqlQuery = new StringBuilder();

            sqlQuery.Append(" select");
            sqlQuery.Append(" ispec.inspection_specification_id,");
            sqlQuery.Append(" ispec.inspection_specification_cd,");
            sqlQuery.Append(" ispec.inspection_specification_text,");
            sqlQuery.Append(" ispec.value_from,");
            sqlQuery.Append(" ispec.value_to,");
            sqlQuery.Append(" ispec.unit,");
            sqlQuery.Append(" ispec.operator_from,");
            sqlQuery.Append(" ispec.operator_to,");
            sqlQuery.Append(" iitm.inspection_item_id,");
            sqlQuery.Append(" iitm.inspection_item_name, ");
            sqlQuery.Append(" ispec.specification_result_judge_type, ");
            sqlQuery.Append(" case ispec.specification_result_judge_type ");
            sqlQuery.Append(" when 1 then 'AUTO' when 2 then 'MANUAL' ");
            sqlQuery.Append(" end as specificationresultjudgetype");
            sqlQuery.Append(" from m_inspection_specification ispec");
            sqlQuery.Append(" inner join m_inspection_item iitm");
            sqlQuery.Append(" on iitm.inspection_item_id = ispec.inspection_item_id");
            sqlQuery.Append(" where ispec.factory_cd = :faccd ");

            if (inVo.InspectionSpecificationCode != null)
            {
                sqlQuery.Append(" and ispec.inspection_specification_cd like :inspectionspecificationcd ");
            }

            if (inVo.InspectionSpecificationText != null)
            {
                sqlQuery.Append(" and ispec.inspection_specification_text like :inspectionspecificationtext ");
            }

            if (inVo.InspectionItemId > 0)
            {
                sqlQuery.Append(" and ispec.inspection_item_id = :inspectionitemid ");
            }

            sqlQuery.Append(" order by ispec.inspection_specification_cd ");

            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sqlQuery.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            sqlParameter.AddParameterString("faccd", UserData.GetUserData().FactoryCode);
            sqlParameter.AddParameterString("inspectionspecificationcd", inVo.InspectionSpecificationCode + "%");
            sqlParameter.AddParameterString("inspectionspecificationtext", inVo.InspectionSpecificationText + "%");
            sqlParameter.AddParameterInteger("inspectionitemid", inVo.InspectionItemId);

            //execute SQL
            IDataReader dataReader = sqlCommandAdapter.ExecuteReader(trxContext, sqlParameter);

            ValueObjectList<InspectionSpecificationVo> outVo = null;

            while (dataReader.Read())

            {

                InspectionSpecificationVo currOutVo = new InspectionSpecificationVo();
                currOutVo.InspectionSpecificationId = ConvertDBNull<int>(dataReader, "inspection_specification_id");
                currOutVo.InspectionSpecificationCode = ConvertDBNull<string>(dataReader, "inspection_specification_cd");
                currOutVo.InspectionSpecificationText = ConvertDBNull<string>(dataReader, "inspection_specification_text");
                currOutVo.ValueFrom = ConvertDBNull<string>(dataReader, "value_from");
                currOutVo.ValueTo = ConvertDBNull<string>(dataReader, "value_to");
                currOutVo.Unit = ConvertDBNull<string>(dataReader, "unit");
                currOutVo.OperatorFrom = ConvertDBNull<string>(dataReader, "operator_from");
                currOutVo.OperatorTo = ConvertDBNull<string>(dataReader, "operator_to");
                currOutVo.InspectionItemId = ConvertDBNull<int>(dataReader, "inspection_item_id");
                currOutVo.InspectionItemName = ConvertDBNull<string>(dataReader, "inspection_item_name");
                currOutVo.SpecificationResultJudgeType = ConvertDBNull<int>(dataReader, "specification_result_judge_type");
                currOutVo.SpecificationResultJudgeTypeMode = ConvertDBNull<string>(dataReader, "specificationresultjudgetype");

                if (outVo == null)
                {
                    outVo = new ValueObjectList<InspectionSpecificationVo>();
                }
                outVo.add(currOutVo);
            }
            dataReader.Close();

            return outVo;
        }
    }
}
