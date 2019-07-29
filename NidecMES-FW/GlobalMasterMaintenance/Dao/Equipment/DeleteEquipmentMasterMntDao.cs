using System.Text;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Dao
{
    public class DeleteEquipmentMasterMntDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject arg)
        {
            EquipmentVo inVo = (EquipmentVo)arg;

            StringBuilder sqlQuery = new StringBuilder();

            sqlQuery.Append("Delete From m_equipment");
            sqlQuery.Append(" Where	");
            sqlQuery.Append(" equipment_id = :equipmentid ");
            sqlQuery.Append(" and factory_cd = :faccd ;");
            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sqlQuery.ToString());

            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            sqlParameter.AddParameterInteger("equipmentid", inVo.EquipmentId);
            sqlParameter.AddParameterString("faccd", UserData.GetUserData().FactoryCode);
            EquipmentVo outVo = new EquipmentVo {AffectedCount = sqlCommandAdapter.ExecuteNonQuery(sqlParameter)};

            return outVo;
        }
    }
}
