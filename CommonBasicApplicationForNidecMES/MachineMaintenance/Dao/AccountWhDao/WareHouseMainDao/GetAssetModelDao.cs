using System.Text;
using Com.Nidec.Mes.Framework;
using System.Data;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Vo.AccountWhVo;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Dao
{
    class GetAssetModelDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            AssetVo inVo = (AssetVo)vo;
            StringBuilder sql = new StringBuilder();
            ValueObjectList<AssetVo> voList = new ValueObjectList<AssetVo>();
            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            sql.Append(@"SELECT distinct asset_model from m_asset order by asset_model");

            sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());

            //execute SQL
            IDataReader dataReader = sqlCommandAdapter.ExecuteReader(trxContext, sqlParameter);

            while (dataReader.Read())
            {
                AssetVo outVo = new AssetVo
                {
                    AssetModel = dataReader["asset_model"].ToString()
                };
                voList.add(outVo);
            }
            dataReader.Close();
            return voList;
        }
    }
}