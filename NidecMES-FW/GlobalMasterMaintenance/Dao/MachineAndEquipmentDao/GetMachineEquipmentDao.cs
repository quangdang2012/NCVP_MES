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
    public class GetMachineEquipmentDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            MachineAndEquipmentVo inVo = (MachineAndEquipmentVo)vo;
            StringBuilder sql = new StringBuilder();
            ValueObjectList<MachineAndEquipmentVo> voList = new ValueObjectList<MachineAndEquipmentVo>();
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, string.Empty);
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            sql.Append("select machine_equip_id, machine_id, equipment_id from public.m_machine_equipment");
            sql.Append(" Where 1=1 ");

            //

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
            //DbCommandAdaptor 
            sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());

            //execute SQL
            IDataReader dataReader = sqlCommandAdapter.ExecuteReader(trxContext, sqlParameter);

            while (dataReader.Read())
            {
                MachineAndEquipmentVo outVo = new MachineAndEquipmentVo
                {
                    //convert
                    MachineAndEquipmentID = int.Parse(dataReader["machine_equip_id"].ToString()),
                    MachineID = int.Parse(dataReader["machine_id"].ToString()),
                    EquipmentID = int.Parse(dataReader["equipment_id"].ToString()),
                };
                voList.add(outVo);
            }
            dataReader.Close();
            return voList;
        }
    }
}
