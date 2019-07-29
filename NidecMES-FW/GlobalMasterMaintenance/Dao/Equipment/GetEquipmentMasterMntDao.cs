using System;
using System.Text;
using System.Data;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Dao
{
    public class GetEquipmentMasterMntDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject arg)
        {
            EquipmentVo inVo = (EquipmentVo)arg;

            EquipmentVo outVo = new EquipmentVo();
          
            StringBuilder sqlQuery = new StringBuilder();

            //create SQL
            sqlQuery.Append("Select * from m_equipment ");
            sqlQuery.Append(" where factory_cd = :faccd ");

            if (inVo.EquipmentCode != null)
            {
                sqlQuery.Append(" and equipment_cd like :equipmentcode ");
            }

            if (inVo.EquipmentName != null)
            {
                sqlQuery.Append(" and equipment_name  like :equipmentname ");
            }

            if (inVo.InstrationDate != null && inVo.InstrationDate != DateTime.MinValue)
            {
                sqlQuery.Append(" and instration_dt = :instrationdt ");
            }

            if (inVo.AssetNo != null)
            {
                sqlQuery.Append(" and asset_no  like :assetno ");
            }

            if (inVo.Manufacturer != null)
            {
                sqlQuery.Append(" and manufacturer  like :manufacturer ");
            }

            if (inVo.ModelCode != null)
            {
                sqlQuery.Append(" and model_cd  like :modelcd ");
            }

            if (inVo.ModelName != null)
            {
                sqlQuery.Append(" and model_name  like :modelname ");
            }

            sqlQuery.Append(" order by equipment_cd ");

            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sqlQuery.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            sqlParameter.AddParameterString("faccd", UserData.GetUserData().FactoryCode);

            if (inVo.EquipmentCode != null)
            {
                sqlParameter.AddParameterString("equipmentcode", inVo.EquipmentCode + "%");
            }

            if (inVo.EquipmentName != null)
            {
                sqlParameter.AddParameterString("equipmentname", inVo.EquipmentName + "%");
            }

            if (inVo.InstrationDate != null)
            {
                sqlParameter.AddParameterDateTime("instrationdt", inVo.InstrationDate);
            }

            if (inVo.AssetNo != null)
            {
                sqlParameter.AddParameterString("assetno", inVo.AssetNo + "%");
            }

            if (inVo.Manufacturer != null)
            {
                sqlParameter.AddParameterString("manufacturer", inVo.Manufacturer + "%");
            }

            if (inVo.ModelCode != null)
            {
                sqlParameter.AddParameterString("modelcd", inVo.ModelCode + "%");
            }

            if (inVo.ModelName != null)
            {
                sqlParameter.AddParameterString("modelname", inVo.ModelName + "%");
            }
            //execute SQL
            IDataReader dataReader = sqlCommandAdapter.ExecuteReader(trxContext, sqlParameter);

            while (dataReader.Read())

            {
                EquipmentVo currOutVo = new EquipmentVo
                {
                    EquipmentId = ConvertDBNull<Int32>(dataReader,"equipment_id"),
                    EquipmentCode = ConvertDBNull<string>(dataReader,"equipment_cd"),
                    EquipmentName = ConvertDBNull<string>(dataReader, "equipment_name"),
                    InstrationDate = ConvertDBNull<DateTime>(dataReader,"instration_dt"),
                    AssetNo = ConvertDBNull<string>(dataReader, "asset_no"),
                    Manufacturer = ConvertDBNull<string>(dataReader, "manufacturer"),
                    ModelName = ConvertDBNull<string>(dataReader, "model_name"),
                    ModelCode = ConvertDBNull<string>(dataReader, "model_cd")
                };

                outVo.EquipmentListVo.Add(currOutVo);
            }

            dataReader.Close();

            return outVo;
        }
    }
}
