using System;
using System.Text;
using System.Data;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Dao
{
    public class CheckEquipmentRelationDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject arg)
        {
            EquipmentVo inVo = (EquipmentVo)arg;

            EquipmentVo outVo = new EquipmentVo();

            StringBuilder sqlQuery = new StringBuilder();

            //create SQL
            sqlQuery.Append("select eq.equipment_cd, cmf.casting_machine_furnace_id as CastFurnaceId, ");
            sqlQuery.Append("  cm.casting_machine_id as CastingMachineId  from m_equipment eq  ");
            sqlQuery.Append(" left outer join m_casting_machine_furnace cmf on cmf.equipment_id = eq.equipment_id ");
            sqlQuery.Append(" left outer join m_casting_machine cm on cm.equipment_id = eq.equipment_id ");
            sqlQuery.Append(" where eq.factory_cd = :faccd ");

            if (inVo.EquipmentCode != null)
            {
                sqlQuery.Append(" and UPPER(equipment_cd) = UPPER(:equipmentcode) ");
            }

            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sqlQuery.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            sqlParameter.AddParameterString("faccd", UserData.GetUserData().FactoryCode);
            if (inVo.EquipmentCode != null)
            {
                sqlParameter.AddParameterString("equipmentcode", inVo.EquipmentCode);
            }

            //execute SQL
            IDataReader dataReader = sqlCommandAdapter.ExecuteReader(trxContext, sqlParameter);

            outVo.AffectedCount = 0;

            while (dataReader.Read())
            {
                outVo.CastingMachineFurnaceId = Convert.ToInt32("0" + dataReader["CastFurnaceId"]);
                outVo.CastingMachineId = Convert.ToInt32("0" + dataReader["CastingMachineId"]);
            }

            dataReader.Close();

            return outVo;
        }
    }
}
