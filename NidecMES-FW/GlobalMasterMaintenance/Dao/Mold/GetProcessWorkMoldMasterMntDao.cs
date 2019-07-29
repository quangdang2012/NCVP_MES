using System;
using System.Text;
using System.Data;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Dao
{
    public class GetProcessWorkMoldMasterMntDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            ProcessWorkMoldVo inVo = (ProcessWorkMoldVo)vo;

            StringBuilder sqlQuery = new StringBuilder();

            sqlQuery.Append("Select");
            sqlQuery.Append(" pwm.process_work_mold_id,");
            sqlQuery.Append(" pwm.process_work_id,");
            sqlQuery.Append(" pwm.mold_id,");           
            sqlQuery.Append(" m.mold_name,");
            sqlQuery.Append(" pw.process_work_name");
            sqlQuery.Append(" from m_gtrs_process_work_mold pwm");           
            sqlQuery.Append(" inner join m_process_work pw on pwm.process_work_id = pw.process_work_id");
            sqlQuery.Append(" inner join m_mold m on pwm.mold_id = m.mold_id");
            sqlQuery.Append(" where 1 = 1 ");
            

            if (inVo.MoldId > 0)
            {
                sqlQuery.Append(" and pwm.mold_id = :moldid");
            }

            if (inVo.ProcessWorkId > 0)
            {
                sqlQuery.Append(" and pwm.process_work_id = :processworkid");
            }

            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sqlQuery.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();

            if (inVo.MoldId > 0)
            {
                sqlParameter.AddParameterInteger("moldid", inVo.MoldId);
            }
           
            if (inVo.ProcessWorkId > 0)
            {
                sqlParameter.AddParameterInteger("processworkid", inVo.ProcessWorkId);
            }
            //execute SQL
            IDataReader dataReader = sqlCommandAdapter.ExecuteReader(trxContext, sqlParameter);

            ProcessWorkMoldVo outVo = new ProcessWorkMoldVo();

            while (dataReader.Read())
            {
                ProcessWorkMoldVo currVo = new ProcessWorkMoldVo
                {
                    ProcessWorkId = Convert.ToInt32(DBDataCheckHelper.ConvertDBNullToStringNull(dataReader["process_work_id"])),
                    MoldId = Convert.ToInt32(dataReader["mold_id"]),
                    MoldName = dataReader["mold_name"].ToString(),
                    ProcessWorkName = dataReader["process_work_name"].ToString(),
                    ProcessWorkMoldId = Convert.ToInt32(dataReader["process_work_mold_id"]),

                };

                outVo.ProcessWorkMoldListVo.Add(currVo);
            }

            dataReader.Close();

            return outVo;
        }
    }
}
