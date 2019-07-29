using System;
using System.Text;
using System.Data;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Dao
{
    public class GetInspectionTestInstructionMasterMntDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject arg)
        {
            InspectionTestInstructionVo inVo = (InspectionTestInstructionVo)arg;

            StringBuilder sqlQuery = new StringBuilder();

            sqlQuery.Append("select");
            sqlQuery.Append(" itinsth.inspection_test_instruction_id,");
            sqlQuery.Append(" itinsth.inspection_test_instruction_cd,");
            sqlQuery.Append(" itinsth.inspection_test_instruction_text,");
            sqlQuery.Append(" itinsth.inspection_item_id,");
            sqlQuery.Append(" iitm.inspection_item_name ");
            //sqlQuery.Append(" itinstd.inspection_test_instruction_detail_id,");
            //sqlQuery.Append(" itinstd.inspection_test_instruction_detail_cd,");
            //sqlQuery.Append(" itinstd.inspection_test_instruction_detail_text,");
            //sqlQuery.Append(" itinstd.inspection_test_instruction_detail_result_count");
            sqlQuery.Append(" from m_inspection_test_instruction itinsth");
            //sqlQuery.Append(" left join m_inspection_test_instruction_detail itinstd");
            //sqlQuery.Append(" on itinstd.inspection_test_instruction_id = itinsth.inspection_test_instruction_id");
            sqlQuery.Append(" inner join m_inspection_item iitm");
            sqlQuery.Append(" on iitm.inspection_item_id = itinsth.inspection_item_id");
            sqlQuery.Append(" where itinsth.factory_cd = :faccd ");

            if (inVo.InspectionTestInstructionDetailCode != null)
            {
                sqlQuery.Append(" and itinstd.inspection_test_instruction_detail_cd like :inspectiontestinstructiondetailcd ");
            }

            if (inVo.InspectionTestInstructionDetailText != null)
            {
                sqlQuery.Append(" and itinstd.inspection_test_instruction_detail_text like :inspectiontestinstructiondetailtext ");
            }

            if (inVo.InspectionItemId > 0)
            {
                sqlQuery.Append(" and itinsth.inspection_item_id = :inspectionitemid ");
            }

            sqlQuery.Append(" order by itinsth.inspection_test_instruction_cd ");

            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sqlQuery.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            sqlParameter.AddParameterString("faccd", UserData.GetUserData().FactoryCode);

            if (inVo.InspectionTestInstructionDetailCode != null)
            {
                sqlParameter.AddParameterString("inspection_test_instruction_detail_cd", inVo.InspectionTestInstructionDetailCode + "%");
            }

            if (inVo.InspectionTestInstructionDetailText != null)
            {
                sqlParameter.AddParameterString("inspectiontestinstructiondetailtext", inVo.InspectionTestInstructionDetailText + "%");
            }

            if (inVo.InspectionItemId > 0)
            {
                sqlParameter.AddParameterInteger("inspectionitemid", inVo.InspectionItemId);
            }

            //execute SQL
            IDataReader dataReader = sqlCommandAdapter.ExecuteReader(trxContext, sqlParameter);

            ValueObjectList<InspectionTestInstructionVo> outVo = null;

            while (dataReader.Read())

            {
                InspectionTestInstructionVo currOutVo = new InspectionTestInstructionVo();
                currOutVo.InspectionTestInstructionId = ConvertDBNull<Int32>(dataReader, "inspection_test_instruction_id");
                currOutVo.InspectionTestInstructionCode = ConvertDBNull<string>(dataReader, "inspection_test_instruction_cd");
                currOutVo.InspectionTestInstructionText = ConvertDBNull<string>(dataReader, "inspection_test_instruction_text");
                currOutVo.InspectionItemId = ConvertDBNull<Int32>(dataReader, "inspection_item_id");
                currOutVo.InspectionItemName = ConvertDBNull<string>(dataReader, "inspection_item_name");
                //currOutVo.InspectionTestInstructionDetailId = ConvertDBNull<Int32>(dataReader, "inspection_test_instruction_detail_id");
                //currOutVo.InspectionTestInstructionDetailCode = ConvertDBNull<string>(dataReader, "inspection_test_instruction_detail_cd");
                //currOutVo.InspectionTestInstructionDetailText = ConvertDBNull<string>(dataReader, "inspection_test_instruction_detail_text");
                //currOutVo.InspectionTestInstructionDetailResultCount = ConvertDBNull<Int32>(dataReader, "inspection_test_instruction_detail_result_count");
                
                if (outVo == null)
                {
                    outVo = new ValueObjectList<InspectionTestInstructionVo>();
                }
                outVo.add(currOutVo);
            }
            dataReader.Close();

            return outVo;
        }
    }
}
