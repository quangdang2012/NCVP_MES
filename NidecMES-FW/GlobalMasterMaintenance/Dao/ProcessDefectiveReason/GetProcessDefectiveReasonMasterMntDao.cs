using System;
using System.Text;
using System.Data;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Dao
{
    public class GetProcessDefectiveReasonMasterMntDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject arg)
        {
            ProcessDefectiveReasonVo inVo = (ProcessDefectiveReasonVo)arg;

            StringBuilder sqlQuery = new StringBuilder();

            sqlQuery.Append("Select");
            sqlQuery.Append(" pwdr.process_work_defective_reason_id,");
            sqlQuery.Append(" pwdr.defective_reason_id,");
            sqlQuery.Append(" pwdr.process_work_id,");
            sqlQuery.Append(" df.defective_reason_name,");
            sqlQuery.Append(" pw.process_work_name");
            sqlQuery.Append(" from m_process_work_defective_reason pwdr");
            sqlQuery.Append(" inner join m_process_work pw on pwdr.process_work_id = pw.process_work_id");
            sqlQuery.Append(" inner join m_defective_reason df on pwdr.defective_reason_id = df.defective_reason_id");
            sqlQuery.Append(" where pwdr.factory_cd = :faccd ");

            if (inVo.DefectiveReasonId > 0)
            {
                sqlQuery.Append(" and pwdr.defective_reason_id = :dfrid");
            }

            if (inVo.ProcessWorkId > 0)
            {
                sqlQuery.Append(" and pwdr.process_work_id = :pwid");
            }
                        
            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sqlQuery.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            sqlParameter.AddParameterString("faccd", UserData.GetUserData().FactoryCode);
            if (inVo.DefectiveReasonId > 0)
            {
                sqlParameter.AddParameterInteger("dfrid", inVo.DefectiveReasonId);
            }

            if (inVo.ProcessWorkId > 0)
            {
                sqlParameter.AddParameterInteger("pwid", inVo.ProcessWorkId);
            }

            //execute SQL
            IDataReader dataReader = sqlCommandAdapter.ExecuteReader(trxContext, sqlParameter);

            ProcessDefectiveReasonVo outVo = new ProcessDefectiveReasonVo();

            while (dataReader.Read())
            {
                ProcessDefectiveReasonVo currOutVo = new ProcessDefectiveReasonVo
                {
                    ProcessWorkDefectiveReasonId = Convert.ToInt32(dataReader["process_work_defective_reason_id"]),
                    DefectiveReasonId = Convert.ToInt32(dataReader["defective_reason_id"]),
                    ProcessWorkId = Convert.ToInt32(dataReader["process_work_id"]),
                    ProcessWorkName = dataReader["process_work_name"].ToString(),
                    DefectiveReasonName = dataReader["defective_reason_name"].ToString()
                };

                outVo.ProcessDefectiveReasonListVo.Add(currOutVo);
            }

            dataReader.Close();

            return outVo;
        }
    }
}
