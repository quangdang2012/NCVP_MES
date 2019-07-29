using System.Text;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Dao
{
    public class UpdateProcessMasterMntDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject arg)
        {
            ProcessVo inVo = (ProcessVo)arg;

            StringBuilder sqlQuery = new StringBuilder();

            sqlQuery.Append("Update m_process");
            sqlQuery.Append(" Set ");
            sqlQuery.Append(" process_name = :processname ");
            //sqlQuery.Append(" next_process_cd = :nextprocesscd ");
            sqlQuery.Append(" Where	");
            sqlQuery.Append(" process_id = :processid ");
            sqlQuery.Append(" and factory_cd = :factcd;");

            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sqlQuery.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            sqlParameter.AddParameterInteger("processid", inVo.ProcessId);
            sqlParameter.AddParameterString("processname", inVo.ProcessName);
            sqlParameter.AddParameterString("factcd", UserData.GetUserData().FactoryCode);
            //sqlParameter.AddParameterString("nextprocesscd", inVo.NextPocessCode);

            ProcessVo outVo = new ProcessVo {AffectedCount = sqlCommandAdapter.ExecuteNonQuery(sqlParameter)};

            return outVo;
        }
    }
}
