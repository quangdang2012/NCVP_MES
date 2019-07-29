using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Dao
{
    public class AddMachineEquipmentDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            MachineAndEquipmentVo inVo = (MachineAndEquipmentVo)vo;
            StringBuilder sql = new StringBuilder();
            sql.Append("insert into public.m_machine_equipment(machine_id,equipment_id) ");
            sql.Append("values(:machine_id,:equipment_id)");

            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());
            //
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            sqlParameter.AddParameterInteger("machine_id", inVo.MachineID);
            sqlParameter.AddParameterInteger("equipment_id", inVo.EquipmentID);

            //execute SQL

            MachineAndEquipmentVo outVo = new MachineAndEquipmentVo
            {
                AffectedCount = sqlCommandAdapter.ExecuteNonQuery(sqlParameter)
            };

            return outVo;
        }
    }
}
