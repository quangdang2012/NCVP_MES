using System.Text;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Dao
{
    public class DeleteProcessWorkMasterMntDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject arg)
        {
            ProcessWorkVo inVo = (ProcessWorkVo)arg;         

            StringBuilder sqlQuery = new StringBuilder();

            sqlQuery.Append("Delete From m_process_work");
            sqlQuery.Append(" Where	");
            sqlQuery.Append(" process_work_id = :processworkid ");
            sqlQuery.Append(" and factory_cd = :factcd ");

            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sqlQuery.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            sqlParameter.AddParameterInteger("processworkid", inVo.ProcessWorkId);
            sqlParameter.AddParameterString("factcd", UserData.GetUserData().FactoryCode);

            ProcessWorkVo outVo = new ProcessWorkVo {AffectedCount = sqlCommandAdapter.ExecuteNonQuery(sqlParameter)};

            return outVo;
        }
    }
}
