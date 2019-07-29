using System.Text;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Dao
{
    public class DeleteProcessWorkMachineMasterMntDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject arg)
        {
            ProcessWorkMachineVo inVo = (ProcessWorkMachineVo)arg;

            StringBuilder sqlQuery = new StringBuilder();

            sqlQuery.Append("Delete from m_processwork_machine");
            sqlQuery.Append(" where factory_cd = :faccd ");
            
            if (inVo.ProcessWorkId > 0)
            {
                sqlQuery.Append(" AND process_work_id = :processworkid");
            }

            if (inVo.MachineId > 0)
            {
                sqlQuery.Append(" AND machine_id = :machineid");
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

            if (inVo.MachineId > 0)
            {
                sqlParameter.AddParameterInteger("machineid", inVo.MachineId);
            }

            ProcessWorkMachineVo outVo = new ProcessWorkMachineVo {AffectedCount = sqlCommandAdapter.ExecuteNonQuery(sqlParameter)};

            return outVo;
        }
    }
}
