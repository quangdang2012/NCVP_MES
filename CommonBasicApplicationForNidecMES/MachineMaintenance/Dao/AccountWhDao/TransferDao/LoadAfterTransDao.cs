using System;
using System.Text;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Vo.AccountWhVo;
using System.Data;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Dao
{
    class LoadAfterTransDao : AbstractDataAccessObject
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

            sql.Append(@"select a.asset_id AssetID, a.asset_cd AssetCode, a.asset_name AssetName, a.asset_no AssetNo from t_transfer_detail_info b
                            left join m_asset a on a.asset_id = b.asset_id
                            left join t_transfer_device c on c.transfer_device_id = b.transfer_device_id
                         where 1 = 1");

            if (!String.IsNullOrEmpty(inVo.TransferDeviceCode))
            {
                sql.Append(@" and c.transfer_device_cd =:transfer_device_cd");
                sqlParameter.AddParameterString("transfer_device_cd", inVo.TransferDeviceCode);
            }

            sql.Append(" order by a.asset_cd");
            sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());

            //execute SQL
            DataSet da = sqlCommandAdapter.ExecuteDataSet(sqlParameter);
            

            //IDataReader dataReader = sqlCommandAdapter.ExecuteReader(trxContext, sqlParameter);

            //while (dataReader.Read())
            //{
            //    TransferVo outVo = new TransferVo
            //    {
            //        AssetCode = dataReader["asset_cd"].ToString(),
            //        AssetName = dataReader["asset_name"].ToString(),
            //        AssetNo = int.Parse(dataReader["asset_no"].ToString()),
            //        AssetID = int.Parse(dataReader["asset_id"].ToString())
            //    };
            //    voList.add(outVo);
            //}
            TransferVo outVo2 = new TransferVo
            {
                dt = da.Tables[0]
            };
            //dataReader.Close();
            return outVo2;
        }

    }
}
