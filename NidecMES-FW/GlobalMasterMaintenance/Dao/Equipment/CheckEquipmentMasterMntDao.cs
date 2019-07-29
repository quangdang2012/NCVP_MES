using System;
using System.Text;
using System.Data;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Dao
{
    public class CheckEquipmentMasterMntDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject arg)
        {
            EquipmentVo inVo = (EquipmentVo)arg;

            EquipmentVo outVo = new EquipmentVo();

            StringBuilder sqlQuery = new StringBuilder();

            //create SQL
            sqlQuery.Append("Select Count(*) as EqpCount from m_equipment ");
            sqlQuery.Append(" where factory_cd = :faccd ");

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
                outVo.AffectedCount = Convert.ToInt32(dataReader["EqpCount"]);
            }

            dataReader.Close();

            return outVo;
        }
    }
}
