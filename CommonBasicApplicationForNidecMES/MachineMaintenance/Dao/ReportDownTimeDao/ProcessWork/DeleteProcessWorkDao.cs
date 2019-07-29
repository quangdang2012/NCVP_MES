using System.Text;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.MachineMaintenance.Vo;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Dao
{
    public class DeleteProcessWorkDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject arg)
        {
            ProcessWorksVo inVo = (ProcessWorksVo)arg;         

            StringBuilder sqlQuery = new StringBuilder();

            sqlQuery.Append("Delete From m_process_work");
            sqlQuery.Append(" Where	");
            sqlQuery.Append(" process_work_id = :processworkid ;");

            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sqlQuery.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            sqlParameter.AddParameterInteger("processworkid", inVo.ProcessWorkId);

            ProcessWorksVo outVo = new ProcessWorksVo {AffectedCount = sqlCommandAdapter.ExecuteNonQuery(sqlParameter)};

            return outVo;
        }
    }
}
