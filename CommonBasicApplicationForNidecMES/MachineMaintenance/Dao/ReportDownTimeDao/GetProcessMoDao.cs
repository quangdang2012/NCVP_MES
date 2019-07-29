using System.Text;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Vo;

using System.Data;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Dao
{
    class GetProcessMoDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            ReportDownTimeVo inVo = (ReportDownTimeVo)vo;
            StringBuilder sql = new StringBuilder();
            ValueObjectList<ReportDownTimeVo> voList = new ValueObjectList<ReportDownTimeVo>();
            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            sql.Append("select a.process_name, c.machine_name from m_process a left join m_process_work b on b.process_id = a.process_id left join m_machine c on c.machine_id = b.machine_id");
            sql.Append(" where b.process_work_id = :process_work_id");

            sqlParameter.AddParameterInteger("process_work_id", inVo.ProcessWorkId);

            sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());

            //execute SQL
            IDataReader dataReader = sqlCommandAdapter.ExecuteReader(trxContext, sqlParameter);

            while (dataReader.Read())
            {
                ReportDownTimeVo outVo = new ReportDownTimeVo
                {
                     ProcessName = dataReader["process_name"].ToString(),
                     MachineName = dataReader["machine_name"].ToString()
                };
                voList.add(outVo);
            }
            dataReader.Close();
            return voList;
        }

    }

}
