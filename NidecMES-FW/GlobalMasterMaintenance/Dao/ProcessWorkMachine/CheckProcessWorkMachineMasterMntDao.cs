using System;
using System.Text;
using System.Data;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Dao
{
    public class CheckProcessWorkMachineMasterMntDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject arg)
        {
            ProcessWorkMachineVo inVo = (ProcessWorkMachineVo)arg;

            StringBuilder sqlQuery = new StringBuilder();

            sqlQuery.Append("Select Count(*) as WorkCount from m_processwork_machine");
            sqlQuery.Append(" where factory_cd = :faccd ");

            if (inVo.MachineId >=0)
            {
                sqlQuery.Append(" and machine_id = :machineid");
            }
           
            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sqlQuery.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            sqlParameter.AddParameterString("faccd", UserData.GetUserData().FactoryCode);

            if (inVo.MachineId >= 0)
            {
                sqlParameter.AddParameterInteger("machineid", inVo.MachineId);
            }

            //execute SQL
            IDataReader dataReader = sqlCommandAdapter.ExecuteReader(trxContext, sqlParameter);

            ProcessWorkMachineVo outVo = new ProcessWorkMachineVo();

            while (dataReader.Read())
            {
                outVo.AffectedCount = Convert.ToInt32(dataReader["WorkCount"]);
            }

            dataReader.Close();

            return outVo;
        }
    }
}
