using System.Text;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Vo;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Dao
{
    class AddJigRepairInformationDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            JigRepairInformationVo inVo = (JigRepairInformationVo)vo;
            StringBuilder sql = new StringBuilder();
            sql.Append(@"insert into t_jig_repair_info(jig_repair_cd, model_id, line_id, process_id, 
                           jig_cause_id, time_from, time_to, jig_current_status, jig_response_id, 
                           repair_result, jig_after_repair_status, place, registration_user_cd, 
                           registration_date_time, factory_cd)");
            sql.Append(@"values(:jig_repair_cd, :model_id, :line_id, :process_id, 
                       :jig_cause_id, :time_from, :time_to, :jig_current_status, :jig_response_id, 
                       :repair_result, :jig_after_repair_status, :place, :registration_user_cd, 
                       now(), :factory_cd)");

            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            sqlParameter.AddParameter("jig_repair_id", inVo.JigRepairId);
            sqlParameter.AddParameter("jig_repair_cd", inVo.JigRepairCode);
            sqlParameter.AddParameter("model_id", inVo.ModelId);
            sqlParameter.AddParameter("line_id", inVo.LineId);
            sqlParameter.AddParameter("process_id", inVo.ProcessId);
            sqlParameter.AddParameter("jig_cause_id", inVo.JigCauseId);
            sqlParameter.AddParameter("time_from", inVo.TimeFrom);
            sqlParameter.AddParameter("time_to", inVo.TimeTo);
            sqlParameter.AddParameter("jig_current_status", inVo.JigCurrentStatus);
            sqlParameter.AddParameter("jig_response_id", inVo.JigResponseId);
            sqlParameter.AddParameter("repair_result", inVo.JigRepairResult);
            sqlParameter.AddParameter("jig_after_repair_status", inVo.JigAfterRepairStatus);
            sqlParameter.AddParameter("place", inVo.JigPlace);
            sqlParameter.AddParameter("registration_user_cd", inVo.RegistrationUserCode);
            sqlParameter.AddParameter("factory_cd", inVo.FactoryCode);
            //execute SQL

            JigRepairInformationVo outVo = new JigRepairInformationVo
            {
                AffectedCount = sqlCommandAdapter.ExecuteNonQuery(sqlParameter)
            };

            return outVo;
        }
    }
}
