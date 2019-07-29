using System.Text;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Vo;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Dao
{
    public class AddReportDownTimeDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            ReportDownTimeVo inVo = (ReportDownTimeVo)vo;
            StringBuilder sql = new StringBuilder();
            sql.Append(@"insert into t_downtime_report(time_from,time_to,prodution_work_content_id,line_id,model_id,process_name,process_work_id,
                machine_name,defective_reason_id,remarks,registration_user_cd,registration_date_time,factory_cd)");
            sql.Append(@" values(:time_from,:time_to,:prodution_work_content_id,:line_id,:model_id,:process_name,:process_work_id,
                :machine_name,:defective_reason_id,:remarks,:registration_user_cd,now(),:factory_cd)");

            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            sqlParameter.AddParameterInteger("downtime_report_id", inVo.DowntimeReportId);
            sqlParameter.AddParameterDateTime("time_to", inVo.TimeTo);
            sqlParameter.AddParameterDateTime("time_from", inVo.TimeFrom);
            sqlParameter.AddParameterString("remarks", inVo.Remakes);

            sqlParameter.AddParameterInteger("line_id", inVo.LineId);
            sqlParameter.AddParameterString("machine_name", inVo.MachineCode);
            sqlParameter.AddParameterInteger("model_id", inVo.ModelId);
            sqlParameter.AddParameterString("process_name", inVo.ProcessCode);
            sqlParameter.AddParameterInteger("process_work_id", inVo.ProcessWorkId);
            sqlParameter.AddParameterInteger("prodution_work_content_id", inVo.ProductionWorkContentId);
            sqlParameter.AddParameterInteger("defective_reason_id", inVo.DefectiveReasonId);

            sqlParameter.AddParameterString("registration_user_cd", inVo.RegistrationUserCode);
            sqlParameter.AddParameterString("factory_cd", inVo.FactoryCode);

            //execute SQL

            ReportDownTimeVo outVo = new ReportDownTimeVo
            {
                AffectedCount = sqlCommandAdapter.ExecuteNonQuery(sqlParameter)
            };

            return outVo;
        }
    }

}
