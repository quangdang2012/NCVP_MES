using System.Text;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Vo;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Dao
{
    public class UpdateReportDownTimeDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            ReportDownTimeVo inVo = (ReportDownTimeVo)vo;
            StringBuilder sql = new StringBuilder();
            sql.Append(@"update t_downtime_report set time_from=:time_from, time_to=:time_to, 
                prodution_work_content_id=:prodution_work_content_id, line_id=:line_id, model_id=:model_id, process_work_id=:process_work_id, process_name=:process_name, machine_name=:machine_name, defective_reason_id=:defective_reason_id, remarks=:remarks");
            sql.Append(" where downtime_report_id =:downtime_report_id");

            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            sqlParameter.AddParameterInteger("downtime_report_id", inVo.DowntimeReportId);
            sqlParameter.AddParameterDateTime("time_from", inVo.TimeFrom);
            sqlParameter.AddParameterDateTime("time_to", inVo.TimeTo);
            sqlParameter.AddParameterInteger("prodution_work_content_id", inVo.ProductionWorkContentId);
            sqlParameter.AddParameterInteger("line_id", inVo.LineId);
            sqlParameter.AddParameterInteger("model_id", inVo.ModelId);
            sqlParameter.AddParameterInteger("process_work_id", inVo.ProcessWorkId);
            sqlParameter.AddParameterString("process_name", inVo.ProcessCode);
            sqlParameter.AddParameterString("machine_name", inVo.MachineCode);         
            sqlParameter.AddParameterInteger("defective_reason_id", inVo.DefectiveReasonId);
            sqlParameter.AddParameterString("remarks", inVo.Remakes);
            //execute SQL

            ReportDownTimeVo outVo = new ReportDownTimeVo
            {
                AffectedCount = sqlCommandAdapter.ExecuteNonQuery(sqlParameter)
            };

            return outVo;
        }
    }
}