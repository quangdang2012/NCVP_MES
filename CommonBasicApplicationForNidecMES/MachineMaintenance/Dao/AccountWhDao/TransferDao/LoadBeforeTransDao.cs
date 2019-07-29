using System;
using System.Text;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Vo.AccountWhVo;
using System.Data;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Dao
{
    class LoadBeforeTransDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            TransferVo inVo = (TransferVo)vo;
            StringBuilder sql = new StringBuilder();
            ValueObjectList<TransferVo> voList = new ValueObjectList<TransferVo>();
            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();

            sql.Append(@"select a.asset_id, a.asset_cd, a.asset_name, a.asset_no from t_warehouse_main b
                            left join m_asset a on a.asset_id = b.asset_id
                            left join m_location c on c.location_id = b.before_location_id
                         where 1 = 1");

            if (!String.IsNullOrEmpty(inVo.LocationCd))
            {
                sql.Append(@" and c.location_cd =:location_cd");
                sqlParameter.AddParameterString("location_cd", inVo.LocationCd);
            }

            if (!String.IsNullOrEmpty(inVo.AssetCode))
            {
                sql.Append(@" and a.asset_cd = :asset_cd");
                sqlParameter.AddParameterString("asset_cd", inVo.AssetCode);
            }

            sql.Append(" order by a.asset_cd");
            sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());

            //execute SQL
            IDataReader dataReader = sqlCommandAdapter.ExecuteReader(trxContext, sqlParameter);

            while (dataReader.Read())
            {
                TransferVo outVo = new TransferVo
                {
                    AssetCode = dataReader["asset_cd"].ToString(),
                    AssetName = dataReader["asset_name"].ToString(),
                    AssetNo = int.Parse(dataReader["asset_no"].ToString()),
                    AssetID = int.Parse(dataReader["asset_id"].ToString())
                };
                voList.add(outVo);
            }
            dataReader.Close();
            return voList;
        }

    }
}
