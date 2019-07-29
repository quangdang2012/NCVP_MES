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
    public class DeleteMachineEquipmentDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            MachineAndEquipmentVo inVo = (MachineAndEquipmentVo)vo;
            StringBuilder sql = new StringBuilder();
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, string.Empty);
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            sql.Append("delete from public.m_machine_equipment Where 1=1 ");

            if (inVo.MachineID > 0)
            {
                sql.Append(" and machine_id = :machine_id ");
                sqlParameter.AddParameterInteger("machine_id", inVo.MachineID);
            }
            if (inVo.EquipmentID > 0)
            {
                sql.Append(" and equipment_id = :equipment_id ");
                sqlParameter.AddParameterInteger("equipment_id", inVo.EquipmentID);
            }
            if (inVo.MachineAndEquipmentID > 0)
            {
                sql.Append(" and machine_equip_id = :machine_equip_id ");
                sqlParameter.AddParameterInteger("machine_equip_id", inVo.MachineAndEquipmentID);
            }




            //create command
            sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());


            //execute SQL

            MachineVo outVo = new MachineVo
            {
                AffectedCount = sqlCommandAdapter.ExecuteNonQuery(sqlParameter)
            };

            return outVo;
        }
    }
}
