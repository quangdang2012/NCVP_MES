using System.Text;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Dao
{
    public class AddEquipmentMasterMntDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject arg)
        {
            EquipmentVo inVo = (EquipmentVo)arg;

            StringBuilder sqlQuery = new StringBuilder();

            sqlQuery.Append("Insert into m_equipment");
            sqlQuery.Append(" ( ");
            sqlQuery.Append(" equipment_cd, ");
            sqlQuery.Append(" equipment_name, ");
            sqlQuery.Append(" instration_dt, ");
            sqlQuery.Append(" asset_no, ");
            sqlQuery.Append(" manufacturer, ");
            sqlQuery.Append(" model_name, ");
            sqlQuery.Append(" model_cd, ");
            sqlQuery.Append(" registration_user_cd, ");
            sqlQuery.Append(" registration_date_time, ");
            sqlQuery.Append(" factory_cd ");
            sqlQuery.Append(" ) ");
            sqlQuery.Append("VALUES	");
            sqlQuery.Append(" ( ");
            sqlQuery.Append(" :equipmentcd ,");
            sqlQuery.Append(" :equipmentname ,");
            sqlQuery.Append(" :instrationdt ,");
            sqlQuery.Append(" :assetno ,");
            sqlQuery.Append(" :manufacturer ,");
            sqlQuery.Append(" :modelname ,");
            sqlQuery.Append(" :modelcd ,");
            sqlQuery.Append(" :registrationusercd ,");
            sqlQuery.Append(" :registrationdt,");
            sqlQuery.Append(" :factorycd ");
            sqlQuery.Append(" ); ");

            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sqlQuery.ToString());

            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            sqlParameter.AddParameterString("equipmentcd", inVo.EquipmentCode);
            sqlParameter.AddParameterString("equipmentname", inVo.EquipmentName);
            sqlParameter.AddParameterDateTime("instrationdt", inVo.InstrationDate);
            sqlParameter.AddParameterString("assetno", inVo.AssetNo);
            sqlParameter.AddParameterString("manufacturer", inVo.Manufacturer);
            sqlParameter.AddParameterString("modelname", inVo.ModelName);
            sqlParameter.AddParameterString("modelcd", inVo.ModelCode);
            sqlParameter.AddParameterString("registrationusercd", inVo.RegistrationUserCode);
            sqlParameter.AddParameterDateTime("registrationdt", trxContext.ProcessingDBDateTime);
            sqlParameter.AddParameterString("factorycd", inVo.FactoryCode);

            EquipmentVo outVo = new EquipmentVo {AffectedCount = sqlCommandAdapter.ExecuteNonQuery(sqlParameter)};

            return outVo;
        }
    }
}
