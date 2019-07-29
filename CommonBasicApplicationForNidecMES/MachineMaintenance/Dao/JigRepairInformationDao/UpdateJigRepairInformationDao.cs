using System.Text;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Vo;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Dao
{
    public class UpdateJigRepairInformationDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            JigRepairInformationVo inVo = (JigRepairInformationVo)vo;
            StringBuilder sql = new StringBuilder();
            sql.Append(@"update t_jig_repair_info set jig_repair_cd=:jig_repair_cd,
                                                        model_id=:model_id,
                                                        line_id=:line_id,
                                                        process_id=:process_id,
                                                        jig_cause_id=:jig_cause_id,
                                                        time_from=:time_from,
                                                        time_to=:time_to,
                                                        jig_current_status=:jig_current_status,
                                                        jig_response_id=:jig_response_id,
                                                        repair_result=:repair_result,
                                                        jig_after_repair_status=:jig_after_repair_status,
                                                        place=:place
                                                        ");
            sql.Append(" where jig_repair_id =:jig_repair_id");




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