using System;
using System.Text;
using System.Data;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Dao
{
    public class CheckMachineMasterMntDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject arg)
        {
            MachineVo inVo = (MachineVo)arg;

            StringBuilder sqlQuery = new StringBuilder();

            sqlQuery.Append("Select Count(*) as MachineCount from m_machine ");
            sqlQuery.Append(" where factory_cd = :faccd ");

            if (inVo.MachineCode != null)
            {
                sqlQuery.Append(" and UPPER(machine_cd) = UPPER(:machinecd)");
            }
                        
            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sqlQuery.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();

            sqlParameter.AddParameterString("faccd", UserData.GetUserData().FactoryCode);

            if (inVo.MachineCode != null)
            {
                sqlParameter.AddParameterString("machinecd", inVo.MachineCode);
            }

            //execute SQL
            IDataReader dataReader = sqlCommandAdapter.ExecuteReader(trxContext, sqlParameter);

            MachineVo outVo = new MachineVo();

            while (dataReader.Read())
            {
                outVo.AffectedCount = Convert.ToInt32(dataReader["MachineCount"]);
            }

            dataReader.Close();

            return outVo;
        } 
    }
}
