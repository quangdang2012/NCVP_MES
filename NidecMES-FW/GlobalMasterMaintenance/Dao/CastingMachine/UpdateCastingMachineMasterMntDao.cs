using System.Text;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Dao
{
    class UpdateCastingMachineMasterMntDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject arg)
        {
            CastingMachineVo inVo = (CastingMachineVo)arg;

            CastingMachineVo outVo = new CastingMachineVo();

            StringBuilder sqlQuery = new StringBuilder();
            sqlQuery.Append("Update m_casting_machine");
            sqlQuery.Append(" set ");
            sqlQuery.Append(" casting_machine_name = ");
            sqlQuery.Append(" :castname, ");
            sqlQuery.Append(" casting_machine_furnace_id = ");
            sqlQuery.Append(" :castfurid,");
            sqlQuery.Append(" equipment_id = ");
            sqlQuery.Append(" :eqpid ");
            sqlQuery.Append(" where");
            sqlQuery.Append(" casting_machine_id = ");
            sqlQuery.Append(" :castid");
            sqlQuery.Append(" and factory_cd = :faccd ;");
            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sqlQuery.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();

            sqlParameter.AddParameterInteger("castid", inVo.CastingMachineId);
            sqlParameter.AddParameterString("castname", inVo.CastingMachineName);
            sqlParameter.AddParameterInteger("castfurid", inVo.CastingMachineFurnaceId);
            sqlParameter.AddParameterInteger("eqpid", inVo.EquipmentId);
            sqlParameter.AddParameterString("faccd", UserData.GetUserData().FactoryCode);

            outVo.AffectedCount = sqlCommandAdapter.ExecuteNonQuery(sqlParameter);

            return outVo;
        }
    }
}
