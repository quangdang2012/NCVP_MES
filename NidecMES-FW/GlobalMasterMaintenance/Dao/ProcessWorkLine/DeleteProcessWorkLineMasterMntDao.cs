using System.Text;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Dao
{
    public class DeleteProcessWorkLineMasterMntDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject arg)
        {
            ProcessWorkLineVo inVo = (ProcessWorkLineVo)arg;

            StringBuilder sqlQuery = new StringBuilder();

            sqlQuery.Append("Delete from m_processwork_line");
            sqlQuery.Append(" where factory_cd = :faccd ");
            
            if (inVo.ProcessWorkId>0)
            {
                sqlQuery.Append(" AND process_work_id = :processworkid");
            }

            if (inVo.LineId > 0)
            {
                sqlQuery.Append(" AND line_id = :lineid");
            }


            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sqlQuery.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            sqlParameter.AddParameterString("faccd", UserData.GetUserData().FactoryCode);

            if (inVo.ProcessWorkId > 0)
            {
                sqlParameter.AddParameterInteger("processworkid", inVo.ProcessWorkId);
            }

            if (inVo.LineId > 0)
            {
                sqlParameter.AddParameterInteger("lineid", inVo.LineId);
            }

            ProcessWorkLineVo outVo = new ProcessWorkLineVo { AffectedCount = sqlCommandAdapter.ExecuteNonQuery(sqlParameter)};

            return outVo;
        }
    }
}
