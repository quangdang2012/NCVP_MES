using System;
using System.Text;
using System.Data;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Dao
{
    public class GetInspectionTestInstructionDetailSeqDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject arg)
        {
            InspectionTestInstructionVo inVo = (InspectionTestInstructionVo)arg;

            StringBuilder sqlQuery = new StringBuilder();

            sqlQuery.Append("select");
            sqlQuery.Append(" inspection_test_instruction_detail_cd");
            sqlQuery.Append(" from m_inspection_test_instruction_detail");
            sqlQuery.Append(" where factory_cd = :faccd ");
            sqlQuery.Append(" and inspection_test_instruction_id = :inspectiontestinstructionid ");
            sqlQuery.Append(" order by inspection_test_instruction_detail_id desc ");
            sqlQuery.Append(" limit 1 ");
            
            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sqlQuery.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            sqlParameter.AddParameterString("faccd", UserData.GetUserData().FactoryCode);
            sqlParameter.AddParameterInteger("inspectiontestinstructionid", inVo.InspectionTestInstructionId);
            
            //execute SQL
            IDataReader dataReader = sqlCommandAdapter.ExecuteReader(trxContext, sqlParameter);

            InspectionTestInstructionVo currOutVo = new InspectionTestInstructionVo();

            while (dataReader.Read())
            {
                currOutVo.InspectionTestInstructionDetailCode = ConvertDBNull<string>(dataReader, "inspection_test_instruction_detail_cd");                
            }
            dataReader.Close();

            return currOutVo;
        }
    }
}
