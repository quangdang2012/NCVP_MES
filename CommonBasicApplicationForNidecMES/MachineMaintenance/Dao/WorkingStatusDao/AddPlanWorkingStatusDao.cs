using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Vo;
using Com.Nidec.Mes.Framework;
using System.Text;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Dao
{
    public class AddPlanWorkingStatusDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            PlanWorkingStatusVo inVo = (PlanWorkingStatusVo)vo;
            StringBuilder sql = new StringBuilder();
            sql.Append("insert into t_plan_status_machine(plan_section, plan_datetime_add, total_no, plan_data_no, plan_data_div, registration_user_cd, registration_date_time, factory_cd) ");
            sql.Append("values(:plan_section, :plan_datetime_add, :total_no, :plan_data_no, :plan_data_div,  :registration_user_cd,now(), :factory_cd)");
            
            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            sqlParameter.AddParameterString("plan_section", inVo.PlanSection);
            sqlParameter.AddParameterDateTime("plan_datetime_add", inVo.DateTimeAdd);
            sqlParameter.AddParameterInteger("total_no", inVo.TotalNo);
            sqlParameter.AddParameterInteger("plan_data_no", inVo.PlanNo);
            sqlParameter.AddParameter("plan_data_div", inVo.Rate);
            sqlParameter.AddParameterDateTime("registration_date_time", inVo.RegistrationDateTime);
            sqlParameter.AddParameterString("factory_cd", inVo.FactoryCode);
            sqlParameter.AddParameterString("registration_user_cd", inVo.RegistrationUserCode);

            //execute SQL

            PlanWorkingStatusVo outVo = new PlanWorkingStatusVo
            {
                AffectedCount = sqlCommandAdapter.ExecuteNonQuery(sqlParameter)
            };

            return outVo;
        }
    }
}
