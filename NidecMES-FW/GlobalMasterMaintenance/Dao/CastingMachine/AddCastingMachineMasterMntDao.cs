using System.Text;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Dao
{
    class AddCastingMachineMasterMntDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject arg)
        {

            CastingMachineVo inVo = (CastingMachineVo)arg;

            CastingMachineVo outVo = new CastingMachineVo();

            StringBuilder sqlQuery = new StringBuilder();

            sqlQuery.Append("Insert into m_casting_machine");
            sqlQuery.Append(" ( ");
            sqlQuery.Append(" casting_machine_cd,");
            sqlQuery.Append(" casting_machine_name,");
            sqlQuery.Append(" casting_machine_furnace_id,");
            sqlQuery.Append(" equipment_id,");
            sqlQuery.Append(" registration_user_cd,");
            sqlQuery.Append(" registration_date_time,");
            sqlQuery.Append(" factory_cd");
            sqlQuery.Append(" ) ");
            sqlQuery.Append("VALUES	");
            sqlQuery.Append(" ( ");
            sqlQuery.Append(" :castcode,");
            sqlQuery.Append(" :castname,");
            sqlQuery.Append(" :castfurid,");
            sqlQuery.Append(" :eqpid,");
            sqlQuery.Append(" :regusercode,");
            sqlQuery.Append(" now(),");
            sqlQuery.Append(" :factcode");
            sqlQuery.Append(" ); ");

            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sqlQuery.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
                        
            sqlParameter.AddParameterString("castcode", inVo.CastingMachineCode);
            sqlParameter.AddParameterString("castname", inVo.CastingMachineName);
            sqlParameter.AddParameterInteger("castfurid", inVo.CastingMachineFurnaceId);
            sqlParameter.AddParameterInteger("eqpid", inVo.EquipmentId);
            sqlParameter.AddParameterString("regusercode", inVo.RegistrationUserCode);
            //sqlParameter.AddParameterDateTime("regdt", inVo.RegistrationDateTime);
            sqlParameter.AddParameterString("factcode", inVo.FactoryCode);

            outVo.AffectedCount = sqlCommandAdapter.ExecuteNonQuery(sqlParameter);

            return outVo;
        }
    }
}
