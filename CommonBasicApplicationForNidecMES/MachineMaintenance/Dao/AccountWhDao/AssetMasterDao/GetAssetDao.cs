using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Vo.AccountWhVo;
using Com.Nidec.Mes.Framework;
using System;
using System.Data;
using System.Text;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Dao
{
    public class GetAssetDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            AssetVo inVo = (AssetVo)vo;
            StringBuilder sql = new StringBuilder();
            ValueObjectList<AssetVo> voList = new ValueObjectList<AssetVo>();
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, string.Empty);
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            sql.Append("select asset_id,asset_no,asset_cd,asset_name, asset_model,  asset_supplier, asset_type, asset_serial, asset_invoice, asset_life, acquistion_date, acquistion_cost, registration_user_cd,registration_date_time,factory_cd, label_status, asset_po from m_asset");
            sql.Append(" Where 1=1 ");
            if (!String.IsNullOrEmpty(inVo.FactoryCode))
            {
                sql.Append(" and factory_cd = :factory_cd ");
                sqlParameter.AddParameterString("factory_cd", inVo.FactoryCode);
            }
            if (inVo.AssetId > 0)
            {
                sql.Append(" and asset_id = :asset_id ");
                sqlParameter.AddParameterInteger("asset_id", inVo.AssetId);
            }
            if (!string.IsNullOrEmpty(inVo.AssetCode))
            {
                sql.Append(" and asset_cd = :asset_cd ");
                sqlParameter.AddParameterString("asset_cd", inVo.AssetCode);
            }

            if (!string.IsNullOrEmpty(inVo.AssetName))
            {
                sql.Append(" and asset_name = :asset_name ");
                sqlParameter.AddParameterString("asset_name", inVo.AssetName);
            }

            if (inVo.AssetNo != 10000)
            {
                sql.Append(" and asset_no =:asset_no ");
                sqlParameter.AddParameter("asset_no", inVo.AssetNo);
            }


            //create command
            //DbCommandAdaptor 
            sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());

            //execute SQL
            IDataReader dataReader = sqlCommandAdapter.ExecuteReader(trxContext, sqlParameter);

            while (dataReader.Read())
            {
                AssetVo outVo = new AssetVo
                {

                    AssetCode = dataReader["asset_cd"].ToString(),
                    AssetNo = int.Parse(dataReader["asset_no"].ToString()),
                    AssetId = int.Parse(dataReader["asset_id"].ToString()),
                    AssetName = dataReader["asset_name"].ToString(),
                    AssetModel = dataReader["asset_model"].ToString(),
                    AssetSuppiler = dataReader["asset_supplier"].ToString(),
                    AssetType = dataReader["asset_type"].ToString(),
                    AssetInvoice = dataReader["asset_invoice"].ToString(),
                    AssetSerial = dataReader["asset_serial"].ToString(),
                    AssetLife = double.Parse(dataReader["asset_life"].ToString()),
                    AcquistionCost = double.Parse(dataReader["acquistion_cost"].ToString()),
                    AcquistionDate = DateTime.Parse(dataReader["acquistion_date"].ToString()),
                    RegistrationUserCode = dataReader["registration_user_cd"].ToString(),
                    RegistrationDateTime = DateTime.Parse(dataReader["registration_date_time"].ToString()),
                    FactoryCode = dataReader["factory_cd"].ToString(),
                    LabelStatus = dataReader["label_status"].ToString(),
                    AssetPO = dataReader["asset_po"].ToString()
                };
                voList.add(outVo);
            }
            dataReader.Close();
            return voList;
        }
    }
}
