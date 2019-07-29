using System;
using System.Text;
using System.Data;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Dao
{
    public class GetInspectionTestInstructionMasterDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject arg)
        {
            InspectionTestInstructionVo inVo = (InspectionTestInstructionVo)arg;

            StringBuilder sqlQuery = new StringBuilder();

            sqlQuery.Append("select");
            sqlQuery.Append(" inspection_test_instruction_id,");
            sqlQuery.Append(" inspection_test_instruction_cd,");
            sqlQuery.Append(" inspection_test_instruction_text");
            sqlQuery.Append(" from m_inspection_test_instruction");
            sqlQuery.Append(" where factory_cd = :faccd ");

            if (inVo.InspectionTestInstructionCode != null)
            {
                sqlQuery.Append(" and inspection_test_instruction_cd like :inspectiontestinstructioncd ");
            }

            if (inVo.InspectionTestInstructionText != null)
            {
                sqlQuery.Append(" and inspection_test_instruction_text like :inspectiontestinstructiontext ");
            }

            if (inVo.InspectionTestInstructionId > 0)
            {
                sqlQuery.Append(" and inspection_test_instruction_id = :inspectiontestinstructionid ");
            }

            sqlQuery.Append(" order by inspection_test_instruction_cd ");

            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sqlQuery.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            sqlParameter.AddParameterString("faccd", UserData.GetUserData().FactoryCode);

            if (inVo.InspectionTestInstructionCode != null)
            {
                sqlParameter.AddParameterString("inspectiontestinstructioncd", inVo.InspectionTestInstructionCode + "%");
            }

            if (inVo.InspectionTestInstructionText != null)
            {
                sqlParameter.AddParameterString("inspectiontestinstructiontext", inVo.InspectionTestInstructionText + "%");
            }

            if (inVo.InspectionTestInstructionId > 0)
            {
                sqlParameter.AddParameterInteger("inspectiontestinstructionid", inVo.InspectionTestInstructionId);
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
