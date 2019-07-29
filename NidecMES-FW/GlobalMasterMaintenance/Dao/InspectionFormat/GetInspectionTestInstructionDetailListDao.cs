using System;
using System.Text;
using System.Data;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;
using System.Collections.Generic;
using System.Linq;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Dao
{
    public class GetInspectionTestInstructionDetailListDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject arg)
        {
            ValueObjectList<InspectionTestInstructionVo> inspectionTestInstructionVo = (ValueObjectList<InspectionTestInstructionVo>)arg;

            List<int> inspectionTestInstructionId = inspectionTestInstructionVo.GetList().Select(v => v.InspectionTestInstructionId).Distinct().ToList();

            StringBuilder sqlQuery = new StringBuilder();

            sqlQuery.Append("select * ");
            sqlQuery.Append(" from m_inspection_test_instruction_detail");
            sqlQuery.Append(" where factory_cd = :faccd ");
            sqlQuery.Append(" and inspection_test_instruction_id = ANY(:inspectionTestInstructionId) ");

            sqlQuery.Append(" order by inspection_test_instruction_detail_id ");

            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sqlQuery.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            sqlParameter.AddParameterString("faccd", UserData.GetUserData().FactoryCode);
            sqlParameter.AddParameter("inspectionTestInstructionId", inspectionTestInstructionId);

            //execute SQL
            IDataReader dataReader = sqlCommandAdapter.ExecuteReader(trxContext, sqlParameter);

            ValueObjectList<InspectionTestInstructionVo> outVo = null;

            while (dataReader.Read())
            {
                InspectionTestInstructionVo currOutVo = new InspectionTestInstructionVo();

                currOutVo.InspectionTestInstructionDetailId = ConvertDBNull<int>(dataReader, "inspection_test_instruction_detail_id");
                currOutVo.InspectionTestInstructionDetailCode = ConvertDBNull<string>(dataReader, "inspection_test_instruction_detail_cd");
                currOutVo.InspectionTestInstructionDetailText = ConvertDBNull<string>(dataReader, "inspection_test_instruction_detail_text");
                currOutVo.InspectionTestInstructionDetailResultCount = ConvertDBNull<int>(dataReader, "inspection_test_instruction_detail_result_count");
                currOutVo.InspectionTestInstructionDetailMachine = ConvertDBNull<string>(dataReader, "inspection_test_instruction_detail_machine_text");
                currOutVo.InspectionTestInstructionId = ConvertDBNull<int>(dataReader, "inspection_test_instruction_id");

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
