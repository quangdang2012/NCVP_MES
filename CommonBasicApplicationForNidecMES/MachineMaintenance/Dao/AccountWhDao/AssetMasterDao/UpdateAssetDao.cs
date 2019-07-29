using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Vo.AccountWhVo;
using Com.Nidec.Mes.Framework;
using System.Text;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Dao
{
    public class UpdateAssetDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            AssetVo inVo = (AssetVo)vo;
            StringBuilder sql = new StringBuilder();
            sql.Append("update m_asset set asset_cd=:asset_cd,asset_no=:asset_no,asset_name=:asset_name, asset_model=:asset_model, asset_invoice =:asset_invoice,  asset_serial =:asset_serial, asset_supplier=:asset_supplier,asset_life =:asset_life, acquistion_date=:acquistion_date, acquistion_cost=:acquistion_cost, asset_type=:asset_type, label_status=:label_status, asset_po = :asset_po");
            sql.Append(" where asset_id =:asset_id");
            
            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            sqlParameter.AddParameterInteger("asset_id", inVo.AssetId);
            sqlParameter.AddParameterInteger("asset_no", inVo.AssetNo);
            sqlParameter.AddParameterString("asset_cd", inVo.AssetCode);
            sqlParameter.AddParameterString("asset_name", inVo.AssetName);
            sqlParameter.AddParameterString("asset_model", inVo.AssetModel);
            sqlParameter.AddParameterString("asset_serial", inVo.AssetSerial);
            sqlParameter.AddParameterString("asset_supplier", inVo.AssetSuppiler);
            sqlParameter.AddParameterString("asset_invoice", inVo.AssetInvoice);
            sqlParameter.AddParameter("asset_life", inVo.AssetLife);
            sqlParameter.AddParameterDateTime("acquistion_date", inVo.AcquistionDate);
            sqlParameter.AddParameter("acquistion_cost", inVo.AcquistionCost);
            sqlParameter.AddParameterString("asset_type", inVo.AssetType);
            sqlParameter.AddParameterString("factory_cd", inVo.FactoryCode);
            sqlParameter.AddParameterString("registration_user_cd", inVo.RegistrationUserCode);
            sqlParameter.AddParameterString("label_status", inVo.LabelStatus);
            sqlParameter.AddParameterString("asset_po", inVo.AssetPO);
            //execute SQL

            AssetVo outVo = new AssetVo
            {
                AffectedCount = sqlCommandAdapter.ExecuteNonQuery(sqlParameter)
            };

            return outVo;
        }
    }
}
