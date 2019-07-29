using System.Text;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Dao
{
    public class UpdateEquipmentMasterMntDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject arg)
        {
            EquipmentVo inVo = (EquipmentVo)arg;         

            StringBuilder sqlQuery = new StringBuilder();

            sqlQuery.Append("Update m_equipment");
            sqlQuery.Append(" Set ");
            sqlQuery.Append(" equipment_name = :equipmentname , ");
            sqlQuery.Append(" instration_dt = :instrationdt , ");
            sqlQuery.Append(" asset_no = :assetno , ");
            sqlQuery.Append(" manufacturer = :manufacturer , ");
            sqlQuery.Append(" model_name = :modelname , ");
            sqlQuery.Append(" model_cd = :modelcd  ");
            sqlQuery.Append(" Where	");
            sqlQuery.Append(" equipment_id = :equipmentid ");
            sqlQuery.Append(" and factory_cd = :faccd ;");
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sqlQuery.ToString());

            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            sqlParameter.AddParameterInteger("equipmentid", inVo.EquipmentId);
            sqlParameter.AddParameterString("equipmentname", inVo.EquipmentName);
            sqlParameter.AddParameterDateTime("instrationdt", inVo.InstrationDate);
            sqlParameter.AddParameterString("assetno", inVo.AssetNo);
            sqlParameter.AddParameterString("manufacturer", inVo.Manufacturer);
            sqlParameter.AddParameterString("modelname", inVo.ModelName);
            sqlParameter.AddParameterString("modelcd", inVo.ModelCode);
            sqlParameter.AddParameterString("faccd", UserData.GetUserData().FactoryCode);
            EquipmentVo outVo = new EquipmentVo {AffectedCount = sqlCommandAdapter.ExecuteNonQuery(sqlParameter)};

            return outVo;
        } 
    }
}
