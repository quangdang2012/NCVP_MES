using System;
using System.Text;
using System.Data;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Dao
{
    class GetCastingMachineMasterMntDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject arg)
        {

            CastingMachineVo inVo = (CastingMachineVo)arg;

            CastingMachineVo outVo = new CastingMachineVo();

            StringBuilder sql = new StringBuilder();

            //create SQL
            sql.Append("select");
            sql.Append(" cm.casting_machine_id,");
            sql.Append(" cm.casting_machine_cd,");
            sql.Append(" cm.casting_machine_name,");
            sql.Append(" cmf.casting_machine_furnace_id,");
            sql.Append(" cmf.casting_machine_furnace_name,");
            sql.Append(" cm.equipment_id,");
            sql.Append(" eqp.equipment_name");
            sql.Append(" from m_casting_machine cm");
            sql.Append(" inner join m_casting_machine_furnace cmf");
            sql.Append(" on cm.casting_machine_furnace_id = cmf.casting_machine_furnace_id");
            sql.Append(" inner join m_equipment eqp");
            sql.Append(" on cm.equipment_id = eqp.equipment_id");

            sql.Append(FormCondition(inVo).ToString());

            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();

            if (!string.IsNullOrEmpty(inVo.FactoryCode))
            {
                sqlParameter.AddParameterString("faccd", inVo.FactoryCode);
            }
            else
            {
                sqlParameter.AddParameterString("faccd", UserData.GetUserData().FactoryCode);
            }
            

            if (inVo.CastingMachineCode != null)
            {
                sqlParameter.AddParameterString("castcode", inVo.CastingMachineCode + "%");
            }

            if (inVo.CastingMachineName != null)
            {
                sqlParameter.AddParameterString("castname", inVo.CastingMachineName + "%");
            }

            if (inVo.CastingMachineFurnaceId > 0)
            {
                sqlParameter.AddParameterInteger("castfurid", inVo.CastingMachineFurnaceId);
            }

            if (inVo.EquipmentId > 0)
            {
                sqlParameter.AddParameterInteger("eqpid", inVo.EquipmentId);
            }

            //execute SQL
            IDataReader dataReader = sqlCommandAdapter.ExecuteReader(trxContext, sqlParameter);

            while (dataReader.Read())
            {
                CastingMachineVo currOutVo = new CastingMachineVo
                {
                    CastingMachineId = Convert.ToInt32(dataReader["casting_machine_id"].ToString()),
                    CastingMachineCode = dataReader["casting_machine_cd"].ToString(),
                    CastingMachineName = dataReader["casting_machine_name"].ToString(),
                    CastingMachineFurnaceId = Convert.ToInt32(dataReader["casting_machine_furnace_id"].ToString()),
                    CastingMachineFurnaceName = dataReader["casting_machine_furnace_name"].ToString(),
                    EquipmentId = Convert.ToInt32(dataReader["equipment_id"].ToString()),
                    EquipmentName = dataReader["equipment_name"].ToString()
                };

                outVo.CastingMachineListVo.Add(currOutVo);
            }

            dataReader.Close();

            return outVo;
        }

        /// <summary>
        /// Creates seacrh condition as per user inputs 
        /// </summary>
        /// <returns>search condition</returns>
        private StringBuilder FormCondition(CastingMachineVo inVo)
        {

            StringBuilder searchCondition = new StringBuilder();

            searchCondition.Append(" where cm.factory_cd = :faccd ");

            if (inVo.CastingMachineCode != null)
            {
                searchCondition.Append(" and UPPER(cm.casting_machine_cd) like UPPER(:castcode)");
            }

            if (inVo.CastingMachineName != null)
            {
                searchCondition.Append(" and UPPER(cm.casting_machine_name) like UPPER(:castname)");
            }

            if (inVo.CastingMachineFurnaceId > 0)
            {
                searchCondition.Append(" and cmf.casting_machine_furnace_id = :castfurid");
            }

            if (inVo.EquipmentId > 0)
            {
                searchCondition.Append(" and cm.equipment_id = :eqpid");
            }

            searchCondition.Append(" order by cm.casting_machine_cd");

            return searchCondition;

        }
    }
}
