using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Vo.AccountWhVo;
using Com.Nidec.Mes.Framework;
using System;
using System.Text;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Dao
{
    public class DeleteAssetDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            AssetVo inVo = (AssetVo)vo;
            StringBuilder sql = new StringBuilder();
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, string.Empty);
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            sql.Append("delete from  m_asset Where 1=1 ");
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

           

            //create command
            sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());


            //execute SQL

            AssetVo outVo = new AssetVo
            {
                AffectedCount = sqlCommandAdapter.ExecuteNonQuery(sqlParameter)
            };

            return outVo;
        }
    }
}
