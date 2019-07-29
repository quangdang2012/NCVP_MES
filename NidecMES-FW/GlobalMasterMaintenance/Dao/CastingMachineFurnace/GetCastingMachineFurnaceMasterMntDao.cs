using System;
using System.Text;
using System.Data;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Dao
{
    class GetCastingMachineFurnaceMasterMntDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject arg)
        {

            CastingMachineFurnaceVo inVo = (CastingMachineFurnaceVo)arg;

            CastingMachineFurnaceVo outVo = new CastingMachineFurnaceVo();

            StringBuilder sqlQuery = new StringBuilder();

            //create SQL
            sqlQuery.Append("select");
            sqlQuery.Append(" cmf.casting_machine_furnace_id,");
            sqlQuery.Append(" cmf.casting_machine_furnace_cd,");
            sqlQuery.Append(" cmf.casting_machine_furnace_name,");
            sqlQuery.Append(" cmf.equipment_id,");
            sqlQuery.Append(" eqp.equipment_name");
            sqlQuery.Append(" from m_casting_machine_furnace cmf");
            sqlQuery.Append(" inner join m_equipment eqp on cmf.equipment_id = eqp.equipment_id");

            sqlQuery.Append(FormCondition(inVo));

            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sqlQuery.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            sqlParameter.AddParameterString("faccd", UserData.GetUserData().FactoryCode);
            if (inVo.CastingMachineFurnaceCode != null)
            {
                sqlParameter.AddParameterString("castfurcode", inVo.CastingMachineFurnaceCode + "%");
            }

            if (inVo.CastingMachineFurnaceName != null)
            {
                sqlParameter.AddParameterString("castfurname", inVo.CastingMachineFurnaceName + "%");
            }

            if (inVo.EquipmentId > 0)
            {
                sqlParameter.AddParameterInteger("eqpid", inVo.EquipmentId);
            }

            //execute SQL
            IDataReader dataReader = sqlCommandAdapter.ExecuteReader(trxContext, sqlParameter);

            while (dataReader.Read())
            {
                CastingMachineFurnaceVo currOutVo = new CastingMachineFurnaceVo
                {
                    CastingMachineFurnaceId = Convert.ToInt32(dataReader["casting_machine_furnace_id"].ToString()),
                    CastingMachineFurnaceCode = dataReader["casting_machine_furnace_cd"].ToString(),
                    CastingMachineFurnaceName = dataReader["casting_machine_furnace_name"].ToString(),
                    EquipmentId = Convert.ToInt32(dataReader["equipment_id"].ToString()),
                    EquipmentName = dataReader["equipment_name"].ToString()
                };

                outVo.CastingMachineFurnaceListVo.Add(currOutVo);
            }

            dataReader.Close();

            return outVo;
        }

        /// <summary>
        /// Creates seacrh condition as per user inputs 
        /// </summary>
        /// <returns>search condition</returns>
        private StringBuilder FormCondition(CastingMachineFurnaceVo inVo)
        {

            StringBuilder searchCondition = new StringBuilder();

            searchCondition.Append(" where cmf.factory_cd = :faccd ");

            if (inVo.CastingMachineFurnaceCode != null)
            {
                searchCondition.Append(" and UPPER(cmf.casting_machine_furnace_cd) like UPPER(:castfurcode)"); 
            }

            if (inVo.CastingMachineFurnaceName != null)
            {
                searchCondition.Append(" and UPPER(cmf.casting_machine_furnace_name) like UPPER(:castfurname)"); 
            }

            if (inVo.EquipmentId > 0)
            {
                searchCondition.Append(" and cmf.equipment_id = :eqpid");
            }

            searchCondition.Append(" order by cmf.casting_machine_furnace_cd");

            return searchCondition;

        }

    }
}
