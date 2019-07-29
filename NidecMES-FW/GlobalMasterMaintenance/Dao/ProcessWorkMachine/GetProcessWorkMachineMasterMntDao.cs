using System;
using System.Text;
using System.Data;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Dao
{
    public class GetProcessWorkMachineMasterMntDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject arg)
        {
            ProcessWorkMachineVo inVo = (ProcessWorkMachineVo)arg;

            StringBuilder sqlQuery = new StringBuilder();

            sqlQuery.Append("Select pwm.process_work_id, pwm.machine_id,ls.machine_cd,ls.machine_name");
            sqlQuery.Append(" from m_processwork_machine pwm ");
            sqlQuery.Append(" inner join m_machine ls on ls.machine_id = pwm.machine_id ");
            sqlQuery.Append(" where pwm.factory_cd = :faccd ");

            if (inVo.MachineId>0)
            {
                sqlQuery.Append(" and pwm.machine_id = :machineid ");
            }

            if (inVo.ProcessWorkId > 0)
            {
                sqlQuery.Append(" and pwm.process_work_id = :processworkid ");
            }
            if (inVo.MachineName != null)
            {
                sqlQuery.Append(" and machine_name like :machinename ");
            }
            if (inVo.MachineCode != null)
            {
                sqlQuery.Append(" and machine_cd like :machinecode ");
            }

            sqlQuery.Append(" order by machine_name ");

            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sqlQuery.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();

            if  (!string.IsNullOrEmpty(inVo.FactoryCode))
            {
                sqlParameter.AddParameterString("faccd", inVo.FactoryCode);
            }
            else
            {
                sqlParameter.AddParameterString("faccd", UserData.GetUserData().FactoryCode);
            }
            

            if (inVo.MachineId > 0)
            {
                sqlParameter.AddParameterInteger("machineid", inVo.MachineId);
            }

            if (inVo.ProcessWorkId > 0)
            {
                sqlParameter.AddParameterInteger("processworkid", inVo.ProcessWorkId);
            }

            if (inVo.MachineName != null)
            {
                sqlParameter.AddParameterString("machinename", inVo.MachineName + "%");
            }

            if (inVo.MachineCode != null)
            {
                sqlParameter.AddParameterString("machinecode", inVo.MachineCode + "%");
            }

            //execute SQL
            IDataReader dataReader = sqlCommandAdapter.ExecuteReader(trxContext, sqlParameter);

            ProcessWorkMachineVo outVo = new ProcessWorkMachineVo();

            while (dataReader.Read())
            {
                ProcessWorkMachineVo currOutVo = new ProcessWorkMachineVo
                {
                    MachineId = Convert.ToInt32(dataReader["machine_id"]),
                    MachineCode = dataReader["machine_cd"].ToString(),
                    ProcessWorkId = Convert.ToInt32(dataReader["process_work_id"]),
                    MachineName = dataReader["machine_name"].ToString(),
                };

                outVo.ProcessWorkMachineListVo.Add(currOutVo);

            }
            dataReader.Close();

            return outVo;
        } 
    }
}
