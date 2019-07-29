using System;
using System.Text;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;
using System.Data;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Dao
{
    class CheckInspectionTestInstructionDetailMasterMntDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject arg)
        {

            InspectionTestInstructionVo inVo = (InspectionTestInstructionVo)arg;

            StringBuilder sql = new StringBuilder();

            //create SQL
            sql.Append("Select Count(*) as InspectionTestInstructionDetailCount from m_inspection_test_instruction_detail");
            sql.Append(" where factory_cd = :faccd ");

            if (inVo.InspectionTestInstructionDetailText != null)
            {
                sql.Append(" and UPPER(inspection_test_instruction_detail_text) = UPPER(:inspectiontestinstructiondetailtext)");
            }

            if (inVo.InspectionTestInstructionId > 0)
            {
                sql.Append(" and inspection_test_instruction_id = :inspectiontestinstructionid ");
            }

            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            sqlParameter.AddParameterString("faccd", UserData.GetUserData().FactoryCode);

            if (inVo.InspectionTestInstructionDetailText != null)
            {
                sqlParameter.AddParameterString("inspectiontestinstructiondetailtext", inVo.InspectionTestInstructionDetailText);
            }

            if (inVo.InspectionTestInstructionId > 0)
            {
                sqlParameter.AddParameterInteger("inspectiontestinstructionid", inVo.InspectionTestInstructionId);
            }

            //execute SQL
            IDataReader dataReader = sqlCommandAdapter.ExecuteReader(trxContext, sqlParameter);

            InspectionTestInstructionVo outVo = new InspectionTestInstructionVo { AffectedCount = 0 };

            while (dataReader.Read())
            {
                outVo.AffectedCount = Convert.ToInt32(dataReader["InspectionTestInstructionDetailCount"]);
            }

            dataReader.Close();

            return outVo;
        }
    }
}
