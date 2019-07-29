using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Vo.AccountWhVo;
using Com.Nidec.Mes.Framework;
using System;
using System.Data;
using System.Text;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Dao
{
    public class CheckAssetDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            AssetVo inVo = (AssetVo)vo;
            StringBuilder sql = new StringBuilder();
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, string.Empty);
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            sql.Append("Select Count(*) as AssetCount ");
            sql.Append(" from  m_asset");
            sql.Append(" Where 1=1 ");
    
            if (!String.IsNullOrEmpty(inVo.FactoryCode))
            {
                sql.Append(" and factory_cd = :factory_cd ");
                sqlParameter.AddParameterString("factory_cd", inVo.FactoryCode);
            }
            if (!string.IsNullOrEmpty(inVo.AssetCode))
            {
                sql.Append(" and asset_cd = :asset_cd ");
                sqlParameter.AddParameterString("asset_cd", inVo.AssetCode);
            }
            if (inVo.AssetNo > -1)
            {
                sql.Append(" and asset_no = :asset_no ");
                sqlParameter.AddParameter("asset_no", inVo.AssetNo);
            }
            if (inVo.AssetId > 0)
            {
                sql.Append(" and asset_id != :asset_id "); ///?????
                sqlParameter.AddParameterInteger("asset_id", inVo.AssetId);
            }
          

            sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());

            //execute SQL
            IDataReader dataReader = sqlCommandAdapter.ExecuteReader(trxContext, sqlParameter);
            AssetVo outVo = new AssetVo();
            while (dataReader.Read())
            {
                outVo.AffectedCount = Convert.ToInt32(dataReader["AssetCount"].ToString());
            }
            dataReader.Close();
            return outVo;
        }
    }
}
