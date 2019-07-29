using System.Text;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.MachineMaintenance.Vo;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Dao
{
    public class UpdateProcessWorkDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject arg)
        {
            ProcessWorksVo inVo = (ProcessWorksVo)arg;

            StringBuilder sqlQuery = new StringBuilder();

            sqlQuery.Append("Update m_process_work");
            sqlQuery.Append(" Set ");
            sqlQuery.Append(" process_work_name = :processworkname, ");
            sqlQuery.Append(" process_id = :processid, ");
            sqlQuery.Append(" model_id  = :modelid, ");
            sqlQuery.Append(" machine_id  = :machineid ");
            sqlQuery.Append(" Where	");
            sqlQuery.Append(" process_work_id = :processworkid ;");

            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sqlQuery.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            sqlParameter.AddParameterInteger("processworkid", inVo.ProcessWorkId);
            sqlParameter.AddParameterString("processworkname", inVo.ProcessWorkName);
            sqlParameter.AddParameterInteger("processid", inVo.AssyID);
            sqlParameter.AddParameterInteger("modelid", inVo.ModelID);
            sqlParameter.AddParameterInteger("machineid", inVo.MachineID);

            ProcessWorksVo outVo = new ProcessWorksVo {AffectedCount = sqlCommandAdapter.ExecuteNonQuery(sqlParameter)};

            return outVo;
        }
    }
}
