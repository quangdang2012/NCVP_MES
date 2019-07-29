using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Vo;
using Com.Nidec.Mes.Framework;
using System.Data;
using System.Text;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Dao
{
    public class CallPlanDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            PlanWorkingStatusVo inVo = (PlanWorkingStatusVo)vo;
            StringBuilder sql = new StringBuilder();
            ValueObjectList<PlanWorkingStatusVo> voList = new ValueObjectList<PlanWorkingStatusVo>();
            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            sql.Append(@"select plan_section, total_no, plan_data_no, plan_data_div  from t_plan_status_machine  where plan_id in(select max(plan_id) from t_plan_status_machine group by plan_section) order by plan_section ");

            sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());

            //execute SQL
            IDataReader dataReader = sqlCommandAdapter.ExecuteReader(trxContext, sqlParameter);

            while (dataReader.Read())
            {
                PlanWorkingStatusVo outVo = new PlanWorkingStatusVo
                {

                    TotalNo = int.Parse(dataReader["total_no"].ToString()),
                    PlanNo = int.Parse(dataReader["plan_data_no"].ToString()),
                    Rate = double.Parse(dataReader["plan_data_div"].ToString()),
                    PlanSection = dataReader["plan_section"].ToString(),


                };
                voList.add(outVo);
            }
            dataReader.Close();
            return voList;
        }
    }
}
