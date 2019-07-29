using System.Text;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Dao
{
    public class DeleteProcessWorkMoldMasterMntDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject arg)
        {
            ProcessWorkMoldVo inVo = (ProcessWorkMoldVo)arg;

            StringBuilder sqlQuery = new StringBuilder();

            sqlQuery.Append(" Delete From m_gtrs_process_work_mold");
            sqlQuery.Append(" Where	1 = 1 ");

            if(inVo.ProcessWorkId > 0)
            {
                sqlQuery.Append(" and process_work_id = :processworkid ");
            }

            if (inVo.MoldId > 0)
            {
                sqlQuery.Append(" and mold_id = :moldid ");
            }
            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sqlQuery.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();

            if (inVo.ProcessWorkId > 0)
            {
                sqlParameter.AddParameterInteger("processworkid", inVo.ProcessWorkId);
            }

            if (inVo.MoldId > 0)
            {
                sqlParameter.AddParameterInteger("moldid", inVo.MoldId);
            }

            ProcessWorkMoldVo outVo = new ProcessWorkMoldVo { AffectedCount = sqlCommandAdapter.ExecuteNonQuery(sqlParameter) };

            return outVo;

        }
    }
}
