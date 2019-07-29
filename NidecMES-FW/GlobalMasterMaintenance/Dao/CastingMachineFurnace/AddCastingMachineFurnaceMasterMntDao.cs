using System;
using System.Text;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Dao
{
    class AddCastingMachineFurnaceMasterMntDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject arg)
        {

            CastingMachineFurnaceVo inVo = (CastingMachineFurnaceVo)arg;

            CastingMachineFurnaceVo outVo = new CastingMachineFurnaceVo();

            StringBuilder sqlQuery = new StringBuilder();

            sqlQuery.Append("Insert into m_casting_machine_furnace");
            sqlQuery.Append(" ( ");
            sqlQuery.Append(" casting_machine_furnace_cd,");
            sqlQuery.Append(" casting_machine_furnace_name,");
            sqlQuery.Append(" equipment_id,");
            sqlQuery.Append(" registration_user_cd,");
            sqlQuery.Append(" registration_date_time,");
            sqlQuery.Append(" factory_cd");
            sqlQuery.Append(" ) ");
            sqlQuery.Append("VALUES	");
            sqlQuery.Append(" ( ");
            sqlQuery.Append(" :castfurcode,");
            sqlQuery.Append(" :castfurname,");
            sqlQuery.Append(" :eqpid,");
            sqlQuery.Append(" :regusercode,");
            sqlQuery.Append(" now(),");
            sqlQuery.Append(" :factcode");
            sqlQuery.Append(" ); ");

            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sqlQuery.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();

            sqlParameter.AddParameterString("castfurcode", inVo.CastingMachineFurnaceCode);
            sqlParameter.AddParameterString("castfurname", inVo.CastingMachineFurnaceName);
            sqlParameter.AddParameterInteger("eqpid", inVo.EquipmentId);
            sqlParameter.AddParameterString("regusercode", inVo.RegistrationUserCode);
            //sqlParameter.AddParameterDateTime("regdt", inVo.RegistrationDateTime);
            sqlParameter.AddParameterString("factcode", inVo.FactoryCode);

            outVo.AffectedCount = sqlCommandAdapter.ExecuteNonQuery(sqlParameter);

            return outVo;
        }
    }
}
