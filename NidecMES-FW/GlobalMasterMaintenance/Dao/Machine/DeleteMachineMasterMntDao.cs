using System.Text;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Dao
{
    public class DeleteMachineMasterMntDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject arg)
        {
            MachineVo inVo = (MachineVo)arg;        

            StringBuilder sqlQuery = new StringBuilder();

            sqlQuery.Append("Delete From m_machine");
            sqlQuery.Append(" Where	");
            sqlQuery.Append(" machine_id = :machineid");
            sqlQuery.Append(" and factory_cd = :faccd ;");
            
            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sqlQuery.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            sqlParameter.AddParameterInteger("machineid", inVo.MachineId);
            sqlParameter.AddParameterString("faccd", UserData.GetUserData().FactoryCode);

            MachineVo outVo = new MachineVo { AffectedCount = sqlCommandAdapter.ExecuteNonQuery(sqlParameter)};

            return outVo;
        }
    }
}
