using System;
using System.Text;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;
using System.Data;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Dao
{
    class CheckInspectionTestInstructionMasterMntDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject arg)
        {

            InspectionTestInstructionVo inVo = (InspectionTestInstructionVo)arg;

            StringBuilder sql = new StringBuilder();

            //create SQL
            sql.Append("Select Count(*) as InspectionTestInstructionCount from m_inspection_test_instruction");
            sql.Append(" where 1 = 1 ");

            if (inVo.InspectionTestInstructionCode != null && inVo.Mode != CommonConstants.MODE_UPDATE)
            {
                sql.Append(" and UPPER(inspection_test_instruction_cd) = UPPER(:inspectiontestinstructioncd)");
            }

            if (inVo.InspectionItemId > 0)
            {
                if (inVo.InspectionTestInstructionCode != null && inVo.Mode != CommonConstants.MODE_UPDATE)
                {
                    sql.Append(" or ( ");
                }
                else
                {
                    sql.Append(" and ( ");
                }
                if (inVo.InspectionTestInstructionId > 0 && inVo.Mode == CommonConstants.MODE_UPDATE)
                {
                    sql.Append(" inspection_test_instruction_id <> :inspectiontestinstructionid and ");
                }

                sql.Append(" inspection_item_id = :inspectionitemid and factory_cd = :faccd)");
            }

            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            sqlParameter.AddParameterString("faccd", UserData.GetUserData().FactoryCode);

            if (inVo.InspectionTestInstructionCode != null && inVo.Mode != CommonConstants.MODE_UPDATE)
            {
                sqlParameter.AddParameterString("inspectiontestinstructioncd", inVo.InspectionTestInstructionCode);
            }

            if (inVo.InspectionItemId > 0)
            {
                if (inVo.InspectionTestInstructionId > 0 && inVo.Mode == CommonConstants.MODE_UPDATE)
                {
                    sqlParameter.AddParameterInteger("inspectiontestinstructionid", inVo.InspectionTestInstructionId);
                }
                sqlParameter.AddParameterInteger("inspectionitemid", inVo.InspectionItemId);
            }

            //execute SQL
            IDataReader dataReader = sqlCommandAdapter.ExecuteReader(trxContext, sqlParameter);

            InspectionTestInstructionVo outVo = new InspectionTestInstructionVo { AffectedCount = 0 };

            while (dataReader.Read())
            {
                outVo.AffectedCount = Convert.ToInt32(dataReader["InspectionTestInstructionCount"]);
            }

            dataReader.Close();

            return outVo;
        }
    }
}
