using System;
using System.Text;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;
using System.Data;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Dao
{
    class CheckInspectionTestInstructionDetailResultCountDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject arg)
        {

            InspectionTestInstructionVo inVo = (InspectionTestInstructionVo)arg;

            StringBuilder sql = new StringBuilder();

            //create SQL
            sql.Append("Select inspection_test_instruction_detail_result_count from m_inspection_test_instruction_detail");
            sql.Append(" where factory_cd = :faccd ");

            if (inVo.InspectionTestInstructionId > 0)
            {
                sql.Append(" and inspection_test_instruction_id = :inspectiontestinstructionid ");
            }
                        
            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            sqlParameter.AddParameterString("faccd", UserData.GetUserData().FactoryCode);
            sqlParameter.AddParameterInteger("inspectiontestinstructionid", inVo.InspectionTestInstructionId);
                        
            //execute SQL
            IDataReader dataReader = sqlCommandAdapter.ExecuteReader(trxContext, sqlParameter);

            InspectionTestInstructionVo outVo = new InspectionTestInstructionVo { AffectedCount = 0 };

            while (dataReader.Read())
            {
                outVo.AffectedCount = Convert.ToInt32(dataReader["inspection_test_instruction_detail_result_count"]);
            }

            dataReader.Close();

            return outVo;
        }
    }
}
