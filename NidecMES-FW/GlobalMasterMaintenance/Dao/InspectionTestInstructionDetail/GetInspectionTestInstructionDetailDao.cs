using System;
using System.Text;
using System.Data;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;
using System.Collections.Generic;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Dao
{
    public class GetInspectionTestInstructionDetailDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject arg)
        {
            //InspectionTestInstructionVo inVo = (InspectionTestInstructionVo)arg;

            ValueObjectList<ValueObjectList<ValueObject>> inVo = (ValueObjectList<ValueObjectList<ValueObject>>)arg;
            List<int> InspectionTestInstructionList = new List<int>();

 
            foreach (ValueObjectList<ValueObject> getTestInstructionVo in inVo.GetList())
            {
                if ((((InspectionTestInstructionVo)getTestInstructionVo.GetList()[0]).InspectionTestInstructionId) != 0)
                {
                    InspectionTestInstructionList.Add(((InspectionTestInstructionVo)getTestInstructionVo.GetList()[0]).InspectionTestInstructionId);
                }
            }

            StringBuilder sqlQuery = new StringBuilder();

            sqlQuery.Append("select");
            sqlQuery.Append(" itinsth.inspection_test_instruction_id,");
            sqlQuery.Append(" itinsth.inspection_test_instruction_cd,");
            sqlQuery.Append(" itinsth.inspection_test_instruction_text,");
            sqlQuery.Append(" itinstd.inspection_test_instruction_detail_id,");
            sqlQuery.Append(" itinstd.inspection_test_instruction_detail_cd,");
            sqlQuery.Append(" itinstd.inspection_test_instruction_detail_text,");
            sqlQuery.Append(" itinstd.inspection_test_instruction_detail_result_count,");
            sqlQuery.Append(" itinstd.inspection_test_instruction_detail_machine_text");
            sqlQuery.Append(" from m_inspection_test_instruction itinsth");
            sqlQuery.Append(" inner join m_inspection_test_instruction_detail itinstd");
            sqlQuery.Append(" on itinstd.inspection_test_instruction_id = itinsth.inspection_test_instruction_id");
            sqlQuery.Append(" where itinsth.factory_cd = :faccd ");

            //if (inVo.InspectionTestInstructionDetailCode != null)
            //{
            //    sqlQuery.Append(" and itinstd.inspection_test_instruction_detail_cd like :inspectiontestinstructiondetailcd ");
            //}

            //if (inVo.InspectionTestInstructionDetailText != null)
            //{
            //    sqlQuery.Append(" and itinstd.inspection_test_instruction_detail_text like :inspectiontestinstructiondetailtext ");
            //}

            //if (inVo.InspectionTestInstructionId > 0)
            //{
            sqlQuery.Append(" and itinstd.inspection_test_instruction_id = ANY(:inspectiontestinstructionid) ");
            //}

            //if (inVo.InspectionTestInstructionDetailId > 0)
            //{
            //    sqlQuery.Append(" and itinstd.inspection_test_instruction_detail_id = :inspectiontestinstructiondetailid ");
            //}

            sqlQuery.Append(" order by itinstd.inspection_test_instruction_detail_cd");

            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sqlQuery.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            sqlParameter.AddParameterString("faccd", UserData.GetUserData().FactoryCode);

            //if (inVo.InspectionTestInstructionDetailCode != null)
            //{
            //    sqlParameter.AddParameterString("inspectiontestinstructiondetailcd", inVo.InspectionTestInstructionDetailCode + "%");
            //}

            //if (inVo.InspectionTestInstructionDetailText != null)
            //{
            //    sqlParameter.AddParameterString("inspectiontestinstructiondetailtext", inVo.InspectionTestInstructionDetailText + "%");
            //}

            //if (inVo.InspectionTestInstructionId > 0)
            //{
            sqlParameter.AddParameter("inspectiontestinstructionid", InspectionTestInstructionList);
            //}

            //if (inVo.InspectionTestInstructionDetailId > 0)
            //{
            //    sqlParameter.AddParameterInteger("inspectiontestinstructiondetailid", inVo.InspectionTestInstructionDetailId);
            //}

            //execute SQL
            IDataReader dataReader = sqlCommandAdapter.ExecuteReader(trxContext, sqlParameter);

            ValueObjectList<InspectionTestInstructionVo> outVo = null;

            while (dataReader.Read())

            {
                InspectionTestInstructionVo currOutVo = new InspectionTestInstructionVo();
                currOutVo.InspectionTestInstructionId = ConvertDBNull<int>(dataReader, "inspection_test_instruction_id");
                currOutVo.InspectionTestInstructionCode = ConvertDBNull<string>(dataReader, "inspection_test_instruction_cd");
                currOutVo.InspectionTestInstructionText = ConvertDBNull<string>(dataReader, "inspection_test_instruction_text");
                currOutVo.InspectionTestInstructionDetailId = ConvertDBNull<int>(dataReader, "inspection_test_instruction_detail_id");
                currOutVo.InspectionTestInstructionDetailCode = ConvertDBNull<string>(dataReader, "inspection_test_instruction_detail_cd");
                currOutVo.InspectionTestInstructionDetailText = ConvertDBNull<string>(dataReader, "inspection_test_instruction_detail_text");
                currOutVo.InspectionTestInstructionDetailResultCount = ConvertDBNull<int>(dataReader, "inspection_test_instruction_detail_result_count");
                currOutVo.InspectionTestInstructionDetailMachine = ConvertDBNull<string>(dataReader, "inspection_test_instruction_detail_machine_text");

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
